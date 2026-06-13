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
                    if(id != "")
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
                    productoNegocio.agregar(productoNuevo, Request.QueryString["id"].ToString());
                }
                else
                {
                    productoNegocio.agregar(productoNuevo);
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
    }
}