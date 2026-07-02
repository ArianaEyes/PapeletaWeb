<%@ Page Title="Papeletas" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Papeletas.aspx.cs"
    Inherits="DemoPapeletaWeb.Papeletas" %><asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .page-header {
            /* Cambio de color a tonos azules */
            background: linear-gradient(135deg,#0d6efd,#6ea8fe);
            color: white; border-radius: 20px;
            padding: 30px; margin: 30px;
            box-shadow: 0px 10px 25px rgba(0,0,0,.15);
        }
        .page-header h2 { font-weight: bold; }
    </style></asp:Content><asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="page-header">
        <h2><i class="fa-solid fa-file-invoice"></i> Gestión de Papeletas</h2>
        <p>Consulta, registra y administra las papeletas de infracción del sistema.</p>
    </div>

    <div class="container-fluid">
        <div class="card shadow border-0 mb-5">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i> Listado de Papeletas</h5>
            </div>
            <div class="card-body">
                <table class="table table-hover align-middle">
                    <thead class="table-primary">
                        <tr>
                            <th>Cod. Papeleta</th>
                            <th>Cod. Infracción</th>
                            <th>Fecha</th>
                            <th>Hora</th>
                            <th>Lugar</th>
                            <th>Estado</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>P00001</td>
                            <td>I01</td>
                            <td>2026-06-15</td>
                            <td>10:30:00</td>
                            <td>Av. Larco 123</td>
                            <td><span class="badge bg-primary">Pagado</span></td>
                        </tr>
                        <tr>
                            <td>P00002</td>
                            <td>I05</td>
                            <td>2026-06-16</td>
                            <td>14:15:00</td>
                            <td>Calle Los Pinos 45</td>
                            <td><span class="badge bg-warning text-dark">Pendiente</span></td>
                        </tr>
                        <tr>
                            <td>P00003</td>
                            <td>I02</td>
                            <td>2026-06-17</td>
                            <td>09:00:00</td>
                            <td>Av. Javier Prado 500</td>
                            <td><span class="badge bg-danger">Vencido</span></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div></asp:Content>