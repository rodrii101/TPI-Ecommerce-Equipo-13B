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
        public Usuario UsuarioCarrito { get; set; }

        public DateTime Fecha { get; set; }
    }
}
