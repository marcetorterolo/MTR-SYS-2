// <copyright file="DiscoHandler.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Handler
{
    using System.Collections.Generic;
    using System.Linq;
    using MTRSYS.Web.Models.DataTypes;
    using MTRSYS.Web.Models.Entidades;

    /// <summary>
    /// Manejador de Disco.
    /// Se aplica patron Singleton.
    /// </summary>
    public class DiscoHandler
    {
        private static DiscoHandler instance = null;

        private DiscoHandler()
        {
            this.ListaDiscos = new List<Disco>();
        }

        /// <summary>
        /// Gets instance.
        /// </summary>
        /// <returns>DiscoHandler.</returns>
        public static DiscoHandler GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DiscoHandler();
                }

                return instance;
            }
        }

        private List<Disco> ListaDiscos { get; set; }

        /// <summary>
        /// Crea una entidad de tipo DISCO y lo agrega a la coleccion "ListaDiscos".
        /// En la coleccion no se admiten ID repetidos.
        /// </summary>
        /// <param name="pDTDisco">DataType con los datos del disco.</param>
        public void AgregarDisco(DTDisco pDTDisco)
        {
            if (pDTDisco != null)
            {
                // verifico que no exista
                var d = this.ListaDiscos.Where(x => x.Id == pDTDisco.Id).FirstOrDefault();
                if (d == null)
                {
                    Disco newDisco;
                    if (pDTDisco.Tipo == 0)
                    {
                        // HDD
                        newDisco = new HardDrive() { Id = pDTDisco.Id, Capacidad = pDTDisco.Capacidad, Marca = pDTDisco.Marca };
                    }
                    else
                    {
                        // SDD
                        newDisco = new SolidState() { Id = pDTDisco.Id, Capacidad = pDTDisco.Capacidad, Marca = pDTDisco.Marca };
                    }

                    this.ListaDiscos.Add(newDisco);
                }
            }
        }

        /// <summary>
        /// Retorna un disco con el id 'pId' o null si no lo encuentra.
        /// </summary>
        /// <param name="pId">Id del disco.</param>
        /// <returns>Disco or null.</returns>
        public Disco GetDisco(int pId)
        {
            Disco result = null;
            foreach (Disco item in this.ListaDiscos)
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
            foreach (Disco item in this.ListaDiscos)
            {
                res.Add(item.Id);
            }

            return res;
        }
    }
}