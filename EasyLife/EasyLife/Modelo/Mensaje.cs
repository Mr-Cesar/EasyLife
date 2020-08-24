using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Mensaje
    {
        private long idMensaje;
        private string emisor;
        private string destinatario;
        private Boolean estadoM;
        private string fechaRegistroM;
        private string descripcion;
        private Persona persona;
        private TipoMensaje tipoMensaje;

        public TipoMensaje _tipoMensaje
        {
            get { return tipoMensaje; }
            set { tipoMensaje = value; }
        }

        public Persona _persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public string _descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string _fechaRegistroM
        {
            get { return fechaRegistroM; }
            set { fechaRegistroM = value; }
        }

        public Boolean _estadoM
        {
            get { return estadoM; }
            set { estadoM = value; }
        }

        public string _destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }

        public string _emisor
        {
            get { return emisor; }
            set { emisor = value; }
        }

        public long _idMensaje
        {
            get { return idMensaje; }
            set { idMensaje = value; }
        }
    }
}