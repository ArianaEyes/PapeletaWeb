using PapeletaWeb_BE;
using PapeletaWeb_BL;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoPapeletaWeb
{
    public partial class Papeletas : System.Web.UI.Page
    {
        PapeletaBL objPapeletaBL = new PapeletaBL();
        VehiculoBL objVehiculoBL = new VehiculoBL();
        InfraccionBL objInfraccionBL = new InfraccionBL();
        PoliciaBL objPoliciaBL = new PoliciaBL();

        private const int REGISTROS_POR_PAGINA = 10;

        private string CodigoEditar
        {
            get
            {
                return ViewState["CodigoEditar"] == null
                    ? ""
                    : ViewState["CodigoEditar"].ToString();
            }
            set
            {
                ViewState["CodigoEditar"] = value;
            }
        }

        private int PaginaActual
        {
            get
            {
                return ViewState["PaginaActual"] == null
                    ? 1
                    : (int)ViewState["PaginaActual"];
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
            {
                CargarPapeletas(null);

                CargarCombos();

                pnlFormulario.Visible = false;
            }
        }

        private void CargarCombos()
        {
            ddlVehiculo.DataSource = objVehiculoBL.ListarVehiculos(1, 1000);
            ddlVehiculo.DataTextField = "Cod_Vehiculo";
            ddlVehiculo.DataValueField = "Cod_Vehiculo";
            ddlVehiculo.DataBind();

            ddlVehiculo.Items.Insert(
                0,
                new ListItem("-- Seleccione vehículo --", "")
            );



            ddlInfraccion.DataSource =
                objInfraccionBL.ListarInfracciones(1, 1000);

            ddlInfraccion.DataTextField =
                "Descripcion_Sancion";

            ddlInfraccion.DataValueField =
                "Cod_Infraccion";

            ddlInfraccion.DataBind();


            ddlInfraccion.Items.Insert(
                0,
                new ListItem("-- Seleccione infracción --", "")
            );




            ddlPolicia.DataSource =
                objPoliciaBL.BuscarPolicias(null, 1, 1000);


            ddlPolicia.DataTextField =
                "Nombre";

            ddlPolicia.DataValueField =
                "Cod_Policia";


            ddlPolicia.DataBind();


            ddlPolicia.Items.Insert(
                0,
                new ListItem("-- Seleccione policía --", "")
            );

        }

        private void LimpiarFormulario()
        {
            ddlVehiculo.SelectedIndex = 0;

            ddlInfraccion.SelectedIndex = 0;

            ddlPolicia.SelectedIndex = 0;


            txtLugar.Text = "";

            txtFecha.Text = "";

            txtHora.Text = "";

            txtInfo.Text = "";

            txtObservaciones.Text = "";
        }


        private void CargarPapeletas(string filtro)
        {
            int total = objPapeletaBL.ContarPapeletas(filtro);
            var lista = objPapeletaBL.BuscarPapeletas(
                filtro,
                PaginaActual,
                REGISTROS_POR_PAGINA
            );
            gvPapeletas.DataSource = lista;
            gvPapeletas.DataBind();
            lblCantidad.Text =
                "Total: " + total;
            int totalPaginas =
                (int)Math.Ceiling(
                    (double)total /
                    REGISTROS_POR_PAGINA
                );
            if (totalPaginas == 0)
            {
                totalPaginas = 1;
            }
            lblPagina.Text =
                "Página " +
                PaginaActual +
                " de " +
                totalPaginas;
            btnAnterior.Enabled =
                PaginaActual > 1;
            btnSiguiente.Enabled =
                PaginaActual < totalPaginas;

        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            CodigoEditar = "";
            CargarCombos();
            pnlFormulario.Visible = true;
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            PaginaActual = 1;

            CargarPapeletas(
                txtBuscar.Text.Trim()
            );
        }
        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (PaginaActual > 1)
            {
                PaginaActual--;
                CargarPapeletas(
                    txtBuscar.Text.Trim()
                );
            }
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {

            PaginaActual++;
            CargarPapeletas(
                txtBuscar.Text.Trim()
            );

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                PapeletaBE obj = new PapeletaBE();


                obj.Cod_Infraccion =
                    ddlInfraccion.SelectedValue;


                obj.Cod_Policia =
                    ddlPolicia.SelectedValue;


                obj.Cod_Vehiculo =
                    ddlVehiculo.SelectedValue;



                obj.Fecha_Infraccion =
                    Convert.ToDateTime(txtFecha.Text);



                obj.Hora_Infraccion =
                    TimeSpan.Parse(txtHora.Text);



                obj.Lugar_Infraccion =
                    txtLugar.Text.Trim();



                obj.Info_Adicional =
                    txtInfo.Text.Trim();



                obj.Observaciones =
                    txtObservaciones.Text.Trim();



                if (string.IsNullOrEmpty(CodigoEditar))
                {
                    obj.Usu_Registro = "ADMIN";

                    objPapeletaBL.InsertarPapeleta(obj);
                }
                else
                {
                    obj.Cod_Papeleta = CodigoEditar;

                    obj.Usu_Ult_Modificacion = "ADMIN";

                    objPapeletaBL.ActualizarPapeleta(obj);
                }



                LimpiarFormulario();

                CodigoEditar = "";


                pnlFormulario.Visible = false;


                CargarPapeletas(
                    txtBuscar.Text.Trim()
                );


                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "",
                    "alert('Papeleta guardada correctamente');",
                    true
                );

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "",
                    "alert('" + ex.Message.Replace("'", "") + "');",
                    true
                );

            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();

            CodigoEditar = "";

            pnlFormulario.Visible = false;
        }

        protected void gvPapeletas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string codigo = e.CommandArgument.ToString();


            if (e.CommandName == "Editar")
            {
                var obj = objPapeletaBL.ConsultarPapeleta(codigo);


                CodigoEditar = obj.Cod_Papeleta;


                ddlVehiculo.SelectedValue = obj.Cod_Vehiculo;
                ddlInfraccion.SelectedValue = obj.Cod_Infraccion;
                ddlPolicia.SelectedValue = obj.Cod_Policia;


                txtLugar.Text = obj.Lugar_Infraccion;
                txtInfo.Text = obj.Info_Adicional;
                txtObservaciones.Text = obj.Observaciones;


                txtFecha.Text =
                    obj.Fecha_Infraccion.ToString("yyyy-MM-dd");


                txtHora.Text =
                    obj.Hora_Infraccion.ToString();


                pnlFormulario.Visible = true;

            }



            if (e.CommandName == "Eliminar")
            {
                objPapeletaBL.EliminarPapeleta(codigo);

                CargarPapeletas(txtBuscar.Text.Trim());
            }

        }
    }
}