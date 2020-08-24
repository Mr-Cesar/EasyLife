using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerMulta
    {
        public static string crearMulta(long departamento, int multa, string motivo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.asignarMultaDep(departamento, multa, motivo);
                return "Multa Creada";
            }
        }

        public static string modificarMulta(long idMulta, long departamento, int multa, string motivo, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateMulta(idMulta, departamento, multa, motivo, estado);
                return "Multa Modificada";
            }
        }

        public static string eliminarMulta(long multa)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.deleteMulta(multa);
                return "Multa Eliminada";
            }
        }

        public static string modificarEstadoMulta(long multa, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateEstadoMulta(multa, estado);
                return "Estado Multa Modificado";
            }
        }

        public static List<MULTA> listaMultaNoPagadaDepartamento(long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.MULTA
                            where u.ID_DEPARTAMENTO == departamento && u.ESTADO_MULTA == true
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

        public static List<MULTA> listaMultaDepartamento(long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.MULTA
                            where u.ID_DEPARTAMENTO == departamento
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

        public static List<Adapter.AdapterMulta> listaAdapterMulta(long persona)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.MULTA
                            from d in dbc.DEPARTAMENTO
                            where u.ID_DEPARTAMENTO == d.ID_DEPARTAMENTO && d.ID_PERSONA == persona
                            select new Adapter.AdapterMulta()
                            {
                                _ID_MULTA = u.ID_MULTA,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _MOTIVO = u.MOTIVO,
                                _ESTADO_MULTA = u.ESTADO_MULTA,
                                _COSTO_MULTA = u.COSTO_MULTA,
                                _NUMERO_DEP = d.NUMERO_DEP
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

        public static List<Adapter.AdapterMulta> listaAdapterMultaDepartamento(long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.MULTA
                            from d in dbc.DEPARTAMENTO
                            where u.ID_DEPARTAMENTO == d.ID_DEPARTAMENTO && d.ID_DEPARTAMENTO == departamento
                            select new Adapter.AdapterMulta()
                            {
                                _ID_MULTA = u.ID_MULTA,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _MOTIVO = u.MOTIVO,
                                _ESTADO_MULTA = u.ESTADO_MULTA,
                                _COSTO_MULTA = u.COSTO_MULTA,
                                _NUMERO_DEP = d.NUMERO_DEP
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

        public static List<Adapter.AdapterMulta> listadoAdapterMultaNoPagas(long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.MULTA
                            from d in dbc.DEPARTAMENTO
                            where u.ID_DEPARTAMENTO == d.ID_DEPARTAMENTO && d.ID_DEPARTAMENTO == departamento && u.ESTADO_MULTA == false
                            select new Adapter.AdapterMulta()
                            {
                                _ID_MULTA = u.ID_MULTA,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _MOTIVO = u.MOTIVO,
                                _ESTADO_MULTA = u.ESTADO_MULTA,
                                _COSTO_MULTA = u.COSTO_MULTA,
                                _NUMERO_DEP = d.NUMERO_DEP
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