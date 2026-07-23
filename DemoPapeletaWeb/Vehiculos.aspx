<%@ Page Title="Vehículos" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs"
    Inherits="DemoPapeletaWeb.Vehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/vehiculos.css" rel="stylesheet"/>   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-car text-white"></i> Gestión de Vehículos</h2>
        <p>Consulta y administra los vehículos registrados.</p>
    </div>

    <div class="container-fluid">

        <div class="card shadow border-0 mb-4">
            <div class="card-body">
                <div class="row g-3 align-items-end">
                    <div class="col-md-5">
                        <label class="form-label fw-bold">Buscar por código, DNI, dueño o marca:</label>
                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Ej: V0001, Toyota..."></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-dark w-100" OnClick="btnConsultar_Click" CausesValidation="False" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnNuevo" runat="server" Text="+ Nuevo" CssClass="btn btn-success w-100" OnClick="btnNuevo_Click" CausesValidation="False" />
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow border-0 mb-5">
            <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i> Listado de Vehículos</h5>
                <asp:Label ID="lblCantidad" runat="server" CssClass="badge bg-warning text-dark"></asp:Label>
            </div>

            <div class="card-body table-responsive">
                <asp:GridView ID="gvVehiculos" runat="server" CssClass="table table-hover align-middle"
                    AutoGenerateColumns="false" GridLines="None">
                    <HeaderStyle CssClass="table-dark" />
                    <Columns>
                        <asp:BoundField DataField="Cod_Vehiculo" HeaderText="Código" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI Dueño" />
                        <asp:BoundField DataField="Infractor" HeaderText="Propietario" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" />
                        <asp:BoundField DataField="Color" HeaderText="Color" />
                        <asp:BoundField DataField="Tipo_Vehiculo" HeaderText="Tipo" />
                        <asp:BoundField DataField="Anio_Fabricacion" HeaderText="Año" />
                        <asp:BoundField DataField="Nro_Motor" HeaderText="Nro Motor" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <span class='badge <%# Eval("EstadoTexto").ToString() == "Activo" ? "bg-success" : "bg-danger" %>'>
                                    <%# Eval("EstadoTexto") %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <asp:Panel ID="pnlFormulario" runat="server" Visible="false">
                    <div class="card shadow border-0 mt-4">
                        <div class="card-header bg-dark text-white">
                            <h5 class="mb-0"><i class="fa-solid fa-car"></i> Nuevo Vehículo</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-4 mb-3">
                                    <label>Código de Infractor</label>
                                    <asp:TextBox ID="txtCodInfractor" runat="server" CssClass="form-control" placeholder="Ej: I0001" />
                                    <asp:RequiredFieldValidator ID="rfvInfractor" runat="server"
                                        ControlToValidate="txtCodInfractor"
                                        ErrorMessage="Ingrese el código del infractor."
                                        ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label>Marca</label>
                                    <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select" />
                                    <asp:RequiredFieldValidator ID="rfvMarca" runat="server"
                                        ControlToValidate="ddlMarca" InitialValue=""
                                        ErrorMessage="Seleccione una marca."
                                        ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label>Color</label>
                                    <asp:DropDownList ID="ddlColor" runat="server" CssClass="form-select" />
                                    <asp:RequiredFieldValidator ID="rfvColor" runat="server"
                                        ControlToValidate="ddlColor" InitialValue=""
                                        ErrorMessage="Seleccione un color."
                                        ForeColor="Red" Display="Dynamic" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4 mb-3">
                                    <label>Tipo de Vehículo</label>
                                    <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-select" />
                                    <asp:RequiredFieldValidator ID="rfvTipo" runat="server"
                                        ControlToValidate="ddlTipo" InitialValue=""
                                        ErrorMessage="Seleccione el tipo."
                                        ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label>Año de Fabricación</label>
                                    <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control"
                                        placeholder="Ej: 2020"
                                        onkeypress="return event.charCode >= 48 && event.charCode <= 57;" />
                                    <asp:RequiredFieldValidator ID="rfvAnio" runat="server"
                                        ControlToValidate="txtAnio"
                                        ErrorMessage="Ingrese el año de fabricación."
                                        ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label>Número de Motor</label>
                                    <asp:TextBox ID="txtNroMotor" runat="server" CssClass="form-control"
                                        placeholder="Ej: MOT123456" MaxLength="30" />
                                    <asp:RequiredFieldValidator ID="rfvMotor" runat="server"
                                        ControlToValidate="txtNroMotor"
                                        ErrorMessage="Ingrese el número de motor."
                                        ForeColor="Red" Display="Dynamic" />
                                </div>
                            </div>
                            <div class="text-center mt-3">
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
                                    CssClass="btn btn-success" OnClick="btnGuardar_Click" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"
                                    CssClass="btn btn-secondary ms-2" CausesValidation="False"
                                    OnClick="btnCancelar_Click" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <div class="d-flex justify-content-between align-items-center mt-3">
                    <asp:Button ID="btnAnterior" runat="server" Text="← Anterior"
                        CssClass="btn btn-outline-dark" OnClick="btnAnterior_Click" />
                    <asp:Label ID="lblPagina" runat="server" CssClass="fw-bold fs-5 text-dark" />
                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente →"
                        CssClass="btn btn-outline-dark" OnClick="btnSiguiente_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>