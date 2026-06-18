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
    public partial class DefaultCliente : System.Web.UI.Page
    {
        public List<Producto> listaProducto {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            listaProducto = negocioProducto.listarProductos();
        }
    }
}