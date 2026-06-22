using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<CarritoDetalle> ItemsCarrito { get; set; }

        /*public int IdCarrito { get; set; }
        public Usuario UsuarioCarrito { get; set; }

        public DateTime Fecha { get; set; }*/
    }
}
