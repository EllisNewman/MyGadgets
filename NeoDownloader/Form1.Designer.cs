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
            this.s_labelGameVersion = new System.Windows.Forms.Label();
            this.labelGameVersion = new System.Windows.Forms.Label();
            this.s_labelIndex = new System.Windows.Forms.Label();
            this.labelIndex = new System.Windows.Forms.Label();
            this.btnIndexDownload = new System.Windows.Forms.Button();
            this.btnGameVersionChange = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.groupMain = new System.Windows.Forms.GroupBox();
            this.btnAssetDownLoad = new System.Windows.Forms.Button();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.labelDownLoadInfo = new System.Windows.Forms.Label();
            this.groupMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // s_labelGameVersion
            // 
            this.s_labelGameVersion.AutoSize = true;
            this.s_labelGameVersion.Location = new System.Drawing.Point(13, 13);
            this.s_labelGameVersion.Name = "s_labelGameVersion";
            this.s_labelGameVersion.Size = new System.Drawing.Size(53, 12);
            this.s_labelGameVersion.TabIndex = 0;
            this.s_labelGameVersion.Text = "版本号：";
            // 
            // labelGameVersion
            // 
            this.labelGameVersion.AutoSize = true;
            this.labelGameVersion.Location = new System.Drawing.Point(72, 13);
            this.labelGameVersion.Name = "labelGameVersion";
            this.labelGameVersion.Size = new System.Drawing.Size(41, 12);
            this.labelGameVersion.TabIndex = 1;
            this.labelGameVersion.Text = "000000";
            // 
            // s_labelIndex
            // 
            this.s_labelIndex.AutoSize = true;
            this.s_labelIndex.Location = new System.Drawing.Point(255, 13);
            this.s_labelIndex.Name = "s_labelIndex";
            this.s_labelIndex.Size = new System.Drawing.Size(65, 12);
            this.s_labelIndex.TabIndex = 2;
            this.s_labelIndex.Text = "索引文件：";
            // 
            // labelIndex
            // 
            this.labelIndex.AutoSize = true;
            this.labelIndex.Location = new System.Drawing.Point(327, 13);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(41, 12);
            this.labelIndex.TabIndex = 3;
            this.labelIndex.Text = "不存在";
            // 
            // btnIndexDownload
            // 
            this.btnIndexDownload.Location = new System.Drawing.Point(389, 8);
            this.btnIndexDownload.Name = "btnIndexDownload";
            this.btnIndexDownload.Size = new System.Drawing.Size(90, 23);
            this.btnIndexDownload.TabIndex = 2;
            this.btnIndexDownload.Text = "下载索引文件";
            this.btnIndexDownload.UseVisualStyleBackColor = true;
            this.btnIndexDownload.Click += new System.EventHandler(this.btnIndexDownload_Click);
            // 
            // btnGameVersionChange
            // 
            this.btnGameVersionChange.Location = new System.Drawing.Point(128, 8);
            this.btnGameVersionChange.Name = "btnGameVersionChange";
            this.btnGameVersionChange.Size = new System.Drawing.Size(90, 23);
            this.btnGameVersionChange.TabIndex = 1;
            this.btnGameVersionChange.Text = "版本号切换";
            this.btnGameVersionChange.UseVisualStyleBackColor = true;
            this.btnGameVersionChange.Click += new System.EventHandler(this.btnGameVersionChange_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(799, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.Text = "使用说明";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // groupMain
            // 
            this.groupMain.Controls.Add(this.listBoxResult);
            this.groupMain.Controls.Add(this.btnSearch);
            this.groupMain.Controls.Add(this.label1);
            this.groupMain.Controls.Add(this.txtBoxSearch);
            this.groupMain.Location = new System.Drawing.Point(15, 37);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(859, 465);
            this.groupMain.TabIndex = 8;
            this.groupMain.TabStop = false;
            // 
            // btnAssetDownLoad
            // 
            this.btnAssetDownLoad.Location = new System.Drawing.Point(750, 552);
            this.btnAssetDownLoad.Name = "btnAssetDownLoad";
            this.btnAssetDownLoad.Size = new System.Drawing.Size(124, 42);
            this.btnAssetDownLoad.TabIndex = 10;
            this.btnAssetDownLoad.Text = "下载";
            this.btnAssetDownLoad.UseVisualStyleBackColor = true;
            this.btnAssetDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // listBoxResult
            // 
            this.listBoxResult.Font = new System.Drawing.Font("宋体", 14F);
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.ItemHeight = 19;
            this.listBoxResult.Location = new System.Drawing.Point(30, 62);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxResult.Size = new System.Drawing.Size(477, 384);
            this.listBoxResult.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(374, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "输入查询关键字：";
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(135, 21);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(218, 21);
            this.txtBoxSearch.TabIndex = 0;
            // 
            // labelDownLoadInfo
            // 
            this.labelDownLoadInfo.Font = new System.Drawing.Font("宋体", 11F);
            this.labelDownLoadInfo.Location = new System.Drawing.Point(45, 528);
            this.labelDownLoadInfo.Name = "labelDownLoadInfo";
            this.labelDownLoadInfo.Size = new System.Drawing.Size(684, 66);
            this.labelDownLoadInfo.TabIndex = 9;
            this.labelDownLoadInfo.Text = "label2";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 613);
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
            this.Name = "Form1";
            this.Text = "NeoDownloader a0.1";
            this.groupMain.ResumeLayout(false);
            this.groupMain.PerformLayout();
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
    }
}

