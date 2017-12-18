using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

namespace MyUI
{
    public partial class UcTreeList : UserControl
    {
        public UcTreeList()
        {
            InitializeComponent();
            InitTree();
        }
        public void InitTree()
        {
            DataTable dt = CreateTable();
            for (int i = 2; i <= 2; i++)
            {
                DataRow dr = dt.NewRow();dr[0] = i;dr[1] = "一级节点" + i;
                dr[2]=new object();
                dr[3] = 0;
                dt.Rows.Add(dr);
                for (int j = 3; j < 6; j++)
                {
                    dr = dt.NewRow();
                    dr[0] = j;
                    dr[1] = "二级节点" + j;
                    dr[2] = new object();
                    dr[3] = i;
                    dt.Rows.Add(dr);
                }
            }
            treeList1.DataSource = dt;
        }

        private DataTable CreateTable()
        {
            DataTable dt=new DataTable();
            dt.Columns.Add("ID", typeof (string));
            dt.Columns.Add("NodeName", typeof (string));
            dt.Columns.Add("Data", typeof (object));
            dt.Columns.Add("ParentID", typeof (string));
            return dt;
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeList1.ContextMenuStrip = null;
                TreeListHitInfo hitInfo = treeList1.CalcHitInfo(new Point(e.X, e.Y));
                TreeListNode node = hitInfo.Node;
                treeList1.FocusedNode = node;
                if (node != null)
                {
                    treeList1.ContextMenuStrip = ContextMenuStrip;
                }}}

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (ModifierKeys == Keys.None) &&
               (treeList1.State == TreeListState.Regular))
            {
                Point p = new Point(Cursor.Position.X, Cursor.Position.Y);
                TreeListHitInfo hitInfo = treeList1.CalcHitInfo(e.Location);if (hitInfo.HitInfoType == HitInfoType.Cell)
                {
                    treeList1.SetFocusedNode(hitInfo.Node);
                }
                if (treeList1.FocusedNode != null)
                {
                    popupMenu1.ShowPopup(p);
                }

            }
        }
    }
}
