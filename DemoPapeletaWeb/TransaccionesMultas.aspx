<%@ Page Title="TransaccionesMultas" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="TransaccionesMultas.aspx.cs"
    Inherits="DemoPapeletaWeb.TransaccionesMultas"%>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* =========================================================
   CUANDO SE LLAMA AL CCS NO EJECUTA
========================================================= */
.registro-container {
    width: 100%;
    padding: 26px 28px 40px;
    box-sizing: border-box;
    color: #172033;
}

.registro-header {
    margin-bottom: 24px;
    padding: 30px 34px;
    border-radius: 22px;
    background: linear-gradient(110deg, #156ff5, #619df5);
    color: #ffffff;
    box-shadow: 0 12px 25px rgba(24, 111, 239, 0.2);
}

.registro-header-contenido {
    display: flex;
    align-items: center;
    gap: 22px;
}

.registro-header-icono {
    display: flex;
    align-items: center;
    justify-content: center;
    flex: 0 0 72px;
    width: 72px;
    height: 72px;
    border-radius: 19px;
    background-color: rgba(255, 255, 255, 0.18);
    font-size: 32px;
}

.registro-header h1 {
    margin: 0 0 7px;
    color: #ffffff;
    font-size: 36px;
    font-weight: 750;
}

.registro-header p {
    margin: 0;
    color: rgba(255, 255, 255, 0.94);
    font-size: 17px;
}


.registro-card {
    width: 100%;
    margin-bottom: 24px;
    overflow: hidden;
    border: 1px solid #dce5ef;
    border-radius: 13px;
    background-color: #ffffff;
    box-shadow: 0 8px 22px rgba(35, 54, 85, 0.1);
}

.registro-card-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    gap: 15px;
    min-height: 52px;
    padding: 13px 20px;
    background: linear-gradient(90deg, #126df5, #3184fa);
    color: #ffffff;
    font-size: 18px;
    font-weight: 700;
}

.registro-card-titulo {
    display: flex;
    align-items: center;
    gap: 9px;
}

    .registro-card-titulo i {
        font-size: 18px;
    }

.registro-card-indicador {
    padding: 5px 11px;
    border: 1px solid rgba(255, 255, 255, 0.42);
    border-radius: 18px;
    background-color: rgba(255, 255, 255, 0.14);
    font-size: 12px;
}

.registro-card-body {
    padding: 23px 20px;
}


.registro-label {
    display: block;
    margin-bottom: 7px;
    color: #202938;
    font-size: 14px;
    font-weight: 700;
}

.campo-requerido {
    color: #dc3545;
}

.registro-control {
    display: block;
    width: 100% !important;
    min-height: 45px;
    padding: 9px 13px;
    border: 1px solid #cfd8e4;
    border-radius: 8px;
    outline: none;
    background-color: #ffffff;
    color: #1f2937;
    font-family: inherit;
    font-size: 14px;
    box-sizing: border-box;
    transition: border-color 0.2s ease, box-shadow 0.2s ease;
}

    .registro-control:focus {
        border-color: #1672ff;
        box-shadow: 0 0 0 4px rgba(22, 114, 255, 0.14);
    }

select.registro-control {
    cursor: pointer;
}

textarea.registro-control {
    min-height: 92px;
    resize: vertical;
}

.registro-textarea {
    min-height: 100px;
}

.campo-bloqueado {
    background-color: #edf2f7 !important;
    color: #526070;
    cursor: not-allowed;
}


.btn-registro {
    display: inline-flex;
    align-items: center;
    justify-content: center;
    min-width: 150px;
    min-height: 45px;
    padding: 9px 18px;
    border: 1px solid transparent;
    border-radius: 8px;
    font-family: inherit;
    font-size: 14px;
    font-weight: 650;
    cursor: pointer;
    transition: background-color 0.2s ease, transform 0.2s ease, box-shadow 0.2s ease;
}

    .btn-registro:hover {
        transform: translateY(-1px);
    }

.btn-buscar {
    width: 100%;
    background-color: #126df5;
    color: #ffffff;
    box-shadow: 0 5px 12px rgba(18, 109, 245, 0.18);
}

    .btn-buscar:hover {
        background-color: #0d5ed8;
    }

.btn-registrar-principal {
    width: 100%;
    background-color: #159447;
    color: #ffffff;
    box-shadow: 0 5px 12px rgba(21, 148, 71, 0.18);
}

    .btn-registrar-principal:hover {
        background-color: #10763a;
    }

.btn-cancelar {
    background-color: #8d96a2;
    color: #ffffff;
}

    .btn-cancelar:hover {
        background-color: #737d89;
    }

.btn-nueva-infraccion {
    background-color: #ffc54c;
    color: #332500;
}

    .btn-nueva-infraccion:hover {
        background-color: #edb132;
    }

.btn-finalizar {
    background-color: #159447;
    color: #ffffff;
}

    .btn-finalizar:hover {
        background-color: #10763a;
    }

.datos-encontrados {
    margin-top: 22px;
    padding: 20px;
    border: 1px solid #bde3cc;
    border-radius: 10px;
    background-color: #f3fbf6;
}

.datos-encontrados-cabecera {
    margin-bottom: 17px;
    padding-bottom: 12px;
    border-bottom: 1px solid #cfe9d9;
    color: #15713c;
    font-size: 15px;
    font-weight: 700;
}

    .datos-encontrados-cabecera i {
        margin-right: 7px;
    }

.memoria-aviso {
    margin-top: 20px;
    padding: 11px 14px;
    border: 1px solid #cfe1f8;
    border-radius: 8px;
    background-color: #f1f7ff;
    color: #536f92;
    font-size: 13px;
}

    .memoria-aviso i {
        margin-right: 7px;
        color: #1672ff;
    }


.resumen-horizontal {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    overflow: hidden;
    border: 1px solid #dce5ef;
    border-radius: 10px;
    background-color: #f8fbff;
}

    .resumen-horizontal > div {
        min-height: 71px;
        padding: 12px 15px;
        border-right: 1px solid #dce5ef;
    }

        .resumen-horizontal > div:last-child {
            border-right: none;
        }

    .resumen-horizontal span {
        display: block;
        margin-bottom: 5px;
        color: #718097;
        font-size: 11px;
        font-weight: 750;
        text-transform: uppercase;
    }

    .resumen-horizontal label {
        color: #17243a;
        font-size: 16px;
        font-weight: 750;
    }

.descripcion-infraccion {
    display: block;
    margin-top: 10px;
    padding: 11px 13px;
    border: 1px solid #e0e7ef;
    border-radius: 8px;
    background-color: #f4f7fb;
    color: #46546a;
    font-size: 13px;
}

.table-responsive {
    width: 100%;
    overflow-x: auto;
}

.tabla-papeletas {
    width: 100%;
    min-width: 950px;
    border: 1px solid #dce5ef;
    border-collapse: collapse;
    background-color: #ffffff;
    font-size: 13px;
}

    .tabla-papeletas th {
        padding: 12px 10px;
        border-bottom: 2px solid #d5e0ed;
        background-color: #f1f6fc;
        color: #34445b;
        font-weight: 700;
        text-align: left;
        white-space: nowrap;
    }

    .tabla-papeletas td {
        padding: 11px 10px;
        border-bottom: 1px solid #e4eaf1;
        color: #3f4b5d;
        vertical-align: middle;
    }

    .tabla-papeletas tr:hover td {
        background-color: #f8fbff;
    }

.tabla-vacia {
    padding: 30px;
    color: #7c8797;
    text-align: center;
}

.btn-tabla-eliminar {
    display: inline-flex;
    align-items: center;
    justify-content: center;
    width: 32px;
    height: 32px;
    border: 1px solid #f0a6ab;
    border-radius: 6px;
    color: #dc3545;
    text-decoration: none;
}

    .btn-tabla-eliminar:hover {
        background-color: #fff0f1;
        color: #b4232d;
    }

.btn-limpiar-lista {
    padding: 7px 13px;
    border: none;
    border-radius: 7px;
    background-color: #e85656;
    color: #ffffff;
    cursor: pointer;
}

.totales-papeletas {
    display: flex;
    justify-content: flex-end;
    gap: 15px;
    flex-wrap: wrap;
    margin-top: 16px;
}

    .totales-papeletas > div {
        min-width: 145px;
        padding: 10px 14px;
        border: 1px solid #dce5ef;
        border-radius: 8px;
        background-color: #f8fbff;
        color: #526176;
        font-size: 13px;
    }

    .totales-papeletas label {
        margin-left: 5px;
        color: #1672ff;
        font-size: 16px;
        font-weight: 800;
    }

.mensaje-registro {
    display: block;
    width: 100%;
    margin-bottom: 20px;
    padding: 13px 16px;
    border-radius: 9px;
    font-size: 14px;
    font-weight: 600;
    box-sizing: border-box;
}

.mensaje-exito {
    border: 1px solid #91d1a8;
    background-color: #e5f8eb;
    color: #176638;
}

.mensaje-error {
    border: 1px solid #efacb2;
    background-color: #ffe9eb;
    color: #9c202b;
}


.acciones-finales {
    display: flex;
    justify-content: flex-end;
    gap: 14px;
    flex-wrap: wrap;
    margin: 5px 0 30px;
}


.registro-container input[type="text"],
.registro-container input[type="date"],
.registro-container input[type="time"],
.registro-container select,
.registro-container textarea {
    max-width: none;
}

.registro-container .row {
    --bs-gutter-x: 1.4rem;
}

.registro-container .h-100 {
    height: 100% !important;
}



@media screen and (max-width: 991px) {

    .registro-container {
        padding: 20px 18px 35px;
    }

    .registro-header {
        padding: 25px;
    }

        .registro-header h1 {
            font-size: 30px;
        }

    .resumen-horizontal {
        grid-template-columns: repeat(2, 1fr);
    }

        .resumen-horizontal > div:nth-child(2) {
            border-right: none;
        }

        .resumen-horizontal > div:nth-child(-n+2) {
            border-bottom: 1px solid #dce5ef;
        }
}

@media screen and (max-width: 576px) {

    .registro-container {
        padding: 15px 10px 30px;
    }

    .registro-header-contenido {
        align-items: flex-start;
        flex-direction: column;
    }

    .registro-header-icono {
        width: 58px;
        height: 58px;
        flex-basis: 58px;
        font-size: 25px;
    }

    .registro-header h1 {
        font-size: 26px;
    }

    .registro-header p {
        font-size: 14px;
    }

    .registro-card-header {
        align-items: flex-start;
        flex-direction: column;
    }

    .registro-card-body {
        padding: 18px 14px;
    }

    .resumen-horizontal {
        grid-template-columns: 1fr;
    }

        .resumen-horizontal > div {
            border-right: none;
            border-bottom: 1px solid #dce5ef;
        }

            .resumen-horizontal > div:last-child {
                border-bottom: none;
            }

    .acciones-finales {
        flex-direction: column;
    }

        .acciones-finales .btn-registro {
            width: 100%;
        }

    .totales-papeletas > div {
        width: 100%;
    }
}

    </style>
</asp:Content>



<asp:Content
    ID="Content4"
    ContentPlaceHolderID="ContentPlaceHolder1"
    runat="server">

    <div class="registro-container">

        <!-- ENCABEZADO -->

        <div class="registro-header">

            <div class="registro-header-contenido">

                <div class="registro-header-icono">
                    <i class="fa-solid fa-file-circle-plus"></i>
                </div>

                <div>
                    <h1>Registro de Papeletas</h1>

                    <p>
                        Registra una o varias infracciones para
                        el mismo infractor.
                    </p>
                </div>

            </div>

        </div>

        <asp:Label
            ID="lblMensaje"
            runat="server"
            Visible="false">
        </asp:Label>

        <!-- POLICÍA -->

        <div class="registro-card">

            <div class="registro-card-header">

                <div class="registro-card-titulo">
                    <i class="fa-solid fa-user-shield"></i>
                    Datos del policía
                </div>

                <span class="registro-card-indicador">
                    Identificación obligatoria
                </span>

            </div>

            <div class="registro-card-body">

                <div class="row g-3 align-items-end">

                    <div class="col-lg-3 col-md-6">

                        <label class="registro-label">
                            DNI del policía
                            <span class="campo-requerido">*</span>
                        </label>

                        <asp:TextBox
                            ID="txtDniPolicia"
                            runat="server"
                            CssClass="registro-control"
                            MaxLength="8"
                            placeholder="Ingrese 8 dígitos">
                        </asp:TextBox>

                    </div>

                    <div class="col-lg-2 col-md-6">

                        <asp:Button
                            ID="btnBuscarPolicia"
                            runat="server"
                            Text="Buscar policía"
                            CssClass="btn-registro btn-buscar"
                            CausesValidation="false"
                            OnClick="btnBuscarPolicia_Click" />

                    </div>

                    <div class="col-lg-2 col-md-6">

                        <label class="registro-label">
                            Código
                        </label>

                        <asp:TextBox
                            ID="txtCodigoPolicia"
                            runat="server"
                            CssClass="registro-control campo-bloqueado"
                            ReadOnly="true">
                        </asp:TextBox>

                    </div>

                    <div class="col-lg-5 col-md-6">

                        <label class="registro-label">
                            Nombre completo
                        </label>

                        <asp:TextBox
                            ID="txtNombrePolicia"
                            runat="server"
                            CssClass="registro-control campo-bloqueado"
                            ReadOnly="true">
                        </asp:TextBox>

                    </div>

                </div>

            </div>

        </div>

        <div class="row g-4">

            <!-- INFRACTOR -->

            <div class="col-xl-5">

                <div class="registro-card h-100">

                    <div class="registro-card-header">

                        <div class="registro-card-titulo">
                            <i class="fa-solid fa-address-card"></i>
                            1. Buscar infractor
                        </div>

                    </div>

                    <div class="registro-card-body">

                        <div class="row g-3 align-items-end">

                            <div class="col-md-7">

                                <label class="registro-label">
                                    DNI del infractor
                                    <span class="campo-requerido">*</span>
                                </label>

                                <asp:TextBox
                                    ID="txtDniInfractor"
                                    runat="server"
                                    CssClass="registro-control"
                                    MaxLength="8"
                                    placeholder="Ingrese 8 dígitos">
                                </asp:TextBox>

                            </div>

                            <div class="col-md-5">

                                <asp:Button
                                    ID="btnBuscarInfractor"
                                    runat="server"
                                    Text="Buscar infractor"
                                    CssClass="btn-registro btn-buscar"
                                    CausesValidation="false"
                                    OnClick="btnBuscarInfractor_Click" />

                            </div>

                        </div>

                        <asp:Panel
                            ID="pnlDatosInfractor"
                            runat="server"
                            Visible="false"
                            CssClass="datos-encontrados">

                            <div class="datos-encontrados-cabecera">
                                <i class="fa-solid fa-circle-check"></i>
                                Infractor encontrado
                            </div>

                            <div class="row g-3">

                                <div class="col-md-4">

                                    <label class="registro-label">
                                        Código
                                    </label>

                                    <asp:TextBox
                                        ID="txtCodInfractor"
                                        runat="server"
                                        CssClass="registro-control campo-bloqueado"
                                        ReadOnly="true">
                                    </asp:TextBox>

                                </div>

                                <div class="col-md-8">

                                    <label class="registro-label">
                                        Nombre completo
                                    </label>

                                    <asp:TextBox
                                        ID="txtNombreInfractor"
                                        runat="server"
                                        CssClass="registro-control campo-bloqueado"
                                        ReadOnly="true">
                                    </asp:TextBox>

                                </div>

                                <div class="col-md-4">

                                    <label class="registro-label">
                                        Brevete
                                    </label>

                                    <asp:TextBox
                                        ID="txtBrevete"
                                        runat="server"
                                        CssClass="registro-control campo-bloqueado"
                                        ReadOnly="true">
                                    </asp:TextBox>

                                </div>

                                <div class="col-md-5">

                                    <label class="registro-label">
                                        Distrito
                                    </label>

                                    <asp:TextBox
                                        ID="txtDistritoInfractor"
                                        runat="server"
                                        CssClass="registro-control campo-bloqueado"
                                        ReadOnly="true">
                                    </asp:TextBox>

                                </div>

                                <div class="col-md-3">

                                    <label class="registro-label">
                                        Estado
                                    </label>

                                    <asp:TextBox
                                        ID="txtEstadoInfractor"
                                        runat="server"
                                        CssClass="registro-control campo-bloqueado"
                                        ReadOnly="true">
                                    </asp:TextBox>

                                </div>

                                <div class="col-12">

                                    <label class="registro-label">
                                        Dirección
                                    </label>

                                    <asp:TextBox
                                        ID="txtDireccionInfractor"
                                        runat="server"
                                        CssClass="registro-control campo-bloqueado"
                                        ReadOnly="true">
                                    </asp:TextBox>

                                </div>

                            </div>

                        </asp:Panel>

                        <div class="memoria-aviso">
                            <i class="fa-solid fa-circle-info"></i>

                            Los datos del infractor se conservarán
                            mientras registras sus papeletas.
                        </div>

                    </div>

                </div>

            </div>

            <!-- INFRACCIÓN -->

            <div class="col-xl-7">

                <div class="registro-card h-100">

                    <div class="registro-card-header">

                        <div class="registro-card-titulo">
                            <i class="fa-solid fa-triangle-exclamation"></i>
                            2. Datos de la infracción
                        </div>

                    </div>

                    <div class="registro-card-body">

                        <div class="row g-3">

                            <div class="col-md-7">

                                <label class="registro-label">
                                    Tipo de infracción
                                    <span class="campo-requerido">*</span>
                                </label>

                                <asp:DropDownList
                                    ID="ddlInfraccion"
                                    runat="server"
                                    CssClass="registro-control"
                                    AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlInfraccion_SelectedIndexChanged">
                                </asp:DropDownList>

                            </div>

                            <div class="col-md-5">

                                <label class="registro-label">
                                    Código del vehículo
                                    <span class="campo-requerido">*</span>
                                </label>

                                <asp:TextBox
                                    ID="txtCodigoVehiculo"
                                    runat="server"
                                    CssClass="registro-control"
                                    MaxLength="6"
                                    placeholder="Ejemplo: V00001">
                                </asp:TextBox>

                            </div>

                            <div class="col-md-6">

                                <label class="registro-label">
                                    Fecha
                                    <span class="campo-requerido">*</span>
                                </label>

                                <asp:TextBox
                                    ID="txtFechaInfraccion"
                                    runat="server"
                                    TextMode="Date"
                                    CssClass="registro-control">
                                </asp:TextBox>

                            </div>

                            <div class="col-md-6">

                                <label class="registro-label">
                                    Hora
                                    <span class="campo-requerido">*</span>
                                </label>

                                <asp:TextBox
                                    ID="txtHoraInfraccion"
                                    runat="server"
                                    TextMode="Time"
                                    CssClass="registro-control">
                                </asp:TextBox>

                            </div>

                            <div class="col-12">

                                <label class="registro-label">
                                    Lugar
                                    <span class="campo-requerido">*</span>
                                </label>

                                <asp:TextBox
                                    ID="txtLugar"
                                    runat="server"
                                    CssClass="registro-control"
                                    MaxLength="150"
                                    placeholder="Lugar de la intervención">
                                </asp:TextBox>

                            </div>

                            <div class="col-12">

                                <label class="registro-label">
                                    Referencia
                                </label>

                                <asp:TextBox
                                    ID="txtReferencia"
                                    runat="server"
                                    CssClass="registro-control"
                                    MaxLength="200"
                                    placeholder="Referencia del lugar">
                                </asp:TextBox>

                            </div>

                            <div class="col-md-6">

                                <label class="registro-label">
                                    Información adicional
                                </label>

                                <asp:TextBox
                                    ID="txtInfoAdicional"
                                    runat="server"
                                    CssClass="registro-control registro-textarea"
                                    TextMode="MultiLine"
                                    Rows="3"
                                    MaxLength="100">
                                </asp:TextBox>

                            </div>

                            <div class="col-md-6">

                                <label class="registro-label">
                                    Observaciones
                                </label>

                                <asp:TextBox
                                    ID="txtObservaciones"
                                    runat="server"
                                    CssClass="registro-control registro-textarea"
                                    TextMode="MultiLine"
                                    Rows="3"
                                    MaxLength="100">
                                </asp:TextBox>

                            </div>

                            <div class="col-12">

                                <div class="resumen-horizontal">

                                    <div>
                                        <span>Código</span>

                                        <asp:Label
                                            ID="lblCodigoInfraccion"
                                            runat="server"
                                            Text="-">
                                        </asp:Label>
                                    </div>

                                    <div>
                                        <span>Calificación</span>

                                        <asp:Label
                                            ID="lblCalificacion"
                                            runat="server"
                                            Text="-">
                                        </asp:Label>
                                    </div>

                                    <div>
                                        <span>Puntos</span>

                                        <asp:Label
                                            ID="lblPuntos"
                                            runat="server"
                                            Text="0">
                                        </asp:Label>
                                    </div>

                                    <div>
                                        <span>UIT</span>

                                        <asp:Label
                                            ID="lblUit"
                                            runat="server"
                                            Text="0.00">
                                        </asp:Label>
                                    </div>

                                </div>

                                <asp:Label
                                    ID="lblDescripcionInfraccion"
                                    runat="server"
                                    Text="-"
                                    CssClass="descripcion-infraccion">
                                </asp:Label>

                            </div>

                            <div class="col-12">

                                <asp:Button
                                    ID="btnRegistrar"
                                    runat="server"
                                    Text="Registrar papeleta"
                                    CssClass="btn-registro btn-registrar-principal"
                                    OnClick="btnRegistrar_Click" />

                            </div>

                        </div>

                    </div>

                </div>

            </div>

        </div>

        <!-- TABLA TEMPORAL -->

        <div class="registro-card">

            <div class="registro-card-header">

                <div class="registro-card-titulo">
                    <i class="fa-solid fa-table-list"></i>
                    Papeletas registradas para este infractor
                </div>

                <asp:Button
                    ID="btnLimpiarLista"
                    runat="server"
                    Text="Limpiar lista"
                    CssClass="btn-limpiar-lista"
                    CausesValidation="false"
                    OnClick="btnLimpiarLista_Click" />

            </div>

            <div class="registro-card-body">

                <div class="table-responsive">

                    <asp:GridView
                        ID="gvPapeletasRegistradas"
                        runat="server"
                        AutoGenerateColumns="false"
                        CssClass="tabla-papeletas"
                        GridLines="None"
                        OnRowCommand="gvPapeletasRegistradas_RowCommand">

                        <Columns>

                            <asp:TemplateField HeaderText="N.°">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField
                                DataField="CodPapeleta"
                                HeaderText="Código" />

                            <asp:BoundField
                                DataField="FechaHora"
                                HeaderText="Fecha y hora" />

                            <asp:BoundField
                                DataField="Infraccion"
                                HeaderText="Infracción" />

                            <asp:BoundField
                                DataField="CodVehiculo"
                                HeaderText="Vehículo" />

                            <asp:BoundField
                                DataField="Lugar"
                                HeaderText="Lugar" />

                            <asp:BoundField
                                DataField="Puntos"
                                HeaderText="Puntos" />

                            <asp:BoundField
                                DataField="Uit"
                                HeaderText="UIT"
                                DataFormatString="{0:N2}" />

                            <asp:BoundField
                                DataField="Estado"
                                HeaderText="Estado" />

                            <asp:TemplateField HeaderText="Acciones">

                                <ItemTemplate>

                                    <asp:LinkButton
                                        ID="btnQuitarFila"
                                        runat="server"
                                        CommandName="QuitarFila"
                                        CommandArgument='<%# Container.DataItemIndex %>'
                                        CssClass="btn-tabla-eliminar"
                                        CausesValidation="false"
                                        ToolTip="Quitar de la vista">

                                        <i class="fa-solid fa-trash"></i>

                                    </asp:LinkButton>

                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>

                        <EmptyDataTemplate>
                            <div class="tabla-vacia">
                                Todavía no se han registrado papeletas
                                en esta operación.
                            </div>
                        </EmptyDataTemplate>

                    </asp:GridView>

                </div>

                <div class="totales-papeletas">

                    <div>
                        Total papeletas:
                        <asp:Label
                            ID="lblTotalPapeletas"
                            runat="server"
                            Text="0">
                        </asp:Label>
                    </div>

                    <div>
                        Total puntos:
                        <asp:Label
                            ID="lblTotalPuntos"
                            runat="server"
                            Text="0">
                        </asp:Label>
                    </div>

                    <div>
                        Total UIT:
                        <asp:Label
                            ID="lblTotalUit"
                            runat="server"
                            Text="0.00">
                        </asp:Label>
                    </div>

                </div>

            </div>

        </div>

        <!-- ACCIONES -->

        <div class="acciones-finales">

            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                CssClass="btn-registro btn-cancelar"
                CausesValidation="false"
                OnClick="btnCancelar_Click" />

            <asp:Button
                ID="btnNuevaInfraccion"
                runat="server"
                Text="Nueva infracción"
                CssClass="btn-registro btn-nueva-infraccion"
                CausesValidation="false"
                OnClick="btnNuevaInfraccion_Click" />

            <asp:Button
                ID="btnFinalizar"
                runat="server"
                Text="Finalizar y salir"
                CssClass="btn-registro btn-finalizar"
                CausesValidation="false"
                OnClick="btnFinalizar_Click" />

        </div>

    </div>

</asp:Content>