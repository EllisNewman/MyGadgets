namespace NeoDownloader
{
    partial class GameVersionChange
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
            this.txtBoxGameVersion = new System.Windows.Forms.TextBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnLatest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioBtnJP = new System.Windows.Forms.RadioButton();
            this.radioBtnCNT = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxGameVersion
            // 
            this.txtBoxGameVersion.Location = new System.Drawing.Point(73, 50);
            this.txtBoxGameVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxGameVersion.Name = "txtBoxGameVersion";
            this.txtBoxGameVersion.Size = new System.Drawing.Size(132, 25);
            this.txtBoxGameVersion.TabIndex = 0;
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("宋体", 10F);
            this.btnFinish.Location = new System.Drawing.Point(481, 337);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(4);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(172, 81);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "保存并确认";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(90, 96);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(100, 28);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "查询";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnLatest
            // 
            this.btnLatest.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLatest.Location = new System.Drawing.Point(56, 59);
            this.btnLatest.Margin = new System.Windows.Forms.Padding(4);
            this.btnLatest.Name = "btnLatest";
            this.btnLatest.Size = new System.Drawing.Size(144, 52);
            this.btnLatest.TabIndex = 5;
            this.btnLatest.Text = "查询";
            this.btnLatest.UseVisualStyleBackColor = true;
            this.btnLatest.Click += new System.EventHandler(this.btnLatest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLatest);
            this.groupBox1.Location = new System.Drawing.Point(41, 106);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(267, 155);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "获取当前版本号";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBoxGameVersion);
            this.groupBox2.Controls.Add(this.btnCheck);
            this.groupBox2.Location = new System.Drawing.Point(369, 106);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(284, 155);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "手动输入版本号";
            // 
            // labelResult
            // 
            this.labelResult.Font = new System.Drawing.Font("宋体", 9F);
            this.labelResult.Location = new System.Drawing.Point(24, 26);
            this.labelResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(352, 68);
            this.labelResult.TabIndex = 9;
            this.labelResult.Text = "...";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelResult);
            this.groupBox3.Location = new System.Drawing.Point(41, 311);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(413, 113);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询结果";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioBtnCNT);
            this.groupBox4.Controls.Add(this.radioBtnJP);
            this.groupBox4.Location = new System.Drawing.Point(41, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(612, 79);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "区服选择";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "查询API由matsurihi.me、esterTion提供";
            // 
            // radioBtnJP
            // 
            this.radioBtnJP.AutoSize = true;
            this.radioBtnJP.Checked = true;
            this.radioBtnJP.Location = new System.Drawing.Point(197, 36);
            this.radioBtnJP.Name = "radioBtnJP";
            this.radioBtnJP.Size = new System.Drawing.Size(58, 19);
            this.radioBtnJP.TabIndex = 0;
            this.radioBtnJP.TabStop = true;
            this.radioBtnJP.Text = "日服";
            this.radioBtnJP.UseVisualStyleBackColor = true;
            this.radioBtnJP.CheckedChanged += new System.EventHandler(this.radioBtnJP_CheckedChanged);
            // 
            // radioBtnCNT
            // 
            this.radioBtnCNT.AutoSize = true;
            this.radioBtnCNT.Location = new System.Drawing.Point(328, 36);
            this.radioBtnCNT.Name = "radioBtnCNT";
            this.radioBtnCNT.Size = new System.Drawing.Size(73, 19);
            this.radioBtnCNT.TabIndex = 1;
            this.radioBtnCNT.Text = "繁中服";
            this.radioBtnCNT.UseVisualStyleBackColor = true;
            this.radioBtnCNT.CheckedChanged += new System.EventHandler(this.radioBtnCNT_CheckedChanged);
            // 
            // GameVersionChange
            // 
            this.AcceptButton = this.btnCheck;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 458);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnFinish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GameVersionChange";
            this.Text = "区服＆版本号切换";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxGameVersion;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnLatest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioBtnCNT;
        private System.Windows.Forms.RadioButton radioBtnJP;
    }
}