<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Empresa.aspx.cs" Inherits="VestidosAdmin.Empresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <div runat="server" Visible=<%# FormType == 1 %>>
            <h1 class="h2">Cadastrar Empresa</h1>
        </div>
        <div runat="server" Visible=<%# FormType == 2 %>>
            <h1 class="h2">Editar Empresa</h1>
        </div>
    </div>
    <div class="h6">Dados da Empresa</div>
    <div class="form-row bg-light border rounded px-3 pt-3">
    <div class="col-md-4 mb-3">
      <label for="txbNome">Nome</label>
      <asp:TextBox runat="server" type="text" CssClass="form-control" id="txbNome" placeholder="Nome fantasia" required />
    </div>
    <div class="col-md-4 mb-3">
      <label for="txbCnpj">CNPJ</label>
      <asp:TextBox runat="server" type="text" class="form-control" id="txbCnpj" placeholder="CNPJ" required />
    </div>
    <div class="col-md-4 mb-3">
      <label for="txbTelefone">Telefone</label>
      <asp:TextBox runat="server" type="text" class="form-control" id="txbTelefone" placeholder="Telefone" required />
    </div>
    <div class="col-md-4 mb-3">
      <label for="txbEmail">E-mail</label>
      <div class="input-group">
        <div class="input-group-prepend">
          <span class="input-group-text" id="inputGroupPrepend2">@</span>
        </div>
        <asp:TextBox runat="server" type="text" class="form-control" id="txbEmail" placeholder="E-mail" aria-describedby="inputGroupPrepend2" required />
      </div>
    </div>
    <div class="col-md-4 mb-3">
      <label for="txbLogin">Login</label>
      <asp:TextBox runat="server" type="text" class="form-control" id="txbLogin" placeholder="Login" required />
    </div>
    <div class="col-md-4 mb-3">
      <label for="txbSenha">Senha</label>
      <asp:TextBox runat="server" type="password" class="form-control" id="txbSenha" placeholder="Senha" required />
    </div>
    <div class="col-md-12 mb-3">
        <div class="form-group">
            <label for="exampleFormControlFile1">Foto</label>
            <input type="file" class="form-control-file" id="exampleFormControlFile1">
        </div>
    </div>
  </div>
    
  <div class="h6 pt-5">Endereço</div>  
  <div class="form-row bg-light border rounded px-3 pt-3">
    <div class="col-md-8 mb-3">
      <label for="txbRua">Rua</label>
      <asp:TextBox runat="server" type="text" class="form-control" id="txbRua" placeholder="Rua" required />
    </div>
    <div class="col-md-4 mb-3">
      <label for="txbNumero">Número</label>
      <asp:TextBox runat="server" type="text" class="form-control" id="txbNumero" placeholder="Número" required />
    </div>
    <div class="col-md-4 mb-3">
      <label for="txbComplemento">Complemento</label>
      <asp:TextBox runat="server" type="text" class="form-control" id="txbComplemento" placeholder="Complemento" />
    </div>
    <div class="col-md-4 mb-3">
      <label for="txbBairro">Bairro</label>
      <asp:TextBox runat="server" type="text" class="form-control" id="txbBairro" placeholder="Bairro" required/>
    </div>
      <div class="col-md-4 mb-3">
      <label for="txbCidade">Cidade</label>
      <asp:TextBox runat="server" type="text" class="form-control" id="txbCidade" placeholder="Cidade" required />
    </div>
    <div class="col-md-3 mb-3">
      <label for="txbEstado">Estado</label>
      <asp:TextBox runat="server" type="text" class="form-control" id="txbEstado" placeholder="Estado" required />
    </div>
    <div class="col-md-3 mb-3">
      <label for="txbCep">CEP</label>
      <asp:TextBox runat="server" type="number" class="form-control" id="txbCep" placeholder="CEP" required />
    </div>
  </div>
    <div class="form-row d-flex justify-content-center py-3">
        <asp:Button runat="server" ID="btnSalvar" class="btn btn-primary" type="submit" Text="Salvar" OnClick="btnSalvar_Click" />
    </div>
</asp:Content>
