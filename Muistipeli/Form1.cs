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
            
            // for each image found make a new Card with imagepath and filename as imagename
            
            // Start a new game
            NewGame();
        }

        private void NewGame()
        {
            // pick N amount of cards from List

            // populate N*2 Pictureboxes with cards randomly

            // reset counter for tries


            throw new NotImplementedException();
        }

        private void OpenCard()
        {
            // try to open the card clicked on, if already open or removed card do nothing

            // if another card already open compare them
            // if a pair remove them else close them and increment tries counter
            
            // check if any pairs left in game
        }

        private void Btn_newgame_click(object sender, EventArgs e)
        {
            
        }

        private void PictureBox1_click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_click(object sender, EventArgs e)
        {

        }

        private void PictureBox3_click(object sender, EventArgs e)
        {

        }

        private void PictureBox4_click(object sender, EventArgs e)
        {

        }

        private void PictureBox5_click(object sender, EventArgs e)
        {

        }

        private void PictureBox6_click(object sender, EventArgs e)
        {

        }
    }
}
