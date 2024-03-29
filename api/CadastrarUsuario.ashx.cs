﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cDados;
using System.Web.Script.Serialization;
using api.ViewModels;
using System.Drawing;
using System.IO;
using System.Configuration;

namespace api
{
    /// <summary>
    /// Cadastrar usuário do APP
    /// </summary>
    public class CadastrarUsuario : IHttpHandler
    {
        private cUsuario objUsuario = new cUsuario();
        private cLogradouro objLogradouro = new cLogradouro();
        private cFoto objFoto = new cFoto();
        private string mensagem = null;

        public void ProcessRequest(HttpContext context)
         {
            JavaScriptSerializer json = new JavaScriptSerializer();

            var novoUsuario = context.Request.Form["jsonUsuario"];
            int? usuarioId = null;

            try
            {
                if (string.IsNullOrWhiteSpace(novoUsuario))
                    throw new Exception("Parâmetro não informado");

                NovoUsuario usuario = json.Deserialize<NovoUsuario>(novoUsuario);

                objLogradouro.Rua = usuario.Rua;
                objLogradouro.Numero = usuario.Numero;
                objLogradouro.Complemento = usuario.Complemento;
                objLogradouro.Bairro = usuario.Bairro;
                objLogradouro.Cidade = usuario.Numero;
                objLogradouro.Estado = usuario.Numero;
                objLogradouro.Cep = usuario.Cep;

                objLogradouro = objLogradouro.Inserir(objLogradouro);

                if(objLogradouro.Id <= 0)
                {
                    throw new Exception("erro ao salvar o endereço =(");
                }

                objUsuario.Nome = usuario.Nome;
                objUsuario.Cpf = usuario.Cpf;
                objUsuario.DataNascimento = usuario.DataNascimento;
                objUsuario.Telefone = usuario.Telefone;
                objUsuario.Email = usuario.Email;
                objUsuario.Senha = usuario.Senha;
                objUsuario.IdLogradouro = objLogradouro.Id;
                
                if (!string.IsNullOrWhiteSpace(usuario.Foto)){
                    objFoto.Nome = usuario.Foto;
                    objFoto = objFoto.Inserir(objFoto);
                    objUsuario.IdFoto = objFoto.Id;
                }

                objUsuario = objUsuario.Inserir(objUsuario);

                if (objUsuario.Id <= 0)
                {
                    objLogradouro.Excluir(objLogradouro.Id);
                    throw new Exception("erro ao salvar o usuario =(");
                }
                else
                {
                    usuarioId = objUsuario.Id;
                }

            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            context.Response.ContentType = "text/json";

            if (usuarioId != null)
            {
                mensagem = "Logado com sucesso!";
                context.Response.Write(json.Serialize(
                    new
                    {
                        sucesso = true,
                        mensagem,
                        id = usuarioId
                    })
                );
            }
            else
            {
                context.Response.Write(json.Serialize(new { sucesso = false, mensagem }));
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        
    }
}