using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    class Tetris
    {
        public enum Direction { Up, Down, Left, Right, Rotate }

        public enum Figure { Square = 1, Stick, T, Z, S, L, Г }

        static public bool Place(int[,] figure, ref int[,] moving, int[,] array, ref int x, ref int y, ref int[,] coordinates)
        {
            int m = 0;
            int n = 0;
            if (CountLines(figure, Direction.Left) == 0 && x < figure.GetLength(0) / 2)
            {
                x = 0;
            }
            if (CountLines(figure, Direction.Right) == 0 && x > 10 - figure.GetLength(0))
            {
                x = 10 - figure.GetLength(0);
            }
            if (CountLines(figure, Direction.Down) == 0 && y > 20 - figure.GetLength(0))
            {
                y = 20 - figure.GetLength(0);
            }
            for (int j = 0; j < figure.GetLength(1) - CountLines(figure, Direction.Up); j++)
            {
                for (int i = 0; i < figure.GetLength(0); i++)
                {
                    if (figure[i, j + CountLines(figure, Direction.Up)] != 0)
                    {
                        coordinates[m, n] = i + x;
                        m++;
                        coordinates[m, n] = j + y;
                        m = 0;
                        n++;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (array[coordinates[0, i], coordinates[1, i]] != 0)
                {
                    return false;
                }
            }
            for (int j = 0; j < figure.GetLength(1) - CountLines(figure, Direction.Up); j++)
            {
                for (int i = 0; i < figure.GetLength(0); i++)
                {
                    if (figure[i, j + CountLines(figure, Direction.Up)] != 0)
                    {
                        moving[i + x, j + y] = figure[i, j + CountLines(figure, Direction.Up)];
                    }
                }
            }
            return true;
        }

        static public int CountLines(int[,] array, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        for (int i = 0; i < array.GetLength(0); i++)
                        {
                            if (array[i, j] != 0)
                            {
                                return j;
                            }
                        }
                    }
                    return 0;

                case Direction.Left:
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            if (array[i, j] != 0)
                            {
                                return i;
                            }
                        }
                    }
                    return 0;

                case Direction.Right:
                    for (int i = array.GetLength(0) - 1; i >= 0; i--)
                    {
                        for (int j = array.GetLength(1) - 1; j >= 0; j--)
                        {
                            if (array[i, j] != 0)
                            {
                                return array.GetLength(0) - 1 - i;
                            }
                        }
                    }
                    return 0;

                case Direction.Down:
                    for (int j = array.GetLength(1) - 1; j >= 0; j--)
                    {
                        for (int i = array.GetLength(0) - 1; i >= 0; i--)
                        {
                            if (array[i, j] != 1)
                            {
                                return array.GetLength(0) - 1 - j;
                            }
                        }
                    }
                    return 0;

                default: return 0;
            }
        }

        static public void NullArray(ref int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = 0;
                }
            }
        }

        static public void Rotate(ref int[,] array)
        {
            int[,] temp = new int[array.GetLength(0), array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    temp[array.GetLength(1) - 1 - j, i] = array[i, j];
                }
            }
            array = temp;
        }

        static public void SetNewFigure(ref int[,] array, Figure figure)
        {

            switch (figure)
            {
                case Figure.Square:
                    array = new int[2, 2];
                    array[0, 0] = Convert.ToInt32(figure);
                    array[0, 1] = Convert.ToInt32(figure);
                    array[1, 1] = Convert.ToInt32(figure);
                    array[1, 0] = Convert.ToInt32(figure);

                    break;

                case Figure.Stick:
                    array = new int[4, 4];
                    array[0, 1] = Convert.ToInt32(figure);
                    array[1, 1] = Convert.ToInt32(figure);
                    array[2, 1] = Convert.ToInt32(figure);
                    array[3, 1] = Convert.ToInt32(figure);

                    break;

                case Figure.T:
                    array = new int[3, 3];
                    array[1, 0] = Convert.ToInt32(figure);
                    array[0, 1] = Convert.ToInt32(figure);
                    array[1, 1] = Convert.ToInt32(figure);
                    array[2, 1] = Convert.ToInt32(figure);

                    break;

                case Figure.Z:
                    array = new int[3, 3];
                    array[0, 0] = Convert.ToInt32(figure);
                    array[1, 0] = Convert.ToInt32(figure);
                    array[1, 1] = Convert.ToInt32(figure);
                    array[2, 1] = Convert.ToInt32(figure);

                    break;

                case Figure.S:
                    array = new int[3, 3];
                    array[2, 0] = Convert.ToInt32(figure);
                    array[1, 0] = Convert.ToInt32(figure);
                    array[1, 1] = Convert.ToInt32(figure);
                    array[0, 1] = Convert.ToInt32(figure);

                    break;

                case Figure.L:
                    array = new int[3, 3];
                    array[2, 0] = Convert.ToInt32(figure);
                    array[0, 1] = Convert.ToInt32(figure);
                    array[1, 1] = Convert.ToInt32(figure);
                    array[2, 1] = Convert.ToInt32(figure);

                    break;

                case Figure.Г:
                    array = new int[3, 3];
                    array[0, 0] = Convert.ToInt32(figure);
                    array[0, 1] = Convert.ToInt32(figure);
                    array[1, 1] = Convert.ToInt32(figure);
                    array[2, 1] = Convert.ToInt32(figure);

                    break;

                default: break;
            }
        }

        static public int FullLine(ref int[,] array)
        {
            int count = 0;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    if (array[i, j] != 0)
                    {

                        if (i == array.GetLength(0) - 1)
                        {
                            count++;
                            for (int j2 = j; j2 >= 0; j2--)
                            {
                                for (int i2 = 0; i2 < array.GetLength(0); i2++)
                                {
                                    if (j2 > 0)
                                    {
                                        array[i2, j2] = array[i2, j2 - 1];
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return count;
        }

        static public void NextLevel(ref int level, out int time, out int upScore)
        {

            level += 1;
            double time2 = 1000;
            for (int i = 0; i < level; i++)
            {
                time2 *= 0.75;
            }
            time = Convert.ToInt32(time2);
            upScore = 0;
            for (int i = 1; i <= level; i++)
            {
                upScore += i * 500;
            }
        }
    }
}
