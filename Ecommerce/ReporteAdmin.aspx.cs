using negocioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ReporteAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PedidoNegocio negocioPedido = new PedidoNegocio();
            dgvTopPedidos.DataSource = negocioPedido.ReporteTopPedidos();
            dgvTopPedidos.DataBind();

            dgvTopProducto.DataSource = negocioPedido.ReporteTopProductos();
            dgvTopProducto.DataBind();

            dgvTopVendedores.DataSource = negocioPedido.ReporteTopVendedores();
            dgvTopVendedores.DataBind();
        }
    }
}