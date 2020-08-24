using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Region
    {
        private long idRegion;
        private String nomRegion;

        public String _nomRegion
        {
            get { return nomRegion; }
            set { nomRegion = value; }
        }

        public long _idRegion
        {
            get { return idRegion; }
            set { idRegion = value; }
        }
    }
}