using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Entities
{
    public class Imagenes
    {
        public int IdImage { get; set; }
        public byte[] Archivo { get; set; }
        public string Nombre { get; set; }
        public string ContentType { get; set; }
       
    }
}
