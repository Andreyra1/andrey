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
    public partial class FormBattleships : Form
    {
        public FormBattleships()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font brokenChalk;
        byte[] fontData = Properties.Resources.BrokenChalk;
        SoundPlayer Down = new SoundPlayer(Properties.Resources.TetrisDown);
        SoundPlayer Kill = new SoundPlayer(Properties.Resources.BattleshipsDeath);
        SoundPlayer Hit = new SoundPlayer(Properties.Resources.BattleshipsHit);
        SoundPlayer Miss = new SoundPlayer(Properties.Resources.BattleshipsMiss);
        SoundPlayer Rotate = new SoundPlayer(Properties.Resources.TetrisRotate);
        SoundPlayer Win = new SoundPlayer(Properties.Resources.Win);
        Panel[,] Field1 = new Panel[10, 10];
        Panel[,] Field2 = new Panel[10, 10];
        Panel[,] Field = new Panel[10, 10];
        int[,] fieldArray1 = new int[12, 12];
        int[,] fieldArray2 = new int[12, 12];
        int[,] fieldArray = new int[12, 12];
        int x = 3;
        int y = 4;
        int horizontal = 0;
        int vertical = 0;
        int shipAmmount = -1;
        bool place;
        bool game = false;
        bool turn = false;
        int score1 = 0;
        int score2 = 0;

        private void FormBattleships_Load(object sender, EventArgs e)
        {
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.BrokenChalk.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.BrokenChalk.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            brokenChalk = new Font(fonts.Families[0], 36.00F);
            btnNextTurn.Font = brokenChalk;
            NewGame();
        }

        private void NewGame()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            CreatePanel(18, Field1);
            CreatePanel(592, Field2);
            Field = Field1;
            fieldArray = fieldArray1;
            Battleships.NextShip(ref horizontal, ref vertical, ref shipAmmount);
            DrawShip(horizontal, vertical, fieldArray, ref Field);     
        }

        private void Restart()
        {
            x = 3;
            y = 4;
            horizontal = 0;
            vertical = 0;
            shipAmmount = -1;
            place = true;
            game = false;
            turn = false;
            score1 = 0;
            score2 = 0;
            Clear(ref Field1);
            Clear(ref Field2);
            Battleships.NullArray(ref fieldArray);
            Battleships.NullArray(ref fieldArray1);
            Battleships.NullArray(ref fieldArray2);
            Field = Field1;
            fieldArray = fieldArray1;
            Battleships.NextShip(ref horizontal, ref vertical, ref shipAmmount);
            DrawShip(horizontal, vertical, fieldArray, ref Field);
        }


        private void CreatePanel(int pos, Panel[,] panel)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Panel cell = new MyPanel();
                    cell.Size = new Size(47, 46);
                    cell.BackColor = System.Drawing.Color.Transparent;
                    cell.BackgroundImageLayout = ImageLayout.Stretch;
                    cell.MouseEnter += new EventHandler(Panel_Hover);
                    cell.MouseClick += new MouseEventHandler(Panel_Click);
                    cell.Location = new Point(pos + ((47 + 1) * i), 48 + ((46 + 1) * j));
                    panel[i, j] = cell;
                    this.Controls.Add(cell);
                }
            }
        }

        private void Clear(ref Panel[,] panel)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    panel[i, j].BackgroundImage = null;
                }
            }
        }

        private void Draw(int[,] array, ref Panel[,] panel)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    switch (array[i + 1, j + 1])
                    {
                        case 0: panel[i, j].BackgroundImage = null; break;
                        case 1:if(panel[i, j].BackgroundImage != Properties.Resources.Miss)
                            panel[i, j].BackgroundImage = Properties.Resources.Miss; break;
                        case 2:
                            if (panel[i, j].BackgroundImage != Properties.Resources.Alive)
                                panel[i, j].BackgroundImage = Properties.Resources.Alive; break;
                        case 3:
                            if (panel[i, j].BackgroundImage != Properties.Resources.Damaged)
                                panel[i, j].BackgroundImage = Properties.Resources.Damaged; break;
                        case 4:
                            if(panel[i, j].BackgroundImage != Properties.Resources.Dead)
                            panel[i, j].BackgroundImage = Properties.Resources.Dead;
                            panel[i, j].BackgroundImage = Properties.Resources.Dead; break;
                    }
                }
            }
        }
        private void DrawGame(int[,] array, ref Panel[,] panel)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    switch (array[i + 1, j + 1])
                    {
                        case 0: panel[i, j].BackgroundImage = null; break;
                        case 1: panel[i, j].BackgroundImage = Properties.Resources.Miss; break;
                        case 2: panel[i, j].BackgroundImage = null; break;
                        case 3: panel[i, j].BackgroundImage = Properties.Resources.Damaged; break;
                        case 4: panel[i, j].BackgroundImage = Properties.Resources.Dead; break;
                    }
                }
            }
        }

        private void DrawShip(int horizontal, int vertical, int[,] array, ref Panel[,] panel)
        {
            int color = 0;
            if (Battleships.CheckPlace(x, y, horizontal, vertical, fieldArray, ref place) == true)
            {
                color = 0;
            }
            else
            {
                color = 1;
            }
            for (int i = x; i < x + horizontal; i++)
            {
                for (int j = y; j < y + vertical; j++)
                {
                    if (color == 0)
                    {
                        panel[i, j].BackgroundImage = Properties.Resources.NewGreen;
                    }
                    else
                    {
                        panel[i, j].BackgroundImage = Properties.Resources.NewRed;
                    }
                }
            }
        }

        private void FormBattleships_KeyDown(object sender, KeyEventArgs e)
        {
            if (game == false)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:

                        if (x > 0)
                        {
                            x--;
                            //Clear(ref Field);
                            Draw(fieldArray, ref Field);
                            DrawShip(horizontal, vertical, fieldArray, ref Field);
                        }
                        break;
                    case Keys.Up:
                        if (y > 0)
                        {
                            y--;
                            //Clear(ref Field);
                            Draw(fieldArray, ref Field);
                            DrawShip(horizontal, vertical, fieldArray, ref Field);
                        }
                        break;
                    case Keys.Right:
                        if (x + horizontal < 10)
                        {
                            x++;
                            //Clear(ref Field);
                            Draw(fieldArray, ref Field);
                            DrawShip(horizontal, vertical, fieldArray, ref Field);
                        }
                        break;
                    case Keys.Down:
                        if (y + vertical < 10)
                        {
                            y++;
                            //Clear(ref Field);
                            Draw(fieldArray, ref Field);
                            DrawShip(horizontal, vertical, fieldArray, ref Field);
                        }
                        break;
                    case Keys.Enter:
                        if (place == true)
                        {
                            Down.Play();              
                            Battleships.SetShip(ref fieldArray, x, y, true, horizontal, vertical);
                            Draw(fieldArray, ref Field);
                            if (Battleships.NextShip(ref horizontal, ref vertical, ref shipAmmount) != true)
                            {
                                Clear(ref Field);
                                Battleships.ShootingMode(ref fieldArray);
                                if (Field != Field2)
                                {
                                    Field = Field2;
                                    fieldArray = fieldArray2;
                                    shipAmmount = -1;
                                    Battleships.NextShip(ref horizontal, ref vertical, ref shipAmmount);
                                    DrawShip(horizontal, vertical, fieldArray, ref Field);
                                }
                                else
                                {
                                    game = true;
                                    Clear(ref Field);
                                    Battleships.ShootingMode(ref fieldArray);
                                    NextTurn(ref turn);
                                }
                            }
                            else
                            {
                                if (x > 7)
                                {
                                    x = 7;
                                }
                                DrawShip(horizontal, vertical, fieldArray, ref Field);
                            }
                        }
                        break;
                    case Keys.ShiftKey:
                        if (horizontal > vertical)
                        {
                            Rotate.Play();
                            if (y + horizontal < 11)
                            {
                                Clear(ref Field);
                                Draw(fieldArray, ref Field);
                                Battleships.Rotate(ref horizontal, ref vertical);
                                DrawShip(horizontal, vertical, fieldArray, ref Field);
                                break;
                            }
                        }
                        if (vertical > horizontal)
                        {
                            if (x + vertical < 11)
                            {
                                Clear(ref Field);
                                Draw(fieldArray, ref Field);
                                Battleships.Rotate(ref horizontal, ref vertical);
                                DrawShip(horizontal, vertical, fieldArray, ref Field);
                                break;
                            }
                        }
                        break;
                    case Keys.Escape:
                        {
                            FormPause Pause = new FormPause(this);
                            Pause.ShowDialog();
                        }
                        break;
                }
            }
        }

        private void Shoot(int i, int j, int x)
        {
            if (x == 1)
            {
                Field = Field1;
                fieldArray = fieldArray1;
            }
            else
            {
                Field = Field2;
                fieldArray = fieldArray2;
            }

            if (fieldArray[i + 1, j + 1] == (int)Battleships.State.Empty)
            {
                Miss.Play();
                Field[i, j].BackgroundImage = Properties.Resources.Miss;
                fieldArray[i + 1, j + 1] = (int)Battleships.State.Miss;
                btnNextTurn.Visible = true;
                NextTurn(ref turn);

            }
            if (fieldArray[i + 1, j + 1] == (int)Battleships.State.Alive)
            {
                if (Battleships.CheckShipState(i, j, fieldArray) == true)
                {
                    Hit.Play();
                    Field[i, j].BackgroundImage = Properties.Resources.Damaged;
                    fieldArray[i + 1, j + 1] = (int)Battleships.State.Damaged;
                }
                else
                {
                    Kill.Play();
                    Battleships.KillShip(i, j, fieldArray);
                    DrawGame(fieldArray, ref Field);
                    AddScore(turn);
                }
            }
        }

        private void NextTurn(ref bool turn)
        {
            turn = !turn;
            if (turn == false)
            {
                Draw(fieldArray1, ref Field1);
                DrawGame(fieldArray2, ref Field2);
            }
            else
            {
                DrawGame(fieldArray1, ref Field1);
                Draw(fieldArray2, ref Field2);
            }
        }

        private void AddScore(bool turn)
        {

            if (turn == true)
            {
                score1++;
                if (score1 > 9)
                {
                    Win.Play();
                    MessageBox.Show("WIN1");
                    Restart();
                }
            }
            else
            {
                score2++;
                if (score2 > 9)
                {
                    Win.Play();
                    MessageBox.Show("WIN2");
                    Restart();
                }
            }
        }

        private void FormBattleships_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Panel_Hover(object sender, EventArgs e)
        {
            if(game==false)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (sender == Field[i, j])
                        {
                            x = i;
                            y = j;
                            if (y + vertical > 9)
                            {
                                y = 10 - vertical;
                            }
                            if (x + horizontal > 9)
                            {
                                x = 10 - horizontal;
                            }
                            Draw(fieldArray, ref Field);
                            DrawShip(horizontal, vertical, fieldArray, ref Field);
                        }
                    }
                }
            }
        }

        private void Panel_Click(object sender, MouseEventArgs me)
        {
            if(game==false)
            {
                if (me.Button == MouseButtons.Right)
                {
                    Rotate.Play();
                    for (int i = 0; i < 1; i++)
                    {
                        if (horizontal > vertical)
                        {
                            if (y + horizontal < 11)
                            {
                                Clear(ref Field);
                                Draw(fieldArray, ref Field);
                                Battleships.Rotate(ref horizontal, ref vertical);
                                DrawShip(horizontal, vertical, fieldArray, ref Field);
                                break;
                            }
                        }
                        if (vertical > horizontal)
                        {
                            if (x + vertical < 11)
                            {
                                Clear(ref Field);
                                Draw(fieldArray, ref Field);
                                Battleships.Rotate(ref horizontal, ref vertical);
                                DrawShip(horizontal, vertical, fieldArray, ref Field);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (place == true)
                    {
                        Down.Play();
                        Battleships.SetShip(ref fieldArray, x, y, true, horizontal, vertical);
                        Draw(fieldArray, ref Field);

                        if (Battleships.NextShip(ref horizontal, ref vertical, ref shipAmmount) != true)
                        {
                            Clear(ref Field);
                            Battleships.ShootingMode(ref fieldArray);                           
                            if (Field != Field2)
                            {
                                btnNextTurn.Visible = true;
                                x = 3;
                                y = 4;
                                Field = Field2;
                                fieldArray = fieldArray2;
                                shipAmmount = -1;
                                Battleships.NextShip(ref horizontal, ref vertical, ref shipAmmount);
                                DrawShip(horizontal, vertical, fieldArray, ref Field);
                            }
                            else
                            {
                                game = true;
                                Clear(ref Field);
                                Battleships.ShootingMode(ref fieldArray);
                                NextTurn(ref turn);
                            }
                        }
                        else
                        {
                            if (x > 7)
                            {
                                x = 7;
                            }
                            DrawShip(horizontal, vertical, fieldArray, ref Field);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (sender == Field1[i, j] && turn == true)
                        {
                            Shoot(i, j, 1);
                        }
                        if (sender == Field2[i, j] && turn == false)
                        {
                            Shoot(i, j, 2);
                        }
                    }
                }
            }
        }

        private void btnNextTurn_Click(object sender, EventArgs e)
        {
            btnNextTurn.Visible = false;
        }
    }
}
