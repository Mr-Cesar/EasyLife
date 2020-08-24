using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterMulta
    {
        private long ID_MULTA;
        private long ID_DEPARTAMENTO;
        private string MOTIVO;
        private long COSTO_MULTA;
        private Boolean ESTADO_MULTA;
        private string NUMERO_DEP;

        public string _NUMERO_DEP
        {
            get { return NUMERO_DEP; }
            set { NUMERO_DEP = value; }
        }

        public Boolean _ESTADO_MULTA
        {
            get { return ESTADO_MULTA; }
            set { ESTADO_MULTA = value; }
        }

        public long _COSTO_MULTA
        {
            get { return COSTO_MULTA; }
            set { COSTO_MULTA = value; }
        }

        public string _MOTIVO
        {
            get { return MOTIVO; }
            set { MOTIVO = value; }
        }

        public long _ID_DEPARTAMENTO
        {
            get { return ID_DEPARTAMENTO; }
            set { ID_DEPARTAMENTO = value; }
        }

        public long _ID_MULTA
        {
            get { return ID_MULTA; }
            set { ID_MULTA = value; }
        }
    }
}