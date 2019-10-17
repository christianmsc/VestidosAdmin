using cDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VestidosAdmin
{
    public partial class Vestido : System.Web.UI.Page
    {
        public cVestido objVestido = new cVestido();
        public cEmpresa objEmpresa = new cEmpresa();
        public cUsuario objUsuario = new cUsuario();
        public cFoto objFotoEmpresa = new cFoto();
        public cFoto objFotoUsuario = new cFoto();
        public cFoto objFotosVestido = new cFoto();
        public List<cFoto> fotosVestido = new List<cFoto>();

        protected void Page_Load(object sender, EventArgs e)
        {
            objVestido = objVestido.Abrir(Convert.ToInt32(Request.Params["id"]));
            objEmpresa = objEmpresa.Abrir(objVestido.IdEmpresa);
            
            if (objVestido.IdUsuario != null)
            {
                objUsuario = objUsuario.Abrir((int)objVestido.IdUsuario);
            }

            if (objEmpresa.IdFoto != null)
            {
                objFotoEmpresa = objFotoEmpresa.Abrir((int)objEmpresa.IdFoto);
            }

            if (objUsuario != null && objUsuario.IdFoto != null)
            {
                objFotoUsuario = objFotoUsuario.Abrir((int)objUsuario.IdFoto);
            }

            string[] idsFotos = objVestido.Fotos.Split(';');
            for (int i = 0; i < idsFotos.Length; i++)
            {
                objFotosVestido = objFotosVestido.Abrir(Convert.ToInt32(idsFotos[i]));
                if(objFotosVestido != null)
                {
                    fotosVestido.Add(objFotosVestido);
                }
            }

            rptFotosVestido.DataSource = fotosVestido;
            DataBind();
        }
    }
}