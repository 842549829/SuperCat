namespace Qunau.SuperCat
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.dPanel1 = new Dongger.Windows.Forms.DPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.rtxtMessage = new System.Windows.Forms.RichTextBox();
            this.btnChoiceProcess = new Dongger.Windows.Forms.DButton();
            this.btnTest = new Dongger.Windows.Forms.DButton();
            this.txtFlightNo = new Dongger.Windows.Forms.DTitleTextBox();
            this.btnStart = new Dongger.Windows.Forms.DButton();
            this.bgwTest = new System.ComponentModel.BackgroundWorker();
            this.dPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dPanel1
            // 
            this.dPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.dPanel1.BackColorGradint = System.Drawing.Color.Empty;
            this.dPanel1.BorderColor = System.Drawing.Color.Empty;
            this.dPanel1.Controls.Add(this.label1);
            this.dPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dPanel1.LinearGradientMode = Dongger.Windows.Forms.EGradientMode.Horizontal;
            this.dPanel1.Location = new System.Drawing.Point(0, 40);
            this.dPanel1.Name = "dPanel1";
            this.dPanel1.Size = new System.Drawing.Size(741, 43);
            this.dPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(568, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "注：运行前，请检查Genymotion中已经启动航旅纵横，并切换到航班动态界面";
            // 
            // rtxtMessage
            // 
            this.rtxtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.rtxtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtxtMessage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtxtMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.rtxtMessage.Location = new System.Drawing.Point(0, 137);
            this.rtxtMessage.Name = "rtxtMessage";
            this.rtxtMessage.Size = new System.Drawing.Size(741, 416);
            this.rtxtMessage.TabIndex = 2;
            this.rtxtMessage.Text = "";
            // 
            // btnChoiceProcess
            // 
            this.btnChoiceProcess.BackColor = System.Drawing.Color.Transparent;
            this.btnChoiceProcess.BorderColor = System.Drawing.Color.Empty;
            this.btnChoiceProcess.BorderWidth = 0;
            this.btnChoiceProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChoiceProcess.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnChoiceProcess.DefaultBackColorGradint = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnChoiceProcess.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnChoiceProcess.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChoiceProcess.Location = new System.Drawing.Point(213, 93);
            this.btnChoiceProcess.Name = "btnChoiceProcess";
            this.btnChoiceProcess.Radius = 0;
            this.btnChoiceProcess.RadiusMode = Dongger.Windows.Forms.RadiusMode.None;
            this.btnChoiceProcess.Size = new System.Drawing.Size(118, 32);
            this.btnChoiceProcess.TabIndex = 3;
            this.btnChoiceProcess.Text = "选择模拟器进程";
            this.btnChoiceProcess.Click += new System.EventHandler(this.btnChoiceProcess_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.Transparent;
            this.btnTest.BorderColor = System.Drawing.Color.Empty;
            this.btnTest.BorderWidth = 0;
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnTest.DefaultBackColorGradint = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.btnTest.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnTest.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTest.Location = new System.Drawing.Point(656, 93);
            this.btnTest.Name = "btnTest";
            this.btnTest.Radius = 0;
            this.btnTest.RadiusMode = Dongger.Windows.Forms.RadiusMode.None;
            this.btnTest.Size = new System.Drawing.Size(71, 32);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "测试";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtFlightNo
            // 
            this.txtFlightNo.ActivtedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(182)))), ((int)(((byte)(1)))));
            this.txtFlightNo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.txtFlightNo.Location = new System.Drawing.Point(504, 93);
            this.txtFlightNo.MaxLength = 32767;
            this.txtFlightNo.Name = "txtFlightNo";
            this.txtFlightNo.PasswordChar = '\0';
            this.txtFlightNo.ReadOnly = false;
            this.txtFlightNo.Size = new System.Drawing.Size(150, 32);
            this.txtFlightNo.TabIndex = 5;
            this.txtFlightNo.Title = "航班号";
            this.txtFlightNo.UseSystemPasswordChar = false;
            this.txtFlightNo.WaterText = "测试的航班号";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BorderColor = System.Drawing.Color.Empty;
            this.btnStart.BorderWidth = 0;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnStart.DefaultBackColorGradint = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnStart.HoverBackColorGradint = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnStart.Location = new System.Drawing.Point(343, 93);
            this.btnStart.Name = "btnStart";
            this.btnStart.Radius = 0;
            this.btnStart.RadiusMode = Dongger.Windows.Forms.RadiusMode.None;
            this.btnStart.Size = new System.Drawing.Size(148, 32);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "开始接受请求";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // bgwTest
            // 
            this.bgwTest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTest_DoWork);
            this.bgwTest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTest_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackColorGradintTo = System.Drawing.Color.White;
            this.BackColorLinearGradientMode = Dongger.Windows.Forms.EGradientMode.None;
            this.CaptionBackgroundColor = System.Drawing.Color.White;
            this.CaptionForeColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(741, 553);
            this.ControlActivedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.ControlBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtFlightNo);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnChoiceProcess);
            this.Controls.Add(this.rtxtMessage);
            this.Controls.Add(this.dPanel1);
            this.CustomResizeable = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "超级猫前序航班爬虫";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.dPanel1.ResumeLayout(false);
            this.dPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Dongger.Windows.Forms.DPanel dPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxtMessage;
        private Dongger.Windows.Forms.DButton btnChoiceProcess;
        private Dongger.Windows.Forms.DButton btnTest;
        private Dongger.Windows.Forms.DTitleTextBox txtFlightNo;
        private Dongger.Windows.Forms.DButton btnStart;
        private System.ComponentModel.BackgroundWorker bgwTest;

    }
}

