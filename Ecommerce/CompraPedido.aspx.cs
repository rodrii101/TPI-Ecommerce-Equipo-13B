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
        public List<DireccionUsuario> listaDirecciones { get; set; }

        public List<FormasDePagos> listaFormaDePago { get; set; }

        //public decimal total { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarPedido();
            }
        }
        public void cargarPedido()
        {
            Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
            if (UsuarioIngresado != null)
            {
                lblNombreUsuario.Text = UsuarioIngresado.Nombre;
                lblEmailUsuario.Text = UsuarioIngresado.Email;
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
                
                listarDireccionesUsuario();
                listarFormasDePago();
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
        private void listarDireccionesUsuario()
        {
            Usuario usuarioIngresado = (Usuario)Session["UsuarioIngresado"];
            if (usuarioIngresado != null)
            {
                DireccionNegocio negocioDireccion = new DireccionNegocio();
                listaDirecciones = negocioDireccion.listarDomiciliosUsuario(usuarioIngresado.Id);

                repRepetidorDomicilios.DataSource = listaDirecciones;
                repRepetidorDomicilios.DataBind();
            }
        }
        private void listarFormasDePago()
        {
            Usuario usuarioIngresado = (Usuario)Session["UsuarioIngresado"];
            if (usuarioIngresado != null)
            {
                FormasDePagoNegocio negocioPago = new FormasDePagoNegocio();
                listaFormaDePago = negocioPago.listarFormasDePagos();
                repRepitidorFormaDePago.DataSource = listaFormaDePago;
                repRepitidorFormaDePago.DataBind();
            }
        }
        protected void rblFormaDeEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblFormaDeEntrega.SelectedValue == "Domicilio")
            {
                PanelConDireccionUsuario.Visible = true;
                PanelRetiroAlLocal.Visible = false;
            }
            else if (rblFormaDeEntrega.SelectedValue == "Retiro")
            {
                PanelConDireccionUsuario.Visible = false;
                PanelRetiroAlLocal.Visible = true;
            }
        }
        protected void btnFinalizarCompraPedido_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPedido();
                //De momento guarda IdUsuario, FormaDeEntrega, IdDireccion, IdPFormaDePago y idEstadoPedido por default 1 o le mandamos en la base de datos default 1?
                //En caso que guarde por Retiro permitir null o le mando un IdDireccionPropio?
                Usuario usuarioIngressado = (Usuario)Session["UsuarioIngresado"];
                Pedido nuevoPedido = new Pedido();
                string formaDeEntrega = rblFormaDeEntrega.SelectedValue;
                nuevoPedido.IdCliente = usuarioIngressado.Id;
                nuevoPedido.FormaDeEntregaPedido = formaDeEntrega;
                string IdDomicilioSeleccionado = Request.Form["grupoDomicilio"];
                nuevoPedido.IdDireccionDelPedidoUsuario = int.Parse(IdDomicilioSeleccionado);
                string IdPagoSeleccionado = Request.Form["grupoPagos"];
                nuevoPedido.IdFormaDePago = int.Parse(IdPagoSeleccionado);
                nuevoPedido.IdEstadoPedido = 1;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void NuevaDireccionPedido_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
                if (UsuarioIngresado != null)
                {
                    DireccionUsuario nuevaDireccion = new DireccionUsuario();
                    DireccionNegocio negocioDireccion = new DireccionNegocio();
                    nuevaDireccion.Calle = txtCallePedido.Text;
                    nuevaDireccion.Altura = int.Parse(txtAlturaPedido.Text);
                    nuevaDireccion.Piso = txtPisoPedido.Text;
                    nuevaDireccion.Departamento = txtDepartamentoPedido.Text;
                    nuevaDireccion.Localidad = txtLocalidadPedido.Text;
                    nuevaDireccion.CodigoPostal = txtCodPostalPedido.Text;
                    nuevaDireccion.Observacion = txtObservacionesPedido.Text;
                    negocioDireccion.AgregarDireccion(UsuarioIngresado.Id, nuevaDireccion);
                    LimpiarTextBoxDireccion();
                    cargarPedido();
                }
                else
                {
                    Response.Redirect("/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
        private void LimpiarTextBoxDireccion()
        {
            txtCallePedido.Text = "";
            txtAlturaPedido.Text = "";
            txtPisoPedido.Text = "";
            txtDepartamentoPedido.Text = "";
            txtLocalidadPedido.Text = "";
            txtCodPostalPedido.Text = "";
            txtObservacionesPedido.Text = "";
        }
    }

}