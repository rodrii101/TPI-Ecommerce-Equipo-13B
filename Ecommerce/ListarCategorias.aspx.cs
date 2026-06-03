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
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            dgvListadoCategorias.DataSource = negocioCategoria.listarCategorias();
            dgvListadoCategorias.DataBind();
        }

        protected void dgvListadoCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}