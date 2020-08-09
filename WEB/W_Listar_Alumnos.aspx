<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_Listar_Alumnos.aspx.cs" Inherits="WEB.W_Listar_Alumnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="assets/momentjs/moment.js"></script>

    <link href="assets/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/css/toastr.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script
        src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"></script>
    <link rel="stylesheet" href="http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css">

    <script type="text/javascript">
        function marcarAsistencia() {


            var dni = document.getElementById("<%=txtDni.ClientID %>").value;
            sessionStorage.setItem("dni", dni);
            var estado = $('input:radio[name=asistencia]:checked').val();

            $.ajax({
                type: "POST",
                url: "W_Listar_Alumnos.aspx/GetCurrentTime",
                data: '{dni: "' + dni + '",estado: "' + estado + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert("falló" + response.d);
                }
            });
        }
        function OnSuccess(response) {
            //alert("hola"+response.d);
            $(document).ready(function () {                toastr.options = {                    timeOut: 0,                    extendedTimeOut: 100,                    tapToDismiss: true,                    debug: false,                    fadeOut: 10,                    positionClass: "toast-top-center"                };
                Command: toastr["success"]("Se guardó con éxito la asistencia", "Registro exitoso")

            });
        }

    </script>
    <style>
        .toast-top-center {
            top: 12px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form2" runat="server" method="POST">


        <div class="col-lg-12 col-md-12 col-sm-12 card-header">
            <h2>Administrar Asistencia</h2>
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
                                    <h3>Lista de Alumnos</h3>
                                    <div class="row">
                                        <div class="col-md-6 col-md-offset-1 text-center">
                                            <div class="col-md-6">
                                                <%--<div class="col-md-8 form-group form-search is-empty">
                                                    <asp:DropDownList ID="ddlClase" runat="server" CssClass="selectpicker"></asp:DropDownList>
                                                    <span class="material-input"></span>
                                                    <asp:Label ID="lblMensaje1" runat="server" Text=""></asp:Label>
                                                </div>--%>
                                                <div class="col-md-8 form-group form-search is-empty">
                                                    <asp:DropDownList ID="ddlTipoNivel" runat="server" CssClass="selectpicker"></asp:DropDownList>
                                                    <span class="material-input"></span>
                                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                                </div>
                                                <div class="col-md-8 form-group form-search is-empty">
                                                    <asp:DropDownList ID="ddlNivel" runat="server" CssClass="selectpicker"></asp:DropDownList>
                                                    <span class="material-input"></span>
                                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                                </div>
                                                <asp:UpdatePanel ID="upnBotonBuscar1" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="btnBuscar1" runat="server" CssClass="btn btn-white btn-round btn-just-icon" OnClick="btnBuscar1_Click1">
                                                        <i class="material-icons">search</i>
                                                        <div class="ripple-container"></div>
                                                        </asp:LinkButton>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <%--<asp:Button runat="server" Text="BUSCAR" ID="btnBuscar" CssClass="btn btn-fill btn-success" />--%>
                                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
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

                                                <asp:GridView ID="GVAlumnos" runat="server" AutoGenerateColumns="False"
                                                    DataKeyNames="PK_IU_DNI,Apellidos,VU_Correo,VCA_NomCategoria,VTN_NombreTipoNivel,VN_NombreNivel,VU_Horario"
                                                    CssClass="table table-responsive table-bordered table-hover js-basic-example dataTable" PageSize="5"
                                                    AllowPaging="True" OnPageIndexChanging="GVAlumnos_PageIndexChanging" OnRowCommand="GVAlumnos_RowCommand"
                                                    Font-Size="Small" HeaderStyle-ForeColor="#FF5050" HeaderStyle-CssClass="small">
                                                    <RowStyle HorizontalAlign="center" CssClass="table table-striped table-bordered" />
                                                    <Columns>
                                                        <asp:BoundField DataField="PK_IU_DNI" HeaderText="DNI" />
                                                        <asp:BoundField DataField="Apellidos" HeaderText="Nombres y Apellidos" />
                                                        <asp:BoundField DataField="VU_Correo" HeaderText="Correo" />
                                                        <asp:BoundField DataField="VCA_NomCategoria" HeaderText="Categoria" />
                                                        <asp:BoundField DataField="VTN_NombreTipoNivel" HeaderText="Tipo de Nivel" />
                                                        <asp:BoundField DataField="VN_NombreNivel" HeaderText="Nivel" />
                                                        <asp:BoundField DataField="VU_Horario" HeaderText="Horario" />
                                                        <%--<asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:ButtonField ButtonType="button" AccessibleHeaderText="btnAdministrar" Text="Asistencia" HeaderText="Opciones" CommandName="Asistencia">
                                                            <ControlStyle CssClass="btn btn-sm btn-round" BackColor="#00BCD4" />
                                                        </asp:ButtonField>
                                                        <asp:ButtonField ButtonType="button" AccessibleHeaderText="btnProgreso" Text="Progreso" HeaderText="Opciones" CommandName="Progreso">
                                                            <ControlStyle CssClass="btn btn-sm btn-round" BackColor="#FF9800" />
                                                        </asp:ButtonField>
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
                                        <div class="col-md-10 col-md-offset-1">
                                            <p></p>

                                            <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="col-lg-2 col-md-2 col-sm-6">
                                                        <asp:Button ID="btnVerAsistencia" runat="server" Text="Ver Asistencia" CssClass="btn btn-fill btn-success" OnClick="btnVerAsistencia_Click" />
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="col-lg-2 col-md-2 col-sm-6">
                                                        <asp:Button ID="btnVerProgreso" runat="server" Text="Ver Progreso" CssClass="btn btn-fill btn-success" OnClick="btnVerProgreso_Click" />
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

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
                    <asp:UpdatePanel runat="server" ID="updPanelModal" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><i class="material-icons">clear</i></button>
                                <h5 class="modal-title" id="myModalLabel" runat="server">Marcar la asistencia:</h5>
                            </div>
                            <div class="modal-body">
                                <div class="col-lg-12">
                                    <label class="col-md-2 label-on-left">DNI: </label>
                                    <div class="form-group label-floating is-empty">
                                        <label class="control-label"></label>
                                        <asp:TextBox ID="txtDni" runat="server" class="form-control " Enabled="False"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6 checkbox-radios">
                                        <label class="col-md-12 label-on-left">Estado:</label>
                                        </br>
                                        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                            <ContentTemplate>
                                            
                                                    <input type="radio" name="asistencia" id="asistencia1" value="Asistio">Asistio<br>
                                                    <input type="radio" name="asistencia" id="asistencia2" value="Faltó">Falto<br>
                                              
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer text-center">
                                <asp:UpdatePanel ID="upBotonEnviar2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="col-lg-2 col-md-2 col-sm-6">
                                            <asp:Button ID="btnGuardar" type="button" runat="server" Text="Guardar" CssClass="btn btn-info btn-round" BackColor="#4CAF50" UseSubmitBehavior="false" OnClientClick="marcarAsistencia()" data-dismiss="modal" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <button type="button" class="btn btn-info btn-round" data-dismiss="modal">Cerrar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
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
