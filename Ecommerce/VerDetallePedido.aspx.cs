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
        public Pedido PedidoSeleccionado {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.SesionActiva((Usuario)Session["UsuarioIngresado"]))
            {
                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if (id != "")
                {
                    Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
                    PedidoNegocio negocioPedido = new PedidoNegocio();
                    List<PedidoDetalle> listadoPedidoDetalle = negocioPedido.BuscarDetallePedido(int.Parse(id));
                    List<Pedido> listaPedido = negocioPedido.ListarPedidos(UsuarioIngresado.Id, id);
                    PedidoSeleccionado = listaPedido[0];
                    if (string.IsNullOrEmpty(PedidoSeleccionado.PedidoConfirmado.DireccionEntrega.Calle))
                    {
                        PanelDomicilio.Visible = false;
                        panelRetiroAlLocal.Visible = true;
                    }
                    else
                    {
                        PanelDomicilio.Visible = true;
                        panelRetiroAlLocal.Visible = false;
                    }
                    dgvDetallePedido.DataSource = listadoPedidoDetalle;
                    dgvDetallePedido.DataBind();
                }
            } else
                Response.Redirect("Login.aspx", false);
        }
    }
}