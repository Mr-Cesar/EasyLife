using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterEdificio
    {
        private long ID_EDIFICIO;
        private string NOMBRE_EDIFICIO;
        private int CANTIDAD_PISO;
        private int CANTIDAD_DEPARTAMENTO;
        private int TOTAL_GASTO;
        private string CODIGO_LUZ_E;
        private long ID_CONDOMINIO;
        private string NOMBRE_CONDOMINIO;
        private double DIMENSION_EDIFICIO;

        public double _DIMENSION_EDIFICIO
        {
            get { return DIMENSION_EDIFICIO; }
            set { DIMENSION_EDIFICIO = value; }
        }

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

        public string _CODIGO_LUZ_E
        {
            get { return CODIGO_LUZ_E; }
            set { CODIGO_LUZ_E = value; }
        }

        public int _TOTAL_GASTO
        {
            get { return TOTAL_GASTO; }
            set { TOTAL_GASTO = value; }
        }

        public int _CANTIDAD_DEPARTAMENTO
        {
            get { return CANTIDAD_DEPARTAMENTO; }
            set { CANTIDAD_DEPARTAMENTO = value; }
        }

        public int _CANTIDAD_PISO
        {
            get { return CANTIDAD_PISO; }
            set { CANTIDAD_PISO = value; }
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