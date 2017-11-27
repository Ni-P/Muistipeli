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

        List<Card> cards; // Holds all the card prototypes 
        int cardpairs = 12; // how many different cards are in the game
        int remainingpairs = 0;
        int tries = 0; // how many mistakes made
        bool allowCardOpening = false; // allow clicking cards
        string backgroundImage = @".\res\52.png";
        int match1 = -1; // first card of found pair
        int match2 = -1; // second card of found pair

        Card[] slots; // Holds all the cards on the board
        Card openCard = null; // currently opened card for comparison
        List<PictureBox> boxes;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // grab references to all boxes
            GetBoxes();

            // Look for images in the res folder
            List<string> images = new List<string>();

            // load all the paths for the images in the game
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
                Card card = new Card("card_" + i, images[i]);
                cards.Add(card);
            }

            // Start a new game
            NewGame(cardpairs);
        }

        private void NewGame(int N)
        {
            // reset board
            slots = new Card[N * 2];
            for(int i = 0; i < boxes.Count; i++)
            {
                HideCard(i);
            }

            // pick N amount of cards from List

            // populate N*2 Pictureboxes with cards randomly
            Card[] deck1Arr = new Card[N]; // clone our cards to make 2 identical decks
            Card[] deck2Arr = new Card[N]; // clone our cards to make 2 identical decks
            cards.CopyTo(deck1Arr);
            cards.CopyTo(deck2Arr);
            List<Card> deck1 = new List<Card>();
            List<Card> deck2 = new List<Card>();
            deck1 = deck1Arr.ToList();
            deck2 = deck2Arr.ToList();
            deck1Arr = null;
            deck2Arr = null;

            Random rng = new Random();

            if (deck1.Count < N || deck2.Count < N)
            {
                throw new Exception("ERROR: not enough cards in lists.");
            }

            for (int i = 0; i < N * 2; i += 2)
            {
                // get a random card from each deck
                int rnd1 = rng.Next(deck1.Count);
                int rnd2 = rng.Next(deck2.Count);

                // ensure card is not matched after resetting game
                deck1[rnd1].IsMatched = false;
                deck2[rnd2].IsMatched = false;

                // assign the cards to 2 slots in order
                slots[i] = deck1[rnd1];
                slots[i + 1] = deck2[rnd2];

                // remove the assigned cards from the decks
                deck1.RemoveAt(rnd1);
                deck2.RemoveAt(rnd2);
                // repeat until limit when all decks should be empty and the slots filled
            }

            // reset counters
            tries = 0;
            UpdateLabel();
            remainingpairs = N;

            allowCardOpening = true;
            VictoryLabel.Visible = false;
        }

        private bool OpenCard(int s)
        {
            s--; // adjust for zero index FIXME: adjust the click events instead
            if (!allowCardOpening)
            {
                return false;
            }
            // try to open the card clicked on, if already open or removed card do nothing
            if(s == match1 || slots[s].IsMatched) // if card already open do nothing
            {
                return false;
            }
            else if( s != match1) // if second card, set data for timer
            {
                if(openCard == null) // if no other card open, open this one
                {
                    openCard = slots[s];
                    match1 = s;
                    slots[s].IsOpen = true;
                    return true;
                }
                else
                {
                    // card was already matched
                    if (slots[s].IsMatched)
                    {
                        return false;
                    }
                    // set the timer to resolve the open cards
                    delayTimer.Enabled = true;
                    allowCardOpening = false;
                    slots[s].IsOpen = true;
                    match2 = s;
                    return true;
                }
            }
            return false;
            // if another card already open compare them
            // if a pair remove them else close them and increment tries counter

            // check if any pairs left in game
        }

        // hide the card of a box at i, where i is zerobased index of box
        private void HideCard(int i)
        {
            boxes[i].ImageLocation = null;
        }

        private void GetBoxes()
        {
            boxes = new List<PictureBox>();
            boxes.Add(pictureBox1);
            boxes.Add(pictureBox2);
            boxes.Add(pictureBox3);
            boxes.Add(pictureBox4);
            boxes.Add(pictureBox5);
            boxes.Add(pictureBox6);
            boxes.Add(pictureBox7);
            boxes.Add(pictureBox8);
            boxes.Add(pictureBox9);
            boxes.Add(pictureBox10);
            boxes.Add(pictureBox11);
            boxes.Add(pictureBox12);
            boxes.Add(pictureBox13);
            boxes.Add(pictureBox14);
            boxes.Add(pictureBox15);
            boxes.Add(pictureBox16);
            boxes.Add(pictureBox17);
            boxes.Add(pictureBox18);
            boxes.Add(pictureBox19);
            boxes.Add(pictureBox20);
            boxes.Add(pictureBox21);
            boxes.Add(pictureBox22);
            boxes.Add(pictureBox23);
            boxes.Add(pictureBox24);
            //boxes.Add(pictureBox2);
            //boxes.Add(pictureBox2);
            //boxes.Add(pictureBox2);
            //boxes.Add(pictureBox2);
            //boxes.Add(pictureBox2);
            //boxes.Add(pictureBox30);
            //boxes.Add(pictureBox31);
            //boxes.Add(pictureBox32);


        }

        private void DelayTimerTick(object sender, EventArgs e)
        {
            // allow player to open cards again
            allowCardOpening = true;
            // disable timer
            delayTimer.Enabled = false;

            // resolve the cards
            if(slots[match1].Name == slots[match2].Name)
            {
                // cards are a pair
                remainingpairs--;
                slots[match1].IsMatched = true;
                slots[match2].IsMatched = true;
                match1 = -1;
                match2 = -1;
                openCard = null;
                if(remainingpairs == 0)
                {
                    VictoryLabel.Visible = true;
                    allowCardOpening = false; // game over
                    return;
                }
            }
            else
            {
                // cards are not a pair
                slots[match1].IsOpen = false;
                HideCard(match1);
                slots[match2].IsOpen = false;
                HideCard(match2);
                match1 = -1;
                match2 = -1;
                openCard = null;
                tries++;
                UpdateLabel();
            }

        }

        private void UpdateLabel()
        {
            AttemptsLabel.Text = tries + " Yritystä";
        }
        private void Btn_newgame_click(object sender, EventArgs e)
        {
            NewGame(cardpairs);
            //Console.WriteLine("");
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
