using System.Collections.Generic;
using System.Xml.Serialization;

namespace System.XML_Example
{
    [Serializable()]
    [XmlRoot("Contatos")]
    public class Contatos
    {
        [XmlElement("Contato")]
        public List<Contato> Contato { get; set; }
    }
}
