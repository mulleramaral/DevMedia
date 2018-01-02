using System.Collections.Generic;
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
        [XmlArray("Telefone")]
        public List<Telefone> Telefone { get; set; }
        [XmlElement("Obs")]
        public string Obs { get; set; }

        public string IdNome { get { return Id + " - " + Nome; } }

        public Contato()
        {
            Telefone = new List<Telefone>();
        }
    }
}
