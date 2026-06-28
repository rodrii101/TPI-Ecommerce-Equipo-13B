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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.SesionActiva((Usuario)Session["UsuarioIngresado"]))
                    Response.Redirect("DefaultCliente.aspx", false);
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            lblCorreoNoExiste.Text = "";

            Page.Validate();
            if (!Page.IsValid)
                return;

            Usuario user = new Usuario();
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();

            if (!negocioUsuario.existeCuenta(txtRegistroEmail.Text))
            {
                user.Email = txtRegistroEmail.Text;
                user.Pass = txtConfirmarPassword.Text;
                user.TipoUsuario = new TipoUsuario();
                user.TipoUsuario.IdTipoUsuario = 1;
                user.Id = negocioUsuario.Registrar(user);//PARA LOGIN AUTOMATICO

                Session.Add("UsuarioIngresado", user); //LOGIN AUTOMATICO
            }
            else
            {
                lblCorreoNoExiste.Text = "Este correo ya esta asociado a una cuenta.";
                return;
            }

            Response.Redirect("DefaultCliente.aspx", false);
        }
    }
}