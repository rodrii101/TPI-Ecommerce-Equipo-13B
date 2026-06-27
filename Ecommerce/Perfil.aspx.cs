using dominioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
            txtEmailUsuario.Text = UsuarioIngresado.Email;
            txtBoxNombreUsuario.Text = UsuarioIngresado.Nombre;
            txtApellidoUsuario.Text = UsuarioIngresado.Apellido;
            txtDniUsuario.Text = UsuarioIngresado.DNI;
            txtTelefonoUsuario.Text = UsuarioIngresado.Telefono;
            txtFechaNacimiento.Text = UsuarioIngresado.FechaNacimiento.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(UsuarioIngresado.ImagenPerfil))
            {
                imagenPerfilUsuario.ImageUrl = "~/Images/" + UsuarioIngresado.ImagenPerfil;
            }
        }
    }
}