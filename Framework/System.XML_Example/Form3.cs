using System.Linq;
using System.Windows.Forms;

namespace System.XML_Example
{
    public partial class Form3 : Form
    {
        SContatos sContatos = new SContatos();

        Contatos contatos;

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
            c.Telefone = txtTelefone.Text;

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
    }
}
