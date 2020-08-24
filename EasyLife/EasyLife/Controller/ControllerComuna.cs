using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerComuna
    {
        public static List<COMUNA> listaCiudad(long idCiudad)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.COMUNA
                            where u.ID_CIUDAD == idCiudad
                            select u;
                return query.ToList();
            }
        }
    }
}