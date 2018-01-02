using System.Linq;
using System.Windows.Forms;

namespace System.XML_Example
{
    public partial class Form3 : Form
    {
        SContatos sContatos = new SContatos();

        Contatos contatos;

        private int idSelecionado;

        public Form3()
        {
            InitializeComponent();
        }

        private void BindListBox()
        {
            contatos = SContatos.Read();
            listBox1.DataSource = contatos.Contato;
            listBox1.DisplayMember = "IdNome";
            listBox1.ValueMember = "Id";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            BindListBox();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato c = new Contato();
            c.Id = NextId();
            c.Nome = txtNome.Text;
            c.Telefone.Add(txtResidencial.Text);
            c.Telefone.Add(txtComercial.Text);
            c.Telefone.Add(txtCelular.Text);
            c.Obs = txtObs.Text;

            contatos.Contato.Add(c);

            SContatos.Write(contatos);

            BindListBox();
        }

        private int NextId()
        {
            if (!contatos.Contato.Any())
                return 1;

            //int indice = contatos.Contato.Count == 0 ? 0 : contatos.Contato.Count + 1;
            return contatos.Contato[contatos.Contato.Count - 1].Id + 1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                Contato c = contatos.Contato.Find(p => p.Id == (int)listBox1.SelectedValue);
                contatos.Contato.Remove(c);
                SContatos.Write(contatos);
                BindListBox();
            }
            else
            {
                MessageBox.Show("Nenhum item selecionado");
            }

        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                panelIncluir.Visible = false;
                panelAlterar.Visible = true;

                Contato c = contatos.Contato.Find(p => p.Id == (int)listBox1.SelectedValue);
                idSelecionado = c.Id;
                txtNome.Text = c.Nome;
                txtResidencial.Text = c.Telefone.ElementAt(0);
                txtComercial.Text = c.Telefone.ElementAt(1);
                txtCelular.Text = c.Telefone.ElementAt(2);
            }
            else
            {
                MessageBox.Show("Nenhum item selecionado");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelAlterar.Visible = false;
            panelIncluir.Visible = true;

            txtNome.Text = txtResidencial.Text = string.Empty;
            idSelecionado = 0;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Contato contato = contatos.Contato.Find(p => p.Id == idSelecionado);
            contato.Nome = txtNome.Text;
            contato.Telefone.Add(txtResidencial.Text);
            contato.Telefone.Add(txtComercial.Text);
            contato.Telefone.Add(txtCelular.Text);
            contato.Obs = txtObs.Text;
            SContatos.Write(contatos);
            BindListBox();

            btnCancelar_Click(null, null);
        }
    }
}
