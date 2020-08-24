using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Conserje
    {
        private long idConserje;
        private string fechaRegistroCon;
        private Persona persona;
        private Condominio condominio;

        public Condominio _condominio
        {
            get { return condominio; }
            set { condominio = value; }
        }

        public Persona _persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public string _fechaRegistroCon
        {
            get { return fechaRegistroCon; }
            set { fechaRegistroCon = value; }
        }

        public long _idConserje
        {
            get { return idConserje; }
            set { idConserje = value; }
        }
    }
}