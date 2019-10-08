using cDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VestidosAdmin
{
    public partial class Usuario : System.Web.UI.Page
    {
        public cUsuario objUsuario = new cUsuario();
        public bool temFoto;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUsuario = objUsuario.Abrir(Convert.ToInt32(Request.Params["id"]));

            temFoto = System.IO.File.Exists(Server.MapPath("/img/" + objUsuario.Foto));
            DataBind();
        }
    }
}