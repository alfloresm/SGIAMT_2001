<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_RegistrarAlumno2.aspx.cs" Inherits="WEB.W_RegistrarAlumno2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="card">
                    <div class="card-header card-header-text" data-background-color="red">
                        <h4 id="txtPagina" runat="server" class="card-title">Registrar Alumno</h4>
                    </div>
                    <div class="card-content">

                        <form id="form1" runat="server" method="POST" class="form">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="upAlumno" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-6 col-sd-6">
                                            <label class="col-md-2 label-on-left">DNI:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtDNI" runat="server" class="form-control" MaxLength="8" Enabled="True" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-6 col-sd-6">
                                            <label class="col-md-2 label-on-left">Nombres:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNombre" runat="server" class="form-control" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Apellido Paterno</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtApellidoP" runat="server" class="form-control" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Apellido Materno</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtApellidoM" runat="server" class="form-control" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Fecha Nacimiento:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtFechaNacimiento" runat="server" class="form-control datepicker" type="date" required></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Sexo:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:DropDownList ID="ddlSexo" runat="server" CssClass="selectpicker">
                                                    <asp:ListItem Text="---Seleccione----" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
                                                    <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <asp:Panel ID="panelContrasenia" runat="server">
                                            <div class="col-lg-4 col-md-4 col-sd-6">
                                                <label class="col-md-2 label-on-left">Contraseña:</label>
                                                <div class="form-group label-floating is-empty">
                                                    <label class="control-label"></label>
                                                    <asp:TextBox ID="txtContrasenia" runat="server" class="form-control" TextMode="Password" required></asp:TextBox>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Direccion:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtDireccion" runat="server" placeHolder="Ingresa tu direccion" class="form-control" MaxLength="50" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--<div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Academia</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNombreAcademia" runat="server" class="form-control" Text="TUSUY PERU"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Correo:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtCorreo" runat="server" class="form-control" TextMode="Email" required="true"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Celular:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtCelular" runat="server" class="form-control" required></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <%--<div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Estado:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="selectpicker">
                                                    <asp:ListItem Text="---Seleccione----" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                                                    <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>--%>
                                        <%--<asp:Panel ID="Panel2" runat="server" CssClass="col-lg-6 col-md-6 col-sd-12">--%>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Nivel:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:DropDownList ID="ddlNivel" runat="server" CssClass="selectpicker">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--</asp:Panel>--%>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Horario:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:DropDownList ID="ddlHorario" runat="server" CssClass="selectpicker">
                                                    <asp:ListItem Text="---Seleccione----" Value="0" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="8:00am - 9:30am" Value="8:00am - 9:30am"></asp:ListItem>
                                                    <asp:ListItem Text="11:00am - 12:30pm" Value="11:00am - 12:30pm"></asp:ListItem>
                                                    <asp:ListItem Text="1:00pm - 2:30pm" Value="1:00pm - 2:30pm"></asp:ListItem>
                                                    <asp:ListItem Text="3:00pm - 4:30pm" Value="3:00pm - 4:30pm"></asp:ListItem>
                                                    <asp:ListItem Text="5:00pm - 6:30pm" Value="5:00pm - 6:30pm"></asp:ListItem>
                                                    <asp:ListItem Text="7:00pm - 8:30pm" Value="7:00pm - 8:30pm"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-lg-8 col-md-8 col-sm-12">
                                            <p></p>
                                        </div>
                                        <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="col-lg-2 col-md-2 col-sm-6">
                                                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-fill btn-success" OnClick="btnRegistrar_Click" />

                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="col-lg-2 col-md-2 col-sm-6">
                                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-fill btn-danger" OnClick="btnRegresar_Click" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        function showSuccessMessage2() {
            setTimeout(function () {
                swal({
                    title: "Todo guardado",
                    text: "Pulsa el botón y se te redirigirá",
                    type: "success"
                }, function () {
                    window.location = "GestionCatalogo.aspx";
                });
            }, 1000);
        }
        function showMessage(from, align, message, type) {
            $.notify({
                icon: "notifications",
                message: message

            }, {
                    type: type,
                    timer: 3000,
                    placement: {
                        from: from,
                        align: align
                    }
                });
        }

    </script>

</asp:Content>
