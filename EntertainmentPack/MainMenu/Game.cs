using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    class Game:Cards
    {
        public int[] Take(int[] Array)
        {
            int j = 0;
            int[] NewArray = new int[Array.Length];
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

        public int[] TakeComp(int[] Array, int[] Table)
        {
            int j = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] == 0)
                {
                    if (Table[j] != 0)
                    {
                        Array[i] = Table[j];
                        Table[j] = 0;
                        j++;
                    }
                }
            }
            return Array;
        }

        public int[] AllCardsGone(int[] AllAr)
        {
            int j = 0;
            for (int i = 0; i < AllAr.Length; i++)
            {
                if (AllAr[i] != 0)
                {
                    AllAr[j] = AllAr[i];
                    j++;
                    AllAr[i] = 0;
                }
            }
            return AllAr;
        }

        public int CheckWin(int[] PlayerArray)
        {
            int count = 0;
            for (int i = 0; i < PlayerArray.Length; i++)
            {
                if (PlayerArray[i] != 0)
                {
                    count++;
                }
            }
            return count;
        }

        public int[] GiveCards(int[] Player, int[] All)
        {
            int index = 0;
            for (int i = 0; i < 6; i++)
            {
                if (Player[i] == 0)
                {
                    Player[i] = All[index];
                    All[index] = 0;
                    index++;
                }
            }
            return Player;
        }

        public int Count(int[] Player)
        {
            int counter = 0;
            for (int i = 0; i < 6; i++)
            {
                if (Player[i] == 0)
                {
                    counter++;
                }
            }
            return counter;

        }

        public int CardsLeft(int[] AllCards)
        {
            int CardsLeft = 0;
            for (int i = 0; i < AllCards.Length; i++)
            {
                if (AllCards[i] != 0)
                {
                    CardsLeft++;
                }
            }
            return CardsLeft;

        }

        public int[] TrimZero(int[] Old)
        {
            int x = 0;
            for (int i = 0; i < Old.Length; i++)
            {
                if (Old[i] == 0)
                {
                    x++;
                }
            }

            int[] New = new int[Old.Length - x];

            for (int i = 0; i < Old.Length; i++)
            {
                if (Old[i] != 0)
                {
                    New[i] = Old[i];
                }
            }
            return New;

        }

        public int PcMove(int min, int max, int[] layed, int pos, int[] PcAr, int minko, int maxko, int cardsleft)
        {

            int[] ForBeat = new int[6];
            int easy = 0;
            int m = 0;

            Random r = new Random();
            for (int i = min; i <= max; i++)
            {
                if (layed[pos] == i)
                {
                    for (int j = 0; j < PcAr.Length; j++)
                    {
                        if (PcAr[j] > i && PcAr[j] <= max)
                        {
                            ForBeat[m] = PcAr[j];
                            m++;
                            easy++;
                        }
                    }
                }
            }
            if (easy > 0)
            {
                ForBeat = TrimZero(ForBeat);
                return ForBeat[r.Next(0, ForBeat.Length)];
            }
            else
            {
                return LookForKoz(PcAr, layed, pos, minko, maxko, cardsleft);
            }
        }

        public int LookForKoz(int[] Array, int[] Lay, int pos, int mink, int maxk, int CrdsLe)
        {
            int minimum = 0;
            int x = 0;
            int[] ForBeat = new int[6];
            int amountof = 0;
            int index = 0;
            Random r = new Random();
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = mink; j <= maxk; j++)
                {
                    if (Array[i] == j)
                    {
                        amountof++;
                        ForBeat[index] = Array[i];
                        index++;
                    }
                }
            }
            if (amountof > 0)
            {
                x = r.Next(0, 10);
                int ver = 0;
                if (CrdsLe > 0)
                {
                    ver = 5;
                }
                else
                {
                    ver = 0;
                }
                if (x > ver)
                {

                    return 0;
                }
                else
                {
                    ForBeat = TrimZero(ForBeat);
                    minimum = ForBeat[0];

                    for (int i = 1; i < ForBeat.Length; i++)
                    {
                        if (ForBeat[i] < minimum)
                        {
                            minimum = ForBeat[i];
                        }
                    }

                    return minimum;
                }
            }
            else
            {

                return 0;
            }

        }

        public int PcKozMove(int min, int max, int[] layed, int pos, int[] PcAr)
        {
            int x = 0;
            int[] ForBeat = new int[6];
            int easy = 0;
            int m = 0;
            Random r = new Random();

            for (int i = min; i <= max; i++)
            {
                if (layed[pos] == i)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (PcAr[j] > i && PcAr[j] <= max)
                        {
                            ForBeat[m] = PcAr[j];
                            m++;
                            easy++;
                        }
                    }
                }
            }

            if (easy > 0)
            {
                x = r.Next(0, 10);
                if (x > 3)
                {
                    ForBeat = TrimZero(ForBeat);
                    return ForBeat[r.Next(0, ForBeat.Length)];
                }

                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;

            }
        }

        public int HowManyToTake(int[] Array)
        {
            int c = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] != 0)
                {
                    c++;
                }
            }
            return c;
        }

        public int CountCards(int[] Array)
        {
            int cards = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] != 0)
                {
                    cards++;
                }
            }
            return cards;
        }

        public int No(int Player, int[] Table)
        {

            for (int i = 0; i < Table.Length; i++)
            {
                if (Table[i] >= 6 && Table[i] <= 14)
                {
                    if (Player - 20 == Table[i] || Player - 40 == Table[i] || (Player - 60 == Table[i]))
                    {
                        return Player;
                    }
                }
                if (Table[i] >= 26 && Table[i] <= 34)
                {
                    if (Player + 20 == Table[i] || Player - 20 == Table[i] || Player - 40 == Table[i])
                    {
                        return Player;
                    }
                }
                if (Table[i] >= 46 && Table[i] <= 54)
                {
                    if (Player + 40 == Table[i] || Player + 20 == Table[i] || Player - 20 == Table[i])
                    {
                        return Player;
                    }
                }
                if (Table[i] >= 66 && Table[i] <= 74)
                {
                    if (Player + 20 == Table[i] || Player + 40 == Table[i] || Player + 60 == Table[i])
                    {
                        return Player;
                    }
                }
            }
            return 0;
        }

        public int NoBeat(int Player, int Table, int minnimum, int maximum)
        {


            if (Table >= 6 && Table <= 14)
            {
                if (Player > Table && Player <= 14)
                {
                    return Player;
                }
                else
                {
                    if (Table >= minnimum && Table <= maximum)
                    {
                        if (Player > Table && Player <= maximum)
                        {
                            return Player;
                        }
                    }
                    else
                    {
                        for (int i = minnimum; i <= maximum; i++)
                        {
                            if (Player == i)
                            {
                                return Player;
                            }
                        }
                    }
                }

            }
            if (Table >= 26 && Table <= 34)
            {
                if (Player > Table && Player <= 34)
                {
                    return Player;
                }
                else
                {
                    if (Table >= minnimum && Table <= maximum)
                    {
                        if (Player > Table && Player <= maximum)
                        {
                            return Player;
                        }
                    }
                    else
                    {
                        for (int i = minnimum; i <= maximum; i++)
                        {
                            if (Player == i)
                            {
                                return Player;
                            }
                        }
                    }
                }
            }
            if (Table >= 46 && Table <= 54)
            {
                if (Player > Table && Player <= 54)
                {
                    return Player;
                }
                else
                {
                    if (Table >= minnimum && Table <= maximum)
                    {
                        if (Player > Table && Player <= maximum)
                        {
                            return Player;
                        }
                    }
                    else
                    {
                        for (int i = minnimum; i <= maximum; i++)
                        {
                            if (Player == i)
                            {
                                return Player;
                            }
                        }
                    }
                }
            }
            if (Table >= 66 && Table <= 74)
            {
                if (Player > Table && Player <= 74)
                {
                    return Player;
                }
                else
                {
                    if (Table >= minnimum && Table <= maximum)
                    {
                        if (Player > Table && Player <= maximum)
                        {
                            return Player;
                        }
                    }
                    else
                    {
                        for (int i = minnimum; i <= maximum; i++)
                        {
                            if (Player == i)
                            {
                                return Player;
                            }
                        }
                    }
                }
            }

            return 0;


        }

        public int WhoMakes(int[] PlayerO, int m, int x)
        {
            int c = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = m; j <= x; j++)
                {
                    if (PlayerO[i] == j)
                    {
                        c++;
                    }
                }
            }
            if (c > 0)
            {
                int[] B = new int[c];
                int k = 0;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = m; j <= x; j++)
                    {
                        if (PlayerO[i] == j)
                        {
                            B[k] = PlayerO[i];
                            k++;
                        }
                    }
                }
                int minimun = B[0];
                for (int i = 0; i < B.Length; i++)
                {
                    if (B[i] < minimun)
                    {
                        minimun = B[i];
                    }

                }
                return minimun;
            }
            else
            {
                return 0;
            }

        }
    }
}
