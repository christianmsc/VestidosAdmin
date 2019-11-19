using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.ViewModels
{
    public class VestidosResposta
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string tamanho { get; set; }
        public string descricao { get; set; }
        public float preco { get; set; }
        public List<string> fotos { get; set; }
        public string nomeEmpresa { get; set; }
        public string fotoEmpresa { get; set; }
        public string  enderecoEmpresa { get; set; }
        public string nomeUsuario { get; set; }
        public string fotoUsuario { get; set; }
    }
}