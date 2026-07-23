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
        .icono-papeleta { color: #ffc107; }     
        .icono-infractor { color: #dc3545; }    
        .icono-vehiculo { color: #212529; }   
        .icono-policia { color: #0d6efd; }
        .icono-infraccion {
            color: #ffc107;
        }

        .icono-ubigeo {
            color: #198754;
        }

        .card-menu h5 {
            margin-top: 15px;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="banner">
        <h2 id="lblUsuario" runat="server"></h2>
        <p>Administra infractores, vehículos, policías y papeletas desde un solo lugar.</p>
    </div>

    <div class="container-fluid">
        <div class="row g-4">
            <div class="col-md-4">
                <div class="card card-menu p-4 text-center border border-warning border-3">
                    <i class="fa-solid fa-file-circle-exclamation icono icono-papeleta"></i>

                    <h5 class="texto-amarillo">Papeletas</h5>

                    <p>Registrar y consultar papeletas.</p>

                    <a href="Papeletas.aspx"
                        class="btn btn-warning fw-bold text-dark">Ingresar
                    </a>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card card-menu p-4 text-center border border-danger border-3">
                    <i class="fa-solid fa-user icono icono-infractor"></i>

                    <h5 class="texto-rojo">Infractores</h5>

                    <p>Administrar infractores.</p>

                    <a href="Infractores.aspx"
                        class="btn btn-danger">Ingresar
                    </a>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card card-menu p-4 text-center border border-dark border-3">
                    <i class="fa-solid fa-car icono icono-vehiculo"></i>

                    <h5 style="color: #212529; font-weight: bold;">Vehículos
                    </h5>

                    <p>Gestionar vehículos.</p>

                    <a href="Vehiculos.aspx"
                        class="btn btn-dark">Ingresar
                    </a>
                </div>
            </div>
            <div class="row g-4 justify-content-center">

    <div class="col-md-4">
        <div class="card card-menu p-4 text-center border border-primary border-3">
            <i class="fa-solid fa-user-shield icono icono-policia"></i>

            <h5 class="texto-azul">Policías</h5>

            <p>Administrar policías de tránsito.</p>

            <a href="Policias.aspx"
                class="btn btn-primary">
                Ingresar
            </a>
        </div>
    </div>

    <div class="col-md-4">
        <div class="card card-menu p-4 text-center border border-warning border-3">
            <i class="fa-solid fa-triangle-exclamation icono icono-infraccion"></i>

            <h5 class="texto-amarillo">Infracciones</h5>

            <p>Gestionar tipos de infracción.</p>

            <a href="Infracciones.aspx"
                class="btn btn-warning fw-bold text-dark">
                Ingresar
            </a>
        </div>
    </div>

</div>

            <div class="row mt-5">

                <div class="col-md-3">
                    <div class="card bg-warning text-dark shadow border-0">
                        <div class="card-body text-center">
                            <i class="fa-solid fa-file-circle-exclamation fa-2x mb-2"></i>
                            <h2>125</h2>
                            <p class="mb-0 fw-bold">Papeletas</p>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card bg-danger text-white shadow border-0">
                        <div class="card-body text-center">
                            <i class="fa-solid fa-user fa-2x mb-2"></i>
                            <h2>210</h2>
                            <p class="mb-0 fw-bold">Infractores</p>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card bg-dark text-white shadow border-0">
                        <div class="card-body text-center">
                            <i class="fa-solid fa-car fa-2x mb-2"></i>
                            <h2>350</h2>
                            <p class="mb-0 fw-bold">Vehículos</p>
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="card bg-primary text-white shadow border-0">
                        <div class="card-body text-center">
                            <i class="fa-solid fa-user-shield fa-2x mb-2"></i>
                            <h2>18</h2>
                            <p class="mb-0 fw-bold">Policías</p>
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
        <%--FUNCION EN JAVA SCRIPT PARA LA EXPIRACION DE LA SESION--%>
<script type="text/javascript">
        // Tiempo de inactividad en milisegundos (60 segundos =60000 ms)
        const tiempoInactividad = 5000; 
        let temporizador;

        function ReiniciarTemporizador() {
            // Limpiamos el temporizador anterior cada vez que el usuario hace algo
            clearTimeout(temporizador);
            
            // Iniciamos la cuenta regresiva de 55 segundos
            temporizador = setTimeout(CerrarSesionPorInactividad, tiempoInactividad);
        }

        function CerrarSesionPorInactividad() {
           // Redirige al archivo Logout.aspx 
            window.location.href = '<%= ResolveUrl("~/Logout.aspx") %>';
        }

        // Escuchamos los movimientos del usuario para saber si está activo en la página
        window.onload = ReiniciarTemporizador;
        window.onmousemove = ReiniciarTemporizador;
        window.onkeypress = ReiniciarTemporizador;
        window.onclick = ReiniciarTemporizador;
        window.onscroll = ReiniciarTemporizador;

        // SOPORTE PARA AJAX / POSTBACKS:
        // Si usas UpdatePanel o llamadas asíncronas de ASP.NET, esto reiniciará el JS
        if (typeof (Sys) !== 'undefined') {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(IniciarTemporizadorSeguro);
        }
</script>   

</asp:Content>