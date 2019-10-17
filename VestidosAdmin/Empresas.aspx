<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Empresas.aspx.cs" Inherits="VestidosAdmin.Empresas" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Empresas</h1>
        <asp:Button ID="btnNovaEmpresa" Text="Nova Empresa" runat="server" CssClass="btn btn-primary float-right" OnClick="btnNovaEmpresa_Click"/>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="grdEmpresas" runat="server" CssClass="table" GridLines="None" OnRowDataBound="grdEmpresas_RowDataBound"
              OnSelectedIndexChanged="grdEmpresas_SelectedIndexChanged">
        </asp:GridView>
    </div>
</asp:Content>
