using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerEstacionamiento
    {
        public static string crearEstacionamiento(long edificio, string numero, int precio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertEstacionamiento(edificio, numero, precio);
                return "Estacionamiento Creada";
            }
        }

        public static string modificarEstacionamiento(long estacionamiento, long edificio, string numero, int precio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateEstacionamiento(estacionamiento, edificio, numero, precio);
                return "Estacionamiento Modificada";
            }
        }

        public static string asignarEstacionamiento(long estacionamiento, long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.asignarEstacionamiento(estacionamiento, departamento);
                return "Estacionamiento Asignada";
            }
        }

        public static ESTACIONAMIENTO buscarEstacionamiento(long estacionamiento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = (from u in dbc.ESTACIONAMIENTO
                             where u.ID_EST == estacionamiento
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

        public static List<ESTACIONAMIENTO> listaEstacionamiento(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = (from u in dbc.ESTACIONAMIENTO
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