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
    <div class="row bg-light border rounded px-3 pt-3">
        <div class="col-md-2 d-flex align-items-center justify-content-center">
             <div class="form-group text-center">
                <asp:Image ImageUrl=<%# "fotos/" + objFoto.Nome %>  Visible=<%# objEmpresa.IdFoto != null %> width="100px" height="100px" class="d-inline-block rounded-circle mr-1" runat="server"/>
                <asp:Image ImageUrl="fotos/User_icon_BLACK-01.png" class="d-inline-block rounded-circle mr-1" Visible=<%# objEmpresa.IdFoto == null %> width="100px" height="100px" runat="server"/>
                <asp:FileUpload runat="server" CssClass="form-control-file" ID="fuFoto" accept="image/png, image/jpeg" style="display:none"/>
                <div><label for="fuFoto" id="imgLink" onclick="document.getElementById('<%# fuFoto.ClientID %>').click();">Nova Imagem...</label></div>
            </div>
        </div>
        <div class="col-md-10">
            <div class="form-row">
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
                  <asp:TextBox runat="server" type="text" class="form-control" id="txbTelefone" placeholder="Telefone" />
                </div>
                <div class="col-md-4 mb-3">
                  <label for="txbEmailEmpresa">E-mail</label>
                  <div class="input-group">
                    <div class="input-group-prepend">
                      <span class="input-group-text" id="inputGroupPrepend2">@</span>
                    </div>
                    <asp:TextBox runat="server" type="text" class="form-control" id="txbEmailEmpresa" placeholder="E-mail" aria-describedby="inputGroupPrepend2" />
                  </div>
                </div>
                <div class="col-md-4 mb-3">
                  <label for="txbLogin">Login</label>
                  <asp:TextBox runat="server" type="text" class="form-control" id="txbLogin" placeholder="Login" required />
                </div>
                <div class="col-md-4 mb-3">
                  <label for="txbSenhaEmpresa">Senha</label>
                  <asp:TextBox runat="server" type="password" class="form-control" id="txbSenhaEmpresa" placeholder="Senha" required />
                </div>
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
