using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Drawing.Text;

namespace MainMenu
{
    public partial class FormTicTac : ParentForm
    {
        public FormTicTac()
        {
            InitializeComponent();
        }
        SoundPlayer DrawSound = new SoundPlayer(Properties.Resources.Draw);
        SoundPlayer Write = new SoundPlayer(Properties.Resources.TicTacDraw);
        SoundPlayer Win = new SoundPlayer(Properties.Resources.Win);
        SoundPlayer Lose = new SoundPlayer(Properties.Resources.Lose);
        int winP1, winP2, draw;
        bool turn = true;
        string winner;
        int turnCount;
        int gamemode;
        Random r;
        int button, x, y;
        int[,] array = new int[3, 3];
        Button[,] Buttons = new Button[3, 3];

        private void FormTicTac_Load(object sender, EventArgs e)
        {
            brokenChalk = new Font(fonts.Families[0], 26.25F);
            labelCount1.Font = brokenChalk;
            labelCount2.Font = brokenChalk;
            labelCountD.Font = brokenChalk;
            labelP1.Font = brokenChalk;
            labelP2.Font = brokenChalk;
            label1.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 15.75F);
            label2.Font = brokenChalk;
            comboBox.Font = brokenChalk;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(175, 175);
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.BackgroundImage = Properties.Resources.Back;
                    button.Font = new Font("Broken Chalk", 72);
                    button.ForeColor = System.Drawing.Color.Blue;
                    button.Location = new Point(275 + (180 * i), 150 + (180 * j));
                    button.Click += new EventHandler(button_Click);
                    Buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            gamemode = 3;
            NewGame();
            labelP1.Text = "PLAYER";
            labelP2.Text = "COMPUTER(I)";
            CountNull();
            /*this.BringToFront();
            this.Focus()*/
            this.KeyPreview = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Buttons[i, j] == sender)
                    {
                        switch (gamemode)
                        {
                            case 1:
                                if (array[i, j] == 0)
                                {
                                    ButtonPress(i, j);
                                    RandomMove();
                                }
                                else
                                    SystemSounds.Beep.Play();
                                break;
                            case 2:
                                if (array[i, j] == 0)
                                {
                                    ButtonPress(i, j);
                                    Normal();
                                }
                                else
                                    SystemSounds.Beep.Play();
                                break;
                            case 3:
                                if (array[i, j] == 0)
                                {
                                    ButtonPress(i, j);
                                    Impossible();
                                }
                                else
                                    SystemSounds.Beep.Play();
                                break;
                            case 4:
                                if (array[i, j] == 0)
                                {
                                    ButtonPress(i, j);
                                }
                                else
                                    SystemSounds.Beep.Play();
                                break;
                            default: break;
                        }
                    }
                }
            }
        }

        private void ClearSheet()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Buttons[i, j].Text = "";
                }
            }

        }
        private void Draw(bool turn, int i, int j)
        {
            if (turn == true)
                Buttons[i, j].Text = "X";
            else
                Buttons[i, j].Text = "O";

        }

        private void NewGame()
        {
            TicTac.ClearArray(ref array);
            ClearSheet();
            turn = true;
            turnCount = 0;
        }


        private void NextTurn()
        {
            turn = !turn;
            turnCount++;
            if (TicTac.CheckWin(array, out winner) == true)
            {
                if (winner == "X")
                {
                    Win.Play();
                    winP1++;
                    labelCount1.Text = Convert.ToString(winP1);
                }
                else
                {
                    Lose.Play();
                    winP2++;
                    labelCount2.Text = Convert.ToString(winP2);
                }
                MessageBox.Show("" + winner + " WIN", "Victory", MessageBoxButtons.OK);
                NewGame();
            }
            if (turnCount == 9)
            {
                DrawSound.Play();
                MessageBox.Show("DRAW", "Draw", MessageBoxButtons.OK);
                draw++;
                labelCountD.Text = Convert.ToString(draw);
                NewGame();
            }
        }

        private void RandomMove()
        {
            if (turnCount > 0)
            {
                r = new Random();
                button = r.Next(1, 9);
                TicTac.ButtonToArray(button, out x, out y);
                while (array[x, y] != 0)
                {
                    button = r.Next(1, 9);
                    TicTac.ButtonToArray(button, out x, out y);
                }
                Draw(turn, x, y);
                array[x, y] = TicTac.SetValue(turn);
                NextTurn();
            }
        }

        private void Normal()
        {
            if (turnCount > 0)
            {
                if (TicTac.CheckAlmost(array, out x, out y) == true)
                {
                    Draw(turn, x, y);
                    array[x, y] = TicTac.SetValue(turn);
                    NextTurn();
                }
                else
                    RandomMove();
            }
        }

        private void Impossible()
        {
            if (turnCount > 0)
            {
                if (TicTac.CheckAlmost(array, out x, out y) == true)
                {
                    ButtonPress(x, y);
                }
                else
                {
                    if (TicTac.CheckTrap(array, turnCount, out button) == true)
                    {
                        TicTac.ButtonToArray(button, out x, out y);
                        ButtonPress(x, y);
                    }
                    else
                    {
                        if (array[1, 1] == 0)
                            ButtonPress(1, 1);
                        else
                        {
                            button = TicTac.RandomCorner(array);
                            if (button != 0)
                            {
                                TicTac.ButtonToArray(button, out x, out y);
                                ButtonPress(x, y);
                            }
                            else
                                RandomMove();
                        }
                    }
                }
            }
        }

        private void CountNull()
        {
            labelCount1.Text = "0";
            labelCount2.Text = "0";
            labelCountD.Text = "0";
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox.Text)
            {
                case "EASY":
                    {
                        gamemode = 1;
                        NewGame();
                        labelP1.Text = "PLAYER";
                        labelP2.Text = "COMPUTER(E)";
                        CountNull();
                    }
                    break;
                case "NORMAL":
                    {
                        gamemode = 2;
                        NewGame();
                        labelP1.Text = "PLAYER";
                        labelP2.Text = "COMPUTER(N)";
                        CountNull();
                    }
                    break;
                case "IMPOSSIBLE":
                    {
                        gamemode = 3;
                        NewGame();
                        labelP1.Text = "PLAYER";
                        labelP2.Text = "COMPUTER(I)";
                        CountNull();
                    }
                    break;
                case "PLAYER VS PLAYER":
                    {
                        gamemode = 4;
                        NewGame();
                        labelP1.Text = "PLAYER 1";
                        labelP2.Text = "PLAYER 2";
                        CountNull();
                    }
                    break;
                default:
                    MessageBox.Show("Choose game mode");
                    break;
            }
        }

        private void FormTicTac_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Escape:
                    {
                        FormPause Pause = new FormPause(this);
                        Pause.ShowDialog();
                    }
                    break;
            }
        }

        private void FormTicTac_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ButtonPress(int i, int j)
        {
            if (array[i,j]==0)
            {
                Write.Play();
                Draw(turn, i, j);
                array[i, j] = TicTac.SetValue(turn);
                NextTurn();
            }
        }
    }
}
