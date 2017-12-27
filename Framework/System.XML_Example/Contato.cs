using System.Xml.Serialization;

namespace System.XML_Example
{
    [Serializable()]
    public class Contato
    {
        [XmlElement]
        public int Id { get; set; }
        [XmlElement("Nome")]
        public string Nome { get; set; }
        [XmlElement("Telefone")]
        public string Telefone { get; set; }
    }
}
