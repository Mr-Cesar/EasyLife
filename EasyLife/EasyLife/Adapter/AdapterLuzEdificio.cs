using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterLuzEdificio
    {
        private long ID_LUZ_E;
        private long ID_EDIFICIO;
        private long ID_CONDOMINIO;
        private string CODIGO_LUZ_E;
        private string NOMBRE_EDIFICIO;
        private string NOMBRE_CONDOMINIO;
        private Boolean ESTADO_LUZ_E;

        public Boolean _ESTADO_LUZ_E
        {
            get { return ESTADO_LUZ_E; }
            set { ESTADO_LUZ_E = value; }
        }

        public string _NOMBRE_CONDOMINIO
        {
            get { return NOMBRE_CONDOMINIO; }
            set { NOMBRE_CONDOMINIO = value; }
        }

        public string _NOMBRE_EDIFICIO
        {
            get { return NOMBRE_EDIFICIO; }
            set { NOMBRE_EDIFICIO = value; }
        }

        public string _CODIGO_LUZ_E
        {
            get { return CODIGO_LUZ_E; }
            set { CODIGO_LUZ_E = value; }
        }

        public long _ID_CONDOMINIO
        {
            get { return ID_CONDOMINIO; }
            set { ID_CONDOMINIO = value; }
        }

        public long _ID_EDIFICIO
        {
            get { return ID_EDIFICIO; }
            set { ID_EDIFICIO = value; }
        }

        public long _ID_LUZ_E
        {
            get { return ID_LUZ_E; }
            set { ID_LUZ_E = value; }
        }
    }
}