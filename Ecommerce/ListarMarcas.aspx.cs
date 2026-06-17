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
            MarcaNegocio negocioMarca = new MarcaNegocio();
            dgvListadoMarcas.DataSource = negocioMarca.listarMarca();
            dgvListadoMarcas.DataBind();
        }

        protected void dgvListadoMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvListadoMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioMarca.aspx?IdMarca=" + id);
        }
    }
}