using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class CarritoDetalle
    {
        public int IdCarritoDetalle { get; set; }
        public int IdCarrito { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public Producto Producto { get; set; }

        /*public int IdCarrioDetalle { get; set; }
        public Carrito Carrito { get; set; }
        public Producto Producto { get; set; }
        public int CantidadProducto { get; set; }*/
    }
}
