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
            this.labelIndexDownload = new System.Windows.Forms.Label();
            this.groupMain = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
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
            this.btnHelp.Location = new System.Drawing.Point(818, 8);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.Text = "使用说明";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // labelIndexDownload
            // 
            this.labelIndexDownload.AutoSize = true;
            this.labelIndexDownload.Location = new System.Drawing.Point(485, 13);
            this.labelIndexDownload.Name = "labelIndexDownload";
            this.labelIndexDownload.Size = new System.Drawing.Size(41, 12);
            this.labelIndexDownload.TabIndex = 7;
            this.labelIndexDownload.Text = "label1";
            // 
            // groupMain
            // 
            this.groupMain.Controls.Add(this.listBox1);
            this.groupMain.Controls.Add(this.button1);
            this.groupMain.Controls.Add(this.label1);
            this.groupMain.Controls.Add(this.textBox1);
            this.groupMain.Location = new System.Drawing.Point(15, 37);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(878, 465);
            this.groupMain.TabIndex = 8;
            this.groupMain.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(218, 21);
            this.textBox1.TabIndex = 0;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(30, 62);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(507, 340);
            this.listBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 613);
            this.Controls.Add(this.groupMain);
            this.Controls.Add(this.labelIndexDownload);
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
        private System.Windows.Forms.Label labelIndexDownload;
        private System.Windows.Forms.GroupBox groupMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

