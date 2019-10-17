<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Alugueis.aspx.cs" Inherits="VestidosAdmin.Alugueis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Aluguéis</h1>
    </div>
    <asp:Label ID="lblSemRegistro" Text="Não há aluguéis a serem mostrados" runat="server" CssClass="h6 text-secondary d-flex justify-content-center" Visible="false"/>
    <div class="table-responsive">
        <asp:GridView ID="gvAlugueis" runat="server" CssClass="table" GridLines="None" Visible="false" OnRowDataBound="gvAlugueis_RowDataBound">
        </asp:GridView>
    </div>
</asp:Content>
