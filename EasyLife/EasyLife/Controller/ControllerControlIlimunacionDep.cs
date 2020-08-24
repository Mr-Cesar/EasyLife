using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerControlIlimunacionDep
    {
        public static string crearControlDep(long luz, string horaI, string horaT, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertControlDep(luz, horaI, horaT, estado);
                return "Control Creado";
            }
        }

        public static string modificarControlDep(long control, long luz, string horaI, string horaT, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateControlDep(control, luz, horaI, horaT, estado);
                return "Control Modificado";
            }
        }

        public static CONTROL_ILUMINACION_DEPARTAMENTO buscarIdControl(long control)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                CONTROL_ILUMINACION_DEPARTAMENTO aux = (from u in dbc.CONTROL_ILUMINACION_DEPARTAMENTO
                                                        where u.ID_CILUMINACION_D == control
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

        public static List<Adapter.AdapterControlLuzDepartamento> listaControlDep(long persona)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.LUZ_DEPARTAMENTO
                            from c in dbc.CONTROL_ILUMINACION_DEPARTAMENTO
                            from d in dbc.DEPARTAMENTO
                            where d.ID_PERSONA == persona && d.ID_DEPARTAMENTO == u.ID_DEPARTAMENTO &&
                            d.ID_LUZ_D == u.ID_LUZ_D && u.ID_LUZ_D == c.ID_LUZ_D
                            select new Adapter.AdapterControlLuzDepartamento()
                            {
                                _ID_CILUMINACION_D = c.ID_CILUMINACION_D,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _CODIGO_LUZ_D = u.CODIGO_LUZ_D,
                                _HORA_INICIO_D = c.HORA_INICIO_D,
                                _HORA_TERMINO_D = c.HORA_TERMINO_D,
                                _ESTADO_LUZ_CD = c.ESTADO_LUZ_CD,
                                _ESTADO_CONTROL_D = c.ESTADO_CONTROL_D
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

        public static List<Adapter.AdapterControlLuzDepartamento> listaControlDepartamento(long persona, long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.LUZ_DEPARTAMENTO
                            from c in dbc.CONTROL_ILUMINACION_DEPARTAMENTO
                            from d in dbc.DEPARTAMENTO
                            where d.ID_PERSONA == persona && d.ID_DEPARTAMENTO == departamento &&
                            d.ID_DEPARTAMENTO == u.ID_DEPARTAMENTO &&
                            d.ID_LUZ_D == u.ID_LUZ_D && u.ID_LUZ_D == c.ID_LUZ_D
                            select new Adapter.AdapterControlLuzDepartamento()
                            {
                                _ID_CILUMINACION_D = c.ID_CILUMINACION_D,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _CODIGO_LUZ_D = u.CODIGO_LUZ_D,
                                _HORA_INICIO_D = c.HORA_INICIO_D,
                                _HORA_TERMINO_D = c.HORA_TERMINO_D,
                                _ESTADO_LUZ_CD = c.ESTADO_LUZ_CD,
                                _ESTADO_CONTROL_D = c.ESTADO_CONTROL_D
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

        public static List<Adapter.AdapterControlLuzDepartamento> listaSearchControlDep(long persona, string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.LUZ_DEPARTAMENTO
                            from c in dbc.CONTROL_ILUMINACION_DEPARTAMENTO
                            from d in dbc.DEPARTAMENTO
                            where d.ID_PERSONA == persona && d.ID_DEPARTAMENTO == u.ID_DEPARTAMENTO &&
                            d.ID_LUZ_D == u.ID_LUZ_D && u.ID_LUZ_D == c.ID_LUZ_D &&
                            (u.CODIGO_LUZ_D.Contains(parametro) || d.NUMERO_DEP.Contains(parametro) || c.HORA_INICIO_D.Contains(parametro) ||
                            c.HORA_TERMINO_D.Contains(parametro))
                            select new Adapter.AdapterControlLuzDepartamento()
                            {
                                _ID_CILUMINACION_D = c.ID_CILUMINACION_D,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _CODIGO_LUZ_D = u.CODIGO_LUZ_D,
                                _HORA_INICIO_D = c.HORA_INICIO_D,
                                _HORA_TERMINO_D = c.HORA_TERMINO_D,
                                _ESTADO_LUZ_CD = c.ESTADO_LUZ_CD,
                                _ESTADO_CONTROL_D = c.ESTADO_CONTROL_D
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