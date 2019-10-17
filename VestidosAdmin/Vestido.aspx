<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Vestido.aspx.cs" Inherits="VestidosAdmin.Vestido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Detalhes do Vestido</h1>
    </div>
    <div class="container">
        <div id="infosVestido">
            <div class="row">
                <div class="col-md-4 pr-4">
                    <div class="h6">Informações do Vestido</div>
                    <div class="row py-2 border rounded bg-light mb-5 d-flex justify-content-center">
                        <div class="col-md-12">
                            <div class="h4"><%# objVestido.Nome %></div>
                            <div class="h5">Tamanho: <%# objVestido.Tamanho %></div>
                            <div class="h5">Preço: R$ <%# objVestido.Preco %></div>
                            <div class="h5">Descrição: <%# objVestido.Descricao %></div>
                        </div>
                    </div>
                </div>
                <div class="col-md-8 pl-4">
                    <div class="h6">Fotos do Vestido</div>
                    <div class="row py-2 border rounded bg-light mb-5 d-flex justify-content-center">
                        <div id="carouselExampleControls" class="carousel slide px-2" data-ride="carousel">
                            <div class="carousel-inner">
                                <asp:Repeater runat="server" ID="rptFotosVestido">
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <asp:Image ImageUrl=<%# "fotos/" + DataBinder.Eval(Container.DataItem,"Nome") %> CssClass="d-block w-100 rounded" runat="server" />
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Anterior</span>
                            </a>
                            <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Próximo</span>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div ID="infosEmpresa">
            <div class="h6">Informações da Empresa Fornecedora</div>
            <div class="row py-2 border rounded bg-light mb-5">
                <div class="col-md-2">
                    <div Visible=<%# objEmpresa.IdFoto != null %> runat="server">
                        <asp:Image ImageUrl=<%# "fotos/" + objFotoEmpresa.Nome %> width="100px" height="100px" CssClass="d-inline-block rounded-circle mr-1 img-fluid" runat="server" />
                    </div>
                    <div Visible=<%# objEmpresa.IdFoto == null %> runat="server">
                        <asp:Image ImageUrl="fotos/User_icon_BLACK-01.png" width="100px" height="100px" CssClass="d-inline-block rounded-circle mr-1" runat="server"/>
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="h4"><%# objEmpresa.Nome %></div>
                    <div class="h5">E-mail: <%# objEmpresa.Email %></div>
                    <div class="h5">Telefone: <%# objEmpresa.Telefone %></div>
                </div>
            </div>
        </div>
        <div ID="infosUsuario" runat="server" Visible=<%# objUsuario.Id > 0 %>>
            <div class="h6">Informações do Usuário Dono do Vestido</div>
            <div class="row py-2 border rounded bg-light mb-5">
                 <div class="col-md-2">
                    <div Visible=<%# objUsuario.IdFoto != null %> runat="server">
                        <asp:Image ImageUrl=<%# "fotos/" + objFotoUsuario.Nome %> width="100px" height="100px" CssClass="d-inline-block rounded-circle mr-1 img-fluid" runat="server" />
                    </div>
                    <div Visible=<%# objUsuario.IdFoto == null %> runat="server">
                        <asp:Image ImageUrl="fotos/User_icon_BLACK-01.png" width="100px" height="100px" CssClass="d-inline-block rounded-circle mr-1" runat="server" />
                    </div>
                </div>
                <div class="col-md-10">
                    <div class="h4"><%# objUsuario.Nome %></div>
                    <div class="h5">E-mail: <%# objUsuario.Email %></div>
                    <div class="h5">Telefone: <%# objUsuario.Telefone %></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
