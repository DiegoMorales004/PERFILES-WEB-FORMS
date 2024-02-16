<%@ Page Title="ActionDepartment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActionDepartment.aspx.cs" Inherits="PERFILES.ActionDepartment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label ID="lblTitle" runat="server" CssClass="fs-4 fw-bold"></asp:Label>
    <br />
    <br />

    <div class="d-flex flex-row justify-content-start">
        <!-- First Section --> 
        <div class="mr-5">
            <div class="mb-3 d-flex flex-row justify-content-around" >
                <label class="form-label" >Nombre</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control ms-4" ></asp:TextBox>
            </div>
        </div>

        <!-- Second Section --> 
        <div class="ms-4">
            <div class="mb-3 d-flex flex-row justify-content-around">
                <label class="form-label" >Descripcion</label>
                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control ms-4"></asp:TextBox>
            </div>
        </div>
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Guardar" CssClass="btn btn-sm btn-primary" OnClick="btnSubmit_Click"/>

    <asp:LinkButton runat="server" PostBackUrl="~/Departments.aspx" CssClass="btn btn-sm btn-danger" >Cancelar</asp:LinkButton>

</asp:Content>
