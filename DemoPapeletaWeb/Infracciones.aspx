<%@ Page Title="Infracciones" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Infracciones.aspx.cs"
    Inherits="DemoPapeletaWeb.Infracciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/infractores.css" rel="stylesheet" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-triangle-exclamation"></i>Gestión de Infracciones</h2>
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
                    <div class="col-md-3">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary w-100" OnClick="btnConsultar_Click" />
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
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>

</asp:Content>