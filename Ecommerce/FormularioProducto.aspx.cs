using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioEcommerce;
using negocioEcommerce;

namespace Ecommerce
{
    public partial class FormularioProducto : System.Web.UI.Page
    {
        public List<ImagenProducto> listaImagenes
        {
            get
            {
                if (Session["listaImagenes"] == null)
                    Session["listaImagenes"] = new List<ImagenProducto>();

                return (List<ImagenProducto>)Session["listaImagenes"];
            }
            set
            {
                Session["listaImagenes"] = value;
            }
        }
        public bool estadoProducto { get; set; }
        public bool confirmarEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LimpiarListaSession("listaImagenes");

                    confirmarEliminacion = false;

                    txtId.Visible = false;
                    lblId.Visible = false;

                    CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                    List<Categoria> listaCategorias = negocioCategoria.listarCategorias();
                    

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataValueField = "IdCategoria";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    MarcaNegocio negocioMarca = new MarcaNegocio();
                    List<Marca> listaMarca = negocioMarca.listarMarca();
                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "IdMarca";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    //CONFIGURACION SI ESTAMOS MODIFICANDO
                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";

                    if (id != "")
                    {
                        txtId.Visible = true;
                        lblId.Visible = true;
                        txtId.Enabled = false;
                        btnAgregarProducto.Text = "Modificar";

                        ProductoNegocio negocio = new ProductoNegocio();
                        List<Producto> lista = negocio.listarProductos(id);
                        Producto seleccionado = lista[0];
                        Session.Add("estadoAux", seleccionado);
                        //Producto seleccionado = (negocio.listar(id))[0]; lo mismo a las dos lineas de arriba

                        //PRE CARGA DE LOS CAMPOS
                        txtId.Text = id;
                        txtNombre.Text = seleccionado.Nombre;
                        txtDescripcion.Text = seleccionado.Descripcion;
                        txtPrecio.Text = seleccionado.Precio.ToString();
                        ddlCategoria.SelectedValue = seleccionado.Categoria.IdCategoria.ToString();
                        txtStock.Text = seleccionado.Stock.ToString();
                        ddlMarca.SelectedValue = seleccionado.Marca.IdMarca.ToString();

                        estadoProducto = seleccionado.Estado;
                        if (estadoProducto)
                            btnDesactivar.Text = "Desactivar";
                        else
                            btnDesactivar.Text = "Activar";

                        //carrusel
                        CargarCarrusel(Convert.ToInt32(Request.QueryString["id"]));
                    }
                    else
                    {
                        //CARGO CARRUSEL Y SI ESTA VACIO NO MUESTRO BOTON ELIMINAR
                        CargarCarrusel(listaImagenes);
                        btnEliminarImg.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }

        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto productoNuevo = new Producto();

                productoNuevo.Nombre = txtNombre.Text;
                productoNuevo.Descripcion = txtDescripcion.Text;
                productoNuevo.Precio = decimal.Parse(txtPrecio.Text);
                productoNuevo.Categoria = new Categoria();
                productoNuevo.Categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
                productoNuevo.Marca = new Marca();
                productoNuevo.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);
                productoNuevo.Stock = int.Parse(txtStock.Text);



                if (Request.QueryString["id"] != null)
                {
                    ImagenNegocio imagenNegocio = new ImagenNegocio();

                    productoNegocio.modificarProducto(productoNuevo, Request.QueryString["id"].ToString());
                }
                else
                {
                    productoNegocio.agregar(productoNuevo, listaImagenes);
                }

                LimpiarListaSession("listaImagenes");
                Response.Redirect("ListarProductos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            confirmarEliminacion = true;
        }

        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                string id = Request.QueryString["id"].ToString();
                negocio.eliminarProducto(int.Parse(id));
                Response.Redirect("ListarProductos.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                bool estado = ((Producto)Session["estadoAux"]).Estado;
                int id = int.Parse(txtId.Text);
                negocio.desactivarProducto(id, estado);

                Response.Redirect("ListarProductos.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void btnGuardarImg_Click(object sender, EventArgs e)
        {
            try
            {
                ImagenProducto aux = new ImagenProducto();
                aux.ImagenURL = txtImagenUrl.Text;
                aux.EsPrincipal = listaImagenes.Count == 0; //COMPARA SI listaImagenes es true/false

                //MODIFIACION DE IMAGEN
                if(Request.QueryString["id"] != null)
                {
                    if (string.IsNullOrWhiteSpace(txtImagenUrl.Text))
                        return;

                    int idProducto = int.Parse(Request.QueryString["id"].ToString());
                    ImagenNegocio negocioImg = new ImagenNegocio();

                    negocioImg.agregarImagen(idProducto, aux.ImagenURL);
                    CargarCarrusel(idProducto);//MUESTRO CARRUSEL CON LA IMAGEN NUEVA CARGADA
                }
                //ALTA DE IMAGEN
                else
                {
                    listaImagenes.Add(aux);
                    CargarCarrusel(listaImagenes);
                }

                txtImagenUrl.Text = string.Empty; 
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }

        protected void btnEliminarImg_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
                return; // Modo nuevo: este botón no debe usarse
            
            //VERIFICO SI EL id imagen del carrusel ES VALIDO
            if (string.IsNullOrEmpty(hfImagenActualId.Value) || !int.TryParse(hfImagenActualId.Value, out int id))
                return;

            //string idFotoActual = hfImagenActualId.Value;
            EliminarImagen(id);
            int idProducto = int.Parse(Request.QueryString["id"]);
            CargarCarrusel(idProducto);
            //ActualizarHiddenFieldConPrimeraImagen();
        }

        protected void btnElegirPrincipal_Click(object sender, EventArgs e)
        {
            //VERIFICO SI EL id imagen del carrusel ES VALIDO
            if (string.IsNullOrEmpty(hfImagenActualId.Value) || !int.TryParse(hfImagenActualId.Value, out int id))
                return;

            string idProducto = Request.QueryString["id"].ToString();
            string idFotoActual = hfImagenActualId.Value;
            ActualizarImagenPrincipal(idProducto, int.Parse(idFotoActual));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarListaSession("listaImagenes");
            Response.Redirect("ListarProductos.aspx", false);
        }


        protected void rptCarrusel2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btnEliminar = e.Item.FindControl("btnEliminarItem") as Button;
                if (btnEliminar != null)
                {
                    // Obtener el objeto ImagenProducto de este item
                    ImagenProducto img = e.Item.DataItem as ImagenProducto;

                    if (Request.QueryString["id"] != null)
                    {
                        // Modo edición: usar el ID real de la base de datos
                        btnEliminar.CommandArgument = img.Id.ToString();
                    }
                    else
                    {
                        // Modo nuevo: usar el índice del item en la lista
                        btnEliminar.CommandArgument = e.Item.ItemIndex.ToString();
                    }
                }
            }
        }


        protected void rptCarrusel2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "EliminarImagen")
            {
                string argumento = e.CommandArgument.ToString();
                EliminarImagen(int.Parse(argumento));

                // Recargar el carrusel según el modo
                if (Request.QueryString["id"] != null)
                    CargarCarrusel(int.Parse(Request.QueryString["id"]));
                else
                    CargarCarrusel(listaImagenes);

            }
        }



        //FUNCIONES


        //MODIFICACION
        private void CargarCarrusel(int idProducto)
        { 
            ImagenNegocio negocioImg = new ImagenNegocio();
            List<ImagenProducto> listaImagenes = new List<ImagenProducto>();
            listaImagenes = negocioImg.listarImgProducto(idProducto);
            rptCarrusel.DataSource = listaImagenes;
            rptCarrusel.DataBind();

            if (listaImagenes.Count > 0)
            {
                
                btnEliminarImg.Enabled = true;
                btnEliminarImg.Visible = true;
                rptCarrusel.Visible = true;

            }
            else
            {
                btnEliminarImg.Enabled = false;
                btnEliminarImg.Visible = false;
                rptCarrusel.Visible = false;
            }
        }

        //ALTA
        private void CargarCarrusel(List<ImagenProducto> listaImagenes)
        {
            rptCarrusel2.DataSource = listaImagenes;
            rptCarrusel2.DataBind();
            rptCarrusel2.Visible = listaImagenes.Count > 0;
        }

        private void ActualizarImagenPrincipal(string idProducto, int idImagen)
        {
            ImagenNegocio negocioImg = new ImagenNegocio();
            negocioImg.establecerImagenPrincipal(idProducto, idImagen);
        }

        private void EliminarImagen(int idImagen)
        {
            if (Request.QueryString["id"] != null)
            {
                //MODIFICANDO BORRAMOS DIRECTAMENTE EN LA TABLA DE BASE DE DATOS
                ImagenNegocio negocioImg = new ImagenNegocio();
                negocioImg.eliminarImagen(idImagen);
            }
            else
            {
                //ALTA PRODUCTO BORRAMOS DE LA listaImagenes EN SESSION PORQUE NO EXISTE UNA TABLA IMAGENES AUN. 
                int indice = idImagen;
                if(indice >= 0 && indice < listaImagenes.Count)
                {
                    listaImagenes.RemoveAt(indice);
                }
            }
        }

        private void LimpiarListaSession(string nombreLista)
        {
            if (Session[nombreLista] != null) 
                Session.Remove(nombreLista);
        }

        protected void rptCarrusel_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "EstablecerPrincipal")
            {
                // Validar que el argumento sea un número
                if (e.CommandArgument != null && int.TryParse(e.CommandArgument.ToString(), out int idImagen))
                {
                    string idProducto = Request.QueryString["id"];
                    if (!string.IsNullOrEmpty(idProducto))
                    {
                        // Establecer la imagen como principal
                        ActualizarImagenPrincipal(idProducto, idImagen);
                        // Recargar el carrusel para reflejar el cambio (aunque no haya cambio visual, 
                        // es buena práctica actualizar la interfaz)
                        CargarCarrusel(int.Parse(idProducto));
                    }
                }
            }
        }
    }
}


