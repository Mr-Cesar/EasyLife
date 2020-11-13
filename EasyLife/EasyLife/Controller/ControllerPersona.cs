using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerPersona
    {
        public static string crearPersona(long rol, string nombre, string apellido, string rut, string telefono, string correo, Boolean luz, string sexo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertPersona(rol, nombre, apellido, rut, telefono, correo, luz, sexo);
                return "Persona Creada";
            }
        }

        public static string modificarUsuario(long persona, string telefono, string correo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.UpdatePersona(persona, telefono, correo);
                return "Persona Modificada";
            }
        }

        public static string modificarPersona(long persona, string nombre, string apellido, string rut, string telefono, string correo, string sexo,
            Boolean luz)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updatePropietarioFull(persona, nombre, apellido, rut, telefono, correo, luz, sexo);
                return "Propietario Modificada";
            }
        }

        public static string modificarPersonal(long persona, long rol, string nombre, string apellido, string rut, string telefono, string correo, string sexo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.UpdatePersonal(rol, persona, nombre, apellido, rut, telefono, correo, sexo);
                return "Persona Modificada";
            }
        }

        public static string eliminarPersona(long persona)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.deletePersona(persona);
                return "Persona Eliminada";
            }
        }

        public static string modificarEstadoPersona(long persona, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.cambioEstadoPersona(persona, estado);
                return "Estado Persona Modificada";
            }
        }

        public static PERSONA buscarPersonaRut(string rut)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                PERSONA aux = (from u in dbc.PERSONA
                               where u.FK_RUT == rut
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

        public static List<PERSONA> admCondominio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            from c in dbc.CONDOMINIO
                            where c.ID_PERSONA == u.ID_PERSONA && c.ID_CONDOMINIO == condominio
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

        public static List<PERSONA> conserjeCondominio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            from c in dbc.CONSERJE
                            where c.ID_PERSONA == u.ID_PERSONA && c.ID_CONDOMINIO == condominio
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

        public static PERSONA buscarIdPersona(long persona)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                PERSONA aux = (from u in dbc.PERSONA
                               where u.ID_PERSONA == persona
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

        public static Adapter.AdapterPersonal buscarPersonalId(long idPersonal)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var aux = from u in dbc.PERSONA
                          from r in dbc.ROL
                          where u.ID_PERSONA == idPersonal && u.ID_ROL == r.ID_ROL
                          select new Adapter.AdapterPersonal()
                          {
                              _ID_PERSONA = u.ID_PERSONA,
                              _NOMBRE_PERSONA = u.NOMBRE_PERSONA,
                              _APELLIDO_PERSONA = u.APELLIDO_PERSONA,
                              _FK_RUT = u.FK_RUT,
                              _TELEFONO_PERSONA = u.TELEFONO_PERSONA,
                              _CORREO_PERSONA = u.CORREO_PERSONA,
                              _ESTADO_PERSONA = u.ESTADO_PERSONA,
                              _DESCRIPCION_ROL = r.DESCRIPCION_ROL
                          };
                if (aux != null)
                {
                    return aux.SingleOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<PERSONA> listaPersonalRol(long rol)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            where u.ID_ROL == rol
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

        public static List<Adapter.AdapterPersonal> listaPersonal()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            from r in dbc.ROL
                            where u.ID_ROL == r.ID_ROL && u.ID_ROL != 4
                            select new Adapter.AdapterPersonal()
                            {
                                _ID_PERSONA = u.ID_PERSONA,
                                _DESCRIPCION_ROL = r.DESCRIPCION_ROL,
                                _FK_RUT = u.FK_RUT,
                                _NOMBRE_PERSONA = u.NOMBRE_PERSONA,
                                _APELLIDO_PERSONA = u.APELLIDO_PERSONA,
                                _TELEFONO_PERSONA = u.TELEFONO_PERSONA,
                                _CORREO_PERSONA = u.CORREO_PERSONA,
                                _ESTADO_PERSONA = u.ESTADO_PERSONA
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

        public static List<Adapter.AdapterPersonal> listaPersonalCondominio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                List<Adapter.AdapterPersonal> lista = new List<Adapter.AdapterPersonal>();
                var adm = from u in dbc.PERSONA
                          from r in dbc.ROL
                          from c in dbc.CONDOMINIO
                          where c.ID_CONDOMINIO == condominio && u.ID_ROL == r.ID_ROL
                          && u.ID_PERSONA == c.ID_PERSONA
                          select new Adapter.AdapterPersonal()
                          {
                              _ID_PERSONA = u.ID_PERSONA,
                              _DESCRIPCION_ROL = r.DESCRIPCION_ROL,
                              _FK_RUT = u.FK_RUT,
                              _NOMBRE_PERSONA = u.NOMBRE_PERSONA,
                              _APELLIDO_PERSONA = u.APELLIDO_PERSONA
                          };
                lista.Add(adm.SingleOrDefault());

                var query = from u in dbc.PERSONA
                            from r in dbc.ROL
                            from c in dbc.CONDOMINIO
                            from con in dbc.CONSERJE
                            where c.ID_CONDOMINIO == condominio && u.ID_ROL == r.ID_ROL
                            && u.ID_PERSONA == con.ID_PERSONA && con.ID_CONDOMINIO == c.ID_CONDOMINIO
                            select new Adapter.AdapterPersonal()
                            {
                                _ID_PERSONA = u.ID_PERSONA,
                                _DESCRIPCION_ROL = r.DESCRIPCION_ROL,
                                _FK_RUT = u.FK_RUT,
                                _NOMBRE_PERSONA = u.NOMBRE_PERSONA,
                                _APELLIDO_PERSONA = u.APELLIDO_PERSONA
                            };
                foreach (var item in query.ToList())
                {
                    lista.Add(item);
                }

                if (lista.Count > 0)
                {
                    return lista;
                }
                else
                {
                    return null;
                }
            }
        }

        public static List<Adapter.AdapterPropietario> listaPropietarios()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            from r in dbc.ROL
                            from d in dbc.DEPARTAMENTO
                            from e in dbc.EDIFICIO
                            from c in dbc.CONDOMINIO
                            where u.ID_ROL == r.ID_ROL && u.ID_ROL == 4 &&
                            d.ID_PERSONA == u.ID_PERSONA && d.ID_EDIFICIO == e.ID_EDIFICIO &&
                            e.ID_CONDOMINIO == c.ID_CONDOMINIO
                            select new Adapter.AdapterPropietario()
                            {
                                _ID_PERSONA = u.ID_PERSONA,
                                _FK_RUT = u.FK_RUT,
                                _NOMBRE_PERSONA = u.NOMBRE_PERSONA,
                                _APELLIDO_PERSONA = u.APELLIDO_PERSONA,
                                _TELEFONO_PERSONA = u.TELEFONO_PERSONA,
                                _CORREO_PERSONA = u.CORREO_PERSONA,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _NOMBRE_CONDOMINIO = c.NOMBRE_CONDOMINIO,
                                _ESTADO_PERSONA = u.ESTADO_PERSONA,
                                _ID_CONDOMINIO = c.ID_CONDOMINIO,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO
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

        public static List<Adapter.AdapterPropietario> listaPropietariosCondominio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            from r in dbc.ROL
                            from d in dbc.DEPARTAMENTO
                            from e in dbc.EDIFICIO
                            from c in dbc.CONDOMINIO
                            where u.ID_ROL == r.ID_ROL && u.ID_ROL == 4 &&
                            d.ID_PERSONA == u.ID_PERSONA && d.ID_EDIFICIO == e.ID_EDIFICIO &&
                            e.ID_CONDOMINIO == c.ID_CONDOMINIO && c.ID_CONDOMINIO == condominio
                            select new Adapter.AdapterPropietario()
                            {
                                _ID_PERSONA = u.ID_PERSONA,
                                _FK_RUT = u.FK_RUT,
                                _NOMBRE_PERSONA = u.NOMBRE_PERSONA,
                                _APELLIDO_PERSONA = u.APELLIDO_PERSONA,
                                _TELEFONO_PERSONA = u.TELEFONO_PERSONA,
                                _CORREO_PERSONA = u.CORREO_PERSONA,
                                _SEXO = u.SEXO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _NOMBRE_CONDOMINIO = c.NOMBRE_CONDOMINIO,
                                _ESTADO_PERSONA = u.ESTADO_PERSONA,
                                _ID_CONDOMINIO = c.ID_CONDOMINIO,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO
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

        public static List<Adapter.AdapterPropietario> searchListaPropietario(string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            from r in dbc.ROL
                            from d in dbc.DEPARTAMENTO
                            from e in dbc.EDIFICIO
                            from c in dbc.CONDOMINIO
                            where u.ID_ROL == r.ID_ROL && u.ID_ROL == 4 &&
                            d.ID_PERSONA == u.ID_PERSONA && d.ID_EDIFICIO == e.ID_EDIFICIO &&
                            e.ID_CONDOMINIO == c.ID_CONDOMINIO &&
                            (u.NOMBRE_PERSONA.Contains(parametro) || u.APELLIDO_PERSONA.Contains(parametro) || u.FK_RUT.Contains(parametro) ||
                            d.NUMERO_DEP.Contains(parametro) || e.NOMBRE_EDIFICIO.Contains(parametro) || c.NOMBRE_CONDOMINIO.Contains(parametro))
                            select new Adapter.AdapterPropietario()
                            {
                                _ID_PERSONA = u.ID_PERSONA,
                                _FK_RUT = u.FK_RUT,
                                _NOMBRE_PERSONA = u.NOMBRE_PERSONA,
                                _APELLIDO_PERSONA = u.APELLIDO_PERSONA,
                                _TELEFONO_PERSONA = u.TELEFONO_PERSONA,
                                _CORREO_PERSONA = u.CORREO_PERSONA,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _NOMBRE_CONDOMINIO = c.NOMBRE_CONDOMINIO,
                                _ESTADO_PERSONA = u.ESTADO_PERSONA,
                                _ID_CONDOMINIO = c.ID_CONDOMINIO,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO
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

        public static List<PERSONA> searchPropietario(string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            where u.ID_ROL == 4 &&
                            (u.NOMBRE_PERSONA.Contains(parametro) || u.APELLIDO_PERSONA.Contains(parametro) || u.FK_RUT.Contains(parametro) ||
                            u.TELEFONO_PERSONA.Contains(parametro) || u.CORREO_PERSONA.Contains(parametro))
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

        public static List<Adapter.AdapterPersonal> searchPersonal(string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            from r in dbc.ROL
                            where u.ID_ROL == r.ID_ROL && u.ID_ROL != 4 &&
                            (u.NOMBRE_PERSONA.Contains(parametro) || u.APELLIDO_PERSONA.Contains(parametro) || u.FK_RUT.Contains(parametro) ||
                            r.DESCRIPCION_ROL.Contains(parametro) || u.TELEFONO_PERSONA.Contains(parametro) || u.CORREO_PERSONA.Contains(parametro))
                            select new Adapter.AdapterPersonal()
                            {
                                _ID_PERSONA = u.ID_PERSONA,
                                _DESCRIPCION_ROL = r.DESCRIPCION_ROL,
                                _FK_RUT = u.FK_RUT,
                                _NOMBRE_PERSONA = u.NOMBRE_PERSONA,
                                _APELLIDO_PERSONA = u.APELLIDO_PERSONA,
                                _TELEFONO_PERSONA = u.TELEFONO_PERSONA,
                                _CORREO_PERSONA = u.CORREO_PERSONA,
                                _ESTADO_PERSONA = u.ESTADO_PERSONA
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

        public static List<Adapter.AdapterPersonal> listaAdapterPersonalRol(long rol)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.PERSONA
                            from r in dbc.ROL
                            where u.ID_ROL == r.ID_ROL && u.ID_ROL == rol
                            select new Adapter.AdapterPersonal()
                            {
                                _ID_PERSONA = u.ID_PERSONA,
                                _DESCRIPCION_ROL = r.DESCRIPCION_ROL,
                                _FK_RUT = u.FK_RUT,
                                _NOMBRE_PERSONA = u.NOMBRE_PERSONA,
                                _APELLIDO_PERSONA = u.APELLIDO_PERSONA,
                                _TELEFONO_PERSONA = u.TELEFONO_PERSONA,
                                _CORREO_PERSONA = u.CORREO_PERSONA,
                                _ESTADO_PERSONA = u.ESTADO_PERSONA
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