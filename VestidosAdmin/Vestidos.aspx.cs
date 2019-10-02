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
        protected void Page_Load(object sender, EventArgs e)
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * from Usuario";
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            List<Vestido> vestidos = new List<Vestido>();
            while (registro.Read())
            {
                vestidos.Add(new Vestido()
                {
                    Id = Convert.ToInt32(registro["id"]),
                    Nome = registro["nome"].ToString(),
                    DataNascimento = Convert.ToDateTime(registro["data_nascimento"].ToString()),
                    Cidade = registro["cidade"].ToString()
                });
            }
            gvVestidos.DataSource = vestidos;
            gvVestidos.DataBind();
            con.Close();

        }
    }

    public class Vestido {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cidade { get; set; }
    }
}