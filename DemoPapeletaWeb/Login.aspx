<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DemoPapeletaWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Login Papeleta</title>

    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Geologica:wght,CRSV@100..900,0&family=Google+Sans:ital,opsz,wght@0,17..18,400..700;1,17..18,400..700&display=swap" rel="stylesheet">
    <link href="CSS/DemoCSS.css" rel="stylesheet" type="text/css" />
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

                <asp:Label ID="lblError" runat="server" Text="" 
                Style="color:red; font-size:13px; margin-top:10px; display:block;"></asp:Label>

                <div class="formulario">
                    <div class="casillas">
                        <label>Coloque su nombre de usuario y/o gmail.</label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="caja" placeholder="Escribe aquí..."></asp:TextBox>
                    </div>

                    <div class="casillas">
                        <label>Coloque su contraseña.</label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="caja" TextMode="Password" placeholder="Escribe aquí..."></asp:TextBox>
                    </div>

                    <div class="check">
                        <asp:CheckBox ID="chkPoliticas" runat="server" />
                        <span>Estar de acuerdo con las políticas y privacidad</span>
                    </div>

                    <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn login" OnClick="btnLogin_Click" />

                    <br />

                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" 
                    CssClass="btn register" OnClick="btnRegistrar_Click" />
                </div>

            </div>

        </div>

        <asp:Image ID="imgFondo" runat="server" CssClass="imagen-fondo" ImageUrl="Images/img3.jpg" />
    </form>
</body>
</html>