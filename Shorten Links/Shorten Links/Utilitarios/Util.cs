using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shorten_Links.Utilitarios
{
    public class Util
    {
        public void LogErrro(String Dato)
        {
            string Ruta = "C:\\LogsCutLinks";

            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            string strDate = Convert.ToDateTime(dateTime).ToString("yyMMdd");

            if (!File.Exists(Ruta))
            {
                File.Create(Ruta); 

                string Log = "\\Log";
                StreamWriter sw = File.CreateText(Ruta + Log + strDate);
                sw.Write(Dato + strDate);
                sw.Close();
            }
            else
            {
                string Log = "\\Log";
                StreamWriter sw = File.CreateText(Ruta + Log + strDate);
                sw.Write(Dato + strDate);
                sw.Close();
            }
        }
    }
}
