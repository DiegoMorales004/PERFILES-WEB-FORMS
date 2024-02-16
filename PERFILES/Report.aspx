<%@ Page Title="Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="PERFILES.Report" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <hr />
        

        <div class="row">
    <div class="col-12">
        
        <asp:GridView ID="GVEmployees" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="Names" HeaderText="Nombres"/>
                <asp:BoundField DataField="DPI" HeaderText="DPI"/>
                <asp:BoundField DataField="BirthDate" HeaderText="Fecha de Nacimiento"/>
                <asp:BoundField DataField="Gender" HeaderText="Genero"/>
                <asp:BoundField DataField="Admission" HeaderText="Fecha de contratacion"/>
                <asp:BoundField DataField="Age" HeaderText="Edad"/>
                <asp:BoundField DataField="HomeAddress" HeaderText="Direccion"/>
                <asp:BoundField DataField="NIT" HeaderText="NIT"/>
                <asp:BoundField DataField="Department.name" HeaderText="Departamento"/>

            </Columns>
        </asp:GridView>
        
    </div>
</div>

    </main>
</asp:Content>
