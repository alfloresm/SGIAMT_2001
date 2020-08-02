<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="WEB.prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Buscar número aleatorio en el servidor utilizando AJAX</title>
        <style>
            .label {
                font-size: 30px;
            }
        </style>
        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js"></script>

    </head>

    <body>

        <%--<form id="form1" runat="server">



            <div>
                <asp:TextBox ID="btnNumeroAleatorio" runat="server" AutoPostBack="false">Buscar número aleatorio</asp:TextBox>
                <br />
                <asp:Label ID="lblResultado" runat="server" CssClass="label" />
            </div>
        </form>--%>

        <form id="form2" runat="server">
            <div>

                <b>SUMA DE VALORES CON JavaScript Y ASP.NET</b><br />
                <br />
                valo A=<asp:TextBox ID="txt_a" runat="server">0</asp:TextBox>
                <br />
                valor B=<asp:TextBox ID="txt_b" runat="server">0</asp:TextBox>
                <br />
                Resultado=<asp:TextBox ID="txt_total" runat="server">0</asp:TextBox>

            </div>
        </form>

        <%--        <script type="text/javascript">            $(document).ready(function () {                $('#btnNumeroAleatorio').click(function (e) {                    e.preventDefault();                    $.ajax({                        type: "POST",                                              // tipo de request que estamos generando                        url: 'prueba.aspx/BuscarNumAleatorio',                    // URL al que vamos a hacer el pedido                        data: null,                                                // data es un arreglo JSON que contiene los parámetros que 
                        // van a ser recibidos por la función del servidor                        contentType: "application/json; charset=utf-8",            // tipo de contenido                        dataType: "json",                                          // formato de transmición de datos                        async: true,                                               // si es asincrónico o no                        success: function (resultado) {                            // función que va a ejecutar si el pedido fue exitoso                            var num = resultado.d;                            $('#lblResultado').text('Número aleatorio es ' + num);                        },                        error: function (XMLHttpRequest, textStatus, errorThrown) { // función que va a ejecutar si hubo algún tipo de error en el pedido                            var error = eval("(" + XMLHttpRequest.responseText + ")");                            aler(error.Message);
                        }                    });                });            });    </script>--%>
        <script type="text/javascript">
            function sumar() {
                var a, b, r;    // Se declara la variable
                a = document.getElementById('txt_a').value;  //captura del contenido del TextBox
                b = document.getElementById('txt_b').value;
                r = parseFloat(a) + parseFloat(b);           // Convierte en Float y sumar
                document.getElementById('txt_total').value = r; // El resultado en TextBox resultado
            }
        </script>

    </body>
    </html>
</asp:Content>
