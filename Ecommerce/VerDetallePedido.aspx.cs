using dominioEcommerce;
using negocioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class VerDetallePedido : System.Web.UI.Page
    {
        public decimal  Subtotal { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
            if (id != "")
            {
                PedidoNegocio negocioPedido = new PedidoNegocio();
                List<PedidoDetalle> listadoPedidoDetalle = negocioPedido.BuscarDetallePedido(int.Parse(id));
                
                dgvDetallePedido.DataSource = listadoPedidoDetalle;
                dgvDetallePedido.DataBind();
            }
        }
    }
}