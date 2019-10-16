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

        public int FormType;

        protected void Page_Load(object sender, EventArgs e)
        {
            FormType = Convert.ToInt32(Request.Params["FormType"]);

            if (FormType == 2)
            {
                objEmpresa = objEmpresa.Abrir(Convert.ToInt32(Request.QueryString["id"]));
                objLogradouro = objLogradouro.Abrir(objEmpresa.IdLogradouro);
                if (objEmpresa.IdFoto != null)
                {
                    objFoto = objFoto.Abrir((int)objEmpresa.IdFoto);
                }

                if (!IsPostBack)
                {
                    if (objEmpresa != null)
                    {
                        txbNome.Text = objEmpresa.Nome;
                        txbCnpj.Text = objEmpresa.Cnpj;
                        txbTelefone.Text = objEmpresa.Telefone;
                        txbEmailEmpresa.Text = objEmpresa.Email;
                        txbLogin.Text = objEmpresa.Login;
                        txbSenhaEmpresa.Text = objEmpresa.Senha;

                    }

                    if (objLogradouro != null)
                    {
                        txbRua.Text = objLogradouro.Rua;
                        txbNumero.Text = objLogradouro.Numero;
                        txbComplemento.Text = objLogradouro.Complemento;
                        txbBairro.Text = objLogradouro.Bairro;
                        txbCidade.Text = objLogradouro.Cidade;
                        txbEstado.Text = objLogradouro.Estado;
                        txbCep.Text = objLogradouro.Cep;
                    }
                }
            }

            DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                objEmpresa.Nome = txbNome.Text;
                objEmpresa.Cnpj = txbCnpj.Text;
                objEmpresa.Telefone = txbTelefone.Text;
                objEmpresa.Email = txbEmailEmpresa.Text;
                objEmpresa.Login = txbLogin.Text;
                objEmpresa.Senha = txbSenhaEmpresa.Text;

                objLogradouro.Rua = txbRua.Text;
                objLogradouro.Numero = txbNumero.Text;
                objLogradouro.Complemento = txbComplemento.Text;
                objLogradouro.Bairro = txbBairro.Text;
                objLogradouro.Cidade = txbCidade.Text;
                objLogradouro.Estado = txbEstado.Text;
                objLogradouro.Cep = txbCep.Text;

                if (fuFoto.PostedFile.FileName != String.Empty)
                {
                    objFoto.Nome = DateTime.Now.Ticks.ToString() + "-" + fuFoto.PostedFile.FileName;
                }

                if (FormType == 1)
                {
                    objLogradouro = objLogradouro.Inserir(objLogradouro);
                    objEmpresa.IdLogradouro = objLogradouro.Id;

                    if (objFoto.Nome != null && objFoto.Nome != String.Empty)
                    {
                        objFoto = objFoto.Inserir(objFoto);
                        objEmpresa.IdFoto = objFoto.Id;
                        fuFoto.PostedFile.SaveAs(Server.MapPath(@"fotos/") + objFoto.Nome);
                    }

                    objEmpresa.Inserir(objEmpresa);

                    Response.Write("<script>alert('Empresa cadastrada com sucesso!');</script>");
                }
                else if (FormType == 2)
                {
                    objLogradouro.Alterar(objLogradouro);

                    if (objFoto.Id > 0)
                    {
                        objFoto.Alterar(objFoto);
                        if (fuFoto.PostedFile.FileName != String.Empty)
                        {
                            fuFoto.PostedFile.SaveAs(Server.MapPath(@"fotos/") + objFoto.Nome);
                        }
                    }
                    else if (objFoto.Nome != null && objFoto.Nome != String.Empty)
                    {
                        objFoto = objFoto.Inserir(objFoto);
                        objEmpresa.IdFoto = objFoto.Id;
                        fuFoto.PostedFile.SaveAs(Server.MapPath(@"fotos/") + objFoto.Nome);
                    }

                    objEmpresa.Alterar(objEmpresa);

                    Response.Write("<script>alert('Empresa atualizada com sucesso!');</script>");
                }

                Response.Redirect("Empresas.aspx");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}