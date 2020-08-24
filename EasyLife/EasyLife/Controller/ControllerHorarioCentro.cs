using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerHorarioCentro
    {
        public static string crearHorarioCentro(long centro, string dia, string horaI, string horaT, string horaC)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertHorario(centro, dia, horaI, horaT, horaC);
                return "Horario Creado";
            }
        }

        public static string modificarHorario(long horario, long centro, string dia, string horaI, string horaT, string horarioC)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateHorario(horario, centro, dia, horaI, horaT, horarioC);
                return "Horario Modificado";
            }
        }

        public static string eliminarHorario(long horario)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.deleteHorario(horario);
                return "Horario Eliminado";
            }
        }

        public static string modificarEstadoHorario(long horario, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateEstadoHorario(horario, estado);
                return "Estado Horario Modificado";
            }
        }

        public static HORARIO_CENTRO buscarIdHorarioCentro(long horario)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                HORARIO_CENTRO aux = (from u in dbc.HORARIO_CENTRO
                                      where u.ID_HORARIO_CENTRO == horario
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

        public static List<HORARIO_CENTRO> listadoHorario(long centro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.HORARIO_CENTRO
                            where u.ID_CENTRO == centro
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

        public static List<HORARIO_CENTRO> listadoHorarioDia(long centro, string dia)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.HORARIO_CENTRO
                            where u.ID_CENTRO == centro && u.DIA_HORARIO == dia
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