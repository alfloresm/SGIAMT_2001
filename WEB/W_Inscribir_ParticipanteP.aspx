<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_Inscribir_ParticipanteP.aspx.cs" Inherits="WEB.W_Inscribirr_ParticipanteP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="card-header card-header-text" data-background-color="red">
                            <h4 id="txtPagina" runat="server" class="card-title">Inscribir Participante</h4>
                        </div>
                        <div class="card-content">
                            <form id="form1" runat="server">
                                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
                                <%--<asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                    <ContentTemplate>--%>
                                <div class="row">

                                    <div class="col-md-4 col-md-offset-1">
                                        <label class="col-md-4 label-on-left">Concurso</label>
                                        <div class="form-group label-floating is-empty">
                                            <label class="control-label"></label>
                                            <asp:DropDownList ID="ddlConcurso" runat="server" CssClass="selectpicker">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-4 col-md-offset-2 checkbox-radios">
                                        <label class="col-md-12 label-on-left">Modalidad</label>
                                        </br>
                                        </br>
                                                <div class="col-md-6">
                                                    <asp:RadioButton ID="RbSeriado" runat="server" Text="Seriado" GroupName="modalidad"
                                                        AutoPostBack="True" OnCheckedChanged="RbSeriado_CheckedChanged" EnableTheming="True" CssClass="radio-inline"
                                                        ForeColor="Black" />
                                                </div>
                                        <div class="col-md-6">
                                            <asp:RadioButton ID="RbNovel" runat="server" Text="Novel" GroupName="modalidad"
                                                AutoPostBack="True" OnCheckedChanged="RbNovel_CheckedChanged" CssClass="radio-inline"
                                                ForeColor="Black" />
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="row">
                                    <asp:Panel ID="pnlParticipanteS" runat="server" CssClass="col-lg-12 col-md-12 col-sm-12">
                                        <div class="col-md-6">
                                            <div class="col-md-8 form-group form-search is-empty">
                                                <asp:TextBox ID="txtDni" runat="server" class="form-control" placeholder="Buscar"></asp:TextBox>
                                                <span class="material-input"></span>
                                                <asp:Label ID="lblMensaje1" runat="server" Text=""></asp:Label>
                                            </div>
                                            <asp:UpdatePanel ID="upnBotonBuscar1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btnBuscar1" runat="server" CssClass="btn btn-white btn-round btn-just-icon" OnClick="btnBuscar1_Click">
                                                    <i class="material-icons">search</i>
                                                    <div class="ripple-container"></div>
                                                    </asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:UpdatePanel ID="updPanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="row">

                                                        <label class="col-md-3 label-on-left">Nombre</label>
                                                        <div class="col-md-9">
                                                            <div class="form-group label-floating is-empty">
                                                                <label class="control-label"></label>
                                                                <asp:TextBox ID="txtNombre1" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="col-md-3 label-on-left">Categoria</label>
                                                        <div class="col-md-9">
                                                            <div class="form-group label-floating is-empty">
                                                                <label class="control-label"></label>
                                                                <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <asp:TextBox ID="txtGen" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <br />
                                <div class="row">
                                    <asp:Panel ID="pnlParticipanteN" runat="server">
                                        <div class="col-md-6">
                                            <div class="col-md-8 form-group form-search is-empty">
                                                <asp:TextBox ID="txtdni2" runat="server" class="form-control" placeholder="Buscar"></asp:TextBox>
                                                <asp:Label ID="lblmensaje2" runat="server" Text=""></asp:Label>
                                                <span class="material-input"></span>
                                            </div>
                                            <asp:UpdatePanel ID="upnBotonBuscar2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btnBuscar2" runat="server" CssClass="btn btn-white btn-round btn-just-icon" OnClick="btnBuscar2_Click">
                                                    <i class="material-icons">search</i>
                                                    <div class="ripple-container"></div>
                                                    </asp:LinkButton>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:UpdatePanel ID="updPanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="row">
                                                        <label class="col-md-3 label-on-left">Nombre</label>
                                                        <div class="col-md-9">
                                                            <div class="form-group label-floating is-empty">
                                                                <label class="control-label"></label>
                                                                <asp:TextBox ID="txtNombre2" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <label class="col-md-3 label-on-left">Categoria</label>
                                                        <div class="col-md-9">
                                                            <div class="form-group label-floating is-empty">
                                                                <label class="control-label"></label>
                                                                <asp:TextBox ID="txtCategoria2" runat="server" CssClass="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="row">
                                    <div class="col-lg-8 col-md-8 col-sm-12">
                                        <p></p>
                                    </div>
                                    <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="col-lg-2 col-md-2 col-sm-6">
                                                <asp:Button ID="btnInscribir" runat="server" Text="Inscribir" CssClass="btn btn-fill btn-success" OnClick="btnInscribir_Click" />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="col-lg-2 col-md-2 col-sm-6">
                                        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-fill btn-danger" OnClick="btnRegresar_Click" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3 class="text-left">PAGAR: </h3>
                                        <h1 id="H1" runat="server" class="card-title">S/.20</h1>
                                    </div>
                                </div>
                                <%--</ContentTemplate>
                                </asp:UpdatePanel>--%>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
    </script>
</asp:Content>
