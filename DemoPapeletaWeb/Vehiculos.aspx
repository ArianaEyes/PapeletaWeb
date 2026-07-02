<%@ Page Title="Vehículos" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs"
    Inherits="DemoPapeletaWeb.Vehiculos" %><asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-header {
            /* Degradado en tonos verdes (success) */
            background: linear-gradient(135deg,#198754,#4dcf8e);
            color: white; 
            border-radius: 20px;
            padding: 30px; margin: 30px;
            box-shadow: 0px 10px 25px rgba(0,0,0,.15);
        }
        .page-header h2 { font-weight: bold; }
    </style></asp:Content><asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-car"></i> Gestión de Vehículos</h2>
        <p>Consulta, registra y administra el parque automotor del sistema.</p>
    </div>

    <div class="container-fluid">
        <div class="card shadow border-0 mb-5">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i> Listado de Vehículos</h5>
            </div>
            <div class="card-body">
                <table class="table table-hover align-middle">
                    <thead class="table-success">
                        <tr>
                            <th>Cod. Vehículo</th>
                            <th>Año</th>
                            <th>Nro. Motor</th>
                            <th>Tipo</th>
                            <th>Estado</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>V00001</td>
                            <td>2024</td>
                            <td>MOT-998877</td>
                            <td>Sedán</td>
                            <td><span class="badge bg-success">Activo</span></td>
                        </tr>
                        <tr>
                            <td>V00002</td>
                            <td>2022</td>
                            <td>MOT-112233</td>
                            <td>Camioneta</td>
                            <td><span class="badge bg-success">Activo</span></td>
                        </tr>
                        <tr>
                            <td>V00003</td>
                            <td>2020</td>
                            <td>MOT-445566</td>
                            <td>Motocicleta</td>
                            <td><span class="badge bg-danger">Inactivo</span></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div></asp:Content>