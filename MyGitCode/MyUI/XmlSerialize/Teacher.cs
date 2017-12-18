using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace UI.XmlSerialize
{

    public class Teacher
    {
        [XmlElement("Students")]
        public List<Student> Students { get; set; }
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
