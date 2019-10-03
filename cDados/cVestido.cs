using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace cDados
{
    public class cVestido
    {
        public int Id { get; set; }
        public int IdUsuarioDono { get; set; }
        public string Nome { get; set; }
        public string Tamanho { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public string Fotos { get; set; }
        public bool Relevancia { get; set; }
        public bool Notificacao { get; set; }

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
                    IdUsuarioDono = Convert.ToInt32(registro["id_usuario_dono"]),
                    Nome = registro["nome"].ToString(),
                    Tamanho = registro["tamanho"].ToString(),
                    Descricao = registro["descricao"].ToString(),
                    Preco = float.Parse(registro["preco"].ToString()),
                    Fotos = registro["fotos"].ToString(),
                    Relevancia = Boolean.Parse(registro["relevancia"].ToString()),
                    Notificacao = Boolean.Parse(registro["notificacao"].ToString())
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
                    IdUsuarioDono = Convert.ToInt32(registro["id_usuario_dono"]),
                    Nome = registro["nome"].ToString(),
                    Tamanho = registro["tamanho"].ToString(),
                    Descricao = registro["descricao"].ToString(),
                    Preco = float.Parse(registro["preco"].ToString()),
                    Fotos = registro["fotos"].ToString(),
                    Relevancia = Boolean.Parse(registro["relevancia"].ToString()),
                    Notificacao = Boolean.Parse(registro["notificacao"].ToString())
                };
            }
            con.Close();
            return vestido;
        }
    }
}