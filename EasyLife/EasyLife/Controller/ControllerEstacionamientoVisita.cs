using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerEstacionamientoVisita
    {
        public static string crearEstacionamiento(string departamento, long edificio, string patente, string horaE, int total)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertEstacionamiento(departamento, edificio, patente, horaE, total);
                return "Estacionamiento Creado";
            }
        }

        public static string modificarEstacionamiento(long estacionamiento, long boleta, string departamento, long edificio, string patente, string horaE, string horaS,
            Boolean estado, int total)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateEstacionamiento(estacionamiento, boleta, departamento, edificio, patente, horaE, horaS, estado, total);
                return "Estacionamiento Modificado";
            }
        }

        public static string salidaEstacionamiento(long est, long boleta, string horaS, int total, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateEstSalida(est, boleta, horaS, total, estado);
                return "Salida Registrada";
            }
        }

        public static ESTACIONAMIENTO_VISITA buscarIdEstacionamiento(long estacionamiento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                ESTACIONAMIENTO_VISITA aux = (from u in dbc.ESTACIONAMIENTO_VISITA
                                              where u.ID_ESTACIONAMIENTO == estacionamiento
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

        public static List<Adapter.AdapterEstacionamiento> listaEstacionamiento(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.ESTACIONAMIENTO_VISITA
                            from e in dbc.EDIFICIO
                            from d in dbc.DEPARTAMENTO
                            where u.EDIFICIO == edificio && u.NUM_DEP == d.NUMERO_DEP &&
                            u.EDIFICIO == e.ID_EDIFICIO && e.ID_EDIFICIO == d.ID_EDIFICIO
                            select new Adapter.AdapterEstacionamiento()
                            {
                                _ID_ESTACIONAMIENTO = u.ID_ESTACIONAMIENTO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _PATENTE = u.PATENTE,
                                _HORA_ENTRADA = u.HORA_ENTRADA,
                                _HORA_SALIDA = u.HORA_SALIDA,
                                _ESTADO_EST = u.ESTADO_EST,
                                _COSTO_BOLETA = u.TOTAL_EST
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

        public static List<Adapter.AdapterEstacionamiento> listaSearchEstacionamiento(long edificio, string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.ESTACIONAMIENTO_VISITA
                            from e in dbc.EDIFICIO
                            from d in dbc.DEPARTAMENTO
                            where u.EDIFICIO == edificio && u.NUM_DEP == d.NUMERO_DEP &&
                            u.EDIFICIO == e.ID_EDIFICIO && e.ID_EDIFICIO == d.ID_EDIFICIO &&
                            (u.PATENTE.Contains(parametro) || u.NUM_DEP.Contains(parametro) || e.NOMBRE_EDIFICIO.Contains(parametro))
                            select new Adapter.AdapterEstacionamiento()
                            {
                                _ID_ESTACIONAMIENTO = u.ID_ESTACIONAMIENTO,
                                _NUMERO_DEP = d.NUMERO_DEP,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _PATENTE = u.PATENTE,
                                _HORA_ENTRADA = u.HORA_ENTRADA,
                                _HORA_SALIDA = u.HORA_SALIDA,
                                _ESTADO_EST = u.ESTADO_EST,
                                _COSTO_BOLETA = u.TOTAL_EST
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