// <copyright file="Repositorio.cs" company="Marcelo Torterolo">
// Copyright (c) Marcelo Torterolo. All rights reserved.
// </copyright>

namespace MTRSYS.Web.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using MTRSYS.Web.Handler;
    using MTRSYS.Web.Models.DataTypes;
    using MTRSYS.Web.Models.Entidades;

    /// <summary>
    /// Repositorio del sistema.
    /// </summary>
    public class Repositorio
    {
        private static Repositorio instance = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repositorio"/> class.
        /// </summary>
        private Repositorio()
        {
            this.HandlerDiscos = DiscoHandler.GetInstance;
            this.HandlerMemoria = MemoriaHandler.GetInstance;
            this.HandlerProcesador = ProcesadorHandler.GetInstance;
            this.HandlerComputadora = ComputadoraHandler.GetInstance;

            this.CrearDiscos();
            this.CrearProcesadores();
            this.CrearMemorias();
            this.CrearComputadoras();
        }

        /// <summary>
        /// Gets instance.
        /// </summary>
        /// <returns>Repository.</returns>
        public static Repositorio GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Repositorio();
                }

                return instance;
            }
        }

        private DiscoHandler HandlerDiscos { get; set; }

        private MemoriaHandler HandlerMemoria { get; set; }

        private ProcesadorHandler HandlerProcesador { get; set; }

        private ComputadoraHandler HandlerComputadora { get; set; }

        private void CrearDiscos()
        {
            this.HandlerDiscos.AgregarDisco(new DTDisco() { Id = 1, Capacidad = 128, Marca = "Toshiba", Tipo = TipoDisco.SDD });
            this.HandlerDiscos.AgregarDisco(new DTDisco() { Id = 2, Capacidad = 254, Marca = "Samsung", Tipo = TipoDisco.SDD });
            this.HandlerDiscos.AgregarDisco(new DTDisco() { Id = 3, Capacidad = 1024, Marca = "Sony", Tipo = TipoDisco.HDD });
        }

        private void CrearMemorias()
        {
            this.HandlerMemoria.AgregarMemoria(new DTMemoria() { Id = 1, Capacidad = 4, Marca = "OCZ" });
            this.HandlerMemoria.AgregarMemoria(new DTMemoria() { Id = 2, Capacidad = 8, Marca = "Corsair" });
            this.HandlerMemoria.AgregarMemoria(new DTMemoria() { Id = 3, Capacidad = 16, Marca = "Kingston" });
        }

        private void CrearProcesadores()
        {
            this.HandlerProcesador.AgregarProcesador(new DTProcesador() { Id = 1, Marca = "Intel", Modelo = "i5" });
            this.HandlerProcesador.AgregarProcesador(new DTProcesador() { Id = 2, Marca = "AMD", Modelo = "Phenom" });
            this.HandlerProcesador.AgregarProcesador(new DTProcesador() { Id = 3, Marca = "Intel", Modelo = "i3" });
        }

        private void CrearComputadoras()
        {
            List<int> idDisk = this.HandlerDiscos.GetIds();
            List<int> idProc = this.HandlerProcesador.GetIds();
            List<int> idMem = this.HandlerMemoria.GetIds();

            foreach (int d in idDisk)
            {
                foreach (int p in idProc)
                {
                    foreach (int m in idMem)
                    {
                        this.HandlerComputadora.AgregarComputadora("PC (" + d.ToString(CultureInfo.InvariantCulture) + p.ToString(CultureInfo.InvariantCulture) + m.ToString(CultureInfo.InvariantCulture) + ")", d, p, m);
                    }
                }
            }
        }
    }
}