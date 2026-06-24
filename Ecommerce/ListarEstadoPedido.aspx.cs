using negocioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class ListarEstadoPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                EstadoPedidoNegocio negocioEstadoPedido = new EstadoPedidoNegocio();
                dgvListadoEstadoPedido.DataSource = negocioEstadoPedido.listarEstadoPedido();
                dgvListadoEstadoPedido.DataBind();
        }

        protected void dgvListadoEstadoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvListadoEstadoPedido.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioEstadoPedido.aspx?IdEstadoPedido=" + Id);
        }
    }
}