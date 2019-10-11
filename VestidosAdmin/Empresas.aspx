<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Empresas.aspx.cs" Inherits="VestidosAdmin.Empresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Empresas</h1>
    </div>
    <asp:GridView ID="grdEmpresas" runat="server" CssClass="table table-striped" GridLines="None" OnRowDataBound="grdEmpresas_RowDataBound">
    </asp:GridView>
</asp:Content>
