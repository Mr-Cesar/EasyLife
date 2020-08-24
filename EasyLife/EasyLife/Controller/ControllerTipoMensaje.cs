using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerTipoMensaje
    {
        public static List<TIPO_MENSAJE> listaTipoMensaje()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.TIPO_MENSAJE
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

        public static TIPO_MENSAJE buscarTipoMensaje(string tipoMensaje)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                TIPO_MENSAJE aux = (from u in dbc.TIPO_MENSAJE
                                    where u.DESCRIPCION_TP == tipoMensaje
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

        public static TIPO_MENSAJE buscarIdTipoMensaje(long idTipoMensaje)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                TIPO_MENSAJE aux = (from u in dbc.TIPO_MENSAJE
                                    where u.ID_TIPO_MENSAJE == idTipoMensaje
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
    }
}