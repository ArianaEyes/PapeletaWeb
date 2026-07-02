<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="DemoPapeletaWeb.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

<meta charset="utf-8" />

<title>Sistema de Gestión de Papeletas</title>

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet"/>

<link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.7.2/css/all.min.css" rel="stylesheet"/>

<style>

body{
    background:#eef2f7;
    font-family:'Segoe UI';
}

.sidebar{

position:fixed;
left:0;
top:0;
width:250px;
height:100%;
background:#1f2937;
color:white;

}

.logo{

padding:25px;
font-size:24px;
font-weight:bold;
text-align:center;
border-bottom:1px solid rgba(255,255,255,.1);

}

.logo i{

color:#0d6efd;
margin-right:8px;

}

.sidebar a{

display:block;
padding:16px 25px;
color:white;
text-decoration:none;
font-size:17px;
transition:.3s;

}

.sidebar a:hover{

background:#0d6efd;
padding-left:35px;

}

.sidebar a i{

width:25px;

}

.main{

margin-left:250px;

}

.topbar{

height:70px;
background:white;
box-shadow:0px 3px 10px rgba(0,0,0,.1);

display:flex;

justify-content:space-between;

align-items:center;

padding:0 35px;

}

.usuario{

font-size:17px;

font-weight:600;

}

.banner{

margin:30px;

background:linear-gradient(135deg,#0d6efd,#4f9dff);

color:white;

border-radius:20px;

padding:35px;

box-shadow:0px 10px 25px rgba(0,0,0,.2);

}

.banner h2{

font-weight:bold;

}

.card-menu{

border:none;

border-radius:20px;

transition:.3s;

box-shadow:0px 5px 20px rgba(0,0,0,.1);

cursor:pointer;

}

.card-menu:hover{

transform:translateY(-8px);

}

.icono{

font-size:55px;

color:#0d6efd;

}

.card-menu h5{

margin-top:15px;

font-weight:bold;

}

</style>

</head>

<body>

<form id="form1" runat="server">

<div class="sidebar">

<div class="logo">

<i class="fa-solid fa-road"></i>

Papeletas

</div>

<a href="Inicio.aspx">

<i class="fa-solid fa-house"></i>

Inicio

</a>

<a href="#">

<i class="fa-solid fa-file-circle-exclamation"></i>

Papeletas

</a>

<a href="#">

<i class="fa-solid fa-user"></i>

Infractores

</a>

<a href="#">

<i class="fa-solid fa-car"></i>

Vehículos

</a>

<a href="#">

<i class="fa-solid fa-user-shield"></i>

Policías

</a>

<a href="#">

<i class="fa-solid fa-triangle-exclamation"></i>

Infracciones

</a>

<a href="#">

<i class="fa-solid fa-location-dot"></i>

Ubigeo

</a>

<a href="Login.aspx">

<i class="fa-solid fa-right-from-bracket"></i>

Cerrar sesión

</a>

</div>

<div class="main">

<div class="topbar">

<h4>

Sistema de Gestión de Papeletas

</h4>

<div class="usuario">

<i class="fa-solid fa-circle-user"></i>

Administrador

</div>

</div>

<div class="banner">

<h2>

¡Bienvenid@!

</h2>

<p>

Administra infractores, vehículos, policías y papeletas desde un solo lugar.

</p>

</div>

<div class="container-fluid">

<div class="row g-4">

<div class="col-md-4">

<div class="card card-menu p-4 text-center">

<i class="fa-solid fa-file-circle-exclamation icono"></i>

<h5>Papeletas</h5>

<p>Registrar y consultar papeletas.</p>

<button class="btn btn-primary">

Ingresar

</button>

</div>

</div>

<div class="col-md-4">

<div class="card card-menu p-4 text-center">

<i class="fa-solid fa-user icono"></i>

<h5>Infractores</h5>

<p>Administrar infractores.</p>

<button class="btn btn-primary">

Ingresar

</button>

</div>

</div>

<div class="col-md-4">

<div class="card card-menu p-4 text-center">

<i class="fa-solid fa-car icono"></i>

<h5>Vehículos</h5>

<p>Gestionar vehículos.</p>

<button class="btn btn-primary">

Ingresar

</button>

</div>

</div>

    <div class="col-md-4">

    <div class="card card-menu p-4 text-center">

        <i class="fa-solid fa-user-shield icono"></i>

        <h5>Policías</h5>

        <p>Administrar policías de tránsito.</p>

        <button class="btn btn-primary">
            Ingresar
        </button>

    </div>

</div>

<div class="col-md-4">

    <div class="card card-menu p-4 text-center">

        <i class="fa-solid fa-triangle-exclamation icono"></i>

        <h5>Infracciones</h5>

        <p>Gestionar tipos de infracción.</p>

        <button class="btn btn-primary">
            Ingresar
        </button>

    </div>

</div>

<div class="col-md-4">

    <div class="card card-menu p-4 text-center">

        <i class="fa-solid fa-location-dot icono"></i>

        <h5>Ubigeo</h5>

        <p>Consultar departamentos y distritos.</p>

        <button class="btn btn-primary">
            Ingresar
        </button>

    </div>

</div>

</div>

<!-- ESTADÍSTICAS -->

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

<!-- TABLA -->

<div class="card shadow mt-5 mb-5 border-0">

<div class="card-header bg-dark text-white">

<h5 class="mb-0">

<i class="fa-solid fa-clock-rotate-left"></i>

Últimas Papeletas Registradas

</h5>

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

<td>
<span class="badge bg-success">
Activa
</span>
</td>

</tr>

<tr>

<td>P00002</td>

<td>María Díaz</td>

<td>Kia Rio</td>

<td>José Flores</td>

<td>

<span class="badge bg-danger">
Inactivo
</span>

</td>

</tr>

<tr>

<td>P00003</td>

<td>Luis Rojas</td>

<td>Hyundai Accent</td>

<td>Pedro Ruiz</td>

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

<footer class="text-center mt-4 mb-3">

<hr />

<p class="text-secondary">

<i class="fa-solid fa-shield-halved text-primary"></i>

Sistema de Gestión de Papeletas © 2026

<br />

Desarrollado por el Grupo 5 - PA4

</p>

</footer>

</div>

</form>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js"></script>

</body>

</html>