<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_Mostrar_Resultado.aspx.cs" Inherits="WEB.W_Buscar_Tanda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/css/material-dashboard.css" rel="stylesheet" />
    <link href="../assets/css/demo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <form id="form1" runat="server">

                        <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>

                        <div class="card">
                            <div class="row">
                                <div class="col-md-6 col-md-offset-3">
                                    <div class="col-md-6 text-center">
                                        <h5 class="text-danger">La ultima tanda calificada fue: </h5>
                                    </div>
                                    <div class="col-md-6">
                                        <br />
                                        <asp:Label ID="lblNumTanda" runat="server" Text="Label" CssClass="text-danger" Font-Bold="True" Font-Size="Large"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="card-header card-header-text" data-background-color="red">
                                <h4 class="card-title">Buscar Tanda</h4>
                            </div>
                            <div class="card-content">

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="col-md-8 form-group form-search is-empty">
                                            <asp:TextBox ID="txtTanda" runat="server" class="form-control" placeholder="Buscar Tanda" MaxLength="8" TextMode="Number" Font-Size="Large"></asp:TextBox>
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
                                    <asp:UpdatePanel runat="server" ID="UpdatePanelInfo" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="col-md-6">
                                                <div class="col-md-6">
                                                    <label class="col-md-3 label-on-left">Categoria</label>
                                                    <div class="col-md-9">
                                                        <div class="form-group label-floating is-empty">
                                                            <label class="control-label"></label>
                                                            <asp:Label ID="lblCategoria" runat="server" Text="" CssClass="text-uppercase"></asp:Label>

                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="col-md-3 label-on-left">Modalidad</label>
                                                    <div class="col-md-9">
                                                        <div class="form-group label-floating is-empty">
                                                            <label class="control-label"></label>
                                                            <asp:Label ID="lblModalidad" runat="server" Text="" CssClass="text-uppercase"></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="card">
                            <div class="card-header card-header-text" data-background-color="red">
                                <h4 class="card-title">Mostrar Resultado</h4>
                            </div>
                            <div class="card-content">
                                <div class="row">
                                    <div class="col-md-6">
                                        <img src="assets/img/flags/trofeo.png" class="img-fluid rounded" alt="Responsive image" width="500" height="500" />
                                    </div>
                                    <div class="col-md-6">
                                        <div class="col-lg-12 col-md-12 col-sm-13 text-center">
                                            <h2 class="text-center">EL GANADOR ES!</h2>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-13 text-center">
                                            <h1 class="text-center" runat="server" id="codGanador">N° 101</h1>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-13 text-center">
                                            <h3 class="text-center" runat="server" id="nombre">Nombre:</h3>
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
</asp:Content>
