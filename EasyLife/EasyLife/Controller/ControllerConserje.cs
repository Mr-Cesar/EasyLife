using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerConserje
    {
        public static string crearConserje(long persona, long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertConserje(persona, condominio);
                return "Conserje Creado";
            }
        }

        public static string modificarConserje(long conserje, long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateConserje(conserje, condominio);
                return "Conserje Modificado";
            }
        }

        public static string deleteConserje(long conserje)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.deleteConserje(conserje);
                return "Conserje Eliminado";
            }
        }

        public static CONSERJE buscarIdConserje(long conserje)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                CONSERJE aux = (from u in dbc.CONSERJE
                                where u.ID_PERSONA == conserje
                                select u).FirstOrDefault();
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

        public static string asignarConserjeCondominio(long conserje, long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.asignarConserjeCondominio(conserje, condominio);
                return "Personal Asignado";
            }
        }

        public static string quitarConserjeCondominio(long conserje)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.denegarConserjeCondominio(conserje);
                return "Personal Denegado";
            }
        }

        public static List<PERSONA> listaConserjeCondominio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            from c in dbc.CONSERJE
                            where u.ID_PERSONA == c.ID_PERSONA && c.ID_CONDOMINIO == condominio
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

        public static List<Adapter.AdapterConserje> listaAdapterConserjeCondominio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            from c in dbc.CONSERJE
                            from con in dbc.CONDOMINIO
                            where u.ID_PERSONA == c.ID_PERSONA && c.ID_CONDOMINIO == con.ID_CONDOMINIO && c.ID_CONDOMINIO == condominio
                            select new Adapter.AdapterConserje()
                            {
                                _ID_CONSERJE = c.ID_CONSERJE,
                                _ID_PERSONA = u.ID_PERSONA,
                                _NOMBRE_PERSONA = u.NOMBRE_PERSONA,
                                _APELLIDO_PERSONA = u.APELLIDO_PERSONA,
                                _FK_RUT = u.FK_RUT,
                                _TELEFONO_PERSONA = u.TELEFONO_PERSONA,
                                _CORREO_PERSONA = u.CORREO_PERSONA,
                                _SEXO = u.SEXO,
                                _ESTADO_PERSONA = u.ESTADO_PERSONA,
                                _ID_CONDOMINIO = con.ID_CONDOMINIO,
                                _NOMBRE_CONDOMINIO = con.NOMBRE_CONDOMINIO
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

        public static List<Adapter.AdapterConserje> searchAdapterConserjeCondominio(long condominio, string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            from c in dbc.CONSERJE
                            from con in dbc.CONDOMINIO
                            where u.ID_PERSONA == c.ID_PERSONA && c.ID_CONDOMINIO == con.ID_CONDOMINIO && c.ID_CONDOMINIO == condominio ||
                            (u.NOMBRE_PERSONA.Contains(parametro) || u.APELLIDO_PERSONA.Contains(parametro) || u.FK_RUT.Contains(parametro) ||
                            u.TELEFONO_PERSONA.Contains(parametro) || u.CORREO_PERSONA.Contains(parametro))
                            select new Adapter.AdapterConserje()
                            {
                                _ID_CONSERJE = c.ID_CONSERJE,
                                _ID_PERSONA = u.ID_PERSONA,
                                _NOMBRE_PERSONA = u.NOMBRE_PERSONA,
                                _APELLIDO_PERSONA = u.APELLIDO_PERSONA,
                                _FK_RUT = u.FK_RUT,
                                _TELEFONO_PERSONA = u.TELEFONO_PERSONA,
                                _CORREO_PERSONA = u.CORREO_PERSONA,
                                _SEXO = u.SEXO,
                                _ESTADO_PERSONA = u.ESTADO_PERSONA,
                                _ID_CONDOMINIO = con.ID_CONDOMINIO,
                                _NOMBRE_CONDOMINIO = con.NOMBRE_CONDOMINIO
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