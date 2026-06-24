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
    public partial class DetalleProducto : System.Web.UI.Page
    {
        public Producto ProductoSeleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
            try
            {
                if (Id != "")
                {
                    ProductoNegocio negocioProducto = new ProductoNegocio();
                    List<Producto> lista = negocioProducto.listarProductos(Id);
                    if(lista != null && lista.Count > 0)
                    {
                        ProductoSeleccionado = lista[0];
                    }
                    else
                    {
                        Response.Redirect("/DefaultCliente.aspx");
                    }
                    CargarCarrusel(Convert.ToInt32(Request.QueryString["id"]));
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
        private void CargarCarrusel(int idProducto)
        {
            ImagenNegocio negocioImg = new ImagenNegocio();
            List<ImagenProducto> listaImagenes = new List<ImagenProducto>();
            listaImagenes = negocioImg.listarImgProducto(idProducto);
            rptCarrusel.DataSource = listaImagenes;
            rptCarrusel.DataBind();

        }

        protected void btnAgregarProductoEnDetalleProducto_Click(object sender, EventArgs e)
        {
            if (Seguridad.SesionActiva((Usuario)Session["UsuarioIngresado"]))
            {
                Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
                    int IdProducto = ProductoSeleccionado.Id;
                    int idUsuario = UsuarioIngresado.Id;
                    CarritoNegocio negocioCarrito = new CarritoNegocio();
                    int IdCarrito = negocioCarrito.BuscarCarritoDelUsuario(idUsuario);
                    if (IdCarrito == 0)
                    {
                        IdCarrito = negocioCarrito.CrearCarritoUsuario(idUsuario);
                    }
                    negocioCarrito.AgregarProductosDetalleCarrito(IdCarrito, IdProducto, 1);
            }
            else
                Response.Redirect("Login.aspx", false);
        }

        protected void btnComprarAhora_Click(object sender, EventArgs e)
        {
            if (Seguridad.SesionActiva((Usuario)Session["UsuarioIngresado"]))
            {
                Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
                int IdProducto = ProductoSeleccionado.Id;
                int idUsuario = UsuarioIngresado.Id;
                CarritoNegocio negocioCarrito = new CarritoNegocio();
                int IdCarrito = negocioCarrito.BuscarCarritoDelUsuario(idUsuario);
                if (IdCarrito == 0)
                {
                    IdCarrito = negocioCarrito.CrearCarritoUsuario(idUsuario);
                }
                negocioCarrito.AgregarProductosDetalleCarrito(IdCarrito, IdProducto, 1);
                Response.Redirect("/Carrito.aspx");
            }
            else
                Response.Redirect("Login.aspx", false);
        }
    }
    
}