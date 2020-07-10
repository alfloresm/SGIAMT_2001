<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_GestionarConcurso.aspx.cs" Inherits="WEB.W_GestionarConcurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="assets/momentjs/moment.js"></script>

    <link href="assets/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="col-lg-12 col-md-12 col-sm-12 card-header">
            <h2>Gestionar Concurso</h2>
        </div>
        <div class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="row clearfix">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="card">
                                <div class="card-header card-header-icon" data-background-color="black">
                                    <i class="material-icons">assignment</i>
                                </div>
                                <h3>Lista Concurso</h3>
                                <div class="row">
                                    <div class="col-lg-3 col-md-6 col-sm-12 text-center">
                                        <asp:Button runat="server" Text="REGISTRAR" ID="btnRegistrar" CssClass="btn bg-indigo waves-effect glyphicon-plus" OnClick="btnRegistrar_Click" />

                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 text-center">
                                        <asp:Button runat="server" Text="ACTUALIZAR CATEGORIAS" ID="btnActualizarC" CssClass="btn bg-indigo waves-effect" OnClick="btnActualizarCat_Click" />
                                    </div>

                                    <%--<form class="col-lg-6 navbar-form navbar-right" role="search">
                                        <div class="col-lg-3 form-group form-search is-empty">
                                            <input type="text" class="form-control" placeholder="Search">
                                            <span class="material-input"></span>
                                        </div>
                                        <button type="submit" class="btn btn-white btn-round btn-just-icon">
                                            <i class="material-icons">search</i>
                                            <div class="ripple-container"></div>
                                        </button>
                                    </form>--%>
                                </div>


                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                        <div class="card-content table-responsive">

                                            <asp:GridView ID="GVConcurso" runat="server" AutoGenerateColumns="False"
                                                DataKeyNames="PK_IC_IdConcurso,VC_NombreCon,IC_CantidadSeriado,IC_CantidadNovel,VE_NombreEstado"
                                                CssClass="table table-bordered table-hover js-basic-example dataTable" PageSize="5"
                                                AllowPaging="True" OnPageIndexChanging="GVConcurso_PageIndexChanging" OnRowCommand="GVConcurso_RowCommand"
                                                Font-Size="Small" HeaderStyle-ForeColor="#FF5050" HeaderStyle-CssClass="small">
                                                <RowStyle HorizontalAlign="center" CssClass="table table-striped table-bordered"/>
                                                <Columns>
                                                    <asp:BoundField DataField="PK_IC_IdConcurso" HeaderText="Concurso" />
                                                    <asp:BoundField DataField="VC_NombreCon" HeaderText="Nombre" />
                                                    <asp:BoundField DataField="IC_CantidadSeriado" HeaderText="Cantidad Seriado" />
                                                    <asp:BoundField DataField="IC_CantidadNovel" HeaderText="Cantidad Novel" />
                                                    <asp:BoundField DataField="VE_NombreEstado" HeaderText="Estado" />
                                                    <asp:ButtonField ButtonType="button" AccessibleHeaderText="btnActualizarC" Text="✏️" CommandName="Actualizar">
                                                        <ControlStyle CssClass="btn btn-sm btn-warning " />
                                                    </asp:ButtonField>
                                                    <asp:ButtonField ButtonType="button" AccessibleHeaderText="btnDetalle" Text="📄" CommandName="Detalle">
                                                        <ControlStyle CssClass="btn btn-sm btn-info " />
                                                    </asp:ButtonField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
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

