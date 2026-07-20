<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="SitioWEB_VentasGUI.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Sesión Cerrada</title>

    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Geologica:wght,CRSV@100..900,0&family=Google+Sans:ital,opsz,wght@0,17..18,400..700;1,17..18,400..700&display=swap" rel="stylesheet">
    <link href="CSS/login.css" rel="stylesheet" type="text/css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />

    <!-- Redirige automáticamente al Login después de 7 segundos -->
    <meta http-equiv="refresh" content="7;url=Login.aspx" />

    <style>
        /* Solo lo necesario para el ícono y el mensaje de logout,
           todo lo demás (contenedor, login-card, logo, btn) ya viene de login.css */
        .logout-icono {
            font-size: 60px;
            color: #000;
            margin-bottom: 15px;
        }

        .logout-titulo {
            font-family: 'Google Sans', sans-serif;
            font-weight: 700;
            font-size: 22px;
            color: #000;
            margin: 0 0 10px 0;
        }

        .logout-texto {
            font-family: 'Geologica', sans-serif;
            font-size: 14px;
            color: #555;
            margin-bottom: 20px;
        }

        .logout-contador {
            font-family: 'Geologica', sans-serif;
            font-size: 12px;
            color: #999;
            margin-top: 15px;
        }
    </style>
    <link href="CSS/DemoCSS.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">

        <div class="contenedor">

            <div class="mensaje">
                SESIÓN CERRADA
                <br />
                CON ÉXITO
            </div>

            <div class="login-card">

                <img src="Images/img_papeleta.png" class="logo" />

                <i class="fas fa-user-shield logout-icono"></i>

                <p class="logout-titulo">¡Hasta pronto!</p>
                <p class="logout-texto">
                    Has salido del sistema de manera segura. Tu información y consultas pendientes han sido protegidas.
                </p>

                <a href="Login.aspx" class="btn login" style="text-decoration: none; display: block; text-align: center;">
                    <i class="fas fa-sign-in-alt" style="margin-right: 6px;"></i>Iniciar Sesión Otra Vez
                </a>

                <p class="logout-contador">Serás redirigido automáticamente en unos segundos...</p>

            </div>

        </div>

        <asp:Image ID="imgFondo" runat="server" CssClass="imagen-fondo" ImageUrl="Images/img3.jpg" />
    </form>
</body>
</html>
