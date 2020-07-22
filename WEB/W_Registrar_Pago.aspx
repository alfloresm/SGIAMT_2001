<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="W_Registrar_Pago.aspx.cs" Inherits="WEB.W_Registrar_Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="card">
                    <div class="card-header card-header-text" data-background-color="red">
                        <h4 id="txtPagina" runat="server" class="card-title">Registrar Pago</h4>
                    </div>
                    <div class="card-content">

                        <form id="form1" runat="server" method="POST" class="form">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <div class="row">
                                <asp:Panel ID="Panel2" runat="server" CssClass="col-lg-6 col-md-6 col-sd-12">
                                    <div class="col-md-6">
                                        <label class="col-md-2 label-on-left">DNI:</label>
                                        <div class="form-group label-floating is-empty">
                                            <label class="control-label"></label>
                                            <asp:DropDownList ID="ddlDNI" runat="server" CssClass="selectpicker">
                                                <asp:ListItem Text="---Seleccione----" Value="0" Selected="True"></asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                        <asp:TextBox ID="txtDni" runat="server" class="form-control" placeholder="Buscar"></asp:TextBox>
                                                
                                    </div>
                                    <asp:UpdatePanel ID="upnBotonBuscar1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnBuscar1" runat="server" CssClass="btn btn-white btn-round btn-just-icon" OnClick="btnBuscar1_Click">
                                                    <i class="material-icons">search</i>
                                                    <div class="ripple-container"></div>
                                            </asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                                <div class="col-md-6">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="row">
                                                <label class="col-md-3 label-on-left">Nombre:</label>
                                                <div class="col-md-9">
                                                    <div class="form-group label-floating is-empty">
                                                        <label class="control-label"></label>
                                                        <asp:TextBox ID="txtNombre2" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <label class="col-md-3 label-on-left">Categoria:</label>
                                                <div class="col-md-9">
                                                    <div class="form-group label-floating is-empty">
                                                        <label class="control-label"></label>
                                                        <asp:TextBox ID="txtCategoria2" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-sd-6">
                                    <label class="col-md-2 label-on-left">Concepto Pago:</label>
                                    <div class="form-group label-floating is-empty">
                                        <label class="control-label"></label>

                                        <asp:DropDownList ID="ddlConceptoPago" runat="server" CssClass="selectpicker">
                                        </asp:DropDownList>
                                        
                                        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btnMonto" runat="server" CssClass="btn btn-white btn-round btn-just-icon" OnClick="btnMonto_Click">
                                                    <i class="material-icons">calculate</i>
                                                    <div class="ripple-container"></div>
                                                </asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>

                                <asp:UpdatePanel ID="updPanel2" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <div class="col-lg-4 col-md-4 col-sd-6">
                                            <label class="col-md-2 label-on-left">Monto:</label>
                                            <div class="form-group label-floating is-empty">
                                                <label class="control-label"></label>S/.
                                                
                                                <asp:TextBox ID="txtMonto" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="row">

                                <div class="col-lg-4 col-md-4 col-sd-6">
                                    <label class="col-md-2 label-on-left">Mes:</label>
                                    <div class="form-group label-floating is-empty">
                                        <label class="control-label"></label>
                                        <asp:DropDownList ID="ddlMes" runat="server" CssClass="selectpicker">
                                            <asp:ListItem Text="Seleccione" Value="0" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Enero" Value="Enero"></asp:ListItem>
                                            <asp:ListItem Text="Febrero" Value="Febrero"></asp:ListItem>
                                            <asp:ListItem Text="Marzo" Value="Marzo"></asp:ListItem>
                                            <asp:ListItem Text="Abril" Value="Abril"></asp:ListItem>
                                            <asp:ListItem Text="Mayo" Value="Mayo"></asp:ListItem>
                                            <asp:ListItem Text="Junio" Value="Junio"></asp:ListItem>
                                            <asp:ListItem Text="Julio" Value="Julio"></asp:ListItem>
                                            <asp:ListItem Text="Agosto" Value="Agosto"></asp:ListItem>
                                            <asp:ListItem Text="Septiembre" Value="Septiembre"></asp:ListItem>
                                            <asp:ListItem Text="Octubre" Value="Octubre"></asp:ListItem>
                                            <asp:ListItem Text="Noviembre" Value="Noviembre"></asp:ListItem>
                                            <asp:ListItem Text="Diciembre" Value="Diciembre"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-lg-8 col-md-8 col-sm-12">
                                    <p></p>
                                </div>
                                <asp:UpdatePanel ID="upBotonEnviar" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="col-lg-2 col-md-2 col-sm-6">
                                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-fill btn-success" OnClick="btnRegistrar_Click" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="col-lg-2 col-md-2 col-sm-6">
                                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-fill btn-danger" OnClick="btnRegresar_Click" />
                                </div>
                            </div>
                            <%--</ContentTemplate>
                            </asp:UpdatePanel>--%>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function showSuccessMessage2() {
            setTimeout(function () {
                swal({
                    title: "Todo guardado",
                    text: "Pulsa el botón y se te redirigirá",
                    type: "success"
                }, function () {
                    window.location = "GestionCatalogo.aspx";
                });
            }, 1000);
        }
        function showMessage(from, align, message, type) {
            $.notify({
                icon: "notifications",
                message: message

            }, {
                    type: type,
                    timer: 3000,
                    placement: {
                        from: from,
                        align: align
                    }
                });
        }
    </script>
    <script>
        ///*
        // * OBTENER FECHA CTUAL PARA DATE
        // */
        //document.getElementById('date').valueAsDate = new Date();
        ///*
        // * LLENAR DE DATOS A YEAR
        // */
        //var year = new Date().getFullYear().toString();
        //var y = parseInt(year);
        //var j = 0;
        //let selectyear = document.getElementById('year');
        //for (var i = parseInt(y) - 1; i < parseInt(y) + 2; i++) {
        //    selectyear.options[j] = new Option(i, i);
        //    j++;
        //}
        ///*
        // * SELECCIONA YEAR ACTUAL QUE SIEMPRE ESTA EN LA SEGUNDA POSCION O INDEX 1
        // */
        //selectyear.selectedIndex = "1";
        ///*
        // * VINCULO ENTRE CONCEPT Y AMOUNT
        // */
        //function selectionConcept() {
        //    let amount = document.getElementById('amount');
        //    amount.value = document.getElementById('concept').value;
        //}
        //function selectionAmount() {
        //    let concept = document.getElementById('concept');
        //    concept.value = document.getElementById('amount').value;
        //}
    </script>

</asp:Content>
