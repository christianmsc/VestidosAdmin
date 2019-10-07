using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using cDados;

namespace VestidosAdmin
{
    public partial class Alugueis : System.Web.UI.Page
    {
        cAluguel objAluguel = new cAluguel();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<cAluguel> alugueis = objAluguel.Listar();
            
            if(alugueis.Count > 0)
            {
                gvAlugueis.DataSource = alugueis;
                gvAlugueis.DataBind();
                gvAlugueis.Visible = true;

            }
            else
            {
                lblSemRegistro.Visible = true;
            }
        }

        protected void gvAlugueis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Cliente";
                e.Row.Cells[2].Text = "Vestido";
                e.Row.Cells[3].Text = "Início Aluguel";
                e.Row.Cells[4].Text = "Fim Aluguel";
                e.Row.Cells[5].Text = "Valor";
            }
        }
    }
}