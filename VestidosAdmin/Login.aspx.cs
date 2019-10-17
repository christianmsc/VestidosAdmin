using cDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VestidosAdmin
{
    public partial class Login : System.Web.UI.Page
    {
        cUsuario usuario = new cUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["idUsuario"] != null)
            {
                Response.Redirect("Default.aspx");
            }
            else if (Request.Cookies["idUsuario"] != null)
            {
                Session["idUsuario"] = Request.Cookies["idUsuario"].Value;
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            int? idUsuario = usuario.Logar(txbEmail.Text, txbSenha.Text);
            if (idUsuario != null)
            {
               
                Session["idUsuario"] = idUsuario;
                Session.Timeout = 1;

                if (ckb1.Checked)
                {
                    Response.Cookies.Add(new HttpCookie("idUsuario", idUsuario.ToString()));
                }

                Response.Redirect("Default.aspx");

            }
            else
            {
                Response.Write("<script>alert('amig@, e-mail ou senha são inválidos! =(')</script>");
            }
        }
    }
}