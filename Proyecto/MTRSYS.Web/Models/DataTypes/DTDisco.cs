// <copyright file="DTDisco.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Models.DataTypes
{
    using MTRSYS.Web.Models.Entidades;

    /// <summary>
    /// DataType de Disco.
    /// </summary>
    public class DTDisco
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Capacidad.
        /// </summary>
        public int Capacidad { get; set; }

        /// <summary>
        /// Gets or sets Marca.
        /// </summary>
        public string Marca { get; set; }

        /// <summary>
        /// Gets or sets Tipo.
        /// </summary>
        public TipoDisco Tipo { get; set; }

        /// <summary>
        /// Retorna nombre del tipo de disco.
        /// </summary>
        /// <returns>string.</returns>
        public string GetStringTipo()
        {
            if (this.Tipo == TipoDisco.HDD)
            {
                return "Hard Drive";
            }
            else
            {
                return "Solid State";
            }
        }
    }
}