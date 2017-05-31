using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenu
{
    public partial class FormPause : Form
    {
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
    }
}
