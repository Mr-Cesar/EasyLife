using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Login
    {
        private long idLogin;
        private string rutPersona;
        private string password;
        private Persona persona;

        public Persona _persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public string _password
        {
            get { return password; }
            set { password = value; }
        }

        public string _rutPersona
        {
            get { return rutPersona; }
            set { rutPersona = value; }
        }

        public long _idLogin
        {
            get { return idLogin; }
            set { idLogin = value; }
        }
    }
}