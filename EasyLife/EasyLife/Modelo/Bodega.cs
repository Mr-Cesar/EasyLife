using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Bodega
    {
        private long idBodega;
        private Edificio edificio;
        private float dimensionBodega;
        private string numeroBodega;
        private Departamento departamento;

        public Departamento _departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        public string _numeroBodega
        {
            get { return numeroBodega; }
            set { numeroBodega = value; }
        }

        public float _dimensionBodega
        {
            get { return dimensionBodega; }
            set { dimensionBodega = value; }
        }

        public Edificio _edificio
        {
            get { return edificio; }
            set { edificio = value; }
        }

        public long _idBodega
        {
            get { return idBodega; }
            set { idBodega = value; }
        }
    }
}