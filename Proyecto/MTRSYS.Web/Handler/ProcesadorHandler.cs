// <copyright file="ProcesadorHandler.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Handler
{
    using System.Collections.Generic;
    using System.Linq;
    using MTRSYS.Web.Models.DataTypes;
    using MTRSYS.Web.Models.Entidades;

    /// <summary>
    /// Manejador de Procesador.
    /// Se aplica patron Singleton.
    /// </summary>
    public class ProcesadorHandler
    {
        private static ProcesadorHandler instance = null;

        private ProcesadorHandler()
        {
            this.ListaProcesadores = new List<Procesador>();
        }

        /// <summary>
        /// Gets instance.
        /// </summary>
        /// <returns>ProcesadorHandler.</returns>
        public static ProcesadorHandler GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProcesadorHandler();
                }

                return instance;
            }
        }

        private List<Procesador> ListaProcesadores { get; set; }

        /// <summary>
        /// Crea una entidad de tipo PROCESADOR y lo agrega a la coleccion "ListaProcesadores".
        /// En la coleccion no se admiten ID repetidos.
        /// </summary>
        /// <param name="pDTProcesador">DataType con los datos del procesador.</param>
        public void AgregarProcesador(DTProcesador pDTProcesador)
        {
            if (pDTProcesador != null)
            {
                // Verifico no exista
                var p = this.ListaProcesadores.Where(x => x.Id == pDTProcesador.Id).FirstOrDefault();
                if (p == null)
                {
                    Procesador newProcesador;
                    newProcesador = new Procesador() { Id = pDTProcesador.Id, Modelo = pDTProcesador.Modelo, Marca = pDTProcesador.Marca };
                    this.ListaProcesadores.Add(newProcesador);
                }
            }
        }

        /// <summary>
        /// Retorna un procesador con el id 'pId' o null si no lo encuentra.
        /// </summary>
        /// <param name="pId">Id del procesador.</param>
        /// <returns>Procesador or null.</returns>
        public Procesador GetProcesador(int pId)
        {
            Procesador result = null;
            foreach (Procesador item in this.ListaProcesadores)
            {
                if (item.Id == pId)
                {
                    return item;
                }
            }

            return result;
        }

        /// <summary>
        /// Retorna una lista con los ID's de los procesadores en la coleccion "ListaProcesadores".
        /// </summary>
        /// <returns>Lista de enteros.</returns>
        public List<int> GetIds()
        {
            List<int> res = new List<int>();
            foreach (Procesador item in this.ListaProcesadores)
            {
                res.Add(item.Id);
            }

            return res;
        }
    }
}