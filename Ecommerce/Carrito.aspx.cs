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
    }
}