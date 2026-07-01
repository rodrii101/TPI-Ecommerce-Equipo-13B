using dominioEcommerce;
using negocioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class GestionarEstado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.SesionActiva(Session["UsuarioIngresado"]))
            {
                if (!IsPostBack)
                {
                    Usuario usuarioIngresado = (Usuario)Session["UsuarioIngresado"];

                    if (Request.QueryString["Id"] != null || Request.QueryString["Id"] != "") {
                        int idPedido = int.Parse(Request.QueryString["Id"]);

                        PedidoNegocio negocioPedido = new PedidoNegocio();
                        Pedido pedido = negocioPedido.buscarPedido(idPedido);
                        Session.Add("Pedido", pedido);

                        CargarPedido(pedido);

                        CargarHistorial(idPedido);
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        public void CargarHistorial(int idPedido)
        {
            HistorialEstadoPedidoNegocio historialNegocio = new HistorialEstadoPedidoNegocio();
            List<HistorialEstadoPedido> listaHistorialPedidos = historialNegocio.ListarHistorialPedido(idPedido);
            dgvHistorial.DataSource = listaHistorialPedidos;
            dgvHistorial.DataBind();
        }

        public void CargarPedido(Pedido pedido)
        {
            lblIdPedido.Text = pedido.IdPedido.ToString();
            lblCliente.Text = pedido.PedidoConfirmado.Cliente.Nombre + " " + pedido.PedidoConfirmado.Cliente.Apellido;
            lblFecha.Text = pedido.FechaPedido.ToString();
            lblEstado.Text = pedido.EstadoActual.Descripcion;
            lblFormaDeEntrega.Text = pedido.PedidoConfirmado.FormaEntrega.Descripcion;
            lblFormaDePago.Text = pedido.PedidoConfirmado.FormaDePago.Descripcion;
            lblMontoTotal.Text = pedido.PedidoConfirmado.MontoTotal.ToString();
        }

        protected void btnRegistrarEstado_Click(object sender, EventArgs e)
        {
            panelResgistrarEstado.Visible = true;
            EstadoPedidoNegocio estadoPedidoNegocio = new EstadoPedidoNegocio();
            List<EstadoPedido> listaEstados = estadoPedidoNegocio.listarEstadoPedido();
            
            ddlEstados.DataSource = listaEstados;
            ddlEstados.DataValueField = "IdEstadoPedido";
            ddlEstados.DataTextField = "Descripcion";
            ddlEstados.DataBind();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionEstadoPedido.aspx", false);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            HistorialEstadoPedido nuevoHistorial = new HistorialEstadoPedido();
            nuevoHistorial.IdPedido = ((Pedido)(Session["Pedido"])).IdPedido;
            nuevoHistorial.Estado = new EstadoPedido();
            nuevoHistorial.Estado.IdEstadoPedido = int.Parse(ddlEstados.SelectedValue);
            nuevoHistorial.Observaciones = txtObservacion.Text;

            HistorialEstadoPedidoNegocio negocioHistorial = new HistorialEstadoPedidoNegocio();
            negocioHistorial.RegistrarCambio(nuevoHistorial);
            panelResgistrarEstado.Visible = false;

            PedidoNegocio negocioPedido = new PedidoNegocio();
            negocioPedido.ActualizarEstadoPedido(nuevoHistorial.IdPedido, nuevoHistorial.Estado.IdEstadoPedido);

            Pedido pedido = negocioPedido.buscarPedido(nuevoHistorial.IdPedido);
            Session.Add("Pedido", pedido);
            CargarPedido(pedido);
            CargarHistorial(nuevoHistorial.IdPedido);
        }
    }
}