using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Direccion
    {
        private long idDireccion;
        private string calle;
        private int numero;
        private Condominio condominio;
        private Comuna comuna;

        public Comuna _comuna
        {
            get { return comuna; }
            set { comuna = value; }
        }

        public Condominio _condominio
        {
            get { return condominio; }
            set { condominio = value; }
        }

        public int _numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string _calle
        {
            get { return calle; }
            set { calle = value; }
        }

        public long _idDireccion
        {
            get { return idDireccion; }
            set { idDireccion = value; }
        }
    }
}