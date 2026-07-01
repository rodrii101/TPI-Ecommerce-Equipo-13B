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
    public partial class GestionEstadoPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.SesionAdmin(Session["UsuarioIngresado"]))
            {
                Session.Add("Error", "Debe tener permisos de Admin");
                Response.Redirect("Error.aspx");
            }
            if (Seguridad.SesionActiva(Session["UsuarioIngresado"]))
            {
                Usuario usuarioIngresado = (Usuario)Session["UsuarioIngresado"];

                if (!IsPostBack)
                {
                    PedidoNegocio negocioPedido = new PedidoNegocio();
                    List<Pedido> listaPedidos = negocioPedido.listarTodosLosPedidos();
                    Session.Add("ListadoPedido", listaPedidos);
                
                    bool encontrePedido = (listaPedidos != null && listaPedidos.Count > 0);
                    panelPedidos.Visible = encontrePedido;
                    panelSinPedidos.Visible = !encontrePedido;

                    dgvPedidos.DataSource = listaPedidos;
                    dgvPedidos.DataBind();
                }

            }
            else
                Response.Redirect("Login.aspx", false);
        }

        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdPedido = dgvPedidos.SelectedDataKey.Value.ToString();
            Response.Redirect("GestionarEstado.aspx?Id=" + IdPedido, false);
        }

        protected void txtIdPedido_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdPedido.Text))
            {
                int idPedido = int.Parse(txtIdPedido.Text);

                List<Pedido> listaPedido = (List<Pedido>)Session["ListadoPedido"];
                List<Pedido> listaFiltradaPedido = listaPedido.FindAll(lp => lp.IdPedido == idPedido);

                bool encontrePedido = (listaFiltradaPedido != null && listaFiltradaPedido.Count > 0);
                panelPedidos.Visible = encontrePedido;
                panelSinPedidos.Visible = !encontrePedido;
                dgvPedidos.DataSource = listaFiltradaPedido;
                dgvPedidos.DataBind();
            }
            else
            {
                dgvPedidos.DataSource = (List<Pedido>)Session["ListadoPedido"];
                dgvPedidos.DataBind();
            }
        }
    }
}