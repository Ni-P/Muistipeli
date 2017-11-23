using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Muistipeli
{
    public partial class MainWindow : Form
    {

        List<Card> cards;
        int cardpairs = 12;
        //List<PictureBox>

        Card[] slots;
        Card openCard = null;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Look for images in the res folder
            List<string> images = new List<string>();
            images.Add(@".\res\0.png");
            images.Add(@".\res\4.png");
            images.Add(@".\res\8.png");
            images.Add(@".\res\12.png");
            images.Add(@".\res\16.png");
            images.Add(@".\res\20.png");
            images.Add(@".\res\24.png");
            images.Add(@".\res\28.png");
            images.Add(@".\res\32.png");
            images.Add(@".\res\36.png");
            images.Add(@".\res\40.png");
            images.Add(@".\res\44.png");

            // for each image found make a new Card with imagepath and filename as imagename
            cards = new List<Card>();

            for (int i = 0; i < cardpairs; i++)
            {
                Card card = new Card("card_"+i, images[i]);
                cards.Add(card);
            }
            // Start a new game
            slots = new Card[cardpairs * 2];
            NewGame(cardpairs);
        }

        private void NewGame(int N)
        {
            // pick N amount of cards from List

            // populate N*2 Pictureboxes with cards randomly
            Card[] cardClonesArr = new Card[N];
            cards.CopyTo(cardClonesArr);
            List<Card> cardClones = new List<Card>();
            cardClones = cardClonesArr.ToList();

            Random rng = new Random();

            if (cards.Count < N || cardClones.Count < N)
            {
                throw new Exception("ERROR: not enough cards in lists.");
            }

            for (int i = 0; i < N*2; i += 2)
            {
                int rnd1 = rng.Next(cards.Count);
                int rnd2 = rng.Next(cardClones.Count);

                slots[i] = cards[rnd1];
                slots[i + 1] = cardClones[rnd2];

                cards.RemoveAt(rnd1);
                cardClones.RemoveAt(rnd2);
            }
            // reset counter for tries


            
        }

        private bool OpenCard(int s)
        {
            // try to open the card clicked on, if already open or removed card do nothing
            return true;
            // if another card already open compare them
            // if a pair remove them else close them and increment tries counter
            
            // check if any pairs left in game
        }

        private void Btn_newgame_click(object sender, EventArgs e)
        {
            Console.WriteLine("");
        }

        private void PictureBox1_click(object sender, EventArgs e)
        {
            if (OpenCard(1))
            {
                pictureBox1.ImageLocation = slots[0].ImgPath;
            }
        }

        private void PictureBox2_click(object sender, EventArgs e)
        {
            if (OpenCard(2))
            {
                pictureBox2.ImageLocation = slots[1].ImgPath;
            }
        }

        private void PictureBox3_click(object sender, EventArgs e)
        {
            if (OpenCard(3))
            {
                pictureBox3.ImageLocation = slots[2].ImgPath;
            }
        }

        private void PictureBox4_click(object sender, EventArgs e)
        {
            if (OpenCard(4))
            {
                pictureBox4.ImageLocation = slots[3].ImgPath;
            }
        }

        private void PictureBox5_click(object sender, EventArgs e)
        {
            if (OpenCard(5))
            {
                pictureBox5.ImageLocation = slots[4].ImgPath;
            }
        }

        private void PictureBox6_click(object sender, EventArgs e)
        {
            if (OpenCard(6))
            {
                pictureBox6.ImageLocation = slots[5].ImgPath;
            }
        }

        private void PictureBox7_click(object sender, EventArgs e)
        {
            if (OpenCard(7))
            {
                pictureBox7.ImageLocation = slots[6].ImgPath;
            }
        }

        private void PictureBox8_click(object sender, EventArgs e)
        {
            if (OpenCard(8))
            {
                pictureBox8.ImageLocation = slots[7].ImgPath;
            }
        }

        private void PictureBox9_click(object sender, EventArgs e)
        {
            if (OpenCard(9))
            {
                pictureBox9.ImageLocation = slots[8].ImgPath;
            }
        }

        private void PictureBox10_click(object sender, EventArgs e)
        {
            if (OpenCard(10))
            {
                pictureBox10.ImageLocation = slots[9].ImgPath;
            }
        }

        private void PictureBox11_click(object sender, EventArgs e)
        {
            if (OpenCard(11))
            {
                pictureBox11.ImageLocation = slots[10].ImgPath;
            }
        }

        private void PictureBox12_click(object sender, EventArgs e)
        {
            if (OpenCard(12))
            {
                pictureBox12.ImageLocation = slots[11].ImgPath;
            }
        }

        private void PictureBox13_click(object sender, EventArgs e)
        {
            if (OpenCard(13))
            {
                pictureBox13.ImageLocation = slots[12].ImgPath;
            }
        }

        private void PictureBox14_click(object sender, EventArgs e)
        {
            if (OpenCard(14))
            {
                pictureBox14.ImageLocation = slots[13].ImgPath;
            }
        }

        private void PictureBox15_click(object sender, EventArgs e)
        {
            if (OpenCard(15))
            {
                pictureBox15.ImageLocation = slots[14].ImgPath;
            }
        }

        private void PictureBox16_click(object sender, EventArgs e)
        {
            if (OpenCard(16))
            {
                pictureBox16.ImageLocation = slots[15].ImgPath;
            }
        }

        private void PictureBox17_click(object sender, EventArgs e)
        {
            if (OpenCard(17))
            {
                pictureBox17.ImageLocation = slots[16].ImgPath;
            }
        }

        private void PictureBox18_click(object sender, EventArgs e)
        {
            if (OpenCard(18))
            {
                pictureBox18.ImageLocation = slots[17].ImgPath;
            }
        }

        private void PictureBox19_click(object sender, EventArgs e)
        {
            if (OpenCard(19))
            {
                pictureBox19.ImageLocation = slots[18].ImgPath;
            }
        }

        private void PictureBox20_click(object sender, EventArgs e)
        {
            if (OpenCard(20))
            {
                pictureBox20.ImageLocation = slots[19].ImgPath;
            }
        }

        private void PictureBox21_click(object sender, EventArgs e)
        {
            if (OpenCard(21))
            {
                pictureBox21.ImageLocation = slots[20].ImgPath;
            }
        }

        private void PictureBox22_click(object sender, EventArgs e)
        {
            if (OpenCard(22))
            {
                pictureBox22.ImageLocation = slots[21].ImgPath;
            }
        }

        private void PictureBox23_click(object sender, EventArgs e)
        {
            if (OpenCard(23))
            {
                pictureBox23.ImageLocation = slots[22].ImgPath;
            }
        }

        private void PictureBox24_click(object sender, EventArgs e)
        {
            if (OpenCard(24))
            {
                pictureBox24.ImageLocation = slots[23].ImgPath;
            }
        }
    }
}
