using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Turno
    {
        private long idTurno;
        private string descripcionTurno;
        private string fechaInicio;
        private string fechaTermino;

        public string _fechaTermino
        {
            get { return fechaTermino; }
            set { fechaTermino = value; }
        }

        public string _fechaInicio
        {
            get { return fechaInicio; }
            set { fechaInicio = value; }
        }

        public string _descripcionTurno
        {
            get { return descripcionTurno; }
            set { descripcionTurno = value; }
        }

        public long _idTurno
        {
            get { return idTurno; }
            set { idTurno = value; }
        }
    }
}