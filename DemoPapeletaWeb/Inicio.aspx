<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Inicio.aspx.cs"
    Inherits="DemoPapeletaWeb.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/inicio.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="banner">
        <h2>¡Bienvenid@!</h2>
        <p>Administra infractores, vehículos, policías y papeletas desde un solo lugar.</p>
    </div>

    <div class="container-fluid">
        <div class="row g-4">

            <div class="col-md-4">
                <div class="card card-menu p-4 text-center">
                    <i class="fa-solid fa-file-circle-exclamation icono azul"></i>
                    <h5 class="texto-azul">Papeletas</h5>
                    <p>Registrar y consultar papeletas.</p>
                    <a href="Papeletas.aspx" class="btn btn-primary">Ingresar</a>
                </div>
            </div>

            <div class="col-md-4">
                <div class="card card-menu p-4 text-center">
                    <i class="fa-solid fa-user icono amarillo"></i>
                    <h5 class="texto-amarillo">Infractores</h5>
                    <p>Administrar infractores.</p>
                    <a href="Infractores.aspx" class="btn btn-warning">Ingresar</a>
                </div>
            </div>

            <div class="col-md-4">
                <div class="card card-menu p-4 text-center">
                    <i class="fa-solid fa-car icono verde"></i>
                    <h5 class="texto-verde">Vehículos</h5>
                    <p>Gestionar vehículos.</p>
                    <a href="Vehiculos.aspx" class="btn btn-success">Ingresar</a>
                </div>
            </div>

        </div>

        <div class="row g-4 justify-content-center mt-1">

            <div class="col-md-4">
                <div class="card card-menu p-4 text-center">
                    <i class="fa-solid fa-user-shield icono rojo"></i>
                    <h5 class="texto-rojo">Policías</h5>
                    <p>Administrar policías de tránsito.</p>
                    <a href="Policias.aspx" class="btn btn-danger">Ingresar</a>
                </div>
            </div>

            <div class="col-md-4">
                <div class="card card-menu p-4 text-center">
                    <i class="fa-solid fa-triangle-exclamation icono naranja"></i>
                    <h5 class="texto-naranja">Infracciones</h5>
                    <p>Gestionar tipos de infracción.</p>
                    <a href="Infracciones.aspx" class="btn btn-warning">Ingresar</a>
                </div>
            </div>

        </div>

        <div class="row mt-5">
            <div class="col-md-3">
                <div class="card bg-primary text-white shadow border-0">
                    <div class="card-body text-center">
                        <h2>125</h2>
                        <p>Total Papeletas</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card bg-success text-white shadow border-0">
                    <div class="card-body text-center">
                        <h2>350</h2>
                        <p>Vehículos</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card bg-warning text-dark shadow border-0">
                    <div class="card-body text-center">
                        <h2>210</h2>
                        <p>Infractores</p>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card bg-danger text-white shadow border-0">
                    <div class="card-body text-center">
                        <h2>18</h2>
                        <p>Policías</p>
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow mt-5 mb-5 border-0">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0"><i class="fa-solid fa-clock-rotate-left"></i>Últimas Papeletas Registradas</h5>
            </div>
            <div class="card-body">
                <table class="table table-hover align-middle">
                    <thead class="table-primary">
                        <tr>
                            <th>Código</th>
                            <th>Infractor</th>
                            <th>Vehículo</th>
                            <th>Policía</th>
                            <th>Estado</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>P00001</td>
                            <td>Juan Pérez</td>
                            <td>Toyota Corolla</td>
                            <td>Carlos Ramos</td>
                            <td><span class="badge bg-success">Activa</span></td>
                        </tr>
                        <tr>
                            <td>P00002</td>
                            <td>María Díaz</td>
                            <td>Kia Rio</td>
                            <td>José Flores</td>
                            <td><span class="badge bg-danger">Inactivo</span></td>
                        </tr>
                        <tr>
                            <td>P00003</td>
                            <td>Luis Rojas</td>
                            <td>Hyundai Accent</td>
                            <td>Pedro Ruiz</td>
                            <td><span class="badge bg-danger">Inactivo</span></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
