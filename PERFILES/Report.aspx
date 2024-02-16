<%@ Page Title="Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="PERFILES.Report" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <hr />
        

        <div class="row">
            <div class="col-12">

                <asp:Button ID="btnFilters" runat="server" Text="Aplicar filtros" CssClass="btn btn-success"
                    OnClick="btnSubmit_Click"/>

                <div class="mt-3 d-flex flex-row mx-auto mb-3">
                    <!-- Select department -->
                    <div class="mb-3 card p-2">
                        <label class="form-label" >Departamento</label>
                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <!-- Select dates --> 
                    <div class="d-flex flex-row justify-content-around">

                        <div class="ms-5 card p-2">
                            <label class="form-label" >Fecha de contratacion inicial</label>
                            <asp:TextBox ID="txtInitialDate" runat="server" CssClass="form-control" TextMode="Date">
                            </asp:TextBox>
                        </div>

                        <div class="ms-2 card p-2">
                            <label class="form-label" >Fecha de contratacion final</label>
                            <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" TextMode="Date">
                            </asp:TextBox>
                        </div>

                    </div>

                </div>

        
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
