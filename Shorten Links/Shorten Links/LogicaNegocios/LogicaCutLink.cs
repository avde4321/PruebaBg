using Shorten_Links.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shorten_Links.LogicaNegocios
{
    public class LogicaCutLink
    {
        public GestorBD CutLink(GestorBD gestor)
        {
            int longitud = 7;
            int indice = 0;
            const string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder token = new StringBuilder();
            Random rnd = new Random();
            try
            {
                for (int i = 0; i < longitud; i++)
                {
                    indice = rnd.Next(alfabeto.Length);
                    token.Append(alfabeto[indice]);
                }
                gestor.UrlShortern = "https://localhost:44337/api/CutLinks/" + token.ToString();
                gestor.TokenUrl = token.ToString();
                gestor.FechaIngreso = Convert.ToString(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                gestor.Estado = "A";
            }
            catch (Exception ex)
            {

            }

            return gestor;
        }

        public object ContadorIngreso( dynamic Registro) 
        {
            
            try
            {
                Registro.ContIngreso = Registro.ContIngreso + 1;
                Registro.FechaIngreso = Convert.ToString(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
            }
            catch (Exception)
            {

                throw;
            }
            return Registro;
        }
    }
}
