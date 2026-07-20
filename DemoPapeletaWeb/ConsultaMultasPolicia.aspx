<%@ Page Title="Multas por Policía" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaMultasPolicia.aspx.cs" Inherits="DemoPapeletaWeb.ConsultaMultasPolicia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-header {
            background: linear-gradient(135deg,#dc3545,#ff6b6b);
            color: white; border-radius: 20px;
            padding: 30px; margin: 30px 30px 20px 30px;
            box-shadow: 0px 10px 25px rgba(0,0,0,.15);
        }
        .page-header h2 { font-weight: bold; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="page-header">
        <h2><i class="fa-solid fa-user-shield"></i> Multas por Policía</h2>
        <p>Consulta las multas registradas por policía en un rango de fechas.</p>
    </div>

    <div class="container-fluid">
        <div class="card shadow border-0 mb-4">
            <div class="card-body">
                <div class="row g-3 align-items-end">
                    <div class="col-md-3">
                        <label class="form-label fw-bold">Código de Policía:</label>
                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"
                            placeholder="Ej: P00001"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label class="form-label fw-bold">Fecha Inicio:</label>
                        <asp:TextBox ID="txtFecIni" runat="server" CssClass="form-control"
                            TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <label class="form-label fw-bold">Fecha Fin:</label>
                        <asp:TextBox ID="txtFecFin" runat="server" CssClass="form-control"
                            TextMode="Date"></asp:TextBox>
                    </div>
                    <div class="col-md-3 d-flex gap-2">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar"
                            CssClass="btn btn-danger w-50" OnClick="btnConsultar_Click" />
                        <asp:Button ID="btnDescargar" runat="server" Text="⬇ Excel"
                            CssClass="btn btn-warning w-50" OnClick="btnDescargar_Click" />
                    </div>
                </div>
                <div class="mt-2">
                    <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger fw-bold"></asp:Label>
                </div>
            </div>
        </div>
        <div class="card shadow border-0 mb-5">
            <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i> Resultados</h5>
                <div class="d-flex align-items-center gap-2">
                    <asp:Label ID="lblFaltaFrecuente" runat="server" CssClass="badge bg-secondary"></asp:Label>
                    <asp:Label ID="lblCantidad" runat="server" CssClass="badge bg-warning text-dark"></asp:Label>
                </div>
            </div>
            <div class="card-body table-responsive">
                <asp:GridView ID="gvMultas" runat="server" CssClass="table table-hover align-middle"
                    AutoGenerateColumns="false" GridLines="None">
                    <HeaderStyle CssClass="table-danger" />
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
            </div>
        </div>
    </div>
</asp:Content>