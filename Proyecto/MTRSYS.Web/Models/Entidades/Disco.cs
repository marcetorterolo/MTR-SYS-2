// <copyright file="Disco.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Models.Entidades
{
    /// <summary>
    /// Enumerado que representa los tipos de disco en el sistema.
    /// </summary>
    public enum TipoDisco
    {
        /// <summary>
        /// Disco Duro.
        /// </summary>
        HDD = 0,

        /// <summary>
        /// Disco Solido.
        /// </summary>
        SDD = 1,
    }

    /// <summary>
    /// Clase abstracta que representa un disco en el sistema.
    /// </summary>
    public abstract class Disco
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
        /// Retorna <see cref="TipoDisco"/> del disco.
        /// </summary>
        /// <returns>TipoDisco.</returns>
        public abstract TipoDisco GetTipo();
    }
}