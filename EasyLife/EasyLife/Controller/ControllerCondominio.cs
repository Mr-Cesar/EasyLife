using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerCondominio
    {
        public static string crearCondominio(long direccion, long persona, string nombre, int precio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertCondominio(direccion, persona, nombre, precio);
                return "Condominio Creado";
            }
        }

        public static string modificarCondominio(long condominio, long direccion, long persona, string nombre, int precio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateCondominio(condominio, direccion, persona, nombre, precio);
                return "Condominio Modificado";
            }
        }

        public static string asignarAdministradorCondominio(long persona, long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.asignarAdministradorCondominio(persona, condominio);
                return "Personal Asignado";
            }
        }

        public static string quitarAdministradorCondominio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.denegarAdministradorCondominio(condominio);
                return "Personal Denegado";
            }
        }

        public static List<CONDOMINIO> listaCondominio()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CONDOMINIO
                            select u;
                return query.ToList();
            }
        }

        public static List<CONDOMINIO> listaCondominioAdministrador(long administrador)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CONDOMINIO
                            where u.ID_PERSONA == administrador
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

        public static CONDOMINIO buscarIdCondominio(long idCondominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                CONDOMINIO query = (from u in dbc.CONDOMINIO
                                    where u.ID_CONDOMINIO == idCondominio
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

        public static CONDOMINIO buscarCondominio(long direccion)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                CONDOMINIO query = (from u in dbc.CONDOMINIO
                                    where u.ID_DIRECCION == direccion
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

        public static List<CONDOMINIO> listaCondominiosLibres()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CONDOMINIO
                            where u.ID_PERSONA == 1
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

        public static List<Adapter.AdapterCondominio> listaAdapterCondominio()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CONDOMINIO
                            from p in dbc.PERSONA
                            from d in dbc.DIRECCION
                            from co in dbc.COMUNA
                            from ci in dbc.CIUDAD
                            from r in dbc.REGION
                            where u.ID_PERSONA == p.ID_PERSONA && u.ID_DIRECCION == d.ID_DIRECCION &&
                            d.ID_COMUNA == co.ID_COMUNA && co.ID_CIUDAD == ci.ID_CIUDAD &&
                            ci.ID_REGION == r.ID_REGION
                            select new Adapter.AdapterCondominio
                            {
                                _ID_CONDOMINIO = u.ID_CONDOMINIO,
                                _NOMBRE_CONDOMINIO = u.NOMBRE_CONDOMINIO,
                                _PRECIO_EST = u.PRECIO_EST,
                                _FK_RUT = p.FK_RUT,
                                _CALLE = d.CALLE,
                                _NUMERO = d.NUMERO,
                                _NOMBRE_COMUNA = co.NOMBRE_COMUNA,
                                _NOMBRE_CIUDAD = ci.NOMBRE_CIUDAD,
                                _NOMBRE_REGION = r.NOMBRE_REGION
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

        public static List<Adapter.AdapterCondominio> listaAdapterCondominioAdm(long administrador)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CONDOMINIO
                            from p in dbc.PERSONA
                            from d in dbc.DIRECCION
                            from co in dbc.COMUNA
                            from ci in dbc.CIUDAD
                            from r in dbc.REGION
                            where u.ID_PERSONA == p.ID_PERSONA && u.ID_PERSONA == administrador && u.ID_DIRECCION == d.ID_DIRECCION &&
                             d.ID_COMUNA == co.ID_COMUNA && co.ID_CIUDAD == ci.ID_CIUDAD &&
                             ci.ID_REGION == r.ID_REGION
                            select new Adapter.AdapterCondominio
                            {
                                _ID_CONDOMINIO = u.ID_CONDOMINIO,
                                _NOMBRE_CONDOMINIO = u.NOMBRE_CONDOMINIO,
                                _PRECIO_EST = u.PRECIO_EST,
                                _FK_RUT = p.FK_RUT,
                                _CALLE = d.CALLE,
                                _NUMERO = d.NUMERO,
                                _NOMBRE_COMUNA = co.NOMBRE_COMUNA,
                                _NOMBRE_CIUDAD = ci.NOMBRE_CIUDAD,
                                _NOMBRE_REGION = r.NOMBRE_REGION
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

        public static List<Adapter.AdapterCondominio> searchAdaprterCondominio(string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                int i = 0;
                int numero;
                Boolean convert = int.TryParse(parametro, out i);
                if (convert == true)
                {
                    numero = Convert.ToInt32(parametro);
                }
                else
                {
                    numero = 0;
                }

                var query = from u in dbc.CONDOMINIO
                            from p in dbc.PERSONA
                            from d in dbc.DIRECCION
                            from co in dbc.COMUNA
                            from ci in dbc.CIUDAD
                            from r in dbc.REGION
                            where (u.ID_PERSONA == p.ID_PERSONA && u.ID_DIRECCION == d.ID_DIRECCION &&
                            d.ID_COMUNA == co.ID_COMUNA && co.ID_CIUDAD == ci.ID_CIUDAD &&
                            ci.ID_REGION == r.ID_REGION) &&
                            (u.NOMBRE_CONDOMINIO.Contains(parametro) || p.NOMBRE_PERSONA.Contains(parametro) || p.FK_RUT.Contains(parametro) ||
                            p.APELLIDO_PERSONA.Contains(parametro) || d.CALLE.Contains(parametro) || d.NUMERO == numero || co.NOMBRE_COMUNA.Contains(parametro) ||
                            ci.NOMBRE_CIUDAD.Contains(parametro) || r.NOMBRE_REGION.Contains(parametro))
                            select new Adapter.AdapterCondominio
                            {
                                _ID_CONDOMINIO = u.ID_CONDOMINIO,
                                _NOMBRE_CONDOMINIO = u.NOMBRE_CONDOMINIO,
                                _PRECIO_EST = u.PRECIO_EST,
                                _FK_RUT = p.FK_RUT,
                                _CALLE = d.CALLE,
                                _NUMERO = d.NUMERO,
                                _NOMBRE_COMUNA = co.NOMBRE_COMUNA,
                                _NOMBRE_CIUDAD = ci.NOMBRE_CIUDAD,
                                _NOMBRE_REGION = r.NOMBRE_REGION
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

        public static List<Adapter.AdapterCondominio> searchAdaprterCondominioAdministrador(string parametro, long administrador)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                int i = 0;
                int numero;
                Boolean convert = int.TryParse(parametro, out i);
                if (convert == true)
                {
                    numero = Convert.ToInt32(parametro);
                }
                else
                {
                    numero = 0;
                }

                var query = from u in dbc.CONDOMINIO
                            from p in dbc.PERSONA
                            from d in dbc.DIRECCION
                            from co in dbc.COMUNA
                            from ci in dbc.CIUDAD
                            from r in dbc.REGION
                            where (u.ID_PERSONA == p.ID_PERSONA && u.ID_PERSONA == administrador && u.ID_DIRECCION == d.ID_DIRECCION &&
                            d.ID_COMUNA == co.ID_COMUNA && co.ID_CIUDAD == ci.ID_CIUDAD &&
                            ci.ID_REGION == r.ID_REGION) &&
                            (u.NOMBRE_CONDOMINIO.Contains(parametro) || p.NOMBRE_PERSONA.Contains(parametro) || p.FK_RUT.Contains(parametro) ||
                            p.APELLIDO_PERSONA.Contains(parametro) || d.CALLE.Contains(parametro) || d.NUMERO == numero || co.NOMBRE_COMUNA.Contains(parametro) ||
                            ci.NOMBRE_CIUDAD.Contains(parametro) || r.NOMBRE_REGION.Contains(parametro))
                            select new Adapter.AdapterCondominio
                            {
                                _ID_CONDOMINIO = u.ID_CONDOMINIO,
                                _NOMBRE_CONDOMINIO = u.NOMBRE_CONDOMINIO,
                                _PRECIO_EST = u.PRECIO_EST,
                                _FK_RUT = p.FK_RUT,
                                _CALLE = d.CALLE,
                                _NUMERO = d.NUMERO,
                                _NOMBRE_COMUNA = co.NOMBRE_COMUNA,
                                _NOMBRE_CIUDAD = ci.NOMBRE_CIUDAD,
                                _NOMBRE_REGION = r.NOMBRE_REGION
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