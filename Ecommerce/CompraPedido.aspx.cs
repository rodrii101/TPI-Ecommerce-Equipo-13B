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
    public partial class CompraPedido : System.Web.UI.Page
    {
        public List<CarritoDetalle> listaCarritoDetalle { get; set; }

        //public decimal total { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
            if (UsuarioIngresado != null)
            {
                lblNombreUsuario.Text = UsuarioIngresado.Nombre;
                lblEmailUsuario.Text =UsuarioIngresado.Email;
                lblDniUsuario.Text = UsuarioIngresado.DNI;
                lblTelefonoUsuario.Text = UsuarioIngresado.Telefono;
                CarritoNegocio negocioCarrito = new CarritoNegocio();
                listaCarritoDetalle = negocioCarrito.listarDetalleCarritoUsuario(UsuarioIngresado.Id);
                repRepetidorProductos.DataSource = listaCarritoDetalle;
                repRepetidorProductos.DataBind();
                int cantidadProductos = 0;
                foreach (CarritoDetalle detalleProducto in listaCarritoDetalle)
                {
                    cantidadProductos += detalleProducto.Cantidad;
                }
                lblCantidadProductos.Text = cantidadProductos.ToString();
                decimal subTotal = 0;
                decimal total = 0;
                foreach (CarritoDetalle detalleProducto in listaCarritoDetalle)
                {
                    subTotal = detalleProducto.Cantidad * detalleProducto.Producto.Precio;
                    total += subTotal;
                }
                lblTotalAPagar.Text = "$ " + total.ToString("0.00");
            }
            else
                Response.Redirect("Login.aspx", false);

        }
        public string ObtenerImagenPrincipal(CarritoDetalle carritoDetalle)
        {
            if (carritoDetalle.Producto.Imagenes_URL != null && carritoDetalle.Producto.Imagenes_URL.Count > 0)
            {
                //BUSCO IMG PRINCIPAL
                ImagenProducto imgPrincipal = carritoDetalle.Producto.Imagenes_URL.FirstOrDefault(i => i.EsPrincipal);//ESTO DVUELVE OBJ img principal
                if (imgPrincipal != null)                               //i=>i.EsPrincipal --> busca el principal itemXitem en la lista
                    return imgPrincipal.ImagenURL;
                else
                    //SI NO HAY imgPrincipal TOMO LA PRIMER IMAGEN
                    return carritoDetalle.Producto.Imagenes_URL.First().ImagenURL;
            }
            else
            {
                return "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png";
            }
        }
        protected void btnFinalizarCompraPedido_Click(object sender, EventArgs e)
        {
        }
    }
}