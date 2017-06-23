using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Drawing.Text;
namespace MainMenu
{
    public partial class Form1 : ParentForm
    {
        public Form1()
        {
            InitializeComponent();
        }
                       
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBattleships_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            FormBattleships Battleships = new FormBattleships();
            Battleships.Show();
            this.Hide();
        }

        private void btnTicTac_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            FormTicTac TIcTac = new FormTicTac();
            TIcTac.Show();
            this.Hide();
        }

        private void btnTetris_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            FormTetris Tetris = new FormTetris();
            Tetris.Show();
            this.Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBattleships_MouseEnter(object sender, EventArgs e)
        {
            labelName.Text = "BATTLESHIPS";
            labelText.Text = "IT IS SIMPLE! BUILD YOUR SHIPS AND\r\nDESTROY YOUR FRIEND'S ONES IN THIS\r\nEPIC GAME OF BATTLESHIPS!";
            pictureBox.Image = Properties.Resources.ScreenshotBattleships;
        }

        private void btnTicTac_MouseEnter(object sender, EventArgs e)
        {
            labelName.Text = "TIC-TAC-TOE";
            labelText.Text = "YOU THINK YOU ARE SO GOOD AT TIC TAC TOE?\r\nWELL,TRY TO BEAT OUR IMPOSSIBLE AI!";
            pictureBox.Image = Properties.Resources.ScreenshotTicTac;
        }

        private void btnTetris_MouseEnter(object sender, EventArgs e)
        {
            labelName.Text = "TETRIS";
            labelText.Text = "GOOD OLD TETRIS IS BACK AND IT IS\r\nWAITING FOR YOU TO SET\r\n A NEW WORLD RECORD!";
            pictureBox.Image = Properties.Resources.ScreenshotTetris;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            brokenChalk = new Font(fonts.Families[0], 20.25F);
            label.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 9.75F);
            btnBattleships.Font = brokenChalk;
            btnTicTac.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 18.00F);
            btnTetris.Font = brokenChalk;
            btnExit.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 15.75F);
            labelText.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 27.75F);
            labelName.Font = brokenChalk;
            player.URL = "Music/Main.wav";
            player.controls.play();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
            this.KeyPreview = true;
        }
    }
}
