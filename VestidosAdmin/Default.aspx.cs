using cDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VestidosAdmin
{
    public partial class Default : System.Web.UI.Page
    {
        cEmpresa objEmpresa = new cEmpresa();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<cEmpresa> empresasComPlanos = objEmpresa.Listar("idPlano IS NOT NULL ORDER BY id DESC");
            grdEmpresasPlanos.DataSource = empresasComPlanos;
            DataBind();
        }
    }
}