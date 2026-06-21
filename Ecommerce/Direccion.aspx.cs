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
    public partial class Direccion : System.Web.UI.Page
    {
        public List<DireccionUsuario> listaDirecciones { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuarioIngresado = (Usuario)Session["UsuarioIngresado"];
            DireccionNegocio negocioDireccion = new DireccionNegocio();
            listaDirecciones = negocioDireccion.listarDomiciliosUsuario(usuarioIngresado.Id);

            repRepetidorDomicilios.DataSource = listaDirecciones;
            repRepetidorDomicilios.DataBind();
        }
    }
}