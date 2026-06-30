using dominioEcommerce;
using negocioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            if (!IsPostBack)
                CargarCarrito();
        }

        private void CargarCarrito()
        {
            Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
            if (Seguridad.SesionActiva(Session["UsuarioIngresado"]))
            {
                CarritoNegocio negocioCarrito = new CarritoNegocio();
                listaCarritoDetalle = negocioCarrito.listarDetalleCarritoUsuario(UsuarioIngresado.Id);
                
                repRepetidorDetalleCarrito.DataSource = listaCarritoDetalle;
                repRepetidorDetalleCarrito.DataBind();

                bool hayProductos = (listaCarritoDetalle != null && listaCarritoDetalle.Count > 0);
                panelConProductos.Visible = hayProductos;
                panelSinProductos.Visible = !hayProductos;

                int cantidadProductos = 0;
                foreach (CarritoDetalle detalleProducto in listaCarritoDetalle)
                {
                    cantidadProductos += detalleProducto.Cantidad;
                }
                lblCantidadProductos.Text = cantidadProductos.ToString();

                decimal subTotal=0;
                decimal total=0;
                foreach (CarritoDetalle detalleProducto in listaCarritoDetalle)
                {
                    subTotal = detalleProducto.Cantidad * detalleProducto.Producto.Precio;
                    total += subTotal;
                }
                lblTotalAPagar.Text = "$ " + total.ToString("0.00");
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
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

        protected void repRepetidorDetalleCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Usuario usuarioIngresado = (Usuario)Session["UsuarioIngresado"];
            
            if(e.CommandName == "Eliminar")
            { 
                int idProducto = Convert.ToInt32(e.CommandArgument);

                CarritoNegocio carritoNegocio = new CarritoNegocio();
                int idCarrito = carritoNegocio.BuscarCarritoDelUsuario(usuarioIngresado.Id);

                carritoNegocio.EliminarProductoDetalleCarrito(idCarrito, idProducto);
                CargarCarrito();
            }

            if(e.CommandName == "Sumar")
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);
                ProductoNegocio negocioProducto = new ProductoNegocio();
                List<Producto> listaProducto = negocioProducto.listarProductos(idProducto.ToString());
                Producto producto = listaProducto[0];
                int stock = producto.Stock; //STOCK TOTAL DEL PRODUCTO
                
                //BUSCO LA CANTIDAD PEDIDA EN EL DETALLE
                CarritoNegocio carritoNegocio = new CarritoNegocio();
                int idCarrito = carritoNegocio.BuscarCarritoDelUsuario(usuarioIngresado.Id);

                List<CarritoDetalle> listaDetalleCarrito = carritoNegocio.listarDetalleCarritoUsuario(usuarioIngresado.Id);

                CarritoDetalle carritoDetalle = listaDetalleCarrito.FirstOrDefault(ldc => ldc.IdProducto == idProducto);
                int idCarritoDetalle = carritoDetalle.IdCarritoDetalle;

                int cantidadPedida = carritoDetalle.Cantidad + 1; //CANTIDAD DE PRODUCTO QUE USUARIO ESTA PIDIENDO
                
                if(cantidadPedida <= stock)
                {
                    carritoNegocio.modificarCantidad(idCarritoDetalle, cantidadPedida);
                    CargarCarrito();
                }
                else
                {
                    // ALERTA CON JavaScript
                    CargarCarrito();
                    ClientScript.RegisterStartupScript(this.GetType(), "StockAlert", "alert('Stock insuficiente');", true);
                }
            }


            if(e.CommandName == "Restar")
            {
                int idProducto = Convert.ToInt32(e.CommandArgument);
                ProductoNegocio negocioProducto = new ProductoNegocio();
                List<Producto> listaProducto = negocioProducto.listarProductos(idProducto.ToString());
                Producto producto = listaProducto[0];
                int stock = producto.Stock; //STOCK TOTAL DEL PRODUCTO

                // BUSCO LA CANTIDAD PEDIDA EN EL DETALLE
                CarritoNegocio carritoNegocio = new CarritoNegocio();
                int idCarrito = carritoNegocio.BuscarCarritoDelUsuario(usuarioIngresado.Id);

                List<CarritoDetalle> listaDetalleCarrito = carritoNegocio.listarDetalleCarritoUsuario(usuarioIngresado.Id);

                CarritoDetalle carritoDetalle = listaDetalleCarrito.FirstOrDefault(ldc => ldc.IdProducto == idProducto);
                int idCarritoDetalle = carritoDetalle.IdCarritoDetalle;

                int cantidadPedida = carritoDetalle.Cantidad - 1; //CANTIDAD DE PRODUCTO QUE USUARIO ESTA PIDIENDO

                if(cantidadPedida >= 1)
                {
                    carritoNegocio.modificarCantidad(idCarritoDetalle, cantidadPedida);
                    CargarCarrito();
                }
            }
        }

        protected void btnContinuarComprando_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultCliente.aspx", false);
            CargarCarrito();
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            //VERIFICO QUE EN LA LISTA NO HAYA NINGUN detalleCarrito NO HAYA NINGUN DETALLE CON PROBLEMAS DE STOCK
            CarritoNegocio negociCarrito = new CarritoNegocio();
            List<CarritoDetalle> listaCarritoDetalle = negociCarrito.listarDetalleCarritoUsuario(((Usuario)Session["UsuarioIngresado"]).Id);

            foreach(CarritoDetalle detalleCarrito in listaCarritoDetalle)
            {
                if(detalleCarrito.HayEsaCantidad == false || detalleCarrito.HayStock == false)
                {
                    CargarCarrito();
                    return;
                }
            }

            Response.Redirect("CompraPedido.aspx", false);
        }
    }
}