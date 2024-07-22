<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Votaciones.aspx.cs" Inherits="SistemaDeVotaciones2.Votaciones" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Votaciones - Sistema de Votaciones</title>
    <meta charset="utf-8" />
    <link href="Styles/site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Votaciones</h1>

            <nav class="sidebar-menu">
                <ul>
                    <li><a href="Inicio.aspx">Inicio</a></li>
                    <li><a href="IngresarCandidatos.aspx">Ingresar Candidatos</a></li>
                    <li><a href="Votaciones.aspx">Votaciones</a></li>
                    <li><a href="Resultados.aspx">Resultados</a></li>
                </ul>
            </nav>

            <!-- Mensajes de error y éxito -->
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
            <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" />

            <!-- Formulario para seleccionar candidato y votar -->
            <asp:DropDownList ID="ddlCandidatos" runat="server" />
            <asp:Button ID="btnVote" Text="Votar" runat="server" OnClick="btnVote_Click" />
        </div>
    </form>
</body>
</html>
