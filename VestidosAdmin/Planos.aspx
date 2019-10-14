<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Planos.aspx.cs" Inherits="VestidosAdmin.Planos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Planos</h1>
    </div>
    <asp:ListView runat="server" DataKeyNames="id" DataSourceID="SqlDataSource1" InsertItemPosition="LastItem">
        <AlternatingItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Excluir" CssClass="btn btn-dark btn-sm mb-1"/>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Editar" CssClass="btn btn-dark btn-sm mb-1" />
                </td>
                <td>
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td>
                    <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                </td>
                <td>
                    <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                </td>
                <td>
                    <asp:Label ID="valorLabel" runat="server" Text='<%# Eval("valor") %>' />
                </td>
                <td>
                    <asp:Label ID="qtd_max_vestidosLabel" runat="server" Text='<%# Eval("qtd_max_vestidos") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Salvar" CssClass="btn btn-dark btn-sm mb-1" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" CssClass="btn btn-dark btn-sm mb-1" />
                </td>
                <td>
                    <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="nomeTextBox" runat="server" Text='<%# Bind("nome") %>' />
                </td>
                <td>
                    <asp:TextBox ID="descricaoTextBox" runat="server" Text='<%# Bind("descricao") %>' />
                </td>
                <td>
                    <asp:TextBox ID="valorTextBox" runat="server" Text='<%# Bind("valor") %>' />
                </td>
                <td>
                    <asp:TextBox ID="qtd_max_vestidosTextBox" runat="server" Text='<%# Bind("qtd_max_vestidos") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Novo" CssClass="btn btn-dark btn-sm mb-1" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Limpar" CssClass="btn btn-dark btn-sm mb-1" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:TextBox ID="nomeTextBox" runat="server" Text='<%# Bind("nome") %>' CssClass="form-control" placeholder="Nome" />
                </td>
                <td>
                    <asp:TextBox ID="descricaoTextBox" runat="server" Text='<%# Bind("descricao") %>' CssClass="form-control" placeholder="Descrição" />
                </td>
                <td>
                    <asp:TextBox ID="valorTextBox" runat="server" Text='<%# Bind("valor") %>' CssClass="form-control" placeholder="Valor" />
                </td>
                <td>
                    <asp:TextBox ID="qtd_max_vestidosTextBox" runat="server" Text='<%# Bind("qtd_max_vestidos") %>' CssClass="form-control" placeholder="Qtd. Máx. Vestidos" />
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Excluir" CssClass="btn btn-dark btn-sm mb-1" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Editar" CssClass="btn btn-dark btn-sm mb-1" />
                </td>
                <td>
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td>
                    <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                </td>
                <td>
                    <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                </td>
                <td>
                    <asp:Label ID="valorLabel" runat="server" Text='<%# Eval("valor") %>' />
                </td>
                <td>
                    <asp:Label ID="qtd_max_vestidosLabel" runat="server" Text='<%# Eval("qtd_max_vestidos") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="0" style="" class="table table-striped">
                            <tr runat="server" style="">
                                <th runat="server"></th>
                                <th runat="server">Id</th>
                                <th runat="server">Nome</th>
                                <th runat="server">Descrição</th>
                                <th runat="server">Valor</th>
                                <th runat="server">Qtd. Máx. Vestidos</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" ButtonCssClass="btn btn-dark btn-sm mb-1" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Excluir"  CssClass="btn btn-dark btn-sm mb-1"/>
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Editar" CssClass="btn btn-dark btn-sm mb-1"/>
                </td>
                <td>
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                </td>
                <td>
                    <asp:Label ID="nomeLabel" runat="server" Text='<%# Eval("nome") %>' />
                </td>
                <td>
                    <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                </td>
                <td>
                    <asp:Label ID="valorLabel" runat="server" Text='<%# Eval("valor") %>' />
                </td>
                <td>
                    <asp:Label ID="qtd_max_vestidosLabel" runat="server" Text='<%# Eval("qtd_max_vestidos") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:vestidos_para_alugarConnectionString %>" DeleteCommand="DELETE FROM [Plano] WHERE [id] = @id" InsertCommand="INSERT INTO [Plano] ([nome], [descricao], [valor], [qtd_max_vestidos]) VALUES (@nome, @descricao, @valor, @qtd_max_vestidos)" SelectCommand="SELECT [id], [nome], [descricao], [valor], [qtd_max_vestidos] FROM [Plano]" UpdateCommand="UPDATE [Plano] SET [nome] = @nome, [descricao] = @descricao, [valor] = @valor, [qtd_max_vestidos] = @qtd_max_vestidos WHERE [id] = @id">
         <DeleteParameters>
             <asp:Parameter Name="id" Type="Int32" />
         </DeleteParameters>
         <InsertParameters>
             <asp:Parameter Name="nome" Type="String" />
             <asp:Parameter Name="descricao" Type="String" />
             <asp:Parameter Name="valor" Type="Double" />
             <asp:Parameter Name="qtd_max_vestidos" Type="Int32" />
         </InsertParameters>
         <UpdateParameters>
             <asp:Parameter Name="nome" Type="String" />
             <asp:Parameter Name="descricao" Type="String" />
             <asp:Parameter Name="valor" Type="Double" />
             <asp:Parameter Name="qtd_max_vestidos" Type="Int32" />
             <asp:Parameter Name="id" Type="Int32" />
         </UpdateParameters>
     </asp:SqlDataSource>
</asp:Content>
