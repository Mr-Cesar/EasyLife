using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterControlLuzDepartamento
    {
        private long ID_CILUMINACION_D;
        private string CODIGO_LUZ_D;
        private string HORA_INICIO_D;
        private string HORA_TERMINO_D;
        private Boolean ESTADO_LUZ_CD;
        private Boolean ESTADO_CONTROL_D;
        private string NUMERO_DEP;
        private long ID_DEPARTAMENTO;

        public long _ID_DEPARTAMENTO
        {
            get { return ID_DEPARTAMENTO; }
            set { ID_DEPARTAMENTO = value; }
        }

        public string _NUMERO_DEP
        {
            get { return NUMERO_DEP; }
            set { NUMERO_DEP = value; }
        }

        public Boolean _ESTADO_CONTROL_D
        {
            get { return ESTADO_CONTROL_D; }
            set { ESTADO_CONTROL_D = value; }
        }

        public Boolean _ESTADO_LUZ_CD
        {
            get { return ESTADO_LUZ_CD; }
            set { ESTADO_LUZ_CD = value; }
        }

        public string _HORA_TERMINO_D
        {
            get { return HORA_TERMINO_D; }
            set { HORA_TERMINO_D = value; }
        }

        public string _HORA_INICIO_D
        {
            get { return HORA_INICIO_D; }
            set { HORA_INICIO_D = value; }
        }

        public string _CODIGO_LUZ_D
        {
            get { return CODIGO_LUZ_D; }
            set { CODIGO_LUZ_D = value; }
        }

        public long _ID_CILUMINACION_D
        {
            get { return ID_CILUMINACION_D; }
            set { ID_CILUMINACION_D = value; }
        }
    }
}