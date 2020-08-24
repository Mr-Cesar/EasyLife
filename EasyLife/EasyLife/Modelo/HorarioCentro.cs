using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class HorarioCentro
    {
        private long idHorarioCentro;
        private string diaHorario;
        private string horaInicio;
        private string horaTermino;
        private string fechaRegistroHC;
        private Centro centro;
        private Boolean estado;
        private string horarioCompleto;

        public string _horarioCompleto
        {
            get { return horarioCompleto; }
            set { horarioCompleto = value; }
        }

        public Boolean _estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public Centro _centro
        {
            get { return centro; }
            set { centro = value; }
        }

        public string _fechaRegistroHC
        {
            get { return fechaRegistroHC; }
            set { fechaRegistroHC = value; }
        }

        public string _horaTermino
        {
            get { return horaTermino; }
            set { horaTermino = value; }
        }

        public string _horaInicio
        {
            get { return horaInicio; }
            set { horaInicio = value; }
        }

        public string _diaHorario
        {
            get { return diaHorario; }
            set { diaHorario = value; }
        }

        public long _idHorarioCentro
        {
            get { return idHorarioCentro; }
            set { idHorarioCentro = value; }
        }
    }
}