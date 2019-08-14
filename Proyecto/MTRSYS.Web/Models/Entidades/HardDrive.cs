// <copyright file="HardDrive.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Models.Entidades
{
    /// <summary>
    /// Clase derivada de <see cref="Disco"/> que representa un disco duro en el sistema.
    /// </summary>
    public class HardDrive : Disco
    {
        /// <summary>
        /// Retorna <see cref="TipoDisco"/> del disco.
        /// </summary>
        /// <returns>TipoDisco.</returns>
        public override TipoDisco GetTipo()
        {
            return TipoDisco.HDD;
        }
    }
}