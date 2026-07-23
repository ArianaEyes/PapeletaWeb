using System;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;

namespace DemoPapeletaWeb
{
    public partial class Login : System.Web.UI.Page
    {
        string conexion = @"Server=.;Database=PAPELETA;Trusted_Connection=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conexion))
                {
                    cn.Open();

                    string consulta = @"SELECT Login_Usuario, Pass_Usuario
                        FROM Tb_Usuario
                        WHERE Login_Usuario=@Login_Usuario
                        AND Pass_Usuario=@Pass_Usuario";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.Parameters.AddWithValue("@Login_Usuario", txtUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@Pass_Usuario", txtPassword.Text.Trim());

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                Session["Usuario"] = dr["Login_Usuario"];
                                Response.Redirect("Inicio.aspx");
                            }
                            else
                            {
                                lblError.Text = "Usuario o contraseña incorrectos. (Usuario: '" + txtUsuario.Text + "')";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ERROR DE CONEXIÓN: " + ex.Message;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}