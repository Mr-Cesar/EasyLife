using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class ReservaCentro
    {
        private long idReservaCentro;
        private string fechaRegistroRC;
        private Departamento departamento;
        private Centro centro;
        private Boleta boleta;
        private long codHorario;

        public long _codHorario
        {
            get { return codHorario; }
            set { codHorario = value; }
        }

        public Boleta _boleta
        {
            get { return boleta; }
            set { boleta = value; }
        }

        public Centro _centro
        {
            get { return centro; }
            set { centro = value; }
        }

        public Departamento _departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        public string _fechaRegistroRC
        {
            get { return fechaRegistroRC; }
            set { fechaRegistroRC = value; }
        }

        public long _idReservaCentro
        {
            get { return idReservaCentro; }
            set { idReservaCentro = value; }
        }
    }
}