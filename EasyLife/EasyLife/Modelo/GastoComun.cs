using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class GastoComun
    {
        private long idGasto;
        private Edificio edificio;
        private int gastoConserje;
        private int gastoGuardia;
        private int gastoManAreas;
        private int gastoCamaras;
        private int gastoArtAseo;
        private int gastoAseo;
        private int gastoAscensor;
        private int gastoAguaCaliente;
        private int gastoOtro;
        private int totalGasto;
        private string fechaRegistroGasto;

        public string _fechaRegistroGasto
        {
            get { return fechaRegistroGasto; }
            set { fechaRegistroGasto = value; }
        }

        public int _totalGasto
        {
            get { return totalGasto; }
            set { totalGasto = value; }
        }

        public int _gastoOtro
        {
            get { return gastoOtro; }
            set { gastoOtro = value; }
        }

        public int _gastoAguaCaliente
        {
            get { return gastoAguaCaliente; }
            set { gastoAguaCaliente = value; }
        }

        public int _gastoAscensor
        {
            get { return gastoAscensor; }
            set { gastoAscensor = value; }
        }

        public int _gastoAseo
        {
            get { return gastoAseo; }
            set { gastoAseo = value; }
        }

        public int _gastoArtAseo
        {
            get { return gastoArtAseo; }
            set { gastoArtAseo = value; }
        }

        public int _gastoCamaras
        {
            get { return gastoCamaras; }
            set { gastoCamaras = value; }
        }

        public int _gastoManAreas
        {
            get { return gastoManAreas; }
            set { gastoManAreas = value; }
        }

        public int _gastoGuardia
        {
            get { return gastoGuardia; }
            set { gastoGuardia = value; }
        }

        public int _gastoConserje
        {
            get { return gastoConserje; }
            set { gastoConserje = value; }
        }

        public Edificio _edificio
        {
            get { return edificio; }
            set { edificio = value; }
        }

        public long _idGasto
        {
            get { return idGasto; }
            set { idGasto = value; }
        }
    }
}