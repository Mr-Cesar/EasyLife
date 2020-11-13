using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterMensaje
    {
        private long ID_MENSAJE;
        private long ID_PERSONA;
        private string DESCRIPCION_MENSAJE;
        private string EMISOR_MENSAJE;
        private string DESTINATARIO_MENSAJE;
        private string DESCRIPCION_TP;

        public string _DESCRIPCION_TP
        {
            get { return DESCRIPCION_TP; }
            set { DESCRIPCION_TP = value; }
        }

        public string _DESTINATARIO_MENSAJE
        {
            get { return DESTINATARIO_MENSAJE; }
            set { DESTINATARIO_MENSAJE = value; }
        }

        public string _EMISOR_MENSAJE
        {
            get { return EMISOR_MENSAJE; }
            set { EMISOR_MENSAJE = value; }
        }

        public string _DESCRIPCION_MENSAJE
        {
            get { return DESCRIPCION_MENSAJE; }
            set { DESCRIPCION_MENSAJE = value; }
        }

        public long _ID_PERSONA
        {
            get { return ID_PERSONA; }
            set { ID_PERSONA = value; }
        }

        public long _ID_MENSAJE
        {
            get { return ID_MENSAJE; }
            set { ID_MENSAJE = value; }
        }
    }
}