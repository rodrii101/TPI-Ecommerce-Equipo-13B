using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Error"] != null)
            {
                lblError.Text = Session["Error"].ToString();
                Session.Remove("Error");
            }
            else
            {
                lblError.Text = "Ocurrio un error en el sistema";
            }
        }
    }
}