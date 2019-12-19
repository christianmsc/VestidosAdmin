using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.ViewModels
{
    public class UsuarioResposta
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public DateTime dataNascimento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string foto { get; set; }

    }
}