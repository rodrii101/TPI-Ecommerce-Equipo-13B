using negocioEcommerce;
using dominioEcommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class FormularioFormasDePago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtIdFormasDePago.Enabled = false;
                    btmDesactivarYActivarFormasDePago.Visible = false;
                    string id = Request.QueryString["IdFormasDePagos"] != null ? Request.QueryString["IdFormasDePagos"].ToString() : "";
                    if (id != "")
                    {
                        btmDesactivarYActivarFormasDePago.Visible = true;
                        FormasDePagoNegocio negocioPago = new FormasDePagoNegocio();
                        FormasDePagos seleccionado = (negocioPago.listarFormasDePagos(id))[0];
                        Session.Add("FormaDePagoSeleccionado", seleccionado);
                        txtIdFormasDePago.Text = id;
                        txtDescripcionFormasDePago.Text = seleccionado.Descripcion;
                        if (!seleccionado.Estado)
                        {
                            btmDesactivarYActivarFormasDePago.Text = "Reactivar";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
            }
        }

        protected void btmAgregarFormasDePago_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;
                FormasDePagos nuevoPago = new FormasDePagos();
                FormasDePagoNegocio negocioPago = new FormasDePagoNegocio();

                nuevoPago.Descripcion = txtDescripcionFormasDePago.Text;
                if(negocioPago.existeDescripcionFormaDePago(txtDescripcionFormasDePago.Text)){
                    lblDescripcionPago.Text = "Ya existe esta descripcion";
                    return;
                }
                if (Request.QueryString["IdFormasDePagos"] != null)
                {
                    nuevoPago.IdFormasDePago = int.Parse(txtIdFormasDePago.Text);
                    negocioPago.ModificarFormaDePago(nuevoPago);
                }
                else
                    negocioPago.AgregarFormaDePago(nuevoPago);

                Response.Redirect("ListarFormasDePago.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btmDesactivarYActivarFormasDePago_Click(object sender, EventArgs e)
        {
            try
            {
                FormasDePagoNegocio negocioPago = new FormasDePagoNegocio();
                FormasDePagos seleccionado = (FormasDePagos)Session["FormaDePagoSeleccionado"];
                negocioPago.DesactivarYActivarFormaDeProducto(seleccionado.IdFormasDePago, !seleccionado.Estado);
                Response.Redirect("ListarFormasDePago.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}