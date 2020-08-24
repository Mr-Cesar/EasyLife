using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterControlLuzEdificio
    {
        private long ID_CILUMINACION_E;
        private string CODIGO_LUZ_E;
        private string HORA_INICIO_E;
        private string HORA_TERMINO_E;
        private Boolean ESTADO_LUZ_CE;
        private Boolean ESTADO_CONTROL_E;
        private string NOMBRE_EDIFICIO;
        private long ID_EDIFICIO;

        public long _ID_EDIFICIO
        {
            get { return ID_EDIFICIO; }
            set { ID_EDIFICIO = value; }
        }

        public string _NOMBRE_EDIFICIO
        {
            get { return NOMBRE_EDIFICIO; }
            set { NOMBRE_EDIFICIO = value; }
        }

        public Boolean _ESTADO_CONTROL_E
        {
            get { return ESTADO_CONTROL_E; }
            set { ESTADO_CONTROL_E = value; }
        }

        public Boolean _ESTADO_LUZ_CE
        {
            get { return ESTADO_LUZ_CE; }
            set { ESTADO_LUZ_CE = value; }
        }

        public string _HORA_TERMINO_E
        {
            get { return HORA_TERMINO_E; }
            set { HORA_TERMINO_E = value; }
        }

        public string _HORA_INICIO_E
        {
            get { return HORA_INICIO_E; }
            set { HORA_INICIO_E = value; }
        }

        public string _CODIGO_LUZ_E
        {
            get { return CODIGO_LUZ_E; }
            set { CODIGO_LUZ_E = value; }
        }

        public long _ID_CILUMINACION_E
        {
            get { return ID_CILUMINACION_E; }
            set { ID_CILUMINACION_E = value; }
        }
    }
}