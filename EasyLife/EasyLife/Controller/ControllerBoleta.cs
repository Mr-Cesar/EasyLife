using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyLife.Controller
{
    public class ControllerBoleta
    {
        public static string crearBoletaEst(long estacionamiento, long persona, int costo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertBoletaEst(estacionamiento, persona, costo);
                return "Boleta Creada";
            }
        }

        public static string crearBoletaReserva(long persona, int costo, long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertBoletaReserva(persona, costo, departamento);
                return "Boleta Creada";
            }
        }

        public static string crearBoletaGasto(long persona, int costo, long departamento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.insertBoletaGasto(persona, costo, departamento);
                return "Boleta Creada";
            }
        }

        public static string modificarBoletaReserva(int costo, long boleta)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                dbc.updateBoletaReserva(costo, boleta);
                return "Boleta Modificada";
            }
        }

        public static BOLETA buscarBoletaEst(long estacionamiento)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                BOLETA aux = (from u in dbc.BOLETA
                              where u.ID_ESTACIONAMIENTO == estacionamiento
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

        public static BOLETA buscarBoletaReserva(long conserje, long departamento, int costo)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                BOLETA aux = (from u in dbc.BOLETA
                              where u.ID_PERSONA == conserje && u.DEP == departamento && u.COSTO_BOLETA == costo
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