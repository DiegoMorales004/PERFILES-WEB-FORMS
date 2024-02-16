<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PERFILES._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div>
            <asp:Button runat="server" OnClick="New_Employee_Click" CssClass="btn btn-sm btn-success" Text="Nuevo" />
        </div>
    </div>

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

                    <asp:TemplateField>
                        <ItemTemplate>
                            
                            <asp:LinkButton 
                                runat="server" 
                                CommandArgument='<%# Eval("Id") %>'
                                OnClick="Edit_Employee_Click"
                                CssClass="btn btn-sm btn-primary mb-2"
                                >
                                Editar
                            </asp:LinkButton>

                            <asp:LinkButton 
                                runat="server" 
                                CommandArgument='<%# Eval("Id") %>'
                                OnClick="Delete_Employee_Click"
                                CssClass="btn btn-sm btn-danger"
                                OnClientClick="return confirm('¿Desea eliminar el empleado?')"
                                >
                                Eliminar
                            </asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            
        </div>
    </div>

</asp:Content>
