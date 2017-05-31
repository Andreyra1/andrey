using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using WMPLib;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int level = 1;
        int time = 1000;
        int score = 0;
        int upScore = 500;
        int x = 3;
        int y = 0;
        int[,] current = new int[4, 4];
        int[,] next = new int[4, 4];
        int[,] coordinates = new int[2, 4];
        int[,] array = new int[10, 20];
        int[,] moving = new int[10, 20];
        Tetris.Figure figure;
        Tetris.Figure nextFigure;
        Random r = new Random();
        Panel[,] Field = new Panel[10, 20];
        Panel[,] Next = new Panel[4, 4];
        Array figures = Enum.GetValues(typeof(Tetris.Figure));
        bool game = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            Player.URL = "TetrisMainTheme.mp3";
            CreatePanel(10, 20);
            CreatePanel(4, 4);
            timer1.Interval = time;
            labelNext.Text = Convert.ToString(upScore);
            figure = (Tetris.Figure)figures.GetValue(r.Next(figures.Length));
            Tetris.SetNewFigure(ref current, figure);
            Tetris.Place(current, ref moving, array, ref x, ref y, ref coordinates);
            Update(true);
            nextFigure = (Tetris.Figure)figures.GetValue(r.Next(figures.Length));
            Tetris.SetNewFigure(ref next, nextFigure);
            Draw(next, nextFigure);
        }

        private void CreatePanel(int iRow, int iColumn)
        {
            for (int i = 0; i < iRow; i++)
            {
                for (int j = 0; j < iColumn; j++)
                {
                    Panel cell = new Panel();
                    cell.Size = new Size(25, 25);
                    cell.BackColor = System.Drawing.Color.Transparent;
                    cell.BackgroundImageLayout = ImageLayout.Stretch;
                    if (iRow == 10)
                    {
                        cell.Location = new Point(13 + (26 * i), 27 + (26 * j));
                        Field[i, j] = cell;
                    }
                    else
                    {
                        cell.Location = new Point(302 + (26 * i), 27 + (26 * j));
                        Next[i, j] = cell;
                    }
                    this.Controls.Add(cell);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Down();
        }

        private void Draw(int[,] array, Tetris.Figure figure)
        {
            for (int iColumn = 0; iColumn < array.GetLength(0); iColumn++)
            {
                for (int iRow = 0; iRow < array.GetLength(1); iRow++)
                {
                    if (array[iColumn, iRow] == 0)
                    {
                        if (array.GetLength(0) == 10)
                        {
                            Field[iColumn, iRow].BackgroundImage = null;
                        }
                        else
                        {
                            Next[iColumn, iRow].BackgroundImage = null;
                        }
                    }
                    else
                    {
                        switch (array[iColumn, iRow])
                        {
                            case 1:
                                {
                                    if (array.GetLength(0) == 10)
                                    {
                                        Field[iColumn, iRow].BackgroundImage = Properties.Resources.Pink;
                                        break;
                                    }
                                    else
                                    {
                                        Next[iColumn, iRow].BackgroundImage = Properties.Resources.Pink;
                                        break;
                                    }
                                }
                            case 2:
                                {
                                    if (array.GetLength(0) == 10)
                                    {
                                        Field[iColumn, iRow].BackgroundImage = Properties.Resources.Light;
                                        break;
                                    }
                                    else
                                    {
                                        Next[iColumn, iRow].BackgroundImage = Properties.Resources.Light;
                                        break;
                                    }
                                }
                            case 3:
                                {
                                    if (array.GetLength(0) == 10)
                                    {
                                        Field[iColumn, iRow].BackgroundImage = Properties.Resources.Purple;
                                        break;
                                    }
                                    else
                                    {
                                        Next[iColumn, iRow].BackgroundImage = Properties.Resources.Purple;
                                        break;
                                    }
                                }
                            case 4:
                                {
                                    if (array.GetLength(0) == 10)
                                    {
                                        Field[iColumn, iRow].BackgroundImage = Properties.Resources.Red;
                                        break;
                                    }
                                    else
                                    {
                                        Next[iColumn, iRow].BackgroundImage = Properties.Resources.Red;
                                        break;
                                    }
                                }
                            case 5:
                                {
                                    if (array.GetLength(0) == 10)
                                    {
                                        Field[iColumn, iRow].BackgroundImage = Properties.Resources.Green;
                                        break;
                                    }
                                    else
                                    {
                                        Next[iColumn, iRow].BackgroundImage = Properties.Resources.Green;
                                        break;
                                    }
                                }
                            case 6:
                                {
                                    if (array.GetLength(0) == 10)
                                    {
                                        Field[iColumn, iRow].BackgroundImage = Properties.Resources.Orange;
                                        break;
                                    }
                                    else
                                    {
                                        Next[iColumn, iRow].BackgroundImage = Properties.Resources.Orange;
                                        break;
                                    }
                                }
                            case 7:
                                {
                                    if (array.GetLength(0) == 10)
                                    {
                                        Field[iColumn, iRow].BackgroundImage = Properties.Resources.Blue;
                                        break;
                                    }
                                    else
                                    {
                                        Next[iColumn, iRow].BackgroundImage = Properties.Resources.Blue;
                                        break;
                                    }
                                }
                        }
                    }
                }
            }
        }

        private void Clear(Panel[,] panel)
        {
            for (int i = 0; i < panel.GetLength(0); i++)
            {
                for (int j = 0; j < panel.GetLength(1); j++)
                {
                    panel[i, j].BackgroundImage = null;
                }
            }
        }

        public void AddScore(int linesCount)
        {
            switch (linesCount)
            {
                case 1: labelScore.Text = Convert.ToString(score += 100); break;
                case 2: labelScore.Text = Convert.ToString(score += 300); break;
                case 3: labelScore.Text = Convert.ToString(score += 500); break;
                case 4: labelScore.Text = Convert.ToString(score += 700); break;
                default: labelScore.Text = Convert.ToString(score += 4); break;

            }
        }

        public void Down()
        {
            if (coordinates[1, 0] != 19 && coordinates[1, 1] != 19 && coordinates[1, 2] != 19 && coordinates[1, 3] != 19 &&
                array[coordinates[0, 0], coordinates[1, 0] + 1] == 0 && array[coordinates[0, 1], coordinates[1, 1] + 1] == 0 &&
                array[coordinates[0, 2], coordinates[1, 2] + 1] == 0 && array[coordinates[0, 3], coordinates[1, 3] + 1] == 0)
            {
                ChangePosition(Tetris.Direction.Down);
            }
            else
            {
                AddScore(0);
                for (int i = 0; i < 4; i++)
                {
                    moving[coordinates[0, i], coordinates[1, i]] = 0;
                }
                for (int i = 0; i < 4; i++)
                {
                    array[coordinates[0, i], coordinates[1, i]] = Convert.ToInt32(figure);
                }
                x = 3;
                y = 0;
                Tetris.NullArray(ref current);
                Tetris.NullArray(ref coordinates);
                figure = nextFigure;
                Tetris.SetNewFigure(ref current, figure);
                if (Tetris.Place(current, ref moving, array, ref x, ref y, ref coordinates) == true)
                {
                    Clear(Next);
                    nextFigure = (Tetris.Figure)figures.GetValue(r.Next(figures.Length));
                    Tetris.SetNewFigure(ref next, nextFigure);
                    Draw(next, nextFigure);
                    int linesCount = Tetris.FullLine(ref array);
                    if (linesCount > 0)
                    {
                        AddScore(linesCount);
                        Draw(array, figure);
                    }
                    if (score >= upScore)
                    {
                        Tetris.NextLevel(ref level, out time, out upScore);
                        labelNext.Text = Convert.ToString(upScore);
                        timer1.Interval = time;
                    }
                    Update(true);
                }
                else
                {
                    timer1.Enabled = false;
                    game = false;
                    MessageBox.Show("The End!");
                }
            }
        }

        private void ChangePosition(Tetris.Direction direction)
        {
            for (int i = 0; i < 4; i++)
            {
                moving[coordinates[0, i], coordinates[1, i]] = 0;
            }
            Update(false);
            if (direction == Tetris.Direction.Rotate)
            {
                Tetris.Rotate(ref current);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (direction)
                    {
                        case Tetris.Direction.Down: coordinates[1, i] += 1; break;
                        case Tetris.Direction.Left: coordinates[0, i] -= 1; break;
                        case Tetris.Direction.Right: coordinates[0, i] += 1; break;

                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    moving[coordinates[0, i], coordinates[1, i]] = Convert.ToInt32(figure);
                }
                switch (direction)
                {
                    case Tetris.Direction.Down: y++; break;
                    case Tetris.Direction.Left: x--; ; break;
                    case Tetris.Direction.Right: x++; break;

                }

                Update(true);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (game == true)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        if (coordinates[0, 0] != 0 && coordinates[0, 1] != 0 && coordinates[0, 2] != 0 && coordinates[0, 3] != 0 &&
                array[coordinates[0, 0] - 1, coordinates[1, 0]] == 0 && array[coordinates[0, 1] - 1, coordinates[1, 1]] == 0 &&
                array[coordinates[0, 2] - 1, coordinates[1, 2]] == 0 && array[coordinates[0, 3] - 1, coordinates[1, 3]] == 0)
                        {
                            ChangePosition(Tetris.Direction.Left);
                        }
                        break;


                    case Keys.Right:
                        if (coordinates[0, 0] != 9 && coordinates[0, 1] != 9 && coordinates[0, 2] != 9 && coordinates[0, 3] != 9
                    &&
                    array[coordinates[0, 0] + 1, coordinates[1, 0]] == 0 && array[coordinates[0, 1] + 1, coordinates[1, 1]] == 0 &&
                    array[coordinates[0, 2] + 1, coordinates[1, 2]] == 0 && array[coordinates[0, 3] + 1, coordinates[1, 3]] == 0)
                        {
                            ChangePosition(Tetris.Direction.Right);
                        }
                        break;

                    case Keys.Space:
                        while (coordinates[1, 0] != 19 && coordinates[1, 1] != 19 && coordinates[1, 2] != 19 && coordinates[1, 3] != 19 &&
                               array[coordinates[0, 0], coordinates[1, 0] + 1] == 0 && array[coordinates[0, 1], coordinates[1, 1] + 1] == 0 &&
                               array[coordinates[0, 2], coordinates[1, 2] + 1] == 0 && array[coordinates[0, 3], coordinates[1, 3] + 1] == 0)
                        {
                            ChangePosition(Tetris.Direction.Down);
                        }
                        if (coordinates[1, 0] == 19 || coordinates[1, 1] == 19 || coordinates[1, 2] == 19 || coordinates[1, 3] == 19 ||
                            array[coordinates[0, 0], coordinates[1, 0] + 1] != 0 || array[coordinates[0, 1], coordinates[1, 1] + 1] != 0 ||
                            array[coordinates[0, 2], coordinates[1, 2] + 1] != 0 || array[coordinates[0, 3], coordinates[1, 3] + 1] != 0)
                        {
                            Down();
                        }
                        break;

                    case Keys.ShiftKey:
                        ChangePosition(Tetris.Direction.Rotate);
                        if (Tetris.Place(current, ref moving, array, ref x, ref y, ref coordinates) == true)
                        {
                            Update(true);
                        }
                        else
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Tetris.Rotate(ref current);
                            }
                            Tetris.Place(current, ref moving, array, ref x, ref y, ref coordinates);
                            Update(true);
                        }
                        break;

                    case Keys.Down:
                        {
                            Down();
                        }
                        break;
                }
            }
        }
        private void Update (bool x)
        {
            if (array.GetLength(0) == 10)
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (figure)
                    {
                        case Tetris.Figure.Square:
                            {
                                if (x == true)
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = Properties.Resources.Pink;
                                else
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = null;
                                break;
                            }
                        case Tetris.Figure.Stick:
                            {
                                if (x == true)
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = Properties.Resources.Light;
                                else
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = null;
                                break;
                            }
                        case Tetris.Figure.T:
                            {
                                if (x == true)
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = Properties.Resources.Purple;
                                else
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = null;
                                break;
                            }
                        case Tetris.Figure.Z:
                            {
                                if (x == true)
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = Properties.Resources.Red;
                                else
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = null;
                                break;
                            }
                        case Tetris.Figure.S:
                            {
                                if (x == true)
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = Properties.Resources.Green;
                                else
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = null;
                                break;
                            }
                        case Tetris.Figure.L:
                            {
                                if (x == true)
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = Properties.Resources.Orange;
                                else
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = null;
                                break;
                            }
                        case Tetris.Figure.Г:
                            {
                                if (x == true)
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = Properties.Resources.Blue;
                                else
                                    Field[coordinates[0, i], coordinates[1, i]].BackgroundImage = null;
                                break;
                            }
                    }
                } 
            }
        }
    }
} 