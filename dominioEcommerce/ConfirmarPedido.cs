using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class ConfirmarPedido
    {
        public Usuario Cliente { get; set; }//NOMBRE, APELLIDO, EMAIL, 
        //public Usuario Vendedor { get; set; } NO LO USO PORQUE EL VENDEDOR FIGURA EN CADA PRODUCTO
        public FormasDeEntrega FormaEntrega { get; set; }
        public DireccionUsuario DireccionEntrega { get; set; }
        public FormasDePagos FormaDePago { get; set; }
        public List<CarritoDetalle> ListaDetalleCarrito { get; set; }
        public Decimal MontoTotal { get; set; }
    }
}
