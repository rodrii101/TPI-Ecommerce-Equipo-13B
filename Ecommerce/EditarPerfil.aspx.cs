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
    public partial class EditarPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
                txtBoxNombreEditarUsuario.Text = UsuarioIngresado.Nombre;
                txtApellidoEditarUsuario.Text = UsuarioIngresado.Apellido;
                txtDniEditarUsuario.Text = UsuarioIngresado.DNI;
                txtTelefonoEditarUsuario.Text = UsuarioIngresado.Telefono;
                txtFechaNacimiento.Text = UsuarioIngresado.FechaNacimiento.ToString("yyyy-MM-dd");
                if (!string.IsNullOrEmpty(UsuarioIngresado.ImagenPerfil))
                    imgEditarFotoPerfil.ImageUrl = "~/Images/" + UsuarioIngresado.ImagenPerfil;
            }
        }

        protected void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
                UsuarioNegocio negocioUsuario = new UsuarioNegocio();
                if (txtImagenPerfil.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagenPerfil.PostedFile.SaveAs(ruta + "fotoPerfil-" + UsuarioIngresado.Id + ".jpg");
                    UsuarioIngresado.ImagenPerfil = "fotoPerfil-" + UsuarioIngresado.Id + ".jpg";
                    UsuarioIngresado.Nombre = txtBoxNombreEditarUsuario.Text;
                }
                UsuarioIngresado.Apellido = txtApellidoEditarUsuario.Text;
                UsuarioIngresado.Telefono = txtTelefonoEditarUsuario.Text;
                UsuarioIngresado.DNI = txtDniEditarUsuario.Text;
                UsuarioIngresado.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                negocioUsuario.EditarPerfil(UsuarioIngresado);

                Image imagenPerfiUsuario = (Image)Master.FindControl("imgPerfil");
                imagenPerfiUsuario.ImageUrl = "~/Images/" + UsuarioIngresado.ImagenPerfil;
                Response.Redirect("/Perfil.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }


        }
    }
}
