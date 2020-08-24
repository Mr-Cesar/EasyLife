using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Edificio
    {
        private long idEdificio;
        private string nombreEdificio;
        private int pisoEdificio;
        private int cantidadDep;
        private string fechaRegistroE;
        private GastoComun gastoComun;
        private Condominio condominio;

        public Condominio _condominio
        {
            get { return condominio; }
            set { condominio = value; }
        }

        public GastoComun _gastoComun
        {
            get { return gastoComun; }
            set { gastoComun = value; }
        }

        public string _fechaRegistroE
        {
            get { return fechaRegistroE; }
            set { fechaRegistroE = value; }
        }

        public int _cantidadDep
        {
            get { return cantidadDep; }
            set { cantidadDep = value; }
        }

        public int _pisoEdificio
        {
            get { return pisoEdificio; }
            set { pisoEdificio = value; }
        }

        public string _nombreEdificio
        {
            get { return nombreEdificio; }
            set { nombreEdificio = value; }
        }

        public long _idEdificio
        {
            get { return idEdificio; }
            set { idEdificio = value; }
        }
    }
}