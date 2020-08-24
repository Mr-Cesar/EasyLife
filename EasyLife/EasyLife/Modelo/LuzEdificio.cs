using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class LuzEdificio
    {
        private long idLuzE;
        private Edificio edificio;
        private string codigoLuzE;
        private Boolean estadoLuzE;

        public Boolean _estadoLuzE
        {
            get { return estadoLuzE; }
            set { estadoLuzE = value; }
        }

        public string _codigoLuzE
        {
            get { return codigoLuzE; }
            set { codigoLuzE = value; }
        }

        public Edificio _edificio
        {
            get { return edificio; }
            set { edificio = value; }
        }

        public long _idLuzE
        {
            get { return idLuzE; }
            set { idLuzE = value; }
        }
    }
}