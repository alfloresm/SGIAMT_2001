<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_GestionarConcurso.aspx.cs" Inherits="WEB.W_GestionarConcurso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                        <asp:button runat="server" text="REGISTRAR" id="btnRegistrar" cssclass="btn bg-indigo waves-effect glyphicon-plus" onclick="btnRegistrar_Click" />

                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 text-center">
                                        <asp:button runat="server" text="ACTUALIZAR CATEGORIAS" id="btnActualizarC" cssclass="btn bg-indigo waves-effect" onclick="btnActualizarCat_Click" />
                                    </div>

                                    <form class="col-lg-6 navbar-form navbar-right" role="search">
                                        <div class="col-lg-3 form-group form-search is-empty">
                                            <input type="text" class="form-control" placeholder="Search">
                                            <span class="material-input"></span>
                                        </div>
                                        <button type="submit" class="btn btn-white btn-round btn-just-icon">
                                            <i class="material-icons">search</i>
                                            <div class="ripple-container"></div>
                                        </button>
                                    </form>
                                </div>


                                <div class="body table-responsive">
                                    <div class="material-datatables">
                                        <asp:gridview id="GVConcurso" runat="server" autogeneratecolumns="False"
                                            datakeynames="PK_IC_IdConcurso,VC_NombreCon,IC_CantidadSeriado,IC_CantidadNovel,VE_NombreEstado"
                                            cssclass="table table-striped table-no-bordered table-hover" style="text-align: center" pagesize="5"
                                            allowpaging="True" onpageindexchanging="GVConcurso_PageIndexChanging" onrowcommand="GVConcurso_RowCommand">
                                            <%--<RowStyle HorizontalAlign="center" CssClass="table table-striped table-bordered" />--%>
                                            <Columns>
                                                <asp:BoundField DataField="PK_IC_IdConcurso" HeaderText="Concurso" />
                                                <asp:BoundField DataField="VC_NombreCon" HeaderText="Nombre" />
                                                <asp:BoundField DataField="IC_CantidadSeriado" HeaderText="Cantidad Seriado" />
                                                <asp:BoundField DataField="IC_CantidadNovel" HeaderText="Cantidad Novel" />
                                                <asp:BoundField DataField="VE_NombreEstado" HeaderText="Estado" />
                                                <asp:ButtonField ButtonType="button" AccessibleHeaderText="btnActualizarC" Text="Actualizar" CommandName="Actualizar">
                                                    <ControlStyle CssClass="btn btn-warning" />
                                                </asp:ButtonField>
                                                <asp:ButtonField ButtonType="button" AccessibleHeaderText="btnDetalle" Text="Detalle" CommandName="Detalle">
                                                    <ControlStyle CssClass="btn btn-info" />
                                                </asp:ButtonField>
                                            </Columns>
                                        </asp:gridview>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    
</asp:Content>

