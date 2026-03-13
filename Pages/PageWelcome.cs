using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PBSetup.Pages
{
    public partial class PageWelcome : UserControl
    {
        public PageWelcome()
        {
            InitializeComponent();
            panelInfo.Paint += (s, e) => DrawCard(e.Graphics, panelInfo, T.Accent);
            panelWarn.Paint += (s, e) => DrawCard(e.Graphics, panelWarn, T.Gold);
            panelReq.Paint  += (s, e) => DrawCard(e.Graphics, panelReq,  T.Muted);
        }

        private static void DrawCard(Graphics g, Panel p, Color accent)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var pen = new Pen(Color.FromArgb(55, accent), 1))
                g.DrawRounded(pen, 0, 0, p.Width - 1, p.Height - 1, 7);
            using (var b = new SolidBrush(accent))
                g.FillRounded(b, 0, 0, 4, p.Height, 4);
        }

        private void lblRow1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
