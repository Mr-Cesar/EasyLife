using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerControlIluminacionEdificio
    {
        public static CONTROL_ILUMINACION_EDIFICIO buscarIdControl(long control)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                CONTROL_ILUMINACION_EDIFICIO aux = (from u in dbc.CONTROL_ILUMINACION_EDIFICIO
                                                    where u.ID_CILUMINACION_E == control
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

        public static string crearControlEdificio(long luz, string horaI, string horaT, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertControlEdificio(luz, horaI, horaT, estado);
                return "Control Creado";
            }
        }

        public static string modificarControlEdificio(long control, long luz, string horaI, string horaT, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateControlEdificio(control, luz, horaI, horaT, estado);
                return "Control Modificado";
            }
        }

        public static List<CONTROL_ILUMINACION_EDIFICIO> listaControlEdificio(long luz)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CONTROL_ILUMINACION_EDIFICIO
                            where u.ID_LUZ_E == luz
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

        public static List<Adapter.AdapterControlLuzEdificio> listaControlesEdificio(long edificio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CONTROL_ILUMINACION_EDIFICIO
                            from e in dbc.EDIFICIO
                            from l in dbc.LUZ_EDIFICIO
                            where u.ID_LUZ_E == l.ID_LUZ_E && l.ID_EDIFICIO == e.ID_EDIFICIO && e.ID_EDIFICIO == edificio
                            select new Adapter.AdapterControlLuzEdificio()
                            {
                                _ID_CILUMINACION_E = u.ID_CILUMINACION_E,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _CODIGO_LUZ_E = l.CODIGO_LUZ_E,
                                _HORA_INICIO_E = u.HORA_INICIO_E,
                                _HORA_TERMINO_E = u.HORA_TERMINO_E,
                                _ESTADO_LUZ_CE = u.ESTADO_LUZ_CE,
                                _ESTADO_CONTROL_E = u.ESTADO_CONTROL_E
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

        public static List<Adapter.AdapterControlLuzEdificio> listaSearchControlesEdificio(long edificio, string parametro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CONTROL_ILUMINACION_EDIFICIO
                            from e in dbc.EDIFICIO
                            from l in dbc.LUZ_EDIFICIO
                            where u.ID_LUZ_E == l.ID_LUZ_E && l.ID_EDIFICIO == e.ID_EDIFICIO && e.ID_EDIFICIO == edificio &&
                            (u.HORA_INICIO_E.Contains(parametro) || u.HORA_TERMINO_E.Contains(parametro) || e.NOMBRE_EDIFICIO.Contains(parametro) ||
                            l.CODIGO_LUZ_E.Contains(parametro))
                            select new Adapter.AdapterControlLuzEdificio()
                            {
                                _ID_CILUMINACION_E = u.ID_CILUMINACION_E,
                                _ID_EDIFICIO = e.ID_EDIFICIO,
                                _NOMBRE_EDIFICIO = e.NOMBRE_EDIFICIO,
                                _CODIGO_LUZ_E = l.CODIGO_LUZ_E,
                                _HORA_INICIO_E = u.HORA_INICIO_E,
                                _HORA_TERMINO_E = u.HORA_TERMINO_E,
                                _ESTADO_LUZ_CE = u.ESTADO_LUZ_CE,
                                _ESTADO_CONTROL_E = u.ESTADO_CONTROL_E
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