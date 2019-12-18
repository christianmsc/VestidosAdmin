using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.ViewModels
{
    public class LoginRequest
    {

        public string Email { get; set; }
        public string Senha { get; set; }
    }
}