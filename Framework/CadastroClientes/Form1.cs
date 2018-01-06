using System;
using System.Windows.Forms;
using System.Data;

namespace CadastroClientes
{
    public partial class frmCadastroClientes : Form
    {
        public frmCadastroClientes()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            // Cria dataset, que pode ser uma coleção de tabelas
            DataSet dataSet = new DataSet("Dados");
            DataTable tabela = CriarEstruturaTabela();

            // Adiciona tabela ao dataset
            dataSet.Tables.Add(tabela);

            // Criar os registros
            DataRow registro = CriaRegistro(tabela);
            // Adiciona os registros na tabela
            tabela.Rows.Add(registro);

            // Salvando o cliente no XML
            dataSet.WriteXml(@".\cliente_" + txtCodigo.Text + ".xml");
        }

        private DataRow CriaRegistro(DataTable tabela)
        {
            DataRow registro = tabela.NewRow();
            registro["Codigo"] = txtCodigo.Text;
            registro["Nome"] = txtNome.Text;
            registro["Fone"] = txtTelefone.Text;
            registro["Email"] = txtEmail.Text;
            return registro;
        }

        private DataTable CriarEstruturaTabela()
        {
            // Cria a Tabela
            DataTable tabela = new DataTable("Clientes");
            // Cria colunas na tabela
            tabela.Columns.Add(new DataColumn("Codigo"));
            tabela.Columns.Add(new DataColumn("Nome"));
            tabela.Columns.Add(new DataColumn("Fone"));
            tabela.Columns.Add(new DataColumn("Email"));
            return tabela;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            // Cria o dataset
            DataSet dataSet = new DataSet();
            // Le o dataset do disco
            dataSet.ReadXml(@".\cliente_" + txtCodigo.Text + ".xml");
            // tabela é o primeiro datatable da coleção
            DataTable tabela = dataSet.Tables[0];
            // Considero o primeiro registro da tabela
            DataRow registro = tabela.Rows[0];
            // mostro dados do registro na tela
            MostrarDadosTela(registro);
        }

        private void MostrarDadosTela(DataRow registro)
        {
            txtNome.Text = registro["Nome"].ToString();
            txtTelefone.Text = registro["Fone"].ToString();
            txtEmail.Text = registro["Email"].ToString();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            foreach (Control txt in Controls)
            {
                if (txt is TextBox)
                    (txt as TextBox).Clear();
            }
        }
    }
}
