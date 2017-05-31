using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    class Cards
    {
        public int[] Hearts = new int[9];

        public int[] Clubs = new int[9];

        public int[] Diamonds = new int[9];

        public int[] Spades = new int[9];

        public int[] RandomM = new int[36];

        public void HFillit(int[] Masth)
        {
            Masth[0] = 6;
            Masth[1] = 7;
            Masth[2] = 8;
            Masth[3] = 9;
            Masth[4] = 10;
            Masth[5] = 11;
            Masth[6] = 12;
            Masth[7] = 13;
            Masth[8] = 14;
        }

        public void DFillit(int[] Mastd)
        {
            Mastd[0] = 26;
            Mastd[1] = 27;
            Mastd[2] = 28;
            Mastd[3] = 29;
            Mastd[4] = 30;
            Mastd[5] = 31;
            Mastd[6] = 32;
            Mastd[7] = 33;
            Mastd[8] = 34;
        }

        public void SFillit(int[] Masth)
        {
            Masth[0] = 46;
            Masth[1] = 47;
            Masth[2] = 48;
            Masth[3] = 49;
            Masth[4] = 50;
            Masth[5] = 51;
            Masth[6] = 52;
            Masth[7] = 53;
            Masth[8] = 54;
        }

        public void CFillit(int[] Mastd)
        {
            Mastd[0] = 66;
            Mastd[1] = 67;
            Mastd[2] = 68;
            Mastd[3] = 69;
            Mastd[4] = 70;
            Mastd[5] = 71;
            Mastd[6] = 72;
            Mastd[7] = 73;
            Mastd[8] = 74;
        }

        public void RandomFill(int[] R)
        {
            int i = 0; ;
            while (i < 9)
            {
                R[i] = 5;
                i++;
            }
            while (i < 18)
            {
                R[i] = 1;
                i++;
            }
            while (i < 27)
            {
                R[i] = 2;
                i++;
            }
            while (i < 36)
            {
                R[i] = 3;
                i++;
            }
        }

        public int[] Nozero(int[] Array)
        {
            int j = 0;
            int[] NewArray = new int[Array.Length - 1];
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] != 0)
                {
                    NewArray[j] = Array[i];
                    j++;
                }
            }
            return NewArray;
        }

        public int GetNum(ref int[] RandomM, int max)
        {
            int need = 0;
            Random Mast = new Random();
            System.Threading.Thread.Sleep(10);
            int m = Mast.Next(0, max);
            for (int i = 0; i < RandomM.Length; i++)
            {
                if (m == i)
                {
                    need = RandomM[i];
                    RandomM[i] = 0;
                }
            }
            return need;
        }

        public string WriteArray(int[] Array)
        {
            string write = "";
            for (int i = 0; i < Array.Length; i++)
            {
                write += Array[i];
                write += "\r\n";
            }
            return write;

        }


        public void ZeroAll(int[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = 0;

            }
        }

    }
}
