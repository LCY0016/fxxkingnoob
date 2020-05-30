namespace SimpleCrawler
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LtbxInfo = new System.Windows.Forms.ListBox();
            this.GbxStartUrl = new System.Windows.Forms.GroupBox();
            this.BtnContinue = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TbxStartUrl = new System.Windows.Forms.TextBox();
            this.BtnStop = new System.Windows.Forms.Button();
            this.GbxStartUrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // LtbxInfo
            // 
            this.LtbxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LtbxInfo.FormattingEnabled = true;
            this.LtbxInfo.ItemHeight = 15;
            this.LtbxInfo.Location = new System.Drawing.Point(12, 104);
            this.LtbxInfo.Name = "LtbxInfo";
            this.LtbxInfo.Size = new System.Drawing.Size(776, 334);
            this.LtbxInfo.TabIndex = 0;
            // 
            // GbxStartUrl
            // 
            this.GbxStartUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbxStartUrl.Controls.Add(this.BtnStop);
            this.GbxStartUrl.Controls.Add(this.BtnContinue);
            this.GbxStartUrl.Controls.Add(this.BtnPause);
            this.GbxStartUrl.Controls.Add(this.BtnStart);
            this.GbxStartUrl.Controls.Add(this.label1);
            this.GbxStartUrl.Controls.Add(this.TbxStartUrl);
            this.GbxStartUrl.Location = new System.Drawing.Point(12, 21);
            this.GbxStartUrl.Name = "GbxStartUrl";
            this.GbxStartUrl.Size = new System.Drawing.Size(776, 61);
            this.GbxStartUrl.TabIndex = 1;
            this.GbxStartUrl.TabStop = false;
            // 
            // BtnContinue
            // 
            this.BtnContinue.Location = new System.Drawing.Point(605, 24);
            this.BtnContinue.Name = "BtnContinue";
            this.BtnContinue.Size = new System.Drawing.Size(75, 23);
            this.BtnContinue.TabIndex = 4;
            this.BtnContinue.Text = "继续";
            this.BtnContinue.UseVisualStyleBackColor = true;
            this.BtnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Location = new System.Drawing.Point(510, 24);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(75, 23);
            this.BtnPause.TabIndex = 3;
            this.BtnPause.Text = "暂停";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(414, 24);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 2;
            this.BtnStart.Text = "开始";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "起始地址";
            // 
            // TbxStartUrl
            // 
            this.TbxStartUrl.Location = new System.Drawing.Point(96, 24);
            this.TbxStartUrl.Name = "TbxStartUrl";
            this.TbxStartUrl.Size = new System.Drawing.Size(294, 25);
            this.TbxStartUrl.TabIndex = 0;
            // 
            // BtnStop
            // 
            this.BtnStop.Location = new System.Drawing.Point(695, 24);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(75, 23);
            this.BtnStop.TabIndex = 5;
            this.BtnStop.Text = "结束";
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GbxStartUrl);
            this.Controls.Add(this.LtbxInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.GbxStartUrl.ResumeLayout(false);
            this.GbxStartUrl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LtbxInfo;
        private System.Windows.Forms.GroupBox GbxStartUrl;
        private System.Windows.Forms.Button BtnContinue;
        private System.Windows.Forms.Button BtnPause;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbxStartUrl;
        private System.Windows.Forms.Button BtnStop;
    }
}

