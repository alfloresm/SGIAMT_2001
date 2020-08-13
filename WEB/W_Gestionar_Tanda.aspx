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
                            <asp:GridView ID="GVTanda" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="PK_IT_CodTan,Tipo_Tanda,VT_Descripcion"
                                CssClass="table table-responsive table-bordered table-hover js-basic-example dataTable" PageSize="5"
                                AllowPaging="True" OnPageIndexChanging="GVTanda_PageIndexChanging" OnRowCommand="GVTanda_RowCommand"
                                Font-Size="Small" HeaderStyle-ForeColor="#FF5050" HeaderStyle-CssClass="small">
                                <RowStyle HorizontalAlign="center" CssClass="table table-striped table-bordered" />
                                <Columns>
                                    <asp:BoundField DataField="PK_IC_IdConcurso" HeaderText="Codigo" />
                                    <asp:BoundField DataField="Tipo_Tanda" HeaderText="Tipo Tanda" />
                                    <asp:BoundField DataField="VT_Descripcion" HeaderText="Categoría" />

                                </Columns>
                            </asp:GridView>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</asp:Content>
