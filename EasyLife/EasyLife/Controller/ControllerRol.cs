using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerRol
    {
        public static List<ROL> listaRol()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.ROL
                            select u;
                if (query != null)
                {
                    return query.ToList();
                }
                else
                {
                    return null;
                }
            }
        }

        public static ROL buscarRol(string rol)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                ROL aux = (from u in dbc.ROL
                           where u.DESCRIPCION_ROL == rol
                           select u).SingleOrDefault();
                if (aux != null)
                {
                    return aux;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}