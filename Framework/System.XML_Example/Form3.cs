using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace System.XML_Example
{
    public partial class Form3 : Form
    {
        string arquivo = @"C:\Temp\agenda.xml";
        XmlDocument xmlDoc = new XmlDocument();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //Deserialize
            XElement xElement = XElement.Load(arquivo);
            Contatos contatos = Serializer.Deserialize<Contatos>(xElement);

            //Serialize

            XElement xmlReturn = Serializer.Serialize<Contatos>(contatos);
        }

    }
}
