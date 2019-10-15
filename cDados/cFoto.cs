using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace cDados
{
    public class cFoto
    {
        #region INFOS

        private SqlConnection connection;
        private const string TABELA = "Foto";

        #endregion

        public int Id { get; set; }
        public string Nome { get; set; }

        public cFoto()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = connString.ToString();
        }

        public List<cFoto> Listar(string condicao = null)
        {
            List<cFoto> fotos;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = condicao == null ? "SELECT * FROM " + TABELA : "SELECT * FROM " + TABELA + " WHERE " + condicao;
            try
            {
                fotos = new List<cFoto>();
                connection.Open();
                SqlDataReader registro = cmd.ExecuteReader();

                while (registro.Read())
                {
                    fotos.Add(new cFoto()
                    {
                        Id = Convert.ToInt32(registro["id"]),
                        Nome = registro["nome"].ToString()
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

            return fotos;
        }

        public cFoto Abrir(int id, string condicao = null)
        {
            cFoto foto;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = condicao == null ? "SELECT * FROM " + TABELA + " WHERE id = " + id : "SELECT * FROM " + TABELA + " WHERE id = " + id + " AND " + condicao;
            try
            {
                connection.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                foto = null;
                registro.Read();
                if (registro.HasRows)
                {
                    foto = new cFoto()
                    {
                        Id = Convert.ToInt32(registro["id"]),
                        Nome = registro["nome"].ToString()
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

            return foto;
        }

        public cFoto Inserir(cFoto obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO " + TABELA + "(nome) VALUES (@nome);select @@IDENTITY;";
            cmd.Parameters.AddWithValue("nome", obj.Nome);

            try
            {
                connection.Open();
                obj.Id = Convert.ToInt32(cmd.ExecuteScalar());
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

        public void Alterar(cFoto obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "UPDATE " + TABELA + " SET nome=@nome WHERE id = @id;";
            cmd.Parameters.AddWithValue("id", obj.Id);
            cmd.Parameters.AddWithValue("nome", obj.Nome);

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
    }
}