using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterPropietario
    {
        private long ID_PERSONA;
        private string FK_RUT;
        private string NOMBRE_PERSONA;
        private string APELLIDO_PERSONA;
        private string TELEFONO_PERSONA;
        private string CORREO_PERSONA;
        private string NUMERO_DEP;
        private string NOMBRE_EDIFICIO;
        private string NOMBRE_CONDOMINIO;
        private Boolean ESTADO_PERSONA;
        private Boolean LUZ;
        private long ID_EDIFICIO;
        private long ID_CONDOMINIO;
        private long ID_DEPARTAMENTO;
        private string SEXO;

        public string _SEXO
        {
            get { return SEXO; }
            set { SEXO = value; }
        }

        public long _ID_DEPARTAMENTO
        {
            get { return ID_DEPARTAMENTO; }
            set { ID_DEPARTAMENTO = value; }
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

        public Boolean _LUZ
        {
            get { return LUZ; }
            set { LUZ = value; }
        }

        public Boolean _ESTADO_PERSONA
        {
            get { return ESTADO_PERSONA; }
            set { ESTADO_PERSONA = value; }
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

        public string _NUMERO_DEP
        {
            get { return NUMERO_DEP; }
            set { NUMERO_DEP = value; }
        }

        public string _CORREO_PERSONA
        {
            get { return CORREO_PERSONA; }
            set { CORREO_PERSONA = value; }
        }

        public string _TELEFONO_PERSONA
        {
            get { return TELEFONO_PERSONA; }
            set { TELEFONO_PERSONA = value; }
        }

        public string _APELLIDO_PERSONA
        {
            get { return APELLIDO_PERSONA; }
            set { APELLIDO_PERSONA = value; }
        }

        public string _NOMBRE_PERSONA
        {
            get { return NOMBRE_PERSONA; }
            set { NOMBRE_PERSONA = value; }
        }

        public string _FK_RUT
        {
            get { return FK_RUT; }
            set { FK_RUT = value; }
        }

        public long _ID_PERSONA
        {
            get { return ID_PERSONA; }
            set { ID_PERSONA = value; }
        }
    }
}