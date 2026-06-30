using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocioEcommerce;

namespace Ecommerce
{
    public partial class ListarCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.SesionAdmin(Session["UsuarioIngresado"]))
            {
                Session.Add("Error.aspx", "Se necesita permisos de Admin");
                Response.Redirect("Error.aspx");
            }
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            dgvListadoCategorias.DataSource = negocioCategoria.listarCategorias();
            dgvListadoCategorias.DataBind();
        }

        protected void dgvListadoCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvListadoCategorias.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioCategoria.aspx?IdCategoria=" + Id);
        }

        protected void dgvListadoCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListadoCategorias.PageIndex = e.NewPageIndex;
            dgvListadoCategorias.DataBind();
        }
    }
}