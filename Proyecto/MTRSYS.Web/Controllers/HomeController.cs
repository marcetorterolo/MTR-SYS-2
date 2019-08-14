// <copyright file="HomeController.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web.Mvc;
    using MTRSYS.Web.Handler;
    using MTRSYS.Web.Models.DataTypes;
    using MTRSYS.Web.Models.Entidades;
    using MTRSYS.Web.Repository;

    /// <summary>
    /// Controlador de presentación Home.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeController()
        {
            // Se crea el repostorio con todos los elementos
            // del sistema: discos, memorias, procesadores y computadoras
            _ = Repositorio.GetInstance;
        }

        /// <summary>
        /// Retorna la vista correspondiente al link Index1.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            // Esta vista invoca (en el script Home/Home.js)
            // al servicio HomeService/GetComputadoras
            return this.View();
        }

        /// <summary>
        /// Retorna la vista correspondiente al link Index2.
        /// </summary>
        /// <param name="capacidad">Capacidad mínima de las memorias RAM.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        public ActionResult Index2(string capacidad)
        {
            List<DTComputadora> pcs = ComputadoraHandler.GetInstance.GetComputadoras(Convert.ToInt32(capacidad, CultureInfo.InvariantCulture));
            return this.View(pcs);
        }
    }
}