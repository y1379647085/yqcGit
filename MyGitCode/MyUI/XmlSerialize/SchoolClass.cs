using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UI.XmlSerialize
{
    public class SchoolClass
    {
        [XmlElement("Teachers")]
        public List<Teacher> Teachers { get; set; }
        [XmlAttribute("No")]
        public int No { get; set; }
    }
}
