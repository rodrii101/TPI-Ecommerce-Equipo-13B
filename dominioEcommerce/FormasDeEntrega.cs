using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class FormasDeEntrega
    {
        public int IdFormasDePago { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
    }
}
