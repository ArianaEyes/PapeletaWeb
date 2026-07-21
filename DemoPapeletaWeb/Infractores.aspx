<%@ Page Title="Infractores" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Infractores.aspx.cs"
    Inherits="DemoPapeletaWeb.Infractores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link href="CSS/infractores.css" rel="stylesheet" />

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

    <div class="page-header">
        <h2>
            <i class="fa-solid fa-user text-white"></i>
            Gestión de Infractores
        </h2>
        <p>Consulta y administra los infractores registrados.</p>
    </div>

    <div class="container-fluid">

        <div class="card shadow border-0 mb-4">
            <div class="card-body">
                <div class="row g-3 align-items-end">

                    <div class="col-md-5">
                        <label class="form-label fw-bold">
                            Buscar por Código de Infractor, DNI, nombres o apellidos:
                       
                        </label>

                        <asp:TextBox
                            ID="txtBuscar"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Ej: 78451257 o Carlos">
                        </asp:TextBox>
                    </div>

                    <div class="col-md-2">
                        <asp:Button
                            ID="btnConsultar"
                            runat="server"
                            CausesValidation="False"
                            Text="Consultar"
                            CssClass="btn btn-danger w-100"
                            OnClick="btnConsultar_Click" />
                    </div>

                    <div class="col-md-2">
                        <asp:Button
                            ID="btnNuevo"
                            runat="server"
                            CausesValidation="False"
                            Text="+ Nuevo"
                            CssClass="btn btn-success w-100"
                            OnClick="btnNuevo_Click" />
                    </div>

                </div>
            </div>
        </div>

        <div class="card shadow border-0 mb-5">

            <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">
                <h5 class="mb-0"><i class="fa-solid fa-list"></i>Listado de Infractores</h5>
                <span>
                    <asp:Label ID="lblCantidad" runat="server" CssClass="badge bg-danger text-dark"></asp:Label></span>
            </div>

            <div class="card-body table-responsive">

                <asp:GridView ID="gvInfractores" runat="server" CssClass="table table-hover align-middle"
                    AutoGenerateColumns="false" GridLines="None">
                    <HeaderStyle CssClass="table-danger" />
                    <Columns>
                        <asp:BoundField DataField="Cod_Infractor" HeaderText="CODIGO" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:TemplateField HeaderText="Nombres y Apellidos">

                            <ItemTemplate>
                                <%# Eval("Nombres") %> <%# Eval("Ape_Paterno") %> <%# Eval("Ape_Materno") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="Nro_Brevete" HeaderText="Nro Brevete" />
                        <asp:BoundField DataField="Tipo_Brevete" HeaderText="Tipo Brevete" />
                        <asp:BoundField DataField="Fec_Registro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" />
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
                                    CommandArgument='<%# Eval("Cod_Infractor") %>'
                                    CausesValidation="False"
                                    OnClick="btnEditar_Click" />

                                &nbsp;

         <asp:LinkButton
            ID="btnEliminar"
            runat="server"
            Text="Inactivar"
            CssClass="btn btn-danger btn-sm"
            CommandArgument='<%# Eval("Cod_Infractor") %>'
            CausesValidation="False"
            OnClientClick="return confirm('¿Desea inactivar este infractor?');"
            OnClick="btnEliminar_Click" />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Panel ID="pnlFormulario" runat="server" Visible="false">
                    <div class="card shadow border-0 mt-4">

                        <div class="card-header bg-danger text-white">
                            <h5 class="mb-0">
                                <i class="fa-solid fa-user-plus"></i>
                                Nuevo / Editar Infractor
                        </h5>
                        </div>

                        <div class="card-body">

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
                                        ErrorMessage="Ingrese el DNI."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                    <asp:RegularExpressionValidator
                                        ID="revDNI"
                                        runat="server"
                                        ControlToValidate="txtDNI"
                                        ValidationExpression="^\d{8}$"
                                        ErrorMessage="El DNI debe tener exactamente 8 números."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                </div>

                                <div class="col-md-5 mb-3">

                                    <label>Correo</label>

                                    <asp:TextBox
                                        ID="txtCorreo"
                                        runat="server"
                                        CssClass="form-control"
                                        MaxLength="100" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvCorreo"
                                        runat="server"
                                        ControlToValidate="txtCorreo"
                                        ErrorMessage="Ingrese el correo."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                    <asp:RegularExpressionValidator
                                        ID="revCorreo"
                                        runat="server"
                                        ControlToValidate="txtCorreo"
                                        ValidationExpression="\w+([-.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ErrorMessage="Correo electrónico inválido."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-4 mb-3">

                                    <label>Nombres</label>

                                    <asp:TextBox
                                        ID="txtNombres"
                                        runat="server"
                                        CssClass="form-control"
                                        MaxLength="50"
                                        onkeypress="return SoloLetras(event);" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvNombres"
                                        runat="server"
                                        ControlToValidate="txtNombres"
                                        ErrorMessage="Ingrese los nombres."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                    <asp:RegularExpressionValidator
                                        ID="revNombres"
                                        runat="server"
                                        ControlToValidate="txtNombres"
                                        ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$"
                                        ErrorMessage="Solo se permiten letras."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                </div>

                                <div class="col-md-4 mb-3">

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
                                        ErrorMessage="Ingrese el apellido paterno."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                    <asp:RegularExpressionValidator
                                        ID="revPaterno"
                                        runat="server"
                                        ControlToValidate="txtPaterno"
                                        ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$"
                                        ErrorMessage="Solo se permiten letras."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                </div>

                                <div class="col-md-4 mb-3">

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
                                        ErrorMessage="Ingrese el apellido materno."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                    <asp:RegularExpressionValidator
                                        ID="revMaterno"
                                        runat="server"
                                        ControlToValidate="txtMaterno"
                                        ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$"
                                        ErrorMessage="Solo se permiten letras."
                                        ForeColor="Red"
                                        Display="Dynamic" />

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
                                        ErrorMessage="Seleccione un departamento."
                                        ForeColor="Red"
                                        Display="Dynamic" />

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
                                        ErrorMessage="Seleccione una provincia."
                                        ForeColor="Red"
                                        Display="Dynamic" />

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
                                        ErrorMessage="Seleccione un distrito."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-12 mb-3">

                                    <label>Dirección</label>

                                    <asp:TextBox
                                        ID="txtDireccion"
                                        runat="server"
                                        CssClass="form-control"
                                        MaxLength="150" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvDireccion"
                                        runat="server"
                                        ControlToValidate="txtDireccion"
                                        ErrorMessage="Ingrese la dirección."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                </div>

                            </div>

                            <div class="row">

                                <div class="col-md-6 mb-3">

                                    <label>Sexo</label>

                                    <asp:RadioButtonList
                                        ID="rblSexo"
                                        runat="server"
                                        RepeatDirection="Horizontal">

                                        <asp:ListItem Value="M">Masculino</asp:ListItem>
                                        <asp:ListItem Value="F">Femenino</asp:ListItem>

                                    </asp:RadioButtonList>

                                </div>

                                <div class="col-md-6 mb-3">

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
                                        ErrorMessage="Seleccione la fecha de nacimiento."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                </div>

                                <div class="col-md-4 mb-3">

                                    <label>Nro Brevete</label>

                                    <asp:TextBox
                                        ID="txtBrevete"
                                        runat="server"
                                        CssClass="form-control"
                                        MaxLength="8" />

                                    <asp:RequiredFieldValidator
                                        ID="rfvBrevete"
                                        runat="server"
                                        ControlToValidate="txtBrevete"
                                        ErrorMessage="Ingrese el número de brevete."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                </div>

                                <div class="col-md-4 mb-3">

                                    <label>Tipo Brevete</label>

                                    <asp:DropDownList
                                        ID="ddlTipoBrevete"
                                        runat="server"
                                        CssClass="form-select">

                                        <asp:ListItem Value="">-- Seleccione --</asp:ListItem>
                                        <asp:ListItem Value="A1">A1</asp:ListItem>
                                        <asp:ListItem Value="A2">A2</asp:ListItem>
                                        <asp:ListItem Value="A3">A3</asp:ListItem>

                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator
                                        ID="rfvTipo"
                                        runat="server"
                                        ControlToValidate="ddlTipoBrevete"
                                        InitialValue=""
                                        ErrorMessage="Seleccione el tipo de brevete."
                                        ForeColor="Red"
                                        Display="Dynamic" />

                                </div>

                            </div>

                            <div class="text-center mt-4">

                                <asp:ValidationSummary
                                    ID="vsErrores"
                                    runat="server"
                                    HeaderText="Corrija los siguientes errores:"
                                    ForeColor="Red"
                                    DisplayMode="BulletList" />

                                <asp:Button
                                    ID="btnGuardar"
                                    runat="server"
                                    Text="Guardar"
                                    CssClass="btn btn-success"
                                    OnClick="btnGuardar_Click" />

                                <asp:Button
                                    ID="btnCancelar"
                                    runat="server"
                                    CausesValidation="False"
                                    Text="Cancelar"
                                    CssClass="btn btn-secondary ms-2"
                                    OnClick="btnCancelar_Click" />

                            </div>

                        </div>

                    </div>
                </asp:Panel>
                <div class="d-flex justify-content-between align-items-center mt-3">

                    <asp:Button ID="btnAnterior"
                        runat="server"
                        Text="← Anterior"
                        CssClass="btn btn-outline-danger"
                        OnClick="btnAnterior_Click" />

                    <asp:Label ID="lblPagina"
                        runat="server"
                        CssClass="fw-bold fs-5" />

                    <asp:Button ID="btnSiguiente"
                        runat="server"
                        Text="Siguiente →"
                        CssClass="btn btn-outline-danger"
                        OnClick="btnSiguiente_Click" />

                </div>
            </div>
        </div>

    </div>

</asp:Content>
