<%@ Page Title="Infractores" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Infractores.aspx.cs"
    Inherits="DemoPapeletaWeb.Infractores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/infractores.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2>
            <i class="fa-solid fa-user text-white"></i>
            Gestión de Infractores
        </h2>
        <p>Consulta y administra los infractores registrados.</p>
    </div>

    <div class="container-fluid">

        <div class="card shadow border-0 mb-4">
            <div class="card-body">
                <div class="row g-3 align-items-end">
                    <div class="col-md-5">
                        <label class="form-label fw-bold">Buscar por Código de Infractor, DNI, nombres o apellidos:</label>
                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Ej: 78451257 o Carlos"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-danger w-100" OnClick="btnConsultar_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow border-0 mb-5">

            <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i> Listado de Infractores</h5>
                <span><asp:Label ID="lblCantidad" runat="server" CssClass="badge bg-danger text-dark"></asp:Label></span>
            </div>

            <div class="card-body table-responsive">

                <asp:GridView ID="gvInfractores" runat="server" CssClass="table table-hover align-middle"
                    AutoGenerateColumns="false" GridLines="None">
                    <HeaderStyle CssClass="table-danger" />
                    <Columns>
                        <asp:BoundField DataField="Cod_Infractor" HeaderText="CODIGO" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:TemplateField HeaderText="Nombres y Apellidos">
                            <ItemTemplate>
                                <%# Eval("Nombres") %> <%# Eval("Ape_Paterno") %> <%# Eval("Ape_Materno") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="Nro_Brevete" HeaderText="Nro Brevete" />
                        <asp:BoundField DataField="Tipo_Brevete" HeaderText="Tipo Brevete" />
                        <asp:BoundField DataField="Fec_Registro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <span class='badge <%# Eval("EstadoTexto").ToString() == "Activo" ? "bg-success" : "bg-danger" %>'>
                                    <%# Eval("EstadoTexto") %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="d-flex justify-content-between align-items-center mt-3">

                    <asp:Button ID="btnAnterior"
                        runat="server"
                        Text="← Anterior"
                        CssClass="btn btn-outline-danger"
                        OnClick="btnAnterior_Click" />

                    <asp:Label ID="lblPagina"
                        runat="server"
                        CssClass="fw-bold fs-5" />

                    <asp:Button ID="btnSiguiente"
                        runat="server"
                        Text="Siguiente →"
                        CssClass="btn btn-outline-danger"
                        OnClick="btnSiguiente_Click" />

                </div>
            </div>

        </div>

    </div>

</asp:Content>
