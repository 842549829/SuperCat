namespace Qunau.SuperCat
{
    partial class FrmChoiceProcess
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChoiceProcess));
            this.btnOK = new Dongger.Windows.Forms.DButton();
            this.btnCancel = new Dongger.Windows.Forms.DButton();
            this.dgvProcesses = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dPanel1 = new Dongger.Windows.Forms.DPanel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).BeginInit();
            this.dPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BorderColor = System.Drawing.Color.Empty;
            this.btnOK.BorderWidth = 0;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(40, 368);
            this.btnOK.Name = "btnOK";
            this.btnOK.Radius = 0;
            this.btnOK.RadiusMode = Dongger.Windows.Forms.RadiusMode.None;
            this.btnOK.Size = new System.Drawing.Size(115, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确认选择(&O)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.Empty;
            this.btnCancel.BorderWidth = 0;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnCancel.DefaultBackColorGradint = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(194, 368);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Radius = 0;
            this.btnCancel.RadiusMode = Dongger.Windows.Forms.RadiusMode.None;
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvProcesses
            // 
            this.dgvProcesses.AllowUserToAddRows = false;
            this.dgvProcesses.AllowUserToDeleteRows = false;
            this.dgvProcesses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProcesses.BackgroundColor = System.Drawing.Color.White;
            this.dgvProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProcesses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProcesses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProcesses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProcesses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colTitle});
            this.dgvProcesses.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvProcesses.Location = new System.Drawing.Point(0, 40);
            this.dgvProcesses.Name = "dgvProcesses";
            this.dgvProcesses.ReadOnly = true;
            this.dgvProcesses.RowHeadersVisible = false;
            this.dgvProcesses.RowTemplate.Height = 23;
            this.dgvProcesses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProcesses.Size = new System.Drawing.Size(370, 274);
            this.dgvProcesses.TabIndex = 2;
            // 
            // colID
            // 
            this.colID.HeaderText = "PID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.HeaderText = "名称";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "标题";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            // 
            // dPanel1
            // 
            this.dPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(18)))));
            this.dPanel1.BackColorGradint = System.Drawing.Color.Empty;
            this.dPanel1.BorderColor = System.Drawing.Color.Empty;
            this.dPanel1.Controls.Add(this.label1);
            this.dPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dPanel1.LinearGradientMode = Dongger.Windows.Forms.EGradientMode.Horizontal;
            this.dPanel1.Location = new System.Drawing.Point(0, 314);
            this.dPanel1.Name = "dPanel1";
            this.dPanel1.Size = new System.Drawing.Size(370, 42);
            this.dPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "只显示了名称为player的进程";
            // 
            // FrmChoiceProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackColorGradintTo = System.Drawing.Color.White;
            this.BackColorLinearGradientMode = Dongger.Windows.Forms.EGradientMode.None;
            this.CaptionBackgroundColor = System.Drawing.Color.White;
            this.CaptionForeColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(370, 413);
            this.ControlActivedColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.ControlBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.Controls.Add(this.dPanel1);
            this.Controls.Add(this.dgvProcesses);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.CustomResizeable = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChoiceProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模拟器进程选择";
            this.TitleFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Load += new System.EventHandler(this.FrmChoiceProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProcesses)).EndInit();
            this.dPanel1.ResumeLayout(false);
            this.dPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Dongger.Windows.Forms.DButton btnOK;
        private Dongger.Windows.Forms.DButton btnCancel;
        private System.Windows.Forms.DataGridView dgvProcesses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private Dongger.Windows.Forms.DPanel dPanel1;
        private System.Windows.Forms.Label label1;
    }
}