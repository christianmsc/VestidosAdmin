using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace cDados
{
    public class cEmpresa
    {
        #region INFOS

        private SqlConnection connection;
        private const string TABELA = "Empresa";

        #endregion

        #region ATRIBUTOS

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int? IdFoto { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int IdLogradouro { get; set; }
        public int? IdPlano { get; set; }

        #endregion

        #region CONSTRUTOR

        public cEmpresa()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = connString.ToString();
        }

        #endregion

        #region LISTAR

        public List<cEmpresa> Listar(string condicao = null)
        {
            List<cEmpresa> empresas;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = condicao == null ? "SELECT * FROM " + TABELA : "SELECT * FROM " + TABELA + " WHERE " + condicao;
            try
            {
                empresas = new List<cEmpresa>();
                connection.Open();
                SqlDataReader registro = cmd.ExecuteReader();

                while (registro.Read())
                {
                    empresas.Add(new cEmpresa()
                    {
                        Id = Convert.ToInt32(registro["id"]),
                        Nome = registro["nome"].ToString(),
                        Cnpj = registro["cnpj"].ToString(),
                        Telefone = registro["telefone"].ToString(),
                        Email = registro["email"].ToString(),
                        IdFoto = registro["idFoto"] != System.DBNull.Value ? (int?)Convert.ToInt32(registro["idFoto"]) : null,
                        Login = registro["login"].ToString(),
                        Senha = registro["senha"].ToString(),
                        IdLogradouro = Convert.ToInt32(registro["idLogradouro"].ToString()),
                        IdPlano = registro["idPlano"] != System.DBNull.Value ? (int?) Convert.ToInt32(registro["idPlano"]) : null
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return empresas;
        }

        #endregion

        #region ABRIR

        public cEmpresa Abrir(int id, string condicao = null)
        {
            cEmpresa empresa;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = condicao == null ? "SELECT * FROM " + TABELA + " WHERE id = " + id : "SELECT * FROM " + TABELA + " WHERE id = " + id + " AND " + condicao;
            try
            {
                connection.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                empresa = null;
                registro.Read();
                if (registro.HasRows)
                {
                    empresa = new cEmpresa()
                    {
                        Id = Convert.ToInt32(registro["id"]),
                        Nome = registro["nome"].ToString(),
                        Cnpj = registro["cnpj"].ToString(),
                        Telefone = registro["telefone"].ToString(),
                        Email = registro["email"].ToString(),
                        IdFoto = registro["idFoto"] != System.DBNull.Value ? (int?)Convert.ToInt32(registro["idFoto"]) : null,
                        Login = registro["login"].ToString(),
                        Senha = registro["senha"].ToString(),
                        IdLogradouro = Convert.ToInt32(registro["idLogradouro"].ToString()),
                        IdPlano = registro["idPlano"] != System.DBNull.Value ? (int?)Convert.ToInt32(registro["idPlano"]) : null
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return empresa;
        }

        #endregion

        #region INSERIR

        public cEmpresa Inserir(cEmpresa obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO " + TABELA + "(nome,cnpj,telefone,email,idFoto,login,senha,idLogradouro,idPlano) VALUES (@nome,@cnpj,@telefone,@email,@idFoto,@login,@senha,@idLogradouro,@idPlano)";
            cmd.Parameters.AddWithValue("nome", obj.Nome);
            cmd.Parameters.AddWithValue("cnpj", obj.Cnpj);
            cmd.Parameters.AddWithValue("telefone", (object)obj.Telefone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("email", (object)obj.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("idFoto", (object)obj.IdFoto ?? DBNull.Value);
            cmd.Parameters.AddWithValue("login", obj.Login);
            cmd.Parameters.AddWithValue("senha", obj.Senha);
            cmd.Parameters.AddWithValue("idLogradouro", obj.IdLogradouro);
            cmd.Parameters.AddWithValue("idPlano", (object)obj.IdPlano ?? DBNull.Value);

            try
            {
                connection.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                connection.Close();
            }

            return obj;
        }

        #endregion

        #region ALTERAR

        public void Alterar(cEmpresa obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "UPDATE " + TABELA + " SET nome=@nome,cnpj=@cnpj,telefone=@telefone,email=@email,idFoto=@idFoto,login=@login,senha=@senha,idLogradouro=@idLogradouro,idPlano=@idPlano WHERE id = @id;";
            cmd.Parameters.AddWithValue("id", obj.Id);
            cmd.Parameters.AddWithValue("nome", obj.Nome);
            cmd.Parameters.AddWithValue("cnpj", obj.Cnpj);
            cmd.Parameters.AddWithValue("telefone", (object)obj.Telefone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("email", (object)obj.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("idFoto", (object)obj.IdFoto ?? DBNull.Value);
            cmd.Parameters.AddWithValue("login", obj.Login);
            cmd.Parameters.AddWithValue("senha", obj.Senha);
            cmd.Parameters.AddWithValue("idLogradouro", obj.IdLogradouro);
            cmd.Parameters.AddWithValue("idPlano", (object)obj.IdPlano ?? DBNull.Value);

            try
            { 
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion

        #region EXCLUIR

        public void Excluir(int cod)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "DELETE from " + TABELA + " WHERE id = " + cod.ToString();

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion

        #region OUTROS

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

        #endregion
    }
}