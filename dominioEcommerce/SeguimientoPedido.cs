using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class SeguimientoPedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdEstadoPedido { get; set; }
        public EstadoPedido PedidoEstadoSeguimiento { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaEstadoSeguimiento { get; set; }
    }
}
