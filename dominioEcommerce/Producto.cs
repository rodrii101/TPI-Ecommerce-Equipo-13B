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
        public decimal Precio { get; set; } //VERIFICAR EL TIPO DE DATO
        public Categoria Categoria { get; set; }
        //public Marca Marca {get; set}
        public bool Estado { get; set; }
        public int Stock { get; set; }
        //public ImagenProducto Imagen_URL { get; set; }
    }
}
