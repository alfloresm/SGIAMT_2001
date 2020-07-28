<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_Calificar_Participante.aspx.cs" Inherits="WEB.W_Calificar_Participante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="card-header card-header-text" data-background-color="red">
                            <h4 id="txtPagina" runat="server" class="card-title">Calificar Participante</h4>
                        </div>
                        <div class="card-content">
                            <form id="form1" runat="server">
                                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="col-md-8 form-group form-search is-empty">
                                            <asp:TextBox ID="txtTanda" runat="server" class="form-control" placeholder="Buscar Tanda" MaxLength="8"></asp:TextBox>
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
                                    <asp:Panel ID="PaneInfo" runat="server">
                                        <div class="col-md-6">
                                            <div class="col-md-6">
                                                <label class="col-md-3 label-on-left">Categoria</label>
                                                <div class="col-md-9">
                                                    <div class="form-group label-floating is-empty">
                                                        <label class="control-label"></label>
                                                        <asp:Label ID="lblCategoria" runat="server" Text=""></asp:Label>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <label class="col-md-3 label-on-left">Modalidad</label>
                                                <div class="col-md-9">
                                                    <div class="form-group label-floating is-empty">
                                                        <label class="control-label"></label>
                                                        <asp:Label ID="lblModalidad" runat="server" Text=""></asp:Label>

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="card">
                                            <div class="card-header card-header-text" data-background-color="red">
                                                <h4 id="H1" runat="server" class="card-title">Pista N°1</h4>
                                            </div>
                                            <div class="card-content">
                                                <div class="col-md-12">
                                                <label class="col-md-3 label-on-left">#Cod Participante</label>
                                                <div class="col-md-9">
                                                    <div class="form-group label-floating is-empty">
                                                        <label class="control-label"></label>
                                                        <asp:Label ID="lblCod" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                                    <button ID='btn1' class="btn btn-danger">3</button>
                                                    <button ID='btn2' class="btn btn-warning">4</button>
                                                    <button ID='btn3' class="btn btn-success">5</button>
                                            </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
