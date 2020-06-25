<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_GestionarConcurso.aspx.cs" Inherits="WEB.W_GestionarConcurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/css/dataTables.bootstrap.css" rel="stylesheet" />
    <script>$(function () {
            $(".dataTable").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                "bProcessing": false,
                "bLengthChange": false,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Buscar registros",
                    lengthMenu: "Mostrar _MENU_ registros",
                    paginate: {
                        first: "Primero",
                        last: "&Uacute;ltimo",
                        next: "Siguiente",
                        previous: "Anterior"
                    },

                }, "bLengthChange": false,
                "bFilter": true,
                "bInfo": false,
                "bAutoWidth": false,
                responsive: true
            });
        });</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<form id="form1" runat="server">--%>
    <div class="col-lg-12 col-md-12 col-sm-12 card-header">
        <h1>Gestionar Concurso</h1>
    </div>
    <div class="row">
        <div class="row clearfix">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
                <asp:updatepanel id="UpdatePanel" runat="server" updatemode="Conditional" childrenastriggers="false">
                    <ContentTemplate>
                        <div class="card">
                            <div class="header">
                                <h2>Lista Concurso</h2>
                                </div>
                             <div class="row">
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <asp:button runat="server" text="REGISTRAR" id="Button1" cssclass="btn bg-indigo waves-effect glyphicon-plus" onclick="btnRegistrar_Click" />
                        
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <asp:button runat="server" text="ACTUALIZAR CATEGORIAS" id="Button2" cssclass="btn bg-indigo waves-effect" onclick="btnActualizarCat_Click" />
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-sm-12">
                                        <form class="col-lg-6 navbar-form navbar-right" role="search">
                                            <div class="form-group form-search is-empty">
                                                <input type="text" class="form-control" placeholder="Search">
                                                <span class="material-input"></span>
                                            </div>
                                            <button type="submit" class="btn btn-white btn-round btn-just-icon">
                                                <i class="material-icons">search</i>
                                                <div class="ripple-container"></div>
                                            </button>
                                     </form>
                                        <%--<asp:textbox runat="server" id="Textbox1" cssclass="col-lg-6 form-control"></asp:textbox>
                                        <asp:button runat="server" text="buscar" id="btnBuscar" cssclass="col-lg-6 btn bg-indigo waves-effect" />--%>
                                    </div>
                                 </div>
                            </div>
                        <div class="body table-responsive">
                           <div class="material-datatables">
                                <asp:GridView ID="gvConcurso" CssClass="table table-striped table-no-bordered table-hover dataTable dtr-inline" DataKeyNames="PK_IC_IdConcurs,VC_NombreCon" runat="server" AutoGenerateColumns="False" EmptyDataText="No existen registros" ShowHeaderWhenEmpty="True" OnRowCommand="gvConcurso_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="PK_IC_IdConcurso" HeaderText="Codigo" />
                                        <asp:BoundField DataField="VC_NombreCon" HeaderText="Nombre" />
                                        <asp:BoundField DataField="IC_CantidadSeriado" HeaderText="Cantidad Seriado" />
                                        <asp:BoundField DataField="IC_CantidadNovel" HeaderText="Cantidad Novel" />
                                        <asp:BoundField DataField="VE_NombreEstado" HeaderText="Estado" />

                                        <asp:ButtonField ButtonType="button" HeaderText="Detalles" CommandName="Ver" Text="Ver">
                                            <ControlStyle CssClass="btn btn-warning glyphicon-eye-open" />
                                        </asp:ButtonField>
                                        <asp:ButtonField ButtonType="button" HeaderText="Actualizar" CommandName="Actualizar" Text="Editar">
                                            <ControlStyle CssClass="btn btn-warning glyphicon-edit" />
                                        </asp:ButtonField>
                                    </Columns>
                                </asp:GridView>
                               </div>
                            </div>
                        </ContentTemplate>
                    </asp:updatepanel>
            </div>
        </div>
    </div>
    <%--</form>--%>
    <script src="assets/js/jquery.datatables.js"></script>
</asp:Content>
