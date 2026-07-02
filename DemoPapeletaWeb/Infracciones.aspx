<%@ Page Title="Infracciones" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Infracciones.aspx.cs"
    Inherits="DemoPapeletaWeb.Infracciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/infracciones.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2>
            <i class="fa-solid fa-triangle-exclamation"></i>
            Gestión de Infracciones
        </h2>
        <p>Consulta, registra y administra las infracciones del sistema.</p>
    </div>

    <div class="container-fluid">

        <div class="card shadow border-0 mb-5">

            <div class="card-header bg-dark text-white">
                <h5 class="mb-0">
                    <i class="fa-solid fa-list"></i>
                    Listado de Infracciones
                </h5>
            </div>

            <div class="card-body table-responsive">

                <table class="table table-hover align-middle">

                    <thead class="table-warning">

                        <tr>
                            <th>Código</th>
                            <th>Descripción</th>
                            <th>Sanción</th>
                            <th>Calificación</th>
                            <th>Puntos</th>
                            <th>UIT</th>
                            <th>Medida Preventiva</th>
                            <th>Fecha Registro</th>
                            <th>Estado</th>
                        </tr>

                    </thead>

                    <tbody>

                        <tr>
                            <td>I001</td>
                            <td>Exceso de velocidad</td>
                            <td>Multa</td>
                            <td>Grave</td>
                            <td>50</td>
                            <td>8%</td>
                            <td>Retención de licencia</td>
                            <td>15/06/2026</td>
                            <td>
                                <span class="badge bg-success">
                                    Activo
                                </span>
                            </td>
                        </tr>

                        <tr>
                            <td>I002</td>
                            <td>No usar cinturón</td>
                            <td>Multa</td>
                            <td>Leve</td>
                            <td>20</td>
                            <td>4%</td>
                            <td>Amonestación</td>
                            <td>16/06/2026</td>
                            <td>
                                <span class="badge bg-success">
                                    Activo
                                </span>
                            </td>
                        </tr>

                        <tr>
                            <td>I003</td>
                            <td>Conducir ebrio</td>
                            <td>Multa</td>
                            <td>Muy Grave</td>
                            <td>100</td>
                            <td>50%</td>
                            <td>Internamiento del vehículo</td>
                            <td>17/06/2026</td>
                            <td>
                                <span class="badge bg-danger">
                                    Inactivo
                                </span>
                            </td>
                        </tr>

                    </tbody>

                </table>

            </div>

        </div>

    </div>

</asp:Content>