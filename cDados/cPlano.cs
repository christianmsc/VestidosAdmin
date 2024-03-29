﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace cDados
{
    public class cPlano
    {
        #region INFOS

        private SqlConnection connection;
        private const string TABELA = "Plano";

        #endregion

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public int QtdMaxVestidos { get; set; }

        public cPlano()
        {
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["vestidos_para_alugarConnectionString"].ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = connString.ToString();
        }

        public List<cPlano> Listar(string condicao = null)
        {
            List<cPlano> planos;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = condicao == null ? "SELECT * FROM " + TABELA : "SELECT * FROM " + TABELA + " WHERE " + condicao;
            try
            {
                planos = new List<cPlano>();
                connection.Open();
                SqlDataReader registro = cmd.ExecuteReader();

                while (registro.Read())
                {
                    planos.Add(new cPlano()
                    {
                        Id = Convert.ToInt32(registro["id"]),
                        Nome = registro["nome"].ToString(),
                        Descricao = registro["descricao"].ToString(),
                        Valor = float.Parse(registro["valor"].ToString()),
                        QtdMaxVestidos = Convert.ToInt32(registro["qtdMaxVestidos"].ToString())
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

            return planos;
        }

        public cPlano Abrir(int id, string condicao = null)
        {
            cPlano plano;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = condicao == null ? "SELECT * FROM " + TABELA + " WHERE id = " + id : "SELECT * FROM " + TABELA + " WHERE id = " + id + " AND " + condicao;
            try
            {
                connection.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                plano = null;
                registro.Read();
                if (registro.HasRows)
                {
                    plano = new cPlano()
                    {
                        Id = Convert.ToInt32(registro["id"]),
                        Nome = registro["nome"].ToString(),
                        Descricao = registro["descricao"].ToString(),
                        Valor = float.Parse(registro["valor"].ToString()),
                        QtdMaxVestidos = Convert.ToInt32(registro["qtdMaxVestidos"].ToString())
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

            return plano;
        }

        public cPlano Inserir(cPlano obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO " + TABELA + "(nome,descricao,valor,qtdMaxVestidos) VALUES (@nome,@descricao,@valor,@qtdMaxVestidos);select @@IDENTITY;";
            cmd.Parameters.AddWithValue("nome", obj.Nome);
            cmd.Parameters.AddWithValue("descricao", obj.Descricao);
            cmd.Parameters.AddWithValue("valor", obj.Valor);
            cmd.Parameters.AddWithValue("qtdMaxVestidos", obj.QtdMaxVestidos);

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

        public void Alterar(cPlano obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "UPDATE " + TABELA + " SET nome=@nome,descricao=@descricao,valor=@valor,qtdMaxVestidos=@qtdMaxVestidos WHERE id = @id;";
            cmd.Parameters.AddWithValue("id", obj.Id);
            cmd.Parameters.AddWithValue("nome", obj.Nome);
            cmd.Parameters.AddWithValue("descricao", obj.Descricao);
            cmd.Parameters.AddWithValue("valor", obj.Valor);
            cmd.Parameters.AddWithValue("qtdMaxVestidos", obj.QtdMaxVestidos);

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