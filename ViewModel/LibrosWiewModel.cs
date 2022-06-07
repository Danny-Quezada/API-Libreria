using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
   public class LibrosWiewModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Temas { get; set; }
        public string Editorial { get; set; }
    }
}
