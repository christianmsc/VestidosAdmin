using cDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VestidosAdmin
{
    public partial class Empresa : System.Web.UI.Page
    {
        public cEmpresa objEmpresa = new cEmpresa();
        public bool temFoto;
        public int FormType;

        protected void Page_Load(object sender, EventArgs e)
        {
            FormType = Convert.ToInt32(Request.Params["FormType"]);

            if (FormType == 2)
            {
                objEmpresa = objEmpresa.Abrir(Convert.ToInt32(Request.QueryString["id"]));
                if(objEmpresa != null)
                {
                    txbNome.Text = objEmpresa.Nome;
                    txbCnpj.Text = objEmpresa.Cnpj;
                    txbTelefone.Text = objEmpresa.Telefone;
                    txbEmail.Text = objEmpresa.Email;
                    txbLogin.Text = objEmpresa.Login;
                    txbSenha.Text = objEmpresa.Senha;
                }
            }

            DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            cEmpresa empresa = new cEmpresa();
            empresa.Id = new Random().Next();
            empresa.Nome = txbNome.Text;
            empresa.Cnpj = txbCnpj.Text;
            empresa.Telefone = txbTelefone.Text;
            empresa.Email = txbEmail.Text;
            empresa.Foto = "foto1.png";
            empresa.Login = txbLogin.Text;
            empresa.Senha = txbSenha.Text;
            empresa.IdLogradouro = 1;
            empresa.IdPlano = 1;

            if(FormType == 1)
            {
                empresa.Inserir(empresa);
            }
            else if(FormType == 2)
            {
                empresa.Alterar(objEmpresa);
            }

            Response.Redirect("Empresas.aspx");
        }
    }
}