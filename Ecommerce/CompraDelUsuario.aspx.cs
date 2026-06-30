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
    public partial class CompraDelUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.SesionActiva(Session["UsuarioIngresado"]))
            {
                Usuario usuarioIngresado = (Usuario)Session["UsuarioIngresado"];
                PedidoNegocio negocioPedido = new PedidoNegocio();
                List<Pedido> listaPedidos = negocioPedido.BuscarPedidoDelUsuario(usuarioIngresado.Id);
                bool encontrePedido = (listaPedidos != null && listaPedidos.Count > 0);
                ConCompras.Visible = encontrePedido;
                SinCompras.Visible = !encontrePedido;

                dgvPedidosUsuario.DataSource = listaPedidos;
                dgvPedidosUsuario.DataBind();
            }else
                Response.Redirect("Login.aspx", false);
        }

        protected void dgvPedidosUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdPedido = dgvPedidosUsuario.SelectedDataKey.Value.ToString();
            Response.Redirect("VerDetallePedido.aspx?Id=" + IdPedido, false);
        }
    }
}