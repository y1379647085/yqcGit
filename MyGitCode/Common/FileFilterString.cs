using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendMethods
{
    /// <summary>
    /// 文件后缀过滤字符串
    /// </summary>
    public class FileFilterString
    {
        /// <summary>
        /// excel文件
        /// </summary>
        public const string Excel = "Excel File 2007(*.xlsx)|*.xlsx|Excel File 2003(*.xls)|*.xls";

        /// <summary>
        /// xml文件
        /// </summary>
        public const string Xml = "XML File(*.xml)|*.xml";

        /// <summary>
        /// shp文件
        /// </summary>
        public const string Shp = "SHP File(*.shp)|*.shp";

        /// <summary>
        /// jpg文件
        /// </summary>
        public const string Jpg = "JPG Files(*.JPG)|*.JPG";

        /// <summary>
        /// csv文件
        /// </summary>
        public const string Csv = "CSV Files(*.csv)|*.csv";

        /// <summary>
        /// 图片文件
        /// </summary>
        public const string Image = "Image Files(*.BMP)|*.BMP|Image Files(*.PNG)|*.PNG|Image Files(*.JPG)|*.JPG";
    }
}
