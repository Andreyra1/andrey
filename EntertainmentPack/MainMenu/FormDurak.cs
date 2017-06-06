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
    public partial class FormDurak : Form
    {
        public FormDurak()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        Font brokenChalk;
        byte[] fontData = Properties.Resources.BrokenChalk;
        SoundPlayer Shuffle = new SoundPlayer(Properties.Resources.DurakShuffle);
        SoundPlayer GiveCr = new SoundPlayer(Properties.Resources.DurakGive);
        SoundPlayer Hodi = new SoundPlayer(Properties.Resources.DurakMove);
        SoundPlayer HeTakes = new SoundPlayer(Properties.Resources.DurakITake);
        SoundPlayer HeTakesMore = new SoundPlayer(Properties.Resources.DurakUh);
        SoundPlayer Bitos = new SoundPlayer(Properties.Resources.DurakBito);
        SoundPlayer TakeCardss = new SoundPlayer(Properties.Resources.DurakTake);
        SoundPlayer Turn = new SoundPlayer(Properties.Resources.DurakYourTurn);
        SoundPlayer Win = new SoundPlayer(Properties.Resources.Win);
        SoundPlayer Lose = new SoundPlayer(Properties.Resources.Lose);
        SoundPlayer Draw = new SoundPlayer(Properties.Resources.Draw);
        public int[] All = new int[36];
        public int[] PlayerOne = new int[36];
        public int[] PlayerTwo = new int[36];
        public int[] TakeCards = new int[12];
        int qKoz;
        int minkoz = 0;
        int maxkoz = 0;   
        int TablePos = 0;
        int Koza = 0;
        int counter = 0;
        int ClickPos = 0;       
        int index = 0;
        int pindex = 0;
        int distance = 90;
        int posofcomp = 150;
        bool MyMoveHod ;
        int Mywin = 0;
        int PcWin = 0;
        bool x = false;
        bool y = false;
        Size size = new Size(80, 120);
        PictureBox[] picturebox = new PictureBox[36];
        PictureBox[] Comp = new PictureBox[36];
        int CardsLeft = 0;
        int MaximumTable = 12;

        public void PcTakes()
        {
            Game g = new Game();
            Cards c = new Cards();
            g.TakeComp(PlayerTwo, TakeCards);
            index = g.CountCards(PlayerTwo);
            DrawTake(index);
            DrawPc(posofcomp);
            HeTakes.Play();
            TablePos = 0;
            counter = 0;
            Clear();
            CheckWin();
            Give(PlayerOne, PlayerTwo, All, MyMoveHod);
        }

        public void Give(int[] PlayerO, int[] PlayerT, int[] All, bool whofirst)
        {
            Game g = new Game();
            int cardsofone = g.CountCards(PlayerO);
            int cardsoftwo = g.CountCards(PlayerT);
            int index = 0;
            if (cardsofone < 6 && cardsoftwo < 6)
            {
                if (cardsofone < cardsoftwo)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (PlayerO[i] == 0)
                        {
                            PlayerO[i] = All[index];
                            All[index] = 0;
                            index++;
                            cardsofone++;
                            if (cardsofone == cardsoftwo)
                            {
                                break;
                            }
                        }
                    }
                    g.AllCardsGone(All);
                }
                if (cardsoftwo < cardsofone)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (PlayerT[i] == 0)
                        {
                            PlayerT[i] = All[index];
                            All[index] = 0;
                            index++;
                            cardsoftwo++;
                            if (cardsoftwo == cardsofone)
                            {
                                break;
                            }
                        }
                    }
                    g.AllCardsGone(All);
                }
                index = 0;
                if (cardsoftwo == cardsofone)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (PlayerO[i] == 0)
                        {
                            PlayerO[i] = All[index];
                            All[index] = 0;
                            index++;
                        }
                        if (PlayerT[i] == 0)
                        {
                            PlayerT[i] = All[index];
                            All[index] = 0;
                            index++;
                        }
                    }
                    g.AllCardsGone(All);
                }
            }
            else
            {
                if (cardsoftwo < 6 && cardsofone >= 6)
                {
                    for (int i = 0; i < 6; i++)
                    {

                        if (PlayerT[i] == 0)
                        {
                            PlayerT[i] = All[index];
                            All[index] = 0;
                            index++;
                        }
                    }
                    g.AllCardsGone(All);
                }
            }
            if (cardsofone < 6 && cardsoftwo >= 6)
            {
                int allcards = g.CountCards(All);
                for (int i = 0; i < 6; i++)
                {
                    if (PlayerO[i] == 0)
                    {
                        PlayerO[i] = All[index];
                        All[index] = 0;
                        index++;
                    }

                }
                g.AllCardsGone(All);
            }

            if (All[0] == 0)
            {
                if (g.CountCards(PlayerTwo) < 6 || g.CountCards(PlayerOne) < 6)
                {
                    switch (MyMoveHod)
                    {
                        case true: MaximumTable = g.CountCards(PlayerTwo); break;
                        case false: MaximumTable = g.CountCards(PlayerOne); break;
                        default:
                            break;
                    }
                }
                else
                {
                    MaximumTable = 12;
                }

                KOZR.BringToFront();
                switch (minkoz)
                {
                    case 6: KOZR.Image = imageList2.Images[75]; break;
                    case 26: KOZR.Image = imageList2.Images[76]; break;
                    case 46: KOZR.Image = imageList2.Images[77]; break;
                    case 66: KOZR.Image = imageList2.Images[78]; break;
                    default:
                        break;
                }
                pictureBox13.Visible = false;
            }

            g.CountCards(PlayerTwo);
            DrawPc(posofcomp);          
            label2.Text = g.CardsLeft(All).ToString();
            g.CountCards(PlayerOne);
            DrawPlayer(posofcomp);         
            label2.Text = g.CardsLeft(All).ToString();
        }
        public void Clear()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
            pictureBox10.Image = null;
            pictureBox11.Image = null;
            pictureBox12.Image = null;
        }

        public void DrawPlayer(int pos)
        {
            Game g = new Game();
            index =
            g.CountCards(PlayerOne);

            for (int i = 0; i < index + 1; i++)
            {
                Controls.Remove(picturebox[i]);
                picturebox[i] = null;
            }
            for (int i = 0; i < index; i++)
            {
                if (PlayerOne[i] != 0)
                {
                    pos += distance;
                    PictureBox picture = new PictureBox();
                    picturebox[i] = picture;
                    picturebox[i].Image = imageList1.Images[PlayerOne[i]];
                    picturebox[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    picturebox[i].Size = size;                  
                    if (MyMoveHod == true)
                    {
                        picturebox[i].Click += new EventHandler(button3_Click_1);
                    }
                    else
                    {
                        picturebox[i].Click += new EventHandler(button6_Click_1);
                    }
                    picture.Location = new Point(pos, 540);
                }
            }
            Controls.AddRange(picturebox);
        }

        public void DrawPcCardsWhilePodkiding()
        {
            switch (counter)
            {
                case 0:
                   
                    pictureBox3.BringToFront();
                    pictureBox3.Image = imageList1.Images[TakeCards[TablePos + 2]]; break;

                case 1:
                   
                    pictureBox5.BringToFront();
                    pictureBox5.Image = imageList1.Images[TakeCards[TablePos + 2]]; break;

                case 2:
                    pictureBox7.BringToFront();
                    pictureBox7.Image = imageList1.Images[TakeCards[TablePos + 2]]; break;

                case 3:
                    
                    pictureBox9.BringToFront();
                    pictureBox9.Image = imageList1.Images[TakeCards[TablePos + 2]]; break;

                case 4:
                    
                    pictureBox11.BringToFront();
                    pictureBox11.Image = imageList1.Images[TakeCards[TablePos + 2]]; break;

                case 5:
                     pictureBox13.BringToFront();
                    pictureBox13.Image = imageList1.Images[TakeCards[TablePos + 2]]; break;
                default:
                    break;
            }
        }

        public void Start()
        {
            CardsLeft = 0;
            Random rand = new Random();
            Cards c = new Cards();
            string s = "";
            c.HFillit(c.Hearts);
            c.DFillit(c.Diamonds);
            c.SFillit(c.Spades);
            c.CFillit(c.Clubs);
            c.RandomFill(c.RandomM);
            int maxh = 9;
            int maxd = 9;
            int maxs = 9;
            int maxc = 9;
            string write = "";
            int what = 37;
            MaximumTable = 12;
            label5.Visible = false;
            label4.Visible = false;
            c.ZeroAll(PlayerOne);
            c.ZeroAll(PlayerTwo);
            c.ZeroAll(All);
            Clear();
            counter = 0;
            button5.Visible = true;
            pictureBox13.BringToFront();
            for (int i = 0; i < picturebox.Length; i++)
            {
                Controls.Remove(picturebox[i]);
                picturebox[i] = null;
            }
            for (int i = 0; i < Comp.Length; i++)
            {
                Controls.Remove(Comp[i]);
                Comp[i] = null;
            }
            Shuffle.Play();
            for (int all = 0; all < All.Length; all++)
            {
                what--;
                int masta = c.GetNum(ref c.RandomM, what);
                write += masta;
                write += "\r\n";
                c.RandomM = c.Nozero(c.RandomM);
                if (masta == 5)
                {
                    int r = rand.Next(0, maxh);

                    for (int j = 0; j < c.Hearts.Length; j++)
                    {
                        if (r == j)
                        {
                            All[all] = c.Hearts[j];
                            c.Hearts[j] = 0;
                            c.Hearts = c.Nozero(c.Hearts);
                            maxh--;
                            s += All[all];
                            s += "\r\n";
                        }
                    }
                }
                if (masta == 1)
                {
                    int r = rand.Next(0, maxd);
                    for (int j = 0; j < c.Diamonds.Length; j++)
                    {
                        if (r == j)
                        {
                            All[all] = c.Diamonds[j];
                            c.Diamonds[j] = 0;
                            c.Diamonds = c.Nozero(c.Diamonds);
                            maxd--;
                            s += All[all];
                            s += "\r\n";
                        }
                    }
                }
                if (masta == 2)
                {
                    int r = rand.Next(0, maxs);

                    for (int j = 0; j < c.Spades.Length; j++)
                    {
                        if (r == j)
                        {
                            All[all] = c.Spades[j];
                            c.Spades[j] = 0;
                            c.Spades = c.Nozero(c.Spades);
                            maxs--;
                            s += All[all];
                            s += "\r\n";
                        }
                    }
                }
                if (masta == 3)
                {
                    int r = rand.Next(0, maxc);

                    for (int j = 0; j < c.Clubs.Length; j++)
                    {
                        if (r == j)
                        {
                            All[all] = c.Clubs[j];
                            c.Clubs[j] = 0;
                            c.Clubs = c.Nozero(c.Clubs);
                            maxc--;
                            s += All[all];
                            s += "\r\n";
                        }
                    }
                }
            }         
            for (int i = 0; i < 6; i++)
            {
                Controls.Remove(picturebox[i]);
            }

            int jaw = 0;
            int saw = 0;
            for (int i = 0; i < 12; i++)
            {
                if (i % 2 == 0)
                {
                    PlayerOne[jaw] = All[i];
                    jaw++;
                    All[i] = 0;
                }
                else
                {
                    if (i % 2 != 0)
                    {
                        PlayerTwo[saw] = All[i];
                        saw++;
                        All[i] = 0;
                    }
                }
            }
            for (int i
            = 0; i < All.Length; i++)
            {
                if (All[i] != 0)
                {
                    CardsLeft++;
                }
            }
            Random Kozir = new Random();
            Koza = Kozir.Next(12, 35);
            qKoz = All[Koza];
            All[Koza] = 0;
            Game g = new Game();
            All = g.AllCardsGone(All);
            All[23] = qKoz;          
            if (qKoz >= 6 && qKoz <= 14)
            {
                minkoz = 6;
                maxkoz = 14;
            }

            if (qKoz >= 26 && qKoz <= 34)
            {
                minkoz = 26;
                maxkoz = 34;
            }
            if (qKoz >= 46 && qKoz <= 54)
            {
                minkoz = 46;
                maxkoz = 54;
            }
            if (qKoz >= 66 && qKoz <= 74)
            {
                minkoz = 66;
                maxkoz = 74;
            }
            KOZR.Image = imageList1.Images[qKoz];
            pictureBox13.Visible = true;
            GiveCr.Play();
            int Who = g.WhoMakes(PlayerOne, minkoz, maxkoz);
            int WhoP = g.WhoMakes(PlayerTwo, minkoz, maxkoz);
            if (Who != 0 && WhoP != 0 && Who < WhoP)
            {
                Turn.Play();
                   MyMoveHod = true;
                button4.Visible = false;
                label4.Visible = true;
            }
            if (Who != 0 && WhoP != 0 && Who > WhoP)
            {
                MyMoveHod = false;
                PcMoves();
                button4.Visible = true;
                label5.Visible = true;
            }
            if (Who == 0 && WhoP != 0)
            {
                MyMoveHod = false;
                PcMoves();
                button4.Visible = true;
                label5.Visible = true;
            }
            if (WhoP == 0 && Who != 0)
            {
                Turn.Play();
                MyMoveHod = true;
                button4.Visible = false;
                label4.Visible = true;
            }
            index = g.CountCards(PlayerOne);
            index = g.CountCards(PlayerTwo);
            int posofcomp = 150;
            int pos = 150;
            DrawPlayer(pos);
            DrawPc(posofcomp);       
            label1.Visible = true;
            label3.Visible = true;
            label1.Text = Mywin.ToString();
            label3.Text = PcWin.ToString();
            label2.Text = CardsLeft.ToString();
        }

        public void DrawPc(int pos)
        {
            Game g = new Game();
            pindex = g.CountCards(PlayerTwo);
            for (int i = 0; i < pindex + 1; i++)
            {
                Controls.Remove(Comp[i]);
                Comp[i] = null;
            }
            for (int i = 0; i < pindex; i++)
            {
                if (PlayerTwo[i] != 0)
                {
                    pos += distance;
                    PictureBox picture = new PictureBox();
                    Comp[i] = picture;
                    Comp[i].Image = imageList1.Images[75];
                    Comp[i].SizeMode = PictureBoxSizeMode.StretchImage;
                    Comp[i].Size = size;
                    picture.Location = new Point(pos, 50);
                }
            }
            Controls.AddRange(Comp);
        }

        public void CheckWin()
        {
            Game g = new Game();
            if (All[0] == 0)
            {
                if (g.CountCards(PlayerOne) == 0 && g.CountCards(PlayerTwo) != 0)
                {
                    Win.Play();
                    MessageBox.Show("You WON !");
                    Mywin++;
                    Clear();
                    DialogResult d = MessageBox.Show("Wanna Start New Game ?", "New Game ?", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        Start();
                    }
                }
                else
                {
                    if (g.CountCards(PlayerTwo) == 0 && g.CountCards(PlayerOne) != 0)
                    {
                        Lose.Play();
                        MessageBox.Show("Pc WON !");
                        PcWin++;
                        Clear();
                        DialogResult d = MessageBox.Show("Wanna Start New Game ?", "New Game ?", MessageBoxButtons.YesNo);
                        if (d == DialogResult.Yes)
                        {
                            Start();
                        }
                    }
                }
                if (g.CountCards(PlayerTwo) == 0 && g.CountCards(PlayerOne) == 0)
                {
                    Draw.Play();
                    MessageBox.Show("DRAW");
                    PcWin++;
                    Mywin++;
                    Clear();
                    DialogResult d = MessageBox.Show("Wanna Start New Game ?", "New Game ?", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        Start();
                    }
                }
            }
            label1.Text = Mywin.ToString();
            label3.Text = PcWin.ToString();
        }

        public void PlayerAddsWhenPcTook()
        {
            Cards c = new Cards();
            Game g = new Game();
            int Cark = ClickPos;
            TakeCards[TablePos] = PlayerOne[Cark];    
            PlayerOne[Cark] = 0;
            PlayerOne = g.Take(PlayerOne);
           
            if (counter == 0)
            {
                pictureBox1.BringToFront();
                pictureBox1.Image = imageList1.Images[TakeCards[TablePos]];

                
            }
            if (counter == 1)
            {
                pictureBox3.BringToFront();
                pictureBox3.Image = imageList1.Images[TakeCards[TablePos]];

                
            }
            if (counter == 2)
            {
                pictureBox5.BringToFront();
                pictureBox5.Image = imageList1.Images[TakeCards[TablePos]];

              
                
            }
            if (counter == 3)
            {
                pictureBox7.BringToFront();
                pictureBox7.Image = imageList1.Images[TakeCards[TablePos]];

                
            }
            if (counter == 4)
            {
                pictureBox9.BringToFront();
                pictureBox9.Image = imageList1.Images[TakeCards[TablePos]];

                
            }
            if (counter == 5)
            {
                pictureBox11.BringToFront();
                pictureBox11.Image = imageList1.Images[TakeCards[TablePos]];

                
            }
            g.CountCards(PlayerOne);
            DrawPlayer(posofcomp);
            Hodi.Play();
            x = true;
            TablePos += 1;
            counter++;
        }

        public void PlayerMoves()
        {
            Cards c = new Cards();
            Game g = new Game();
            if (MyMoveHod == true)
            {
                button5.Enabled = true;
                if (TablePos < MaximumTable)
                {
                    int Cark = 0;
                    Cark = ClickPos;
                    TakeCards[TablePos] = PlayerOne[Cark];
                  
                    if (PlayerOne[Cark] >= 6 && PlayerOne[Cark] <= 14)
                    {
                        TakeCards[TablePos + 1] = g.PcMove(6, 15, TakeCards, TablePos, PlayerTwo, minkoz, maxkoz, CardsLeft);
                    }
                    if (PlayerOne[Cark] >= 26 && PlayerOne[Cark] <= 34)
                    {
                        TakeCards[TablePos + 1] = g.PcMove(26, 35, TakeCards, TablePos, PlayerTwo, minkoz, maxkoz, CardsLeft);
                    }
                    if (PlayerOne[Cark] >= 46 && PlayerOne[Cark] <= 54)
                    {
                        TakeCards[TablePos + 1] = g.PcMove(46, 55, TakeCards, TablePos, PlayerTwo, minkoz, maxkoz, CardsLeft);
                    }
                    if (PlayerOne[Cark] >= 66 && PlayerOne[Cark] <= 74)
                    {
                        TakeCards[TablePos + 1] = g.PcMove(66, 75, TakeCards, TablePos, PlayerTwo, minkoz, maxkoz, CardsLeft);
                    }
                    if (PlayerOne[Cark] >= minkoz && PlayerOne[Cark] <= maxkoz)
                    {
                        TakeCards[TablePos + 1] = g.PcKozMove(minkoz, maxkoz, TakeCards, TablePos, PlayerTwo);
                    }
                    PlayerOne[Cark] = 0;
                    PlayerOne = g.Take(PlayerOne);
                   
                    switch (counter)
                    {
                        case 0:
                            pictureBox1.BringToFront();
                            pictureBox1.Image = imageList1.Images[TakeCards[TablePos]]; break;
                        case 1:
                            pictureBox3.BringToFront();
                            pictureBox3.Image = imageList1.Images[TakeCards[TablePos]];
                            break;
                        case 2:
                            pictureBox5.BringToFront();
                            pictureBox5.Image = imageList1.Images[TakeCards[TablePos]];
                             break;
                        case 3:
                            pictureBox7.BringToFront();
                            pictureBox7.Image = imageList1.Images[TakeCards[TablePos]];
                            break;
                        case 4:
                            pictureBox9.BringToFront();
                            pictureBox9.Image = imageList1.Images[TakeCards[TablePos]];
                             break;

                        case 5:
                            pictureBox11.BringToFront();
                            pictureBox11.Image = imageList1.Images[TakeCards[TablePos]];
                             break;
                        default:
                            break;
                    }
                    g.CountCards(PlayerOne);
                    DrawPlayer(posofcomp);                  
                    Hodi.Play();
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (PlayerTwo[j] == TakeCards[i])
                            {
                                PlayerTwo[j] = 0;
                            }
                        }
                    }
                    if (TakeCards[TablePos + 1] == 0)
                    {
                        DialogResult result = MessageBox.Show("I Am Taking, Want To Give something Else ?", "Taking", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            HeTakesMore.Play();
                              x = true;
                            TablePos += 1;
                            counter++;
                            button1.Visible = true;
                        }
                        else
                        {
                            PcTakes();
                        }
                    }
                    else
                    {
                        PlayerTwo = g.Take(PlayerTwo);
                        if (counter == 0)
                        {
                            pictureBox2.BringToFront();
                            pictureBox2.Image = imageList1.Images[TakeCards[TablePos + 1]];
                           
                        }
                        if (counter == 1)
                        {
                            pictureBox4.BringToFront();
                            pictureBox4.Image = imageList1.Images[TakeCards[TablePos + 1]];
                          
                        }
                        if (counter == 2)
                        {
                            pictureBox6.BringToFront();
                            pictureBox6.Image = imageList1.Images[TakeCards[TablePos + 1]];
                            
                        }
                        if (counter == 3)
                        {
                            pictureBox8.BringToFront();
                            pictureBox8.Image = imageList1.Images[TakeCards[TablePos + 1]];
                           
                        }
                        if (counter == 4)
                        {
                            pictureBox10.BringToFront();
                            pictureBox10.Image = imageList1.Images[TakeCards[TablePos + 1]];
                            
                        }
                        if (counter == 5)
                        {
                            pictureBox12.BringToFront();
                            pictureBox12.Image = imageList1.Images[TakeCards[TablePos + 1]];
                           
                        }
                        g.CountCards(PlayerTwo);
                        DrawPc(posofcomp);
                        Hodi.Play();
                        TablePos += 2;
                        counter++;
                        CheckWin();
                        x = false;
                    }
                }
                else
                {
                    MessageBox.Show("Table is Full");
                }
            }
        }

        public void DrawTake(int cards)
        {
            Game g = new Game();
            int index = 0;
            index = cards;
            switch (index)
            {
                case 1:
                case 2:
                    posofcomp = 150 + 180;
                    distance = 80; break;

                case 4:
                case 3:             
                    posofcomp = 150+90;
                    distance = 80; break;

                case 8:
                case 7:
                case 6:
                case 5:
                    posofcomp = 150;
                    distance = 80; break;

                case 9:
                case 10:
                case 11:
                    posofcomp = 90;
                    distance = 80; break;
                case 12:
                case 13:
                case 14:
                    posofcomp = 60;
                    distance = 80; break;
                case 15:
                case 16:
                case 17:
                    posofcomp = 30;
                    distance = 80; break;
                case 18:
                case 19:
                case 20:
                    posofcomp = 20;
                    distance = 75; break;
                case 21:
                case 22:
                case 23:
                    posofcomp = 10;
                    distance = 80; break;
                case 24:
                case 25:
                case 26:
                    posofcomp = 5;
                    distance = 80; break;
                case 27:
                case 28:
                case 29:
                    posofcomp = 3;
                    distance = 80; break;
                case 30:
                case 31:
                case 32:
                    posofcomp = 2;
                    distance = 80; break;
                case 33:
                case 34:
                case 35:
                    posofcomp = 1;
                    distance = 60; break;

                case 36:
                    posofcomp = 0;
                    distance = 50; break;
                default:
                   break;
            }
        }

        public void Bito()
        {
            MyMoveHod = !MyMoveHod;
            button6.Enabled = true;
            Cards c = new Cards();
            Game g = new Game();
            for (int i = 0; i < TakeCards.Length; i++)
            {
                TakeCards[i] = 0;
            }
            Clear();
            Bitos.Play();
            TablePos = 0;
            counter = 0;
            Give(PlayerOne, PlayerTwo, All, MyMoveHod);
            CheckWin();     
            if (MyMoveHod == false)
            {
                PcMoves();
            }
            else
            {
                Turn.Play();
                button4.Visible = false;
                label4.Visible = true;
                label5.Visible = false;
            }
        }

        public void PcMoves()
        {
            if (MyMoveHod == false)
            {
                button5.Enabled = false;
                label4.Visible = false;
                label5.Visible = true;
                button4.Visible = true;
                Pc p = new Pc();
                TakeCards[TablePos] = p.Hod(PlayerTwo, minkoz, maxkoz, CardsLeft);
                int ComputerCards = 0;
                ComputerCards = p.HowManyToTake(PlayerTwo);
                for (int i = 0; i < PlayerTwo.Length; i++)
                {
                    if (PlayerTwo[i] == TakeCards[TablePos])
                    {
                        PlayerTwo[i] = 0;
                    }
                }
                PlayerTwo = p.Take(PlayerTwo);
                int posofcomp = 150;
                DrawPc(posofcomp);
                Hodi.Play();
                pictureBox1.BringToFront();
                pictureBox1.Image = imageList1.Images[TakeCards[TablePos]];
            }
        }

        public void PlayerBeats()
        {
            Pc p = new Pc();
            if (MyMoveHod == false)
            {
                int pod = 0;
                int Cark = 0;
                Cark = ClickPos;
                TakeCards[TablePos + 1] = PlayerOne[Cark];             
                PlayerOne[Cark] = 0;
                PlayerOne = p.Take(PlayerOne);             
                switch (counter)
                {
                    case 0:
                       
                        pictureBox2.BringToFront();
                        pictureBox2.Image = imageList1.Images[TakeCards[TablePos + 1]];
                        break;
                    case 1:
                      
                        pictureBox4.BringToFront();
                        pictureBox4.Image = imageList1.Images[TakeCards[TablePos + 1]];
                        break;
                    case 2:
                       
                        pictureBox6.BringToFront();
                        pictureBox6.Image = imageList1.Images[TakeCards[TablePos + 1]];
                        break;
                    case 3:
                       
                        pictureBox8.BringToFront();
                        pictureBox8.Image = imageList1.Images[TakeCards[TablePos + 1]];
                        break;
                    case 4:
                        
                        pictureBox10.BringToFront();
                        pictureBox10.Image = imageList1.Images[TakeCards[TablePos + 1]]; break;
                    case 5:
                       
                        pictureBox12.BringToFront();
                        pictureBox12.Image = imageList1.Images[TakeCards[TablePos + 1]]; break;
                    default:
                        break;
                }

                p.CountCards(PlayerOne);
                DrawPlayer(posofcomp);
                Hodi.Play();
                if (TablePos + 2 < MaximumTable - 1)
                {
                    TakeCards[TablePos + 2] = p.PodKid(TakeCards[pod], PlayerTwo);
                    while (TakeCards[TablePos + 2] == 0)
                    {
                        pod++;
                        if (pod > 11)
                        {
                            MessageBox.Show("Bito");
                            Bito();
                            break;
                        }
                    }
                    if (TakeCards[TablePos + 2] != 0)
                    {
                        if (TakeCards[TablePos +
                        2] >= minkoz && TakeCards[TablePos + 2] <= maxkoz)
                        {
                            if (CardsLeft > 0)
                            {
                                Random door = new Random();
                                int d = door.Next(0, 10);
                                if (d > 7)
                                {
                                    DrawPcCardsWhilePodkiding();
                                    p.CountCards(PlayerTwo);
                                    DrawPc(posofcomp);
                                    Hodi.Play();
                                    TablePos += 2;
                                    counter++;
                                    for (int i = 0; i < 12; i++)
                                    {
                                        for (int j = 0; j < 12; j++)
                                        {
                                            if (PlayerTwo[j] == TakeCards[i])
                                            {
                                                PlayerTwo[j] = 0;
                                            }
                                        }
                                    }
                                    PlayerTwo = p.Take(PlayerTwo);
                                }
                                else
                                {
                                    TakeCards[TablePos + 2] = 0;
                                    TablePos += 2;
                                    counter++;
                                    MessageBox.Show("Bito");
                                    Bito();
                                }
                            }
                            else
                            {
                                if (CardsLeft == 0)
                                {
                                    DrawPcCardsWhilePodkiding();
                                    p.CountCards(PlayerTwo);
                                    DrawPc(posofcomp);
                                    Hodi.Play();
                                    for (int i = 0; i < 12; i++)
                                    {
                                        for (int j = 0; j < 12; j++)
                                        {
                                            if (PlayerTwo[j] == TakeCards[i])
                                            {
                                                PlayerTwo[j] = 0;
                                            }
                                        }
                                    }
                                    PlayerTwo = p.Take(PlayerTwo);
                                    TablePos += 2;
                                    counter++;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                for (int j = 0; j < 12; j++)
                                {
                                    if (PlayerTwo[j] == TakeCards[i])
                                    {
                                        PlayerTwo[j] = 0;
                                    }
                                }
                            }
                            PlayerTwo = p.Take(PlayerTwo);
                            DrawPcCardsWhilePodkiding();
                            p.CountCards(PlayerTwo);
                            DrawPc(posofcomp);
                            Hodi.Play();
                            TablePos += 2;
                            counter++;
                        }
                    }              
                }
                else
                {
                    button6.Enabled = false;
                    MessageBox.Show("Bito");
                    Bito();
                }
            }
        }

        public void PcAddsWhenPlayerTook()
        {
            int pod = 0;
            if (TablePos + 1 < MaximumTable + 1)
            {
                Pc p = new Pc();
                TakeCards[TablePos + 1] = p.PodKid(TakeCards[pod], PlayerTwo);
                while (TakeCards[TablePos + 1] == 0)
                {
                    pod++;
                    if (pod > 11)
                    {
                        y = true;
                        break;
                    }
                }
                if (TakeCards[TablePos + 1] != 0)
                {

                    if (TakeCards[TablePos + 1] >= minkoz && TakeCards[TablePos + 1] <= maxkoz)
                    {
                        MessageBox.Show("I have more");
                        MessageBox.Show(TakeCards[TablePos + 1].ToString(), minkoz.ToString());
                        if (CardsLeft > 0)
                        {
                            Random door = new Random();
                            int d = door.Next(0, 10);
                            if (d > 80)
                            {
                                DrawPcCardsWhilePodkiding();
                                for (int i = 0; i < 12; i++)
                                {
                                    for (int j = 0; j < 12; j++)
                                    {
                                        if (PlayerTwo[j] == TakeCards[i])
                                        {
                                            PlayerTwo[j] = 0;
                                        }
                                    }
                                }
                                PlayerTwo = p.Take(PlayerTwo);
                                p.CountCards(PlayerTwo);
                                DrawPc(posofcomp);
                                Hodi.Play();
                                TablePos += 1;
                                counter++;
                            }
                            else
                            {
                                TakeCards[TablePos + 1] = 0;
                                MessageBox.Show(" i dont give kozirs");
                                TablePos += 1;
                                counter++;
                                y = true;
                            }
                        }
                        else
                        {
                            if (CardsLeft == 0)
                            {
                                DrawPcCardsWhilePodkiding();
                                for (int i = 0; i < 12; i++)
                                {
                                    for (int j = 0; j < 12; j++)
                                    {
                                        if (PlayerTwo[j] == TakeCards[i])
                                        {
                                            PlayerTwo[j] = 0;
                                        }
                                    }
                                }
                                PlayerTwo = p.Take(PlayerTwo);
                                p.CountCards(PlayerTwo);
                                DrawPc(posofcomp);
                                Hodi.Play();
                                TablePos += 1;
                                counter++;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("I have more");
                        for (int i = 0; i < 12; i++)
                        {
                            for (int j = 0; j < 12; j++)
                            {
                                if (PlayerTwo[j] == TakeCards[i])
                                {
                                    PlayerTwo[j] = 0;
                                }
                            }
                        }
                        PlayerTwo = p.Take(PlayerTwo);
                        DrawPcCardsWhilePodkiding();
                        p.CountCards(PlayerTwo);
                        DrawPc(posofcomp);
                        Hodi.Play();
                        TablePos += 1;
                        counter++;
                    }
                }           
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Game g = new Game();
            Cards c = new Cards();
            if (counter == 0)
            {
                for (int i = 0; i < PlayerOne.Length; i++)
                {
                    if (sender == picturebox[i])
                    {
                        ClickPos = i;
                        PlayerMoves();
                    }
                }
            }
            if (counter > 0 && x == false)
                for (int i = 0; i < PlayerOne.Length; i++)
                {
                    if (sender == picturebox[i])
                    {
                        if (g.No(PlayerOne[i], TakeCards) == 0)
                        {
                            MessageBox.Show("Please Choose Another Card");
                        }
                        else
                        {
                            ClickPos = i;
                            PlayerMoves();
                        }
                    }
                }
            if (counter > 0 && x == true)
                for (int i = 0; i < PlayerOne.Length; i++)
                {
                    if (sender == picturebox[i])
                    {
                        if (g.No(PlayerOne[i], TakeCards) == 0)
                        {
                            MessageBox.Show("He Takes But Please Choose Another Card");
                        }
                        else
                        {
                            ClickPos = i;
                            PlayerAddsWhenPcTook();
                        }
                    }
                }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            while (y == false)
            {
                PcAddsWhenPlayerTook();
            }
            TablePos = 0;
            Game g = new Game();
            int j = 0;
            Cards c = new Cards();
            for (int i = 0; i < PlayerOne.Length; i++)
            {
                if (PlayerOne[i] == 0)
                {
                    if (TakeCards[j] != 0)
                    {
                        PlayerOne[i] = TakeCards[j];
                        TakeCards[j] = 0;
                        j++;
                    }
                }
            }
            index = g.CountCards(PlayerOne);
            DrawTake(index);
            DrawPlayer(posofcomp);
            TakeCardss.Play();
            Give(PlayerOne, PlayerTwo, All, MyMoveHod);
            Clear();
            counter = 0;
            MyMoveHod = false;
            PcMoves();
            y = false;
            CheckWin();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Bito();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Pc p = new Pc();
            for (int i = 0; i < PlayerOne.Length; i++)
            {
                if (sender == picturebox[i])
                {
                    if (p.NoBeat(PlayerOne[i], TakeCards[TablePos], minkoz, maxkoz) == 0)
                    {
                        MessageBox.Show("Please,Choose Another Card");
                    }
                    else
                    {
                        ClickPos = i;
                        PlayerBeats();
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PcTakes();
            button1.Visible = false;
        }
    
        private void FormDurak_Load(object sender, EventArgs e)
        {
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.BrokenChalk.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.BrokenChalk.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            brokenChalk = new Font(fonts.Families[0], 20.25F);
            label1.Font = brokenChalk;
            label3.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 24.00F);
            label2.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 21.75F);
            label4.Font = brokenChalk;
            label5.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 21.75F);
            label6.Font = brokenChalk;
            label7.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 11.25F);
            button1.Font = brokenChalk;
            button4.Font = brokenChalk;
            button7.Font = brokenChalk;
            brokenChalk = new Font(fonts.Families[0], 14.25F);
            button5.Font = brokenChalk;
            Start();
        }

        private void FormDurak_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    {
                        FormPause Pause = new FormPause(this);
                        Pause.ShowDialog();
                    }
                    break;
            }
        }

        private void FormDurak_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
