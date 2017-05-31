using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        int[,] n;
        int[,] array;
        bool pause=true;
        public int x = 70;
        public int y = 280;
        public int speed = 0;
        public bool mode = false;
        public  int percentage = 10;
        public Form1()
        {
            InitializeComponent();
        }

        private void tsmiStart_Click(object sender, EventArgs e)
        {
            pause = false;
            array = Life.Array(x, y);
            n = Life.Array(x, y);
            Life.Random(ref array, x, y, percentage);
            textBox.Text = Life.Draw(array, y);
            if (backgroundWorker1 != null && backgroundWorker1.IsBusy)
             {
                 backgroundWorker1.CancelAsync();
             }
             else
             {
                 if (backgroundWorker1 != null && !backgroundWorker1.CancellationPending)
                     backgroundWorker1.RunWorkerAsync();
             }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (pause == false)
            {
                textBox.Text = Life.Draw(array, y);
                Life.Game(ref array, out n, x, y, mode);
                System.Threading.Thread.Sleep(speed);
            }

        }

        private void tsmiStop_Click(object sender, EventArgs e)
        {
            pause = true;
        }

        private void tsmiSettings_Click(object sender, EventArgs e)
        {
            if (pause == true)
            {
                FormSettings Settings = new FormSettings(this);
                Settings.Show();
            }
            else
                MessageBox.Show("Stop the game", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tsmiContinue_Click(object sender, EventArgs e)
        {
            pause = false;
            if (backgroundWorker1 != null && backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
            else
            {
                if (backgroundWorker1 != null && !backgroundWorker1.CancellationPending)
                    backgroundWorker1.RunWorkerAsync();
            }
        }

        private void gliderGunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pause == true)
            {
                pause = false;
                array = Life.Array(x, y);
                n = Life.Array(x, y);
                Life.Gun(ref array, x, y, percentage);
                textBox.Text = Life.Draw(array, y);
                if (backgroundWorker1 != null && backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                }
                else
                {
                    if (backgroundWorker1 != null && !backgroundWorker1.CancellationPending)
                        backgroundWorker1.RunWorkerAsync();
                }
            }
            else
                MessageBox.Show("Stop the game", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}