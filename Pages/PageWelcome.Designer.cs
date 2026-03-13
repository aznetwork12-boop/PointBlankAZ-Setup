namespace PBSetup.Pages
{
    partial class PageWelcome
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool d) { if (d && components != null) components.Dispose(); base.Dispose(d); }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.lblInfoHdr = new System.Windows.Forms.Label();
            this.lblRow0 = new System.Windows.Forms.Label();
            this.lblRow1 = new System.Windows.Forms.Label();
            this.lblRow3 = new System.Windows.Forms.Label();
            this.panelWarn = new System.Windows.Forms.Panel();
            this.lblWarn = new System.Windows.Forms.Label();
            this.panelReq = new System.Windows.Forms.Panel();
            this.lblReq = new System.Windows.Forms.Label();
            this.panelInfo.SuspendLayout();
            this.panelWarn.SuspendLayout();
            this.panelReq.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(268, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(194, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Xoş Gəldiniz!";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.BackColor = System.Drawing.Color.Transparent;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.lblSub.Location = new System.Drawing.Point(171, 65);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(393, 20);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Point Blank AzNetwork-u qurmaq üçün bu sehrbazı izləyin.";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(255)))));
            this.panelInfo.Controls.Add(this.lblInfoHdr);
            this.panelInfo.Controls.Add(this.lblRow0);
            this.panelInfo.Controls.Add(this.lblRow1);
            this.panelInfo.Controls.Add(this.lblRow3);
            this.panelInfo.Location = new System.Drawing.Point(0, 88);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(732, 138);
            this.panelInfo.TabIndex = 2;
            // 
            // lblInfoHdr
            // 
            this.lblInfoHdr.AutoSize = true;
            this.lblInfoHdr.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoHdr.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.lblInfoHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(255)))));
            this.lblInfoHdr.Location = new System.Drawing.Point(16, 10);
            this.lblInfoHdr.Name = "lblInfoHdr";
            this.lblInfoHdr.Size = new System.Drawing.Size(140, 15);
            this.lblInfoHdr.TabIndex = 0;
            this.lblInfoHdr.Text = "Bu quraşdırıcı nə edəcək?";
            // 
            // lblRow0
            // 
            this.lblRow0.AutoSize = true;
            this.lblRow0.BackColor = System.Drawing.Color.Transparent;
            this.lblRow0.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRow0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblRow0.Location = new System.Drawing.Point(32, 34);
            this.lblRow0.Name = "lblRow0";
            this.lblRow0.Size = new System.Drawing.Size(274, 17);
            this.lblRow0.TabIndex = 1;
            this.lblRow0.Text = "●   Rəsmi serverdən oyun fayllarını yükləyəcək";
            // 
            // lblRow1
            // 
            this.lblRow1.AutoSize = true;
            this.lblRow1.BackColor = System.Drawing.Color.Transparent;
            this.lblRow1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRow1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblRow1.Location = new System.Drawing.Point(32, 58);
            this.lblRow1.Name = "lblRow1";
            this.lblRow1.Size = new System.Drawing.Size(300, 17);
            this.lblRow1.TabIndex = 2;
            this.lblRow1.Text = "●   Seçdiyiniz qovluğa oyun fayllarını quraşdıracaq";
            this.lblRow1.Click += new System.EventHandler(this.lblRow1_Click);
            // 
            // lblRow3
            // 
            this.lblRow3.AutoSize = true;
            this.lblRow3.BackColor = System.Drawing.Color.Transparent;
            this.lblRow3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblRow3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblRow3.Location = new System.Drawing.Point(32, 82);
            this.lblRow3.Name = "lblRow3";
            this.lblRow3.Size = new System.Drawing.Size(223, 17);
            this.lblRow3.TabIndex = 4;
            this.lblRow3.Text = "●   Masaüstündə qısayolu yaradacaq";
            // 
            // panelWarn
            // 
            this.panelWarn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(245)))), ((int)(((byte)(200)))), ((int)(((byte)(66)))));
            this.panelWarn.Controls.Add(this.lblWarn);
            this.panelWarn.Location = new System.Drawing.Point(0, 238);
            this.panelWarn.Name = "panelWarn";
            this.panelWarn.Size = new System.Drawing.Size(732, 50);
            this.panelWarn.TabIndex = 3;
            // 
            // lblWarn
            // 
            this.lblWarn.AutoSize = true;
            this.lblWarn.BackColor = System.Drawing.Color.Transparent;
            this.lblWarn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblWarn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(200)))), ((int)(((byte)(66)))));
            this.lblWarn.Location = new System.Drawing.Point(14, 16);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(387, 17);
            this.lblWarn.TabIndex = 0;
            this.lblWarn.Text = "⚠   Administrator icazəsi tələb olunur administrator olaraq açın.";
            // 
            // panelReq
            // 
            this.panelReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.panelReq.Controls.Add(this.lblReq);
            this.panelReq.Location = new System.Drawing.Point(0, 300);
            this.panelReq.Name = "panelReq";
            this.panelReq.Size = new System.Drawing.Size(732, 50);
            this.panelReq.TabIndex = 4;
            // 
            // lblReq
            // 
            this.lblReq.AutoSize = true;
            this.lblReq.BackColor = System.Drawing.Color.Transparent;
            this.lblReq.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblReq.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.lblReq.Location = new System.Drawing.Point(14, 16);
            this.lblReq.Name = "lblReq";
            this.lblReq.Size = new System.Drawing.Size(392, 15);
            this.lblReq.TabIndex = 0;
            this.lblReq.Text = "Tələblər:  Windows 7/8/8.1/10/11  ·  ~14 GB boş disk  ·  .NET 4.8  ·  İnternet";
            // 
            // PageWelcome
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelWarn);
            this.Controls.Add(this.panelReq);
            this.Name = "PageWelcome";
            this.Size = new System.Drawing.Size(732, 370);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelWarn.ResumeLayout(false);
            this.panelWarn.PerformLayout();
            this.panelReq.ResumeLayout(false);
            this.panelReq.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label lblInfoHdr;
        private System.Windows.Forms.Label lblRow0;
        private System.Windows.Forms.Label lblRow1;
        private System.Windows.Forms.Label lblRow3;
        private System.Windows.Forms.Panel panelWarn;
        private System.Windows.Forms.Label lblWarn;
        private System.Windows.Forms.Panel panelReq;
        private System.Windows.Forms.Label lblReq;
    }
}
