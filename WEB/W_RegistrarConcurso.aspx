<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_RegistrarConcurso.aspx.cs" Inherits="WEB.W_RegistrarConcurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="card">
                    <div class="card-header card-header-text" data-background-color="red">
                        <h4 id="txtPagina" runat="server" class="card-title">Registrar Concurso</h4>
                    </div>
                    <div class="card-content">

                        <form id="form1" runat="server" method="POST" class="form">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="upConcurso" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <asp:Panel ID="Panel2" runat="server" CssClass="col-lg-6 col-md-6 col-sd-12">
                                        <div class="row clearfix">
                                            <div class="col-lg-12 col-md-12 col-sd-12">
                                                <label class="col-md-2 label-on-left">Codigo</label>
                                                <div class="form-group label-floating is-empty">
                                                    <label class="control-label"></label>
                                                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control " Enabled="False"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Nombre</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Lugar</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtlugar" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Fecha</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtFecha" runat="server" class="form-control datepicker" type="date"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-5 col-md-5 col-sd-6">
                                            <label class="col-md-2 label-on-left">Cantidad Seriado</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtcantSeriado" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-md-2"></div>
                                        <div class="col-lg-5 col-md-5 col-sd-6">
                                            <label class="col-md-2 label-on-left">Cantidad Novel</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtcantNovel" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3"></div>
                                        <asp:Panel ID="Panel1" runat="server" CssClass="col-lg-6 col-md-6 col-sd-12">
                                            <div class="col-lg-5 col-md-5 col-sd-6">
                                                <label class="col-md-2 label-on-left">Estado</label>
                                                <div class="form-group label-floating is-empty">
                                                    <label class="control-label"></label>
                                                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="selectpicker">
                                                        <asp:ListItem Text="---Seleccione----" Value="0" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="No Realizado" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Realizado" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <div class="col-lg-3 col-md-3"></div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-8 col-md-8 col-sm-12">
                                            <p></p>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-6">
                                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-fill btn-success" OnClick="btnRegistrar_Click" />
                                        </div>
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
</asp:Content>
