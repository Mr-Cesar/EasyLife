using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterCondominio
    {
        private long ID_CONDOMINIO;
        private string FK_RUT;
        private string CALLE;
        private int NUMERO;
        private string NOMBRE_COMUNA;
        private string NOMBRE_CIUDAD;
        private string NOMBRE_REGION;
        private string NOMBRE_CONDOMINIO;
        private int PRECIO_EST;
        private int CANTIDAD_EDIFICIO;
        private int CANTIDAD_DEP;
        private int CANTIDAD_PISOS;
        private string PREFIJO;
        private long ID_DIRECCION;
        private string TIPO;

        public string _TIPO
        {
            get { return TIPO; }
            set { TIPO = value; }
        }

        public long _ID_DIRECCION
        {
            get { return ID_DIRECCION; }
            set { ID_DIRECCION = value; }
        }

        public string _PREFIJO
        {
            get { return PREFIJO; }
            set { PREFIJO = value; }
        }

        public int _CANTIDAD_PISOS
        {
            get { return CANTIDAD_PISOS; }
            set { CANTIDAD_PISOS = value; }
        }

        public int _CANTIDAD_DEP
        {
            get { return CANTIDAD_DEP; }
            set { CANTIDAD_DEP = value; }
        }

        public int _CANTIDAD_EDIFICIO
        {
            get { return CANTIDAD_EDIFICIO; }
            set { CANTIDAD_EDIFICIO = value; }
        }

        public int _PRECIO_EST
        {
            get { return PRECIO_EST; }
            set { PRECIO_EST = value; }
        }

        public string _NOMBRE_CONDOMINIO
        {
            get { return NOMBRE_CONDOMINIO; }
            set { NOMBRE_CONDOMINIO = value; }
        }

        public string _NOMBRE_REGION
        {
            get { return NOMBRE_REGION; }
            set { NOMBRE_REGION = value; }
        }

        public string _NOMBRE_CIUDAD
        {
            get { return NOMBRE_CIUDAD; }
            set { NOMBRE_CIUDAD = value; }
        }

        public string _NOMBRE_COMUNA
        {
            get { return NOMBRE_COMUNA; }
            set { NOMBRE_COMUNA = value; }
        }

        public int _NUMERO
        {
            get { return NUMERO; }
            set { NUMERO = value; }
        }

        public string _CALLE
        {
            get { return CALLE; }
            set { CALLE = value; }
        }

        public string _FK_RUT
        {
            get { return FK_RUT; }
            set { FK_RUT = value; }
        }

        public long _ID_CONDOMINIO
        {
            get { return ID_CONDOMINIO; }
            set { ID_CONDOMINIO = value; }
        }
    }
}