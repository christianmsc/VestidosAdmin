using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace cDados
{
    public class cUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cidade { get; set; }

        public List<cUsuario> Listar(string condicao = null)
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = condicao == null ? "SELECT * FROM Usuario" : "SELECT * FROM Usuario WHERE " + condicao;
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            List<cUsuario> usuarios = new List<cUsuario>();
            while (registro.Read())
            {
                usuarios.Add(new cUsuario()
                {
                    Id = Convert.ToInt32(registro["id"]),
                    Nome = registro["nome"].ToString(),
                    DataNascimento = Convert.ToDateTime(registro["data_nascimento"].ToString()),
                    Cidade = registro["cidade"].ToString()
                });
            }
            con.Close();
            return usuarios;
        }

        public cUsuario Abrir(int id, string condicao = null)
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = condicao == null ? "SELECT * FROM Usuario WHERE id = " + id : "SELECT * FROM Usuario WHERE id = " + id + " AND " + condicao;
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            cUsuario usuario = null;
            registro.Read();
            if (registro.HasRows)
            {
                usuario = new cUsuario()
                {
                    Id = Convert.ToInt32(registro["id"]),
                    Nome = registro["nome"].ToString(),
                    DataNascimento = Convert.ToDateTime(registro["data_nascimento"].ToString()),
                    Cidade = registro["cidade"].ToString()
                };
            }
            con.Close();
            return usuario;
        }
    }
}