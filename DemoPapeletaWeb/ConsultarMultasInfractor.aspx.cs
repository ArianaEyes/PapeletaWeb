using OfficeOpenXml;
using PapeletaWeb_BE;
using PapeletaWeb_BL;
using System;
using System.Collections.Generic;
using System.IO;

namespace DemoPapeletaWeb
{
    public partial class ConsultarMultasInfractor : System.Web.UI.Page
    {
        PapeletaBL objBL = new PapeletaBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                ExcelPackage.License.SetNonCommercialOrganization("ISIL");
        }

        private List<MultaBE> ObtenerDatos()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                lblMensaje.Text = "Ingrese el código del infractor.";
                return null;
            }
            if (string.IsNullOrEmpty(txtFecIni.Text) || string.IsNullOrEmpty(txtFecFin.Text))
            {
                lblMensaje.Text = "Ingrese las fechas de inicio y fin.";
                return null;
            }

            lblMensaje.Text = "";
            DateTime ini = Convert.ToDateTime(txtFecIni.Text);
            DateTime fin = Convert.ToDateTime(txtFecFin.Text);
            return objBL.ListarMultasPorInfractor(txtCodigo.Text.Trim().ToUpper(), ini, fin);
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = ObtenerDatos();
                if (lista == null) return;

                if (lista.Count == 0)
                {
                    lblMensaje.Text = "No se encontraron multas en el período indicado.";
                    gvMultas.DataSource = null;
                    gvMultas.DataBind();
                    lblCantidad.Text = "0 registros";
                    lblDeudaTotal.Text = "";
                    return;
                }

                gvMultas.DataSource = lista;
                gvMultas.DataBind();
                lblCantidad.Text = lista.Count + " registros";

                DateTime ini = Convert.ToDateTime(txtFecIni.Text);
                DateTime fin = Convert.ToDateTime(txtFecFin.Text);
                decimal deuda = objBL.CalcularUitPendiente(txtCodigo.Text.Trim().ToUpper(), ini, fin);
                lblDeudaTotal.Text = "UIT pendientes: " + deuda.ToString("N2");
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = ObtenerDatos();
                if (lista == null || lista.Count == 0)
                {
                    lblMensaje.Text = "No hay datos para descargar.";
                    return;
                }

                DateTime ini = Convert.ToDateTime(txtFecIni.Text);
                DateTime fin = Convert.ToDateTime(txtFecFin.Text);
                decimal deuda = objBL.CalcularUitPendiente(txtCodigo.Text.Trim().ToUpper(), ini, fin);

                ExcelPackage.License.SetNonCommercialOrganization("ISIL");

                using (var pck = new ExcelPackage())
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Multas por Infractor");

                    ws.Cells[1, 1].Value = "SISTEMA DE PAPELETAS - MULTAS POR INFRACTOR";
                    ws.Cells[2, 1].Value = "Infractor: " + txtCodigo.Text.Trim().ToUpper();
                    ws.Cells[3, 1].Value = "Período: " + txtFecIni.Text + " al " + txtFecFin.Text;
                    ws.Cells[4, 1].Value = "UIT pendientes de pago: " + deuda.ToString("N2");
                    ws.Cells[4, 1].Style.Font.Bold = true;
                    ws.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.DarkRed);

                    ws.Cells[6, 1].Value = "Papeleta";
                    ws.Cells[6, 2].Value = "Infractor";
                    ws.Cells[6, 3].Value = "Lugar";
                    ws.Cells[6, 4].Value = "Falta";
                    ws.Cells[6, 5].Value = "Calificación";
                    ws.Cells[6, 6].Value = "UIT";
                    ws.Cells[6, 7].Value = "Fecha";
                    ws.Cells[6, 8].Value = "Policía";
                    ws.Cells[6, 9].Value = "Estado";
                    ws.Cells[6, 1, 6, 9].Style.Font.Bold = true;

                    int fila = 7;
                    foreach (var m in lista)
                    {
                        ws.Cells[fila, 1].Value = m.Cod_Papeleta;
                        ws.Cells[fila, 2].Value = m.Infractor;
                        ws.Cells[fila, 3].Value = m.Lugar_Infraccion;
                        ws.Cells[fila, 4].Value = m.Falta_Cometida;
                        ws.Cells[fila, 5].Value = m.Calificacion;
                        ws.Cells[fila, 6].Value = m.Uit;
                        ws.Cells[fila, 7].Value = m.Fecha_Infraccion.ToString("dd/MM/yyyy");
                        ws.Cells[fila, 8].Value = m.Policia;
                        ws.Cells[fila, 9].Value = m.Estado_Papeleta;
                        fila++;
                    }

                    ws.Cells[fila, 1].Value = "Total registros: " + lista.Count;
                    ws.Cells[fila, 1].Style.Font.Bold = true;

                    ws.Column(1).Width = 15;
                    ws.Column(2).Width = 35;
                    ws.Column(3).Width = 30;
                    ws.Column(4).Width = 40;
                    ws.Column(5).Width = 15;
                    ws.Column(6).Width = 10;
                    ws.Column(7).Width = 15;
                    ws.Column(8).Width = 35;
                    ws.Column(9).Width = 15;

                    string filename = "MultasInfractor_" + txtCodigo.Text.Trim() + "_" + DateTime.Today.ToString("yyyyMMdd") + ".xlsx";

                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment; filename=" + filename + ".xlsx");

                    using (var ms = new MemoryStream())
                    {
                        pck.SaveAs(ms);
                        ms.WriteTo(Response.OutputStream);
                    }
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al generar Excel: " + ex.Message;
            }
        }
    }
}