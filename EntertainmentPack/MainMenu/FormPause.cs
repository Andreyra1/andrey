using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
namespace MainMenu
{
    public partial class FormPause : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font brokenChalk;
        byte[] fontData = Properties.Resources.BrokenChalk;
        Form original;
        FormTetris tetris;
        bool x1=false;
        public FormPause(Form incoming)
        {
            InitializeComponent();
            original = incoming;
        }
        public FormPause(FormTetris tetrisIN, bool x2)
        {
            InitializeComponent();
            tetris = tetrisIN;
            x1 = x2;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if(x1 == true)
            {
                tetris.timer1.Enabled = true;
            }
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            Form1 form = new Form1();
            form.Show();
            this.Close();
            if (x1 == true)
            {
                tetris.Hide();
                tetris.player.controls.stop();
            }
            else
            {
                //original.player.controls.stop();
                original.Hide();
            }
        }

        private void FormPause_Load(object sender, EventArgs e)
        {
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.BrokenChalk.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.BrokenChalk.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            brokenChalk = new Font(fonts.Families[0], 21.75F);
            btnContinue.Font = brokenChalk;
            btnExit.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 36.00F);
            label1.Font = brokenChalk;
        }
    }
}
