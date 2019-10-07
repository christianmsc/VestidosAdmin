﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="VestidosAdmin.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Detalhes do Usuário</h1>
    </div>
    <div class="container">
        <div class="h6">Informações Pessoais</div>
        <div class="row py-2 border rounded bg-light mb-5">
            <div class="col-md-2">
                <%--<img src="https://t4.ftcdn.net/jpg/01/12/09/17/500_F_112091769_vWEmDiwVIpO4H1plGuhYgnmduTuiGUh2.jpg" width="100%" height="100%" class="d-inline-block rounded-circle mr-1" alt="">--%>
                <img src="img/<%# objUsuario.Foto %>" width="100%" height="100%" class="d-inline-block rounded-circle mr-1" alt="">
            </div>
            <div class="col-md-10">
                <div class="h4"><%# objUsuario.Nome %></div>
                <div class="h5">CPF: <%# objUsuario.Cpf %></div>
                <div class="h5">Data de Nascimento: <%# objUsuario.DataNascimento.ToString("dd/MM/yyyy") %></div>
                <div class="h5">Telefone: <%# objUsuario.Telefone %></div>
            </div>
        </div>
        <div class="h6">Endereço</div>
        <div class="row py-2 border rounded bg-light mb-5">
            <div class="col-md-12">
                <div class="h5">Logradouro: <span class="h6"><%# objUsuario.Logradouro %></span></div>
                <div class="h5">Número: <span class="h6"><%# objUsuario.Numero %></span></div>
                <div class="h5" Visible=<%# objUsuario.Complemento != null && objUsuario.Complemento != String.Empty %> runat="server">Complemento: <span class="h6"><%# objUsuario.Complemento %></span></div>
                <div class="h5">Bairro: <span class="h6"><%# objUsuario.Bairro %></span></div>
                <div class="h5">Cidade: <span class="h6"><%# objUsuario.Cidade %></span></div>
                <div class="h5">Estado: <span class="h6"><%# objUsuario.Estado %></span></div>
                <div class="h5">CEP: <span class="h6"><%# objUsuario.Cep %></span></div>
            </div>
        </div>
    </div>
</asp:Content>
