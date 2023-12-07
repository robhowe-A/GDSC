using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.Serialization;

namespace waterlocator.Models
{
    [XmlRoot(ElementName = "kml",
     Namespace = "http://www.opengis.net/kml/2.2")]
    public class Kml
    {
        [XmlElement(ElementName = "Document")]
        public Document Document { get; set; }

    }
}
