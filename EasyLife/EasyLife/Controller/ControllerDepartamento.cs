using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerDepartamento
    {
        public static string crearDepartamento(long edificio, string numero, double dimension)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertDepartamento(edificio, numero, dimension);
                return "Departamento Creado";
            }
        }

        public static string modificarDepartamento(long departamento, string numero)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateDepartamento(departamento, numero);
                return "Departamento Modificado";
            }
        }

        public static string asignarDepartamentoPropietario(long propietario, long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.UpdateDepartamentoPersona(departamento, propietario);
                return "Departamento Asignado";
            }
        }

        public static DEPARTAMENTO buscarIdDepartamento(long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                DEPARTAMENTO aux = (from u in dbc.DEPARTAMENTO
                                    where u.ID_DEPARTAMENTO == departamento
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

        public static List<DEPARTAMENTO> listaDepartamentoPersona(long persona)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.DEPARTAMENTO
                            where u.ID_PERSONA == persona
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

        public static List<Adapter.AdapterDepartamento> listaAdapterDepartamentoPersona(long persona)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.DEPARTAMENTO
                            from e in dbc.EDIFICIO
                            from c in dbc.CONDOMINIO
                            where u.ID_PERSONA == persona && u.ID_EDIFICIO == e.ID_EDIFICIO &&
                            e.ID_CONDOMINIO == c.ID_CONDOMINIO
                            select new Adapter.AdapterDepartamento()
                            {
                                _ID_CONDOMINIO = c.ID_CONDOMINIO,
                                _NOMBRE_CONDOMINIO = c.NOMBRE_CONDOMINIO,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _ID_DEPARTAMENTO = u.ID_DEPARTAMENTO,
                                _NUMERO_DEP = u.NUMERO_DEP
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

        public static List<DEPARTAMENTO> listaDepartamento(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.DEPARTAMENTO
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

        public static List<DEPARTAMENTO> listaDepartamentoLibre(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.DEPARTAMENTO
                            where u.ID_EDIFICIO == edificio && u.ID_PERSONA == null
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

        public static List<DEPARTAMENTO> listaDepartamentoOcupado(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.DEPARTAMENTO
                            where u.ID_EDIFICIO == edificio && u.ID_PERSONA != null
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

        public static List<DEPARTAMENTO> listaDepartamentoLuz(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.DEPARTAMENTO
                            from p in dbc.PERSONA
                            where p.LUZ == true && p.ID_PERSONA == u.ID_PERSONA && u.ID_EDIFICIO == edificio
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