using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerMensaje
    {
        public static string crearMensaje(long tipo, long persona, string descripcion, string emisor, string destinatario, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertMensaje(tipo, persona, descripcion, emisor, destinatario, estado);
                return "Mensaje Creado";
            }
        }

        public static string modificarMensaje(long mensaje, long tipo, long persona, string descripcion, string emisor, string destinatario, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateMensaje(mensaje, tipo, persona, descripcion, emisor, destinatario, estado);
                return "Mensaje Modificado";
            }
        }

        public static string eliminarMensaje(long mensaje)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.deleteMensaje(mensaje);
                return "Mensaje Eliminado";
            }
        }

        public static string modificarEstadoMensaje(long mensaje, Boolean estado)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.CambioEstMensaje(mensaje, estado);
                return "Estado Mensaje Modificado";
            }
        }

        public static List<MENSAJE> listadoMensajePersona(long persona)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.MENSAJE
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

        public static List<Adapter.AdapterMensaje> listaMensajeProp(string rut)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.MENSAJE
                            from t in dbc.TIPO_MENSAJE
                            where u.ID_TIPO_MENSAJE == t.ID_TIPO_MENSAJE && u.DESTINATARIO_MENSAJE == rut
                            select new Adapter.AdapterMensaje()
                            {
                                _ID_MENSAJE = u.ID_MENSAJE,
                                _DESCRIPCION_MENSAJE = u.DESCRIPCION_MENSAJE,
                                _EMISOR_MENSAJE = u.EMISOR_MENSAJE,
                                _DESTINATARIO_MENSAJE = u.DESTINATARIO_MENSAJE,
                                _DESCRIPCION_TP = t.DESCRIPCION_TP
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

        public static List<Adapter.AdapterMensaje> listaMensajeAdm(string rut)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.MENSAJE
                            from t in dbc.TIPO_MENSAJE
                            where u.ID_TIPO_MENSAJE == t.ID_TIPO_MENSAJE && u.EMISOR_MENSAJE == rut
                            select new Adapter.AdapterMensaje()
                            {
                                _ID_MENSAJE = u.ID_MENSAJE,
                                _DESCRIPCION_MENSAJE = u.DESCRIPCION_MENSAJE,
                                _EMISOR_MENSAJE = u.EMISOR_MENSAJE,
                                _DESTINATARIO_MENSAJE = u.DESTINATARIO_MENSAJE,
                                _DESCRIPCION_TP = t.DESCRIPCION_TP
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