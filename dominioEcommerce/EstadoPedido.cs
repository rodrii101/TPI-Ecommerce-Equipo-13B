using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class EstadoPedido
    {
        public int IdEstadoPedido { get; set; }
        public string Descripcion { get; set; }//PAGADO, PENDIENTE PAGO, EN PREPARACION, ENVIADO 
        public string Observaciones { get; set; }//COMENTARIOS "Cliente confirmo pago por transferencia"
        public bool Estado { get; set; }

        /*
         * PENSABA EN CAMBIAR ESTADOPEDIDO A ESTO PERO NO ME DI CUENTA QUE YA LO HABIAS DESARROLLADO, ASI QUE HAY QUE VER....
         public class Estado
        {
            public int Id { get; set; }
            public string Descripcion { get; set; } // 'PENDIENTE DE PAGO', 'PAGADO', etc.
        }

         */
    }
}
