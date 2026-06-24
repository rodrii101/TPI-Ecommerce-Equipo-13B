using dominioEcommerce;
using negocioEcommerce;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class FormularioEstadoPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdEstadoPedido.Enabled = false;
            btmDesactivarYActivarEstadoPedido.Visible = false;
            try
            {
                string Id = Request.QueryString["IdEstadoPedido"] != null ? Request.QueryString["IdEstadoPedido"].ToString() : "";
                if (Id != "" && !IsPostBack)
                {
                    btmDesactivarYActivarEstadoPedido.Visible = true;
                    EstadoPedidoNegocio negocioEstadoPedido = new EstadoPedidoNegocio();
                    EstadoPedido seleccionado = (negocioEstadoPedido.listarEstadoPedido(Id))[0];
                    Session.Add("EstadoPedidoSeleccionado", seleccionado);
                    txtIdEstadoPedido.Text = Id;
                    txtDescripcionEstadoPedido.Text = seleccionado.Descripcion;
                    if (!seleccionado.Estado)
                    {
                        btmDesactivarYActivarEstadoPedido.Text = "Reactivar";
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnAgregarEstadoPedido_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                EstadoPedido nuevoEstadoPedido = new EstadoPedido();
                EstadoPedidoNegocio negocioEstadoPedido = new EstadoPedidoNegocio();
                nuevoEstadoPedido.Descripcion = txtDescripcionEstadoPedido.Text;

                if (Request.QueryString["IdEstadoPedido"] != null)
                {
                    nuevoEstadoPedido.IdEstadoPedido = int.Parse(txtIdEstadoPedido.Text);
                    negocioEstadoPedido.ModificarEstadoPedido(nuevoEstadoPedido);
                }else
                    negocioEstadoPedido.AgregarEstadoPedido(nuevoEstadoPedido);
                
                Response.Redirect("/ListarEstadoPedido.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btmDesactivarYActivarEstadoPedido_Click(object sender, EventArgs e)
        {
            try
            {
                EstadoPedidoNegocio negocioEstadoPedido = new EstadoPedidoNegocio();
                EstadoPedido seleccionado = (EstadoPedido)Session["EstadoPedidoSeleccionado"];
                negocioEstadoPedido.ActivarODesativarEstadoPedido(seleccionado.IdEstadoPedido, !seleccionado.Estado);
                Response.Redirect("/ListarEstadoPedido.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}