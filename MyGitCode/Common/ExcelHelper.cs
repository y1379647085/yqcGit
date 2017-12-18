using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.OleDb;
using System.Reflection;

namespace ExtendMethods
{
    public class ExcelHelper
    {
        /// <summary>
        /// 导入Excel转换为DataSet
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static DataSet ImportExcel(string fileName)
        {
            DataSet ds = null;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            if (xlApp == null)
                return null;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            try
            { workbook = xlApp.Workbooks.Open(fileName, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, 1, 0); }
            catch (Exception ex)
            {
                return null;
            }
            try
            {
                int n = workbook.Worksheets.Count;
                string[] sheetSet = new string[n];
                System.Collections.ArrayList al = new System.Collections.ArrayList();
                for (int i = 1; i <= n; i++)
                { sheetSet[i - 1] = ((Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[i]).Name; }
                workbook.Close(null,null,null);
                xlApp.Quit();
                if (workbook != null)
                {
                    Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }
                if (xlApp != null)
                {
                    Marshal.ReleaseComObject(xlApp);
                    xlApp = null;
                }
                GC.Collect();
                //excel表单转为DataSet
                string fileType = Path.GetExtension(fileName);
                string connStr = " Provider= Microsoft.Ace.OLEDB.12.0 ; Data Source= " + fileName + " ;Extended Properties ='Excel 12.0;HDR=Yes;IMEX=1;'";
                if (fileType.ToLower() == ".xls")
                {
                    connStr = " Provider= Microsoft.Jet.OLEDB.4.0 ; Data Source= " + fileName + " ;Extended Properties ='Excel 8.0'";
                }
                else
                {
                    connStr = " Provider= Microsoft.Ace.OLEDB.12.0 ; Data Source= " + fileName + " ;Extended Properties ='Excel 12.0;HDR=Yes;IMEX=1;'";
                }
                using (OleDbConnection conn = new OleDbConnection(connStr))
                {
                    conn.Open();
                    OleDbDataAdapter da;
                    for (int i = 0; i <= n; i++)
                    {
                        string sql = "select * from [" + sheetSet[i - 1] + "$]";
                        da = new OleDbDataAdapter(sql, conn);
                        da.Fill(ds, sheetSet[i - 1]);
                        da.Dispose();
                    }
                    conn.Close();
                    conn.Dispose();
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            return ds;
        }

        /// <summary>
        /// DataSet转出为Excel
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="sheetName"></param>
        /// <param name="strFileName"></param>
        public static void DataSetToExcel(DataSet ds, string sheetName,string strFileName)
        {
            if (ds == null || ds.Tables.Count == 0)
            {
                return;
            }
            System.Reflection.Missing miss = System.Reflection.Missing.Value;
            //创建excel对象appExcel，Workbook对象，WorkSheet对象，Range对象
            Microsoft.Office.Interop.Excel.Application appExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbookData;
            Microsoft.Office.Interop.Excel.Worksheet worksheetData;
            Microsoft.Office.Interop.Excel.Range rangeData;
            appExcel.Visible = false;
            System.Globalization.CultureInfo currentCi = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            workbookData = appExcel.Workbooks.Add(miss);
            try
            {
                for (int k = 0; k < ds.Tables.Count; k++)
                {
                    worksheetData = (Microsoft.Office.Interop.Excel.Worksheet)workbookData.Worksheets.Add(Missing.Value,Missing.Value,Missing.Value,Missing.Value);
                    worksheetData.Name = ds.Tables[k].TableName;
                    worksheetData.Columns.EntireColumn.AutoFit();
                    if (ds.Tables[k] != null)
                    {
                        for (int i = 0; i < ds.Tables[k].Columns.Count; i++)
                        {
                            worksheetData.Cells[i + 1] = ds.Tables[k].Columns[i].ColumnName.ToString();
                        }
                        //先给range对象一个范围从A2开始，range对象可以给一个cell范围，也可以给例如A1-H10这样的范围
                        //因为第一行已经写了表头，所以所有数据都从A2开始
                        rangeData = worksheetData.get_Range("A2", miss);
                        int iRowCount = ds.Tables[k].Rows.Count;
                        int iColumnAccount = ds.Tables[k].Columns.Count;
                        //在内存中声明一个iEachSize*iColumnAccount的数组，iEachSize是每次最大存储的行数，iColumnAccount就是最大存储的实际列数
                        object[,] objVal = new object[iRowCount, iColumnAccount];
                        //方法一
                        //for(int i=0;i<ds.Tables[k].Rows.Count;i++)
                        //{
                        //     for (int j = 0; j < iColumnAccount; j++)
                        //    {
                        //        objVal[i, j] = ds.Tables[k].Rows[i][j].ToString();
                        //         worksheetData.Cells[i+2,j+1]=objVal[i,j];
                        //    }
                        //    System.Windows.Forms.Application.DoEvents();
                        //}

                        //方法2
                        Microsoft.Office.Interop.Excel.Range xlRange = null;
                        for (int i = 0; i < iRowCount; i++)
                        {
                            for (int j = 0; j < iColumnAccount; j++)
                            {
                                objVal[i, j] = ds.Tables[k].Rows[i][j].ToString();
                            }
                            if (i % 1000 ==0)
                                System.Windows.Forms.Application.DoEvents();
                            
                        }
                        xlRange = worksheetData.get_Range(appExcel.Cells[2, 1],appExcel.Cells[iRowCount+1,iColumnAccount]);
                        //调用Range的Value2属性，把内存中的值赋给Excel
                        xlRange.Value2 = objVal;
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlRange);
                        xlRange = null;

                    }
                }
                workbookData.Saved = true;
                appExcel.DisplayAlerts = false;
                workbookData.SaveAs(strFileName + "", miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,miss,miss,miss);
                appExcel.DisplayAlerts = true;
                appExcel.Quit();
                //结束之前恢复环境
                System.Threading.Thread.CurrentThread.CurrentCulture = currentCi;
                GC.Collect();
            }
            catch (Exception ex)
            {
                appExcel.Quit();
                Kill(appExcel);
                System.Threading.Thread.CurrentThread.CurrentCulture = currentCi;
                GC.Collect();
            }

        }
        [System.Runtime.InteropServices.DllImport("User32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        public static void Kill(Microsoft.Office.Interop.Excel.Application excelApp)
        {
            IntPtr t = new IntPtr(excelApp.Hwnd);
            int k = 0;
            GetWindowThreadProcessId(t, out k);
            System.Diagnostics.Process p = System.Diagnostics.Process.GetProcessById(k);
            p.Kill();
        }
    }
}
