<%@ Page Title="Papeletas" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Papeletas.aspx.cs"
    Inherits="DemoPapeletaWeb.Papeletas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-header {
            background: linear-gradient(135deg,#ffc107,#ffda6a);
            color: #212529;
            border-radius: 20px;
            padding: 30px;
            margin: 30px;
            box-shadow: 0px 10px 25px rgba(0,0,0,.15);
        }

        .table-responsive {
            border-radius: 15px;
        }

        .table {
            font-size: 14px;
            white-space: nowrap;
        }

        .table thead th {
            text-align: center;
            vertical-align: middle;
        }

        .table tbody td {
            vertical-align: middle;
        }

        .badge {
            font-size: 13px;
            padding: 7px 12px;
            border-radius: 20px;
        }

        .card {
            border-radius: 18px;
        }

        .card-header {
            font-size: 18px;
            font-weight: bold;
        }

        .page-header h2 {
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2>
            <i class="fa-solid fa-file-circle-exclamation text-dark"></i>
            Gestión de Papeletas
        </h2>
        <p>Consulta y administra las papeletas registradas.</p>
    </div>

    <div class="container-fluid">

        <div class="card shadow border-0 mb-4">
            <div class="card-body">
                <div class="row g-3 align-items-end">
                    <div class="col-md-5">
                        <label class="form-label fw-bold">
                            Buscar por código, infractor, lugar, policía o estado:
                        </label>

                        <asp:TextBox ID="txtBuscar"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Ej: P00001, Pedro Salas, PENDIENTE...">
                        </asp:TextBox>
                    </div>

                    <div class="col-md-3">
                        <asp:Button ID="btnConsultar"
                            runat="server"
                            Text="Consultar"
                            CssClass="btn btn-warning w-100"
                            OnClick="btnConsultar_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow border-0 mb-5">

            <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">

                <h5 class="mb-0">
                    <i class="fa-solid fa-list"></i>
                    Listado de Papeletas
                </h5>

                <asp:Button 
                    ID="btnNuevo"
                    runat="server"
                    Text="+ Nueva Papeleta"
                    CssClass="btn btn-warning"
                    OnClick="btnNuevo_Click"/>

                <asp:Label ID="lblCantidad"
                    runat="server"
                    CssClass="badge bg-warning text-dark">
                </asp:Label>

            </div>

            <div class="card-body table-responsive">

                <asp:GridView ID="gvPapeletas"
                    runat="server"
                    CssClass="table table-hover align-middle"
                    AutoGenerateColumns="false"
                    GridLines="None"
                    OnRowCommand="gvPapeletas_RowCommand"
                    EmptyDataText="No hay papeletas registradas.">

                    <HeaderStyle CssClass="table-warning" />

                    <Columns>

                        <asp:BoundField DataField="Cod_Papeleta" HeaderText="Código" />
                        <asp:BoundField DataField="Infractor" HeaderText="Infractor" />
                        <asp:BoundField DataField="Lugar_Infraccion" HeaderText="Lugar" />
                        <asp:BoundField DataField="Falta_Cometida" HeaderText="Falta" />
                        <asp:BoundField DataField="Uit" HeaderText="UIT" DataFormatString="{0:N2}" />
                        <asp:BoundField DataField="Fecha_Infraccion" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Policia" HeaderText="Policía" />

                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>

                                <span class='badge <%# Eval("Estado_Papeleta").ToString() == "CANCELADO" ? "bg-success" : "bg-danger" %>'>
                                    <%# Eval("Estado_Papeleta") %>
                                </span>

                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>

                            <asp:Button
                             ID="btnEditar"
                             runat="server"
                             Text="Editar"
                             CssClass="btn btn-sm btn-primary"
                             CommandName="Editar"
                             CommandArgument='<%# Eval("Cod_Papeleta") %>' />


                            <asp:Button
                             ID="btnEliminar"
                             runat="server"
                             Text="Eliminar"
                             CssClass="btn btn-sm btn-danger"
                             CommandName="Eliminar"
                             CommandArgument='<%# Eval("Cod_Papeleta") %>' />

                            </ItemTemplate>

                         </asp:TemplateField>

                    </Columns>

                </asp:GridView>

                <asp:Panel ID="pnlFormulario"
                    runat="server"
                    Visible="false">
                    <div class="card shadow border-0 mt-4">
                        <div class="card-header bg-warning">
                            <h5>
                                <i class="fa-solid fa-file-circle-plus"></i>
                                Nueva / Editar Papeleta
                            </h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-4 mb-3">
                                    <label>Vehículo</label>
                                    <asp:DropDownList
                                        ID="ddlVehiculo"
                                        runat="server"
                                        CssClass="form-select">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label>Infracción</label>
                                    <asp:DropDownList
                                        ID="ddlInfraccion"
                                        runat="server"
                                        CssClass="form-select">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label>Policía</label>
                                    <asp:DropDownList
                                        ID="ddlPolicia"
                                        runat="server"
                                        CssClass="form-select">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 mb-3">
                                    <label>Lugar infracción</label>
                                    <asp:TextBox
                                        ID="txtLugar"
                                        runat="server"
                                        CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-3 mb-3">
                                    <label>Fecha</label>
                                    <asp:TextBox
                                        ID="txtFecha"
                                        runat="server"
                                        TextMode="Date"
                                        CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-3 mb-3">
                                    <label>Hora</label>
                                    <asp:TextBox
                                        ID="txtHora"
                                        runat="server"
                                        TextMode="Time"
                                        CssClass="form-control">
                                    </asp:TextBox>
                                </div>
                            </div>
                            <div class="mb-3">
                                <label>Información adicional</label>
                                <asp:TextBox
                                    ID="txtInfo"
                                    runat="server"
                                    CssClass="form-control">
                                </asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label>Observaciones</label>
                                <asp:TextBox
                                    ID="txtObservaciones"
                                    runat="server"
                                    CssClass="form-control"
                                    TextMode="MultiLine">
                                </asp:TextBox>
                            </div>
                            <div class="text-center">
                                <asp:Button
                                    ID="btnGuardar"
                                    runat="server"
                                    Text="Guardar"
                                    CssClass="btn btn-success"
                                    OnClick="btnGuardar_Click" />
                                <asp:Button
                                    ID="btnCancelar"
                                    runat="server"
                                    Text="Cancelar"
                                    CssClass="btn btn-secondary ms-2"
                                    CausesValidation="False"
                                    OnClick="btnCancelar_Click" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <div class="d-flex justify-content-between align-items-center mt-3">

                    <asp:Button ID="btnAnterior"
                        runat="server"
                        Text="← Anterior"
                        CssClass="btn btn-outline-warning"
                        OnClick="btnAnterior_Click" />

                    <asp:Label ID="lblPagina"
                        runat="server"
                        CssClass="fw-bold fs-5 text-warning" />

                    <asp:Button ID="btnSiguiente"
                        runat="server"
                        Text="Siguiente →"
                        CssClass="btn btn-outline-warning"
                        OnClick="btnSiguiente_Click" />

                </div>

            </div>

        </div>

    </div>

</asp:Content>