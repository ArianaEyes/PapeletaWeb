using PapeletaWeb_BE;
using PapeletaWeb_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoPapeletaWeb
{
    public partial class Infracciones : System.Web.UI.Page
    {
        InfraccionBL objInfraccionBL = new InfraccionBL();

        private const int REGISTROS_POR_PAGINA = 10;

        private int PaginaActual
        {
            get
            {
                return ViewState["PaginaActual"] == null ? 1 : (int)ViewState["PaginaActual"];
            }
            set
            {
                ViewState["PaginaActual"] = value;
            }
        }
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
            if (!IsPostBack)
                CargarInfracciones(null);
        }

        private void CargarInfracciones(string filtro)
        {
            int total = objInfraccionBL.ContarInfracciones(filtro);

            var lista = objInfraccionBL.BuscarInfracciones(
                filtro,
                PaginaActual,
                REGISTROS_POR_PAGINA);

            gvInfracciones.DataSource = lista;
            gvInfracciones.DataBind();

            lblCantidad.Text = "Infracciones: " + total;

            int totalPaginas = (int)Math.Ceiling((double)total / REGISTROS_POR_PAGINA);

            if (totalPaginas == 0)
                totalPaginas = 1;

            lblPagina.Text = "Página " + PaginaActual + " de " + totalPaginas;

            btnAnterior.Enabled = PaginaActual > 1;
            btnSiguiente.Enabled = PaginaActual < totalPaginas;
        }

        protected string ObtenerClaseBadge(object calificacion)
        {
            string calif = calificacion?.ToString() ?? "";
            if (calif == "MUY GRAVE") return "bg-danger";
            if (calif == "GRAVE") return "bg-warning text-dark";
            return "bg-success";
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            PaginaActual = 1;
            CargarInfracciones(txtBuscar.Text.Trim());
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (PaginaActual > 1)
            {
                PaginaActual--;
                CargarInfracciones(txtBuscar.Text.Trim());
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            PaginaActual++;
            CargarInfracciones(txtBuscar.Text.Trim());
        }

        private void LimpiarFormulario()
        {
            txtDescripcion.Text = "";
            ddlCalificacion.SelectedValue = "";
            txtPuntos.Text = "";
            txtUit.Text = "";
            txtMedida.Text = "";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            Editando = false;
            CodigoInfraccion = "";

            btnGuardar.Text = "Guardar";

            pnlFormulario.Visible = true;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            CodigoInfraccion = btn.CommandArgument;

            InfraccionBE obj =
                objInfraccionBL.ObtenerInfraccion(CodigoInfraccion);

            txtDescripcion.Text = obj.Descripcion_Sancion;
            ddlCalificacion.SelectedValue = obj.Calificacion;
            txtPuntos.Text = obj.Puntos.ToString();
            txtUit.Text = obj.Uit.ToString();
            txtMedida.Text = obj.Medida_Preventiva;

            Editando = true;

            btnGuardar.Text = "Actualizar";

            pnlFormulario.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            pnlFormulario.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                InfraccionBE obj = new InfraccionBE();

                obj.Cod_Infraccion = CodigoInfraccion;
                obj.Descripcion_Sancion = txtDescripcion.Text.Trim();
                obj.Calificacion = ddlCalificacion.SelectedValue;
                obj.Puntos = Convert.ToInt32(txtPuntos.Text);
                obj.Uit = Convert.ToDecimal(txtUit.Text);
                obj.Medida_Preventiva = txtMedida.Text.Trim();

                bool ok;

                if (Editando)
                    ok = objInfraccionBL.ActualizarInfraccion(obj);
                else
                    ok = objInfraccionBL.InsertarInfraccion(obj);

                if (ok)
                {
                    LimpiarFormulario();

                    pnlFormulario.Visible = false;

                    Editando = false;
                    CodigoInfraccion = "";

                    btnGuardar.Text = "Guardar";

                    CargarInfracciones(txtBuscar.Text.Trim());

                    ScriptManager.RegisterStartupScript(
                        this,
                        GetType(),
                        "ok",
                        "alert('Operación realizada correctamente.');",
                        true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error",
                    "alert('" + ex.Message.Replace("'", "") + "');", true);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string codigo = btn.CommandArgument;
                objInfraccionBL.EliminarInfraccion(codigo);
                CargarInfracciones(txtBuscar.Text.Trim());
                ScriptManager.RegisterStartupScript(this, GetType(), "ok",
                    "alert('Infracción inactivada correctamente.');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error",
                    "alert('" + ex.Message.Replace("'", "") + "');", true);
            }
        }

        private string CodigoInfraccion
        {
            get
            {
                return ViewState["CodigoInfraccion"] == null
                    ? ""
                    : ViewState["CodigoInfraccion"].ToString();
            }
            set
            {
                ViewState["CodigoInfraccion"] = value;
            }
        }

        private bool Editando
        {
            get
            {
                return ViewState["Editando"] == null
                    ? false
                    : (bool)ViewState["Editando"];
            }
            set
            {
                ViewState["Editando"] = value;
            }
        }
    }
}