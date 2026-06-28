using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public ConfirmarPedido PedidoConfirmado { get; set; }
        public DateTime FechaPedido { get; set; }
        //public EstadoPedido EstadoPedido { get; set; }
        public List<PedidoDetalle> ListaDetalles { get; set; }
        //confirmarPedido -- Pedido -- pedidoDetalle -- Elimina carrito y detallecarrito //
        //Vendedor -- Pedido
    }
}
