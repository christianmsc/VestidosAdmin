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
        public cFoto objFoto = new cFoto();
        public cLogradouro objLogradouro = new cLogradouro();
        public bool temFoto;

        protected void Page_Load(object sender, EventArgs e)
        {
            objUsuario = objUsuario.Abrir(Convert.ToInt32(Request.Params["id"]));
            temFoto = objUsuario.IdFoto != null && (objFoto = objFoto.Abrir((int)objUsuario.IdFoto)) != null && System.IO.File.Exists(Server.MapPath("/fotos/" + objFoto.Nome));
            objLogradouro = objLogradouro.Abrir(objUsuario.IdLogradouro);
            DataBind();
        }
    }
}