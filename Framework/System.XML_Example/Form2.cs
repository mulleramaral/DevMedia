using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace System.XML_Example
{
    public partial class Form2 : Form
    {

        string arquivo = @"C:\Temp\Agenda2.xml";
        XmlDocument xmlDoc = new XmlDocument();

        public Form2()
        {
            InitializeComponent();

            if (!File.Exists(arquivo))
            {

                XmlNode nodeRoot = xmlDoc.CreateElement("Contatos");
                xmlDoc.AppendChild(nodeRoot);
                xmlDoc.Save(arquivo);
            }
            ReadAgenda();
        }

        private void ReadAgenda()
        {
            xmlDoc.Load(arquivo);
            lblAgenda.Text = "Contatos: \n\n";
            foreach (XmlNode node in xmlDoc.GetElementsByTagName("Contato"))
            {
                lblAgenda.Text += node.Attributes["nome"].Value + " : " + node.Attributes["telefone"].Value + "\n";
            }
        }

        private void Add(string nome,string telefone)
        {
            XElement xElement = new XElement("Contato");
            xElement.Add(new XAttribute("nome", nome));
            xElement.Add(new XAttribute("telefone", telefone));

            XElement xDoc = XElement.Load(arquivo);
            xDoc.Add(xElement);
            xDoc.Save(arquivo);
            ReadAgenda();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add(txtNome.Text, txtTelefone.Text);
        }
    }
}
