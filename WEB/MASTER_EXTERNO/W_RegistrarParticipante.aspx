<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER_EXTERNO/Master_externo.Master" AutoEventWireup="true" CodeBehind="W_RegistrarParticipante.aspx.cs" Inherits="WEB.MASTER_EXTERNO.W_RegistrarParticipante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../assets/js/jquery-3.1.1.min.js"></script>
    <script src="../assets/js/material.min.js"></script>

<script type="text/javascript">
        function ImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=Image1.ClientID%>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                };
                $('#hftxtimg').val("Lleno");
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content col-md-8 col-md-offset-2">
        <div class="container-fluid">
            <div class="row">
                <div class="card">
                    <form id="form1" runat="server" method="POST" class="form">
                        <div class="card-header card-header-text" data-background-color="red">
                            <h4 id="txtPagina" runat="server" class="card-title">Registrar Participante</h4>
                        </div>
                        <div class="card-content">

                            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
                            <%--<asp:UpdatePanel ID="upParticipante" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>--%>
                            <div class="row">
                                <div class="col-md-8 col-md-offset-2">
                                    <label class="col-md-2 col-sm-2 label-on-left">DNI:</label>
                                    <div class="col-lg-4 col-md-4 col-sd-4">
                                        <div class="form-group label-floating is-empty">
                                            <label class="control-label"></label>
                                            <asp:TextBox ID="txtDNI" runat="server" class="form-control" MaxLength="8" Enabled="True" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <label class="col-md-2 label-on-left">Nombres:</label>
                                    <div class="col-lg-4 col-md-4 col-sd-4">
                                        <div class="form-group label-floating is-empty">
                                            <label class="control-label"></label>
                                            <asp:TextBox ID="txtNombre" runat="server" class="form-control" required></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-md-1 label-on-left">Apellido Paterno</label>
                                <div class="col-lg-3 col-md-3 col-sd-6">
                                    <div class="form-group label-floating is-empty">
                                        <label class="control-label"></label>
                                        <asp:TextBox ID="txtApellidoP" runat="server" class="form-control" required></asp:TextBox>
                                    </div>
                                </div>
                                <label class="col-md-1 label-on-left">Apellido Materno</label>
                                <div class="col-lg-3 col-md-3 col-sd-6">
                                    <div class="form-group label-floating is-empty">
                                        <label class="control-label"></label>
                                        <asp:TextBox ID="txtApellidoM" runat="server" class="form-control" required></asp:TextBox>
                                    </div>
                                </div>
                                <label class="col-md-1 label-on-left">Genero</label>
                                <div class="col-lg-3 col-md-3 checkbox-radios">
                                    </br>
                                            </br>
                                             <div class="col-md-6">
                                                 <asp:RadioButton ID="rbFemenino" runat="server" Text="Femenino" GroupName="Genero"
                                                     AutoPostBack="True" EnableTheming="True" CssClass="radio-inline"
                                                     ForeColor="Red" />
                                             </div>
                                    <div class="col-md-6">
                                        <asp:RadioButton ID="rbMasculino" runat="server" Text="Masculino" GroupName="Genero"
                                            AutoPostBack="True" CssClass="radio-inline"
                                            ForeColor="red" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-md-2 label-on-left">Academia</label>
                                <div class="col-lg-6 col-md-6 col-sd-6">
                                    <div class="form-group label-floating is-empty">
                                        <label class="control-label"></label>
                                        <asp:TextBox ID="txtNombreAcademia" runat="server" class="form-control" required></asp:TextBox>
                                    </div>
                                </div>
                                <label class="col-md-2 label-on-left">Celular:</label>
                                <div class="col-lg-2 col-md-2 col-sd-6">
                                    <div class="form-group label-floating is-empty">
                                        <label class="control-label"></label>
                                        <asp:TextBox ID="txtCelular" runat="server" class="form-control" required></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <label class="col-md-2 label-on-left">Correo:</label>
                                <div class="col-lg-6 col-md-6 col-sd-6">
                                    <div class="form-group label-floating is-empty">
                                        <label class="control-label"></label>
                                        <asp:TextBox ID="txtCorreo" runat="server" class="form-control" TextMode="Email" required="true"></asp:TextBox>
                                    </div>
                                </div>
                                <label class="col-md-2 label-on-left">Fecha Nacimiento:</label>
                                <div class="col-lg-2 col-md-2 col-sd-6">
                                    <div class="form-group label-floating is-empty">
                                        <label class="control-label"></label>
                                        <asp:TextBox ID="txtFechaNacimiento" runat="server" class="form-control datepicker" type="date" required></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8 col-md-offset-2">
                                    <label class="col-md-2 col-sm-2 label-on-left">Contraseña:</label>
                                    <div class="col-lg-4 col-md-4 col-sd-4">
                                        <div class="form-group label-floating is-empty">
                                            <label class="control-label"></label>
                                            <asp:TextBox ID="txtContraseña" name="texto" runat="server" class="form-control" type="password" placeholder="Contraseña" BackColor="White" Width="100%"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Las Contraseñas deben  ser IGUALES!!!" ControlToCompare="txtContraseña" ControlToValidate="txtcontra2" ForeColor="Red"></asp:CompareValidator>

                                        </div>
                                    </div>
                                    <label class="col-md-3 label-on-left">Vuelava a escribir contraseña:</label>
                                    <div class="col-lg-3 col-md-3 col-sd-6">
                                        <div class="form-group label-floating is-empty">
                                            <label class="control-label"></label>
                                            <asp:TextBox ID="txtcontra2" name="texto" runat="server" class="form-control" type="password" placeholder="Confirmar Contraseña"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6 col-md-offset-3">
                                    <label class="col-md-6 label-on-left">Imagen</label>
                                    <div>

                                        <asp:Image ID="Image1" runat="server" class="rounded" />

                                        <input name="fileAnexo" type="file" id="FileUpload1" runat="server" accept=".png,.jpg" class="btn btn-warning" onchange="ImagePreview(this);" />
                                        <br />
                                    </div>
                                    <div class="center">
                                    </div>
                                </div>

                            </div>
                            <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </div>
                        <div class="card-footer">
                            <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="col-lg-2 col-md-2 col-sm-6">
                                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-fill btn-success" OnClick="btnRegistrar_Click" />

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="col-lg-2 col-md-2 col-sm-6">
                                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-fill btn-danger" OnClick="btnRegresar_Click"/>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <script src="../assets/js/App/UploadFile.js"></script>
    <script src="../assets/js/sweetalert.min.js"></script>
    <script>
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
        function getQueryStringParameter(paramToRetrieve) {
            if (document.URL.split("?")[1] != undefined) {
                var params = document.URL.split("?")[1].split("&");
                var strParams = "";
                for (var i = 0; i < params.length; i = i + 1) {
                    var singleParam = params[i].split("=");
                    if (singleParam[0] == paramToRetrieve)
                        return singleParam[1].replace("#", "");
                }
            }
        }
        function showSuccessMessage2() {
            setTimeout(function () {
                swal({
                    title: "Todo guardado",
                    text: "Pulsa el botón y se te redirigirá al Login",
                    type: "success"
                }, function () {
                    window.location = "MASTER_EXTERNO/W_Login.aspx";
                });
            }, 1000);
        }
        
    </script>
    
</asp:Content>
