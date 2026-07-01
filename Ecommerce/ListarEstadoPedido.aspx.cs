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
    public partial class ListarEstadoPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.SesionAdmin(Session["UsuarioIngresado"]))
            {
                Session.Add("Error", "Se necesita permisos de Admin");
                Response.Redirect("Error.aspx");
            }
            if (!IsPostBack)
                cargarEstadoPedido();
        }
        private void cargarEstadoPedido()
        {
            EstadoPedidoNegocio negocioEstadoPedido = new EstadoPedidoNegocio();
            List<EstadoPedido> listadoEstadoPedido = negocioEstadoPedido.listarEstadoPedido();
            Session.Add("listadoEstadoPedido", listadoEstadoPedido);
            EncontreEstadoPedido(listadoEstadoPedido);
            dgvListadoEstadoPedido.DataSource = Session["listadoEstadoPedido"];
            dgvListadoEstadoPedido.DataBind();
        }
        private void EncontreEstadoPedido(List<EstadoPedido> lista)
        {
            EstadoPedidoNegocio negocioEstadoPedido = new EstadoPedidoNegocio();
            bool encontreEstadoPedido = (lista != null && lista.Count > 0);
            PanelConMarca.Visible = encontreEstadoPedido;
            PanelSinMarca.Visible = !encontreEstadoPedido;
        }
        protected void dgvListadoEstadoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvListadoEstadoPedido.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioEstadoPedido.aspx?IdEstadoPedido=" + Id);
        }



        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                txtFiltroRapidoEstadoPedido.Text = "";
                txtFiltroAvanzado.Text = "";
                ddlCriterioEstadoPedido.SelectedIndex = 0;
                ddlEstadoEstadoPedido.Items.Clear();
                cargarEstadoPedido();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnBuscarFiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                EstadoPedidoNegocio negocioEstadoPedido = new EstadoPedidoNegocio();
                List<EstadoPedido> listaFiltradaAvanzada = negocioEstadoPedido.filtradoAvanzadoEstadoPedido(txtCampoEstadoPedido.Text,
                ddlCriterioEstadoPedido.SelectedItem.ToString(), txtFiltroAvanzado.Text, ddlEstadoEstadoPedido.SelectedItem.ToString());
                EncontreEstadoPedido(listaFiltradaAvanzada);
                dgvListadoEstadoPedido.DataSource = listaFiltradaAvanzada;
                dgvListadoEstadoPedido.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void chkFiltroAvanzadoEstadoPedido_CheckedChanged(object sender, EventArgs e)
        {
            bool activadoFiltroAvanzado = chkFiltroAvanzadoEstadoPedido.Checked;
            PanelFiltroAvanzado.Visible = activadoFiltroAvanzado;
            txtFiltroRapidoEstadoPedido.Enabled = !activadoFiltroAvanzado;
            ddlCriterioEstadoPedido.Items.Clear();
            txtCampoEstadoPedido.Enabled = false;
            if (txtCampoEstadoPedido.Text == "Descripcion")
            {
                ddlCriterioEstadoPedido.Items.Add("Comienza con");
                ddlCriterioEstadoPedido.Items.Add("Contiene");
                ddlCriterioEstadoPedido.Items.Add("Termina con");
            }
            else
            {
                ddlCriterioEstadoPedido.Items.Add("Algo falla");
            }
        }

        protected void txtFiltroRapidoEstadoPedido_TextChanged(object sender, EventArgs e)
        {
            List<EstadoPedido> listaMarca = (List<EstadoPedido>)Session["listadoEstadoPedido"];
            List<EstadoPedido> listaFiltrada = listaMarca.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltroRapidoEstadoPedido.Text.ToUpper()));
            EncontreEstadoPedido(listaFiltrada);
            dgvListadoEstadoPedido.DataSource = listaFiltrada;
            dgvListadoEstadoPedido.DataBind();
        }

        protected void dgvListadoEstadoPedido_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListadoEstadoPedido.PageIndex = e.NewPageIndex;
            cargarEstadoPedido();
            dgvListadoEstadoPedido.DataBind();
        }
    }
}