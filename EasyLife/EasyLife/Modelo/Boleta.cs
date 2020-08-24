using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Boleta
    {
        private long idBoleta;
        private string fechaRegistroBoleta;
        private EstacionamientoVisita estVisita;
        private Persona persona;
        private long costoBoleta;
        private long DEP;

        public long _DEP
        {
            get { return DEP; }
            set { DEP = value; }
        }

        public long _costoBoleta
        {
            get { return costoBoleta; }
            set { costoBoleta = value; }
        }

        public Persona _persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public EstacionamientoVisita _estVisita
        {
            get { return estVisita; }
            set { estVisita = value; }
        }

        public string _fechaRegistroBoleta
        {
            get { return fechaRegistroBoleta; }
            set { fechaRegistroBoleta = value; }
        }

        public long _idBoleta
        {
            get { return idBoleta; }
            set { idBoleta = value; }
        }
    }
}