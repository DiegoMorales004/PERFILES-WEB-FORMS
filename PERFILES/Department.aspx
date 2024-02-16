<%@ Page Title="Department" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="PERFILES.Department" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="Departamento">
        <h2 id="title"><%: Title %></h2>
        <hr />
        

        <div class="row">
    <div class="col-12">
        
            <asp:GridView ID="GVDepartment" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Nombre"/>
                    <asp:BoundField DataField="description" HeaderText="Descripcioin"/>

                    <asp:TemplateField>
                        <ItemTemplate>
        
                            <div class="d-flex">
                                <asp:LinkButton 
                                    runat="server" 
                                    CommandArgument='<%# Eval("Id") %>'
                                    OnClick="Edit_Department_Click"
                                    CssClass="btn btn-sm btn-primary"
                                    >
                                    Editar
                                </asp:LinkButton>
                            </div>

                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        
        </div>
    </div>

    </main>
</asp:Content>