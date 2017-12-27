using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace System.XML_Example
{
    public partial class Form3 : Form
    {
        string arquivo = @"C:\Temp\agenda.xml";
        XmlDocument xmlDoc = new XmlDocument();
        XElement xDoc;
        Contatos contatos;
        

        public Form3()
        {
            InitializeComponent();
            if (!File.Exists(arquivo))
            {
                XmlNode nodeRoot = xmlDoc.CreateElement("Contatos");
                xmlDoc.AppendChild(nodeRoot);
                xmlDoc.Save(arquivo);
            }
        }

        private void ReadAgenda()
        {
            xDoc = XElement.Load(arquivo);
            contatos = Serializer.Deserialize<Contatos>(xDoc);
            lblContatos.Text = string.Empty;

            foreach (Contato c in contatos.Contato)
            {
                lblContatos.Text += "Nome: " + c.Nome + "\nTelefone: " + c.Telefone + "\n\n";
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ReadAgenda();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato c = new Contato();
            c.Nome = txtNome.Text;
            c.Telefone = txtTelefone.Text;

            contatos.Contato.Add(c);

            XElement xmlReturn = Serializer.Serialize(contatos);
            xmlReturn.Save(arquivo);

            ReadAgenda();
        }
    }
}
