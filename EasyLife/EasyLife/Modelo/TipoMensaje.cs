using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class TipoMensaje
    {
        private long idTipoMensaje;
        private string descripcionTP;

        public string _descripcionTP
        {
            get { return descripcionTP; }
            set { descripcionTP = value; }
        }

        public long _idTipoMensaje
        {
            get { return idTipoMensaje; }
            set { idTipoMensaje = value; }
        }
    }
}