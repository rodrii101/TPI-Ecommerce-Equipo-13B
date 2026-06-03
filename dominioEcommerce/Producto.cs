using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public Categoria Categoria { get; set; }
        public bool Estado { get; set; }
        public int Stock { get; set; }
    }
}
