using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocioEcommerce;

namespace Ecommerce
{
    public partial class ListarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            dgvListaProductos.DataSource = negocioProducto.listarProductos();
            dgvListaProductos.DataBind();
        }

        protected void dgvListaProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvListaProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioProducto.aspx?id=" + id, false);
        }
    }
}