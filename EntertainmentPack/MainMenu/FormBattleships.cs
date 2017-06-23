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
    public partial class FormBattleships : ParentForm
    {
        public FormBattleships()
        {
            InitializeComponent();
        }
        SoundPlayer Down = new SoundPlayer(Properties.Resources.TetrisDown);
        SoundPlayer Kill = new SoundPlayer(Properties.Resources.BattleshipsDeath);
        SoundPlayer Hit = new SoundPlayer(Properties.Resources.BattleshipsHit);
        SoundPlayer Miss = new SoundPlayer(Properties.Resources.BattleshipsMiss);
        SoundPlayer Rotate = new SoundPlayer(Properties.Resources.TetrisRotate);
        SoundPlayer Win = new SoundPlayer(Properties.Resources.Win);
        Panel[,] Field1 = new Panel[10, 10];
        Panel[,] Field2 = new Panel[10, 10];
        Random r = new Random();
        int[,] fieldArray1 = new int[12, 12];
        int[,] fieldArray2 = new int[12, 12];
        int[,] shoots1 = new int[2, 24], shoots2 = new int[2, 26];
        int[,] shoots3 = new int[2, 50];
        int x = 3;
        int y = 4;
        int horizontal = 0;
        int vertical = 0;
        int shipAmmount = -1;
        bool place;
        bool game = false;
        bool turn = true;
        int score1 = 0;
        int score2 = 0;

        private void FormBattleships_Load(object sender, EventArgs e)
        {
            brokenChalk = new Font(fonts.Families[0], 18.0F);
            label1.Font = brokenChalk;
            CreatePanel(18, Field1);
            CreatePanel(592, Field2);
            NewGame();
            Battleships.SetPCShips(ref fieldArray2);
            Battleships.CreateShootArrays(ref shoots1, ref shoots2, ref shoots3);
            /*string s="";
            for(int i =0;i<50;i++)
            {
                for(int j=0;j<2;j++)
                {
                    s += Convert.ToString(shoots3[j, i]);
                    s += " ";
                }
                s += "\r\n";
            }
            MessageBox.Show(s);*/
        }

        private void NewGame()
        {
            Battleships.NextShip(ref horizontal, ref vertical, ref shipAmmount);
            Draw(fieldArray1, ref Field1);
            DrawShip(horizontal, vertical, fieldArray1, ref Field1, x, y);
        }

        private void Restart()
        {

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
                        case 1:
                            if (panel[i, j].BackgroundImage != Properties.Resources.Miss)
                                panel[i, j].BackgroundImage = Properties.Resources.Miss; break;
                        case 2:
                            if (panel[i, j].BackgroundImage != Properties.Resources.Alive)
                                panel[i, j].BackgroundImage = Properties.Resources.Alive; break;
                        case 3:
                            if (panel[i, j].BackgroundImage != Properties.Resources.Damaged)
                                panel[i, j].BackgroundImage = Properties.Resources.Damaged; break;
                        case 4:
                            if (panel[i, j].BackgroundImage != Properties.Resources.Dead)
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

        private void DrawShip(int horizontal, int vertical, int[,] array, ref Panel[,] panel, int x, int y)
        {
            for (int i = x; i < x + horizontal; i++)
            {
                for (int j = y; j < y + vertical; j++)
                {
                    if (Battleships.CheckPlace(x, y, horizontal, vertical, fieldArray1, ref place) == true)
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

        }

        private void Shoot(int i, int j, ref int[,] fieldArray, ref Panel[,] Field)
        {
            switch (fieldArray[i + 1, j + 1])
            {
                case (int)Battleships.State.Alive:
                    {
                        if (Battleships.CheckShipState(i, j, fieldArray) == true)
                        {
                            Hit.Play();
                            fieldArray[i + 1, j + 1] = (int)Battleships.State.Damaged;
                        }
                        else
                        {
                            Kill.Play();
                            Battleships.KillShip(i, j, fieldArray);
                            if (fieldArray == fieldArray1)
                            {
                                AddScore(true);
                            }
                            else
                            {
                                AddScore(false);
                            }
                        }
                    }
                    break;
                case (int)Battleships.State.Empty:
                    {
                        Miss.Play();
                        fieldArray[i + 1, j + 1] = (int)Battleships.State.Miss;
                        turn = !turn;
                    }
                    break;
            }
            Draw(fieldArray1, ref Field1);
            DrawGame(fieldArray2, ref Field2);
            if (turn == false)
            {
                timer1.Enabled = true;
            }
        }

        private void NextTurn(ref bool turn)
        {
            MessageBox.Show("next turn");
            turn = !turn;
            Draw(fieldArray1, ref Field1);
            Draw(fieldArray2, ref Field2);
        }

        private void AddScore(bool player)
        {

            if (player == true)
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
            if(game ==false)
            { 
            Clear(ref Field1);
            Draw(fieldArray1, ref Field1);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (Field1[i, j] == sender)
                        {
                            if (i + horizontal > 9)
                            {
                                x = 10 - horizontal;
                            }
                            else
                            {
                                x = i;
                            }
                            if (j + vertical > 9)
                            {
                                y = 10 - vertical;
                            }
                            else
                            {
                                y = j;
                            }
                            DrawShip(horizontal, vertical, fieldArray1, ref Field1, x, y);
                        }
                    }
                }
            }
        }

        private void Panel_Click(object sender, MouseEventArgs me)
        {
            if (game == false)
            {
                if (me.Button == MouseButtons.Left)
                {
                    if (Battleships.CheckPlace(x,y,horizontal,vertical,fieldArray1,ref place)==true)
                    {
                        Down.Play();
                        Battleships.SetShip(ref fieldArray1, x, y, true, horizontal, vertical);
                        Draw(fieldArray1, ref Field1);
                        if (Battleships.NextShip(ref horizontal, ref vertical, ref shipAmmount) == false)
                        {
                            Battleships.ShootingMode(ref fieldArray1);
                            Battleships.ShootingMode(ref fieldArray2);
                            DrawGame(fieldArray2, ref Field2);
                            Draw(fieldArray1, ref Field1);
                            game = true;
                        }
                    }
                }
                else
                {
                    Clear(ref Field1);
                    Draw(fieldArray1, ref Field1);
                    Battleships.Rotate(ref horizontal, ref vertical);
                    if(x+horizontal>9)
                    {
                        x = 6;
                    }
                    if (y + vertical > 9)
                    {
                        y = 6;
                    }
                    DrawShip(horizontal, vertical, fieldArray1,ref Field1, x, y);
                }
            }
            else
            {if (turn == true)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (Field2[i, j] == sender)
                            {
                                Shoot(i, j, ref fieldArray2, ref Field2);
                            }
                        }
                    }
                }
            }
        }

        private void PCShoot(ref int[,] fieldArray, ref int[,] shoots1, ref int[,] shoots2, ref int[,] shoots3)
        {
            int x, y;
            int [,] count;
            int lines;
            int rand;
            Battleships.Direction direction1 = new Battleships.Direction();
            Battleships.Direction direction2 = new Battleships.Direction();
            if (Battleships.SearchDamaged(fieldArray1, out count) == true)
            {
                lines = Battleships.CountArrayLines(count);
               if (lines>1)
                {
                    rand = r.Next(lines);
                    Battleships.FindDamagedDirection(count[0,rand], count[1, rand], fieldArray1, ref direction1, ref direction2);
                    while (ShootRandomDirection(count[0, rand], count[1, rand], direction1, direction2) == false)
                    {
                        rand = r.Next(lines);
                    };

                }
                else
                {
                    while (ShootRandomDirection(count[0, 0], count[1, 0], Battleships.Direction.Null, Battleships.Direction.Null) == false);
                }
            }
            else
            {
                if (Battleships.CountArrayLines(shoots1) == 0)
                {
                    if (Battleships.CountArrayLines(shoots2) == 0)
                    {
                        if (Battleships.CountArrayLines(shoots3) == 0)
                        {

                        }
                        else
                        {
                            Battleships.ChooseRandomCoordinates(ref shoots3, out x, out y);
                            while (fieldArray1[x + 1, y + 1] != (int)Battleships.State.Alive && fieldArray1[x + 1, y + 1] != (int)Battleships.State.Empty)
                            {
                                if (Battleships.CountArrayLines(shoots3) == 0)
                                {
                                    break;
                                }
                                Battleships.ChooseRandomCoordinates(ref shoots3, out x, out y);
                            }
                            Shoot(x, y, ref fieldArray1, ref Field1);
                        }
                    }
                    else
                    {
                        Battleships.ChooseRandomCoordinates(ref shoots2, out x, out y);
                        while (fieldArray1[x + 1, y + 1] != (int)Battleships.State.Alive && fieldArray1[x + 1, y + 1] != (int)Battleships.State.Empty)
                        {
                            if (Battleships.CountArrayLines(shoots2) == 0)
                            {
                                break;
                            }
                            Battleships.ChooseRandomCoordinates(ref shoots2, out x, out y);
                        }
                        Shoot(x, y, ref fieldArray1, ref Field1);
                    }
                }
                else
                {
                    Battleships.ChooseRandomCoordinates(ref shoots1, out x, out y);
                    while (fieldArray1[x + 1, y + 1] != (int)Battleships.State.Alive && fieldArray1[x + 1, y + 1] != (int)Battleships.State.Empty)
                    {
                        if (Battleships.CountArrayLines(shoots1) == 0)
                        {
                            break;
                        }
                        Battleships.ChooseRandomCoordinates(ref shoots1, out x, out y);
                    }
                    Shoot(x, y, ref fieldArray1, ref Field1);
                }
            }
        }
        

        private bool ShootRandomDirection(int x, int y, Battleships.Direction direction1, Battleships.Direction direction2)
        {
            if (direction1 == Battleships.Direction.Null)
            {
                switch (r.Next(4))
                {
                    case (int)Battleships.Direction.Left:
                        if(ShootDirection(x, y, Battleships.Direction.Left)==true)
                            return true;
                        else
                            return false;
                    case (int)Battleships.Direction.Up:
                        if (ShootDirection(x, y, Battleships.Direction.Up) == true)
                            return true;
                        else
                            return false;
                    case (int)Battleships.Direction.Right:
                        if (ShootDirection(x, y, Battleships.Direction.Right) == true)
                            return true;
                        else
                            return false;
                    case (int)Battleships.Direction.Down:
                        if (ShootDirection(x, y, Battleships.Direction.Down) == true)
                            return true;
                        else
                            return false;
                    default: return false;
                }
            }
            else
            {
                if (r.Next(2) == 0)
                {
                    if (ShootDirection(x, y, direction1) == true)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (ShootDirection(x, y, direction2) == true)
                        return true;
                    else
                        return false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            PCShoot(ref fieldArray1, ref shoots1, ref shoots2, ref shoots3);         
        }

        private bool ShootDirection(int x, int y, Battleships.Direction direction)
        {
            switch (direction)
            {
                case Battleships.Direction.Left:
                    if (fieldArray1[x, y + 1] == (int)Battleships.State.Empty || fieldArray1[x, y + 1] == (int)Battleships.State.Alive)
                    {
                        if (x > 0)
                        {
                            Shoot(x - 1, y, ref fieldArray1, ref Field1);
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                case Battleships.Direction.Up:
                    if (fieldArray1[x + 1, y] == (int)Battleships.State.Empty || fieldArray1[x + 1, y] == (int)Battleships.State.Alive)
                    {
                        if (y > 0)
                        {
                            Shoot(x, y - 1, ref fieldArray1, ref Field1);
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                case Battleships.Direction.Right:
                    if (fieldArray1[x + 2, y + 1] == (int)Battleships.State.Empty || fieldArray1[x + 2, y + 1] == (int)Battleships.State.Alive)
                    {
                        if (x < 10)
                        {
                            Shoot(x + 1, y, ref fieldArray1, ref Field1);
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                case Battleships.Direction.Down:
                    if (fieldArray1[x + 1, y + 2] == (int)Battleships.State.Empty || fieldArray1[x + 1, y + 2] == (int)Battleships.State.Alive)
                    {
                        if (y < 10)
                        {
                            Shoot(x, y + 1, ref fieldArray1, ref Field1);
                            return true;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                default: return false;
            }
        }

    }
}
