using cDados;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VestidosAdmin
{
    public partial class Vestidos : System.Web.UI.Page
    {
        cVestido objVestido = new cVestido();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvVestidos.DataSource = objVestido.Listar();
            gvVestidos.DataBind();
        }

        protected void gvVestidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvVestidos, "Select$" + e.Row.RowIndex);
                e.Row.Attributes["style"] = "cursor:pointer";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Dono";
                e.Row.Cells[4].Text = "Descrição";
                e.Row.Cells[5].Text = "Preço";
                e.Row.Cells[7].Text = "Relevância";
                e.Row.Cells[8].Text = "Notificação";
            }
        }

        protected void gvVestidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("Vestido.aspx?id=" + gvVestidos.SelectedRow.Cells[0].Text);
        }
    }
}