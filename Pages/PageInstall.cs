using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PBSetup.Pages
{
    public partial class PageInstall : UserControl
    {
        public Panel[]  Dots  { get { return new[] { dot0, dot1, dot2, dot3 }; } }
        public Label[]  Steps { get { return new[] { lblStep0, lblStep1, lblStep2, lblStep3 }; } }

        public PageInstall()
        {
            InitializeComponent();

            // Dot-ları dairə şəklinə sal
            foreach (var dot in Dots)
            {
                var gp = new GraphicsPath();
                gp.AddEllipse(0, 0, dot.Width, dot.Height);
                dot.Region = new Region(gp);
                dot.Paint += DotPaint;
            }
        }

        private static void DotPaint(object s, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var p = new Pen(T.Border, 1))
                e.Graphics.DrawEllipse(p, 0, 0, ((Control)s).Width - 1, ((Control)s).Height - 1);
        }

        public void MarkStep(int i, bool done)
        {
            var dot = Dots[i];
            var lbl = Steps[i];
            dot.BackColor  = done ? T.Success : Color.FromArgb(20, T.Accent);
            lbl.ForeColor  = done ? T.Success : T.Accent;
            dot.Paint -= DotCheckMark;
            if (done) dot.Paint += DotCheckMark;
            dot.Invalidate();
        }

        private static void DotCheckMark(object s, PaintEventArgs e)
        {
            var c = (Control)s;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var p = new Pen(Color.Black, 2f)
                { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round })
                e.Graphics.DrawLines(p, new[]
                {
                    new Point(6, c.Height/2),
                    new Point(c.Width/2-1, c.Height-7),
                    new Point(c.Width-6, 7)
                });
        }
    }
}
