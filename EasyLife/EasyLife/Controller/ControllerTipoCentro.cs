using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerTipoCentro
    {
        public static List<TIPO_CENTRO> listaTipoCentro()
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.TIPO_CENTRO
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

        public static TIPO_CENTRO buscarTipoCentro(string tipoCentro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                TIPO_CENTRO aux = (from u in dbc.TIPO_CENTRO
                                   where u.NOMBRE_TIPO_CENTRO == tipoCentro
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

        public static TIPO_CENTRO buscarIdTipoCentro(long idTipoCentro)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                TIPO_CENTRO aux = (from u in dbc.TIPO_CENTRO
                                   where u.ID_TIPO_CENTRO == idTipoCentro
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