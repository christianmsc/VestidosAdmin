﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cDados;
using System.Web.Script.Serialization;
using api.ViewModels;

namespace api
{
    /// <summary>
    /// Logar usuário do APP
    /// </summary>
    public class Login : IHttpHandler
    {
        private cUsuario objUsuario = new cUsuario();
        private string mensagem = null;
        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();

            string loginJson = context.Request.Form["login"];
            int? usuarioId = null;

            try
            {
                if (string.IsNullOrWhiteSpace(loginJson))
                    throw new Exception("Parâmetros não informados");

                LoginRequest login = json.Deserialize<LoginRequest>(loginJson);

                if ((usuarioId = objUsuario.Logar(login.Email, login.Senha)) == null)
                    throw new Exception("E-mail e/ou senha inválidos");

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

        private string GerarToken()
        {
            string caracteresPermitidos = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[21];
            Random rd = new Random();
            for (int i = 0; i < 21; i++)
            {
                if (i.Equals(10))
                {
                    chars[i] = Convert.ToChar("-");
                    i++;
                }
                chars[i] = caracteresPermitidos[rd.Next(0, caracteresPermitidos.Length)];
            }
            return new string(chars);
        }
    }
}