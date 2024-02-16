<%@ Page Title="Informacion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PERFILES.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <hr />
        <h4> <b>Desarrollador:</b> Diego Morales</h4>
        <h4> <b>Proyecto:</b> PERFILES, S. A</h4>
        <p>Desarrollado con APS WEB FORMS y estructura de N capas.</p>
        <h4>Repositorio: </h4>
        <a class="nav-link" runat="server" href="https://github.com/DiegoMorales004/PERFILES-WEB-FORMS">Link a GitHub</a>
    </main>
</asp:Content>
