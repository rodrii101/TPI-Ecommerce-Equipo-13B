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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            try
            {
                usuario = new Usuario(txtLoginEmail.Text, txtLoginContra.Text, 1);
                if (negocioUsuario.Loguer(usuario))
                {
                    Session.Add("UsuarioIngresado", usuario);
                    Response.Redirect("DefaultCliente.aspx");
                }else
                    Response.Redirect("Carrito.aspx");
            }
            
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}