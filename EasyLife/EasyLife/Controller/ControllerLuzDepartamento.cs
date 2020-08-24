using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerLuzDepartamento
    {
        public static string crearLuzDepartamento(string codigo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertLuzDep(codigo);
                return "Luz Departamento Creada";
            }
        }

        public static string modficarLuzDepartamento(long luz, string codigo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateLuzDep(luz, codigo);
                return "Luz Departamento Modificada";
            }
        }

        public static string eliminarLuzDepartamento(long luz)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.deleteLuzDep(luz);
                return "Luz Departamento Eliminada";
            }
        }

        public static string asignarLuzDepartamento(long departamento, long luz)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.AsignarLuzDep(departamento, luz);
                return "Luz Departamento Asignada";
            }
        }

        public static LUZ_DEPARTAMENTO buscarLuzDepartamento(long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                LUZ_DEPARTAMENTO aux = (from u in dbc.LUZ_DEPARTAMENTO
                                        where u.ID_DEPARTAMENTO == departamento
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

        public static LUZ_DEPARTAMENTO buscarIdLuzDepartamento(long luz)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                LUZ_DEPARTAMENTO aux = (from u in dbc.LUZ_DEPARTAMENTO
                                        where u.ID_LUZ_D == luz
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

        public static List<LUZ_DEPARTAMENTO> listaLuzDepartamentoLibre()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.LUZ_DEPARTAMENTO
                            where u.ID_DEPARTAMENTO == null
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

        public static List<LUZ_DEPARTAMENTO> listaLuzDepartamento()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.LUZ_DEPARTAMENTO
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