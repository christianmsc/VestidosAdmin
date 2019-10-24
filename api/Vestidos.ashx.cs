using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cDados;
using System.Web.Script.Serialization;
using api.ViewModels;

namespace api
{
    /// <summary>
    /// Listar um ou mais vestidos
    /// </summary>
    public class Vestidos : IHttpHandler
    {
        private cVestido objVestido = new cVestido();
        private cFoto objFoto = new cFoto();
        private string mensagem = null;
        private string productionUrl = "http://ameiseuvestido.gear.host/";

        public void ProcessRequest(HttpContext context)
        {

            JavaScriptSerializer json = new JavaScriptSerializer();
            List<cVestido> vestidos = null;
            VestidosResposta vestidoResposta = null;
            List<VestidosResposta> vestidosResposta = null;

            string idVestido = context.Request.Params["id"];
            string offset = context.Request.Params["offset"];
            string results = context.Request.Params["results"];

            try
            {
                if (!string.IsNullOrWhiteSpace(idVestido))
                {
                    objVestido = objVestido.Abrir(Convert.ToInt32(idVestido));

                    if (objVestido == null)
                    {
                        throw new Exception("Vestido não encontrado.");
                    }

                    string[] fotos = objVestido.Fotos.Split(';');
                    List<string> urlFotos = new List<string>();

                    foreach (string foto in fotos)
                    {
                        objFoto = objFoto.Abrir(Convert.ToInt32(foto));
                        if (objFoto != null)
                        {
                            urlFotos.Add(productionUrl + "fotos/" + objFoto.Nome);
                        }
                    }

                    vestidoResposta = new VestidosResposta
                    {
                        id = objVestido.Id,
                        nome = objVestido.Nome,
                        descricao = objVestido.Descricao,
                        tamanho = objVestido.Tamanho,
                        preco = objVestido.Preco,
                        fotos = urlFotos
                    };

                }
                else
                {
                    if(offset != null && results != null)
                    {
                        vestidos = objVestido.ListarPaginacao(offset, results);
                    }
                    else
                    {
                        vestidos = objVestido.Listar();
                    }

                    if (vestidos == null)
                    {
                        throw new Exception("Nenhum vestido encontrado.");
                    }

                    foreach (cVestido vestido in vestidos)
                    {
                        string[] fotos = vestido.Fotos.Split(';');
                        List<string> urlFotos = new List<string>();

                        foreach (string foto in fotos)
                        {
                            objFoto = objFoto.Abrir(Convert.ToInt32(foto));
                            if (objFoto != null)
                            {
                                urlFotos.Add(productionUrl + "fotos/" + objFoto.Nome);
                            }
                        }

                        if (vestidosResposta == null)
                        {
                            vestidosResposta = new List<VestidosResposta>();
                        }

                        vestidosResposta.Add(
                            new VestidosResposta
                            {
                                id = vestido.Id,
                                nome = vestido.Nome,
                                descricao = vestido.Descricao,
                                tamanho = vestido.Tamanho,
                                preco = vestido.Preco,
                                fotos = urlFotos
                            }
                        );
                    }
                }

            }
            catch (Exception ex)
            {
                mensagem = ex.Message;
            }

            context.Response.ContentType = "text/json";
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            if (!string.IsNullOrWhiteSpace(idVestido) && vestidoResposta != null)
            {
                mensagem = "Vestido encontrado!";
                context.Response.Write(json.Serialize(
                    new
                    {
                        sucesso = true,
                        mensagem,
                        vestido = vestidoResposta
                    })
                );
            }
            else if (vestidosResposta != null)
            {
                mensagem = "Vestidos encontrados!";
                context.Response.Write(json.Serialize(
                    new
                    {
                        sucesso = true,
                        mensagem,
                        vestidos = vestidosResposta
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