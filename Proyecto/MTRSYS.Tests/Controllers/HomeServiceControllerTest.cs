using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using MTRSYS.Web.Controllers;
using MTRSYS.Web.Models.DataTypes;
using System.Linq;

namespace MTRSYS.Tests.Controllers
{
    [TestClass]
    public class HomeServiceControllerTest
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

        /// <summary>
        /// Se valida que el resultado de la rutina webapi
        /// no sea null.
        /// </summary>
        [TestMethod]
        public void GetComputadoras_NotNull()
        {
            IEnumerable<DTComputadora> result = null;
            using (HomeServiceController cHomeService = new HomeServiceController())
            {
                // Arrange
                result = cHomeService.GetComputadoras(8);
            }

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Se valida la cantidad de elementos devueltos por la rutina webapi.
        /// </summary>
        [TestMethod]
        public void GetComputadoras_Count()
        {
            ArmarListaPC();
            IEnumerable<DTComputadora> result = null;

            using (HomeServiceController cHomeService = new HomeServiceController())
            {
                // Arrange
                result = cHomeService.GetComputadoras(8);
            }

            List<DTComputadora> resultAsList = result.ToList();
            // Assert
            Assert.AreEqual(ListaPCs.Count, resultAsList.Count);
        }

        /// <summary>
        /// Se validan los nombres de las computadoras devueltos por la rutina webapi.
        /// </summary>
        [TestMethod]
        public void GetComputadoras_Equals()
        {
            ArmarListaPC();
            IEnumerable<DTComputadora> result = null;

            using (HomeServiceController cHomeService = new HomeServiceController())
            {
                // Arrange
                result = cHomeService.GetComputadoras(8);
            }

            List<DTComputadora> resultAsList = result.ToList();
            // Controlo los nombres de las computadoras creadas sean correctos
            for (int i = 0; i < ListaPCs.Count; i++)
            {
                // Assert
                Assert.AreEqual(ListaPCs[i], resultAsList[i].Nombre);
            }
        }
    }
}
