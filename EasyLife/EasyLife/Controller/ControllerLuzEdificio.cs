using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerLuzEdificio
    {
        public static string crearLuzEdificio(string codigo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertLuzEdificio(codigo);
                return "Luz Edificio Creada";
            }
        }

        public static string modficarLuzEdificio(long luz, string codigo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateLuzEdificio(luz, codigo);
                return "Luz Edificio Modificada";
            }
        }

        public static string eliminarLuzEdificio(long luz)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.deleteLuzEdificio(luz);
                return "Luz Edificio Eliminada";
            }
        }

        public static string asignarLuzEdificio(long edificio, long luz)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.AsignarLuzEdi(edificio, luz);
                return "Luz Edificio Asignada";
            }
        }

        public static List<LUZ_EDIFICIO> listaLuzEdificio()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.LUZ_EDIFICIO
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

        public static List<LUZ_EDIFICIO> buscarLuzEdificio(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.LUZ_EDIFICIO
                            where u.ID_EDIFICIO == edificio
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

        public static LUZ_EDIFICIO buscarIdLuzEdificio(long luz)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                LUZ_EDIFICIO query = (from u in dbc.LUZ_EDIFICIO
                                      where u.ID_LUZ_E == luz
                                      select u).SingleOrDefault();
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

        public static List<LUZ_EDIFICIO> listaLuzDisponibles()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.LUZ_EDIFICIO
                            where u.ID_EDIFICIO == null
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
    }
}