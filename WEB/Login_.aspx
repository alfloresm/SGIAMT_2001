<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_.aspx.cs" Inherits="WEB.Login_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" type="image/png" href="../assets/img/logo.png" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport' />
    <title>Tusuy Peru</title>
    <link href="assets/css/Login.css" rel="stylesheet" />
    <link href="assets/sweetalert/sweetalert.css" rel="stylesheet" />
</head>
<body>
    <div class="body"></div>
    <div class="grad"></div>
    <div class="header">
        <div>Tusuy<span class="color: #DE432F;">Perú</span></div>
    </div>
    <br />

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate>
                <div class="login">
                    <asp:TextBox ID="txtDni" runat="server" CssClass="txtUser" placeholder="DNI" MinLength="8" MaxLength="8" required></asp:TextBox>
                    <br />
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="txtPass" placeholder="Contraseña" TextMode="Password" MinLength="3" required></asp:TextBox>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
                        <ContentTemplate>
                            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btnLogin" OnClick="btnLogin_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
<script src="assets/sweetalert/sweetalert.min.js"></script>
<script>
    function showErrorMessage() {
        swal({title: "ERROR!",
            text: "Usuario o contraseña incorrecta",
            type: "error"});
    }
</script>
</html>
