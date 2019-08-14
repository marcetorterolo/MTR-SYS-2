// <copyright file="Procesador.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Models.Entidades
{
    /// <summary>
    /// Clase que representa un procesador en el sistema.
    /// </summary>
    public class Procesador
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Marca.
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Gets or sets Modelo.
        /// </summary>
        public string Modelo { get; set; }
    }
}