using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Persona
    {
        private long idPersona;
        private string nombrePersona;
        private string apellidoPersona;
        private string rutPersona;
        private string telefonoPersona;
        private string correoPersona;
        private Boolean estadoPersona;
        private string fechaRegistroP;
        private Login login;
        private Rol rol;
        private Boolean luz;
        private Char sexo;

        public Char _sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public Boolean _luz
        {
            get { return luz; }
            set { luz = value; }
        }

        public Rol _rol
        {
            get { return rol; }
            set { rol = value; }
        }

        public Login _login
        {
            get { return login; }
            set { login = value; }
        }

        public string _fechaRegistroP
        {
            get { return fechaRegistroP; }
            set { fechaRegistroP = value; }
        }

        public Boolean _estadoPersona
        {
            get { return estadoPersona; }
            set { estadoPersona = value; }
        }

        public string _correoPersona
        {
            get { return correoPersona; }
            set { correoPersona = value; }
        }

        public string _telefonoPersona
        {
            get { return telefonoPersona; }
            set { telefonoPersona = value; }
        }

        public string _rutPersona
        {
            get { return rutPersona; }
            set { rutPersona = value; }
        }

        public string _apellidoPersona
        {
            get { return apellidoPersona; }
            set { apellidoPersona = value; }
        }

        public string _nombrePersona
        {
            get { return nombrePersona; }
            set { nombrePersona = value; }
        }

        public long _idPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }
    }
}