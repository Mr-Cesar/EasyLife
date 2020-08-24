using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class ControlIluminacionEdificio
    {
        private long idCIE;
        private LuzEdificio luzEdificio;
        private string horaInicio;
        private string horaTermino;
        private Boolean estadoLuzC;
        private Boolean estadoControl;

        public Boolean _estadoControl
        {
            get { return estadoControl; }
            set { estadoControl = value; }
        }

        public Boolean _estadoLuzC
        {
            get { return estadoLuzC; }
            set { estadoLuzC = value; }
        }

        public string _horaTermino
        {
            get { return horaTermino; }
            set { horaTermino = value; }
        }

        public string _horaInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }

        public LuzEdificio _luzEdificio
        {
            get { return luzEdificio; }
            set { luzEdificio = value; }
        }

        public long _idCIE
        {
            get { return idCIE; }
            set { idCIE = value; }
        }
    }
}