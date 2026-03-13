namespace PBSetup
{
    partial class SetupForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelStepBar = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pgDone = new PBSetup.Pages.PageDone();
            this.pgInstall = new PBSetup.Pages.PageInstall();
            this.pgPath = new PBSetup.Pages.PagePath();
            this.pgWelcome = new PBSetup.Pages.PageWelcome();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(30)))));
            this.panelHeader.Controls.Add(this.btnMinimize);
            this.panelHeader.Controls.Add(this.btnClose);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(732, 86);
            this.panelHeader.TabIndex = 0;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(68)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMinimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.btnMinimize.Location = new System.Drawing.Point(666, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Text = "─";
            this.btnMinimize.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(68)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.btnClose.Location = new System.Drawing.Point(698, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "✕";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // panelStepBar
            // 
            this.panelStepBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(30)))));
            this.panelStepBar.Location = new System.Drawing.Point(0, 86);
            this.panelStepBar.Name = "panelStepBar";
            this.panelStepBar.Size = new System.Drawing.Size(732, 56);
            this.panelStepBar.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.panelContent.Controls.Add(this.pgDone);
            this.panelContent.Controls.Add(this.pgInstall);
            this.panelContent.Controls.Add(this.pgPath);
            this.panelContent.Controls.Add(this.pgWelcome);
            this.panelContent.Location = new System.Drawing.Point(0, 142);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(34, 0, 34, 0);
            this.panelContent.Size = new System.Drawing.Size(732, 370);
            this.panelContent.TabIndex = 2;
            // 
            // pgDone
            // 
            this.pgDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.pgDone.Location = new System.Drawing.Point(0, 0);
            this.pgDone.Name = "pgDone";
            this.pgDone.Size = new System.Drawing.Size(732, 370);
            this.pgDone.TabIndex = 3;
            // 
            // pgInstall
            // 
            this.pgInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.pgInstall.Location = new System.Drawing.Point(0, 0);
            this.pgInstall.Name = "pgInstall";
            this.pgInstall.Size = new System.Drawing.Size(732, 370);
            this.pgInstall.TabIndex = 2;
            // 
            // pgPath
            // 
            this.pgPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.pgPath.Location = new System.Drawing.Point(0, 0);
            this.pgPath.Name = "pgPath";
            this.pgPath.Size = new System.Drawing.Size(732, 370);
            this.pgPath.TabIndex = 1;
            // 
            // pgWelcome
            // 
            this.pgWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.pgWelcome.Location = new System.Drawing.Point(0, 0);
            this.pgWelcome.Name = "pgWelcome";
            this.pgWelcome.Size = new System.Drawing.Size(732, 370);
            this.pgWelcome.TabIndex = 0;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(18)))), ((int)(((byte)(30)))));
            this.panelFooter.Controls.Add(this.lblVersion);
            this.panelFooter.Controls.Add(this.btnBack);
            this.panelFooter.Controls.Add(this.btnCancel);
            this.panelFooter.Controls.Add(this.btnNext);
            this.panelFooter.Location = new System.Drawing.Point(0, 512);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(732, 68);
            this.panelFooter.TabIndex = 3;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(100)))), ((int)(((byte)(135)))));
            this.lblVersion.Location = new System.Drawing.Point(150, 27);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(210, 13);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "PointBlank AzNetwork Setup  ·  .NET 4.8";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(42)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(68)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnBack.Location = new System.Drawing.Point(20, 15);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 38);
            this.btnBack.TabIndex = 1;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "← Geri";
            this.btnBack.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(24)))), ((int)(((byte)(42)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(38)))), ((int)(((byte)(68)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnCancel.Location = new System.Drawing.Point(455, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 38);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Ləğv et";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(255)))));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Location = new System.Drawing.Point(581, 15);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(140, 38);
            this.btnNext.TabIndex = 3;
            this.btnNext.TabStop = false;
            this.btnNext.Text = "İrəli →";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(12)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(733, 580);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelStepBar);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(733, 580);
            this.MinimumSize = new System.Drawing.Size(733, 580);
            this.Name = "SetupForm";
            this.Text = "PointBlankAZ — Quraşdırıcı";
            this.panelHeader.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel  panelHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Panel  panelStepBar;
        private System.Windows.Forms.Panel  panelContent;
        private System.Windows.Forms.Panel  panelFooter;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label  lblVersion;
        private PBSetup.Pages.PageWelcome   pgWelcome;
        private PBSetup.Pages.PagePath      pgPath;
        private PBSetup.Pages.PageInstall   pgInstall;
        private PBSetup.Pages.PageDone      pgDone;
    }
}
