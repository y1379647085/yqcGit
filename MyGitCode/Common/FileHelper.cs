using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtendMethods
{
    public class FileHelper
    {
        public static IEnumerable ReadText(string path)
        {
            return File.ReadLines(path);
        }
    }
}
