using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUI
{
    public partial class UcGridControl : UserControl
    {
        public UcGridControl()
        {
            InitializeComponent();
            //Init();
        }

        /// <summary>
        /// gridControl示例代码
        /// </summary>
        private void Init()
        {
            Image image = Image.FromFile(@"F:\pic\ATM.png");
            DataTable dt=new DataTable();
            DataColumn dc1=new DataColumn("Picture",typeof(Image));
            DataColumn dc2=new DataColumn("PicName",typeof(string));
            dt.Columns.Add(dc1);dt.Columns.Add(dc2);
            DataRow dr = dt.NewRow();
            dr[0] = image;
            dr[1] = "ATM";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = image;dr[1] = "ATM";
            dt.Rows.Add(dr);
            gridControl1.DataSource = dt;
        }
    }
}
