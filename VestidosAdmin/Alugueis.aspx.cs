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
    }
}