using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Ciudad
    {
        private long idCiudad;
        private String nomCiudad;
        private Region region;

        public Region _region
        {
            get { return region; }
            set { region = value; }
        }

        public String _nomCiudad
        {
            get { return nomCiudad; }
            set { nomCiudad = value; }
        }

        public long _idCiudad
        {
            get { return idCiudad; }
            set { idCiudad = value; }
        }
    }
}