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
    public partial class ListarProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.SesionVendedor(Session["UsuarioIngresado"]))
            {
                Session.Add("Error.aspx", "Se necesita permisos de vendedor");
                Response.Redirect("Error.aspx");
            }
            if (!IsPostBack)
            {
                if (!Seguridad.SesionActiva((Usuario)Session["UsuarioIngresado"]))
                    Response.Redirect("Login.aspx", false);

                Usuario usuarioIngresado = (Usuario)Session["UsuarioIngresado"];
                if (usuarioIngresado.TipoUsuario.IdTipoUsuario == 2)
                {
                    ProductoNegocio productoNegocio = new ProductoNegocio();
                    List<Producto> listaProductosDelVendedor = productoNegocio.listarProductosPorUsuario(usuarioIngresado.Id);

                    dgvListaProductos.DataSource = listaProductosDelVendedor;
                }
                else if (usuarioIngresado.TipoUsuario.IdTipoUsuario == 3)
                {
                    ProductoNegocio productoNegocio = new ProductoNegocio();
                    List<Producto> listaProductosAdmin = productoNegocio.listarProductos();
                    dgvListaProductos.DataSource = listaProductosAdmin;
                }
                else
                {
                    Response.Redirect("DefaultCliente.aspx", false);
                    //VERIFICAR SI HACE FALTA AVISAR QUE NO TIENE PERMISO
                }
                dgvListaProductos.DataBind();
            }
            
        }

        protected void dgvListaProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string idProducto = dgvListaProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioProducto.aspx?id=" + idProducto, false);
        }
    }
}