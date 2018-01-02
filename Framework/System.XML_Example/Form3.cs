using System.Collections.Generic;
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

        private void BindListBox(List<Contato> Contato)
        {
            listBox1.DataSource = Contato;
            listBox1.DisplayMember = "IdNome";
            listBox1.ValueMember = "Id";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            contatos = SContatos.Read();
            BindListBox(contatos.Contato);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato c = new Contato();
            c.Id = NextId();
            c.Nome = txtNome.Text;
            c.Telefone.Add(new Telefone((int)TiposTelefone.Residencial,txtResidencial.Text));
            c.Telefone.Add(new Telefone((int)TiposTelefone.Comercial,txtComercial.Text));
            c.Telefone.Add(new Telefone((int)TiposTelefone.Celular,txtCelular.Text));
            c.Obs = txtObs.Text;

            contatos.Contato.Add(c);

            SContatos.Write(contatos);

            BindListBox(SContatos.Read().Contato);
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
                BindListBox(SContatos.Read().Contato);
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
                if (c.Telefone.Any())
                {
                    txtResidencial.Text = c.Telefone.FirstOrDefault(t => t.Tipo.Equals((int)TiposTelefone.Residencial)).Numero;
                    txtComercial.Text = c.Telefone.FirstOrDefault(t => t.Tipo.Equals((int)TiposTelefone.Comercial)).Numero; ;
                    txtCelular.Text = c.Telefone.FirstOrDefault(t => t.Tipo.Equals((int)TiposTelefone.Celular)).Numero;
                }
                txtObs.Text = c.Obs;
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
            contato.Telefone.Clear();
            contato.Telefone.Add(new Telefone((int)TiposTelefone.Residencial,txtResidencial.Text));
            contato.Telefone.Add(new Telefone((int)TiposTelefone.Comercial,txtComercial.Text));
            contato.Telefone.Add(new Telefone((int)TiposTelefone.Celular,txtCelular.Text));
            contato.Obs = txtObs.Text;
            SContatos.Write(contatos);
            BindListBox(SContatos.Read().Contato);

            btnCancelar_Click(null, null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Form f4 = new Form4();
            f4.FormClosed += F4_FormClosed;
            f4.ShowDialog();
        }

        private void F4_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FiltroContatos.Filtro.Any())
            {
                BindListBox(FiltroContatos.Filtro);
            }
        }

        private void btnRemoverFiltro_Click(object sender, EventArgs e)
        {
            BindListBox(SContatos.Read().Contato);
        }
    }
}
