using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace System.XML_Example
{
    public class SContatos
    {
        static string arquivo = @"C:\Temp\agenda.xml";
        static XmlDocument xmlDoc = new XmlDocument();
        static XElement xDoc;
        static Contatos contatos;

        public SContatos()
        {
            if (!File.Exists(arquivo))
            {
                XmlNode nodeRoot = xmlDoc.CreateElement("Contatos");
                xmlDoc.AppendChild(nodeRoot);
                xmlDoc.Save(arquivo);
            }
        }

        public static Contatos Read()
        {
            xDoc = XElement.Load(arquivo);
            contatos = Serializer.Deserialize<Contatos>(xDoc);

            return contatos;
        }

        public static void Write(Contatos contatos)
        {
            XElement xmlReturn = Serializer.Serialize(contatos);
            xmlReturn.Save(arquivo);
        }

    }
}
