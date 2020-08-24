using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class LuzDepartamento
    {
        private long idLuzD;
        private Departamento departamento;
        private string codigoLuzD;
        private Boolean estadoLuzD;

        public Boolean _estadoLuzD
        {
            get { return estadoLuzD; }
            set { estadoLuzD = value; }
        }

        public string _codigoLuzD
        {
            get { return codigoLuzD; }
            set { codigoLuzD = value; }
        }

        public Departamento _departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        public long _idLuzD
        {
            get { return idLuzD; }
            set { idLuzD = value; }
        }
    }
}