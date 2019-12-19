using FotoUpload.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FotoUpload.Controllers
{
    [RoutePrefix("api/foto")]
    public class FotoController : ApiController
    {

        [HttpPost]
        [Route("add")]
        public object Post(Foto foto)
        {
            try
            {
                byte[] fotoUsuario = Base64ToImage(foto.base64);
                string nomeFoto, relativePath, absolutePath;
                do
                {
                    nomeFoto = GerarToken() + ".jpg";
                    relativePath = "~/Fotos/" + nomeFoto;
                    absolutePath = HttpContext.Current.Server.MapPath(relativePath);
                }
                while (File.Exists(absolutePath));

                File.WriteAllBytes(absolutePath, fotoUsuario);

                return new { sucesso = true, mensagem = "Foto adicionada com sucesso!", nomeFoto };
            }
            catch(Exception ex)
            {
                return new { sucesso = true, mensagem = ex.Message };
            }
        }

        [HttpDelete]
        [Route("deletar")]
        public string Delete()
        {
            return "1";
        }

        private byte[] Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            return imageBytes;
        }

        private string GerarToken()
        {
            string caracteresPermitidos = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
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
