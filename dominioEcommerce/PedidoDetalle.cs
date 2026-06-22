using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class PedidoDetalle
    {
        public int IdPedidoDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }//Guarda el precio unitario en caso de que el vendedor cambie el precio en el futuro
        public Producto Producto { get; set; }//Obtener nombre, idVendedor, etc...
    }
}
