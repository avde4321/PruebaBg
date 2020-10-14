using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shorten_Links.Models
{
    public class GestorBD
    {
        [Key]
        public int CiRegistros { get; set; }
        public string UrlOriginal { get; set; }
        public string UrlShortern { get; set; }
        public string FechaIngreso { get; set; }
        public string Estado { get; set; }
    }
}
