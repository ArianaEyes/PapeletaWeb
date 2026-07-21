<%@ Page Title="Multas por Vehículo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaMultasVehiculo.aspx.cs" Inherits="DemoPapeletaWeb.ConsultaMultasVehiculo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-header {
            background: linear-gradient(135deg,#212529,#495057);
            color: white;
            border-radius: 20px;
            padding: 30px;
            margin: 30px 30px 20px 30px;
            box-shadow: 0px 10px 25px rgba(0,0,0,.15);
        }

        .page-header h2 {
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-car me-2"></i>Multas por Vehículo</h2>
        <p>Consulta las multas registradas por vehículo en un rango de fechas.</p>
    </div>

    <div class="container-fluid">

        <!-- Filtros -->
        <div class="card shadow border-0 mb-4">
            <div class="card-body">

                <div class="row g-3 align-items-end">

                    <div class="col-md-3">
                        <label class="form-label fw-bold">Código de Vehículo:</label>
                        <asp:TextBox ID="txtCodigo"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Ej: V00001">
                        </asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <label class="form-label fw-bold">Fecha Inicio:</label>
                        <asp:TextBox ID="txtFecIni"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Date">
                        </asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <label class="form-label fw-bold">Fecha Fin:</label>
                        <asp:TextBox ID="txtFecFin"
                            runat="server"
                            CssClass="form-control"
                            TextMode="Date">
                        </asp:TextBox>
                    </div>

                    <div class="col-md-3 d-flex gap-2">

                        <asp:Button ID="btnConsultar"
                            runat="server"
                            Text="Consultar"
                            CssClass="btn btn-dark w-50"
                            OnClick="btnConsultar_Click" />

                        <asp:Button ID="btnDescargar"
                            runat="server"
                            Text="⬇ Excel"
                            CssClass="btn btn-outline-dark w-50"
                            OnClick="btnDescargar_Click" />

                    </div>

                </div>

                <div class="mt-3">
                    <asp:Label ID="lblMensaje"
                        runat="server"
                        CssClass="text-danger fw-bold">
                    </asp:Label>
                </div>

            </div>
        </div>

        <!-- Resultados -->
        <div class="card shadow border-0 mb-5">

            <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">

                <h5 class="mb-0">
                    <i class="fa-solid fa-list me-2"></i>Resultados
                </h5>

                <div class="d-flex align-items-center gap-2">

                    <asp:Label ID="lblResumen"
                        runat="server"
                        CssClass="badge bg-light text-dark fs-6">
                    </asp:Label>

                    <asp:Label ID="lblCantidad"
                        runat="server"
                        CssClass="badge bg-white text-dark fs-6">
                    </asp:Label>

                </div>

            </div>

            <div class="card-body table-responsive">

                <asp:GridView ID="gvMultas"
                    runat="server"
                    CssClass="table table-hover align-middle"
                    AutoGenerateColumns="false"
                    GridLines="None">

                    <HeaderStyle CssClass="table-dark" />

                    <Columns>

                        <asp:BoundField DataField="Cod_Papeleta" HeaderText="Papeleta" />
                        <asp:BoundField DataField="Infractor" HeaderText="Infractor" />
                        <asp:BoundField DataField="Lugar_Infraccion" HeaderText="Lugar" />
                        <asp:BoundField DataField="Falta_Cometida" HeaderText="Falta" />
                        <asp:BoundField DataField="Calificacion" HeaderText="Calificación" />
                        <asp:BoundField DataField="Uit" HeaderText="UIT" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Fecha_Infraccion" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Policia" HeaderText="Policía" />
                        <asp:BoundField DataField="Estado_Papeleta" HeaderText="Estado" />

                    </Columns>

                </asp:GridView>

                <div class="d-flex justify-content-between align-items-center mt-3">

                    <asp:Button ID="btnAnterior"
                        runat="server"
                        Text="← Anterior"
                        CssClass="btn btn-outline-dark"
                        OnClick="btnAnterior_Click" />

                    <asp:Label ID="lblPagina"
                        runat="server"
                        CssClass="fw-bold fs-5 text-dark">
                    </asp:Label>

                    <asp:Button ID="btnSiguiente"
                        runat="server"
                        Text="Siguiente →"
                        CssClass="btn btn-outline-dark"
                        OnClick="btnSiguiente_Click" />

                </div>

            </div>

        </div>

    </div>

</asp:Content>