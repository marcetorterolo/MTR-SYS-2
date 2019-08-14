using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using MTRSYS.Web.Controllers;
using MTRSYS.Web.Models.DataTypes;

namespace MTRSYS.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private List<string> ListaPCs { get; set; }

        private void ArmarListaPC()
        {
            // Armo esta lista (solamente con los nombres), en el mismo orden
            // en que se crean las computadoras en HomeController::CrearComputadoras
            ListaPCs = new List<string>();
            for (int d = 1; d <= 3; d++)
            {
                for (int p = 1; p <= 3; p++)
                {
                    // Prestar atencion que no se usa la memoria con id=1
                    // ya que la misma no deberia ser incluida en el resultado
                    // porque es de capacidad = 4 y se invoca GetComputadoras(8)
                    for (int m = 2; m <= 3; m++)
                    {
                        ListaPCs.Add("PC (" + d.ToString(CultureInfo.InvariantCulture) + p.ToString(CultureInfo.InvariantCulture) + m.ToString(CultureInfo.InvariantCulture) + ")");
                    }
                }
            }
        }

        [TestMethod]
        public void Index()
        {
            ViewResult result = null;
            using (HomeController controller = new HomeController())
            {
                // Act
                result = controller.Index() as ViewResult;
            }

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Se valida que el resultado de la rutina webapi
        /// no sea null.
        /// </summary>
        [TestMethod]
        public void Index2_NotNull()
        {
            ViewResult result = null;
            using (HomeController controller = new HomeController())
            {
                result = controller.Index2(8.ToString(CultureInfo.InvariantCulture)) as ViewResult;
            }

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Se valida la cantidad de elementos devueltos.
        /// </summary>
        [TestMethod]
        public void Index2_Count()
        {
            ViewResult result = null;
            ArmarListaPC();

            using (HomeController controller = new HomeController())
            {
                result = controller.Index2(8.ToString(CultureInfo.InvariantCulture)) as ViewResult;
            }

            List<DTComputadora> computadoras = result.Model as List<DTComputadora>;
            Assert.AreEqual(ListaPCs.Count, computadoras.Count);
        }

        /// <summary>
        /// Se validan los nombres de las computadoras devueltos.
        /// </summary>
        [TestMethod]
        public void Index2_Equals()
        {
            ViewResult result = null;
            ArmarListaPC();

            using (HomeController controller = new HomeController())
            {
                result = controller.Index2(8.ToString(CultureInfo.InvariantCulture)) as ViewResult;
            }

            List<DTComputadora> computadoras = result.Model as List<DTComputadora>;
            for (int i = 0; i < ListaPCs.Count; i++)
            {
                Assert.AreEqual(ListaPCs[i], computadoras[i].Nombre);
            }
        }
    }
}
