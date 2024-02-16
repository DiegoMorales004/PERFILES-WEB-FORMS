<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="PERFILES.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="lblTitle" runat="server" CssClass="fs-4 fw-bold"></asp:Label>
    <br />
    <br />

    <div class="d-flex flex-row justify-content-start">
        <!-- First Section --> 
        <div class="mr-5">
            <div class="mb-3 d-flex flex-row justify-content-around" >
                <label class="form-label" >Nombres</label>
                <asp:TextBox ID="txtNames" runat="server" CssClass="form-control ms-4" ></asp:TextBox>
            </div>

            <div class="mb-3 d-flex flex-row justify-content-around">
                <label class="form-label" >DPI</label>
                <asp:TextBox ID="txtDPI" runat="server" CssClass="form-control ms-4" ></asp:TextBox>
            </div>

            <div class="mb-3 d-flex flex-row justify-content-around">
                <label class="form-label" >Fecha de nacimiento</label>
                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control ms-4" TextMode="Date"></asp:TextBox>
            </div>

            <div class="mb-3 d-flex flex-row justify-content-around">
                <label class="form-label" >Genero</label>
                <asp:DropDownList ID="ddlGenders" runat="server" CssClass="form-control ms-4"></asp:DropDownList>
            </div>
        </div>

        <!-- Second Section --> 
        <div class="ms-4">
            <div class="mb-3 d-flex flex-row justify-content-around">
                <label class="form-label" >Fecha de contratacion</label>
                <asp:TextBox ID="txtAdmission" runat="server" CssClass="form-control ms-4" TextMode="Date"></asp:TextBox>
            </div>

            <div class="mb-3 d-flex flex-row justify-content-around">
                <label class="form-label" >Direccion</label>
                <asp:TextBox ID="txtHomeAddress" runat="server" CssClass="form-control ms-4"></asp:TextBox>
            </div>

            <div class="mb-3 d-flex flex-row justify-content-around">
                <label class="form-label" >NIT</label>
                <asp:TextBox ID="txtNIT" runat="server" CssClass="form-control ms-4"></asp:TextBox>
            </div>

            <div class="mb-3 d-flex flex-row">
                <label class="form-label" >Departamento</label>
                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control ms-4"></asp:DropDownList>
            </div>
        </div>
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Guardar" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click"/>

    <asp:LinkButton runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-sm btn-danger" >Cancelar</asp:LinkButton>

</asp:Content>
