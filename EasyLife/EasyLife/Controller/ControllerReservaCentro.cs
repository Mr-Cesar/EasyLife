using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerReservaCentro
    {
        public static string crearReserva(long departamento, long centro, long horario, long boleta)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertReservaConserje(departamento, centro, horario, boleta);
                return "Reserva Creada";
            }
        }

        public static string modificarReserva(long reserva, long departamento, long centro, long horario)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateReserva(reserva, departamento, centro, horario);
                return "Reserva Modificada";
            }
        }

        public static string asignarBoletaReserva(long reserva, long boleta)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.AsignarBoletaReserva(reserva, boleta);
                return "Boleta Asignada";
            }
        }

        public static List<Adapter.AdapterReserva> listaReservaDepartamento(long propietario)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.RESERVA_CENTRO
                            from c in dbc.CENTRO
                            from b in dbc.BOLETA
                            from h in dbc.HORARIO_CENTRO
                            from d in dbc.DEPARTAMENTO
                            from t in dbc.TIPO_CENTRO
                            where d.ID_PERSONA == propietario && u.ID_DEPARTAMENTO == d.ID_DEPARTAMENTO &&
                            u.ID_CENTRO == c.ID_CENTRO && u.COD_HORARIO == h.ID_HORARIO_CENTRO &&
                            b.DEP == u.ID_DEPARTAMENTO && c.ID_TIPO_CENTRO == t.ID_TIPO_CENTRO &&
                            b.ID_BOLETA == u.ID_BOLETA && b.DEP == u.ID_DEPARTAMENTO
                            select new Adapter.AdapterReserva()
                            {
                                _ID_RESERVA_CENTRO = u.ID_RESERVA_CENTRO,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _ID_HORARIO_CENTRO = h.ID_HORARIO_CENTRO,
                                _ID_CENTRO = c.ID_CENTRO,
                                _ID_BOLETA = b.ID_BOLETA,
                                _ID_TIPO_CENTRO = t.ID_TIPO_CENTRO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _NOMBRE_CENTRO = c.NOMBRE_CENTRO,
                                _DIA_HORARIO = h.DIA_HORARIO,
                                _HORA_INICIO_D = h.HORA_INICIO_D,
                                _HORA_TERMINO_D = h.HORA_TERMINO_D,
                                _COSTO_BOLETA = b.COSTO_BOLETA,
                                _NOMBRE_TIPO_CENTRO = t.NOMBRE_TIPO_CENTRO,
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

        public static List<Adapter.AdapterReserva> searchReservaDepartamento(long propietario, string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.RESERVA_CENTRO
                            from c in dbc.CENTRO
                            from b in dbc.BOLETA
                            from h in dbc.HORARIO_CENTRO
                            from d in dbc.DEPARTAMENTO
                            from t in dbc.TIPO_CENTRO
                            where d.ID_PERSONA == propietario && u.ID_DEPARTAMENTO == d.ID_DEPARTAMENTO &&
                            u.ID_CENTRO == c.ID_CENTRO && u.COD_HORARIO == h.ID_HORARIO_CENTRO &&
                            b.DEP == u.ID_DEPARTAMENTO && c.ID_TIPO_CENTRO == t.ID_TIPO_CENTRO &&
                            b.ID_BOLETA == u.ID_BOLETA && b.DEP == u.ID_DEPARTAMENTO &&
                            (c.NOMBRE_CENTRO.Contains(parametro) || h.DIA_HORARIO.Contains(parametro) || h.HORA_INICIO_D.Contains(parametro) ||
                            h.HORA_TERMINO_D.Contains(parametro) || h.HORARIO_COMPLETO.Contains(parametro) || d.NUMERO_DEP.Contains(parametro) ||
                            t.NOMBRE_TIPO_CENTRO.Contains(parametro) || c.NOMBRE_CENTRO.Contains(parametro))
                            select new Adapter.AdapterReserva()
                            {
                                _ID_RESERVA_CENTRO = u.ID_RESERVA_CENTRO,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _ID_HORARIO_CENTRO = h.ID_HORARIO_CENTRO,
                                _ID_CENTRO = c.ID_CENTRO,
                                _ID_BOLETA = b.ID_BOLETA,
                                _ID_TIPO_CENTRO = t.ID_TIPO_CENTRO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _NOMBRE_CENTRO = c.NOMBRE_CENTRO,
                                _DIA_HORARIO = h.DIA_HORARIO,
                                _HORA_INICIO_D = h.HORA_INICIO_D,
                                _HORA_TERMINO_D = h.HORA_TERMINO_D,
                                _COSTO_BOLETA = b.COSTO_BOLETA,
                                _NOMBRE_TIPO_CENTRO = t.NOMBRE_TIPO_CENTRO,
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

        public static List<Adapter.AdapterReserva> listaReservaTipoCentro(long propietario, long tipo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.RESERVA_CENTRO
                            from c in dbc.CENTRO
                            from b in dbc.BOLETA
                            from h in dbc.HORARIO_CENTRO
                            from d in dbc.DEPARTAMENTO
                            from t in dbc.TIPO_CENTRO
                            where d.ID_PERSONA == propietario && u.ID_DEPARTAMENTO == d.ID_DEPARTAMENTO &&
                            u.ID_CENTRO == c.ID_CENTRO && u.COD_HORARIO == h.ID_HORARIO_CENTRO &&
                            b.DEP == u.ID_DEPARTAMENTO && c.ID_TIPO_CENTRO == t.ID_TIPO_CENTRO &&
                            b.ID_BOLETA == u.ID_BOLETA && b.DEP == u.ID_DEPARTAMENTO && t.ID_TIPO_CENTRO == tipo
                            select new Adapter.AdapterReserva()
                            {
                                _ID_RESERVA_CENTRO = u.ID_RESERVA_CENTRO,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _ID_HORARIO_CENTRO = h.ID_HORARIO_CENTRO,
                                _ID_CENTRO = c.ID_CENTRO,
                                _ID_BOLETA = b.ID_BOLETA,
                                _ID_TIPO_CENTRO = t.ID_TIPO_CENTRO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _NOMBRE_CENTRO = c.NOMBRE_CENTRO,
                                _DIA_HORARIO = h.DIA_HORARIO,
                                _HORA_INICIO_D = h.HORA_INICIO_D,
                                _HORA_TERMINO_D = h.HORA_TERMINO_D,
                                _COSTO_BOLETA = b.COSTO_BOLETA,
                                _NOMBRE_TIPO_CENTRO = t.NOMBRE_TIPO_CENTRO,
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

        public static List<Adapter.AdapterReserva> listadoReservaDepartamento(long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.RESERVA_CENTRO
                            from c in dbc.CENTRO
                            from b in dbc.BOLETA
                            from h in dbc.HORARIO_CENTRO
                            from d in dbc.DEPARTAMENTO
                            from t in dbc.TIPO_CENTRO
                            where u.ID_DEPARTAMENTO == departamento && u.ID_DEPARTAMENTO == d.ID_DEPARTAMENTO &&
                            u.ID_CENTRO == c.ID_CENTRO && u.COD_HORARIO == h.ID_HORARIO_CENTRO &&
                            b.DEP == u.ID_DEPARTAMENTO && c.ID_TIPO_CENTRO == t.ID_TIPO_CENTRO &&
                            b.ID_BOLETA == u.ID_BOLETA && b.DEP == u.ID_DEPARTAMENTO
                            select new Adapter.AdapterReserva()
                            {
                                _ID_RESERVA_CENTRO = u.ID_RESERVA_CENTRO,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _ID_HORARIO_CENTRO = h.ID_HORARIO_CENTRO,
                                _ID_CENTRO = c.ID_CENTRO,
                                _ID_BOLETA = b.ID_BOLETA,
                                _ID_TIPO_CENTRO = t.ID_TIPO_CENTRO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _NOMBRE_CENTRO = c.NOMBRE_CENTRO,
                                _DIA_HORARIO = h.DIA_HORARIO,
                                _HORA_INICIO_D = h.HORA_INICIO_D,
                                _HORA_TERMINO_D = h.HORA_TERMINO_D,
                                _COSTO_BOLETA = b.COSTO_BOLETA,
                                _NOMBRE_TIPO_CENTRO = t.NOMBRE_TIPO_CENTRO,
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

        public static List<Adapter.AdapterReserva> listadoSearchReservaDepartamento(long departamento, string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.RESERVA_CENTRO
                            from c in dbc.CENTRO
                            from b in dbc.BOLETA
                            from h in dbc.HORARIO_CENTRO
                            from d in dbc.DEPARTAMENTO
                            from t in dbc.TIPO_CENTRO
                            where u.ID_DEPARTAMENTO == departamento && u.ID_DEPARTAMENTO == d.ID_DEPARTAMENTO &&
                            u.ID_CENTRO == c.ID_CENTRO && u.COD_HORARIO == h.ID_HORARIO_CENTRO &&
                            b.DEP == u.ID_DEPARTAMENTO && c.ID_TIPO_CENTRO == t.ID_TIPO_CENTRO &&
                            b.ID_BOLETA == u.ID_BOLETA && b.DEP == u.ID_DEPARTAMENTO &&
                            (h.DIA_HORARIO.Contains(parametro) || h.HORA_INICIO_D.Contains(parametro) || h.HORA_TERMINO_D.Contains(parametro) ||
                            d.NUMERO_DEP.Contains(parametro) || t.NOMBRE_TIPO_CENTRO.Contains(parametro))
                            select new Adapter.AdapterReserva()
                            {
                                _ID_RESERVA_CENTRO = u.ID_RESERVA_CENTRO,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _ID_HORARIO_CENTRO = h.ID_HORARIO_CENTRO,
                                _ID_CENTRO = c.ID_CENTRO,
                                _ID_BOLETA = b.ID_BOLETA,
                                _ID_TIPO_CENTRO = t.ID_TIPO_CENTRO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _NOMBRE_CENTRO = c.NOMBRE_CENTRO,
                                _DIA_HORARIO = h.DIA_HORARIO,
                                _HORA_INICIO_D = h.HORA_INICIO_D,
                                _HORA_TERMINO_D = h.HORA_TERMINO_D,
                                _COSTO_BOLETA = b.COSTO_BOLETA,
                                _NOMBRE_TIPO_CENTRO = t.NOMBRE_TIPO_CENTRO,
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

        public static List<Adapter.AdapterReserva> listadoSearchReservaTipoCentro(long departamento, long tipo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.RESERVA_CENTRO
                            from c in dbc.CENTRO
                            from b in dbc.BOLETA
                            from h in dbc.HORARIO_CENTRO
                            from d in dbc.DEPARTAMENTO
                            from t in dbc.TIPO_CENTRO
                            where u.ID_DEPARTAMENTO == departamento && u.ID_DEPARTAMENTO == d.ID_DEPARTAMENTO &&
                            u.ID_CENTRO == c.ID_CENTRO && u.COD_HORARIO == h.ID_HORARIO_CENTRO &&
                            b.DEP == u.ID_DEPARTAMENTO && c.ID_TIPO_CENTRO == t.ID_TIPO_CENTRO &&
                            b.ID_BOLETA == u.ID_BOLETA && b.DEP == u.ID_DEPARTAMENTO && t.ID_TIPO_CENTRO == tipo
                            select new Adapter.AdapterReserva()
                            {
                                _ID_RESERVA_CENTRO = u.ID_RESERVA_CENTRO,
                                _ID_DEPARTAMENTO = d.ID_DEPARTAMENTO,
                                _ID_HORARIO_CENTRO = h.ID_HORARIO_CENTRO,
                                _ID_CENTRO = c.ID_CENTRO,
                                _ID_BOLETA = b.ID_BOLETA,
                                _ID_TIPO_CENTRO = t.ID_TIPO_CENTRO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _NOMBRE_CENTRO = c.NOMBRE_CENTRO,
                                _DIA_HORARIO = h.DIA_HORARIO,
                                _HORA_INICIO_D = h.HORA_INICIO_D,
                                _HORA_TERMINO_D = h.HORA_TERMINO_D,
                                _COSTO_BOLETA = b.COSTO_BOLETA,
                                _NOMBRE_TIPO_CENTRO = t.NOMBRE_TIPO_CENTRO,
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