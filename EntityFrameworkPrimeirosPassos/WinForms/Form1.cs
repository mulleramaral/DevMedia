using Data;
using Domain;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinForms
{
    public partial class Form1 : Form
    {
        private Contexto contexto;

        public Form1()
        {
            InitializeComponent();
            contexto = new Contexto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loja = new Loja
            {
                Nome = "MCA Papelaria",
                Descricao = "Papela do muller",
            };
            contexto.Lojas.Add(loja);

            var produto = new Produto
            {
                Nome = "Caneta Bic",
                Descricao = "Caneta Bic azul",
                Valor = 1.20m,
                Loja = loja
            };
            contexto.Produtos.Add(produto);
            contexto.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var loja = contexto.Lojas.Find(1);
            var novoProduto = new Produto
            {
                Nome = "Lapis",
                Descricao = "Lapis colorido 12 cores",
                Valor = 32.21m,
                LojaId = loja.Id
            };
            contexto.Produtos.Add(novoProduto);
            contexto.SaveChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var produto = contexto.Produtos.Find(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var produtosIniciadosEmC = contexto.Produtos.Where(p => p.Nome.StartsWith("C")).ToList();
            var produtosDaLoja1 = contexto.Produtos.Where(p => p.LojaId == 1).ToList();

            var produtosDaLoja1test = contexto.Lojas.Find(1).Produtos;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var loja = contexto.Lojas.Find(1);
            loja.Nome = "Nome alterado";
            contexto.SaveChanges();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //var produto = contexto.Produtos.Find(1);
            //contexto.Produtos.Remove(produto);

            var loja = contexto.Lojas.Find(1);
            contexto.Lojas.Remove(loja);
            contexto.SaveChanges();
        }
    }
}
