using DevExpress.XtraBars.Ribbon;
using ExtendMethods;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.XmlSerialize;

namespace MyUI
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int GetTempNum()
        {
            return 0;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    List<int> listNo = new List<int> {1, 2, 3, 2, 2};
            //    ArrayList alist = new ArrayList {"Adams", "Arthur", "Buchanan"};
            //    var result=alist.Cast<string>().Where(x => x.StartsWith("A"));
            //}
            //catch (Exception ex)
            //{             
            //}
            //string s = @"wi1Kua0kLMploa";
            //bool b = IsURL(s);
            //string s1 = b.ToString();
            SchoolClass class1 = new SchoolClass { No = 7 };
            List<Teacher> teachers = new List<Teacher>();
            List<Student> students = new List<Student>
            {
                new Student {Name = "张三", Age = 12, Sex = "男"},
                new Student {Name = "李四", Age = 12, Sex = "男"},
                new Student {Name = "王五", Age = 12, Sex = "男"}
            };
            teachers.Add(new Teacher { Name = "mrYang", Students = students });
            teachers.Add(new Teacher { Name = "missZhu", Students = students });
            class1.No = 7;
            class1.Teachers = teachers;
            string filePath = @"E:\MyCode\myJson.txt";
            JsonUtil.SerializeToFile(filePath,class1);
                //.DeserializeFromXml<SchoolClass>(filePath);

        }
        /// <summary>  
        /// 判断输入的字符串是否是一个超链接  
        /// </summary>  
        /// <param name="input"></param>  
        /// <returns></returns>  
        public static bool IsURL(string input)
        {
            //string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";  
            //string pattern = @"^[a-zA-Z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$";
            string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";   
            Regex regex = new Regex(pattern);return regex.IsMatch(input);
                
        }  

    }
}
