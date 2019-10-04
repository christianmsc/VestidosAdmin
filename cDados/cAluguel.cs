using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace cDados
{
    public class cAluguel
    {
        public int Id { get; set; }
        public int IdUsuarioAlugou { get; set; }
        public int IdVestido { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public float PrecoFinal { get; set; }
        public bool Ativo { get; set; }
        public bool Entregue { get; set; }
        
        public List<cAluguel> Listar(string condicao = null)
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = condicao == null ? "SELECT * FROM Aluguel" : "SELECT * FROM Aluguel WHERE " + condicao;
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            List<cAluguel> alugueis = new List<cAluguel>();
            while (registro.Read())
            {
                alugueis.Add(new cAluguel()
                {
                    Id = Convert.ToInt32(registro["id"]),
                    IdUsuarioAlugou = Convert.ToInt32(registro["id_usuario_alugou"]),
                    IdVestido = Convert.ToInt32(registro["id_vestido"]),
                    DataInicio = Convert.ToDateTime(registro["data_inicio"].ToString()),
                    DataFim = Convert.ToDateTime(registro["data_fim"].ToString()),
                    PrecoFinal = float.Parse(registro["preco_final"].ToString(), CultureInfo.InvariantCulture),
                    Ativo = Boolean.Parse(registro["ativo"].ToString()),
                    Entregue = Boolean.Parse(registro["entregue"].ToString())
                });
            }
            con.Close();
            return alugueis;
        }

        public cAluguel Abrir(int id, string condicao = null)
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = condicao == null ? "SELECT * FROM Aluguel WHERE id = " + id : "SELECT * FROM Aluguel WHERE id = " + id + " AND " + condicao;
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            cAluguel aluguel = null;
            registro.Read();
            if (registro.HasRows)
            {
                aluguel = new cAluguel()
                {
                    Id = Convert.ToInt32(registro["id"]),
                    IdUsuarioAlugou = Convert.ToInt32(registro["id_usuario_alugou"]),
                    IdVestido = Convert.ToInt32(registro["id_vestido"]),
                    DataInicio = Convert.ToDateTime(registro["data_inicio"].ToString()),
                    DataFim = Convert.ToDateTime(registro["data_fim"].ToString()),
                    PrecoFinal = float.Parse(registro["preco_final"].ToString(), CultureInfo.InvariantCulture),
                    Ativo = Boolean.Parse(registro["ativo"].ToString()),
                    Entregue = Boolean.Parse(registro["entregue"].ToString())
                };
            }
            con.Close();
            return aluguel;
        }
    }
}