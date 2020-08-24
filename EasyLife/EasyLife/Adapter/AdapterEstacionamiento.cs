using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterEstacionamiento
    {
        private long ID_ESTACIONAMIENTO;
        private string NOMBRE_PERSONA;
        private string NUMERO_DEP;
        private string NOMBRE_EDIFICIO;
        private string PATENTE;
        private string HORA_ENTRADA;
        private string HORA_SALIDA;
        private Boolean ESTADO_EST;
        private int COSTO_BOLETA;

        public int _COSTO_BOLETA
        {
            get { return COSTO_BOLETA; }
            set { COSTO_BOLETA = value; }
        }

        public Boolean _ESTADO_EST
        {
            get { return ESTADO_EST; }
            set { ESTADO_EST = value; }
        }

        public string _HORA_SALIDA
        {
            get { return HORA_SALIDA; }
            set { HORA_SALIDA = value; }
        }

        public string _HORA_ENTRADA
        {
            get { return HORA_ENTRADA; }
            set { HORA_ENTRADA = value; }
        }

        public string _PATENTE
        {
            get { return PATENTE; }
            set { PATENTE = value; }
        }

        public string _NOMBRE_EDIFICIO
        {
            get { return NOMBRE_EDIFICIO; }
            set { NOMBRE_EDIFICIO = value; }
        }

        public string _NUMERO_DEP
        {
            get { return NUMERO_DEP; }
            set { NUMERO_DEP = value; }
        }

        public string _NOMBRE_PERSONA
        {
            get { return NOMBRE_PERSONA; }
            set { NOMBRE_PERSONA = value; }
        }

        public long _ID_ESTACIONAMIENTO
        {
            get { return ID_ESTACIONAMIENTO; }
            set { ID_ESTACIONAMIENTO = value; }
        }
    }
}