using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SitioWEB_VentasGUI
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Codifique
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            //1.Elimina la cookie de autenticacion que maneja el archivo Web.config
            FormsAuthentication.SignOut();

            //2. Limpia todas las variables guardadas en la memoria temporal del servidor
            Session.Clear();

            //3. Destruye la forma definitiva la sesión en IIS
            Session.Abandon();
            //4. Limpia las cookies de sesión del navegador de forma explícita
            if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpCookie cookieAutenticacion = new HttpCookie(FormsAuthentication.FormsCookieName);
                cookieAutenticacion.Expires = DateTime.UtcNow.AddDays(-1);//Expira ayer
                    Response.Cookies.Add(cookieAutenticacion);
            }

        }
    }
}