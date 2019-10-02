<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Vestidos.aspx.cs" Inherits="VestidosAdmin.Vestidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvVestidos" runat="server" CssClass="table table-striped" GridLines="None">
    </asp:GridView>
</asp:Content>
