using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    static class Life
    {
        static public int[,] Array(int x, int y)
        {
            int[,] a = new int[x, y];
            return a;
        }

        static public string Draw(int[,] array, int x)
        {
            string s = "";
            int n = 0;
            foreach (int i in array)
            {
                if (i == 1)
                {
                    s += "*";
                }
                else
                {
                    s += " ";
                }
                n++;
                if (n == x)
                {
                    s += "\r\n";
                    n = 0;
                }
            }
            return s;
        }
        static public string Draw2(int[,] array, int x)
        {
            string s = "";
            int n = 0;
            foreach (int i in array)
            {
                s += i;
                n++;
                if (n == x)
                {
                    s += "\r\n";
                    n = 0;
                }
            }
            return s;
        }

        static public void Game(ref int[,] array, out int[,] n, int x, int y, bool mode)
        {
            int[,] b = new int[x, y];
            int[,] a;
            if (mode == true)
            {
                a = array;
            }
            else
            {
                a = new int[x, y];
            }
            for (int i = 1; i < x - 1; i++)
            {
                for (int j = 1; j < y - 1; j++)
                {
                    if (array[i, j] == 1)
                    {
                        b[i, j] = Neighbours(array, true, i, j);
                        if (b[i, j] < 2)
                            a[i, j] = 0;
                        if (b[i, j] > 3)
                            a[i, j] = 0;
                        if (b[i, j] == 2 || b[i, j] == 3)
                            a[i, j] = 1;
                    }
                    else
                    {
                        b[i, j] = Neighbours(array, false, i, j);
                        if (b[i, j] == 3)
                            a[i, j] = 1;
                        else
                            a[i, j] = 0;
                    }
                }
            }
            array = a;
            n = b;
        }

        static public int Neighbours(int[,] array, bool alive, int x, int y)
        {
            int n = 0;
            if (alive == true)
            {
                n--;
            }
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (array[i, j] == 1)
                    {
                        n++;
                    }
                }
            }
            return n;
        }

        static public void Random(ref int[,] array, int x, int y, int percentage)
        {
            Random r = new Random();
            for (int i = 1; i < x - 1; i++)
            {
                for (int j = 1; j < y - 1; j++)
                {
                    if (r.Next(1, 100) <= percentage)
                    {
                        array[i, j] = 1;
                    }
                }
            }
        }

        static public void Gun(ref int[,] array, int x, int y, int percentage)
        {
            //mini exploder
            array[8, 110] = 1;
            array[9, 109] = 1;
            array[9, 110] = 1;
            array[9, 111] = 1;
            array[10, 109] = 1;
            array[10, 111] = 1;
            array[11, 110] = 1;

            //exploder
            array[40, 110] = 1;
            array[41, 110] = 1;
            array[42, 110] = 1;
            array[43, 110] = 1;
            array[44, 110] = 1;
            array[40, 114] = 1;
            array[41, 114] = 1;
            array[42, 114] = 1;
            array[43, 114] = 1;
            array[44, 114] = 1;
            array[40, 112] = 1;
            array[44, 112] = 1;

            //row
            array[40, 170] = 1;
            array[40, 171] = 1;
            array[40, 172] = 1;
            array[40, 173] = 1;
            array[40, 174] = 1;
            array[40, 175] = 1;
            array[40, 176] = 1;
            array[40, 177] = 1;
            array[40, 178] = 1;
            array[40, 179] = 1;

            //tumbler
            array[8, 170] = 1;
            array[8, 171] = 1;
            array[9, 170] = 1;
            array[9, 171] = 1;
            array[8, 173] = 1;
            array[8, 174] = 1;
            array[9, 173] = 1;
            array[9, 174] = 1;
            array[10, 171] = 1;
            array[11, 171] = 1;
            array[12, 171] = 1;
            array[10, 173] = 1;
            array[11, 173] = 1;
            array[12, 173] = 1;
            array[11, 169] = 1;
            array[12, 169] = 1;
            array[13, 169] = 1;
            array[11, 175] = 1;
            array[12, 175] = 1;
            array[13, 175] = 1;
            array[13, 170] = 1;
            array[13, 174] = 1;

            //gun
            array[4 + 2, 2] = 1;
            array[4 + 2, 2 + 1] = 1;
            array[4 + 3, 2] = 1;
            array[4 + 3, 2 + 1] = 1;

            array[4 + 2, 2 + 9] = 1;
            array[4 + 2, 2 + 10] = 1;
            array[4 + 3, 2 + 8] = 1;
            array[4 + 3, 2 + 10] = 1;
            array[4 + 4, 2 + 8] = 1;
            array[4 + 4, 2 + 9] = 1;

            array[4 + 4, 2 + 16] = 1;
            array[4 + 4, 2 + 17] = 1;
            array[4 + 5, 2 + 16] = 1;
            array[4 + 5, 2 + 18] = 1;
            array[4 + 6, 2 + 16] = 1;

            array[4 + 2, 2 + 22] = 1;
            array[4 + 2, 2 + 23] = 1;
            array[4 + 1, 2 + 22] = 1;
            array[4 + 1, 2 + 24] = 1;
            array[4, 2 + 23] = 1;
            array[4, 2 + 24] = 1;

            array[4, 2 + 34] = 1;
            array[4, 2 + 35] = 1;
            array[4 + 1, 2 + 34] = 1;
            array[4 + 1, 2 + 35] = 1;

            array[4 + 7, 2 + 35] = 1;
            array[4 + 7, 2 + 36] = 1;
            array[4 + 8, 2 + 35] = 1;
            array[4 + 8, 2 + 37] = 1;
            array[4 + 9, 2 + 35] = 1;

            array[4 + 12, 2 + 24] = 1;
            array[4 + 12, 2 + 25] = 1;
            array[4 + 12, 2 + 26] = 1;
            array[4 + 13, 2 + 24] = 1;
            array[4 + 14, 2 + 25] = 1;
        }
    }
}