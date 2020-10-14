using Shorten_Links.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shorten_Links.LogicaNegocios
{
    public class LogicaCutLink
    {
        public GestorBD CutLink(GestorBD gestor)
        {
            string UrlOriginal = gestor.UrlOriginal;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create("http://tinyurl.com/api-create.php?url=" + UrlOriginal);
            try
            {
                HttpWebResponse objResponse = objRequest.GetResponse() as HttpWebResponse;
                StreamReader stmReader = new StreamReader(objResponse.GetResponseStream());

                gestor.UrlShortern = stmReader.ReadToEnd();
                gestor.FechaIngreso = Convert.ToString(DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
                gestor.Estado = "A";
            }
            catch (Exception ex)
            { 

            }

            return gestor;
        }
    }
}
