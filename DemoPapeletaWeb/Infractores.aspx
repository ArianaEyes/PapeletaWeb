<%@ Page Title="Infractores" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Infractores.aspx.cs"
    Inherits="DemoPapeletaWeb.Infractores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-header {
            background: linear-gradient(135deg,#ffc107,#ffdb70);
            color: #333;
            border-radius: 20px;
            padding: 30px;
            margin: 30px;
            box-shadow: 0 10px 25px rgba(0,0,0,.15);
        }

            .page-header h2 {
                font-weight: bold;
            }

        .table th {
            white-space: nowrap;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-user"></i>Gestión de Infractores</h2>
        <p>Consulta y administra los infractores registrados.</p>
    </div>

    <div class="container-fluid">

        <div class="card shadow border-0 mb-5">

            <div class="card-header bg-dark text-white">
                <h5><i class="fa-solid fa-list"></i>Listado de Infractores</h5>
            </div>

            <div class="card-body table-responsive">

                <table class="table table-hover align-middle">

                    <thead class="table-warning">
                        <tr>
                            <th>DNI</th>
                            <th>Nombres y Apellidos</th>
                            <th>Correo</th>
                            <th>Dirección</th>
                            <th>Nro Brevete</th>
                            <th>Tipo Brevete</th>
                            <th>Fecha Registro</th>
                            <th>Estado</th>
                        </tr>
                    </thead>

                    <tbody>

                        <tr>
                            <td>45678901</td>
                            <td>Carlos Mendoza López</td>
                            <td>cmendoza@gmail.com</td>
                            <td>Av. Primavera 123</td>
                            <td>Q12345678</td>
                            <td>A-IIb</td>
                            <td>15/06/2026</td>
                            <td><span class="badge bg-success">Activo</span></td>
                        </tr>

                        <tr>
                            <td>32145678</td>
                            <td>Ana Torres Quispe</td>
                            <td>atorres@gmail.com</td>
                            <td>Jr. Los Olivos 254</td>
                            <td>Q98765432</td>
                            <td>A-I</td>
                            <td>18/06/2026</td>
                            <td><span class="badge bg-danger">Inactivo</span></td>
                        </tr>

                        <tr>
                            <td>78901234</td>
                            <td>Luis Ramos Díaz</td>
                            <td>lramos@gmail.com</td>
                            <td>Av. Perú 455</td>
                            <td>Q44556677</td>
                            <td>A-IIIa</td>
                            <td>20/06/2026</td>
                            <td><span class="badge bg-success">Activo</span></td>
                        </tr>

                    </tbody>

                </table>

            </div>

        </div>

    </div>

</asp:Content>
