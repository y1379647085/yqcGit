using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace ReNameTool
{
    public partial class Form1 : Form
    {
        //private string _filePath = string.Empty;
        private readonly BindingList<FileProperty> _bindlistProperty = new BindingList<FileProperty>();
        //private DataTable _dtResult;
        public Form1()
        {
            InitializeComponent();
            gridView1.OptionsView.GroupDrawMode = GroupDrawMode.Standard;
            gridView1.Columns["DirName"].GroupIndex = 0;
        }

        private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                //var dt = CreateFileNameDataTable();
                var fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    buttonEdit1.Text = fbd.SelectedPath;
                    GetDirectoryInfosToGrid();
                }

                gridControl1.DataSource = _bindlistProperty;
                gridView1.OptionsView.GroupDrawMode = GroupDrawMode.Standard;
                gridView1.Columns["DirName"].GroupIndex = 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //_dtResult = gridControl1.DataSource as DataTable;
                //if(_dtResult == null)return;
                if (_bindlistProperty.Count <= 0) return;
                foreach (var fileProperty in _bindlistProperty)
                {
                    if (Path.GetFileNameWithoutExtension(fileProperty.FileName) == fileProperty.AfterName) continue;
                    var path = fileProperty.DirPath.Substring(0, fileProperty.DirPath.LastIndexOf("\\"));
                    File.Move(fileProperty.DirPath,
                        path + "\\" + fileProperty.AfterName +
                        fileProperty.FileName.Substring(fileProperty.FileName.LastIndexOf(".")));
                }

                XtraMessageBox.Show("保存成功");
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show("保存失败");
                Console.WriteLine(exception);
                throw;
            }
        }

        private void buttonEdit1_EditValueChanged(object sender, EventArgs e)
        {
            GetDirectoryInfosToGrid();
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                var curFileProperty = _bindlistProperty[e.RowHandle];
                foreach (var fileProperty in _bindlistProperty)
                    if (fileProperty.DirName != curFileProperty.DirName &&
                        fileProperty.FileName == curFileProperty.FileName)
                        fileProperty.AfterName = curFileProperty.AfterName;
                gridControl1.DataSource = _bindlistProperty;
                gridControl1.RefreshDataSource();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var path = ((Array) e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString(); //获得路径
            buttonEdit1.Text = path;
        }

        private void GetDirectoryInfosToGrid()
        {
            _bindlistProperty.Clear();
            var subDirectorys = Directory.GetDirectories(buttonEdit1.Text);
            if (subDirectorys.Length > 0)
                foreach (var subDir in subDirectorys)
                {
                    var files = Directory.GetFiles(subDir);
                    foreach (var file in files)
                    {
                        //var dr = dt.NewRow();
                        //dr[0] = file;
                        //    //Path.GetDirectoryName(subDir);
                        //dr[1] = subDir.Substring(subDir.LastIndexOf("\\")+1);
                        //dr[2] = Path.GetFileName(file);
                        //dr[3] = Path.GetFileNameWithoutExtension(file);
                        //    dt.Rows.Add(dr);
                        var fileProperty = new FileProperty
                        {
                            DirPath = file,
                            DirName = subDir.Substring(subDir.LastIndexOf("\\") + 1),
                            FileName = Path.GetFileName(file),
                            AfterName = Path.GetFileNameWithoutExtension(file)
                        };
                        _bindlistProperty.Add(fileProperty);
                    }
                }

            gridControl1.DataSource = _bindlistProperty;
            gridControl1.RefreshDataSource();
        }

        private DataTable CreateFileNameDataTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("DirPath", typeof(string));
            dt.Columns.Add("DirName", typeof(string));
            dt.Columns.Add("FileName", typeof(string));
            dt.Columns.Add("AfterName", typeof(string));
            return dt;
        }       
    }

    class FileProperty
    {
        public string DirPath { get; set; }
        public string DirName { get; set; }
        public string FileName { get; set; }
        public string AfterName { get; set; }
    }
}