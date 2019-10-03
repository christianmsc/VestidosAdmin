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
    }
}