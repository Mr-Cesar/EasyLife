using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerEdificio
    {
        public static string crearEdificio(long condominio, string nombre, int piso, int departamento, double dimension)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertEdificio(condominio, nombre, piso, departamento, dimension);
                return "Edificio Creado";
            }
        }

        public static string modificarEdificio(long edificio, string nombre, int piso, int departamento, double dimension)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateEdificio(edificio, nombre, piso, departamento, dimension);
                return "Edificio Modificado";
            }
        }

        public static string asignarGastoEdificio(long edificio, long gasto)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.AsignarGasto(edificio, gasto);
                return "Gasto Asignado";
            }
        }

        public static long cantidadDep(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = (from u in dbc.EDIFICIO
                             select u).ToList();
                long total = 0;
                foreach (var item in query)
                {
                    total = item.CANTIDAD_DEPARTAMENTO + total;
                }

                if (query != null)
                {
                    return total;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static List<EDIFICIO> buscarEdificioCondominio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.EDIFICIO
                            where u.ID_CONDOMINIO == condominio
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

        public static EDIFICIO buscarIdEdificio(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                EDIFICIO query = (from u in dbc.EDIFICIO
                                  where u.ID_EDIFICIO == edificio
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

        public static List<Adapter.AdapterEdificio> listaAdapterEdificio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.EDIFICIO
                            from g in dbc.GASTOS_COMUNES
                            where u.ID_CONDOMINIO == condominio &&
                            u.ID_EDIFICIO == g.ID_EDIFICIO
                            select new Adapter.AdapterEdificio()
                            {
                                _ID_EDIFICIO = u.ID_EDIFICIO,
                                _NOMBRE_EDIFICIO = u.NOMBRE_EDIFICIO,
                                _CANTIDAD_PISO = u.CANTIDAD_PISO,
                                _CANTIDAD_DEPARTAMENTO = u.CANTIDAD_DEPARTAMENTO,
                                _TOTAL_GASTO = g.TOTAL_GASTO
                            };
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