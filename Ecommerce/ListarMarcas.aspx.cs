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
    public partial class ListarMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.SesionAdmin(Session["UsuarioIngresado"]))
            {
                Session.Add("Error.aspx", "Se necesita permisos de Admin");
                Response.Redirect("Error.aspx");
            }
            if (!IsPostBack)
                cargarListadoMarcas();
        }
        private void cargarListadoMarcas()
        {
            MarcaNegocio negocioMarca = new MarcaNegocio();
            List<Marca> listadoMarca = negocioMarca.listarMarca();
            Session.Add("ListadoMarca", listadoMarca);

 
            bool encontreMarca = (listadoMarca != null && listadoMarca.Count > 0);
            PanelConMarca.Visible = encontreMarca;
            PanelSinMarca.Visible = !encontreMarca;

            dgvListadoMarcas.DataSource = Session["ListadoMarca"];
            dgvListadoMarcas.DataBind();
        }
        protected void dgvListadoMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvListadoMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioMarca.aspx?IdMarca=" + id);
        }

        protected void txtFiltroRapidoMarca_TextChanged(object sender, EventArgs e)
        {
            List<Marca> listaMarca = (List<Marca>)Session["ListadoMarca"];
            List<Marca> listaFiltrada = listaMarca.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltroRapidoMarca.Text.ToUpper()));
            bool encontreMarca = (listaFiltrada != null && listaFiltrada.Count > 0);
            PanelConMarca.Visible = encontreMarca;
            PanelSinMarca.Visible = !encontreMarca;
            dgvListadoMarcas.DataSource = listaFiltrada;
            dgvListadoMarcas.DataBind();
        }

        protected void chkFiltroAvanzadoMarca_CheckedChanged(object sender, EventArgs e)
        {
            bool activadoFiltroAvanzado = chkFiltroAvanzadoMarca.Checked;
            PanelFiltroAvanzado.Visible = activadoFiltroAvanzado;
            txtFiltroRapidoMarca.Enabled = !activadoFiltroAvanzado;
            ddlCriterioMarca.Items.Clear();
            txtCampoMarca.Enabled = false;
            if (txtCampoMarca.Text == "Descripcion")
            {
                ddlCriterioMarca.Items.Add("Comienza con");
                ddlCriterioMarca.Items.Add("Contiene");
                ddlCriterioMarca.Items.Add("Termina con");
            }
            else
            {
                ddlCriterioMarca.Items.Add("hola");
            }
        }
        protected void btnBuscarFiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
               
                MarcaNegocio negocioMarca = new MarcaNegocio();
                List<Marca> listaFiltradaAvanzada = negocioMarca.filtradoAvanzadoMarca(txtCampoMarca.Text,
                    ddlCriterioMarca.SelectedItem.ToString(), txtFiltroAvanzado.Text, ddlEstadoMarca.SelectedItem.ToString());
                bool encontreMarca = (listaFiltradaAvanzada != null && listaFiltradaAvanzada.Count > 0);
                PanelConMarca.Visible = encontreMarca;
                PanelSinMarca.Visible = !encontreMarca;
                dgvListadoMarcas.DataSource = listaFiltradaAvanzada;
                dgvListadoMarcas.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                txtFiltroRapidoMarca.Text = "";
                txtFiltroAvanzado.Text = "";
                ddlEstadoMarca.SelectedIndex = 0;
                ddlCriterioMarca.Items.Clear();
                cargarListadoMarcas();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void dgvListadoMarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListadoMarcas.PageIndex = e.NewPageIndex;
            cargarListadoMarcas();
            dgvListadoMarcas.DataBind();
        }
    }
}