using cDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VestidosAdmin
{
    public partial class Default : System.Web.UI.Page
    {
        public cEmpresa objEmpresa = new cEmpresa();
        public cPlano objPlano = new cPlano();
        public JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

        public string[] nomesPlanos;
        public int[] qtdPlanos;
        public float[] vlrTotalPorPlano;
        public string[] cores;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Pega o nome de todos os planos cadastrados
            nomesPlanos = objPlano.Listar().Select(p => p.Nome).ToArray();

            // Pega todos os usuários que tiverem planos
            DataTable usuariosPlanos = objEmpresa.ListarComPlanos();
            
            // Map para armazenar o valor total por cada tipo de plano
            Dictionary<string, float> socorro = new Dictionary<string, float>();

            // Map para armazenar a quantidade de empresas por plano
            Dictionary<string, int> euQueroMinhaMae = new Dictionary<string, int>();
            
            // Define as keys do map como os nomes dos planos
            for (int i = 0; i < nomesPlanos.Length; i++)
            {
                socorro.Add(nomesPlanos[i], 0);
                euQueroMinhaMae.Add(nomesPlanos[i], 0);
            }
            
            // Para cada plano aderido, adiciona o valor e a quantidade de recorrências
            foreach (DataRow usuarioPlano in usuariosPlanos.Rows)
            {
                string nome = usuarioPlano["Plano"].ToString();
                float valor = float.Parse(usuarioPlano["Valor"].ToString());
                if (socorro.ContainsKey(nome))
                {
                    socorro[nome] += valor;
                    euQueroMinhaMae[nome] += 1;
                }
            }

            qtdPlanos = euQueroMinhaMae.Values.ToArray();
            vlrTotalPorPlano = socorro.Values.ToArray();
            grdEmpresasPlanos.DataSource = usuariosPlanos;
            cores = gerarCoresAleatorias(nomesPlanos.Length);

            DataBind();
        }

        private string[] gerarCoresAleatorias(int qtd)
        {
            Random rnd = new Random();
            List<string> cores = new List<string>();
            for (int i = 0; i < qtd; i++)
            {
                cores.Add($"rgb({rnd.Next(0,255)}, {rnd.Next(0, 255)}, {rnd.Next(0, 255)})");
            }
            return cores.ToArray();
        }
    }
}