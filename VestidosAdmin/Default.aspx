<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VestidosAdmin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1 class="h2">Informações</h1>
        <div class="btn-toolbar mb-2 mb-md-0">
            <div class="btn-group mr-2">
                <button type="button" class="btn btn-sm btn-primary">Exportar</button>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row pb-5">
            <div class="col-lg-6 text-center">
                <h5>Receita por Plano</h5>
                <canvas class="my-4 w-100" id="myChart" width="900" height="380"></canvas>
            </div>
            <div class="col-lg-6 text-center">
                <h5>Qantidade de Empresas por Plano</h5>
                <canvas class="my-4 w-100" id="myChart2" width="900" height="380"></canvas>
            </div>
        </div>
        <div class="row">
            <h2>Últimos Planos</h2>
            <div class="table-responsive">
                <asp:GridView ID="grdEmpresasPlanos" CssClass="table" GridLines="None" runat="server"></asp:GridView>    
            </div>
        </div>
    </div>
    
    <script type="text/javascript">
        nomesPlanos = <%= jsSerializer.Serialize(nomesPlanos) %>;
        qtdPlanos = <%= jsSerializer.Serialize(qtdPlanos) %>;
        vlrTotalPlanos = <%= jsSerializer.Serialize(vlrTotalPorPlano) %>;
        cores = <%= jsSerializer.Serialize(cores) %>;
    </script>
</asp:Content>
