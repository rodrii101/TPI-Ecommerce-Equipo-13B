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
    public partial class CambiarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Seguridad.SesionActiva((Usuario)Session["UsuarioIngresado"]))
                    Response.Redirect("Login.aspx", false);
            }
        }

        protected void btnCambiarPass_Click(object sender, EventArgs e)
        {
            string nueva = txtNuevaPass.Text;
            string confirmar = txtConfirmarPass.Text;

            try
            {
                Usuario usuarioActual = (Usuario)Session["UsuarioIngresado"];
                UsuarioNegocio negocio = new UsuarioNegocio();

                negocio.ActualizarPassword(usuarioActual.Id, nueva);

                usuarioActual.Pass = nueva;
                Session["UsuarioIngresado"] = usuarioActual;

                lblCambioPass.Visible = true;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario usuarioActual = (Usuario)Session["UsuarioIngresado"];

            Usuario usuarioAux = new Usuario();
            usuarioAux.Email = usuarioActual.Email;
            usuarioAux.Pass = txtVerficarPass.Text; 

            UsuarioNegocio negocio = new UsuarioNegocio();

            if (negocio.Loguer(usuarioAux))
            {
                panelVerificarPass.Visible = false;
                panelCambiarPass.Visible = true;
            }
            else
            {
                lblPassInvalida.Visible = true;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx", false);
        }
    }
}