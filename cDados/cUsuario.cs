using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace cDados
{
    public class cUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdLogradouro { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public int? IdFoto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

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
                    IdLogradouro = Convert.ToInt32(registro["idLogradouro"].ToString()),
                    Cpf = registro["cpf"].ToString(),
                    DataNascimento = DateTime.ParseExact(registro["dataNascimento"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Telefone = registro["telefone"].ToString(),
                    IdFoto = registro["idFoto"] != System.DBNull.Value ? (int?)Convert.ToInt32(registro["idFoto"]) : null,
                    Email = registro["email"].ToString(),
                    Senha = registro["senha"].ToString()
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
                    IdLogradouro = Convert.ToInt32(registro["idLogradouro"].ToString()),
                    Cpf = registro["cpf"].ToString(),
                    DataNascimento = DateTime.Parse(registro["dataNascimento"].ToString()),
                    Telefone = registro["telefone"].ToString(),
                    IdFoto = registro["idFoto"] != System.DBNull.Value ? (int?)Convert.ToInt32(registro["idFoto"]) : null,
                    Email = registro["email"].ToString(),
                    Senha = registro["senha"].ToString()
                };
            }
            con.Close();
            return usuario;
        }

        public int? Logar(string email, string senha)
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT id FROM Usuario WHERE email = '" + email + "' AND senha = '" + senha + "'";
            con.Open();
            SqlDataReader registro = cmd.ExecuteReader();
            int? idUsuario = null;
            registro.Read();
            if (registro.HasRows)
            {
                idUsuario = Convert.ToInt32(registro["id"]);
            }
            con.Close();
            return idUsuario;
        }
    }
}