using cDados;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VestidosAdmin
{
    public partial class Empresa : System.Web.UI.Page
    {
        public cEmpresa objEmpresa = new cEmpresa();
        public cLogradouro objLogradouro = new cLogradouro();
        public cFoto objFoto = new cFoto();

        public bool temFoto;
        public int FormType;

        protected void Page_Load(object sender, EventArgs e)
        {
            FormType = Convert.ToInt32(Request.Params["FormType"]);

            if (FormType == 2)
            {
                objEmpresa = objEmpresa.Abrir(Convert.ToInt32(Request.QueryString["id"]));
                if (objEmpresa != null)
                {
                    txbNome.Text = objEmpresa.Nome;
                    txbCnpj.Text = objEmpresa.Cnpj;
                    txbTelefone.Text = objEmpresa.Telefone;
                    txbEmail.Text = objEmpresa.Email;
                    txbLogin.Text = objEmpresa.Login;
                    txbSenha.Text = objEmpresa.Senha;

                    objLogradouro = objLogradouro.Abrir(objEmpresa.IdLogradouro);
                    if (objLogradouro != null)
                    {
                        txbRua.Text = objLogradouro.Rua;
                        txbNumero.Text = objLogradouro.Numero;
                        txbComplemento.Text = objLogradouro.Complemento ?? String.Empty;
                        txbBairro.Text = objLogradouro.Bairro;
                        txbCidade.Text = objLogradouro.Cidade;
                        txbEstado.Text = objLogradouro.Estado;
                        txbCep.Text = objLogradouro.Cep;
                    }

                    objFoto = objFoto.Abrir((int)objEmpresa.IdFoto);
                }

            }

            DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                cEmpresa empresa = new cEmpresa();
                cFoto foto = new cFoto();
                cLogradouro logradouro = new cLogradouro();

                empresa.Id = new Random().Next();
                empresa.Nome = txbNome.Text;
                empresa.Cnpj = txbCnpj.Text;
                empresa.Telefone = txbTelefone.Text;
                empresa.Email = txbEmail.Text;
                empresa.Login = txbLogin.Text;
                empresa.Senha = txbSenha.Text;
                empresa.IdPlano = null;

                logradouro.Rua = txbRua.Text;
                logradouro.Numero = txbNumero.Text;
                logradouro.Complemento = txbComplemento.Text != String.Empty ? txbComplemento.Text : null;
                logradouro.Bairro = txbBairro.Text;
                logradouro.Cidade = txbCidade.Text;
                logradouro.Estado = txbEstado.Text;
                logradouro.Cep = txbCep.Text;

                if (FormType == 1)
                {
                    logradouro = logradouro.Inserir(logradouro);
                    empresa.IdLogradouro = logradouro.Id;
                    empresa.IdFoto = fuFoto.PostedFile.FileName != String.Empty ? (int?)foto.Inserir(foto = new cFoto() { Nome = DateTime.Now.Ticks.ToString() + fuFoto.FileName }).Id : null;
                    empresa.Inserir(empresa);
                }
                else if (FormType == 2)
                {
                    empresa.Id = objEmpresa.Id;
                    empresa.IdFoto = fuFoto.PostedFile.FileName != String.Empty ? (int?)foto.Inserir(foto = new cFoto() { Nome = DateTime.Now.Ticks.ToString() + fuFoto.FileName }).Id : null;

                    if (empresa.IdFoto != null)
                    {
                        foto.Inserir(foto);
                        fuFoto.PostedFile.SaveAs(Server.MapPath(@"fotos/") + foto.Nome);

                        if (objEmpresa.IdFoto != null)
                        {
                            foto.Excluir((int)objEmpresa.IdFoto);
                            File.Delete(Server.MapPath(@"fotos/") + objEmpresa.Nome);
                        }

                    }
                    else if (objEmpresa.IdFoto != null)
                    {
                        foto.Excluir((int)objEmpresa.IdFoto);
                        File.Delete(Server.MapPath(@"fotos/") + objEmpresa.Nome);
                    }

                    empresa.Alterar(empresa);
                }

                Response.Redirect("Empresas.aspx");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}