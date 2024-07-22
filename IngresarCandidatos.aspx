<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresarCandidatos.aspx.cs" Inherits="SistemaDeVotaciones2.IngresarCandidatos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingresar Candidatos - Sistema de Votaciones</title>
    <meta charset="utf-8" />
    <link href="Styles/site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Ingresar Candidatos</h1>

            <nav class="sidebar-menu">
                <ul>
                    <li><a href="Inicio.aspx">Inicio</a></li>
                    <li><a href="IngresarCandidatos.aspx">Ingresar Candidatos</a></li>
                    <li><a href="Votaciones.aspx">Votaciones</a></li>
                    <li><a href="Resultados.aspx">Resultados</a></li>
                </ul>
            </nav>

            <asp:TextBox ID="txtNombre" runat="server" />
            <asp:TextBox ID="txtPartido" runat="server" />
            <asp:TextBox ID="txtPlataforma" runat="server" TextMode="MultiLine" />
            
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar Candidato" OnClick="btnAgregar_Click" />
            
            <!-- Labels for error and success messages -->
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
            <asp:Label ID="lblSuccess" runat="server" ForeColor="Green" />
        </div>
    </form>
</body>
</html>
