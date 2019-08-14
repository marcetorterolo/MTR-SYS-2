// <copyright file="MemoriaHandler.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Handler
{
    using System.Collections.Generic;
    using System.Linq;
    using MTRSYS.Web.Models.DataTypes;
    using MTRSYS.Web.Models.Entidades;

    /// <summary>
    /// Manejador de Memoria.
    /// Se aplica patron Singleton.
    /// </summary>
    public class MemoriaHandler
    {
        private static MemoriaHandler instance = null;

        private MemoriaHandler()
        {
            this.ListaMemorias = new List<Memoria>();
        }

        /// <summary>
        /// Gets instance.
        /// </summary>
        /// <returns>MemoriaHandler.</returns>
        public static MemoriaHandler GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MemoriaHandler();
                }

                return instance;
            }
        }

        private List<Memoria> ListaMemorias { get; set; }

        /// <summary>
        /// Crea una entidad de tipo MEMORIA y lo agrega a la coleccion "ListaMemorias".
        /// En la coleccion no se admiten ID repetidos.
        /// </summary>
        /// <param name="pDTMemoria">DataType con los datos del procesador.</param>
        public void AgregarMemoria(DTMemoria pDTMemoria)
        {
            if (pDTMemoria != null)
            {
                // verifico que no exista
                var m = this.ListaMemorias.Where(x => x.Id == pDTMemoria.Id).FirstOrDefault();

                if (m == null)
                {
                    Memoria newMemoria;
                    newMemoria = new Memoria() { Id = pDTMemoria.Id, Capacidad = pDTMemoria.Capacidad, Marca = pDTMemoria.Marca };
                    this.ListaMemorias.Add(newMemoria);
                }
            }
        }

        /// <summary>
        /// Retorna una memoria con el id 'pId' o null si no lo encuentra.
        /// </summary>
        /// <param name="pId">Id del procesador.</param>
        /// <returns>Memoria or null.</returns>
        public Memoria GetMemoria(int pId)
        {
            Memoria result = null;
            foreach (Memoria item in this.ListaMemorias)
            {
                if (item.Id == pId)
                {
                    return item;
                }
            }

            return result;
        }

        /// <summary>
        /// Retorna una lista con los ID's de las memorias en la coleccion "ListaMemorias".
        /// </summary>
        /// <returns>Lista de enteros.</returns>
        public List<int> GetIds()
        {
            List<int> res = new List<int>();
            foreach (Memoria item in this.ListaMemorias)
            {
                res.Add(item.Id);
            }

            return res;
        }
    }
}