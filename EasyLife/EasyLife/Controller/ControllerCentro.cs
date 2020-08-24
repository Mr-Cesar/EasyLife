using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerCentro
    {
        public static string crearCentro(long tipo, long edificio, string nombre, int costo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertCentro(tipo, edificio, nombre, costo);
                return "Centro Creado";
            }
        }

        public static string modificarCentro(long centro, long tipo, long edificio, string nombre, int costo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.UpdateCentro(centro, tipo, edificio, nombre, costo);
                return "Centro Modificado";
            }
        }

        public static string deleteCentro(long centro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.deleteCentro(centro);
                return "Centro Eliminado";
            }
        }

        public static CENTRO buscarIdCentro(long centro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                CENTRO aux = (from u in dbc.CENTRO
                              where u.ID_CENTRO == centro
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

        public static CENTRO buscarCentroEdificio(long edificio, string nombre)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                CENTRO aux = (from u in dbc.CENTRO
                              where u.ID_EDIFICIO == edificio && u.NOMBRE_CENTRO == nombre
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

        public static List<CENTRO> listaCentroEdificio(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CENTRO
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

        public static List<Adapter.AdapterCentro> listaCentrosEdificio(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CENTRO
                            from t in dbc.TIPO_CENTRO
                            where u.ID_EDIFICIO == edificio && u.ID_TIPO_CENTRO == t.ID_TIPO_CENTRO
                            select new Adapter.AdapterCentro()
                            {
                                _ID_CENTRO = u.ID_CENTRO,
                                _NOMBRE_CENTRO = u.NOMBRE_CENTRO,
                                _NOMBRE_TIPO_CENTRO = t.NOMBRE_TIPO_CENTRO,
                                _COSTO = u.COSTO
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

        public static List<Adapter.AdapterCentro> listaAdapterCentro()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CENTRO
                            from t in dbc.TIPO_CENTRO
                            from e in dbc.EDIFICIO
                            from c in dbc.CONDOMINIO
                            where u.ID_EDIFICIO == e.ID_EDIFICIO && e.ID_CONDOMINIO == c.ID_CONDOMINIO &&
                            u.ID_TIPO_CENTRO == t.ID_TIPO_CENTRO
                            select new Adapter.AdapterCentro()
                            {
                                _ID_CENTRO = u.ID_CENTRO,
                                _ID_TIPO_CENTRO = t.ID_TIPO_CENTRO,
                                _ID_CONDOMINIO = c.ID_CONDOMINIO,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _NOMBRE_CENTRO = u.NOMBRE_CENTRO,
                                _NOMBRE_TIPO_CENTRO = t.NOMBRE_TIPO_CENTRO,
                                _NOMBRE_CONDOMINIO = c.NOMBRE_CONDOMINIO,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _COSTO = u.COSTO
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

        public static List<Adapter.AdapterCentro> searchCentro(string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CENTRO
                            from t in dbc.TIPO_CENTRO
                            from h in dbc.HORARIO_CENTRO
                            from e in dbc.EDIFICIO
                            from c in dbc.CONDOMINIO
                            where u.ID_EDIFICIO == e.ID_EDIFICIO && e.ID_CONDOMINIO == c.ID_CONDOMINIO &&
                            u.ID_TIPO_CENTRO == t.ID_TIPO_CENTRO && u.ID_CENTRO == h.ID_CENTRO &&
                            (u.NOMBRE_CENTRO.Contains(parametro) || t.NOMBRE_TIPO_CENTRO.Contains(parametro) ||
                            e.NOMBRE_EDIFICIO.Contains(parametro) || c.NOMBRE_CONDOMINIO.Contains(parametro))
                            select new Adapter.AdapterCentro()
                            {
                                _ID_CENTRO = u.ID_CENTRO,
                                _ID_TIPO_CENTRO = t.ID_TIPO_CENTRO,
                                _ID_HORARIO_CENTRO = h.ID_HORARIO_CENTRO,
                                _ID_CONDOMINIO = c.ID_CONDOMINIO,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _NOMBRE_CENTRO = u.NOMBRE_CENTRO,
                                _NOMBRE_TIPO_CENTRO = t.NOMBRE_TIPO_CENTRO,
                                _DIA_HORARIO = h.DIA_HORARIO,
                                _HORARIO_COMPLETO = h.HORARIO_COMPLETO,
                                _NOMBRE_CONDOMINIO = c.NOMBRE_CONDOMINIO,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _COSTO = u.COSTO
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

        public static List<Adapter.AdapterCentro> searchCentroCondominio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CENTRO
                            from t in dbc.TIPO_CENTRO
                            from h in dbc.HORARIO_CENTRO
                            from e in dbc.EDIFICIO
                            from c in dbc.CONDOMINIO
                            where u.ID_EDIFICIO == e.ID_EDIFICIO && e.ID_CONDOMINIO == c.ID_CONDOMINIO &&
                            u.ID_TIPO_CENTRO == t.ID_TIPO_CENTRO && u.ID_CENTRO == h.ID_CENTRO &&
                            c.ID_CONDOMINIO == condominio
                            select new Adapter.AdapterCentro()
                            {
                                _ID_CENTRO = u.ID_CENTRO,
                                _ID_TIPO_CENTRO = t.ID_TIPO_CENTRO,
                                _ID_HORARIO_CENTRO = h.ID_HORARIO_CENTRO,
                                _ID_CONDOMINIO = c.ID_CONDOMINIO,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _NOMBRE_CENTRO = u.NOMBRE_CENTRO,
                                _NOMBRE_TIPO_CENTRO = t.NOMBRE_TIPO_CENTRO,
                                _DIA_HORARIO = h.DIA_HORARIO,
                                _HORARIO_COMPLETO = h.HORARIO_COMPLETO,
                                _NOMBRE_CONDOMINIO = c.NOMBRE_CONDOMINIO,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _COSTO = u.COSTO
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