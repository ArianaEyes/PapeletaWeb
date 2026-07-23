using PapeletaWeb_BE;
using PapeletaWeb_BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoPapeletaWeb
{
    public partial class TransaccionesMultas : Page
    {
        private readonly PoliciaBL objPoliciaBL =
            new PoliciaBL();

        private readonly InfractorBL objInfractorBL =
            new InfractorBL();

        private readonly InfraccionBL objInfraccionBL =
            new InfraccionBL();

        private readonly PapeletaBL objPapeletaBL =
            new PapeletaBL();

        private const string CLAVE_TABLA =
            "TABLA_PAPELETAS_TEMPORALES";


        protected void Page_Load(
            object sender,
            EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarInfracciones();
                CargarFechaActual();
                InicializarTablaTemporal();

                LimpiarDatosPolicia();
                LimpiarDatosInfractor();
                LimpiarResumenInfraccion();
                OcultarMensaje();
            }
        }

        private DataTable TablaTemporal
        {
            get
            {
                if (ViewState[CLAVE_TABLA] == null)
                {
                    ViewState[CLAVE_TABLA] =
                        CrearEstructuraTabla();
                }

                return (DataTable)
                    ViewState[CLAVE_TABLA];
            }

            set
            {
                ViewState[CLAVE_TABLA] =
                    value;
            }
        }

        private DataTable CrearEstructuraTabla()
        {
            DataTable tabla =
                new DataTable();

            tabla.Columns.Add(
                "CodPapeleta",
                typeof(string)
            );

            tabla.Columns.Add(
                "FechaHora",
                typeof(string)
            );

            tabla.Columns.Add(
                "Infraccion",
                typeof(string)
            );

            tabla.Columns.Add(
                "CodVehiculo",
                typeof(string)
            );

            tabla.Columns.Add(
                "Lugar",
                typeof(string)
            );

            tabla.Columns.Add(
                "Puntos",
                typeof(int)
            );

            tabla.Columns.Add(
                "Uit",
                typeof(decimal)
            );

            tabla.Columns.Add(
                "Estado",
                typeof(string)
            );

            return tabla;
        }

        private void InicializarTablaTemporal()
        {
            TablaTemporal =
                CrearEstructuraTabla();

            EnlazarTabla();
        }

        private void EnlazarTabla()
        {
            gvPapeletasRegistradas.DataSource =
                TablaTemporal;

            gvPapeletasRegistradas.DataBind();

            ActualizarTotales();
        }

        private void AgregarPapeletaATabla(
            string codigoPapeleta,
            InfraccionBE infraccion,
            DateTime fecha,
            TimeSpan hora,
            string codigoVehiculo,
            string lugar)
        {
            DataTable tabla =
                TablaTemporal;

            DataRow fila =
                tabla.NewRow();

            fila["CodPapeleta"] =
                codigoPapeleta;

            fila["FechaHora"] =
                fecha.ToString("dd/MM/yyyy") +
                " " +
                hora.ToString(@"hh\:mm");

            fila["Infraccion"] =
                infraccion.Cod_Infraccion +
                " - " +
                infraccion.Descripcion_Sancion;

            fila["CodVehiculo"] =
                codigoVehiculo;

            fila["Lugar"] =
                lugar;

            fila["Puntos"] =
                infraccion.Puntos;

            fila["Uit"] =
                infraccion.Uit;

            fila["Estado"] =
                "Pendiente";

            tabla.Rows.Add(fila);

            TablaTemporal =
                tabla;

            EnlazarTabla();
        }

        private void ActualizarTotales()
        {
            DataTable tabla =
                TablaTemporal;

            lblTotalPapeletas.Text =
                tabla.Rows.Count.ToString();

            int totalPuntos = 0;
            decimal totalUit = 0m;

            foreach (DataRow fila in tabla.Rows)
            {
                totalPuntos +=
                    Convert.ToInt32(
                        fila["Puntos"]
                    );

                totalUit +=
                    Convert.ToDecimal(
                        fila["Uit"]
                    );
            }

            lblTotalPuntos.Text =
                totalPuntos.ToString();

            lblTotalUit.Text =
                totalUit.ToString("N2");
        }


        protected void btnBuscarPolicia_Click(
            object sender,
            EventArgs e)
        {
            string dni =
                txtDniPolicia.Text.Trim();

            if (!ValidarDni(
                dni,
                "policía"))
            {
                return;
            }

            try
            {
                PoliciaBE policia =
                    objPoliciaBL
                        .ConsultarPoliciaPorDni(dni);

                if (policia == null)
                {
                    LimpiarDatosPolicia();

                    MostrarMensaje(
                        "No se encontró un policía activo con el DNI ingresado.",
                        false
                    );

                    return;
                }

                txtCodigoPolicia.Text =
                    policia.Cod_Policia;

                txtNombrePolicia.Text =
                    ConstruirNombrePolicia(
                        policia
                    );

                ViewState["COD_POLICIA"] =
                    policia.Cod_Policia;

                ViewState["DNI_POLICIA"] =
                    policia.Dni;

                MostrarMensaje(
                    "Policía encontrado correctamente.",
                    true
                );
            }
            catch (Exception ex)
            {
                LimpiarDatosPolicia();

                MostrarMensaje(
                    "No se pudo buscar al policía: " +
                    ex.Message,
                    false
                );
            }
        }

        private string ConstruirNombrePolicia(
            PoliciaBE policia)
        {
            string nombreCompleto =
                policia.Nombre + " " +
                policia.Paterno + " " +
                policia.Materno;

            return nombreCompleto.Trim();
        }

        private void LimpiarDatosPolicia()
        {
            txtCodigoPolicia.Text =
                string.Empty;

            txtNombrePolicia.Text =
                string.Empty;

            ViewState.Remove(
                "COD_POLICIA"
            );

            ViewState.Remove(
                "DNI_POLICIA"
            );
        }


        protected void btnBuscarInfractor_Click(
            object sender,
            EventArgs e)
        {
            string dni =
                txtDniInfractor.Text.Trim();

            if (!ValidarDni(
                dni,
                "infractor"))
            {
                return;
            }

            try
            {
                List<InfractorBE> resultados =
                    objInfractorBL
                        .BuscarInfractores(
                            dni,
                            1,
                            100
                        );

                InfractorBE infractor =
                    resultados.FirstOrDefault(
                        item =>
                            item.Dni == dni
                    );

                if (infractor == null)
                {
                    LimpiarDatosInfractor();

                    MostrarMensaje(
                        "No se encontró un infractor con ese DNI.",
                        false
                    );

                    return;
                }

                txtCodInfractor.Text =
                    infractor.Cod_Infractor;

                txtNombreInfractor.Text =
                    ConstruirNombreInfractor(
                        infractor
                    );

                txtBrevete.Text =
                    infractor.Nro_Brevete;

                txtDistritoInfractor.Text =
                    infractor.Distrito;

                txtEstadoInfractor.Text =
                    string.IsNullOrWhiteSpace(
                        infractor.EstadoTexto
                    )
                    ? infractor.Estado
                    : infractor.EstadoTexto;

                txtDireccionInfractor.Text =
                    infractor.Direccion;

                ViewState["COD_INFRACTOR"] =
                    infractor.Cod_Infractor;

                ViewState["DNI_INFRACTOR"] =
                    infractor.Dni;

                pnlDatosInfractor.Visible =
                    true;

                MostrarMensaje(
                    "Infractor encontrado correctamente.",
                    true
                );
            }
            catch (Exception ex)
            {
                LimpiarDatosInfractor();

                MostrarMensaje(
                    "No se pudo buscar al infractor: " +
                    ex.Message,
                    false
                );
            }
        }

        private string ConstruirNombreInfractor(
            InfractorBE infractor)
        {
            string nombreCompleto =
                infractor.Nombres + " " +
                infractor.Ape_Paterno + " " +
                infractor.Ape_Materno;

            return nombreCompleto.Trim();
        }

        private bool ValidarDni(
            string dni,
            string persona)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                MostrarMensaje(
                    "Ingrese el DNI del " +
                    persona + ".",
                    false
                );

                return false;
            }

            if (dni.Length != 8)
            {
                MostrarMensaje(
                    "El DNI del " +
                    persona +
                    " debe contener exactamente 8 dígitos.",
                    false
                );

                return false;
            }

            long numero;

            if (!long.TryParse(
                dni,
                out numero))
            {
                MostrarMensaje(
                    "El DNI del " +
                    persona +
                    " solo debe contener números.",
                    false
                );

                return false;
            }

            return true;
        }

        private void LimpiarDatosInfractor()
        {
            txtCodInfractor.Text =
                string.Empty;

            txtNombreInfractor.Text =
                string.Empty;

            txtBrevete.Text =
                string.Empty;

            txtDistritoInfractor.Text =
                string.Empty;

            txtEstadoInfractor.Text =
                string.Empty;

            txtDireccionInfractor.Text =
                string.Empty;

            pnlDatosInfractor.Visible =
                false;

            ViewState.Remove(
                "COD_INFRACTOR"
            );

            ViewState.Remove(
                "DNI_INFRACTOR"
            );
        }

        private void CargarInfracciones()
        {
            try
            {
                List<InfraccionBE> lista =
                    objInfraccionBL
                        .ListarInfracciones(
                            1,
                            1000
                        );

                ddlInfraccion.Items.Clear();

                ddlInfraccion.DataSource =
                    lista;

                ddlInfraccion.DataValueField =
                    "Cod_Infraccion";

                ddlInfraccion.DataTextField =
                    "Descripcion_Sancion";

                ddlInfraccion.DataBind();

                ddlInfraccion.Items.Insert(
                    0,
                    new ListItem(
                        "Seleccione una infracción",
                        ""
                    )
                );
            }
            catch (Exception ex)
            {
                ddlInfraccion.Items.Clear();

                ddlInfraccion.Items.Add(
                    new ListItem(
                        "No se pudieron cargar las infracciones",
                        ""
                    )
                );

                MostrarMensaje(
                    "No se pudieron cargar las infracciones: " +
                    ex.Message,
                    false
                );
            }
        }

        protected void ddlInfraccion_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            try
            {
                InfraccionBE infraccion =
                    ObtenerInfraccionSeleccionada();

                if (infraccion == null)
                {
                    LimpiarResumenInfraccion();
                    return;
                }

                MostrarResumenInfraccion(
                    infraccion
                );
            }
            catch (Exception ex)
            {
                LimpiarResumenInfraccion();

                MostrarMensaje(
                    "No se pudo consultar la infracción: " +
                    ex.Message,
                    false
                );
            }
        }

        private InfraccionBE
            ObtenerInfraccionSeleccionada()
        {
            string codigo =
                ddlInfraccion.SelectedValue;

            if (string.IsNullOrWhiteSpace(
                codigo))
            {
                return null;
            }

            List<InfraccionBE> lista =
                objInfraccionBL
                    .BuscarInfracciones(
                        codigo,
                        1,
                        20
                    );

            return lista.FirstOrDefault(
                item =>
                    item.Cod_Infraccion ==
                    codigo
            );
        }

        private void MostrarResumenInfraccion(
            InfraccionBE infraccion)
        {
            lblCodigoInfraccion.Text =
                infraccion.Cod_Infraccion;

            lblDescripcionInfraccion.Text =
                infraccion.Descripcion_Sancion;

            lblCalificacion.Text =
                infraccion.Calificacion;

            lblPuntos.Text =
                infraccion.Puntos.ToString();

            lblUit.Text =
                infraccion.Uit.ToString("N2");
        }

        private void LimpiarResumenInfraccion()
        {
            lblCodigoInfraccion.Text =
                "-";

            lblDescripcionInfraccion.Text =
                "-";

            lblCalificacion.Text =
                "-";

            lblPuntos.Text =
                "0";

            lblUit.Text =
                "0.00";
        }


        protected void btnRegistrar_Click(
            object sender,
            EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return;
            }

            try
            {
                DateTime fecha;
                TimeSpan hora;

                bool fechaValida =
                    DateTime.TryParse(
                        txtFechaInfraccion.Text,
                        out fecha
                    );

                bool horaValida =
                    TimeSpan.TryParse(
                        txtHoraInfraccion.Text,
                        out hora
                    );

                if (!fechaValida ||
                    !horaValida)
                {
                    MostrarMensaje(
                        "La fecha o la hora no tienen un formato válido.",
                        false
                    );

                    return;
                }

                InfraccionBE infraccion =
                    ObtenerInfraccionSeleccionada();

                if (infraccion == null)
                {
                    MostrarMensaje(
                        "No se pudo obtener la infracción seleccionada.",
                        false
                    );

                    return;
                }

                string codigoPolicia =
                    ViewState["COD_POLICIA"]
                        .ToString();

                string codigoVehiculo =
                    txtCodigoVehiculo.Text
                        .Trim()
                        .ToUpper();

                string lugar =
                    txtLugar.Text.Trim();

                PapeletaBE papeleta =
                    new PapeletaBE
                    {
                        Cod_Infraccion =
                            infraccion.Cod_Infraccion,

                        Cod_Policia =
                            codigoPolicia,

                        Cod_Vehiculo =
                            codigoVehiculo,

                        Fecha_Infraccion =
                            fecha,

                        Hora_Infraccion =
                            hora,

                        Lugar_Infraccion =
                            lugar,

                        Referencia =
                            TextoONull(
                                txtReferencia.Text
                            ),

                        Info_Adicional =
                            TextoONull(
                                txtInfoAdicional.Text
                            ),

                        Observaciones =
                            TextoONull(
                                txtObservaciones.Text
                            ),

                        Estado_Papeleta =
                            "A",

                        Fec_Registro =
                            DateTime.Now,

                        Usu_Registro =
                            codigoPolicia,

                        Fec_Ult_Modificacion =
                            null,

                        Usu_Ult_Modificacion =
                            null
                    };

                string codigoPapeleta =
                    objPapeletaBL
                        .InsertarPapeleta(
                            papeleta
                        );

                AgregarPapeletaATabla(
                    codigoPapeleta,
                    infraccion,
                    fecha,
                    hora,
                    codigoVehiculo,
                    lugar
                );

                MostrarMensaje(
                    "La papeleta " +
                    codigoPapeleta +
                    " fue registrada correctamente. " +
                    "Puede registrar otra infracción para el mismo infractor.",
                    true
                );

                LimpiarSoloInfraccion();
            }
            catch (Exception ex)
            {
                MostrarMensaje(
                    "No se pudo registrar la papeleta: " +
                    ex.Message,
                    false
                );
            }
        }

        private bool ValidarFormulario()
        {
            if (ViewState["COD_POLICIA"] == null)
            {
                MostrarMensaje(
                    "Primero debe buscar al policía por su DNI.",
                    false
                );

                txtDniPolicia.Focus();
                return false;
            }

            if (ViewState["COD_INFRACTOR"] == null)
            {
                MostrarMensaje(
                    "Primero debe buscar al infractor por su DNI.",
                    false
                );

                txtDniInfractor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                ddlInfraccion.SelectedValue))
            {
                MostrarMensaje(
                    "Seleccione una infracción.",
                    false
                );

                ddlInfraccion.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtCodigoVehiculo.Text))
            {
                MostrarMensaje(
                    "Ingrese el código del vehículo.",
                    false
                );

                txtCodigoVehiculo.Focus();
                return false;
            }

            if (txtCodigoVehiculo.Text.Trim().Length > 6)
            {
                MostrarMensaje(
                    "El código del vehículo no puede superar 6 caracteres.",
                    false
                );

                txtCodigoVehiculo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(
                txtLugar.Text))
            {
                MostrarMensaje(
                    "Ingrese el lugar de la infracción.",
                    false
                );

                txtLugar.Focus();
                return false;
            }

            DateTime fecha;
            TimeSpan hora;

            if (!DateTime.TryParse(
                txtFechaInfraccion.Text,
                out fecha))
            {
                MostrarMensaje(
                    "Ingrese una fecha válida.",
                    false
                );

                txtFechaInfraccion.Focus();
                return false;
            }

            if (!TimeSpan.TryParse(
                txtHoraInfraccion.Text,
                out hora))
            {
                MostrarMensaje(
                    "Ingrese una hora válida.",
                    false
                );

                txtHoraInfraccion.Focus();
                return false;
            }

            DateTime fechaHora =
                fecha.Date.Add(hora);

            if (fechaHora > DateTime.Now)
            {
                MostrarMensaje(
                    "La fecha y hora de la infracción no pueden ser futuras.",
                    false
                );

                return false;
            }

            return true;
        }

        private string TextoONull(
            string texto)
        {
            return string.IsNullOrWhiteSpace(
                texto)
                ? null
                : texto.Trim();
        }


        protected void gvPapeletasRegistradas_RowCommand(
            object sender,
            GridViewCommandEventArgs e)
        {
            if (e.CommandName != "QuitarFila")
            {
                return;
            }

            int indice;

            if (!int.TryParse(
                e.CommandArgument.ToString(),
                out indice))
            {
                MostrarMensaje(
                    "No se pudo identificar la fila seleccionada.",
                    false
                );

                return;
            }

            DataTable tabla =
                TablaTemporal;

            if (indice >= 0 &&
                indice < tabla.Rows.Count)
            {

                tabla.Rows.RemoveAt(indice);

                TablaTemporal =
                    tabla;

                EnlazarTabla();

                MostrarMensaje(
                    "La papeleta fue retirada de la lista visual. " +
                    "El registro continúa en la base de datos.",
                    true
                );
            }
        }

        protected void btnLimpiarLista_Click(
            object sender,
            EventArgs e)
        {
            InicializarTablaTemporal();

            MostrarMensaje(
                "Se limpió la lista visual. " +
                "Las papeletas registradas continúan en la base de datos.",
                true
            );
        }

        protected void btnNuevaInfraccion_Click(
            object sender,
            EventArgs e)
        {
            LimpiarSoloInfraccion();
            OcultarMensaje();
        }

        private void LimpiarSoloInfraccion()
        {
            if (ddlInfraccion.Items.Count > 0)
            {
                ddlInfraccion.SelectedIndex =
                    0;
            }

            txtLugar.Text =
                string.Empty;

            txtReferencia.Text =
                string.Empty;

            txtInfoAdicional.Text =
                string.Empty;

            txtObservaciones.Text =
                string.Empty;


            CargarFechaActual();
            LimpiarResumenInfraccion();
        }

        private void CargarFechaActual()
        {
            txtFechaInfraccion.Text =
                DateTime.Now.ToString(
                    "yyyy-MM-dd"
                );

            txtHoraInfraccion.Text =
                DateTime.Now.ToString(
                    "HH:mm"
                );
        }


        protected void btnFinalizar_Click(
            object sender,
            EventArgs e)
        {
            LimpiarMemoriaTemporal();

            Response.Redirect(
                "~/Inicio.aspx",
                false
            );

            Context.ApplicationInstance
                .CompleteRequest();
        }

        protected void btnCancelar_Click(
            object sender,
            EventArgs e)
        {
            LimpiarMemoriaTemporal();

            Response.Redirect(
                "~/Inicio.aspx",
                false
            );

            Context.ApplicationInstance
                .CompleteRequest();
        }

        private void LimpiarMemoriaTemporal()
        {
            ViewState.Remove(
                "COD_POLICIA"
            );

            ViewState.Remove(
                "DNI_POLICIA"
            );

            ViewState.Remove(
                "COD_INFRACTOR"
            );

            ViewState.Remove(
                "DNI_INFRACTOR"
            );

            ViewState.Remove(
                CLAVE_TABLA
            );
        }

        private void MostrarMensaje(
            string mensaje,
            bool esExito)
        {
            lblMensaje.Text =
                mensaje;

            lblMensaje.CssClass =
                esExito
                ? "mensaje-registro mensaje-exito"
                : "mensaje-registro mensaje-error";

            lblMensaje.Visible =
                true;
        }

        private void OcultarMensaje()
        {
            lblMensaje.Text =
                string.Empty;

            lblMensaje.Visible =
                false;
        }
    }
}