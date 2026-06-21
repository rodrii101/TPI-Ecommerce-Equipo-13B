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
    public partial class DefaultCliente : System.Web.UI.Page
    {
        public List<Producto> listaProducto {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocioProducto = new ProductoNegocio();
            listaProducto = negocioProducto.listarProductos();//YA TENGO LAS IMAGENES CARGADAS

            
            rptRepeater.DataSource = listaProducto;
            rptRepeater.DataBind();
        }

        public string ObtenerImagenPrincipal(Producto producto)
        {
            if (producto.Imagenes_URL != null && producto.Imagenes_URL.Count > 0)
            {
                //BUSCO IMG PRINCIPAL
                ImagenProducto imgPrincipal = producto.Imagenes_URL.FirstOrDefault(i => i.EsPrincipal);//ESTO DVUELVE OBJ img principal
                if (imgPrincipal != null)                               //i=>i.EsPrincipal --> busca el principal itemXitem en la lista
                    return imgPrincipal.ImagenURL;
                else
                    //SI NO HAY imgPrincipal TOMO LA PRIMER IMAGEN
                    return producto.Imagenes_URL.First().ImagenURL;
            }
            else
            {
                return "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png";
            }
        }

        protected void btnVerDetalleProducto_Click(object sender, EventArgs e)
        {

        }
    }
}