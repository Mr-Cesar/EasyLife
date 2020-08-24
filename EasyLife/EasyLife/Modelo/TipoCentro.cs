using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class TipoCentro
    {
        private long idTipoCentro;
        private string nombreTC;
        private string fechaRegistroTC;

        public string _fechaRegistroTC
        {
            get { return fechaRegistroTC; }
            set { fechaRegistroTC = value; }
        }

        public string _nombreTC
        {
            get { return nombreTC; }
            set { nombreTC = value; }
        }

        public long _idTipoCentro
        {
            get { return idTipoCentro; }
            set { idTipoCentro = value; }
        }
    }
}