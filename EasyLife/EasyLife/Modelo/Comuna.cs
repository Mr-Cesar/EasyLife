using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Comuna
    {
        private long idComuna;
        private String nomComuna;
        private Ciudad ciudad;

        public Ciudad _ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public String _nomComuna
        {
            get { return nomComuna; }
            set { nomComuna = value; }
        }

        public long _idComuna
        {
            get { return idComuna; }
            set { idComuna = value; }
        }
    }
}