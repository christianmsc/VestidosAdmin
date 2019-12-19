using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cDados;
using System.Web.Script.Serialization;
using api.ViewModels;
using System.Configuration;

namespace api
{
    /// <summary>
    /// Obter dados de um usuário
    /// </summary>
    public class Usuario : IHttpHandler
    {
        private cUsuario objUsuario = new cUsuario();
        private string mensagem = null;
        private string productionUrl = ConfigurationManager.AppSettings["productionUrl"].ToString();

        public void ProcessRequest(HttpContext context)
        {

            JavaScriptSerializer json = new JavaScriptSerializer();
            UsuarioResposta usuarioResposta = null;

            string idUsuario = context.Request.Params["id"];

            try
            {
                if (string.IsNullOrWhiteSpace(idUsuario))
                {
                    throw new Exception("Parâmetro não informado.");
                }
                else
                {
                    objUsuario = objUsuario.Abrir(Convert.ToInt32(idUsuario));

                    if (objUsuario == null)
                    {
                        throw new Exception("Usuário não encontrado.");
                    }


                    // recuperar a foto do usuario, se houver
                    string fotoUsuario = null;
                    if (objUsuario.IdFoto != null)
                    {
                        cFoto objFotoUsuario = new cFoto().Abrir((int)objUsuario.IdFoto);
                        fotoUsuario = productionUrl + "fotos/" + objFotoUsuario.Nome;
                    }


                    usuarioResposta = new UsuarioResposta
                    {
                        nome = objUsuario.Nome,
                        cpf = objUsuario.Cpf,
                        dataNascimento = objUsuario.DataNascimento,
                        telefone = objUsuario.Telefone,
                        email = objUsuario.Email,
                        foto = fotoUsuario
                    };

                }

            }

            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            context.Response.ContentType = "application/json";

            if (usuarioResposta != null)
            {
                mensagem = "Usuário encontrado!";
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(
                    new
                    {
                        sucesso = true,
                        mensagem,
                        usuario = usuarioResposta
                    })
                );
            }
            else
            {
                context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(new { sucesso = false, mensagem }));
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