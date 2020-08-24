using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/* Referencia Configuration */

using System.Configuration;

namespace EasyLife.Controller
{
    public class ControllerLogin
    {
        public static LOGIN loginPersona(string rut, string pass)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                try
                {
                    string passEncripter = Controller.ControllerEncryption.stEncryptionMD5(pass);
                    string key = ConfigurationManager.AppSettings["stKey"];
                    string pass3DES = Controller.ControllerEncryption.stEncryption3DES(passEncripter, key);
                    LOGIN aux = (from u in dbc.LOGIN
                                 where u.FK_RUT.Equals(rut) && u.PASSWORD_LOGIN.Equals(pass3DES)
                                 select u).FirstOrDefault();
                    string passDescripted = Controller.ControllerEncryption.stDecrypt(pass3DES, key);
                    if (!passDescripted.Equals(passDescripted))
                    {
                        aux = null;
                    }

                    PERSONA persona = Controller.ControllerPersona.buscarPersonaRut(aux.FK_RUT);
                    if (persona.ESTADO_PERSONA == false)
                    {
                        aux = null;
                    }

                    if (aux != null)
                    {
                        return aux;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error " + ex);
                    return null;
                }
            }
        }

        public static string modificarPassword(string rut, string passActual, string newPass)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                LOGIN aux = loginPersona(rut, passActual);
                string passEncripter = Controller.ControllerEncryption.stEncryptionMD5(newPass);
                string key = ConfigurationManager.AppSettings["stKey"];
                string pass3DES = Controller.ControllerEncryption.stEncryption3DES(passEncripter, key);
                dbc.UpdatePassword(pass3DES, aux.ID_PERSONA);
                return "Password Cambiada";
            }
        }

        public static LOGIN buscarLogin(string rut)
        {
            using (EasyLifeEntities dbc = new EasyLifeEntities())
            {
                LOGIN aux = (from u in dbc.LOGIN
                             where u.FK_RUT == rut
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