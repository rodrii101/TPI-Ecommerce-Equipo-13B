using dominioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class MasterCliente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgPerfil.ImageUrl = "https://static.vecteezy.com/system/resources/previews/004/141/669/non_2x/no-photo-or-blank-image-icon-loading-images-or-missing-image-mark-image-not-available-or-image-coming-soon-sign-simple-nature-silhouette-in-frame-isolated-illustration-vector.jpg";
            if (!(Page is Login || Page is Registro))
            {
                if (!Seguridad.SesionActiva(Session["UsuarioIngresado"]))
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Usuario UsuarioIngresado = (Usuario)Session["UsuarioIngresado"];
                    if (UsuarioIngresado.ImagenPerfil != null)
                        imgPerfil.ImageUrl = "~/Images/" + UsuarioIngresado.ImagenPerfil;
                    if (Seguridad.SesionAdmin(Session["UsuarioIngresado"]))
                    {
                        PanelCliente.Visible = false;
                        PanelAdmin.Visible = true;
                    }
                    else if (Seguridad.SesionVendedor(Session["UsuarioIngresado"])){
                        PanelCliente.Visible = false;
                        PanelVendedor.Visible = true;
                    }
                }
            }
        }
    }
}