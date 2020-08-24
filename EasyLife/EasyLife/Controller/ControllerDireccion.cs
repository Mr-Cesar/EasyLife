using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerDireccion
    {
        public static string crearDireccion(long comuna, string calle, int numero)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertDireccion(comuna, calle, numero);
                return "Direccion Creada";
            }
        }

        public static string modificarDireccion(long direccion, long condominio, long comuna, string calle, int numero)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateDireccion(direccion, condominio, calle, numero, comuna);
                return "Direccion Modificada";
            }
        }

        public static DIRECCION buscarIdDireccion(long direccion)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                DIRECCION aux = (from u in dbc.DIRECCION
                                 where u.ID_DIRECCION == direccion
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

        public static DIRECCION buscarDireccion(long comuna, string calle, int numero)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                DIRECCION aux = (from u in dbc.DIRECCION
                                 where u.ID_COMUNA == comuna && u.CALLE == calle && u.NUMERO == numero
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

        public static DIRECCION buscarDireccionCondominio(long condominio)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                DIRECCION aux = (from u in dbc.DIRECCION
                                 where u.ID_CONDOMINIO == condominio
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