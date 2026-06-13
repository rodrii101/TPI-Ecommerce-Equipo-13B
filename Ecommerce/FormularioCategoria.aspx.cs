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
    public partial class FormularioCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdCategoria.Enabled = false;
            try
            {
                string Id = Request.QueryString["IdCategoria"] != null ? Request.QueryString["IdCategoria"].ToString() : "";
                if (Id != "" && !IsPostBack)
                {
                    CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                    Categoria seleccionado = (negocioCategoria.listarCategorias(Id))[0];
                    txtIdCategoria.Text = Id;
                    txtDescripcionCategoria.Text = seleccionado.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btmAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria nuevaCategoria = new Categoria();
                CategoriaNegocio negocioCategoria = new CategoriaNegocio();

                nuevaCategoria.Descripcion = txtDescripcionCategoria.Text;

                if (Request.QueryString["IdCategoria"] != null)
                {
                    nuevaCategoria.IdCategoria = int.Parse(txtIdCategoria.Text);
                    negocioCategoria.ModificarCategoria(nuevaCategoria);
                }
                else
                    negocioCategoria.AgregarCategoria(nuevaCategoria);

                Response.Redirect("ListarCategorias.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}