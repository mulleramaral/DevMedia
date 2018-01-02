using System.Xml.Serialization;

namespace System.XML_Example
{
    [Serializable()]
    public class Telefone
    {
        [XmlElement("Tipo")]
        public int Tipo { get; set; }
        [XmlElement("Numero")]
        public string Numero { get; set; }

        public Telefone() { }

        public Telefone(int tipo,string numero)
        {
            Tipo = tipo;
            Numero = numero;
        }
    }
}
