// <copyright file="ComputadoraHandler.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Handler
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using MTRSYS.Web.Models.DataTypes;
    using MTRSYS.Web.Models.Entidades;

    /// <summary>
    /// Manejador de Computadora.
    /// Se aplica patron Singleton.
    /// </summary>
    public class ComputadoraHandler
    {
        private static ComputadoraHandler instance = null;

        private ComputadoraHandler()
        {
            this.ListaComputadoras = new List<Computadora>();
            this.HandlerDiscos = DiscoHandler.GetInstance;
            this.HandlerMemoria = MemoriaHandler.GetInstance;
            this.HandlerProcesador = ProcesadorHandler.GetInstance;
        }

        /// <summary>
        /// Gets instance.
        /// </summary>
        /// <returns>ComputadoraHandler.</returns>
        public static ComputadoraHandler GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ComputadoraHandler();
                }

                return instance;
            }
        }

        private List<Computadora> ListaComputadoras { get; set; }

        private DiscoHandler HandlerDiscos { get; set; }

        private MemoriaHandler HandlerMemoria { get; set; }

        private ProcesadorHandler HandlerProcesador { get; set; }

        /// <summary>
        /// Crea una entidad de tipo COMPUTADORA y lo agrega a la coleccion "ListaComputadoras".
        /// En la coleccion no se admiten ID repetidos.
        /// </summary>
        /// <param name="pNombre">Nombre de la computadora, la cual es identificada por la terna (d,p,m) que se
        /// tratan los id de los componentes (disco, procesador, memoria).</param>
        /// <param name="pDId">Id del disco que usa.</param>
        /// <param name="pPId">Id del procesador que usa.</param>
        /// <param name="pMId">Id de la memoria que usa.</param>
        public void AgregarComputadora(string pNombre, int pDId, int pPId, int pMId)
        {
            Disco d = this.HandlerDiscos.GetDisco(pDId);
            Memoria m = this.HandlerMemoria.GetMemoria(pMId);
            Procesador p = this.HandlerProcesador.GetProcesador(pPId);

            string id = pDId.ToString(CultureInfo.InvariantCulture) + pPId.ToString(CultureInfo.InvariantCulture) + pMId.ToString(CultureInfo.InvariantCulture);

            // verifico que no exista computadora con el mismo id (disco-proc-mem)
            var pc = this.ListaComputadoras.Where(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            if (pc == null)
            {
                Computadora newPC = new Computadora(d, p, m, pNombre);
                this.ListaComputadoras.Add(newPC);
            }
        }

        /// <summary>
        /// Crea una entidad de tipo COMPUTADORA y lo agrega a la coleccion "ListaComputadoras".
        /// En la coleccion no se admiten ID repetidos.
        /// </summary>
        /// <param name="pMemCap">Entero para indicar la capacidad mínima de la memorias RAM.</param>
        /// <returns>Lista de DataType DTComputadora.</returns>
        public List<DTComputadora> GetComputadoras(int pMemCap)
        {
            List<DTComputadora> result = new List<DTComputadora>();

            foreach (Computadora item in this.ListaComputadoras)
            {
                if (item.Memoria.Capacidad >= pMemCap)
                {
                    result.Add(new DTComputadora(item.Nombre, item.Memoria.Marca, item.Memoria.Capacidad.ToString(CultureInfo.InvariantCulture), item.Disco.GetTipo() == TipoDisco.HDD ? "Hard Drive" : "Solid State", item.Disco.Marca, item.Disco.Capacidad.ToString(CultureInfo.InvariantCulture), item.Procesador.Modelo));
                }
            }

            return result;
        }
    }
}