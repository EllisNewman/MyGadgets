namespace NeoDownloader
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.s_labelGameVersion = new System.Windows.Forms.Label();
            this.labelGameVersion = new System.Windows.Forms.Label();
            this.s_labelIndex = new System.Windows.Forms.Label();
            this.labelIndex = new System.Windows.Forms.Label();
            this.btnIndexDownload = new System.Windows.Forms.Button();
            this.btnGameVersionChange = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupMain = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnAssetDownLoad = new System.Windows.Forms.Button();
            this.labelDownLoadInfo = new System.Windows.Forms.Label();
            this.btnOpenDownloadPath = new System.Windows.Forms.Button();
            this.labelVersionTime = new System.Windows.Forms.Label();
            this.IndexDownloadWorker = new System.ComponentModel.BackgroundWorker();
            this.progressDownload = new System.Windows.Forms.ProgressBar();
            this.AssetDowloadWorker = new System.ComponentModel.BackgroundWorker();
            this.labelMultiProgress = new System.Windows.Forms.Label();
            this.btnCancelDownload = new System.Windows.Forms.Button();
            this.groupMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // s_labelGameVersion
            // 
            this.s_labelGameVersion.AutoSize = true;
            this.s_labelGameVersion.Location = new System.Drawing.Point(17, 16);
            this.s_labelGameVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.s_labelGameVersion.Name = "s_labelGameVersion";
            this.s_labelGameVersion.Size = new System.Drawing.Size(67, 15);
            this.s_labelGameVersion.TabIndex = 0;
            this.s_labelGameVersion.Text = "版本号：";
            // 
            // labelGameVersion
            // 
            this.labelGameVersion.AutoSize = true;
            this.labelGameVersion.Location = new System.Drawing.Point(96, 16);
            this.labelGameVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGameVersion.Name = "labelGameVersion";
            this.labelGameVersion.Size = new System.Drawing.Size(55, 15);
            this.labelGameVersion.TabIndex = 1;
            this.labelGameVersion.Text = "000000";
            // 
            // s_labelIndex
            // 
            this.s_labelIndex.AutoSize = true;
            this.s_labelIndex.Location = new System.Drawing.Point(340, 16);
            this.s_labelIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.s_labelIndex.Name = "s_labelIndex";
            this.s_labelIndex.Size = new System.Drawing.Size(82, 15);
            this.s_labelIndex.TabIndex = 2;
            this.s_labelIndex.Text = "索引文件：";
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.labelIndex.Location = new System.Drawing.Point(436, 16);
            this.labelIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(52, 15);
            this.labelIndex.TabIndex = 3;
            this.labelIndex.Text = "不存在";
            // 
            // btnIndexDownload
            // 
            this.btnIndexDownload.Location = new System.Drawing.Point(519, 10);
            this.btnIndexDownload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIndexDownload.Name = "btnIndexDownload";
            this.btnIndexDownload.Size = new System.Drawing.Size(120, 29);
            this.btnIndexDownload.TabIndex = 2;
            this.btnIndexDownload.Text = "下载索引文件";
            this.btnIndexDownload.UseVisualStyleBackColor = true;
            this.btnIndexDownload.Click += new System.EventHandler(this.btnIndexDownload_Click);
            // 
            // btnGameVersionChange
            // 
            this.btnGameVersionChange.Location = new System.Drawing.Point(171, 10);
            this.btnGameVersionChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGameVersionChange.Name = "btnGameVersionChange";
            this.btnGameVersionChange.Size = new System.Drawing.Size(120, 29);
            this.btnGameVersionChange.TabIndex = 1;
            this.btnGameVersionChange.Text = "版本号切换";
            this.btnGameVersionChange.UseVisualStyleBackColor = true;
            this.btnGameVersionChange.Click += new System.EventHandler(this.btnGameVersionChange_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(1129, 15);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(100, 29);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.Text = "使用说明";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupMain
            // 
            this.groupMain.Controls.Add(this.groupBox1);
            this.groupMain.Controls.Add(this.btnCheck);
            this.groupMain.Controls.Add(this.listBoxResult);
            this.groupMain.Controls.Add(this.btnSearch);
            this.groupMain.Controls.Add(this.label1);
            this.groupMain.Controls.Add(this.txtBoxSearch);
            this.groupMain.Location = new System.Drawing.Point(20, 46);
            this.groupMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupMain.Name = "groupMain";
            this.groupMain.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupMain.Size = new System.Drawing.Size(1209, 581);
            this.groupMain.TabIndex = 8;
            this.groupMain.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(831, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(359, 521);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "可能用到的关键字和对照表：";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(23, 271);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(317, 246);
            this.label4.TabIndex = 8;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 124);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(239, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "icon_[偶像id+偶像简称][卡面id]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 96);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "卡面头像：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 210);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "ch_[类别]_[偶像id+偶像简称]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 184);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "cb_[类别]_[偶像id+偶像简称]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "模型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "[偶像id+偶像简称][卡面id]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "卡面：";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(637, 25);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(148, 29);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.Text = "与前个版本对比";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // listBoxResult
            // 
            this.listBoxResult.Font = new System.Drawing.Font("宋体", 14F);
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.ItemHeight = 23;
            this.listBoxResult.Location = new System.Drawing.Point(44, 72);
            this.listBoxResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxResult.Size = new System.Drawing.Size(740, 464);
            this.listBoxResult.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(497, 25);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 29);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入查询关键字：";
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(179, 28);
            this.txtBoxSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(289, 25);
            this.txtBoxSearch.TabIndex = 0;
            // 
            // btnAssetDownLoad
            // 
            this.btnAssetDownLoad.Location = new System.Drawing.Point(1064, 690);
            this.btnAssetDownLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAssetDownLoad.Name = "btnAssetDownLoad";
            this.btnAssetDownLoad.Size = new System.Drawing.Size(165, 52);
            this.btnAssetDownLoad.TabIndex = 10;
            this.btnAssetDownLoad.Text = "下载";
            this.btnAssetDownLoad.UseVisualStyleBackColor = true;
            this.btnAssetDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // labelDownLoadInfo
            // 
            this.labelDownLoadInfo.Font = new System.Drawing.Font("宋体", 11F);
            this.labelDownLoadInfo.Location = new System.Drawing.Point(60, 668);
            this.labelDownLoadInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDownLoadInfo.Name = "labelDownLoadInfo";
            this.labelDownLoadInfo.Size = new System.Drawing.Size(963, 38);
            this.labelDownLoadInfo.TabIndex = 9;
            this.labelDownLoadInfo.Text = "label2";
            // 
            // btnOpenDownloadPath
            // 
            this.btnOpenDownloadPath.Location = new System.Drawing.Point(1064, 635);
            this.btnOpenDownloadPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenDownloadPath.Name = "btnOpenDownloadPath";
            this.btnOpenDownloadPath.Size = new System.Drawing.Size(165, 40);
            this.btnOpenDownloadPath.TabIndex = 4;
            this.btnOpenDownloadPath.Text = "打开下载目录";
            this.btnOpenDownloadPath.UseVisualStyleBackColor = true;
            this.btnOpenDownloadPath.Click += new System.EventHandler(this.btnOpenDownloadPath_Click);
            // 
            // labelVersionTime
            // 
            this.labelVersionTime.AutoSize = true;
            this.labelVersionTime.Location = new System.Drawing.Point(697, 16);
            this.labelVersionTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVersionTime.Name = "labelVersionTime";
            this.labelVersionTime.Size = new System.Drawing.Size(63, 15);
            this.labelVersionTime.TabIndex = 12;
            this.labelVersionTime.Text = "label10";
            // 
            // IndexDownloadWorker
            // 
            this.IndexDownloadWorker.WorkerReportsProgress = true;
            this.IndexDownloadWorker.WorkerSupportsCancellation = true;
            this.IndexDownloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.IndexDownloadWorker_DoWork);
            this.IndexDownloadWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.IndexDownloadWorker_ProgressChanged);
            this.IndexDownloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.IndexDownloadWorker_RunWorkerCompleted);
            // 
            // progressDownload
            // 
            this.progressDownload.Location = new System.Drawing.Point(59, 750);
            this.progressDownload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressDownload.Name = "progressDownload";
            this.progressDownload.Size = new System.Drawing.Size(1171, 29);
            this.progressDownload.TabIndex = 13;
            // 
            // AssetDowloadWorker
            // 
            this.AssetDowloadWorker.WorkerReportsProgress = true;
            this.AssetDowloadWorker.WorkerSupportsCancellation = true;
            this.AssetDowloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AssetDowloadWorker_DoWork);
            this.AssetDowloadWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.AssetDowloadWorker_ProgressChanged);
            this.AssetDowloadWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AssetDowloadWorker_RunWorkerCompleted);
            // 
            // labelMultiProgress
            // 
            this.labelMultiProgress.Font = new System.Drawing.Font("宋体", 11F);
            this.labelMultiProgress.Location = new System.Drawing.Point(60, 705);
            this.labelMultiProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMultiProgress.Name = "labelMultiProgress";
            this.labelMultiProgress.Size = new System.Drawing.Size(979, 29);
            this.labelMultiProgress.TabIndex = 14;
            this.labelMultiProgress.Text = "label10";
            // 
            // btnCancelDownload
            // 
            this.btnCancelDownload.Location = new System.Drawing.Point(1064, 690);
            this.btnCancelDownload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelDownload.Name = "btnCancelDownload";
            this.btnCancelDownload.Size = new System.Drawing.Size(165, 52);
            this.btnCancelDownload.TabIndex = 15;
            this.btnCancelDownload.Text = "取消";
            this.btnCancelDownload.UseVisualStyleBackColor = true;
            this.btnCancelDownload.Click += new System.EventHandler(this.btnCancelDownload_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 794);
            this.Controls.Add(this.btnCancelDownload);
            this.Controls.Add(this.labelMultiProgress);
            this.Controls.Add(this.progressDownload);
            this.Controls.Add(this.labelVersionTime);
            this.Controls.Add(this.btnOpenDownloadPath);
            this.Controls.Add(this.btnAssetDownLoad);
            this.Controls.Add(this.labelDownLoadInfo);
            this.Controls.Add(this.groupMain);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnGameVersionChange);
            this.Controls.Add(this.btnIndexDownload);
            this.Controls.Add(this.labelIndex);
            this.Controls.Add(this.s_labelIndex);
            this.Controls.Add(this.labelGameVersion);
            this.Controls.Add(this.s_labelGameVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "NeoDownloader a0.4";
            this.groupMain.ResumeLayout(false);
            this.groupMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label s_labelGameVersion;
        private System.Windows.Forms.Label labelGameVersion;
        private System.Windows.Forms.Label s_labelIndex;
        private System.Windows.Forms.Label labelIndex;
        private System.Windows.Forms.Button btnIndexDownload;
        private System.Windows.Forms.Button btnGameVersionChange;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.GroupBox groupMain;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.ListBox listBoxResult;
        private System.Windows.Forms.Button btnAssetDownLoad;
        private System.Windows.Forms.Label labelDownLoadInfo;
        private System.Windows.Forms.Button btnOpenDownloadPath;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelVersionTime;
        private System.ComponentModel.BackgroundWorker IndexDownloadWorker;
        private System.Windows.Forms.ProgressBar progressDownload;
        private System.ComponentModel.BackgroundWorker AssetDowloadWorker;
        private System.Windows.Forms.Label labelMultiProgress;
        private System.Windows.Forms.Button btnCancelDownload;
    }
}

