using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class ControlIluminacionDep
    {
        private long idCIDep;
        private LuzDepartamento luzDepartamento;
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

        public LuzDepartamento _luzDepartamento
        {
            get { return luzDepartamento; }
            set { luzDepartamento = value; }
        }

        public long _idCIDep
        {
            get { return idCIDep; }
            set { idCIDep = value; }
        }
    }
}