<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="DemoPapeletaWeb.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background-color: #f8f9fa;
        }

        .card-icon {
            font-size: 2rem;
            color: #0d6efd;
        }

        .chart-container {
            position: relative;
            height: auto;
            width: 100%;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4 text-center">Dashboard de Infracciones</h1>

        <div class="row mb-4">
            <div class="col-md-4">
                <div class="card text-center shadow-sm h-100">
                    <div class="card-body">
                        <h5 class="card-title text-primary"><i class="bi bi-file-earmark-text card-icon"></i>Total Papeletas</h5>
                        <p class="card-text fs-3">
                            <asp:Label ID="lblTotalPapeletas" runat="server" Text="0"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card text-center shadow-sm h-100">
                    <div class="card-body">
                        <h5 class="card-title text-success"><i class="bi bi-people-fill card-icon" style="color: #198754;"></i>Total Infractores</h5>
                        <p class="card-text fs-3">
                            <asp:Label ID="lblTotalInfractores" runat="server" Text="0"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card text-center shadow-sm h-100">
                    <div class="card-body">
                        <h5 class="card-title text-warning"><i class="bi bi-car-front-fill card-icon" style="color: #ffc107;"></i>Total Vehículos</h5>
                        <p class="card-text fs-3">
                            <asp:Label ID="lblTotalVehiculos" runat="server" Text="0"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-12">
                <div class="card shadow-sm">
                    <div class="card-header bg-white">
                        <h5 class="mb-0">Estadísticas de Tránsito</h5>
                    </div>
                    <div class="card-body">
                        <div class="chart-container">
                            <table class="table">
                                <!-- FILA 1 -->
                                <tr>
                                    <td align="center">
                                        <asp:Chart ID="grafAnual" runat="server" Width="400px">
                                            <Series>
                                                <asp:Series Name="Series1"></asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                            </ChartAreas>
                                            <Titles>
                                                <asp:Title BackColor="Silver" Font="Microsoft Sans Serif, 10pt, style=Bold" Text="Papeletas por Año"></asp:Title>
                                            </Titles>
                                        </asp:Chart>
                                    </td>
                                    <td align="center">
                                        <asp:Chart ID="grafTop" runat="server" Width="400px">
                                            <Legends>
                                                <asp:Legend Name="Legend1" Docking="Right" Alignment="Center" Font="Microsoft Sans Serif, 9pt"></asp:Legend>
                                            </Legends>
                                            <Series>
                                                <asp:Series Name="Series1"></asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                            </ChartAreas>
                                            <Titles>
                                                <asp:Title BackColor="Silver" Font="Microsoft Sans Serif, 10pt, style=Bold" Text="Top 5 Infracciones"></asp:Title>
                                            </Titles>
                                        </asp:Chart>
                                    </td>
                                </tr>
                                <!-- FILA 2 -->
                                <tr>
                                    <td align="center">
                                        <asp:Chart ID="grafMes" runat="server" Width="400px">
                                            <Series>
                                                <asp:Series Name="Series1"></asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                            </ChartAreas>
                                            <Titles>
                                                <asp:Title BackColor="Silver" Font="Microsoft Sans Serif, 10pt, style=Bold" Text="Papeletas por Mes"></asp:Title>
                                            </Titles>
                                        </asp:Chart>
                                    </td>
                                    <td align="center">
                                        <asp:Chart ID="grafVehiculo" runat="server" Width="400px">
                                            <Legends>
                                                <asp:Legend Name="Legend1" Docking="Right" Alignment="Center" Font="Microsoft Sans Serif, 10pt"></asp:Legend>
                                            </Legends>
                                            <Series>
                                                <asp:Series Name="Series1"></asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                                            </ChartAreas>
                                            <Titles>
                                                <asp:Title BackColor="Silver" Font="Microsoft Sans Serif, 10pt, style=Bold" Text="Infracciones por Vehículo"></asp:Title>
                                            </Titles>
                                        </asp:Chart>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
