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
namespace MainMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //TODO
        //
        //                                    Add Music
        //Battleships AI
        //                                    Credits  
        //Scores
        //try catch

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

        private void btnDurak_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            FormDurak Durak = new FormDurak();
            Durak.Show();
            this.Hide();
        }

        private void btnTetris_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            FormTetris Tetris = new FormTetris();
            Tetris.Show();
            this.Hide();
        }

        private void HideMenu()
        {
            label.Hide();
            btnBattleships.Hide();
            btnDurak.Hide();
            btnExit.Hide();
            btnTetris.Hide();
            btnTicTac.Hide();
            labelName.Hide();
            pictureBox.Hide();
            labelText.Hide();
            bigSquare.Hide();
            smallSquare.Hide();
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

        private void btnDurak_MouseEnter(object sender, EventArgs e)
        {
            labelName.Text = "DURAK: THE CARD GAME";
            labelText.Text = "PLAY ONE OF THE MOST FAMOUS CARD GAMES \r\nIN THE WORLD!\r\nIT IS YOU AGAINST THE PC! FIND OUT WHO IS\r\nA BETTER PLAYER!";
            pictureBox.Image = Properties.Resources.ScreenshotDurak;
        }

        private void btnTetris_MouseEnter(object sender, EventArgs e)
        {
            labelName.Text = "TETRIS";
            labelText.Text = "GOOD OLD TETRIS IS BACK AND IT IS\r\nWAITING FOR YOU TO SET\r\n A NEW WORLD RECORD!";
            pictureBox.Image = Properties.Resources.ScreenshotTetris;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.URL = "Music/SongOne.wav";
            player.controls.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormCredits Credits = new FormCredits();
            Credits.Show();
        }
    }
}
