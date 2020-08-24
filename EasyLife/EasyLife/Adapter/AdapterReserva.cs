using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Adapter
{
    public class AdapterReserva
    {
        private long ID_RESERVA_CENTRO;
        private string NUMERO_DEP;
        private string NOMBRE_CENTRO;
        private string DIA_HORARIO;
        private string HORA_INICIO_D;
        private string HORA_TERMINO_D;
        private long ID_DEPARTAMENTO;
        private long ID_HORARIO_CENTRO;
        private long ID_CENTRO;
        private long ID_BOLETA;
        private long COSTO_BOLETA;
        private string NOMBRE_TIPO_CENTRO;
        private long ID_TIPO_CENTRO;

        public long _ID_TIPO_CENTRO
        {
            get { return ID_TIPO_CENTRO; }
            set { ID_TIPO_CENTRO = value; }
        }

        public string _NOMBRE_TIPO_CENTRO
        {
            get { return NOMBRE_TIPO_CENTRO; }
            set { NOMBRE_TIPO_CENTRO = value; }
        }

        public long _COSTO_BOLETA
        {
            get { return COSTO_BOLETA; }
            set { COSTO_BOLETA = value; }
        }

        public long _ID_BOLETA
        {
            get { return ID_BOLETA; }
            set { ID_BOLETA = value; }
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

        public long _ID_DEPARTAMENTO
        {
            get { return ID_DEPARTAMENTO; }
            set { ID_DEPARTAMENTO = value; }
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

        public string _NOMBRE_CENTRO
        {
            get { return NOMBRE_CENTRO; }
            set { NOMBRE_CENTRO = value; }
        }

        public string _NUMERO_DEP
        {
            get { return NUMERO_DEP; }
            set { NUMERO_DEP = value; }
        }

        public long _ID_RESERVA_CENTRO
        {
            get { return ID_RESERVA_CENTRO; }
            set { ID_RESERVA_CENTRO = value; }
        }
    }
}