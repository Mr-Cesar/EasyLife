using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Modelo
{
    public class Rol
    {
        private long idRol;
        private string descripcionRol;

        public string _descripcionRol
        {
            get { return descripcionRol; }
            set { descripcionRol = value; }
        }

        public long _idRol
        {
            get { return idRol; }
            set { idRol = value; }
        }
    }
}