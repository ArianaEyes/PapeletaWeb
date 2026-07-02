<%@ Page Title="Papeletas" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Papeletas.aspx.cs"
    Inherits="DemoPapeletaWeb.Papeletas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-header {
            background: linear-gradient(135deg,#0d6efd,#6ea8fe);
            color: white;
            border-radius: 20px;
            padding: 30px;
            margin: 30px;
            box-shadow: 0px 10px 25px rgba(0,0,0,.15);
        }

        .table-responsive {
            border-radius: 15px;
        }

        .table {
            font-size: 14px;
            white-space: nowrap;
        }

            .table thead th {
                text-align: center;
                vertical-align: middle;
            }

            .table tbody td {
                vertical-align: middle;
            }

        .badge {
            font-size: 13px;
            padding: 7px 12px;
            border-radius: 20px;
        }

        .card {
            border-radius: 18px;
        }

        .card-header {
            font-size: 18px;
            font-weight: bold;
        }

        .page-header h2 {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-file-invoice"></i>Gestión de Papeletas</h2>
        <p>Consulta, registra y administra las papeletas de infracción del sistema.</p>
    </div>

    <div class="container-fluid">
        <div class="card shadow border-0 mb-5">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i>Listado de Papeletas</h5>
            </div>
            <div class="card-body table-responsive">

                <table class="table table-striped table-hover table-bordered align-middle">

                    <thead class="table-primary">

                        <tr class="text-center">
                            <th>Cod. Papeleta</th>
                            <th>Cod. Infracción</th>
                            <th>Cod. Policía</th>
                            <th>Cod. Vehículo</th>
                            <th>Fecha</th>
                            <th>Hora</th>
                            <th>Referencia</th>
                            <th>Información Adicional</th>
                            <th>Observaciones</th>
                            <th>Estado</th>
                            <th>Fec. Registro</th>
                            <th>Usuario Registro</th>
                            <th>Fec. Modificación</th>
                            <th>Usuario Modificación</th>
                        </tr>

                    </thead>

                    <tbody>

                        <tr>
                            <td>PAP0001</td>
                            <td>I001</td>
                            <td>POL001</td>
                            <td>VEH001</td>
                            <td>15/06/2026</td>
                            <td>10:35</td>
                            <td>Av. Javier Prado</td>
                            <td>Exceso de velocidad</td>
                            <td>Sin novedades</td>
                            <td class="text-center">
                                <span class="badge bg-success">Activo</span>
                            </td>
                            <td>15/06/2026</td>
                            <td>Administrador</td>
                            <td>16/06/2026</td>
                            <td>Administrador</td>
                        </tr>

                        <tr>
                            <td>PAP0002</td>
                            <td>I003</td>
                            <td>POL003</td>
                            <td>VEH005</td>
                            <td>18/06/2026</td>
                            <td>18:20</td>
                            <td>Panamericana Sur</td>
                            <td>Conducía ebrio</td>
                            <td>Vehículo internado</td>
                            <td class="text-center">
                                <span class="badge bg-danger">Inactivo</span>
                            </td>
                            <td>18/06/2026</td>
                            <td>Administrador</td>
                            <td>20/06/2026</td>
                            <td>Administrador</td>
                        </tr>

                        <tr>
                            <td>PAP0003</td>
                            <td>I002</td>
                            <td>POL002</td>
                            <td>VEH010</td>
                            <td>20/06/2026</td>
                            <td>09:10</td>
                            <td>Av. Arequipa</td>
                            <td>No llevaba cinturón</td>
                            <td>Primera infracción</td>
                            <td class="text-center">
                                <span class="badge bg-success">Activo</span>
                            </td>
                            <td>20/06/2026</td>
                            <td>Administrador</td>
                            <td>20/06/2026</td>
                            <td>Administrador</td>
                        </tr>

                    </tbody>

                </table>

            </div>
        </div>
    </div>
</asp:Content>
