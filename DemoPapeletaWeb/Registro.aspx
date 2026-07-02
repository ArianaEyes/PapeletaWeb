<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="DemoPapeletaWeb.Registro" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro - Papeleta</title>
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

        .mensaje {
            position: absolute;
            left: 70px;
            top: 200px;
            background: white;
            color: black;
            font-size: 34px;
            font-weight: bold;
            padding: 25px;
            border-radius: 10px;
        }

        .register-card {
            position: absolute;
            right: 80px;
            top: 40px;
            width: 320px;
            background: #cfd3dd;
            padding: 30px;
            border-radius: 15px;
            text-align: center;
        }

        .logo {
            width: 130px;
            margin-bottom: 15px;
        }

        .register-card label {
            display: block;
            text-align: left;
            font-size: 12px;
            margin: 10px 0 5px;
        }

        .caja {
            width: 100%;
            padding: 10px;
            border-radius: 20px;
            border: none;
            outline: none;
            box-sizing: border-box;
        }

        .btn-register {
            width: 180px;
            padding: 10px;
            background: black;
            color: white;
            border: none;
            border-radius: 15px;
            font-weight: bold;
            cursor: pointer;
            margin-top: 15px;
        }

        .btn-volver {
            width: 180px;
            padding: 8px;
            background: white;
            color: black;
            border: none;
            border-radius: 15px;
            font-weight: bold;
            margin-top: 8px;
            cursor: pointer;
        }

        .lblError {
            color: red;
            font-size: 12px;
            margin-top: 8px;
            display: block;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="contenedor">

            <div class="mensaje">
                ÚNETE AL
                <br />
                SISTEMA
            </div>

            <div class="register-card">

                <img src="Images/img_papeleta.png" class="logo" />

                <asp:Label ID="lblError" runat="server" Text="" CssClass="lblError"></asp:Label>

                <label>Nombres</label>
                <asp:TextBox ID="txtNombres" runat="server" CssClass="caja" placeholder="Ingrese sus nombres"></asp:TextBox>

                <label>Apellidos</label>
                <asp:TextBox ID="txtApellidos" runat="server" CssClass="caja" placeholder="Ingrese sus apellidos"></asp:TextBox>

                <label>Correo electrónico</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="caja" TextMode="Email" placeholder="correo@ejemplo.com"></asp:TextBox>

                <label>Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="caja" placeholder="Nombre de usuario"></asp:TextBox>

                <label>Contraseña</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="caja" TextMode="Password" placeholder="••••••••"></asp:TextBox>

                <label>Confirmar contraseña</label>
                <asp:TextBox ID="txtConfirmar" runat="server" CssClass="caja" TextMode="Password" placeholder="••••••••"></asp:TextBox>

                <asp:Button ID="btnRegistrar"
                    runat="server"
                    Text="Registrarse"
                    CssClass="btn-register"
                    OnClick="btnRegistrar_Click1"
                    OnClientClick="return validarRegistro();" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver al Login" CssClass="btn-volver"
                    OnClick="btnVolver_Click" />

            </div>

        </div>
    </form>

    <script>

        function validarRegistro() {

            var nombres = document.getElementById('<%= txtNombres.ClientID %>').value.trim();
            var apellidos = document.getElementById('<%= txtApellidos.ClientID %>').value.trim();
            var correo = document.getElementById('<%= txtCorreo.ClientID %>').value.trim();
            var usuario = document.getElementById('<%= txtUsuario.ClientID %>').value.trim();
            var password = document.getElementById('<%= txtPassword.ClientID %>').value;
            var confirmar = document.getElementById('<%= txtConfirmar.ClientID %>').value;

            if (nombres === "") {
                alert("Ingrese sus nombres.");
                return false;
            }

            if (!/^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$/.test(nombres)) {
                alert("Los nombres solo pueden contener letras.");
                return false;
            }

            if (apellidos === "") {
                alert("Ingrese sus apellidos.");
                return false;
            }

            if (!/^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$/.test(apellidos)) {
                alert("Los apellidos solo pueden contener letras.");
                return false;
            }

            if (correo === "") {
                alert("Ingrese un correo electrónico.");
                return false;
            }

            var correoValido = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

            if (!correoValido.test(correo)) {
                alert("Ingrese un correo electrónico válido.");
                return false;
            }

            if (usuario === "") {
                alert("Ingrese un nombre de usuario.");
                return false;
            }

            if (usuario.length < 5) {
                alert("El usuario debe tener al menos 5 caracteres.");
                return false;
            }

            if (password === "") {
                alert("Ingrese una contraseña.");
                return false;
            }

            var patron = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{5}$/;

            if (!patron.test(password)) {
                alert("La contraseña debe tener exactamente 5 caracteres, incluyendo una mayúscula, una minúscula y un número.");
                return false;
            }

            if (confirmar === "") {
                alert("Confirme la contraseña.");
                return false;
            }

            if (password !== confirmar) {
                alert("Las contraseñas no coinciden.");
                return false;
            }

            return true;
        }

    </script>
</body>
</html>
