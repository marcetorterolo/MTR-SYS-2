// <copyright file="DTComputadora.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Models.DataTypes
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// DataType de Computadora.
    /// </summary>
    public class DTComputadora
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DTComputadora"/> class.
        /// </summary>
        public DTComputadora()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DTComputadora"/> class.
        /// </summary>
        /// <param name="pNombre">Nombre de la computadora.</param>
        /// <param name="pMMarca">Marca de la memoria.</param>
        /// <param name="pMCapacidad">Capacidad de la memoria.</param>
        /// <param name="pDTipo">Tipo del disco.</param>
        /// <param name="pDMarca">Marca del disco.</param>
        /// <param name="pDCapacidad">Capacidad del disco.</param>
        /// <param name="pPModelo">Modelo del procesador.</param>
        public DTComputadora(string pNombre, string pMMarca, string pMCapacidad, string pDTipo, string pDMarca, string pDCapacidad, string pPModelo)
        {
            this.Nombre = pNombre;
            this.MemoriaMarca = pMMarca;
            this.MemoriaCapacidad = pMCapacidad;
            this.DiscoTipo = pDTipo;
            this.DiscoMarca = pDMarca;
            this.DiscoCapacidad = pDCapacidad;
            this.ProcesadorModelo = pPModelo;
        }

        /// <summary>
        /// Gets or sets Nombre.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets MemoriaMarca.
        /// </summary>
        [Display(Name = "RAM (marca)")]
        public string MemoriaMarca { get; set; }

        /// <summary>
        /// Gets or sets MemoriaCapacidad.
        /// </summary>
        [Display(Name = "RAM (marca)")]
        public string MemoriaCapacidad { get; set; }

        /// <summary>
        /// Gets or sets DiscoTipo.
        /// </summary>
        [Display(Name = "Disco (Tipo)")]
        public string DiscoTipo { get; set; }

        /// <summary>
        /// Gets or sets DiscoMarca.
        /// </summary>
        [Display(Name = "Disco (Marca)")]
        public string DiscoMarca { get; set; }

        /// <summary>
        /// Gets or sets DiscoCapacidad.
        /// </summary>
        [Display(Name = "Disco (Capacidad)")]
        public string DiscoCapacidad { get; set; }

        /// <summary>
        /// Gets or sets ProcesadorModelo.
        /// </summary>
        [Display(Name = "Procesador (Modelo)")]
        public string ProcesadorModelo { get; set; }
    }
}