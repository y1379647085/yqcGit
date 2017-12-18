using System.Collections.Generic;
using ExtendMethods;
using UI.XmlSerialize;

namespace MyUI.XmlSerialize
{
    public class OperationClass
    {
        public void SerializeClass()
        {
            SchoolClass class1 = new SchoolClass {No = 7};
            List<Teacher> teachers = new List<Teacher>();
            List<Student> students = new List<Student>
            {
                new Student {Name = "张三", Age = 12, Sex = "男"},
                new Student {Name = "李四", Age = 12, Sex = "男"},
                new Student {Name = "王五", Age = 12, Sex = "男"}
            };
            teachers.Add(new Teacher {Name = "mrYang", Students = students});
            teachers.Add(new Teacher {Name = "missZhu", Students = students});
            class1.No = 7;
            class1.Teachers = teachers;
            XmlHelper.SerializeToXml("myXml.xml", class1);
        }

        public void DeserializeClass()
        {
            string filePath = @"F:\SheJiMoShi\UI\bin\Debug\myXml.xml";
            SchoolClass myClass = XmlHelper.DeserializeFromXml<SchoolClass>(filePath);
        }
        public void JsonClass()
        {
            SchoolClass class1 = new SchoolClass {No = 7};
            List<Teacher> teachers = new List<Teacher>();
            List<Student> students = new List<Student>
            {
                new Student {Name = "张三", Age = 12, Sex = "男"},
                new Student {Name = "李四", Age = 12, Sex = "男"},
                new Student {Name = "王五", Age = 12, Sex = "男"}
            };
            teachers.Add(new Teacher {Name = "mrYang", Students = students});
            teachers.Add(new Teacher {Name = "missZhu", Students = students});
            class1.No = 7;
            class1.Teachers = teachers;
            string s = XmlHelper.ObjectToJson(class1);
            string s1 = s.ToString();
        }
    }
}
