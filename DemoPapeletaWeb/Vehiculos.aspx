<%@ Page Title="Vehículos" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Vehiculos.aspx.cs"
    Inherits="DemoPapeletaWeb.Vehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .page-header {
            background: linear-gradient(135deg,#198754,#4dcf8e);
            color: white;
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
        <h2><i class="fa-solid fa-car"></i>Gestión de Vehículos</h2>
        <p>Consulta y administra los vehículos registrados.</p>
    </div>

    <div class="container-fluid">

        <div class="card shadow border-0 mb-5">

            <div class="card-header bg-dark text-white">
                <h5><i class="fa-solid fa-list"></i>Listado de Vehículos</h5>
            </div>

            <div class="card-body table-responsive">

                <table class="table table-hover align-middle">

                    <thead class="table-success">

                        <tr>
                            <th>Código</th>
                            <th>Placa</th>
                            <th>Marca</th>
                            <th>Color</th>
                            <th>Tipo Vehículo</th>
                            <th>Nro Motor</th>
                            <th>Infractor</th>
                            <th>Estado</th>
                        </tr>

                    </thead>

                    <tbody>

                        <tr>
                            <td>VEH001</td>
                            <td>ABC-123</td>
                            <td>Toyota</td>
                            <td>Blanco</td>
                            <td>Sedán</td>
                            <td>MOT123456</td>
                            <td>Carlos Mendoza López</td>
                            <td><span class="badge bg-success">Activo</span></td>
                        </tr>

                        <tr>
                            <td>VEH002</td>
                            <td>BCD-456</td>
                            <td>Kia</td>
                            <td>Rojo</td>
                            <td>SUV</td>
                            <td>MOT987654</td>
                            <td>Ana Torres Quispe</td>
                            <td><span class="badge bg-success">Activo</span></td>
                        </tr>

                        <tr>
                            <td>VEH003</td>
                            <td>CDE-789</td>
                            <td>Hyundai</td>
                            <td>Negro</td>
                            <td>Camioneta</td>
                            <td>MOT456123</td>
                            <td>Luis Ramos Díaz</td>
                            <td><span class="badge bg-danger">Inactivo</span></td>
                        </tr>

                    </tbody>

                </table>

            </div>

        </div>

    </div>

</asp:Content>
