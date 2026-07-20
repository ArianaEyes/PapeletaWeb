<%@ Page Title="Policías" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Policias.aspx.cs"
    Inherits="DemoPapeletaWeb.Policias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/infractores.css" rel="stylesheet"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-user-shield"></i>Gestión de Policías</h2>
        <p>Consulta y administra los policías de tránsito registrados.</p>
    </div>

    <div class="container-fluid">

        <div class="card shadow border-0 mb-4">
            <div class="card-body">
                <div class="row g-3 align-items-end">
                    <div class="col-md-5">
                        <label class="form-label fw-bold">Buscar por Código, DNI o nombres:</label>
                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Ej: 12345678 o Ramos"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary w-100" OnClick="btnConsultar_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow border-0 mb-5">
            <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i> Listado de Policías</h5>
                <asp:Label ID="lblCantidad" runat="server" CssClass="badge bg-warning text-dark"></asp:Label>
            </div>

            <div class="card-body table-responsive">
                <asp:GridView ID="gvPolicias" runat="server" CssClass="table table-hover align-middle"
                    AutoGenerateColumns="false" GridLines="None">
                    <HeaderStyle CssClass="table-warning" />
                    <Columns>
                        <asp:BoundField DataField="Cod_Policia" HeaderText="Código" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:TemplateField HeaderText="Nombres y Apellidos">
                            <ItemTemplate>
                                <%# Eval("Nombre") %> <%# Eval("Paterno") %> <%# Eval("Materno") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Rango" HeaderText="Rango" />
                        <asp:BoundField DataField="SexoTexto" HeaderText="Sexo" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fec. Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Distrito" HeaderText="Distrito" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <span class='badge <%# Eval("EstadoTexto").ToString() == "Activo" ? "bg-success" : "bg-danger" %>'>
                                    <%# Eval("EstadoTexto") %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>

</asp:Content>