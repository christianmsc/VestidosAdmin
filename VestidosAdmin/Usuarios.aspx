﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="VestidosAdmin.Usuarios" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Usuários</h1>
    </div>
    <div class="table-responsive">
        <asp:GridView runat="server" ID="gvUsuarios" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" CssClass="table" GridLines="None" OnRowDataBound="gvUsuarios_RowDataBound" OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
                <asp:BoundField DataField="cpf" HeaderText="cpf" SortExpression="cpf" />
                <asp:BoundField DataField="dataNascimento" HeaderText="dataNascimento" SortExpression="dataNascimento" />
                <asp:BoundField DataField="telefone" HeaderText="telefone" SortExpression="telefone" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
            </Columns>
        </asp:GridView>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:vestidos_para_alugarConnectionString %>" SelectCommand="SELECT [id], [nome], [cpf], [dataNascimento], [telefone], [email] FROM [Usuario]"></asp:SqlDataSource>   
</asp:Content>
