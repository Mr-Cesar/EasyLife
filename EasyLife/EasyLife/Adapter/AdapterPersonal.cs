using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterPersonal
    {
        private long ID_PERSONA;
        private string DESCRIPCION_ROL;
        private string FK_RUT;
        private string NOMBRE_PERSONA;
        private string APELLIDO_PERSONA;
        private string TELEFONO_PERSONA;
        private string CORREO_PERSONA;
        private Boolean ESTADO_PERSONA;

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

        public string _DESCRIPCION_ROL
        {
            get { return DESCRIPCION_ROL; }
            set { DESCRIPCION_ROL = value; }
        }

        public long _ID_PERSONA
        {
            get { return ID_PERSONA; }
            set { ID_PERSONA = value; }
        }
    }
}