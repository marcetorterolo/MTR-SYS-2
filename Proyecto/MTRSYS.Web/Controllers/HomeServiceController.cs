// <copyright file="HomeServiceController.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using MTRSYS.Web.Handler;
    using MTRSYS.Web.Models.DataTypes;
    using MTRSYS.Web.Repository;

    /// <summary>
    /// Controlador de servicio Home.
    /// </summary>
    public class HomeServiceController : ApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeServiceController"/> class.
        /// </summary>
        public HomeServiceController()
        {
            // Se crea el repostorio con todos los elementos
            // del sistema: discos, memorias, procesadores y computadoras
            _ = Repositorio.GetInstance;

            this.HandlerComputadora = ComputadoraHandler.GetInstance;
        }

        private ComputadoraHandler HandlerComputadora { get; set; }

        /// <summary>
        /// Retorna los datos de las computadoras cuya memoria RAM sea mayor
        /// o igual al valor indicado por <paramref name="capacidad"/>.
        /// </summary>
        /// <param name="capacidad">Capacidad mínima de la memorias RAM.</param>
        /// <returns>Lista de <see cref="DTComputadora"/>.</returns>
        // GET: api/homeservice/8
        [HttpGet]
        public IEnumerable<DTComputadora> GetComputadoras(int capacidad)
        {
            List<DTComputadora> pcs = this.HandlerComputadora.GetComputadoras(capacidad);
            return pcs;
        }
    }
}