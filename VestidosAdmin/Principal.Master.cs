using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VestidosAdmin
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["logout"] != null && bool.Parse(Request.Params["logout"].ToString()))
            {
                Session.Clear();
                Request.Cookies.Clear();
                Response.Cookies.Clear();
            }

            if (Session["idUsuario"] == null)
            {
                if(Request.Cookies["idUsuario"] != null)
                {
                    Session["idUsuario"] = Request.Cookies["idUsuario"].Value;
                }
                else
                {
                    Response.Cookies["idUsuario"].Expires = DateTime.Now.AddMonths(-1);
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Cookies["idUsuario"].Expires = DateTime.Now.AddMonths(-1);
            Response.Redirect("Login.aspx");
        }
    }
}