// <copyright file="Computadora.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Models.Entidades
{
    using System.Globalization;

    /// <summary>
    /// Clase que representa una computadora en el sistema.
    /// </summary>
    public class Computadora
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Computadora"/> class.
        /// </summary>
        public Computadora()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Computadora"/> class.
        /// </summary>
        /// <param name="pDisco">Disco a usar por la computadora.</param>
        /// <param name="pProcesador">Procesador a usar por la computadora.</param>
        /// <param name="pMemoria">Memoria a usar por la computadora.</param>
        /// <param name="pNombre">Nombre de la computadora.</param>
        public Computadora(Disco pDisco, Procesador pProcesador, Memoria pMemoria, string pNombre)
        {
            if (pDisco != null && pProcesador != null && pMemoria != null)
            {
                this.Id = pDisco.Id.ToString(CultureInfo.InvariantCulture) + pProcesador.Id.ToString(CultureInfo.InvariantCulture) + pMemoria.Id.ToString(CultureInfo.InvariantCulture);
                this.Disco = pDisco;
                this.Procesador = pProcesador;
                this.Memoria = pMemoria;
                this.Nombre = string.IsNullOrEmpty(pNombre) ? "PC (" + this.Id + ")" : pNombre;
            }
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets Disco.
        /// </summary>
        public Disco Disco { get; set; }

        /// <summary>
        /// Gets or sets Procesador.
        /// </summary>
        public Procesador Procesador { get; set; }

        /// <summary>
        /// Gets or sets Memoria.
        /// </summary>
        public Memoria Memoria { get; set; }

        /// <summary>
        /// Gets or sets Nombre.
        /// </summary>
        public string Nombre { get; set; }
    }
}