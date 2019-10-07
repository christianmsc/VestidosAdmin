<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="VestidosAdmin.Usuarios" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Usuários</h1>
    </div>
    <asp:GridView runat="server" ID="gvUsuarios" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" CssClass="table table-striped" GridLines="None" OnRowDataBound="gvUsuarios_RowDataBound" OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome" />
            <asp:BoundField DataField="cidade" HeaderText="Cidade" SortExpression="cidade" />
            <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="estado" />
            <asp:BoundField DataField="data_nascimento" HeaderText="Nascimento" SortExpression="data_nascimento" />
            <asp:BoundField DataField="telefone" HeaderText="Telefone" SortExpression="telefone" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:vestidos_para_alugarConnectionString %>" SelectCommand="SELECT [id], [nome], [cidade], [estado], [data_nascimento], [telefone] FROM [Usuario] ORDER BY [id] DESC"></asp:SqlDataSource>   
</asp:Content>
