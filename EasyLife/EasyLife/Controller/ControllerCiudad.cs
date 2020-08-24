using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerCiudad
    {
        public static List<CIUDAD> listaCiudad(long idRegion)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                var query = from u in dbc.CIUDAD
                            where u.ID_REGION == idRegion
                            select u;
                return query.ToList();
            }
        }
    }
}