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

        private void ValidarEstadoFormulario()
        {
            bool datosPersonalesCompletos = !txtNombre.Enabled && !txtApellido.Enabled && !txtDNI.Enabled && !txtTelefono.Enabled;//PARA QUE SEPA CUANDO ESTN COMPLETOS LOS CAMPOS

            bool formaEntregaValida = false;
            string formaDeEntrega = rblFormaDeEntrega.SelectedValue;

            if (formaDeEntrega == "LOCAL")
            {
                formaEntregaValida = true;
            }
            else if (formaDeEntrega == "DOMICILIO")
            {
                //BUSCO QUE SE HAYA SELECCIONADO UNA DIRECCION PARA ENTREGAR
                string idDomicilioSeleccionado = Request.Form["grupoDomicilio"];
                formaEntregaValida = !string.IsNullOrEmpty(idDomicilioSeleccionado);
            }

            //VALIDAMOS QUE HAYA UNA FORMA DE PAGO SELECCIONADA
            string idPagoSeleccionado = Request.Form["grupoPagos"];
            bool formaPagoValida = !string.IsNullOrEmpty(idPagoSeleccionado);

            btnFinalizarCompraPedido.Enabled = datosPersonalesCompletos && formaEntregaValida && formaPagoValida;//SOLO HABILITA CUANDO TODO ESTE COMPLETO
        }

        public void cargarPedido()
        {
            Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
            if (UsuarioIngresado != null)
            {
                bool tieneDatosIncompletos = false;

                if (UsuarioIngresado.Nombre == null || UsuarioIngresado.Nombre == "")
                {
                    txtNombre.Enabled = true;
                    tieneDatosIncompletos = true;
                }
                else
                {
                    txtNombre.Text = UsuarioIngresado.Nombre;
                }

                if (UsuarioIngresado.Apellido == null || UsuarioIngresado.Apellido == "")
                {
                    txtApellido.Enabled = true;
                    tieneDatosIncompletos = true;
                }
                else
                {
                    txtApellido.Text = UsuarioIngresado.Apellido;
                }

                if (UsuarioIngresado.DNI == null || UsuarioIngresado.DNI == "")
                {
                    txtDNI.Enabled = true;
                    tieneDatosIncompletos = true;
                }
                else
                {
                    txtDNI.Text = UsuarioIngresado.DNI;
                }

                if (UsuarioIngresado.Telefono == null || UsuarioIngresado.Telefono == "")
                {
                    txtTelefono.Enabled = true;
                    tieneDatosIncompletos = true;
                }
                else
                {
                    txtTelefono.Text = UsuarioIngresado.Telefono;
                }

                // Controlamos la visibilidad inicial de los botones según el estado de los datos
                if (tieneDatosIncompletos)
                {
                    btnGuardar.Visible = true;
                    btnGuardar.Enabled = true;
                    btnModificar.Visible = false;
                }
                else
                {
                    btnGuardar.Visible = false;
                    btnModificar.Visible = true;
                }

                txtEmail.Text = UsuarioIngresado.Email;




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

                ValidarEstadoFormulario(); //PARA HABILITAR EL BOTON FINALIZAR COMPRA
            }
            else
                Response.Redirect("Login.aspx", false);
        }


        public void CargarConfirmacinPedido()
        {

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
            if (rblFormaDeEntrega.SelectedValue == "DOMICILIO")
            {
                PanelConDireccionUsuario.Visible = true;
                PanelRetiroAlLocal.Visible = false;
            }
            else if (rblFormaDeEntrega.SelectedValue == "LOCAL")
            {
                PanelConDireccionUsuario.Visible = false;
                PanelRetiroAlLocal.Visible = true;
            }

            ValidarEstadoFormulario(); //VALIDA QUE ESTE COMPLETO
        }
        protected void btnFinalizarCompraPedido_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuarioIngresado = (Usuario)Session["UsuarioIngresado"];

                ConfirmarPedido confirmarPedido = new ConfirmarPedido();
                confirmarPedido.Cliente = usuarioIngresado;


                string formaDeEntrega = rblFormaDeEntrega.SelectedValue;
                if (formaDeEntrega == "LOCAL")
                {
                    FormasDeEntregaNegocio entregaNegocio = new FormasDeEntregaNegocio();
                    List<FormasDeEntrega> listaFormaDeEntrega = entregaNegocio.listarFormasDeEntrega();
                    FormasDeEntrega entrega = listaFormaDeEntrega.FirstOrDefault(lfde => lfde.Descripcion == "LOCAL");

                    confirmarPedido.FormaEntrega = entrega;

                    divConfDomicilio.Visible = false;
                    divConfRetiro.Visible = true;
                    lblRetiro.Text = confirmarPedido.FormaEntrega.Direccion;
                }
                else if (formaDeEntrega == "DOMICILIO")
                {
                    FormasDeEntregaNegocio entregaNegocio = new FormasDeEntregaNegocio();
                    List<FormasDeEntrega> listaFormaDeEntrega = entregaNegocio.listarFormasDeEntrega();
                    FormasDeEntrega entrega = listaFormaDeEntrega.FirstOrDefault(lfde => lfde.Descripcion == "DOMICILIO");

                    confirmarPedido.FormaEntrega = entrega;
                    string idDomicilioSeleccionado = Request.Form["grupoDomicilio"];
                    int idDireccion = int.Parse(idDomicilioSeleccionado);

                    DireccionNegocio direccionNegocio = new DireccionNegocio();
                    confirmarPedido.DireccionEntrega = direccionNegocio.BuscarDireccion(idDireccion);


                    divConfRetiro.Visible = false;
                    divConfDomicilio.Visible = true;
                    lblConfCalle.Text = confirmarPedido.DireccionEntrega.Calle;
                    lblConfAltura.Text = confirmarPedido.DireccionEntrega.Altura.ToString();
                    lblConfPiso.Text = confirmarPedido.DireccionEntrega.Piso.ToString();
                    lblConfDepto.Text = confirmarPedido.DireccionEntrega.Departamento;
                    lblConfLocalidad.Text = confirmarPedido.DireccionEntrega.Localidad;
                    lblConfCodPostal.Text = confirmarPedido.DireccionEntrega.CodigoPostal;
                    lblConfObservaciones.Text = confirmarPedido.DireccionEntrega.Observacion;
                }


                string idPagoSeleccionado = Request.Form["grupoPagos"];
                FormasDePagoNegocio pagosNegocio = new FormasDePagoNegocio();
                List<FormasDePagos> listaFormaDePago = pagosNegocio.listarFormasDePagos(idPagoSeleccionado);
                confirmarPedido.FormaDePago = listaFormaDePago[0];


                CarritoNegocio negocioCarrito = new CarritoNegocio();
                listaCarritoDetalle = negocioCarrito.listarDetalleCarritoUsuario(usuarioIngresado.Id);
                rptConfirmarPedido.DataSource = listaCarritoDetalle;
                rptConfirmarPedido.DataBind();
                int cantidadProductos = 0;
                foreach (CarritoDetalle detalleProducto in listaCarritoDetalle)
                {
                    cantidadProductos += detalleProducto.Cantidad;
                }
                lblConfCantidadProductos.Text = cantidadProductos.ToString();
                decimal subTotal = 0;
                decimal total = 0;
                foreach (CarritoDetalle detalleProducto in listaCarritoDetalle)
                {
                    subTotal = detalleProducto.Cantidad * detalleProducto.Producto.Precio;
                    total += subTotal;
                }
                lblConfTotalAPagar.Text = "$ " + total.ToString("0.00");
                confirmarPedido.ListaDetalleCarrito = listaCarritoDetalle;
                //DATOS PERSONALES
                lblConfNombre.Text = confirmarPedido.Cliente.Nombre + " " + confirmarPedido.Cliente.Apellido;
                lblConfEmail.Text = confirmarPedido.Cliente.Email;
                lblConfDni.Text = confirmarPedido.Cliente.DNI;
                lblConfTelefono.Text = confirmarPedido.Cliente.Telefono;

                //FORMA DE PAGO
                lblConfPago.Text = confirmarPedido.FormaDePago.Descripcion;
                confirmarPedido.MontoTotal = total;
                panelCargaDatos.Visible = false;
                panelConfirmarPedido.Visible = true;
                Session.Add("PedidoConfirmado", confirmarPedido);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                throw ex;
            }
        }

        protected void NuevaDireccionPedido_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate("NuevaDireccion");
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

        //CONFIRMACIN DE PEDIDO

        protected void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            if (Session["PedidoConfirmado"] == null)
                Response.Redirect("/Carrito.aspx");
            try
            {
                ConfirmarPedido confirmarPedido = (ConfirmarPedido)Session["PedidoConfirmado"];
                Pedido nuevoPedido = new Pedido();
                nuevoPedido.PedidoConfirmado = new ConfirmarPedido();
                nuevoPedido.PedidoConfirmado.Cliente = new Usuario();
                nuevoPedido.PedidoConfirmado.DireccionEntrega = new DireccionUsuario();
                nuevoPedido.PedidoConfirmado.FormaDePago = new FormasDePagos();
                nuevoPedido.PedidoConfirmado.FormaEntrega = new FormasDeEntrega();

                nuevoPedido.IdCliente = confirmarPedido.Cliente.Id;
                nuevoPedido.PedidoConfirmado.Cliente.Nombre = confirmarPedido.Cliente.Nombre;
                nuevoPedido.PedidoConfirmado.Cliente.Apellido = confirmarPedido.Cliente.Apellido;
                nuevoPedido.PedidoConfirmado.Cliente.Telefono = confirmarPedido.Cliente.Telefono;
                nuevoPedido.PedidoConfirmado.Cliente.DNI = confirmarPedido.Cliente.DNI;

                nuevoPedido.PedidoConfirmado.FormaDePago.Descripcion = confirmarPedido.FormaDePago.Descripcion;
                nuevoPedido.PedidoConfirmado.FormaEntrega.Descripcion = confirmarPedido.FormaEntrega.Descripcion;
                if (confirmarPedido.FormaEntrega.Descripcion == "DOMICILIO")
                {
                    nuevoPedido.PedidoConfirmado.FormaEntrega.Descripcion = "Domicilio";
                    nuevoPedido.PedidoConfirmado.DireccionEntrega.Calle = confirmarPedido.DireccionEntrega.Calle;
                    nuevoPedido.PedidoConfirmado.DireccionEntrega.Altura = confirmarPedido.DireccionEntrega.Altura;
                    nuevoPedido.PedidoConfirmado.DireccionEntrega.Piso = confirmarPedido.DireccionEntrega.Piso;
                    nuevoPedido.PedidoConfirmado.DireccionEntrega.Departamento = confirmarPedido.DireccionEntrega.Departamento;
                    nuevoPedido.PedidoConfirmado.DireccionEntrega.Localidad = confirmarPedido.DireccionEntrega.Localidad;
                    nuevoPedido.PedidoConfirmado.DireccionEntrega.CodigoPostal = confirmarPedido.DireccionEntrega.CodigoPostal;
                }
                else
                    nuevoPedido.PedidoConfirmado.FormaEntrega.Descripcion = "Local";

                nuevoPedido.PedidoConfirmado.MontoTotal = confirmarPedido.MontoTotal;
                PedidoNegocio negocioPedido = new PedidoNegocio();
                CarritoNegocio negocioCarrito =  new CarritoNegocio();
                List<PedidoDetalle> listaPedidoDetalle = new List<PedidoDetalle>();
                foreach (var listaCarrito in confirmarPedido.ListaDetalleCarrito)
                {
                    PedidoDetalle detallePedidos = new PedidoDetalle();
                    detallePedidos.Producto = new Producto();
                    detallePedidos.IdProducto = listaCarrito.IdProducto;
                    detallePedidos.Producto.Nombre = listaCarrito.Producto.Nombre;
                    detallePedidos.Cantidad = listaCarrito.Cantidad;
                    detallePedidos.PrecioUnitario = listaCarrito.Producto.Precio;
                    detallePedidos.Producto.IdVendedor = listaCarrito.Producto.IdVendedor;
                    detallePedidos.NombreDelVendedor = listaCarrito.Usuario.Nombre;
                    listaPedidoDetalle.Add(detallePedidos);
                    negocioPedido.DisminuirStockPorCompra(listaCarrito.IdProducto, listaCarrito.Cantidad);
                }
                negocioPedido.CrearPedido(nuevoPedido, listaPedidoDetalle);
                int IdCarritoDelUsuario = confirmarPedido.ListaDetalleCarrito[0].IdCarrito;
                negocioCarrito.VaciarDetalleCarrito(IdCarritoDelUsuario);
                Session["PedidoConfirmado"] = null;
                Response.Redirect("/DefaultCliente.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }
        protected void btnAtras_Click(object sender, EventArgs e)
        {
            cargarPedido();
            panelConfirmarPedido.Visible = false;
            panelCargaDatos.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate("DatosPersonales");
            if (!Page.IsValid)
                return;

            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            Usuario usuarioEditado = (Usuario)Session["UsuarioIngresado"];

            usuarioEditado.Nombre = txtNombre.Text;
            usuarioEditado.Apellido = txtApellido.Text;
            usuarioEditado.DNI = txtDNI.Text;
            usuarioEditado.Telefono = txtTelefono.Text;

            negocioUsuario.EditarPerfil(usuarioEditado);

            //BLOQUEO LOS TXT
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDNI.Enabled = false;
            txtTelefono.Enabled = false;

            //OCULTO GUARDAR PARA MOSTRAR MODIFICAR
            btnGuardar.Visible = false;
            btnGuardar.Enabled = false;

            btnModificar.Visible = true;

            ValidarEstadoFormulario();//VERIFICO QUE TODO ESTE COMPLETO
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            //HABILITAMS LOS TXT
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtDNI.Enabled = true;
            txtTelefono.Enabled = true;

            // MUESTRO GUARDAR
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;

            btnModificar.Visible = false;

            ValidarEstadoFormulario();
        }


    }

}