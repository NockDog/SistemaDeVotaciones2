<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SistemaDeVotaciones2.Inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio - Sistema de Votaciones</title>
    <meta charset="utf-8" />
    <link href="Styles/site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Bienvenido al Sistema de Votaciones</h1>
            <img src="path/to/welcome-image.jpg" alt="Bienvenida" class="welcome-image" />

            <nav class="sidebar-menu">
                <ul>
                    <li><a href="IngresarCandidatos.aspx">Ingresar Candidatos</a></li>
                    <li><a href="Votaciones.aspx">Votaciones</a></li>
                    <li><a href="Resultados.aspx">Resultados</a></li>
                </ul>
            </nav>
        </div>
    </form>
</body>
</html>
