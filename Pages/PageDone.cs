using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PBSetup.Pages
{
    public partial class PageDone : UserControl
    {
        public PageDone()
        {
            InitializeComponent();

            panelBanner.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var pen = new Pen(Color.FromArgb(55, T.Success), 1))
                    e.Graphics.DrawRounded(pen, 0, 0, panelBanner.Width - 1, panelBanner.Height - 1, 7);
                using (var b = new SolidBrush(T.Success))
                    e.Graphics.FillRounded(b, 0, 0, 4, panelBanner.Height, 4);
            };
        }
    }
}
