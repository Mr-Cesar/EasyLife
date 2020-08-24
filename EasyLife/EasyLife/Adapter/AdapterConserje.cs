using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterConserje
    {
        private long ID_CONSERJE;
        private long ID_PERSONA;
        private long ID_LOGIN;
        private string NOMBRE_PERSONA;
        private string APELLIDO_PERSONA;
        private string FK_RUT;
        private string TELEFONO_PERSONA;
        private string CORREO_PERSONA;
        private Boolean ESTADO_PERSONA;
        private string SEXO;
        private long ID_CONDOMINIO;
        private string NOMBRE_CONDOMINIO;

        public string _NOMBRE_CONDOMINIO
        {
            get { return NOMBRE_CONDOMINIO; }
            set { NOMBRE_CONDOMINIO = value; }
        }

        public long _ID_CONDOMINIO
        {
            get { return ID_CONDOMINIO; }
            set { ID_CONDOMINIO = value; }
        }

        public string _SEXO
        {
            get { return SEXO; }
            set { SEXO = value; }
        }

        public Boolean _ESTADO_PERSONA
        {
            get { return ESTADO_PERSONA; }
            set { ESTADO_PERSONA = value; }
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

        public string _FK_RUT
        {
            get { return FK_RUT; }
            set { FK_RUT = value; }
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

        public long _ID_LOGIN
        {
            get { return ID_LOGIN; }
            set { ID_LOGIN = value; }
        }

        public long _ID_PERSONA
        {
            get { return ID_PERSONA; }
            set { ID_PERSONA = value; }
        }

        public long _ID_CONSERJE
        {
            get { return ID_CONSERJE; }
            set { ID_CONSERJE = value; }
        }
    }
}