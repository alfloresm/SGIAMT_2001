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
                                            <asp:TextBox ID="txtTanda" runat="server" class="form-control" placeholder="Buscar Tanda" MaxLength="8" TextMode="Number" required></asp:TextBox>
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
                                <div class="row">
                                    <asp:UpdatePanel runat="server" ID="UpdatePanelParticipantes" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Literal ID="LiteralParticipantes" runat="server"></asp:Literal>
                                            <asp:HiddenField ID="hfBoton" runat="server" ClientIDMode="Static"/>
                                            <asp:HiddenField ID="hfParticipante" runat="server" ClientIDMode="Static" OnValueChanged="hfParticipante_ValueChanged"/>
                                            <%--<div class="col-md-6">
                                                <div class="card">
                                                    <div class="card-header card-header-text" data-background-color="black">
                                                        <h4 id="H1" runat="server" class="card-title">Pista N°1</h4>
                                                    </div>
                                                    <div class="card-content">
                                                        <div class="col-md-6 col-md-offset-3">
                                                            <h4 class="text-center text-uppercase">#Codigo Participante: </h4>
                                                                <h3 class="text-center">101</h3>
                                                            <br />
                                                        </div>
                                                        <div class="col-md-12">
                                                            <div class="col-md-6 col-md-offset-3 text-center">
                                                                <button id='btn1' class="btn btn-danger">3</button>
                                                            </div>
                                                            <div class="col-md-6 col-md-offset-3 text-center">
                                                                <button id='btn2' class="btn btn-warning">4</button>
                                                            </div>
                                                            <div class="col-md-6 col-md-offset-3 text-center">
                                                                <button id='btn3' class="btn btn-success">5</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>--%>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
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
        };
        function CambiarTextboxHF(value, value1) {
            console.log("Valor de boton = " + value + " y participante= " + value1);
            $('#hfBoton').val(value);
            $('#hfParticipante').val(value1);
            //$('#btn1'.concat(cont)).attr("disabled", true);
            //$('#btn2'.concat(cont)).attr("disabled", true);
            //$('#btn3'.concat(cont)).attr("disabled", true);
        }
        </script>
</asp:Content>
