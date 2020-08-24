using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterLuzDepartamento
    {
        private long ID_LUZ_D;
        private long ID_DEPARTAMENTO;
        private string CODIGO_LUZ_D;
        private string NUMERO_DEP;
        private Boolean ESTADO_LUZ_D;
        private long ID_EDIFICIO;
        private long ID_CONDOMINIO;
        private string NOMBRE_EDIFICIO;
        private string NOMBRE_CONDOMINIO;

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

        public Boolean _ESTADO_LUZ_D
        {
            get { return ESTADO_LUZ_D; }
            set { ESTADO_LUZ_D = value; }
        }

        public string _NUMERO_DEP
        {
            get { return NUMERO_DEP; }
            set { NUMERO_DEP = value; }
        }

        public string _CODIGO_LUZ_D
        {
            get { return CODIGO_LUZ_D; }
            set { CODIGO_LUZ_D = value; }
        }

        public long _ID_DEPARTAMENTO
        {
            get { return ID_DEPARTAMENTO; }
            set { ID_DEPARTAMENTO = value; }
        }

        public long _ID_LUZ_D
        {
            get { return ID_LUZ_D; }
            set { ID_LUZ_D = value; }
        }
    }
}