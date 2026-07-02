<%@ Page Title="Policías" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Policias.aspx.cs"
    Inherits="DemoPapeletaWeb.Policias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-header {
            background: linear-gradient(135deg,#0d6efd,#4f9dff);
            color: white; border-radius: 20px;
            padding: 30px; margin: 30px;
            box-shadow: 0px 10px 25px rgba(0,0,0,.15);
        }
        .page-header h2 { font-weight: bold; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-user-shield"></i> Gestión de Policías</h2>
        <p>Consulta, registra y administra los policías de tránsito del sistema.</p>
    </div>

    <div class="container-fluid">
        <div class="card shadow border-0 mb-5">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i> Listado de Policías</h5>
            </div>
            <div class="card-body">
                <table class="table table-hover align-middle">
                    <thead class="table-primary">
                        <tr>
                            <th>Código</th>
                            <th>Nombres</th>
                            <th>DNI</th>
                            <th>Rango</th>
                            <th>Estado</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>P00001</td>
                            <td>Carlos Ramos Soto</td>
                            <td>12345678</td>
                            <td>Teniente</td>
                            <td><span class="badge bg-success">Activo</span></td>
                        </tr>
                        <tr>
                            <td>P00002</td>
                            <td>José Flores Vargas</td>
                            <td>87654321</td>
                            <td>Capitán</td>
                            <td><span class="badge bg-success">Activo</span></td>
                        </tr>
                        <tr>
                            <td>P00003</td>
                            <td>Pedro Ruiz Huaman</td>
                            <td>56781234</td>
                            <td>Suboficial</td>
                            <td><span class="badge bg-danger">Inactivo</span></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

</asp:Content>