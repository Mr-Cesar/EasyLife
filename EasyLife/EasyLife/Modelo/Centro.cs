using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Centro
    {
        private long idCentro;
        private string fechaRegistroC;
        private static TipoCentro tipoCentro;
        private Edificio edificio;
        private string nombreCentro;
        private int costo;

        public int _costo
        {
            get { return costo; }
            set { costo = value; }
        }

        public string _nombreCentro
        {
            get { return nombreCentro; }
            set { nombreCentro = value; }
        }

        public Edificio _edificio
        {
            get { return edificio; }
            set { edificio = value; }
        }

        public TipoCentro _tipoCentro
        {
            get { return tipoCentro; }
            set { tipoCentro = value; }
        }

        public string _fechaRegistroC
        {
            get { return fechaRegistroC; }
            set { fechaRegistroC = value; }
        }

        public long _idCentro
        {
            get { return idCentro; }
            set { idCentro = value; }
        }
    }
}