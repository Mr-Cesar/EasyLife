using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerBodega
    {
        public static string crearBodega(long edificio, double dimension, string numero)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertBodega(edificio, dimension, numero);
                return "Bodega Creada";
            }
        }

        public static string modificarBodega(long bodega, long edificio, double dimension, string numero)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateBodega(bodega, edificio, dimension, numero);
                return "Bodega Modificada";
            }
        }

        public static string asignarBodega(long bodega, long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.asignarBodega(bodega, departamento);
                return "Elemento Asignado";
            }
        }

        public static BODEGA buscarBodega(long bodega)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = (from u in dbc.BODEGA
                             where u.ID_BODEGA == bodega
                             select u).FirstOrDefault();
                if (query != null)
                {
                    return query;
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<BODEGA> listaBodega(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = (from u in dbc.BODEGA
                             where u.ID_EDIFICIO == edificio
                             select u);
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
    }
}