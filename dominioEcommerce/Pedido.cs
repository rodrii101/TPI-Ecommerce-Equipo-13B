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
        public List<PedidoDetalle> ListaDetalles { get; set; }

        //NUEVAS PROPIEDADES
        public int IdEstadoActual { get; set; } //EL ID DEL ULTIMO CAMBIO DE ESTADO
        public EstadoPedido EstadoActual { get; set; } //PARA ACCEDER A .EstadoActual.Descripcion

        public List<HistorialEstadoPedido> HistorialEstados { get; set; }//TENMOS EL LISTADO DEL HISTORIAL CAMNIO DE ESTADOS

        //confirmarPedido -- Pedido -- pedidoDetalle -- Elimina carrito y detallecarrito //
        //Vendedor -- Pedido
    }
}
