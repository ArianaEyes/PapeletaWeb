<%@ Page Title="Policías" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Policias.aspx.cs"
    Inherits="DemoPapeletaWeb.Policias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="CSS/policia.css" rel="stylesheet" />

    <script>
        function SoloLetras(e) {
            var tecla = e.which || e.keyCode;
            var caracter = String.fromCharCode(tecla);

            if (tecla == 8 || tecla == 9 || tecla == 13 || tecla == 46 ||
                tecla == 37 || tecla == 38 || tecla == 39 || tecla == 40) {
                return true;
            }

            var patron = /^[A-Za-zÁÉÍÓÚáéíóúÑñ ]$/;

            return patron.test(caracter);
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="CSS/policia.css" rel="stylesheet" />

    <div class="page-header">
        <h2>
            <i class="fa-solid fa-user-shield text-white"></i>
            Gestión de Policías
        </h2>
        <p>Consulta y administra los policías de tránsito registrados.</p>
    </div>

    <div class="container-fluid">

        <div class="card shadow border-0 mb-4">
            <div class="card-body">
                <div class="row g-3 align-items-end">
                    <div class="col-md-5">
                        <label class="form-label fw-bold">Buscar por Código, DNI o nombres:</label>
                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control" placeholder="Ej: 12345678 o Ramos"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button
                            ID="btnConsultar"
                            runat="server"
                            Text="Consultar"
                            CssClass="btn btn-primary w-100"
                            CausesValidation="False"
                            OnClick="btnConsultar_Click" />
                    </div>

                    <div class="col-md-2">
                        <asp:Button
                            ID="btnNuevo"
                            runat="server"
                            Text="+ Nuevo"
                            CssClass="btn btn-success w-100"
                            CausesValidation="False"
                            OnClick="btnNuevo_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow border-0 mb-5">
            <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i>Listado de Policías</h5>
                <asp:Label ID="lblCantidad" runat="server" CssClass="badge bg-primary"></asp:Label>
            </div>

            <div class="card-body table-responsive">
                <asp:GridView ID="gvPolicias" runat="server" CssClass="table table-hover align-middle"
                    AutoGenerateColumns="false" GridLines="None">
                    <HeaderStyle CssClass="table-primary" />
                    <Columns>
                        <asp:BoundField DataField="Cod_Policia" HeaderText="Código" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:TemplateField HeaderText="Nombres y Apellidos">
                            <ItemTemplate>
                                <%# Eval("Nombre") %> <%# Eval("Paterno") %> <%# Eval("Materno") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Rango" HeaderText="Rango" />
                        <asp:BoundField DataField="SexoTexto" HeaderText="Sexo" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fec. Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Distrito" HeaderText="Distrito" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <span class='badge <%# Eval("EstadoTexto").ToString() == "Activo" ? "bg-success" : "bg-danger" %>'>
                                    <%# Eval("EstadoTexto") %>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>

                                <asp:LinkButton
                                    ID="btnEditar"
                                    runat="server"
                                    Text="Editar"
                                    CssClass="btn btn-warning btn-sm"
                                    CommandArgument='<%# Eval("Cod_Policia") %>'
                                    CausesValidation="False"
                                    OnClick="btnEditar_Click" />
                                <asp:LinkButton
                                    ID="btnEliminar"
                                    runat="server"
                                    CssClass="btn btn-danger btn-sm"
                                    Text="Inactivar"
                                    CommandArgument='<%# Eval("Cod_Policia") %>'
                                    CausesValidation="False"
                                    OnClick="btnEliminar_Click"
                                    OnClientClick="return confirm('¿Desea inactivar este policía?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <asp:Panel ID="pnlFormulario"
                    runat="server"
                    Visible="false">

                    <div class="card shadow border-0 mt-4">

                        <div class="card-header bg-primary text-white">
                            <h5 class="mb-0">
                                <i class="fa-solid fa-user-shield"></i>
                                Nuevo / Editar Policía
                            </h5>
                        </div>

                        <div class="card-body">

                            <asp:ValidationSummary
                                ID="vsPolicia"
                                runat="server"
                                CssClass="alert alert-danger"
                                DisplayMode="BulletList" />

                            <div class="row">

                                <div class="col-md-3 mb-3">

                                    <label>DNI</label>

                                    <asp:TextBox
                                        ID="txtDNI"
                                        runat="server"
                                        CssClass="form-control"
                                        MaxLength="8"
                                        onkeypress="return event.charCode >= 48 && event.charCode <= 57;" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvDNI"
                                        runat="server"
                                        ControlToValidate="txtDNI"
                                        ErrorMessage="Ingrese el DNI"
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                    <asp:RegularExpressionValidator
                                        ID="revDNI"
                                        runat="server"
                                        ControlToValidate="txtDNI"
                                        ValidationExpression="\d{8}"
                                        ErrorMessage="El DNI debe tener 8 dígitos"
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                </div>

                                <div class="col-md-5 mb-3">

                                    <label>Nombres</label>

                                    <asp:TextBox
                                        ID="txtNombre"
                                        runat="server"
                                        CssClass="form-control"
                                        MaxLength="50"
                                        onkeypress="return SoloLetras(event);" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvNombre"
                                        runat="server"
                                        ControlToValidate="txtNombre"
                                        ErrorMessage="Ingrese los nombres"
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                    <asp:RegularExpressionValidator
                                        ID="revNombre"
                                        runat="server"
                                        ControlToValidate="txtNombre"
                                        ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$"
                                        ErrorMessage="Los nombres solo pueden contener letras."
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-6 mb-3">

                                    <label>Apellido Paterno</label>

                                    <asp:TextBox
                                        ID="txtPaterno"
                                        runat="server"
                                        CssClass="form-control"
                                        MaxLength="30"
                                        onkeypress="return SoloLetras(event);" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvPaterno"
                                        runat="server"
                                        ControlToValidate="txtPaterno"
                                        ErrorMessage="Ingrese el apellido paterno"
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                    <asp:RegularExpressionValidator
                                        ID="revPaterno"
                                        runat="server"
                                        ControlToValidate="txtPaterno"
                                        ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$"
                                        ErrorMessage="El apellido paterno solo puede contener letras."
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                </div>

                                <div class="col-md-6 mb-3">

                                    <label>Apellido Materno</label>

                                    <asp:TextBox
                                        ID="txtMaterno"
                                        runat="server"
                                        CssClass="form-control"
                                        MaxLength="30"
                                        onkeypress="return SoloLetras(event);" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvMaterno"
                                        runat="server"
                                        ControlToValidate="txtMaterno"
                                        ErrorMessage="Ingrese el apellido materno"
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                    <asp:RegularExpressionValidator
                                        ID="revMaterno"
                                        runat="server"
                                        ControlToValidate="txtMaterno"
                                        ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$"
                                        ErrorMessage="El apellido materno solo puede contener letras."
                                        Display="Dynamic"
                                        ForeColor="Red" />
                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-4 mb-3">

                                    <label>Departamento</label>

                                    <asp:DropDownList
                                        ID="ddlDepartamento"
                                        runat="server"
                                        CssClass="form-select"
                                        AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvDepartamento"
                                        runat="server"
                                        ControlToValidate="ddlDepartamento"
                                        InitialValue=""
                                        ErrorMessage="Seleccione un departamento"
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                </div>

                                <div class="col-md-4 mb-3">

                                    <label>Provincia</label>

                                    <asp:DropDownList
                                        ID="ddlProvincia"
                                        runat="server"
                                        CssClass="form-select"
                                        AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvProvincia"
                                        runat="server"
                                        ControlToValidate="ddlProvincia"
                                        InitialValue=""
                                        ErrorMessage="Seleccione una provincia"
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                </div>

                                <div class="col-md-4 mb-3">

                                    <label>Distrito</label>

                                    <asp:DropDownList
                                        ID="ddlDistrito"
                                        runat="server"
                                        CssClass="form-select" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvDistrito"
                                        runat="server"
                                        ControlToValidate="ddlDistrito"
                                        InitialValue=""
                                        ErrorMessage="Seleccione un distrito"
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-4 mb-3">

                                    <label>Rango</label>

                                    <asp:DropDownList
                                        ID="ddlRango"
                                        runat="server"
                                        CssClass="form-select">
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator
                                        ID="rfvRango"
                                        runat="server"
                                        ControlToValidate="ddlRango"
                                        InitialValue=""
                                        ErrorMessage="Seleccione un rango"
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                </div>

                                <div class="col-md-4 mb-3">

                                    <label>Sexo</label>

                                    <asp:RadioButtonList
                                        ID="rblSexo"
                                        runat="server"
                                        RepeatDirection="Horizontal">

                                        <asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
                                        <asp:ListItem Value="F">Femenino</asp:ListItem>

                                    </asp:RadioButtonList>

                                </div>

                                <div class="col-md-4 mb-3">

                                    <label>Estado</label>

                                    <asp:RadioButtonList
                                        ID="rblEstado"
                                        runat="server"
                                        RepeatDirection="Horizontal">

                                        <asp:ListItem Value="A" Selected="True">Activo</asp:ListItem>
                                        <asp:ListItem Value="I">Inactivo</asp:ListItem>

                                    </asp:RadioButtonList>

                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-4 mb-3">

                                    <label>Fecha Nacimiento</label>

                                    <asp:TextBox
                                        ID="txtNacimiento"
                                        runat="server"
                                        CssClass="form-control"
                                        TextMode="Date" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvNacimiento"
                                        runat="server"
                                        ControlToValidate="txtNacimiento"
                                        ErrorMessage="Seleccione la fecha de nacimiento"
                                        Display="Dynamic"
                                        ForeColor="Red" />

                                </div>

                            </div>

                            <div class="text-center mt-4">

                                <asp:Button
                                    ID="btnGuardar"
                                    runat="server"
                                    Text="Guardar"
                                    CssClass="btn btn-success"
                                    OnClick="btnGuardar_Click" />

                                <asp:Button
                                    ID="btnCancelar"
                                    runat="server"
                                    Text="Cancelar"
                                    CssClass="btn btn-secondary ms-2"
                                    CausesValidation="False"
                                    OnClick="btnCancelar_Click" />

                            </div>

                        </div>

                    </div>

                </asp:Panel>
                <div class="d-flex justify-content-between align-items-center mt-3">

                    <asp:Button ID="btnAnterior"
                        runat="server"
                        Text="← Anterior"
                        CssClass="btn btn-outline-primary"
                        OnClick="btnAnterior_Click" />

                    <asp:Label ID="lblPagina"
                        runat="server"
                        CssClass="fw-bold fs-5 text-primary" />

                    <asp:Button ID="btnSiguiente"
                        runat="server"
                        Text="Siguiente →"
                        CssClass="btn btn-outline-primary"
                        OnClick="btnSiguiente_Click" />

                </div>
            </div>
        </div>

    </div>
    <script>
        window.onload = function () {
            var y = sessionStorage.getItem("scrollPos");
            if (y !== null) {
                window.scrollTo(0, parseInt(y));
            }
        };

        window.onscroll = function () {
            sessionStorage.setItem("scrollPos", window.scrollY);
        };
    </script>
</asp:Content>