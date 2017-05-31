using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMenu
{
    class Pc:Game
    {
        public int Hod(int[] PcArray, int min, int max, int CardsLeft)
        {
            int minimum = 0;
            int co = 0;
            int c = 0;
            int x = 0;
            int ko = 0;
            Random hod = new Random();
            PcArray = TrimZero(PcArray);
            int[] B = new int[PcArray.Length];
            int[] K = new int[PcArray.Length];
            if (CardsLeft > 0)
            {
                for (int i = 0; i < PcArray.Length; i++)
                {
                    for (int j = min; j <= max; j++)
                    {
                        if (PcArray[i] != j)
                        {
                            c++;
                        }
                    }
                    if (c == 9)
                    {
                        B[co] = PcArray[i];
                        co++;
                    }
                    c = 0;
                }
                if (co != 0)
                {
                    B = TrimZero(B);
                    x = hod.Next(0, B.Length);
                    return B[x];
                }
                else
                {
                    if (co == 0)
                    {
                        for (int i = 0; i < PcArray.Length; i++)
                        {
                            for (int j = min; j <= max; j++)
                            {
                                if (PcArray[i] == j)
                                {
                                    K[ko] = PcArray[i];
                                    ko++;
                                }
                            }
                        }
                        K = TrimZero(K);
                        minimum = K[0];
                        for (int i = 1; i < K.Length; i++)
                        {
                            if (K[i] < minimum)
                            {
                                minimum = K[i];
                            }
                        }
                        return minimum;
                    }
                }
            }

            if (CardsLeft == 0)
            {
                x = hod.Next(0, PcArray.Length);
                return PcArray[x];
            }
            return 0;







        }

        public int PodKid(int POne, int[] PlTwo)
        {

            int counter = 0;
            int c = 0;
            int[] WhatToPodkid = new int[3];
            int ind = 0;

            if (POne >= 6 && POne <= 14)
            {
                for (int i = 0; i < PlTwo.Length; i++)
                {
                    if (PlTwo[i] - 20 == POne || PlTwo[i] - 40 == POne || PlTwo[i] - 60 == POne)
                    {
                        WhatToPodkid[ind] = PlTwo[i];
                        ind++;
                        counter++;
                    }
                }
            }
            if (POne >= 26 && POne <= 34)
            {
                for (int i = 0; i < PlTwo.Length; i++)
                {
                    if (PlTwo[i] + 20 == POne || PlTwo[i] - 20 == POne || PlTwo[i] - 40 == POne)
                    {
                        WhatToPodkid[ind] = PlTwo[i];
                        ind++;
                        counter++;
                    }
                }
            }
            if (POne >= 46 && POne <= 54)
            {
                for (int i = 0; i < PlTwo.Length; i++)
                {
                    if (PlTwo[i] + 40 == POne || PlTwo[i] + 20 == POne || PlTwo[i] - 20 == POne)
                    {
                        WhatToPodkid[ind] = PlTwo[i];
                        ind++;
                        counter++;
                    }
                }
            }
            if (POne >= 66 && POne <= 74)
            {
                for (int i = 0; i < PlTwo.Length; i++)
                {
                    if (PlTwo[i] + 20 == POne || PlTwo[i] + 40 == POne || PlTwo[i] + 60 == POne)
                    {
                        WhatToPodkid[ind] = PlTwo[i];
                        ind++;
                        counter++;
                    }
                }
            }
            if (counter > 0)
            {
                WhatToPodkid = TrimZero(WhatToPodkid);
                Random d = new Random();
                c = d.Next(0, WhatToPodkid.Length);
                return WhatToPodkid[c];
            }
            else
            {
                return 0;
            }

        }
    }
}
