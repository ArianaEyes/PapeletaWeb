using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoPapeletaWeb
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            if (Session["Usuario"] == null)
            {
                Response.Redirect("Login.aspx");
                return; // importante: corta la ejecución para que no siga con el resto del código
            }
            lblUsuario.InnerText = "Bienvenido " + Session["Usuario"].ToString();

            
        }

        
    }
}

