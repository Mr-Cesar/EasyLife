using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Departamento
    {
        private long idDep;
        private Persona persona;
        private Edificio edificio;
        private LuzDepartamento luzDepartamento;
        private string numeroDep;
        private string fechaRegistro;

        public string _fechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        public string _numeroDep
        {
            get { return numeroDep; }
            set { numeroDep = value; }
        }

        public LuzDepartamento _luzDepartamento
        {
            get { return luzDepartamento; }
            set { luzDepartamento = value; }
        }

        public Edificio _edificio
        {
            get { return edificio; }
            set { edificio = value; }
        }

        public Persona _persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public long _idDep
        {
            get { return idDep; }
            set { idDep = value; }
        }
    }
}