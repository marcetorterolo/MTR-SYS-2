// <copyright file="DTProcesador.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Models.DataTypes
{
    /// <summary>
    /// DataType de Procesador.
    /// </summary>
    public class DTProcesador
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