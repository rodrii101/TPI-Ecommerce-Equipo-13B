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
            txtIdMarca.Enabled = false;
            btmDesactivarYActivarMarca.Visible = false;
            try
            {
                string id = Request.QueryString["IdMarca"] != null ? Request.QueryString["IdMarca"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
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
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btmAgregarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                Marca nuevaMarca = new Marca();
                MarcaNegocio negocioMarca = new MarcaNegocio();

                nuevaMarca.Descripcion = txtDescripcionMarca.Text;
                nuevaMarca.UrlImagen = txtUrlImagenMarca.Text;

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