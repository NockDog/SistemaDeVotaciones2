<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Resultados.aspx.cs" Inherits="SistemaDeVotaciones2.Resultados" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Resultados - Sistema de Votaciones</title>
    <meta charset="utf-8" />
    <link href="Styles/site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Resultados de la Elección</h1>

            <nav class="sidebar-menu">
                <ul>
                    <li><a href="Inicio.aspx">Inicio</a></li>
                    <li><a href="IngresarCandidatos.aspx">Ingresar Candidatos</a></li>
                    <li><a href="Votaciones.aspx">Votaciones</a></li>
                    <li><a href="Resultados.aspx">Resultados</a></li>
                </ul>
            </nav>

            <!-- Mostrar resultados aquí -->
            <asp:GridView ID="gvResultados" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Partido" HeaderText="Partido" />
                    <asp:BoundField DataField="NumeroDeVotos" HeaderText="Número de Votos" />
                    <asp:BoundField DataField="Porcentaje" HeaderText="Porcentaje" DataFormatString="{0:N2}%" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
