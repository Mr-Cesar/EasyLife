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