<%@ Page Title="Departamentos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="PERFILES.Departments" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="Departamento">
        <h2 id="title"><%: Title %></h2>
        <hr />
        
        <div>
            <div>
                <asp:Button runat="server" OnClick="New_Department_Click" CssClass="btn btn-sm btn-success mx-auto mb-5" Text="Agregar Departamento" />
            </div>
        </div>

        <div class="row">
            <div class="col-12">
        
                    <asp:GridView ID="GVDepartment" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="name" HeaderText="Nombre"/>
                            <asp:BoundField DataField="description" HeaderText="Descripcion"/>

                            <asp:TemplateField>
                                <ItemTemplate>
        
                                    <div class="d-flex">
                                        <asp:LinkButton 
                                            runat="server" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            OnClick="Edit_Department_Click"
                                            CssClass="btn btn-sm btn-primary mx-auto"
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