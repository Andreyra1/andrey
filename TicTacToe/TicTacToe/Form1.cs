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

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true;
        string winner;
        int turnCount;
        int gamemode;
        Random r;
        int button, x, y;
        int[,] array = new int[3, 3];
        Button[,] Buttons = new Button[3, 3];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(100, 100);
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.BackgroundImage = Properties.Resources.Back;
                    button.Font = new Font("Broken Chalk", 48);
                    button.ForeColor = System.Drawing.Color.Blue;
                    button.Location = new Point(12 + (106 * i), 72 + (106 * j));
                    button.Click += new EventHandler(button_Click);
                    Buttons[i, j] = button;
                    this.Controls.Add(button);
                }
            }
            stripMenuImpossble_Click(null, null);
            btnNewGame.Visible = false;
        }

        private void stripMenuEasy_Click(object sender, EventArgs e)
        {
            gamemode = 1;
            NewGame();
            labelP1.Text = "PLAYER";
            labelP2.Text = "COMPUTER(E)";
            CountNull();
        }


        private void stripMenuNormal_Click(object sender, EventArgs e)
        {
            gamemode = 2;
            NewGame();
            labelP1.Text = "PLAYER";
            labelP2.Text = "COMPUTER(N)";
            CountNull();
        }

        private void stripMenuImpossble_Click(object sender, EventArgs e)
        {
            gamemode = 3;
            NewGame();
            labelP1.Text = "PLAYER";
            labelP2.Text = "COMPUTER(I)";
            CountNull();
        }

        private void stripMenuPvP_Click(object sender, EventArgs e)
        {
            gamemode = 4;
            NewGame();
            labelP1.Text = "PLAYER 1";
            labelP2.Text = "PLAYER 2";
            CountNull();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Buttons[i, j] == sender)
                    {
                        ShowButton();
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
            for(int i=0;i<3;i++)
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
                SystemSounds.Hand.Play();
                MessageBox.Show("" + winner + " WIN", "Victory", MessageBoxButtons.OK);
                if(winner=="X")
                    labelCount1.Text = Convert.ToString(Convert.ToInt32(labelCount1.Text) + 1);
                else
                    labelCount2.Text = Convert.ToString(Convert.ToInt32(labelCount2.Text) + 1);
                NewGame();
            }
            if (turnCount == 9)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("DRAW", "Draw", MessageBoxButtons.OK);
                labelCountD.Text = Convert.ToString(Convert.ToInt32(labelCountD.Text) + 1);
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
                Draw(turn, x,y);
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
                    Draw(turn, x,y);
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
                    ButtonPress(x,y);
                }
                else
                {
                    if (TicTac.CheckTrap(array, turnCount, out button) == true)
                    {
                        MessageBox.Show(button.ToString());
                        TicTac.ButtonToArray(button, out x, out y);
                        ButtonPress(x, y);
                    }
                    else
                    {
                        if (array[1, 1] == 0)
                            ButtonPress(1,1);
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

        private void ButtonPress(int i,int j)
        {
                    Draw(turn, i,j);
                    array[i, j] = TicTac.SetValue(turn);
                    NextTurn();
        }

        private void ShowButton()
        {
                btnNewGame.Visible = true;
        }
    }
}