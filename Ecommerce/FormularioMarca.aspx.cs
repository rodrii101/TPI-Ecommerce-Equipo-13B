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
    public partial class FormularioMarca : System.Web.UI.Page
    {
        public string UrlImagen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.SesionAdmin(Session["UsuarioIngresado"]))
            {
                Session.Add("Error", "Se necesita permisos de Admin");
                Response.Redirect("Error.aspx");
            }
            try
            {
                UrlImagen = "https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg";
                if (!IsPostBack)
                {
                    txtIdMarca.Enabled = false;
                    btmDesactivarYActivarMarca.Visible = false;
                    string id = Request.QueryString["IdMarca"] != null ? Request.QueryString["IdMarca"].ToString() : "";
                    txtIdMarca.Visible = false;
                    lblIdMarca.Visible = false;

                    if (id != "")
                    {
                        txtIdMarca.Visible = true;
                        lblIdMarca.Visible = true;
                        btmDesactivarYActivarMarca.Visible = true;
                        MarcaNegocio negocioMarca = new MarcaNegocio();
                        Marca seleccionada = (negocioMarca.listarMarca(id))[0];
                        Session.Add("marcaSeleccionada", seleccionada);

                        txtIdMarca.Text = id;
                        txtDescripcionMarca.Text = seleccionada.Descripcion;
                        txtUrlImagenMarca.Text = seleccionada.UrlImagen;
                        txtUrlImagenMarca_TextChanged(sender, e);
                        if (!seleccionada.Estado)
                        {
                            btmDesactivarYActivarMarca.Text = "Reactivar";
                            btmDesactivarYActivarMarca.CssClass = "btn btn-success";
                        }
                    }
                }
                else
                {
                    UrlImagen = txtUrlImagenMarca.Text;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btmAgregarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                lblExisteMarca.Text = ""; 
                Page.Validate();
                if (!Page.IsValid)
                    return;
                Marca nuevaMarca = new Marca();
                MarcaNegocio negocioMarca = new MarcaNegocio();

                nuevaMarca.Descripcion = txtDescripcionMarca.Text;
                nuevaMarca.UrlImagen = txtUrlImagenMarca.Text;

                if (negocioMarca.existeDescripcion(nuevaMarca.Descripcion))
                {
                    lblExisteMarca.Text = "Ya existe esta descripcion";
                    return;
                }

                if (Request.QueryString["IdMarca"] != null)
                {
                    nuevaMarca.IdMarca = int.Parse(txtIdMarca.Text);
                    negocioMarca.ModificarMarca(nuevaMarca);
                }
                else
                    negocioMarca.AgregarMarca(nuevaMarca);

                Response.Redirect("ListarMarcas.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }

        }

        protected void btmDesactivarYActivarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                MarcaNegocio negocioMarca = new MarcaNegocio();
                Marca seleccionada = (Marca)Session["marcaSeleccionada"];
                negocioMarca.DesativarYActivar(seleccionada.IdMarca, !seleccionada.Estado);
                Response.Redirect("ListarMarcas.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }

        }

        protected void txtUrlImagenMarca_TextChanged(object sender, EventArgs e)
        {
            UrlImagen = txtUrlImagenMarca.Text;
        }
    }
}