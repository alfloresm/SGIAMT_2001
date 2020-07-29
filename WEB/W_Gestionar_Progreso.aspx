<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_Gestionar_Progreso.aspx.cs" Inherits="WEB.W_Gestionar_Progreso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 col-md-12 col-sm-12 card-header">
        <h2>Gestionar Progreso</h2>
    </div>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="card">
                    <div class="card-header card-header-text" data-background-color="red">
                        <h4 id="txtPagina" runat="server" class="card-title">Registrar Progreso</h4>
                    </div>
                    <div class="card-content">
                        <form id="form1" runat="server" method="POST" class="form">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="upAlumno" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Nombre Progreso:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNombreProgreso" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Calificacion Pasos:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNota1" runat="server" class="form-control" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Calificacion de Técnica:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNota2" runat="server" class="form-control" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Calificacion al Interes:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNota3" runat="server" class="form-control" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Calificacion por Habilidad:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNota4" runat="server" class="form-control" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Total Calificacion:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNotaTotal" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Observacion:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtObservacion" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left"></label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label">PROGRESO (%) => </label>
                                                <asp:TextBox ID="txtProgreso" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="col-lg-2 col-md-2 col-sm-6">
                                                    <asp:Button ID="btnCalcular" runat="server" Text="Calcular" CssClass="btn btn-fill btn-info" OnClick="btnCalcular_Click1"/>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-8 col-md-8 col-sm-12">
                                            <p></p>
                                        </div>
                                        <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="col-lg-2 col-md-2 col-sm-6">
                                                    <asp:Button ID="btnRegistrar" runat="server" Text="Guardar" CssClass="btn btn-fill btn-success" OnClick="btnRegistrar_Click"/>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="col-lg-2 col-md-2 col-sm-6">
                                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-fill btn-danger" OnClick="btnRegresar_Click"/>
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
