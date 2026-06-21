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
        public Usuario UsuarioPedido { get; set; }  
        public DireccionUsuario DireccionUsuarioPedido { get; set; }
        public FormasDePagos FormaDePagoPedido { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public decimal MontoTotal { get; set; }
    }
}
