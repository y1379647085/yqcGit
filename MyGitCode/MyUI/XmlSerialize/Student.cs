using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UI.XmlSerialize
{
    public class Student
    {
        [XmlAttribute]
        public int Age { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]public string Sex { get; set; }
    }
}
