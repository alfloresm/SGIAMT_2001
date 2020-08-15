<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_Listar_Progresos.aspx.cs" Inherits="WEB.W_Listar_Progresos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <form id="form2" runat="server" method="POST">
        
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
                                    <h3>Lista de Progreso de Alumnos</h3>
                                    <div class="row">
                                        <div class="col-md-6 col-md-offset-1 text-center">
                                            <div class="col-md-6">
                                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <%--<div class="col-md-4 col-md-offset-2 text-center">
                                            <asp:Button runat="server" Text="ACTUALIZAR CATEGORIAS" ID="btnActualizarC" CssClass="btn bg-indigo waves-effect" OnClick="btnActualizarCat_Click" />
                                        </div>--%>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-10 col-md-offset-1">
                                            <div class="card-content">
                                                <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>--%>

                                                <asp:GridView ID="GVProgreso" runat="server" AutoGenerateColumns="False"
                                                    DataKeyNames="Apellidos,VTN_NombreTipoNivel,VN_NombreNivel,VU_Horario,DTA_Fecha,DP_TotalNota"
                                                    CssClass="table table-responsive table-bordered table-hover js-basic-example dataTable" PageSize="5"
                                                    AllowPaging="True" OnPageIndexChanging="GVProgreso_PageIndexChanging" OnRowCommand="GVProgreso_RowCommand"
                                                    Font-Size="Medium" HeaderStyle-ForeColor="#FF5050">
                                                    <RowStyle HorizontalAlign="center" CssClass="table table-striped table-bordered" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Apellidos" HeaderText="Nombres y Apellidos" />
                                                        <asp:BoundField DataField="VTN_NombreTipoNivel" HeaderText="Tipo de Nivel" />
                                                        <asp:BoundField DataField="VN_NombreNivel" HeaderText="Nivel" />
                                                        <asp:BoundField DataField="VU_Horario" HeaderText="Horario" />
                                                        <asp:BoundField DataField="DTA_Fecha" HeaderText="Fecha" />
                                                        <asp:BoundField DataField="DP_TotalNota" HeaderText="Promedio Progreso" />
                                                        <%--<asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                       <%--<asp:ButtonField ButtonType="button" AccessibleHeaderText="btnDetalle" Text="📄" HeaderText="Ver" CommandName="Detalle">
                                                            <ControlStyle CssClass="btn btn-sm btn-round" BackColor="#4CAF50" />
                                                        </asp:ButtonField>--%>
                                                    </Columns>

                                                </asp:GridView>

                                                <%--</ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-8 col-md-8 col-sm-12">
                                            <p></p>
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-6">
                                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-fill btn-danger" OnClick="btnRegresar_Click" />
                                        </div>
                                    </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
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
