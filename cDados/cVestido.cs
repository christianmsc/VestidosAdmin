using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace cDados
{
    public class cVestido
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Tamanho { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Fotos { get; set; }
        public bool? Relevancia { get; set; }
        public bool? Notificacao { get; set; }

        public List<cVestido> Listar(string condicao = null)
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = condicao == null ? "SELECT * FROM Vestido" : "SELECT * FROM Vestido WHERE " + condicao;
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            List<cVestido> vestidos = new List<cVestido>();
            while (registro.Read())
            {
                vestidos.Add(new cVestido()
                {
                    Id = Convert.ToInt32(registro["id"]),
                    IdEmpresa = Convert.ToInt32(registro["idEmpresa"]),
                    IdUsuario = registro["idUsuario"] != System.DBNull.Value ? (int?)Convert.ToInt32(registro["idUsuario"]) : null,
                    Nome = registro["nome"].ToString(),
                    Tamanho = registro["tamanho"].ToString(),
                    Descricao = registro["descricao"].ToString(),
                    Preco = float.Parse(registro["preco"].ToString()),
                    Fotos = registro["fotos"].ToString(),
                    Relevancia = registro["relevancia"] != System.DBNull.Value ? (bool?)Boolean.Parse(registro["relevancia"].ToString()) : null,
                    Notificacao = registro["notificacao"] != System.DBNull.Value ? (bool?)Boolean.Parse(registro["notificacao"].ToString()) : null
                });
            }
            con.Close();
            return vestidos;
        }

        public cVestido Abrir(int id, string condicao = null)
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = condicao == null ? "SELECT * FROM Vestido WHERE id = " + id : "SELECT * FROM Vestido WHERE id = " + id + " AND " + condicao;
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            cVestido vestido = null;
            registro.Read();
            if (registro.HasRows)
            {
                vestido = new cVestido()
                {
                    Id = Convert.ToInt32(registro["id"]),
                    IdEmpresa = Convert.ToInt32(registro["idEmpresa"]),
                    IdUsuario = registro["idUsuario"] != System.DBNull.Value ? (int?)Convert.ToInt32(registro["idUsuario"]) : null,
                    Nome = registro["nome"].ToString(),
                    Tamanho = registro["tamanho"].ToString(),
                    Descricao = registro["descricao"].ToString(),
                    Preco = float.Parse(registro["preco"].ToString()),
                    Fotos = registro["fotos"].ToString(),
                    Relevancia = registro["relevancia"] != System.DBNull.Value ? (bool?)Boolean.Parse(registro["relevancia"].ToString()) : null,
                    Notificacao = registro["notificacao"] != System.DBNull.Value ? (bool?)Boolean.Parse(registro["notificacao"].ToString()) : null
                };
            }
            con.Close();
            return vestido;
        }
    }
}