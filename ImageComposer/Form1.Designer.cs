namespace ImageComposer
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
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.tglRareWide = new System.Windows.Forms.RadioButton();
            this.tglRareUpright = new System.Windows.Forms.RadioButton();
            this.tglGasha = new System.Windows.Forms.RadioButton();
            this.labelDescription = new System.Windows.Forms.Label();
            this.panelRareUpright = new System.Windows.Forms.Panel();
            this.radioBoth = new System.Windows.Forms.RadioButton();
            this.radioWithFrame = new System.Windows.Forms.RadioButton();
            this.radioNoFrame = new System.Windows.Forms.RadioButton();
            this.panelGashaInfo = new System.Windows.Forms.Panel();
            this.labelGashaInfoHint = new System.Windows.Forms.Label();
            this.radioOldReso = new System.Windows.Forms.RadioButton();
            this.radioNewReso = new System.Windows.Forms.RadioButton();
            this.labelProcessing = new System.Windows.Forms.Label();
            this.panelGasha = new System.Windows.Forms.Panel();
            this.radioGashaBoth = new System.Windows.Forms.RadioButton();
            this.radioWide = new System.Windows.Forms.RadioButton();
            this.radioOrigin = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tglEvent = new System.Windows.Forms.RadioButton();
            this.tglWhiteBoard = new System.Windows.Forms.RadioButton();
            this.tglGashaInfo = new System.Windows.Forms.RadioButton();
            this.panelCard = new System.Windows.Forms.Panel();
            this.radioCardBoth = new System.Windows.Forms.RadioButton();
            this.radioCardWide = new System.Windows.Forms.RadioButton();
            this.radioCardOrigin = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.panelEvent = new System.Windows.Forms.Panel();
            this.radioEventBoth = new System.Windows.Forms.RadioButton();
            this.radioEventFullWithLogo = new System.Windows.Forms.RadioButton();
            this.radioEventFull = new System.Windows.Forms.RadioButton();
            this.panelWhiteBoard = new System.Windows.Forms.Panel();
            this.radioWBMid = new System.Windows.Forms.RadioButton();
            this.radioWBSmall = new System.Windows.Forms.RadioButton();
            this.radioWBLarge = new System.Windows.Forms.RadioButton();
            this.panelRareUpright.SuspendLayout();
            this.panelGashaInfo.SuspendLayout();
            this.panelGasha.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelCard.SuspendLayout();
            this.panelEvent.SuspendLayout();
            this.panelWhiteBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(612, 348);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(184, 64);
            this.buttonOpenFile.TabIndex = 0;
            this.buttonOpenFile.Text = "打开文件";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // tglRareWide
            // 
            this.tglRareWide.AutoSize = true;
            this.tglRareWide.Checked = true;
            this.tglRareWide.Location = new System.Drawing.Point(19, 35);
            this.tglRareWide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tglRareWide.Name = "tglRareWide";
            this.tglRareWide.Size = new System.Drawing.Size(180, 19);
            this.tglRareWide.TabIndex = 1;
            this.tglRareWide.TabStop = true;
            this.tglRareWide.Text = "SSR卡面 横版大图合成";
            this.tglRareWide.UseVisualStyleBackColor = true;
            this.tglRareWide.CheckedChanged += new System.EventHandler(this.CheckToggleChanged);
            // 
            // tglRareUpright
            // 
            this.tglRareUpright.AutoSize = true;
            this.tglRareUpright.Location = new System.Drawing.Point(19, 156);
            this.tglRareUpright.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tglRareUpright.Name = "tglRareUpright";
            this.tglRareUpright.Size = new System.Drawing.Size(180, 19);
            this.tglRareUpright.TabIndex = 2;
            this.tglRareUpright.Text = "SSR卡面 竖版小图合成";
            this.tglRareUpright.UseVisualStyleBackColor = true;
            this.tglRareUpright.CheckedChanged += new System.EventHandler(this.CheckToggleChanged);
            // 
            // tglGasha
            // 
            this.tglGasha.AutoSize = true;
            this.tglGasha.Location = new System.Drawing.Point(17, 76);
            this.tglGasha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tglGasha.Name = "tglGasha";
            this.tglGasha.Size = new System.Drawing.Size(186, 19);
            this.tglGasha.TabIndex = 3;
            this.tglGasha.Text = "卡池界面 横版图像合成";
            this.tglGasha.UseVisualStyleBackColor = true;
            this.tglGasha.CheckedChanged += new System.EventHandler(this.CheckToggleChanged);
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(31, 38);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(423, 34);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "用于将某种形式的图片变成另一种形式。";
            // 
            // panelRareUpright
            // 
            this.panelRareUpright.Controls.Add(this.radioBoth);
            this.panelRareUpright.Controls.Add(this.radioWithFrame);
            this.panelRareUpright.Controls.Add(this.radioNoFrame);
            this.panelRareUpright.Location = new System.Drawing.Point(275, 228);
            this.panelRareUpright.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelRareUpright.Name = "panelRareUpright";
            this.panelRareUpright.Size = new System.Drawing.Size(505, 31);
            this.panelRareUpright.TabIndex = 7;
            // 
            // radioBoth
            // 
            this.radioBoth.AutoSize = true;
            this.radioBoth.Checked = true;
            this.radioBoth.Location = new System.Drawing.Point(376, 4);
            this.radioBoth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioBoth.Name = "radioBoth";
            this.radioBoth.Size = new System.Drawing.Size(103, 19);
            this.radioBoth.TabIndex = 0;
            this.radioBoth.TabStop = true;
            this.radioBoth.Text = "我全都要！";
            this.radioBoth.UseVisualStyleBackColor = true;
            this.radioBoth.CheckedChanged += new System.EventHandler(this.UprightTypeChanged);
            // 
            // radioWithFrame
            // 
            this.radioWithFrame.AutoSize = true;
            this.radioWithFrame.Location = new System.Drawing.Point(161, 4);
            this.radioWithFrame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioWithFrame.Name = "radioWithFrame";
            this.radioWithFrame.Size = new System.Drawing.Size(193, 19);
            this.radioWithFrame.TabIndex = 0;
            this.radioWithFrame.Text = "完整图，含稀有度等图标";
            this.radioWithFrame.UseVisualStyleBackColor = true;
            this.radioWithFrame.CheckedChanged += new System.EventHandler(this.UprightTypeChanged);
            // 
            // radioNoFrame
            // 
            this.radioNoFrame.AutoSize = true;
            this.radioNoFrame.Location = new System.Drawing.Point(4, 4);
            this.radioNoFrame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioNoFrame.Name = "radioNoFrame";
            this.radioNoFrame.Size = new System.Drawing.Size(103, 19);
            this.radioNoFrame.TabIndex = 0;
            this.radioNoFrame.Text = "无图标原图";
            this.radioNoFrame.UseVisualStyleBackColor = true;
            this.radioNoFrame.CheckedChanged += new System.EventHandler(this.UprightTypeChanged);
            // 
            // panelGashaInfo
            // 
            this.panelGashaInfo.Controls.Add(this.labelGashaInfoHint);
            this.panelGashaInfo.Controls.Add(this.radioOldReso);
            this.panelGashaInfo.Controls.Add(this.radioNewReso);
            this.panelGashaInfo.Location = new System.Drawing.Point(276, 266);
            this.panelGashaInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelGashaInfo.Name = "panelGashaInfo";
            this.panelGashaInfo.Size = new System.Drawing.Size(507, 38);
            this.panelGashaInfo.TabIndex = 14;
            // 
            // labelGashaInfoHint
            // 
            this.labelGashaInfoHint.AutoSize = true;
            this.labelGashaInfoHint.Location = new System.Drawing.Point(317, 8);
            this.labelGashaInfoHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGashaInfoHint.Name = "labelGashaInfoHint";
            this.labelGashaInfoHint.Size = new System.Drawing.Size(129, 15);
            this.labelGashaInfoHint.TabIndex = 2;
            this.labelGashaInfoHint.Text = "注：新版自tb02起";
            // 
            // radioOldReso
            // 
            this.radioOldReso.AutoSize = true;
            this.radioOldReso.Location = new System.Drawing.Point(161, 6);
            this.radioOldReso.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioOldReso.Name = "radioOldReso";
            this.radioOldReso.Size = new System.Drawing.Size(118, 19);
            this.radioOldReso.TabIndex = 1;
            this.radioOldReso.Text = "低分辨率旧版";
            this.radioOldReso.UseVisualStyleBackColor = true;
            this.radioOldReso.CheckedChanged += new System.EventHandler(this.GashaInfoChanged);
            // 
            // radioNewReso
            // 
            this.radioNewReso.AutoSize = true;
            this.radioNewReso.Checked = true;
            this.radioNewReso.Location = new System.Drawing.Point(4, 6);
            this.radioNewReso.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioNewReso.Name = "radioNewReso";
            this.radioNewReso.Size = new System.Drawing.Size(118, 19);
            this.radioNewReso.TabIndex = 0;
            this.radioNewReso.TabStop = true;
            this.radioNewReso.Text = "高分辨率新版";
            this.radioNewReso.UseVisualStyleBackColor = true;
            this.radioNewReso.CheckedChanged += new System.EventHandler(this.GashaInfoChanged);
            // 
            // labelProcessing
            // 
            this.labelProcessing.AutoSize = true;
            this.labelProcessing.Location = new System.Drawing.Point(371, 392);
            this.labelProcessing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProcessing.Name = "labelProcessing";
            this.labelProcessing.Size = new System.Drawing.Size(187, 15);
            this.labelProcessing.TabIndex = 8;
            this.labelProcessing.Text = "正在进行合成，请稍候……";
            this.labelProcessing.Visible = false;
            // 
            // panelGasha
            // 
            this.panelGasha.Controls.Add(this.radioGashaBoth);
            this.panelGasha.Controls.Add(this.radioWide);
            this.panelGasha.Controls.Add(this.radioOrigin);
            this.panelGasha.Location = new System.Drawing.Point(276, 146);
            this.panelGasha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelGasha.Name = "panelGasha";
            this.panelGasha.Size = new System.Drawing.Size(463, 36);
            this.panelGasha.TabIndex = 9;
            // 
            // radioGashaBoth
            // 
            this.radioGashaBoth.AutoSize = true;
            this.radioGashaBoth.Location = new System.Drawing.Point(344, 5);
            this.radioGashaBoth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioGashaBoth.Name = "radioGashaBoth";
            this.radioGashaBoth.Size = new System.Drawing.Size(103, 19);
            this.radioGashaBoth.TabIndex = 0;
            this.radioGashaBoth.Text = "我全都要！";
            this.radioGashaBoth.UseVisualStyleBackColor = true;
            this.radioGashaBoth.CheckedChanged += new System.EventHandler(this.CheckGashaChanged);
            // 
            // radioWide
            // 
            this.radioWide.AutoSize = true;
            this.radioWide.Location = new System.Drawing.Point(163, 5);
            this.radioWide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioWide.Name = "radioWide";
            this.radioWide.Size = new System.Drawing.Size(148, 19);
            this.radioWide.TabIndex = 0;
            this.radioWide.Text = "长图，以适应宽屏";
            this.radioWide.UseVisualStyleBackColor = true;
            this.radioWide.CheckedChanged += new System.EventHandler(this.CheckGashaChanged);
            // 
            // radioOrigin
            // 
            this.radioOrigin.AutoSize = true;
            this.radioOrigin.Checked = true;
            this.radioOrigin.Location = new System.Drawing.Point(4, 5);
            this.radioOrigin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioOrigin.Name = "radioOrigin";
            this.radioOrigin.Size = new System.Drawing.Size(118, 19);
            this.radioOrigin.TabIndex = 0;
            this.radioOrigin.TabStop = true;
            this.radioOrigin.Text = "正常比例原图";
            this.radioOrigin.UseVisualStyleBackColor = true;
            this.radioOrigin.CheckedChanged += new System.EventHandler(this.CheckGashaChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tglEvent);
            this.groupBox1.Controls.Add(this.tglWhiteBoard);
            this.groupBox1.Controls.Add(this.tglRareWide);
            this.groupBox1.Controls.Add(this.tglRareUpright);
            this.groupBox1.Controls.Add(this.tglGashaInfo);
            this.groupBox1.Controls.Add(this.tglGasha);
            this.groupBox1.Location = new System.Drawing.Point(16, 75);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(244, 288);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "功能选择";
            // 
            // tglEvent
            // 
            this.tglEvent.AutoSize = true;
            this.tglEvent.Location = new System.Drawing.Point(19, 116);
            this.tglEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tglEvent.Name = "tglEvent";
            this.tglEvent.Size = new System.Drawing.Size(186, 19);
            this.tglEvent.TabIndex = 5;
            this.tglEvent.Text = "活动界面 完整图像合成";
            this.tglEvent.UseVisualStyleBackColor = true;
            // 
            // tglWhiteBoard
            // 
            this.tglWhiteBoard.AutoSize = true;
            this.tglWhiteBoard.Location = new System.Drawing.Point(19, 238);
            this.tglWhiteBoard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tglWhiteBoard.Name = "tglWhiteBoard";
            this.tglWhiteBoard.Size = new System.Drawing.Size(103, 19);
            this.tglWhiteBoard.TabIndex = 4;
            this.tglWhiteBoard.Text = "白板图提取";
            this.tglWhiteBoard.UseVisualStyleBackColor = true;
            // 
            // tglGashaInfo
            // 
            this.tglGashaInfo.AutoSize = true;
            this.tglGashaInfo.Location = new System.Drawing.Point(17, 198);
            this.tglGashaInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tglGashaInfo.Name = "tglGashaInfo";
            this.tglGashaInfo.Size = new System.Drawing.Size(201, 19);
            this.tglGashaInfo.TabIndex = 3;
            this.tglGashaInfo.Text = "卡池界面 信息介绍图合成";
            this.tglGashaInfo.UseVisualStyleBackColor = true;
            this.tglGashaInfo.CheckedChanged += new System.EventHandler(this.CheckToggleChanged);
            // 
            // panelCard
            // 
            this.panelCard.Controls.Add(this.radioCardBoth);
            this.panelCard.Controls.Add(this.radioCardWide);
            this.panelCard.Controls.Add(this.radioCardOrigin);
            this.panelCard.Location = new System.Drawing.Point(276, 106);
            this.panelCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(463, 32);
            this.panelCard.TabIndex = 12;
            // 
            // radioCardBoth
            // 
            this.radioCardBoth.AutoSize = true;
            this.radioCardBoth.Location = new System.Drawing.Point(343, 4);
            this.radioCardBoth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioCardBoth.Name = "radioCardBoth";
            this.radioCardBoth.Size = new System.Drawing.Size(103, 19);
            this.radioCardBoth.TabIndex = 0;
            this.radioCardBoth.Text = "我全都要！";
            this.radioCardBoth.UseVisualStyleBackColor = true;
            this.radioCardBoth.CheckedChanged += new System.EventHandler(this.CheckCardChanged);
            // 
            // radioCardWide
            // 
            this.radioCardWide.AutoSize = true;
            this.radioCardWide.Location = new System.Drawing.Point(161, 4);
            this.radioCardWide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioCardWide.Name = "radioCardWide";
            this.radioCardWide.Size = new System.Drawing.Size(148, 19);
            this.radioCardWide.TabIndex = 0;
            this.radioCardWide.Text = "长图（如果存在）";
            this.radioCardWide.UseVisualStyleBackColor = true;
            this.radioCardWide.CheckedChanged += new System.EventHandler(this.CheckCardChanged);
            // 
            // radioCardOrigin
            // 
            this.radioCardOrigin.AutoSize = true;
            this.radioCardOrigin.Checked = true;
            this.radioCardOrigin.Location = new System.Drawing.Point(4, 4);
            this.radioCardOrigin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioCardOrigin.Name = "radioCardOrigin";
            this.radioCardOrigin.Size = new System.Drawing.Size(118, 19);
            this.radioCardOrigin.TabIndex = 0;
            this.radioCardOrigin.TabStop = true;
            this.radioCardOrigin.Text = "正常比例原图";
            this.radioCardOrigin.UseVisualStyleBackColor = true;
            this.radioCardOrigin.CheckedChanged += new System.EventHandler(this.CheckCardChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(651, 29);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 34);
            this.button1.TabIndex = 11;
            this.button1.Text = "使用说明";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panelEvent
            // 
            this.panelEvent.Controls.Add(this.radioEventBoth);
            this.panelEvent.Controls.Add(this.radioEventFullWithLogo);
            this.panelEvent.Controls.Add(this.radioEventFull);
            this.panelEvent.Location = new System.Drawing.Point(275, 188);
            this.panelEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelEvent.Name = "panelEvent";
            this.panelEvent.Size = new System.Drawing.Size(505, 32);
            this.panelEvent.TabIndex = 15;
            // 
            // radioEventBoth
            // 
            this.radioEventBoth.AutoSize = true;
            this.radioEventBoth.Location = new System.Drawing.Point(376, 4);
            this.radioEventBoth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioEventBoth.Name = "radioEventBoth";
            this.radioEventBoth.Size = new System.Drawing.Size(103, 19);
            this.radioEventBoth.TabIndex = 0;
            this.radioEventBoth.Text = "我全都要！";
            this.radioEventBoth.UseVisualStyleBackColor = true;
            this.radioEventBoth.CheckedChanged += new System.EventHandler(this.CheckEventChanged);
            // 
            // radioEventFullWithLogo
            // 
            this.radioEventFullWithLogo.AutoSize = true;
            this.radioEventFullWithLogo.Checked = true;
            this.radioEventFullWithLogo.Location = new System.Drawing.Point(133, 4);
            this.radioEventFullWithLogo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioEventFullWithLogo.Name = "radioEventFullWithLogo";
            this.radioEventFullWithLogo.Size = new System.Drawing.Size(210, 19);
            this.radioEventFullWithLogo.TabIndex = 0;
            this.radioEventFullWithLogo.TabStop = true;
            this.radioEventFullWithLogo.Text = "完整大图（带有活动LOGO）";
            this.radioEventFullWithLogo.UseVisualStyleBackColor = true;
            this.radioEventFullWithLogo.CheckedChanged += new System.EventHandler(this.CheckEventChanged);
            // 
            // radioEventFull
            // 
            this.radioEventFull.AutoSize = true;
            this.radioEventFull.Location = new System.Drawing.Point(4, 4);
            this.radioEventFull.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioEventFull.Name = "radioEventFull";
            this.radioEventFull.Size = new System.Drawing.Size(88, 19);
            this.radioEventFull.TabIndex = 0;
            this.radioEventFull.Text = "完整大图";
            this.radioEventFull.UseVisualStyleBackColor = true;
            this.radioEventFull.CheckedChanged += new System.EventHandler(this.CheckEventChanged);
            // 
            // panelWhiteBoard
            // 
            this.panelWhiteBoard.Controls.Add(this.radioWBLarge);
            this.panelWhiteBoard.Controls.Add(this.radioWBMid);
            this.panelWhiteBoard.Controls.Add(this.radioWBSmall);
            this.panelWhiteBoard.Location = new System.Drawing.Point(276, 311);
            this.panelWhiteBoard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelWhiteBoard.Name = "panelWhiteBoard";
            this.panelWhiteBoard.Size = new System.Drawing.Size(507, 38);
            this.panelWhiteBoard.TabIndex = 16;
            // 
            // radioWBMid
            // 
            this.radioWBMid.AutoSize = true;
            this.radioWBMid.Location = new System.Drawing.Point(161, 6);
            this.radioWBMid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioWBMid.Name = "radioWBMid";
            this.radioWBMid.Size = new System.Drawing.Size(84, 19);
            this.radioWBMid.TabIndex = 1;
            this.radioWBMid.Text = "512x512";
            this.radioWBMid.UseVisualStyleBackColor = true;
            this.radioWBMid.CheckedChanged += new System.EventHandler(this.WhiteBoardChanged);
            // 
            // radioWBSmall
            // 
            this.radioWBSmall.AutoSize = true;
            this.radioWBSmall.Checked = true;
            this.radioWBSmall.Location = new System.Drawing.Point(4, 6);
            this.radioWBSmall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioWBSmall.Name = "radioWBSmall";
            this.radioWBSmall.Size = new System.Drawing.Size(84, 19);
            this.radioWBSmall.TabIndex = 0;
            this.radioWBSmall.TabStop = true;
            this.radioWBSmall.Text = "512x256";
            this.radioWBSmall.UseVisualStyleBackColor = true;
            this.radioWBSmall.CheckedChanged += new System.EventHandler(this.WhiteBoardChanged);
            // 
            // radioWBLarge
            // 
            this.radioWBLarge.AutoSize = true;
            this.radioWBLarge.Location = new System.Drawing.Point(304, 6);
            this.radioWBLarge.Margin = new System.Windows.Forms.Padding(4);
            this.radioWBLarge.Name = "radioWBLarge";
            this.radioWBLarge.Size = new System.Drawing.Size(92, 19);
            this.radioWBLarge.TabIndex = 1;
            this.radioWBLarge.Text = "1024x512";
            this.radioWBLarge.UseVisualStyleBackColor = true;
            this.radioWBLarge.CheckedChanged += new System.EventHandler(this.WhiteBoardChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 424);
            this.Controls.Add(this.panelWhiteBoard);
            this.Controls.Add(this.panelEvent);
            this.Controls.Add(this.panelGashaInfo);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panelRareUpright);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelGasha);
            this.Controls.Add(this.labelProcessing);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.buttonOpenFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "ImageComposer  v1.8";
            this.panelRareUpright.ResumeLayout(false);
            this.panelRareUpright.PerformLayout();
            this.panelGashaInfo.ResumeLayout(false);
            this.panelGashaInfo.PerformLayout();
            this.panelGasha.ResumeLayout(false);
            this.panelGasha.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.panelEvent.ResumeLayout(false);
            this.panelEvent.PerformLayout();
            this.panelWhiteBoard.ResumeLayout(false);
            this.panelWhiteBoard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.RadioButton tglRareWide;
        private System.Windows.Forms.RadioButton tglRareUpright;
        private System.Windows.Forms.RadioButton tglGasha;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Panel panelRareUpright;
        private System.Windows.Forms.RadioButton radioBoth;
        private System.Windows.Forms.RadioButton radioWithFrame;
        private System.Windows.Forms.RadioButton radioNoFrame;
        private System.Windows.Forms.Label labelProcessing;
        private System.Windows.Forms.Panel panelGasha;
        private System.Windows.Forms.RadioButton radioGashaBoth;
        private System.Windows.Forms.RadioButton radioWide;
        private System.Windows.Forms.RadioButton radioOrigin;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton tglGashaInfo;
        private System.Windows.Forms.Panel panelCard;
        private System.Windows.Forms.RadioButton radioCardBoth;
        private System.Windows.Forms.RadioButton radioCardWide;
        private System.Windows.Forms.RadioButton radioCardOrigin;
        private System.Windows.Forms.RadioButton tglWhiteBoard;
        private System.Windows.Forms.Panel panelGashaInfo;
        private System.Windows.Forms.RadioButton radioOldReso;
        private System.Windows.Forms.RadioButton radioNewReso;
        private System.Windows.Forms.Label labelGashaInfoHint;
        private System.Windows.Forms.RadioButton tglEvent;
        private System.Windows.Forms.Panel panelEvent;
        private System.Windows.Forms.RadioButton radioEventBoth;
        private System.Windows.Forms.RadioButton radioEventFullWithLogo;
        private System.Windows.Forms.RadioButton radioEventFull;
        private System.Windows.Forms.Panel panelWhiteBoard;
        private System.Windows.Forms.RadioButton radioWBMid;
        private System.Windows.Forms.RadioButton radioWBSmall;
        private System.Windows.Forms.RadioButton radioWBLarge;
    }
}

