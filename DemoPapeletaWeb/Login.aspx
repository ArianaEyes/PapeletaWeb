<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DemoPapeletaWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<head>
<title>Login Papeleta</title>

    <style>
        body {
            margin: 0;
            padding: 0;
            height: 100%;
            overflow: hidden;
        }

        .contenedor {
            width: 100%;
            height: 100vh;
            background-image: url("Images/img4.jpg");
            background-size: cover;
            background-position: center;
            position: relative;
        }

        .imagen-fondo {
            display: none;
        }

        .mensaje {
            position: absolute;
            left: 70px;
            top: 240px;
            background: white;
            color: black;
            font-size: 34px;
            font-weight: bold;
            padding: 25px;
            border-radius: 10px;
        }

        .login-card {
            position: absolute;
            right: 80px;
            top: 90px;
            width: 280px;
            background: #cfd3dd;
            padding: 30px;
            border-radius: 15px;
            text-align: center;
        }

        .logo {
            width: 130px;
            margin-bottom: 20px;
        }

        .login-card label {
            display: block;
            text-align: left;
            font-size: 12px;
            margin: 12px 0 6px;
        }

        .caja {
            width: 100%;
            padding: 10px;
            border-radius: 20px;
            border: none;
            outline: none;
        }

        .check {
            font-size: 10px;
            margin: 12px 0;
            text-align: left;
        }

        .btn-login {
            width: 180px;
            padding: 10px;
            background: black;
            color: white;
            border: none;
            border-radius: 15px;
            font-weight: bold;
            cursor: pointer;
        }

        .btn-register {
            width: 180px;
            padding: 8px;
            background: white;
            color: black;
            border: none;
            border-radius: 15px;
            font-weight: bold;
            margin-top: 10px;
            cursor: pointer;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="contenedor">

            <div class="mensaje">
                MÁS ORDEN <br />
                MÁS SEGURIDAD
            </div>

            <div class="login-card">

                <img src="Images/img_papeleta.png" class="logo" />

                <label>Coloque su nombre de usuario y/o gmail.</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="caja" placeholder="Escribe aquí..."></asp:TextBox>

                <label>Coloque su contraseña.</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="caja" TextMode="Password" placeholder="Escribe aquí..."></asp:TextBox>

                <div class="check">
                    <asp:CheckBox ID="chkPoliticas" runat="server" />
                    <span>Estar de acuerdo con las políticas y privacidad</span>
                </div>

                <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn-login" OnClick="btnLogin_Click" />

                <br />

                <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn-register" />

            </div>

        </div>

        <asp:Image ID="imgFondo" runat="server" CssClass="imagen-fondo" ImageUrl="Images/img4.jpg" />
    </form>
</body>
</html>