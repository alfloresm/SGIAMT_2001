<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_Gestionar_Tanda.aspx.cs" Inherits="WEB.W_Gestionar_Tanda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="assets/momentjs/moment.js"></script>
    <link href="../assets/css/material-dashboard.css" rel="stylesheet" />

    <link href="assets/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="card">
            <div class="card-header card-header-icon" data-background-color="black">
                <i class="material-icons">assignment</i>
            </div>
            <h3>GESTIONAR TANDA</h3>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <div class="card-content">
                        <div class="row">
                            <div class="col-md-4 col-md-offset-1 text-center">
                                <asp:Button runat="server" Text="Asiganar Tanda" ID="btnAsignar" CssClass="btn btn-info waves-effect glyphicon-plus" OnClick="btnAsignar_Click" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="card-content">
                                <div class="col-md-10 col-md-offset-1 table-responsive">
                                    <asp:GridView ID="GVTanda" runat="server" AutoGenerateColumns="False"
                                        DataKeyNames="PK_IT_CodTan,Tipo_Tanda,VT_Descripcion"
                                        CssClass="table table-responsive table-bordered table-hover js-basic-example dataTable" PageSize="10"
                                        AllowPaging="True" OnPageIndexChanging="GVTanda_PageIndexChanging" OnRowCommand="GVTanda_RowCommand"
                                        Font-Size="Small" HeaderStyle-ForeColor="#FF5050" HeaderStyle-CssClass="small" EmptyDataText="No hay Registros">
                                        <RowStyle HorizontalAlign="center" CssClass="table table-striped table-bordered" />
                                        <Columns>
                                            <asp:BoundField DataField="PK_IT_CodTan" HeaderText="Codigo" />
                                            <asp:BoundField DataField="Tipo_Tanda" HeaderText="Tipo Tanda" />
                                            <asp:BoundField DataField="VT_Descripcion" HeaderText="Categoría" />

                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
    <script src="assets/jquery-datatable/jquery.dataTables.js"></script>
    <script src="assets/jquery-datatable/skin/bootstrap/js/dataTables.bootstrap.js"></script>
    <script src="../../assets/jquery-datatable/extensions/export/dataTables.buttons.min.js"></script>
    <script src="../../assets/jquery-datatable/extensions/export/buttons.flash.min.js"></script>
    <script src="../../assets/jquery-datatable/extensions/export/jszip.min.js"></script>
    <script src="../../assets/jquery-datatable/extensions/export/pdfmake.min.js"></script>
    <script src="../../assets/jquery-datatable/extensions/export/vfs_fonts.js"></script>
    <script src="../../assets/jquery-datatable/extensions/export/buttons.html5.min.js"></script>
    <script src="../../assets/jquery-datatable/extensions/export/buttons.print.min.js"></script>
    <script>$(function () {
            $(".dataTable").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "bProcessing": false,
                "bLengthChange": false,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Buscar registros",
                    lengthMenu: "Mostrar _MENU_ registros",
                    paginate: false,

                },
                "paging": false,
                "info": false,
                responsive: true
            });
        });
    </script>
</asp:Content>
