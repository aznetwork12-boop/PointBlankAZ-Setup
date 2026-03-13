namespace PBSetup.Pages
{
    partial class PagePath
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool d) { if (d && components != null) components.Dispose(); base.Dispose(d); }

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.lblFolderHdr = new System.Windows.Forms.Label();
            this.panelRow = new System.Windows.Forms.Panel();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblDisk = new System.Windows.Forms.Label();
            this.panelShortcut = new System.Windows.Forms.Panel();
            this.lblShortcut = new System.Windows.Forms.Label();
            this.panelRow.SuspendLayout();
            this.panelShortcut.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Light", 24F);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(239, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(234, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quraşdırma Yeri";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.BackColor = System.Drawing.Color.Transparent;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.lblSub.Location = new System.Drawing.Point(228, 61);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(259, 20);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Oyunun quraşdırılacağı qovluğu seçin.";
            // 
            // lblFolderHdr
            // 
            this.lblFolderHdr.AutoSize = true;
            this.lblFolderHdr.BackColor = System.Drawing.Color.Transparent;
            this.lblFolderHdr.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFolderHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(255)))));
            this.lblFolderHdr.Location = new System.Drawing.Point(0, 94);
            this.lblFolderHdr.Name = "lblFolderHdr";
            this.lblFolderHdr.Size = new System.Drawing.Size(52, 13);
            this.lblFolderHdr.TabIndex = 2;
            this.lblFolderHdr.Text = "QOVLUQ";
            // 
            // panelRow
            // 
            this.panelRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(42)))));
            this.panelRow.Controls.Add(this.txtPath);
            this.panelRow.Controls.Add(this.btnBrowse);
            this.panelRow.Location = new System.Drawing.Point(0, 114);
            this.panelRow.Name = "panelRow";
            this.panelRow.Size = new System.Drawing.Size(732, 46);
            this.panelRow.TabIndex = 3;
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(42)))));
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPath.Font = new System.Drawing.Font("Consolas", 10.5F);
            this.txtPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtPath.Location = new System.Drawing.Point(10, 13);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(608, 17);
            this.txtPath.TabIndex = 0;
            this.txtPath.Text = "C:\\Games\\PointBlankAZ";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(30)))), ((int)(((byte)(52)))));
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(255)))));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(255)))));
            this.btnBrowse.Location = new System.Drawing.Point(620, 1);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(111, 44);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.TabStop = false;
            this.btnBrowse.Text = "Seç...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            // 
            // lblDisk
            // 
            this.lblDisk.BackColor = System.Drawing.Color.Transparent;
            this.lblDisk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDisk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.lblDisk.Location = new System.Drawing.Point(2, 170);
            this.lblDisk.Name = "lblDisk";
            this.lblDisk.Size = new System.Drawing.Size(730, 20);
            this.lblDisk.TabIndex = 4;
            this.lblDisk.Text = "💾  Disk boş yeri hesablanır...";
            // 
            // panelShortcut
            // 
            this.panelShortcut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(124)))), ((int)(((byte)(58)))), ((int)(((byte)(237)))));
            this.panelShortcut.Controls.Add(this.lblShortcut);
            this.panelShortcut.Location = new System.Drawing.Point(0, 204);
            this.panelShortcut.Name = "panelShortcut";
            this.panelShortcut.Size = new System.Drawing.Size(732, 50);
            this.panelShortcut.TabIndex = 5;
            // 
            // lblShortcut
            // 
            this.lblShortcut.AutoSize = true;
            this.lblShortcut.BackColor = System.Drawing.Color.Transparent;
            this.lblShortcut.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblShortcut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.lblShortcut.Location = new System.Drawing.Point(14, 16);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(416, 17);
            this.lblShortcut.TabIndex = 0;
            this.lblShortcut.Text = "Masaüstü qısayolu quraşdırma bitdikdən sonra avtomatik yaradılacaq.";
            // 
            // PagePath
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.lblFolderHdr);
            this.Controls.Add(this.panelRow);
            this.Controls.Add(this.lblDisk);
            this.Controls.Add(this.panelShortcut);
            this.Name = "PagePath";
            this.Size = new System.Drawing.Size(732, 370);
            this.panelRow.ResumeLayout(false);
            this.panelRow.PerformLayout();
            this.panelShortcut.ResumeLayout(false);
            this.panelShortcut.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label   lblTitle;
        private System.Windows.Forms.Label   lblSub;
        private System.Windows.Forms.Label   lblFolderHdr;
        private System.Windows.Forms.Panel   panelRow;
        public  System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button  btnBrowse;
        public  System.Windows.Forms.Label   lblDisk;
        private System.Windows.Forms.Panel   panelShortcut;
        private System.Windows.Forms.Label   lblShortcut;
    }
}
