<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_Asignar_Tanda.aspx.cs" Inherits="WEB.W_Asignar_Tanda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../assets/css/material-dashboard.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" class="form">
        <div class="card">
            <div class="card-header card-header-text" data-background-color="red">
                <h4 id="txtPagina" runat="server" class="card-title">Información de Tanda</h4>
            </div>
            <div class="card-content">

                <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="3600"></asp:ScriptManager>
                <div class="row">

                    <div class="col-md-5">
                        <label class="col-md-12 label-on-left">Modalidad</label>
                        <div class="col-md-5 form-group label-floating is-empty">
                            <asp:DropDownList ID="ddlModalidad" runat="server" CssClass="selectpicker">
                                <asp:ListItem Value="1" Text="Seriado"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Novel"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <label class="col-md-12 label-on-left">Categoria:</label>
                        <div class="col-md-5 form-group label-floating is-empty">
                            <asp:DropDownList ID="ddlCat" runat="server" CssClass="selectpicker">
                                <asp:ListItem Value="Pre Infante" Text="Pre Infante"></asp:ListItem>
                                <asp:ListItem Value="Infante" Text="Infante"></asp:ListItem>
                                <asp:ListItem Value="Infantil" Text="Infantil"></asp:ListItem>
                                <asp:ListItem Value="Junior" Text="Junior"></asp:ListItem>
                                <asp:ListItem Value="Juvenil" Text="Juvenil"></asp:ListItem>
                                <asp:ListItem Value="Adulto" Text="Adulto"></asp:ListItem>
                                <asp:ListItem Value="Senior" Text="Senior"></asp:ListItem>
                                <asp:ListItem Value="Master" Text="Master"></asp:ListItem>
                                <asp:ListItem Value="Oro" Text="Oro"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <br />
                        <br />
                       <%-- <asp:UpdatePanel ID="UpBtnIr" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>--%>
                                <asp:LinkButton ID="btnIr" runat="server" OnClick="btnIr_Click" CssClass="btn btn-success btn-round btn-fab btn-fab-mini">
                            <i class="material-icons">done_outline</i>
                                </asp:LinkButton>
                            <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </div>
                </div>
                            </div>
        </div>
        <asp:Panel ID="pnlPistas" runat="server">
            <asp:HiddenField ID="HFidTanda" runat="server" />
            <div class="card">
                <div class="card-header card-header-text" data-background-color="red">
                    <h4 id="H1" class="card-title">Asignación de Tanda</h4>
                </div>
                <div class="card-content">

                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="card card-pricing card-raised">
                                <h2 class="card-title">PISTA N° 1</h2>
                                <br />
                                <div class="col-md-8 form-group label-floating is-empty">
                                    <asp:TextBox ID="txtCodPista1" runat="server" placeholder="Código" CssClass="form-control" Font-Size="Large"></asp:TextBox>
                                </div>
                                <asp:UpdatePanel ID="updPista1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="BtnPista1" runat="server" Text="OK" CssClass="btn btn-success btn-round btn-fab btn-fab-mini" OnClick="BtnPista1_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="card card-pricing card-raised">
                                <h2 class="card-title">PISTA N° 2</h2>
                                <br />
                                <div class="col-md-8 form-group label-floating is-empty">
                                    <asp:TextBox ID="txtCodPista2" runat="server" placeholder="Código" CssClass="form-control" Font-Size="Large"></asp:TextBox>
                                </div>
                                <asp:UpdatePanel ID="updPista2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="BtnPista2" runat="server" Text="OK" CssClass="btn btn-success btn-round btn-fab btn-fab-mini" OnClick="BtnPista2_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="card card-pricing card-raised">
                                <h2 class="card-title">PISTA N° 3</h2>
                                <br />
                                <div class="col-md-8 form-group label-floating is-empty">
                                    <asp:TextBox ID="txtCodPista3" runat="server" placeholder="Código" CssClass="form-control" Font-Size="Large"></asp:TextBox>
                                </div>
                                <asp:UpdatePanel ID="updPista3" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="BtnPista3" runat="server" Text="OK" CssClass="btn btn-success btn-round btn-fab btn-fab-mini" OnClick="BtnPista3_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-12">
                            <div class="card card-pricing card-raised">
                                <h2 class="card-title">PISTA N° 4</h2>
                                <br />
                                <div class="col-md-8 form-group label-floating is-empty">
                                    <asp:TextBox ID="txtCodPista4" runat="server" placeholder="Código" CssClass="form-control" Font-Size="Large"></asp:TextBox>
                                </div>
                                <asp:UpdatePanel ID="updPista4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="BtnPista4" runat="server" Text="OK" CssClass="btn btn-success btn-round btn-fab btn-fab-mini" OnClick="BtnPista4_Click" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </form>
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
