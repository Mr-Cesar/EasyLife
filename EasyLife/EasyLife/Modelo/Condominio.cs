using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Condominio
    {
        private long idCondominio;
        private Persona persona;
        private Direccion direccion;
        private string fechaRegistroCon;
        private string nombreCon;
        private int precioEst;

        public int _precioEst
        {
            get { return precioEst; }
            set { precioEst = value; }
        }

        public string _nombreCon
        {
            get { return nombreCon; }
            set { nombreCon = value; }
        }

        public string _fechaRegistroCon
        {
            get { return fechaRegistroCon; }
            set { fechaRegistroCon = value; }
        }

        public Direccion _direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public Persona _persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public long _idCondominio
        {
            get { return idCondominio; }
            set { idCondominio = value; }
        }
    }
}