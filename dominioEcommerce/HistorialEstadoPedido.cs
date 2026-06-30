using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominioEcommerce
{
    public class HistorialEstadoPedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaCambio { get; set; }
        public string Observaciones { get; set; }// OBSERVACIONES CUALQUIERAS DEL ADMIN
        public EstadoPedido Estado { get; set; }//PROPOIEDAD PARA MOSTRAR LA DESCRIPCION
    }
}
