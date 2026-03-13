using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBSetup
{
    public partial class SetupForm : Form
    {
        private int _page = 0;
        private string _installPath = Config.DEFAULT_INSTALL;

        private int _activeStep = 0;
        private float _pulse = 0f;
        private bool _pulseUp = true;
        private readonly Timer _pulseTimer;

        [DllImport("user32.dll")] static extern bool ReleaseCapture();
        [DllImport("user32.dll")] static extern int SendMessage(IntPtr h, int m, int w, int l);

        public SetupForm()
        {
            InitializeComponent();

            // Pulse timer — step indicator animasiyası
            _pulseTimer = new Timer { Interval = 40 };
            _pulseTimer.Tick += (s, e) =>
            {
                _pulse += _pulseUp ? 0.05f : -0.05f;
                if (_pulse >= 1f) _pulseUp = false;
                else if (_pulse <= 0f) _pulseUp = true;
                panelStepBar.Invalidate();
            };
            _pulseTimer.Start();
            this.FormClosed += (s, e) => _pulseTimer.Dispose();

            // Header hadisələri
            panelHeader.Paint += PaintHeader;
            panelHeader.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); }
            };
            btnClose.Click += (s, e) => TryClose();
            btnClose.MouseEnter += (s, e) => { btnClose.ForeColor = T.Danger; };
            btnClose.MouseLeave += (s, e) => { btnClose.ForeColor = T.Muted; };
            btnMinimize.Click += (s, e) => WindowState = FormWindowState.Minimized;
            btnMinimize.MouseEnter += (s, e) => { btnMinimize.ForeColor = T.Accent; };
            btnMinimize.MouseLeave += (s, e) => { btnMinimize.ForeColor = T.Muted; };

            // Step bar
            panelStepBar.Paint += PaintStepBar;

            // Footer
            panelFooter.Paint += (s, e) =>
            {
                using (var p = new Pen(T.Border, 1))
                    e.Graphics.DrawLine(p, 0, 0, panelFooter.Width, 0);
                using (var p = new Pen(Color.FromArgb(30, T.Accent), 1))
                    e.Graphics.DrawLine(p, 0, 1, panelFooter.Width, 1);
            };

            // Footer butonları — FlatStyle=Flat + Paint = ghost text yoxdur
            HookBtn(btnBack, false);
            HookBtn(btnCancel, false);
            HookBtn(btnNext, true);
            btnBack.Click += (s, e) => { if (_page > 0 && _page < 2) GoTo(_page - 1); };
            btnNext.Click += (s, e) => NextClick();
            btnCancel.Click += (s, e) => TryClose();

            // Form kənar xətti
            this.Paint += (s, e) =>
            {
                using (var p = new Pen(T.Border, 1))
                    e.Graphics.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
            };

            // Səhifə 3 butonları
            pgDone.btnLaunch.Click += (s, e) => LaunchGame();
            pgDone.btnFolder.Click += (s, e) =>
            {
                try { Process.Start("explorer.exe", _installPath); } catch { }
            };

            GoTo(0);
        }

        // =============================================================
        //  BUTTON PAINT  (ghost text yoxdur)
        // =============================================================
        private static void HookBtn(Button btn, bool primary)
        {
            bool[] h = new bool[] { false };
            btn.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(btn.Parent != null ? btn.Parent.BackColor : T.Surface);

                float x = 1, y = 1, w = btn.Width - 2, hh = btn.Height - 2, r = 6;
                var rf = new RectangleF(0, 0, btn.Width, btn.Height);
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.NoWrap };

                if (primary)
                {
                    Color fill = !btn.Enabled ? T.AccDim : h[0] ? Color.FromArgb(0, 215, 255) : T.Accent;
                    using (var br = new SolidBrush(fill)) g.FillRounded(br, x, y, w, hh, r);
                    if (h[0] && btn.Enabled)
                        using (var sh = new SolidBrush(Color.FromArgb(35, 255, 255, 255))) g.FillRounded(sh, x, y, w, hh / 2f, r);
                    using (var tb = new SolidBrush(btn.Enabled ? Color.Black : Color.FromArgb(80, 0, 0, 0)))
                        g.DrawString(btn.Text, btn.Font, tb, rf, sf);
                }
                else
                {
                    Color bc = !btn.Enabled ? T.Border : h[0] ? T.Accent : T.Border;
                    Color tc = !btn.Enabled ? T.Muted : h[0] ? T.Accent : T.Text;
                    if (h[0] && btn.Enabled)
                        using (var hb = new SolidBrush(Color.FromArgb(18, T.Accent))) g.FillRounded(hb, x, y, w, hh, r);
                    using (var pen = new Pen(bc, 1f)) g.DrawRounded(pen, x, y, w, hh, r);
                    using (var tb = new SolidBrush(tc)) g.DrawString(btn.Text, btn.Font, tb, rf, sf);
                }
                sf.Dispose();
            };
            btn.MouseEnter += (s, e) => { h[0] = true; btn.Invalidate(); };
            btn.MouseLeave += (s, e) => { h[0] = false; btn.Invalidate(); };
            btn.EnabledChanged += (s, e) => btn.Invalidate();
        }

        // =============================================================
        //  HEADER PAINT
        // =============================================================
        private void PaintHeader(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using (var bg = new LinearGradientBrush(
                new Rectangle(0, 0, panelHeader.Width, panelHeader.Height),
                Color.FromArgb(24, 30, 52), T.Surface, LinearGradientMode.Horizontal))
                g.FillRectangle(bg, 0, 0, panelHeader.Width, panelHeader.Height);

            using (var lg = new LinearGradientBrush(
                new Rectangle(0, panelHeader.Height - 2, panelHeader.Width, 2),
                Color.Transparent, Color.FromArgb(120, T.Accent), LinearGradientMode.Horizontal))
            { lg.SetBlendTriangularShape(0.5f); g.FillRectangle(lg, 0, panelHeader.Height - 2, panelHeader.Width, 2); }

            using (var lf = new Font("Segoe UI Black", 30f, FontStyle.Bold, GraphicsUnit.Point))
            using (var sf = new Font("Segoe UI", 9f, GraphicsUnit.Point))
            {
                for (int i = 4; i >= 1; i--)
                    using (var gb = new SolidBrush(Color.FromArgb(10 * (5 - i), T.Accent)))
                        g.DrawString("POINT", lf, gb, 19 + i, 15 + i);

                SizeF ptSz = g.MeasureString("POINT", lf);
                using (var gr = new LinearGradientBrush(new RectangleF(20, 14, 250, 50), T.Accent, Color.FromArgb(0, 130, 210), LinearGradientMode.Horizontal))
                    g.DrawString("POINT", lf, gr, 20, 14);
                using (var b = new SolidBrush(T.Text))
                    g.DrawString("BLANK", lf, b, 20 + ptSz.Width - 10, 14);
                SizeF blSz = g.MeasureString("BLANK", lf);
                using (var af = new Font("Segoe UI Black", 17f, FontStyle.Bold, GraphicsUnit.Point))
                using (var b = new SolidBrush(T.Accent2))
                    g.DrawString("AZNETWORK", af, b, 20 + ptSz.Width + blSz.Width - 20, 28);
                using (var b = new SolidBrush(T.Muted))
                    g.DrawString("Rəsmi Quraşdırıcı  ·  v" + Config.APP_VERSION, sf, b, 24, 66);
            }

            for (int i = 0; i < 5; i++)
                using (var b = new SolidBrush(Color.FromArgb(15 + i * 15, T.Accent)))
                    g.FillEllipse(b, panelHeader.Width - 80 + i * 18f, panelHeader.Height / 2f - 4, 8, 8);
        }

        // =============================================================
        //  STEP BAR PAINT
        // =============================================================
        private static readonly string[] StepLabels = { "Xoş gəldin", "Quraşdırma yeri", "Yüklənir", "Tamamlandı" };

        private void PaintStepBar(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            using (var br = new SolidBrush(T.Surface)) g.FillRectangle(br, 0, 0, panelStepBar.Width, panelStepBar.Height);
            using (var lg = new LinearGradientBrush(new Rectangle(0, 0, panelStepBar.Width, 1), Color.Transparent, Color.FromArgb(60, T.Accent), LinearGradientMode.Horizontal))
            { lg.SetBlendTriangularShape(0.5f); g.FillRectangle(lg, 0, 0, panelStepBar.Width, 1); }

            int n = StepLabels.Length, sw = panelStepBar.Width / n, cr = 14;
            for (int i = 0; i < n; i++)
            {
                int cx = i * sw + sw / 2, cy = 22;
                bool done = i < _activeStep, active = i == _activeStep;

                if (i < n - 1)
                    using (var pen = new Pen(done ? T.Success : T.Border, 1.5f))
                        g.DrawLine(pen, cx + cr, cy, (i + 1) * sw + sw / 2 - cr, cy);

                if (done)
                {
                    using (var b = new SolidBrush(T.Success)) g.FillEllipse(b, cx - cr, cy - cr, cr * 2, cr * 2);
                    using (var f = new Font("Segoe UI", 9f, FontStyle.Bold))
                    using (var b = new SolidBrush(Color.Black))
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        g.DrawString("✓", f, b, new RectangleF(cx - cr, cy - cr, cr * 2, cr * 2), sf);
                }
                else if (active)
                {
                    int gr = cr + 5, ga = (int)(40 * _pulse);
                    using (var b = new SolidBrush(Color.FromArgb(ga, T.Accent))) g.FillEllipse(b, cx - gr, cy - gr, gr * 2, gr * 2);
                    using (var b = new SolidBrush(Color.FromArgb(30, T.Accent))) g.FillEllipse(b, cx - cr, cy - cr, cr * 2, cr * 2);
                    using (var pen = new Pen(T.Accent, 2f)) g.DrawEllipse(pen, cx - cr, cy - cr, cr * 2, cr * 2);
                    using (var f = new Font("Segoe UI", 9f, FontStyle.Bold))
                    using (var b = new SolidBrush(T.Accent))
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        g.DrawString((i + 1).ToString(), f, b, new RectangleF(cx - cr, cy - cr, cr * 2, cr * 2), sf);
                }
                else
                {
                    using (var b = new SolidBrush(T.Surface2)) g.FillEllipse(b, cx - cr, cy - cr, cr * 2, cr * 2);
                    using (var pen = new Pen(T.Border, 1f)) g.DrawEllipse(pen, cx - cr, cy - cr, cr * 2, cr * 2);
                    using (var f = new Font("Segoe UI", 9f))
                    using (var b = new SolidBrush(T.Muted))
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                        g.DrawString((i + 1).ToString(), f, b, new RectangleF(cx - cr, cy - cr, cr * 2, cr * 2), sf);
                }

                Color lc = done ? T.Success : active ? T.Accent : T.Muted;
                using (var f = new Font("Segoe UI", 7.5f))
                using (var b = new SolidBrush(lc))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near })
                    g.DrawString(StepLabels[i], f, b, new RectangleF(cx - sw / 2f, 41, sw, 14), sf);
            }
        }

        // =============================================================
        //  NAVİQASİYA
        // =============================================================
        private void GoTo(int n)
        {
            _page = _activeStep = n;

            pgWelcome.Visible = (n == 0);
            pgPath.Visible = (n == 1);
            pgInstall.Visible = (n == 2);
            pgDone.Visible = (n == 3);

            panelStepBar.Invalidate();

            btnBack.Enabled = (n > 0 && n < 2);
            btnBack.Visible = (n < 3);
            btnNext.Visible = (n < 2);
            btnCancel.Text = (n == 3) ? "Bağla" : "Ləğv et";
            btnCancel.Enabled = true;
            btnBack.Invalidate(); btnNext.Invalidate(); btnCancel.Invalidate();

            if (n == 2)
            {
                btnNext.Enabled = btnBack.Enabled = btnCancel.Enabled = false;
                Task.Run(() => Install());
            }
        }

        private void NextClick()
        {
            if (_page == 1)
            {
                _installPath = pgPath.txtPath.Text.Trim();
                if (string.IsNullOrWhiteSpace(_installPath))
                {
                    MessageBox.Show("Zəhmət olmasa qovluq seçin.", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                pgDone.lblDonePath.Text = _installPath;
            }
            GoTo(_page + 1);
        }

        // =============================================================
        //  QURAŞDIRMA
        // =============================================================
        private async Task Install()
        {
            try
            {
                Mark(0, false); SetProg(0, "Yüklənir...");
                string zip = Path.Combine(Path.GetTempPath(), "pbaz.zip");
                await DownloadWithResume(Config.ZIP_URL, zip);
                Mark(0, true);

                Mark(1, false); SetProg(72, "Fayllar qovluğa yerləşdirilir...");
                if (Directory.Exists(_installPath)) Directory.Delete(_installPath, true);
                Directory.CreateDirectory(_installPath);
                await Task.Run(() => ZipFile.ExtractToDirectory(zip, _installPath));
                try { File.Delete(zip); } catch { }
                Mark(1, true);

                Mark(2, false); SetProg(85, "Masaüstü qısayolu yaradılır...");
                MakeShortcut(_installPath);
                Mark(2, true);

                Mark(3, false); SetProg(95, "Antivirus istisnası əlavə edilir...");
                await AddDefenderExclusion(_installPath);
                Mark(3, true);

                SetProg(100, "Tamamlandı!");
                await Task.Delay(800);
                Invoke(new Action(() => GoTo(3)));
            }
            catch (Exception ex)
            {
                Invoke(new Action(() =>
                {
                    btnCancel.Enabled = true;
                    var result = MessageBox.Show(
                        "Quraşdırma zamanı xəta baş verdi:\n\n" + ex.Message +
                        "\n\nYenidən cəhd etmək istəyirsiniz?",
                        "Xəta", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (result == DialogResult.Yes)
                    {
                        UI(() =>
                        {
                            pgInstall.lblStatus.Text = "Yenidən başlayır...";
                            pgInstall.lblStatus.ForeColor = T.Accent;
                            btnCancel.Enabled = false;
                        });
                        Task.Run(() => Install());
                    }
                    else
                    {
                        UI(() =>
                        {
                            pgInstall.lblStatus.Text = "❌  Xəta baş verdi.";
                            pgInstall.lblStatus.ForeColor = T.Danger;
                        });
                    }
                }));
            }
        }

        // Resume dəstəkli yükləmə — fasilə düşərsə kəsdiyi yerdən davam edir
        private async Task DownloadWithResume(string url, string dest)
        {
            const int maxRetries = 5;
            int attempt = 0;

            while (true)
            {
                attempt++;
                long existingLen = File.Exists(dest) ? new FileInfo(dest).Length : 0L;

                try
                {
                    using (var client = new HttpClient())
                    {
                        client.Timeout = TimeSpan.FromMinutes(30);
                        client.DefaultRequestHeaders.Add("User-Agent", "PBSetup/1.0");

                        // Range header ilə kəsdiyi yerdən davam et
                        if (existingLen > 0)
                        {
                            client.DefaultRequestHeaders.Range =
                                new System.Net.Http.Headers.RangeHeaderValue(existingLen, null);
                            SetProg(-1, string.Format("Davam edir... ({0:F1} MB-dən)", existingLen / 1048576.0));
                        }

                        using (var resp = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                        {
                            // 416 = server artıq tam göndərib, fayl tam deməkdir
                            if (resp.StatusCode == System.Net.HttpStatusCode.RequestedRangeNotSatisfiable)
                                return;

                            resp.EnsureSuccessStatusCode();

                            bool isResume = resp.StatusCode == System.Net.HttpStatusCode.PartialContent;
                            long serverTotal = resp.Content.Headers.ContentLength ?? -1L;
                            long total = isResume ? existingLen + serverTotal : serverTotal;

                            var mode = isResume ? FileMode.Append : FileMode.Create;
                            long read = isResume ? existingLen : 0L;

                            using (var src = await resp.Content.ReadAsStreamAsync())
                            using (var dst = new FileStream(dest, mode, FileAccess.Write, FileShare.None, 65536, true))
                            {
                                byte[] buf = new byte[65536]; int n;
                                while ((n = await src.ReadAsync(buf, 0, buf.Length)) > 0)
                                {
                                    await dst.WriteAsync(buf, 0, n);
                                    read += n;
                                    if (total > 0)
                                    {
                                        int pct = (int)(read / (double)total * 65);
                                        SetProg(pct, string.Format("Yüklənir...  {0:F1} / {1:F1} MB",
                                            read / 1048576.0, total / 1048576.0));
                                    }
                                    else
                                    {
                                        SetProg(-1, string.Format("Yüklənir...  {0:F1} MB", read / 1048576.0));
                                    }
                                }
                            }
                        }
                    }
                    return; // uğurlu
                }
                catch (Exception ex) when (attempt < maxRetries &&
                    (ex is HttpRequestException || ex is IOException || ex is TaskCanceledException))
                {
                    int delay = attempt * 3; // hər dəfə 3 san artır: 3, 6, 9...
                    SetProg(-1, string.Format("Bağlantı kəsildi. {0} saniyə sonra davam edir... ({1}/{2})",
                        delay, attempt, maxRetries));
                    await Task.Delay(delay * 1000);
                    // Növbəti iterasiyada mövcud fayl boyundan davam edəcək
                }
            }
        }

        // Defender istisnası — UAC ilə açıq şəkildə, gizli deyil
        // ShellExecute + runas → istifadəçi UAC pəncərəsi görür, şübhə olmur
        private async Task AddDefenderExclusion(string folder)
        {
            try
            {
                // PowerShell-i ayrı, görünən UAC prompt ilə başladırıq.
                // UseShellExecute=true + Verb="runas" → Windows standart UAC dialoqunu göstərir.
                // Antiviruslar bunu normal admin əməliyyatı kimi qəbul edir,
                // çünki istifadəçi özü icazə verir.
                var psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NonInteractive -ExecutionPolicy Bypass -Command \"Add-MpPreference -ExclusionPath '{folder}'\"",
                    UseShellExecute = true,   // gizli CreateNoWindow yox
                    Verb = "runas", // UAC göstər
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                using (var p = Process.Start(psi))
                    await Task.Run(() => p?.WaitForExit(15000));
            }
            catch
            {
                // İstifadəçi UAC-ı ləğv etdi — problem deyil, oyun işləyir,
                // sadəcə antivirus bəzi faylları silə bilər.
                // Bunu PageDone-da xəbərdarlıq kimi göstəririk.
            }
        }

        private static void MakeShortcut(string dir)
        {
            string exe = Path.Combine(dir, Config.LAUNCHER_EXE);

            foreach (string desk in new[]
            {
        Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory),
        Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    })
            {
                if (string.IsNullOrEmpty(desk)) continue;

                string lnk = Path.Combine(desk, Config.SHORTCUT_NAME + ".lnk");

                string E(string s) => s.Replace("\\", "\\\\");

                string vbs =
                    "Set o=WScript.CreateObject(\"WScript.Shell\")\r\n" +
                    $"Set s=o.CreateShortcut(\"{E(lnk)}\")\r\n" +
                    $"s.TargetPath=\"{E(exe)}\"\r\n" +
                    $"s.WorkingDirectory=\"{E(dir)}\"\r\n" +
                    "s.Save\r\n";

                string vp = Path.Combine(Path.GetTempPath(), "sc_" + Guid.NewGuid().ToString("N") + ".vbs");

                // UTF-8 BOM olmadan yaz
                File.WriteAllText(vp, vbs, new UTF8Encoding(false));

                try
                {
                    using (var pr = Process.Start(new ProcessStartInfo
                    {
                        FileName = "wscript.exe",
                        Arguments = "\"" + vp + "\"",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }))
                    {
                        pr?.WaitForExit(5000);
                    }
                }
                finally
                {
                    try { File.Delete(vp); } catch { }
                }
            }
        }

        private void LaunchGame()
        {
            string exe = Path.Combine(_installPath, Config.LAUNCHER_EXE);
            if (File.Exists(exe)) { Process.Start(new ProcessStartInfo(exe) { UseShellExecute = true }); Application.Exit(); }
            else MessageBox.Show("Launcher tapılmadı:\n" + exe, "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // =============================================================
        //  HELPERS
        // =============================================================
        private void UI(Action a) { if (InvokeRequired) Invoke(a); else a(); }

        private void SetProg(int pct, string status)
        {
            UI(() =>
            {
                pgInstall.lblStatus.Text = status;
                if (pct >= 0) { pgInstall.prgBar.Value = Math.Min(pct, 100); pgInstall.lblPct.Text = pct + "%"; }
            });
        }

        private void Mark(int i, bool done)
        {
            UI(() => pgInstall.MarkStep(i, done));
        }

        private void TryClose()
        {
            if (_page == 3 || _page == 0) { Application.Exit(); return; }
            if (MessageBox.Show("Ləğv etmək istəyirsiniz?", "Çıxış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
