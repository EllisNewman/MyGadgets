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
            this.labelInput = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnLatest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxGameVersion
            // 
            this.txtBoxGameVersion.Location = new System.Drawing.Point(56, 69);
            this.txtBoxGameVersion.Name = "txtBoxGameVersion";
            this.txtBoxGameVersion.Size = new System.Drawing.Size(100, 21);
            this.txtBoxGameVersion.TabIndex = 0;
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(18, 31);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(101, 12);
            this.labelInput.TabIndex = 1;
            this.labelInput.Text = "输入目标版本号：";
            // 
            // btnFinish
            // 
            this.btnFinish.Font = new System.Drawing.Font("宋体", 10F);
            this.btnFinish.Location = new System.Drawing.Point(361, 274);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(129, 65);
            this.btnFinish.TabIndex = 2;
            this.btnFinish.Text = "保存并确认";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(70, 117);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "查询";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnLatest
            // 
            this.btnLatest.Font = new System.Drawing.Font("宋体", 10F);
            this.btnLatest.Location = new System.Drawing.Point(36, 61);
            this.btnLatest.Name = "btnLatest";
            this.btnLatest.Size = new System.Drawing.Size(128, 69);
            this.btnLatest.TabIndex = 5;
            this.btnLatest.Text = "查询最新版本";
            this.btnLatest.UseVisualStyleBackColor = true;
            this.btnLatest.Click += new System.EventHandler(this.btnLatest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "你可以选择：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLatest);
            this.groupBox1.Location = new System.Drawing.Point(31, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 193);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "自动获取";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelInput);
            this.groupBox2.Controls.Add(this.txtBoxGameVersion);
            this.groupBox2.Controls.Add(this.btnCheck);
            this.groupBox2.Location = new System.Drawing.Point(277, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 193);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "手动输入";
            // 
            // labelResult
            // 
            this.labelResult.Location = new System.Drawing.Point(18, 21);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(264, 54);
            this.labelResult.TabIndex = 9;
            this.labelResult.Text = "...";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(337, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "查询API由matsurihi.me提供";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelResult);
            this.groupBox3.Location = new System.Drawing.Point(31, 261);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(310, 78);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询结果";
            // 
            // GameVersionChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 366);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFinish);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GameVersionChange";
            this.Text = "版本号切换";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxGameVersion;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnLatest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}