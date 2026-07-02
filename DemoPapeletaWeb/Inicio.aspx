<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Inicio.aspx.cs"
    Inherits="DemoPapeletaWeb.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .banner { margin: 30px; background: linear-gradient(135deg,#0d6efd,#4f9dff); color: white; border-radius: 20px; padding: 35px; box-shadow: 0px 10px 25px rgba(0,0,0,.2); }
        .banner h2 { font-weight: bold; }
        .card-menu { border: none; border-radius: 20px; transition: .3s; box-shadow: 0px 5px 20px rgba(0,0,0,.1); cursor: pointer; }
        .card-menu:hover { transform: translateY(-8px); }
        .icono { font-size: 55px; color: #0d6efd; }
        .card-menu h5 { margin-top: 15px; font-weight: bold; }
    </style>
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
                    <i class="fa-solid fa-file-circle-exclamation icono"></i>
                    <h5>Papeletas</h5><p>Registrar y consultar papeletas.</p>
                    <button class="btn btn-primary">Ingresar</button>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card card-menu p-4 text-center">
                    <i class="fa-solid fa-user icono"></i>
                    <h5>Infractores</h5><p>Administrar infractores.</p>
                    <a href="Infractores.aspx" class="btn btn-primary">Ingresar</a>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card card-menu p-4 text-center">
                    <i class="fa-solid fa-car icono"></i>
                    <h5>Vehículos</h5><p>Gestionar vehículos.</p>
                    <button class="btn btn-primary">Ingresar</button>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card card-menu p-4 text-center">
                    <i class="fa-solid fa-user-shield icono"></i>
                    <h5>Policías</h5><p>Administrar policías de tránsito.</p>
                    <a href="Policias.aspx" class="btn btn-primary">Ingresar</a>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card card-menu p-4 text-center">
                    <i class="fa-solid fa-triangle-exclamation icono"></i>
                    <h5>Infracciones</h5><p>Gestionar tipos de infracción.</p>
                    <button class="btn btn-primary">Ingresar</button>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card card-menu p-4 text-center">
                    <i class="fa-solid fa-location-dot icono"></i>
                    <h5>Ubigeo</h5><p>Consultar departamentos y distritos.</p>
                    <button class="btn btn-primary">Ingresar</button>
                </div>
            </div>
        </div>

        <div class="row mt-5">
            <div class="col-md-3">
                <div class="card bg-primary text-white shadow border-0">
                    <div class="card-body text-center"><h2>125</h2><p>Total Papeletas</p></div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card bg-success text-white shadow border-0">
                    <div class="card-body text-center"><h2>350</h2><p>Vehículos</p></div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card bg-warning text-dark shadow border-0">
                    <div class="card-body text-center"><h2>210</h2><p>Infractores</p></div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="card bg-danger text-white shadow border-0">
                    <div class="card-body text-center"><h2>18</h2><p>Policías</p></div>
                </div>
            </div>
        </div>

        <div class="card shadow mt-5 mb-5 border-0">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0"><i class="fa-solid fa-clock-rotate-left"></i> Últimas Papeletas Registradas</h5>
            </div>
            <div class="card-body">
                <table class="table table-hover align-middle">
                    <thead class="table-primary">
                        <tr><th>Código</th><th>Infractor</th><th>Vehículo</th><th>Policía</th><th>Estado</th></tr>
                    </thead>
                    <tbody>
                        <tr><td>P00001</td><td>Juan Pérez</td><td>Toyota Corolla</td><td>Carlos Ramos</td><td><span class="badge bg-success">Activa</span></td></tr>
                        <tr><td>P00002</td><td>María Díaz</td><td>Kia Rio</td><td>José Flores</td><td><span class="badge bg-danger">Inactivo</span></td></tr>
                        <tr><td>P00003</td><td>Luis Rojas</td><td>Hyundai Accent</td><td>Pedro Ruiz</td><td><span class="badge bg-danger">Inactivo</span></td></tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>

</asp:Content>