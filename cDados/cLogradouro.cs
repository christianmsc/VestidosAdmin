using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace cDados
{
    public class cLogradouro
    {
        #region INFOS

        private SqlConnection connection;
        private const string TABELA = "Logradouro";

        #endregion

        public int Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }


        public cLogradouro()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = connString.ToString();
        }

        public List<cLogradouro> Listar(string condicao = null)
        {
            List<cLogradouro> logradouros
                ;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = condicao == null ? "SELECT * FROM " + TABELA : "SELECT * FROM " + TABELA + " WHERE " + condicao;
            try
            {
                logradouros = new List<cLogradouro>();
                connection.Open();
                SqlDataReader registro = cmd.ExecuteReader();

                while (registro.Read())
                {
                    logradouros.Add(new cLogradouro()
                    {
                        Id = Convert.ToInt32(registro["id"]),
                        Rua = registro["rua"].ToString(),
                        Numero = registro["numero"].ToString(),
                        Complemento = registro["complemento"].ToString(),
                        Bairro =registro["bairro"].ToString(),
                        Cidade = registro["cidade"].ToString(),
                        Estado = registro["estado"].ToString(),
                        Cep = registro["cep"].ToString()
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

            return logradouros;
        }

        public cLogradouro Abrir(int id, string condicao = null)
        {
            cLogradouro logradouro;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = condicao == null ? "SELECT * FROM " + TABELA + " WHERE id = " + id : "SELECT * FROM " + TABELA + " WHERE id = " + id + " AND " + condicao;
            try
            {
                connection.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                logradouro = null;
                registro.Read();
                if (registro.HasRows)
                {
                    logradouro = new cLogradouro()
                    {
                        Id = Convert.ToInt32(registro["id"]),
                        Rua = registro["rua"].ToString(),
                        Numero = registro["numero"].ToString(),
                        Complemento = registro["complemento"].ToString(),
                        Bairro = registro["bairro"].ToString(),
                        Cidade = registro["cidade"].ToString(),
                        Estado = registro["estado"].ToString(),
                        Cep = registro["cep"].ToString()
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

            return logradouro;
        }

        public cLogradouro Inserir(cLogradouro obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO " + TABELA + "(rua,numero,complemento,bairro,cidade,estado,cep) VALUES (@rua,@numero,@complemento,@bairro,@cidade,@estado,@cep);select @@IDENTITY;";
            cmd.Parameters.AddWithValue("rua", obj.Rua);
            cmd.Parameters.AddWithValue("numero", obj.Numero);
            cmd.Parameters.AddWithValue("complemento", obj.Complemento);
            cmd.Parameters.AddWithValue("bairro", obj.Bairro);
            cmd.Parameters.AddWithValue("cidade", obj.Cidade);
            cmd.Parameters.AddWithValue("estado", obj.Estado);
            cmd.Parameters.AddWithValue("cep", obj.Cep);

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

        public void Alterar(cLogradouro obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "UPDATE " + TABELA + " SET rua=@rua,numero=@numero,complemento=@complemento,bairro=@bairro,cidade=@cidade,estado=@estado,cep=@cep WHERE id = @id;";
            cmd.Parameters.AddWithValue("id", obj.Id);
            cmd.Parameters.AddWithValue("rua", obj.Rua);
            cmd.Parameters.AddWithValue("numero", obj.Numero);
            cmd.Parameters.AddWithValue("complemento", obj.Complemento);
            cmd.Parameters.AddWithValue("bairro", obj.Bairro);
            cmd.Parameters.AddWithValue("cidade", obj.Cidade);
            cmd.Parameters.AddWithValue("estado", obj.Estado);
            cmd.Parameters.AddWithValue("cep", obj.Cep);

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