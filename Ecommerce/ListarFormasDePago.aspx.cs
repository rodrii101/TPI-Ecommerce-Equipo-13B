using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocioEcommerce;
namespace Ecommerce
{
    public partial class ListarFormasDePago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FormasDePagoNegocio PagoNegocio = new FormasDePagoNegocio();
            dgvListadoFormasDePago.DataSource = PagoNegocio.listarFormasDePagos();
            dgvListadoFormasDePago.DataBind();
        }

        protected void dgvListadoFormasDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvListadoFormasDePago.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioFormasDePago.aspx?IdFormasDePagos=" + Id);
        }
    }
}