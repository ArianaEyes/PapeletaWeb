<%@ Page Title="Infracciones" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Infracciones.aspx.cs"
    Inherits="DemoPapeletaWeb.Infracciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/infracciones.css" rel="stylesheet" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-triangle-exclamation text-dark"></i> Gestión de Infracciones</h2>
        <p>Consulta y administra los tipos de infracción registrados.</p>
    </div>

    <div class="container-fluid">

        <div class="card shadow border-0 mb-4">
            <div class="card-body">
                <div class="row g-3 align-items-end">
                    <div class="col-md-5">
                        <label class="form-label fw-bold">Buscar por código, descripción o calificación:</label>
                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Ej: G02, luz roja, GRAVE..."></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-warning w-100" OnClick="btnConsultar_Click" CausesValidation="False" />
                    </div>
                    <div class="col-md-2">
                        <asp:Button ID="btnNuevo" runat="server" Text="+ Nuevo" CssClass="btn btn-success w-100" OnClick="btnNuevo_Click" CausesValidation="False" />
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow border-0 mb-5">
            <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i> Listado de Infracciones</h5>
                <asp:Label ID="lblCantidad" runat="server" CssClass="badge bg-warning text-dark"></asp:Label>
            </div>

            <div class="card-body table-responsive">
                <asp:GridView ID="gvInfracciones" runat="server" CssClass="table table-hover align-middle"
                    AutoGenerateColumns="false" GridLines="None" EmptyDataText="No hay infracciones registradas.">
                    <HeaderStyle CssClass="table-warning" />
                    <Columns>
                        <asp:BoundField DataField="Cod_Infraccion" HeaderText="Código" />
                        <asp:BoundField DataField="Descripcion_Sancion" HeaderText="Descripción" />
                        <asp:TemplateField HeaderText="Calificación">
                            <ItemTemplate>
                                <span class='badge <%# ObtenerClaseBadge(Eval("Calificacion")) %>'>
                                    <%# Eval("Calificacion") %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Puntos" HeaderText="Puntos" />
                        <asp:BoundField DataField="Uit" HeaderText="UIT" DataFormatString="{0:N2}" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEliminar" runat="server" Text="Inactivar"
                                    CssClass="btn btn-danger btn-sm"
                                    CommandArgument='<%# Eval("Cod_Infraccion") %>'
                                    CausesValidation="False"
                                    OnClientClick="return confirm('¿Desea inactivar esta infracción?');"
                                    OnClick="btnEliminar_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <asp:Panel ID="pnlFormulario" runat="server" Visible="false">
                    <div class="card shadow border-0 mt-4">
                        <div class="card-header bg-warning text-dark">
                            <h5 class="mb-0"><i class="fa-solid fa-triangle-exclamation"></i> Nueva Infracción</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-8 mb-3">
                                    <label>Descripción de Sanción</label>
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" MaxLength="200" />
                                    <asp:RequiredFieldValidator ID="rfvDesc" runat="server" ControlToValidate="txtDescripcion"
                                        ErrorMessage="Ingrese la descripción." ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-md-4 mb-3">
                                    <label>Calificación</label>
                                    <asp:DropDownList ID="ddlCalificacion" runat="server" CssClass="form-select">
                                        <asp:ListItem Value="">-- Seleccione --</asp:ListItem>
                                        <asp:ListItem Value="LEVE">LEVE</asp:ListItem>
                                        <asp:ListItem Value="GRAVE">GRAVE</asp:ListItem>
                                        <asp:ListItem Value="MUY GRAVE">MUY GRAVE</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvCalif" runat="server" ControlToValidate="ddlCalificacion"
                                        InitialValue="" ErrorMessage="Seleccione calificación." ForeColor="Red" Display="Dynamic" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3 mb-3">
                                    <label>Puntos</label>
                                    <asp:TextBox ID="txtPuntos" runat="server" CssClass="form-control"
                                        onkeypress="return event.charCode >= 48 && event.charCode <= 57;" />
                                    <asp:RequiredFieldValidator ID="rfvPuntos" runat="server" ControlToValidate="txtPuntos"
                                        ErrorMessage="Ingrese los puntos." ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-md-3 mb-3">
                                    <label>UIT</label>
                                    <asp:TextBox ID="txtUit" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="rfvUit" runat="server" ControlToValidate="txtUit"
                                        ErrorMessage="Ingrese el valor UIT." ForeColor="Red" Display="Dynamic" />
                                </div>
                                <div class="col-md-6 mb-3">
                                    <label>Medida Preventiva</label>
                                    <asp:TextBox ID="txtMedida" runat="server" CssClass="form-control" MaxLength="50" />
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
                    <asp:Button ID="btnAnterior" runat="server" Text="← Anterior" CssClass="btn btn-outline-warning" OnClick="btnAnterior_Click" />
                    <asp:Label ID="lblPagina" runat="server" CssClass="fw-bold fs-5" />
                    <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente →" CssClass="btn btn-outline-warning" OnClick="btnSiguiente_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>