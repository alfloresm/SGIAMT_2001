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
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                            <ContentTemplate>
                                <div class="card">
                                    <div class="card-header card-header-icon" data-background-color="black">
                                        <i class="material-icons">assignment</i>
                                    </div>
                                    <h3>Lista Concurso</h3>
                                    <div class="row">
                                        <div class="col-md-4 col-md-offset-1 text-center">
                                            <asp:Button runat="server" Text="REGISTRAR" ID="btnRegistrar" CssClass="btn bg-indigo waves-effect glyphicon-plus" OnClick="btnRegistrar_Click" />

                                        </div>
                                        <div class="col-md-4 col-md-offset-2 text-center">
                                            <asp:Button runat="server" Text="ACTUALIZAR CATEGORIAS" ID="btnActualizarC" CssClass="btn bg-indigo waves-effect" OnClick="btnActualizarCat_Click" />
                                        </div>
                                    </div>


                                    <div class="row">
                                        <div class="col-md-10 col-md-offset-1">
                                            <div class="card-content">

                                                <asp:GridView ID="GVConcurso" runat="server" AutoGenerateColumns="False"
                                                    DataKeyNames="PK_IC_IdConcurso,VC_NombreCon,IC_CantidadSeriado,IC_CantidadNovel,VE_NombreEstado"
                                                    CssClass="table table-responsive table-bordered table-hover js-basic-example dataTable" PageSize="5"
                                                    AllowPaging="True" OnPageIndexChanging="GVConcurso_PageIndexChanging" OnRowCommand="GVConcurso_RowCommand"
                                                    Font-Size="Small" HeaderStyle-ForeColor="#FF5050" HeaderStyle-CssClass="small">
                                                    <RowStyle HorizontalAlign="center" CssClass="table table-striped table-bordered" />
                                                    <Columns>
                                                        <asp:BoundField DataField="PK_IC_IdConcurso" HeaderText="Concurso" />
                                                        <asp:BoundField DataField="VC_NombreCon" HeaderText="Nombre" />
                                                        <asp:BoundField DataField="IC_CantidadSeriado" HeaderText="Cantidad Seriado" />
                                                        <asp:BoundField DataField="IC_CantidadNovel" HeaderText="Cantidad Novel" />
                                                        <asp:BoundField DataField="VE_NombreEstado" HeaderText="Estado" />
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:Button runat="server" Text="✏️"
                                                                    Visible='<%# ValidacionEstado(Eval("VE_NombreEstado").ToString()) %>'
                                                                    CommandName="Actualizar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-sm btn-warning" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:ButtonField ButtonType="button" AccessibleHeaderText="btnActualizarC" Text="✏️" CommandName="Actualizar">
                                                            <ControlStyle CssClass="btn btn-sm btn-warning " />
                                                        </asp:ButtonField>--%>
                                                        <asp:ButtonField ButtonType="button" AccessibleHeaderText="btnDetalle" Text="📄" CommandName="Detalle">
                                                            <ControlStyle CssClass="btn btn-sm btn-info " />
                                                        </asp:ButtonField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="noticeModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-notice">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><i class="material-icons">clear</i></button>
                        <h5 class="modal-title" id="myModalLabel" runat="server"></h5>
                    </div>
                    <div class="modal-body">
                        <div class="col-lg-12">
                            <label class="col-md-2 label-on-left">Lugar: </label>
                            <div class="form-group label-floating is-empty">
                                <label class="control-label"></label>
                                <asp:TextBox ID="txtlugar" runat="server" class="form-control " Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <label class="col-md-2 label-on-left">fecha: </label>
                            <div class="form-group label-floating is-empty">
                                <label class="control-label"></label>
                                <asp:TextBox ID="txtFecha" runat="server" class="form-control " Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <label class="col-md-2 label-on-left">Cantidad Seriado: </label>
                            <div class="form-group label-floating is-empty">
                                <label class="control-label"></label>
                                <asp:TextBox ID="txtCantSer" runat="server" class="form-control " Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <label class="col-md-2 label-on-left">Cantidad Novel: </label>
                            <div class="form-group label-floating is-empty">
                                <label class="control-label"></label>
                                <asp:TextBox ID="txtCantNov" runat="server" class="form-control " Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <label class="col-md-2 label-on-left">Estado: </label>
                            <div class="form-group label-floating is-empty">
                                <label class="control-label"></label>
                                <asp:TextBox ID="txtEstado" runat="server" class="form-control " Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer text-center">
                        <button type="button" class="btn btn-info btn-round" data-dismiss="modal">Cerrar</button>
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

