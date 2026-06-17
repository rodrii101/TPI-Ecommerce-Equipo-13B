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
                    confirmarEliminacion = false;

                    txtId.Visible = false;
                    lblId.Visible = false;

                    CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                    List<Categoria> listaCategorias = negocioCategoria.listarCategorias();
                    

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataValueField = "IdCategoria";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

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

                        estadoProducto = seleccionado.Estado;
                        if (estadoProducto)
                            btnDesactivar.Text = "Desactivar";
                        else
                            btnDesactivar.Text = "Activar";

                        //campos de imagen
                        CargarCarrusel(Convert.ToInt32(Request.QueryString["id"]));

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
                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto productoNuevo = new Producto();

                productoNuevo.Nombre = txtNombre.Text;
                productoNuevo.Descripcion = txtDescripcion.Text;
                productoNuevo.Precio = decimal.Parse(txtPrecio.Text);
                productoNuevo.Categoria = new Categoria();
                productoNuevo.Categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);
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

                Response.Redirect("ListarProductos.aspx");
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
                    int idProducto = int.Parse(Request.QueryString["id"].ToString());
                    ImagenNegocio negocioImg = new ImagenNegocio();

                    negocioImg.agregarImagen(idProducto, aux.ImagenURL);
                    CargarCarrusel(idProducto);//MUESTRO CARRUSEL CON LA IMAGEN NUEVA CARGADA
                }
                //ALTA DE IMAGEN
                else
                {
                    listaImagenes.Add(aux);
                    rptCarrusel.DataSource = listaImagenes;
                    rptCarrusel.DataBind();
                }

                txtImagenUrl.Text = string.Empty; 
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw ex;
            }
        }


        //FUNCIONES
        private void CargarCarrusel(int idProducto)
        {
            ImagenNegocio negocioImg = new ImagenNegocio();
            
            rptCarrusel.DataSource = negocioImg.listarImgProducto(idProducto);
            rptCarrusel.DataBind();
        }



        private void ActualizarImagenPrincipal(string idProducto, int idImagen)
        {
            ImagenNegocio negocioImg = new ImagenNegocio();
            negocioImg.establecerImagenPrincipal(idProducto, idImagen);
        }

        private void EliminarImagen(int idImagen)
        {
            ImagenNegocio negocioImg = new ImagenNegocio();
            negocioImg.eliminarImagen(idImagen);
        }

        protected void btnEliminarImg_Click(object sender, EventArgs e)
        {
            string idFotoActual = hfImagenActualId.Value;
            EliminarImagen(int.Parse(idFotoActual));

            string idProducto = Request.QueryString["id"].ToString();
            CargarCarrusel(int.Parse(idProducto));
        }

        protected void btnElegirPrincipal_Click(object sender, EventArgs e)
        {
            string idProducto = Request.QueryString["id"].ToString();
            string idFotoActual = hfImagenActualId.Value;
            ActualizarImagenPrincipal(idProducto, int.Parse(idFotoActual));
        }


    }
}


