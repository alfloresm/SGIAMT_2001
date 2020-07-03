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
                        <div class="row clearfix"><p> </p></div>
                        <form id="form1" runat="server" method="POST" class="form">
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
                                <div class="col-lg-8 col-md-8 col-sm-12"><p> </p></div>
                                <div class="col-lg-2 col-md-2 col-sm-6">
                                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-fill btn-success" /></div>
                                <div class="col-lg-2 col-md-2 col-sm-6">
                                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-fill btn-danger" /></div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
