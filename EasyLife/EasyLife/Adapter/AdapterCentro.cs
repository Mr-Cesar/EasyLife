using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterCentro
    {
        private string NOMBRE_CENTRO;
        private string NOMBRE_TIPO_CENTRO;
        private string DIA_HORARIO;
        private string HORA_INICIO_D;
        private string HORA_TERMINO_D;
        private long ID_HORARIO_CENTRO;
        private long ID_CENTRO;
        private long ID_EDIFICIO;
        private string NOMBRE_EDIFICIO;
        private long ID_CONDOMINIO;
        private string NOMBRE_CONDOMINIO;
        private long ID_TIPO_CENTRO;
        private string HORARIO_COMPLETO;
        private int COSTO;

        public int _COSTO
        {
            get { return COSTO; }
            set { COSTO = value; }
        }

        public string _HORARIO_COMPLETO
        {
            get { return HORARIO_COMPLETO; }
            set { HORARIO_COMPLETO = value; }
        }

        public long _ID_TIPO_CENTRO
        {
            get { return ID_TIPO_CENTRO; }
            set { ID_TIPO_CENTRO = value; }
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

        public long _ID_CENTRO
        {
            get { return ID_CENTRO; }
            set { ID_CENTRO = value; }
        }

        public long _ID_HORARIO_CENTRO
        {
            get { return ID_HORARIO_CENTRO; }
            set { ID_HORARIO_CENTRO = value; }
        }

        public string _HORA_TERMINO_D
        {
            get { return HORA_TERMINO_D; }
            set { HORA_TERMINO_D = value; }
        }

        public string _HORA_INICIO_D
        {
            get { return HORA_INICIO_D; }
            set { HORA_INICIO_D = value; }
        }

        public string _DIA_HORARIO
        {
            get { return DIA_HORARIO; }
            set { DIA_HORARIO = value; }
        }

        public string _NOMBRE_TIPO_CENTRO
        {
            get { return NOMBRE_TIPO_CENTRO; }
            set { NOMBRE_TIPO_CENTRO = value; }
        }

        public string _NOMBRE_CENTRO
        {
            get { return NOMBRE_CENTRO; }
            set { NOMBRE_CENTRO = value; }
        }
    }
}