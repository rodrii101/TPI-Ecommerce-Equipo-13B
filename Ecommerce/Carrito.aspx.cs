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
    public partial class Carrito : System.Web.UI.Page
    {
        public List<CarritoDetalle> listaCarritoDetalle { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
            CarritoNegocio negocioCarrito = new CarritoNegocio();
            listaCarritoDetalle = (negocioCarrito.listarDetalleCarritoUsuario(UsuarioIngresado.Id));

            repRepetidorDetalleCarrito.DataSource = listaCarritoDetalle;
            repRepetidorDetalleCarrito.DataBind();
        }
    }
}