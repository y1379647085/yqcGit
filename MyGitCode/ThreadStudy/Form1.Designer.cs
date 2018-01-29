namespace ThreadStudy
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.awaitTest = new DevExpress.XtraEditors.SimpleButton();
            this.taskTest = new DevExpress.XtraEditors.SimpleButton();
            this.threadpoolTest = new DevExpress.XtraEditors.SimpleButton();
            this.threadTest = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnAwait = new DevExpress.XtraEditors.SimpleButton();
            this.OutInfo = new DevExpress.XtraEditors.MemoEdit();
            this.sbtnTask = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnThreadPool = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnThread = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.awaitTest);
            this.layoutControl1.Controls.Add(this.taskTest);
            this.layoutControl1.Controls.Add(this.threadpoolTest);
            this.layoutControl1.Controls.Add(this.threadTest);
            this.layoutControl1.Controls.Add(this.sbtnAwait);
            this.layoutControl1.Controls.Add(this.OutInfo);
            this.layoutControl1.Controls.Add(this.sbtnTask);
            this.layoutControl1.Controls.Add(this.sbtnThreadPool);
            this.layoutControl1.Controls.Add(this.sbtnThread);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(493, 472);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // awaitTest
            // 
            this.awaitTest.Location = new System.Drawing.Point(371, 49);
            this.awaitTest.Name = "awaitTest";
            this.awaitTest.Size = new System.Drawing.Size(106, 27);
            this.awaitTest.StyleController = this.layoutControl1;
            this.awaitTest.TabIndex = 12;
            this.awaitTest.Text = "await异步性能";
            this.awaitTest.Click += new System.EventHandler(this.awaitTest_Click);
            // 
            // taskTest
            // 
            this.taskTest.Location = new System.Drawing.Point(260, 49);
            this.taskTest.Name = "taskTest";
            this.taskTest.Size = new System.Drawing.Size(105, 27);
            this.taskTest.StyleController = this.layoutControl1;
            this.taskTest.TabIndex = 11;
            this.taskTest.Text = "Task异步性能";
            this.taskTest.Click += new System.EventHandler(this.taskTest_Click);
            // 
            // threadpoolTest
            // 
            this.threadpoolTest.Location = new System.Drawing.Point(136, 49);
            this.threadpoolTest.Name = "threadpoolTest";
            this.threadpoolTest.Size = new System.Drawing.Size(118, 27);
            this.threadpoolTest.StyleController = this.layoutControl1;
            this.threadpoolTest.TabIndex = 10;
            this.threadpoolTest.Text = "线程池异步性能";
            this.threadpoolTest.Click += new System.EventHandler(this.threadpoolTest_Click);
            // 
            // threadTest
            // 
            this.threadTest.Location = new System.Drawing.Point(16, 49);
            this.threadTest.Name = "threadTest";
            this.threadTest.Size = new System.Drawing.Size(114, 27);
            this.threadTest.StyleController = this.layoutControl1;
            this.threadTest.TabIndex = 9;
            this.threadTest.Text = "线程异步性能";
            this.threadTest.Click += new System.EventHandler(this.threadTest_Click);
            // 
            // sbtnAwait
            // 
            this.sbtnAwait.Location = new System.Drawing.Point(338, 16);
            this.sbtnAwait.Name = "sbtnAwait";
            this.sbtnAwait.Size = new System.Drawing.Size(139, 27);
            this.sbtnAwait.StyleController = this.layoutControl1;
            this.sbtnAwait.TabIndex = 8;
            this.sbtnAwait.Text = "await异步";
            this.sbtnAwait.Click += new System.EventHandler(this.sbtnAwait_Click);
            // 
            // OutInfo
            // 
            this.OutInfo.Location = new System.Drawing.Point(16, 104);
            this.OutInfo.Name = "OutInfo";
            this.OutInfo.Size = new System.Drawing.Size(461, 352);
            this.OutInfo.StyleController = this.layoutControl1;
            this.OutInfo.TabIndex = 7;
            // 
            // sbtnTask
            // 
            this.sbtnTask.Location = new System.Drawing.Point(238, 16);
            this.sbtnTask.Name = "sbtnTask";
            this.sbtnTask.Size = new System.Drawing.Size(94, 27);
            this.sbtnTask.StyleController = this.layoutControl1;
            this.sbtnTask.TabIndex = 6;
            this.sbtnTask.Text = "Task异步";
            this.sbtnTask.Click += new System.EventHandler(this.sbtnTask_Click);
            // 
            // sbtnThreadPool
            // 
            this.sbtnThreadPool.Location = new System.Drawing.Point(139, 16);
            this.sbtnThreadPool.Name = "sbtnThreadPool";
            this.sbtnThreadPool.Size = new System.Drawing.Size(93, 27);
            this.sbtnThreadPool.StyleController = this.layoutControl1;
            this.sbtnThreadPool.TabIndex = 5;
            this.sbtnThreadPool.Text = "线程池异步";
            this.sbtnThreadPool.Click += new System.EventHandler(this.sbtnThreadPool_Click);
            // 
            // sbtnThread
            // 
            this.sbtnThread.Location = new System.Drawing.Point(16, 16);
            this.sbtnThread.Name = "sbtnThread";
            this.sbtnThread.Size = new System.Drawing.Size(117, 27);
            this.sbtnThread.StyleController = this.layoutControl1;
            this.sbtnThread.TabIndex = 4;
            this.sbtnThread.Text = "线程异步";
            this.sbtnThread.Click += new System.EventHandler(this.sbtnThread_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(493, 472);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.sbtnThread;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(123, 33);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.sbtnThreadPool;
            this.layoutControlItem2.Location = new System.Drawing.Point(123, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(99, 33);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.sbtnTask;
            this.layoutControlItem3.Location = new System.Drawing.Point(222, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(100, 33);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.OutInfo;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 66);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(467, 380);
            this.layoutControlItem4.Text = "信息输出：";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.sbtnAwait;
            this.layoutControlItem5.Location = new System.Drawing.Point(322, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(145, 33);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.threadTest;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 33);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(120, 33);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.threadpoolTest;
            this.layoutControlItem7.Location = new System.Drawing.Point(120, 33);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(124, 33);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.taskTest;
            this.layoutControlItem8.Location = new System.Drawing.Point(244, 33);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(111, 33);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.awaitTest;
            this.layoutControlItem9.Location = new System.Drawing.Point(355, 33);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(112, 33);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 472);
            this.Controls.Add(this.layoutControl1);
            this.Name = "Form1";
            this.Text = "异步测试";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OutInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton sbtnTask;
        private DevExpress.XtraEditors.SimpleButton sbtnThreadPool;
        private DevExpress.XtraEditors.SimpleButton sbtnThread;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton awaitTest;
        private DevExpress.XtraEditors.SimpleButton taskTest;
        private DevExpress.XtraEditors.SimpleButton threadpoolTest;
        private DevExpress.XtraEditors.SimpleButton threadTest;
        private DevExpress.XtraEditors.SimpleButton sbtnAwait;
        private DevExpress.XtraEditors.MemoEdit OutInfo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}