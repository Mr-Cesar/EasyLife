using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Estacionamiento
    {
        private long idEstacionamiento;
        private Edificio edificio;
        private string numeroEstacionamiento;
        private int precioEstacionamiento;
        private Departamento departamento;

        public Departamento _departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        public int _precioEstacionamiento
        {
            get { return precioEstacionamiento; }
            set { precioEstacionamiento = value; }
        }

        public string _numeroEstacionamiento
        {
            get { return numeroEstacionamiento; }
            set { numeroEstacionamiento = value; }
        }

        public Edificio _edificio
        {
            get { return edificio; }
            set { edificio = value; }
        }

        public long _idEstacionamiento
        {
            get { return idEstacionamiento; }
            set { idEstacionamiento = value; }
        }
    }
}