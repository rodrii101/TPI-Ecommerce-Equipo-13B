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
    public partial class RegistroVendedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Seguridad.SesionActiva((Usuario)Session["UsuarioIngresado"]))
                {
                    Response.Redirect("Login.aspx", false);
                    return;
                }
                    

                Usuario usuario = (Usuario)Session["UsuarioINgresado"];
                if(usuario.TipoUsuario.IdTipoUsuario == 2)
                    Response.Redirect("DefaultCliente.aspx", false);//POR AHORA ENVÍA A DEFAULTCLIENTE
                CargarDatos();
            }

        }

        public void CargarDatos()
        {
            Usuario nuevoVendedor = (Usuario)(Session["UsuarioIngresado"]);
            if (nuevoVendedor.Nombre != null)
                txtNombreVendedor.Text = nuevoVendedor.Nombre;
            if (nuevoVendedor.Apellido != null)
                txtApellidoVendedor.Text = nuevoVendedor.Apellido;
            if (nuevoVendedor.DNI != null)
                txtDniVendedor.Text = nuevoVendedor.DNI;
            if (nuevoVendedor.Telefono != null)
                txtTelefonoVendedor.Text = nuevoVendedor.Telefono;
            if (nuevoVendedor.FechaNacimiento != null)
                txtFechaNacimientoVendedor.Text = nuevoVendedor.FechaNacimiento.ToString("yyyy-MM-dd");
        }

        protected void btnRegistrarVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocioUsuario = new UsuarioNegocio();
                Usuario nuevoVendedor = (Usuario)(Session["UsuarioIngresado"]);
                nuevoVendedor.Nombre = txtNombreVendedor.Text;
                nuevoVendedor.Apellido = txtApellidoVendedor.Text;
                nuevoVendedor.Telefono = txtTelefonoVendedor.Text;
                nuevoVendedor.DNI = txtDniVendedor.Text;
                nuevoVendedor.FechaNacimiento = DateTime.Parse(txtFechaNacimientoVendedor.Text);
                negocioUsuario.RegistrarVendedor(nuevoVendedor);

                /* LE AVISO A SESSION QUE AHORA EL USUARIO AHORA ES DE TIPO VENDEDOR*/
                nuevoVendedor.TipoUsuario = new TipoUsuario();
                nuevoVendedor.TipoUsuario.IdTipoUsuario = 2;
                Session["UsuarioIngresado"] = nuevoVendedor;

                Response.Redirect("ListarProductos.aspx", false);
            }
            catch(Exception ex)
            {
                throw ex;
            }


        }
    }
}