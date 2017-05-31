using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    class TicTac
    {
        public static bool CheckWin(int[,] a, out string winner)
        {
            int j = 0;

            for (int i = 0; i <= 2; i++)//check rows
            {
                if (a[i, j] == a[i, j + 1] && a[i, j + 1] == a[i, j + 2] && (a[i, j + 2] == 1 || a[i, j + 2] == 2))
                {
                    if (a[i, j + 2] == 1)
                        winner = "X";
                    else
                        winner = "O";
                    return true;
                }
            }

            for (int i = 0; i <= 2; i++)//check columns
            {
                if (a[j, i] == a[j + 1, i] && a[j + 1, i] == a[j + 2, i] && (a[j + 2, i] == 1 || a[j + 2, i] == 2))
                {
                    if (a[j + 2, i] == 1)
                        winner = "X";
                    else
                        winner = "O";
                    return true;

                }
            }

            if (a[j, j] == a[j + 1, j + 1] && a[j + 1, j + 1] == a[j + 2, j + 2] && (a[j + 2, j + 2] == 1 || a[j + 2, j + 2] == 2))//check diagonal
            {
                if (a[j + 2, j + 2] == 1)
                    winner = "X";
                else
                    winner = "O";
                return true;
            }

            if (a[j + 2, j] == a[j + 1, j + 1] && a[j + 1, j + 1] == a[j, j + 2] && (a[j, j + 2] == 1 || a[j, j + 2] == 2)) //check diagonal
            {
                if (a[j, j + 2] == 1)
                    winner = "X";
                else
                    winner = "O";
                return true;
            }
            winner = "";
            return false;
        }

        public static bool CheckAlmost(int[,] a, out int x, out int y)
        {
            int j = 0;
            for (int n = 2; n >= 1; n--)//check rows
            {
                for (int i = 0; i <= 2; i++)
                {
                    if ((a[i, j] == a[i, j + 1] && a[i, j + 1] == n) || (a[i, j] == a[i, j + 2] && a[i, j + 2] == n) || (a[i, j + 1] == a[i, j + 2] && a[i, j + 2] == n))
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            if (a[i, b] == 0)
                            {
                                x = i;
                                y = b;
                                return true;
                            }
                        }
                    }
                }
            }

            for (int n = 2; n >= 1; n--)//check columns
            {
                for (int i = 0; i <= 2; i++)
                {
                    if ((a[j, i] == a[j + 1, i] && a[j + 1, i] == n) || (a[j, i] == a[j + 2, i] && a[j + 2, i] == n) || (a[j + 1, i] == a[j + 2, i] && a[j + 2, i] == n))
                    {
                        for (int b = 0; b <= 2; b++)
                        {
                            if (a[b, i] == 0)
                            {
                                x = b;
                                y = i;
                                return true;
                            }
                        }
                    }
                }
            }

            for (int n = 2; n >= 1; n--)//chek diaagonal
            {
                if ((a[j, j] == a[j + 1, j + 1] && a[j + 1, j + 1] == n) || (a[j, j] == a[j + 2, j + 2] && a[j + 2, j + 2] == n) || (a[j + 1, j + 1] == a[j + 2, j + 2] && a[j + 2, j + 2] == n))
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        if (a[i, i] == 0)
                        {
                            x = i;
                            y = i;
                            return true;
                        }
                    }
                }
            }

            for (int n = 2; n >= 1; n--)//chek diaagonal
            {
                if ((a[j, j + 2] == a[j + 1, j + 1] && a[j + 1, j + 1] == n) || (a[j, j + 2] == a[j + 2, j] && a[j + 2, j] == n) || (a[j + 1, j + 1] == a[j + 2, j] && a[j + 2, j] == n))
                {
                    if (a[j, j + 2] == 0)
                    {
                        x = j;
                        y = j + 2;
                        return true;
                    }
                    if (a[j + 1, j + 1] == 0)
                    {
                        x = j + 1;
                        y = j + 1;
                        return true;
                    }
                    if (a[j + 2, j] == 0)
                    {
                        x = j + 2;
                        y = j;
                        return true;
                    }
                }
            }
            x = 3;
            y = 3;
            return false;
        }

        public static void ClearArray(ref int[,] array)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = 0;
                }
            }
        }

        public static void ButtonToArray(int button, out int x, out int y)
        {
            switch (button)
            {
                case 1:
                    x = 0; y = 0; break;
                case 2:
                    x = 1; y = 0; break;
                case 3:
                    x = 2; y = 0; break;
                case 4:
                    x = 0; y = 1; break;
                case 5:
                    x = 1; y = 1; break;
                case 6:
                    x = 2; y = 1; break;
                case 7:
                    x = 0; y = 2; break;
                case 8:
                    x = 1; y = 2; break;
                case 9:
                    x = 2; y = 2; break;
                default:
                    x = 3; y = 3; break;
            }
        }

        public static int SetValue(bool turn)
        {
            if (turn == true)
                return 1;
            else
                return 2;
        }

        public static int[] EmptyCorners(int[,] a)
        {
            int[] b = new int[4];
            int n = 0;
            int c = 1;
            for (int j = 0; j <= 2; j += 2)
            {
                for (int i = 0; i <= 2; i += 2)
                {
                    if (a[i, j] == 0)
                    {
                        b[n] = c;
                        n++;
                    }
                    c++;
                }
            }
            return b;
        }

        public static int[] CrossCorners(int[,] a)
        {
            int[] b = new int[4];
            int n = 0;
            int c = 1;
            for (int j = 0; j <= 2; j += 2)
            {
                for (int i = 0; i <= 2; i += 2)
                {
                    if (a[i, j] == 1)
                    {
                        b[n] = c;
                        n++;
                    }
                    c++;
                }
            }
            return b;
        }

        public static int RandomCorner(int[,] a)
        {
            int[] b = EmptyCorners(a);
            int n = 0;
            Random r = new Random();
            if (b[0] == 0)
                return 0;
            else
            {
                while (n == 0)
                {
                    n = b[r.Next(0, 3)];
                }
                switch (n)
                {
                    case 1: return 1;
                    case 2: return 3;
                    case 3: return 7;
                    case 4: return 9;
                    default: return 0;
                }
            }
        }

        public static int[] EmptySides(int[,] a)
        {
            int[] b = new int[4];
            int n = 0;
            int c = 2;
            if (a[1, 0] == 1)
            {
                b[n] = c;
                n++;
            }
            c += 2;
            if (a[0, 1] == 1)
            {
                b[n] = c;
                n++;
            }
            c += 2;
            if (a[2, 1] == 1)
            {
                b[n] = c;
                n++;
            }
            c += 2;
            if (a[1, 2] == 1)
            {
                b[n] = c;
                n++;
            }
            return b;
        }

        public static bool CheckTrap(int[,] a, int turncount, out int button)
        {
            if (turncount < 4)
            {
                int[] c = CrossCorners(a);
                if (c[0] != 0 && c[1] != 0 && c[2] == 0)
                {
                    int[] b = EmptyCorners(a);
                    if (b[0] != 0 && b[1] != 0 && b[2] == 0)
                    {
                        Random r = new Random();
                        int n = 1;
                        while (n % 2 != 0)
                        {
                            n = r.Next(2, 8);
                        }
                        button = n;
                        return true;
                    }
                }
                int[] d = EmptySides(a);
                if (d[1] != 0)
                {
                    if (d[0] == 2 && d[1] == 4)
                    {
                        button = 1;
                        return true;
                    }
                    if (d[0] == 2 && d[1] == 6)
                    {
                        button = 3;
                        return true;
                    }
                    if (d[0] == 4 && d[1] == 8)
                    {
                        button = 7;
                        return true;
                    }
                    if (d[0] == 6 && d[1] == 8)
                    {
                        button = 9;
                        return true;
                    }
                }
            }
            button = 0;
            return false;
        }
    }
}
