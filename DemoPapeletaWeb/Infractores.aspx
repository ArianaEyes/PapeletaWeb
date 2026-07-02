<%@ Page Title="Infractores" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Infractores.aspx.cs"
    Inherits="DemoPapeletaWeb.Infractores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-header {
            background: linear-gradient(135deg,#198754,#4dcf8e);
            color: white; border-radius: 20px;
            padding: 30px; margin: 30px;
            box-shadow: 0px 10px 25px rgba(0,0,0,.15);
        }
        .page-header h2 { font-weight: bold; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-user"></i> Gestión de Infractores</h2>
        <p>Consulta, registra y administra los infractores del sistema.</p>
    </div>

    <div class="container-fluid">
        <div class="card shadow border-0 mb-5">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i> Listado de Infractores</h5>
            </div>
            <div class="card-body">
                <table class="table table-hover align-middle">
                    <thead class="table-success">
                        <tr>
                            <th>Código</th>
                            <th>Nombres</th>
                            <th>DNI</th>
                            <th>Correo</th>
                            <th>Estado</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>I0001</td>
                            <td>Carlos Mendoza López</td>
                            <td>45678901</td>
                            <td>cmendoza@gmail.com</td>
                            <td><span class="badge bg-success">Activo</span></td>
                        </tr>
                        <tr>
                            <td>I0002</td>
                            <td>Ana Torres Quispe</td>
                            <td>32145678</td>
                            <td>atorres@gmail.com</td>
                            <td><span class="badge bg-danger">Inactivo</span></td>
                        </tr>
                        <tr>
                            <td>I0003</td>
                            <td>Luis Ramos Díaz</td>
                            <td>78901234</td>
                            <td>lramos@gmail.com</td>
                            <td><span class="badge bg-success">Activo</span></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

</asp:Content>