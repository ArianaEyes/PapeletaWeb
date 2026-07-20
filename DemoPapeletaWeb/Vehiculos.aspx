<%@ Page Title="Vehículos" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs"
    Inherits="DemoPapeletaWeb.Vehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/vehiculos.css" rel="stylesheet"/>   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-car"></i>Gestión de Vehículos</h2>
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
                    <div class="col-md-3">
                        <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-primary w-100" OnClick="btnConsultar_Click" />
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
                    <HeaderStyle CssClass="table-warning" />
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
            </div>
        </div>

    </div>

</asp:Content>
