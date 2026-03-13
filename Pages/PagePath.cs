using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace PBSetup.Pages
{
    public partial class PagePath : UserControl
    {
        public PagePath()
        {
            InitializeComponent();

            panelRow.Paint += (s, e) =>
            {
                using (var p = new Pen(T.Border, 1))
                    e.Graphics.DrawRectangle(p, 0, 0, panelRow.Width - 1, panelRow.Height - 1);
            };
            panelShortcut.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var pen = new Pen(Color.FromArgb(55, T.Accent2), 1))
                    e.Graphics.DrawRounded(pen, 0, 0, panelShortcut.Width - 1, panelShortcut.Height - 1, 7);
                using (var b = new SolidBrush(T.Accent2))
                    e.Graphics.FillRounded(b, 0, 0, 4, panelShortcut.Height, 4);
            };

            txtPath.TextChanged += (s, e) => RefreshDisk();
            btnBrowse.Click     += (s, e) =>
            {
                using (var d = new FolderBrowserDialog { ShowNewFolderButton = true })
                    if (d.ShowDialog() == DialogResult.OK)
                        txtPath.Text = Path.Combine(d.SelectedPath, Config.SHORTCUT_NAME);
            };

            RefreshDisk();
        }

        public void RefreshDisk()
        {
            try
            {
                string root = Path.GetPathRoot(txtPath.Text ?? "") ?? "";
                if (root.Length > 0 && Directory.Exists(root))
                {
                    double gb = new DriveInfo(root).AvailableFreeSpace / (1024.0 * 1024 * 1024);
                    lblDisk.Text      = string.Format("💾  Disk: {0}  ·  Boş yer: {1:F1} GB", root, gb);
                    lblDisk.ForeColor = gb < 2 ? T.Danger : T.Muted;
                }
            }
            catch { }
        }
    }
}
