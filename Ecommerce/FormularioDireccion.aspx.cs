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
    public partial class FormularioDireccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.SesionActiva(Session["UsuarioIngresado"]))
                Response.Redirect("Login.aspx", false);
            string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
            if (Id != "" && !IsPostBack)
            {
                DireccionNegocio negocioDireccion = new DireccionNegocio();
                int IdDireccion = int.Parse(Id);
                DireccionUsuario seleccionado = negocioDireccion.BuscarDireccion(IdDireccion);
                txtCalle.Text = seleccionado.Calle;
                txtAltura.Text = seleccionado.Altura.ToString();
                txtPiso.Text = seleccionado.Piso;
                txtDepartamento.Text = seleccionado.Departamento;
                txtCodigoPostal.Text = seleccionado.CodigoPostal;
                txtLocalidad.Text = seleccionado.Localidad;
                txtObservacion.Text = seleccionado.Observacion;
            }
        }
        protected void btnAgregarDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                Usuario usuarioIngresado = (Usuario)Session["UsuarioIngresado"];
                DireccionNegocio negocioDireccion = new DireccionNegocio();
                DireccionUsuario nuevaDireccion = new DireccionUsuario();
                nuevaDireccion.Calle = txtCalle.Text;
                nuevaDireccion.Altura = int.Parse(txtAltura.Text);
                nuevaDireccion.Piso = txtPiso.Text;
                nuevaDireccion.Departamento = txtDepartamento.Text;
                nuevaDireccion.CodigoPostal = txtCodigoPostal.Text;
                nuevaDireccion.Localidad = txtLocalidad.Text;
                nuevaDireccion.Observacion = txtObservacion.Text;
                if (Request.QueryString["Id"] != null)
                {
                    nuevaDireccion.Id = int.Parse(Request.QueryString["Id"]);
                    negocioDireccion.ModificarDireccion(nuevaDireccion);
                }
                else
                {
                    negocioDireccion.AgregarDireccion(usuarioIngresado.Id, nuevaDireccion);
                }
                Response.Redirect("/Direccion.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}