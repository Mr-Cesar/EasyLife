using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterGastoComun
    {
        private long ID_GASTOS;
        private string NOMBRE_EDIFICIO;
        private int GASTO_CONSERJE;
        private int GASTO_GUARDIA;
        private int GASTO_MANTENCION_AREAS;
        private int GASTO_CAMARAS;
        private int GASTO_ARTICULOS_ASEO;
        private int GASTOS_ASEO;
        private int GASTO_ASCENSOR;
        private int GASTO_AGUA_CALIENTE;
        private int GASTO_OTRO;
        private int TOTAL_GASTO;
        private string MES;
        private string ANO;
        private long ID_EDIFICIO;

        public long _ID_EDIFICIO
        {
            get { return ID_EDIFICIO; }
            set { ID_EDIFICIO = value; }
        }

        public string _ANO
        {
            get { return ANO; }
            set { ANO = value; }
        }

        public string _MES
        {
            get { return MES; }
            set { MES = value; }
        }

        public int _TOTAL_GASTO
        {
            get { return TOTAL_GASTO; }
            set { TOTAL_GASTO = value; }
        }

        public int _GASTO_OTRO
        {
            get { return GASTO_OTRO; }
            set { GASTO_OTRO = value; }
        }

        public int _GASTO_AGUA_CALIENTE
        {
            get { return GASTO_AGUA_CALIENTE; }
            set { GASTO_AGUA_CALIENTE = value; }
        }

        public int _GASTO_ASCENSOR
        {
            get { return GASTO_ASCENSOR; }
            set { GASTO_ASCENSOR = value; }
        }

        public int _GASTOS_ASEO
        {
            get { return GASTOS_ASEO; }
            set { GASTOS_ASEO = value; }
        }

        public int _GASTO_ARTICULOS_ASEO
        {
            get { return GASTO_ARTICULOS_ASEO; }
            set { GASTO_ARTICULOS_ASEO = value; }
        }

        public int _GASTO_CAMARAS
        {
            get { return GASTO_CAMARAS; }
            set { GASTO_CAMARAS = value; }
        }

        public int _GASTO_MANTENCION_AREAS
        {
            get { return GASTO_MANTENCION_AREAS; }
            set { GASTO_MANTENCION_AREAS = value; }
        }

        public int _GASTO_GUARDIA
        {
            get { return GASTO_GUARDIA; }
            set { GASTO_GUARDIA = value; }
        }

        public int _GASTO_CONSERJE
        {
            get { return GASTO_CONSERJE; }
            set { GASTO_CONSERJE = value; }
        }

        public string _NOMBRE_EDIFICIO
        {
            get { return NOMBRE_EDIFICIO; }
            set { NOMBRE_EDIFICIO = value; }
        }

        public long _ID_GASTOS
        {
            get { return ID_GASTOS; }
            set { ID_GASTOS = value; }
        }
    }
}