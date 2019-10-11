using cDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VestidosAdmin
{
    public partial class Empresas : System.Web.UI.Page
    {
        cEmpresa objEmpresa = new cEmpresa();

        protected void Page_Load(object sender, EventArgs e)
        {
            grdEmpresas.DataSource = objEmpresa.Listar();
            grdEmpresas.DataBind();
        }

        protected void grdEmpresas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Text = "CNPJ";
                e.Row.Cells[4].Text = "E-mail";
                e.Row.Cells[8].Text = "Logradouro";
                e.Row.Cells[9].Text = "Plano";
            }
        }
    }
}