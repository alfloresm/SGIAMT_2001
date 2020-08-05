<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_Listado_Alumnos_General.aspx.cs" Inherits="WEB.W_Listado_Alumnos_General" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="assets/momentjs/moment.js"></script>

    <link href="assets/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
    
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
                                    <h3>Listado General de Alumnos</h3>
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

                                                <asp:GridView ID="GVAlumnosTotal" runat="server" AutoGenerateColumns="False"
                                                    DataKeyNames="PK_IU_DNI,Apellidos,VU_Correo,VU_Celular,VU_Direccion,VCA_NomCategoria,VTN_NombreTipoNivel,VN_NombreNivel,VU_Horario"
                                                    CssClass="table table-responsive table-bordered table-hover js-basic-example dataTable" PageSize="5"
                                                    AllowPaging="True" OnPageIndexChanging="GVAlumnosTotal_PageIndexChanging" OnRowCommand="GVAlumnosTotal_RowCommand"
                                                    Font-Size="Small" HeaderStyle-ForeColor="#FF5050" HeaderStyle-CssClass="small">
                                                    <RowStyle HorizontalAlign="center" CssClass="table table-striped table-bordered" />
                                                    <Columns>
                                                        <asp:BoundField DataField="PK_IU_DNI" HeaderText="Dni" />
                                                        <asp:BoundField DataField="Apellidos" HeaderText="Nombres y Apellidos" />
                                                        <asp:BoundField DataField="VU_Correo" HeaderText="Correo" />
                                                        <asp:BoundField DataField="VU_Celular" HeaderText="Celular" />
                                                        <asp:BoundField DataField="VU_Direccion" HeaderText="Direccion" />
                                                        <asp:BoundField DataField="VCA_NomCategoria" HeaderText="Categoria" />
                                                        <asp:BoundField DataField="VTN_NombreTipoNivel" HeaderText="Tipo de Nivel" />
                                                        <asp:BoundField DataField="VN_NombreNivel" HeaderText="Nivel" />
                                                        <asp:BoundField DataField="VU_Horario" HeaderText="Horario" />
                                                        
                                                        <%--<asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:ButtonField ButtonType="button" AccessibleHeaderText="btnDetalle" Text="📄" HeaderText="Ver" CommandName="Detalle">
                                                            <ControlStyle CssClass="btn btn-sm btn-round" BackColor="#4CAF50" />
                                                        </asp:ButtonField>
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
                                            <asp:Button ID="btnIrARegistro" runat="server" Text="Ir a Registrar Alumno" CssClass="btn btn-success" OnClick="btnIrARegistro_Click" />
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
