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
    }
}