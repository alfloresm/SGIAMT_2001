<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_Gestionar_Progreso.aspx.cs" Inherits="WEB.W_Gestionar_Progreso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>
    <script src="assets/momentjs/moment.js"></script>

    <link href="assets/jquery-datatable/skin/bootstrap/css/dataTables.bootstrap.css" rel="stylesheet">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

    <script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/css/toastr.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"></script>
    <link rel="stylesheet" href="http://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.min.css">

    <script type="text/javascript">
        var nota1;
        var nota2;
        var nota3;
        var nota4;
        var total;
        var promedio;
        var porcentaje;
        var nota1;
        var progreso;
        var observacion;

        function prueba() {

            nota1 = parseInt((document.getElementById("<%=txtNota1.ClientID %>").value), 10);
            nota2 = parseInt((document.getElementById("<%=txtNota2.ClientID %>").value), 10);
            nota3 = parseInt((document.getElementById("<%=txtNota3.ClientID %>").value), 10);
            nota4 = parseInt((document.getElementById("<%=txtNota4.ClientID %>").value), 10);
            progreso = document.getElementById("<%=txtNombreProgreso.ClientID %>").value;
            observacion = document.getElementById("<%=txtObservacion.ClientID %>").value;

            total = (nota1 + nota2 + nota3 + nota4);
            promedio = total / 4;
            porcentaje = promedio * 5;
            // alert(nota1);
            //alert(total);
            //alert("Promedio es: " + promedio);
            //alert("En porcentaje es: " + porcentaje);
            document.getElementById("<%=txtNotaTotal.ClientID%>").value = promedio;
            document.getElementById("<%=txtProgresoP.ClientID%>").value = porcentaje + "%";


        }
        function volver() {
            //alert("me voy");
            document.getElementById("<%=txtNombreProgreso.ClientID%>").value = " ";
            document.getElementById("<%=txtNota1.ClientID%>").value = " ";
            document.getElementById("<%=txtNota2.ClientID%>").value = " ";
            document.getElementById("<%=txtNota3.ClientID%>").value = " ";
            document.getElementById("<%=txtNota4.ClientID%>").value = " ";
            location.href = "http://localhost:65359/W_Listar_Alumnos.aspx";
        }
        function registrar() {
            prueba();
            var dni = sessionStorage.getItem("dni");
            $.ajax({
                type: "POST",
                url: "W_Gestionar_Progreso.aspx/registrar",
                data: '{VP_NombreProgreso: "' + progreso + '",DP_NotaPasos: "' + nota1 + '",DP_NotaTecnica: "' + nota2 + '",DP_NotaInteres: "' + nota3 + '",DP_NotaHabilidad: "' + nota4 + '",DP_TotalNota: "' + promedio + '",VP_Observacion: "' + observacion + '",dni: "' + dni + '"}',
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
                Command: toastr["success"]("Se guardó con éxito el progreso", "Registro exitoso")

                //location.href = "http://localhost:65359/W_Listar_Alumnos.aspx";
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

    <div class="col-lg-12 col-md-12 col-sm-12 card-header">
        <h2>Gestionar Progreso</h2>
    </div>
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="card">
                    <div class="card-header card-header-text" data-background-color="red">
                        <h4 id="txtPagina" runat="server" class="card-title">Registrar Progreso</h4>
                    </div>
                    <div class="card-content">
                        <form id="form1" runat="server" method="POST" class="form">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="upAlumno" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>

                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Nombre Progreso:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNombreProgreso" runat="server" class="form-control" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Calificacion Pasos:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNota1" runat="server" class="form-control" TextMode="Number" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Calificacion Técnica:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNota2" runat="server" class="form-control" TextMode="Number" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Calificacion Interes:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNota3" runat="server" class="form-control" TextMode="Number" required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Calificacion Habilidad:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNota4" runat="server" class="form-control" TextMode="Number" required></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 card-header">
                                            <h2>Total progreso:</h2>
                                        </div>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="col-lg-2 col-md-2 col-sm-6">
                                                    <asp:Button ID="btnCalcular" runat="server" Text="Calcular" CssClass="btn btn-fill btn-info" OnClientClick="prueba()" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Promedio:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtNotaTotal" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Progreso (%)</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtProgresoP" runat="server" class="form-control"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Observacion:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>
                                                <asp:TextBox ID="txtObservacion" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-8 col-md-8 col-sm-12">
                                            <p></p>
                                        </div>
                                        <asp:UpdatePanel ID="upBotonEnviar2" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div class="col-lg-2 col-md-2 col-sm-6">
                                                    <asp:Button ID="btnRegistrar" runat="server" Text="Guardar" CssClass="btn btn-fill btn-success" OnClientClick="registrar()" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="col-lg-2 col-md-2 col-sm-6">
                                            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-fill btn-danger" UseSubmitBehavior="false" OnClientClick="volver()" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

