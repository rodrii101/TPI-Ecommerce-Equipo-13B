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
        public Usuario Usuario { get; set; }
        //NUEVOS PARA SOLUCIONAR TOMA DE STOCK
        public bool HayStock { get; set; }
        public bool HayEsaCantidad { get; set; }

    }
}
