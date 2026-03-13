using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PBSetup
{
    internal static class GfxExt
    {
        private static GraphicsPath RPath(float x, float y, float w, float h, float r)
        {
            r = Math.Min(r, Math.Min(w / 2f, h / 2f));
            var p = new GraphicsPath();
            p.AddArc(x,           y,           r*2, r*2, 180, 90);
            p.AddArc(x+w-r*2,     y,           r*2, r*2, 270, 90);
            p.AddArc(x+w-r*2,     y+h-r*2,     r*2, r*2,   0, 90);
            p.AddArc(x,           y+h-r*2,     r*2, r*2,  90, 90);
            p.CloseFigure();
            return p;
        }

        public static void FillRounded(this Graphics g, Brush b, float x, float y, float w, float h, float r)
        { if (w>0&&h>0) { using (var p=RPath(x,y,w,h,r)) g.FillPath(b,p); } }

        public static void DrawRounded(this Graphics g, Pen pen, float x, float y, float w, float h, float r)
        { if (w>0&&h>0) { using (var p=RPath(x,y,w,h,r)) g.DrawPath(pen,p); } }
    }
}
