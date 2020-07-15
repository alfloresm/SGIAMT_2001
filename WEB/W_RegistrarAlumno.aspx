<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_RegistrarAlumno.aspx.cs" Inherits="WEB.W_RegistrarAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-left: 30px">
        <div class="h3" style="margin-top: 10px">
            Registrar Alumno
        </div>
    </div>
    <section>
        <div class="container-fluid">

            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <form id="form1" runat="server" method="POST" class="form">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <div class="body">

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <div class="col-sm-6">
                                                        <div class="form-group form-float" style="margin-left: 30px">
                                                            DNI:
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtDNI" class="form-control" runat="server" placeHolder="Ingresa DNI"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group form-float">
                                                            Nombres:
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtNombre" class="form-control" runat="server" placeHolder="Ingresa nombres"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>

                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                <ContentTemplate>
                                                    <div class="col-sm-6">
                                                        <div class="form-group form-float" style="margin-left: 30px">
                                                            Apellido Paterno
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtApellidoP" class="form-control" runat="server" placeHolder="Ingresa Apellido Paterno"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <div class="form-group form-float" style="margin-top: 10px">
                                                            Apellido Materno
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtApellidoM" class="form-control" runat="server" placeHolder="Ingresa Apellido Materno"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>

                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <div class="col-sm-4">
                                                        <div class="form-group form-float" style="margin-left: 30px">
                                                            Fecha de Nacimiento
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtFechaNacimiento" class="form-control" runat="server" TextMode="Date" MaxLength="10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <div class="form-group form-float" style="margin-left: 30px">
                                                            Contraseña:
                                                       <div class="form-line focused">
                                                           <div class="form-line">
                                                               <asp:TextBox ID="txtContrasenia" class="form-control" runat="server" placeHolder="Ingresa la contraseña"></asp:TextBox>
                                                           </div>
                                                       </div>
                                                        </div>
                                                    </div>

                                                    <div class="col-sm-4">
                                                        <div class="form-group form-float" style="margin-left: 30px">
                                                            Nombre de la Academia:
                                                       <div class="form-line focused">
                                                           <div class="form-line">
                                                               <asp:TextBox ID="txtNombreAcademia" class="form-control" runat="server" placeHolder="Ingresa el nombre de la academia"></asp:TextBox>
                                                           </div>
                                                       </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>

                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <div class="col-sm-4">
                                                        <div class="form-group form-float" style="margin-left: 30px">
                                                            Correo:
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtCorreo" class="form-control" runat="server" placeHolder="Ingresa tu correo"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <div class="form-group form-float">
                                                            Celular:
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtCelular" class="form-control" runat="server" placeHolder="Ingresa celular"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group form-float" style="margin-left: 20px">
                                                            Estado:
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList runat="server" ID="ddlEstado" CssClass="form-control">
                                                                <asp:ListItem Value="NULO">---Selecciona---</asp:ListItem>
                                                                <asp:ListItem Value="activo">Activo</asp:ListItem>
                                                                <asp:ListItem Value="inactivo">Inactivo</asp:ListItem>

                                                            </asp:DropDownList>
                                                        </ContentTemplate>

                                                    </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">

                                    <div class="col-md-4">
                                        <div class="form-group form-float" style="margin-left: 30px">
                                            Horario
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList runat="server" ID="ddlHoras" CssClass="form-control">
                                                        <asp:ListItem Value="NULO">Seleccione horario</asp:ListItem>
                                                        <asp:ListItem Value="08:00">8:00 AM - 10:30 AM</asp:ListItem>
                                                        <asp:ListItem Value="11:00">11:00 AM - 12:30 PM</asp:ListItem>
                                                        <asp:ListItem Value="1:00">1:00 PM - 2:30 PM</asp:ListItem>
                                                        <asp:ListItem Value="2:00">2:30 PM - 4:00 PM</asp:ListItem>
                                                        <asp:ListItem Value="4:00">4:00 PM - 5:30 PM</asp:ListItem>

                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="form-group form-float">
                                            Dirección:
                                        <div class="form-line focused">
                                            <div class="form-line">
                                                <asp:TextBox ID="txtDireccion" class="form-control" runat="server" placeHolder="Ingresa tu direccion"></asp:TextBox>
                                            </div>
                                        </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="form-group form-float" style="margin-left: 30px">
                                            Sexo:
                                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList runat="server" ID="ddlSexo" CssClass="form-control">
                                                        <asp:ListItem Value="NULO">Seleccionar</asp:ListItem>
                                                        <asp:ListItem Value="femenino">Femenino</asp:ListItem>
                                                        <asp:ListItem Value="masculino">Masculino</asp:ListItem>

                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
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
                                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-fill btn-success" OnClick="btnRegistrar_Click"/>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="col-lg-2 col-md-2 col-sm-6">
                                    <asp:Button ID="btnRegresar" runat="server" Text="cancelar" CssClass="btn btn-fill btn-danger" OnClick="btnRegresar_Click" />
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
