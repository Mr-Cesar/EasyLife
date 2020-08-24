using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerTurno
    {
        public static string crearTurno(string descripcion, string fechaI, string fechaT, long conserje)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertTurno(descripcion, fechaI, fechaT);
                dbc.insertTurno_Conserje(conserje);
                return "Turno Creado";
            }
        }

        public static string modificarTurno(long turno, string descripcion, string fechaI, string fechaT)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateTurno(turno, descripcion, fechaI, fechaT);
                return "Turno Modificado";
            }
        }

        public static string eliminarTurno(long turno)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.deleteTurno(turno);
                return "Turno Eliminado";
            }
        }

        public static string asignarTurno(long conserje)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertTurno_Conserje(conserje);
                return "Turno Asignado";
            }
        }

        public static TURNO buscarIdTurno(long turno)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                TURNO aux = (from u in dbc.TURNO
                             where u.ID_TURNO == turno
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

        public static List<TURNO> listaTurno(long conserje)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.listaTurno(conserje)
                            select new TURNO()
                            {
                                ID_TURNO = u.ID_TURNO,
                                DESCRIPCION_TURNO = u.DESCRIPCION_TURNO,
                                FECHA_INICIO = u.FECHA_INICIO,
                                FECHA_TERMINO = u.FECHA_TERMINO
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