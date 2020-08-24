using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class EstacionamientoVisita
    {
        private long idEstVisita;
        private string patente;
        private string horaEntrada;
        private string horaSalida;
        private Boolean estadoEst;
        private int totalEst;
        private string fechaRegistroEst;
        private Boleta boleta;
        private string numDep;
        private long edificio;

        public long _edificio
        {
            get { return edificio; }
            set { edificio = value; }
        }

        public string _numDep
        {
            get { return numDep; }
            set { numDep = value; }
        }

        public Boleta _boleta
        {
            get { return boleta; }
            set { boleta = value; }
        }

        public string _fechaRegistroEst
        {
            get { return fechaRegistroEst; }
            set { fechaRegistroEst = value; }
        }

        public int _totalEst
        {
            get { return totalEst; }
            set { totalEst = value; }
        }

        public Boolean _estadoEst
        {
            get { return estadoEst; }
            set { estadoEst = value; }
        }

        public string _horaSalida
        {
            get { return horaSalida; }
            set { horaSalida = value; }
        }

        public string _horaEntrada
        {
            get { return horaEntrada; }
            set { horaEntrada = value; }
        }

        public string _patente
        {
            get { return patente; }
            set { patente = value; }
        }

        public long _idEstVisita
        {
            get { return idEstVisita; }
            set { idEstVisita = value; }
        }
    }
}