using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyUI
{
    /// <summary>
    /// 根据当前页获取数据的委托
    /// </summary>
    /// <param name="currentPageNum"></param>
    public delegate void DelegateGetData(int currentPageNum);
    /// <summary>
    /// DevExpress分页控件封装类
    /// </summary>
    public partial class UCPager : UserControl
    {
        #region 变量

        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 每页显示数量
        /// </summary>
        public int PerPageCount { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool IsShowNextPage { get; set; }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool IsShowPreviouPage { get; set; }
        /// <summary>
        /// 是否有第一页
        /// </summary>
        public bool IsShowFirstPage { get; set; }
        /// <summary>
        /// 是否有最后一页
        /// </summary>
        public bool IsShowLastPage { get; set; }
        /// <summary>
        /// 根据当前选中页重新获取数据的委托
        /// </summary>
        public event DelegateGetData DelGetDataByCurrentPage = null;
        /// <summary>
        /// 显示的字符串格式
        /// </summary>
        private string FormatString = "共   {0}   条记录    第  {1}  页 / 共  {2}  页";
        /// <summary>
        /// 没有记录
        /// </summary>
        //private string NoQueryResult = "没有任何记录！";
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public UCPager()
        {
            InitializeComponent();
            CurrentPage = 1;
        }
        #endregion

        #region 初始化方法
        /// <summary>
        /// 初始化Page分页的参数设置
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="currentPage"></param>
        /// <param name="perPageCount"></param>
        public void InitPager(int totalCount, int currentPage = 1, int perPageCount = 20)
        {
            try
            {
                this.TotalCount = totalCount;
                this.CurrentPage = currentPage;
                this.PerPageCount = perPageCount;

                SetPagerParameter();
                SetUserControl();
            }
            catch (Exception ex)
            {
                //LogWritter.WriteLogToFile(ex.Message);
            }
        }

        /// <summary>
        /// 设置Page的各种参数
        /// </summary>
        private void SetPagerParameter()
        {
            try
            {
                //计算总Page数
                if (TotalCount % PerPageCount == 0)
                    TotalPage = TotalCount / PerPageCount;
                else
                    TotalPage = TotalCount / PerPageCount + 1;

                //是否显示上一页
                if (CurrentPage <= 1)
                {
                    IsShowPreviouPage = false;
                }
                else
                {
                    IsShowPreviouPage = true;
                }
                //是否显示下一页
                if (CurrentPage >= TotalPage)
                {
                    IsShowNextPage = false;
                }
                else
                {
                    IsShowNextPage = true;
                }

                if (TotalPage == 1)
                {
                    IsShowNextPage = false;
                    IsShowPreviouPage = false;
                }
                if (CurrentPage > 1 && TotalPage > 1)
                {
                    IsShowFirstPage = true;
                }
                else
                {
                    IsShowFirstPage = false;
                }

                if (CurrentPage < TotalPage && TotalPage > 1)
                {
                    IsShowLastPage = true;
                }
                else
                {
                    IsShowLastPage = false;
                }
            }
            catch (Exception ex)
            {
                //LogWritter.WriteLogToFile(ex.Message);
            }
        }

        /// <summary>
        /// 设置用户控件
        /// </summary>
        private void SetUserControl()
        {
            try
            {
                //this.lblConTotalCount.Text = TotalCount.ToString();
                //this.lblConTotalPage.Text = TotalPageNum.ToString();
                //this.lblConCurrentPage.Text = CurrentPageNum.ToString();
                this.lblControlStr.Text = string.Format(FormatString, TotalCount, TotalCount > 0 ? CurrentPage : 0, TotalPage);

                if (!IsShowNextPage)
                    this.spbtnNext.Enabled = false;
                else
                    this.spbtnNext.Enabled = true;

                if (!IsShowPreviouPage)
                    this.spbtnPreviou.Enabled = false;
                else
                    this.spbtnPreviou.Enabled = true;

                if (!IsShowFirstPage)
                    this.spbtnFirst.Enabled = false;
                else
                    this.spbtnFirst.Enabled = true;

                if (!IsShowLastPage)
                    this.spbtnLast.Enabled = false;
                else
                    this.spbtnLast.Enabled = true;
            }
            catch (Exception ex)
            {
                //LogWritter.WriteLogToFile(ex.Message);
            }
        }

        #endregion

        #region 事件
        /// <summary>
        /// 单击第一页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spbtnFirst_Click(object sender, EventArgs e)
        {
            this.CurrentPage = 1;
            SetPagerParameter();
            SetUserControl();
            ExecuteDelegate();
        }

        /// <summary>
        /// 单击上一页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spbtnPreviou_Click(object sender, EventArgs e)
        {
            this.CurrentPage = CurrentPage - 1;
            SetPagerParameter();
            SetUserControl();
            ExecuteDelegate();
        }

        /// <summary>
        /// 单击下一页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spbtnNext_Click(object sender, EventArgs e)
        {
            this.CurrentPage = CurrentPage + 1;
            SetPagerParameter();
            SetUserControl();
            ExecuteDelegate();
        }

        /// <summary>
        /// 单击最后一页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spbtnLast_Click(object sender, EventArgs e)
        {
            this.CurrentPage = TotalPage;
            SetPagerParameter();
            SetUserControl();
            ExecuteDelegate();
        }

        /// <summary>
        /// 执行委托 根据当前选中页重新获取数据源
        /// </summary>
        private void ExecuteDelegate()
        {
            if (DelGetDataByCurrentPage != null)
            {
                DelGetDataByCurrentPage(CurrentPage);
            }
        }
        #endregion
    }
}
