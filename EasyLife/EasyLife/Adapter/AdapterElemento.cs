using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterElemento
    {
        private long ID_EDIFICIO;
        private string NOMBRE_EDIFICIO;
        private string TIPO;
        private int CANTIDAD;
        private double DIMENSION;
        private int PRECIO;
        private string NUMERO_ELEMENTO;
        private long ID_BODEGA;
        private long ID_EST;
        private string DEP;
        private long ID_DEP;

        public long _ID_DEP
        {
            get { return ID_DEP; }
            set { ID_DEP = value; }
        }

        public string _DEP
        {
            get { return DEP; }
            set { DEP = value; }
        }

        public long _ID_EST
        {
            get { return ID_EST; }
            set { ID_EST = value; }
        }

        public long _ID_BODEGA
        {
            get { return ID_BODEGA; }
            set { ID_BODEGA = value; }
        }

        public string _NUMERO_ELEMENTO
        {
            get { return NUMERO_ELEMENTO; }
            set { NUMERO_ELEMENTO = value; }
        }

        public int _PRECIO
        {
            get { return PRECIO; }
            set { PRECIO = value; }
        }

        public double _DIMENSION
        {
            get { return DIMENSION; }
            set { DIMENSION = value; }
        }

        public int _CANTIDAD
        {
            get { return CANTIDAD; }
            set { CANTIDAD = value; }
        }

        public string _TIPO
        {
            get { return TIPO; }
            set { TIPO = value; }
        }

        public string _NOMBRE_EDIFICIO
        {
            get { return NOMBRE_EDIFICIO; }
            set { NOMBRE_EDIFICIO = value; }
        }

        public long _ID_EDIFICIO
        {
            get { return ID_EDIFICIO; }
            set { ID_EDIFICIO = value; }
        }
    }
}