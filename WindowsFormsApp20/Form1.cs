using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp20
{
    public partial class Form1 : Form
    {
        //Global Variables, which can be accessed from anywhere
        public PictureBox[,] gamespace;

        //Starting xPostition
        public int xPos = 0;

        //Starting yPosition
        public int yPos = 0;

        //public variable to set tick rate of timers
        public int TickRate = 95;
        public Form1()
        {
            InitializeComponent();
            
            // calls GeneratePlayArea Method when the form is first opened
            GeneratePlayArea();
            
            

        }


        // Method for generating play area 2Darray
        private void GeneratePlayArea()
        {
            // Declares an 2D Array 4 indexes wide, and 4 indexes tall to hold picture boxes 
            // from grid on the form
            PictureBox [,] pictureBoxArray = new PictureBox [4,4];

            // assigns pictureboxes from Grid to array
            pictureBoxArray[0, 0] = pb00;
            pictureBoxArray[1, 0] = pb10;
            pictureBoxArray[2, 0] = pb20;
            pictureBoxArray[3, 0] = pb30;
            pictureBoxArray[0, 1] = pb01;
            pictureBoxArray[1, 1] = pb11;
            pictureBoxArray[2, 1] = pb21;
            pictureBoxArray[3, 1] = pb31;
            pictureBoxArray[0, 2] = pb02;
            pictureBoxArray[1, 2] = pb12;
            pictureBoxArray[2, 2] = pb22;
            pictureBoxArray[3, 2] = pb32;
            pictureBoxArray[0, 3] = pb03;
            pictureBoxArray[1, 3] = pb13;
            pictureBoxArray[2, 3] = pb23;
            pictureBoxArray[3, 3] = pb33;

            gamespace = pictureBoxArray;
        }

        //Event triggered by pressing key
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Right arrow key press where e = key that was pressed and Keys.Right refers to right key on keyboard
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                //sets interval of timer "ticks"
                timerRight.Interval = TickRate;
                //Starts timerRight
                timerRight.Start();

            }

            //left arrow left keypress  where e = key that was pressed and Keys.Left refers to left key on keyboard
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                //sets interval of timer "ticks"
                timerLeft.Interval = TickRate;
                //Starts timerLeft
                timerLeft.Start();

            }

            //down arrow down keypress where e = key that was pressed and Keys.Down refers to down key on keyboard
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                //sets interval of timer "ticks"
                timerDown.Interval = TickRate;
                //Starts timerDown
                timerDown.Start();

            }

            //left arrow Up keypress where e = key that was pressed and Keys.Up refers to up key on keyboard
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                //sets interval of timer "ticks"
                timerUp.Interval = TickRate;
                //Starts timerUp
                timerUp.Start();

            }
        }

        // Event triggered by releasing a key
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Right arrow key release where e = key that was pressed and Keys.Right refers to right key on keyboard
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                //stops timerright
                timerRight.Stop();

            }
            //left arrow key release where e = key that was pressed and Keys.Left refers to left key on keyboard
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                //stops timerleft
                timerLeft.Stop();

            }
            //down arrow key release where e = key that was pressed and Keys.Down refers to down key on keyboard
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                //stops timerdown
                timerDown.Stop();

            }
            //up arrow key release where e = key that was pressed and Keys.Up refers to up key on keyboard
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                //stops timerdown
                timerUp.Stop();

            }
        }

        //Controls what happens every time the timerRight "ticks"
        private void timerright_Tick(object sender, EventArgs e)
        {
            //Try catch to prevent errors from going outside array
            try
            {
                //checks if the position + 1 (to the right of xPos) is empty (white) 
                // If the space is empty it sets it to occupied (black) and adds 1 to the
                // xPos position variable and sets the new square, black and the original square white.

                if (gamespace[xPos + 1, yPos].BackColor == Color.White)
                {
                    gamespace[xPos + 1, yPos].BackColor = Color.Black;
                    
                    gamespace[xPos, yPos].BackColor = Color.White;

                    xPos++;
                }
            }
            catch
            {

            }
        }

        //determines what the left timer does on every tick
        private void timerLeft_Tick(object sender, EventArgs e)
        {

            //checks if the X position - 1 (to the left of xPos) is empty (white) 
            // If the space is empty it sets it to occupied (black) and subtracts 1 from the
            // xPos position variable and sets the new square, black and the original square white.
            try
            {
                if (gamespace[xPos - 1, yPos].BackColor == Color.White)
                {
                    gamespace[xPos - 1, yPos].BackColor = Color.Black;
                    gamespace[xPos, yPos].BackColor = Color.White;

                    xPos--;
                }
            }
            catch
            {

            }
        }


        // determines what the "timerdown" does ever tick
        private void timerDown_Tick(object sender, EventArgs e)
        {
            try
            {
                //checks if the Y position + 1 (to the BELOW current yPos) is empty (white) 
                // If the space is empty it sets it to occupied (black) and adds 1 to the
                // yPos position variable and sets the new square, black and the original square white.

                if (gamespace[xPos, yPos+1].BackColor == Color.White)
                {
                    gamespace[xPos, yPos+1].BackColor = Color.Black;
                    gamespace[xPos, yPos].BackColor = Color.White;

                    yPos++;
                }
            }
            catch
            {

            }
        }


        private void timerUp_Tick(object sender, EventArgs e)
        {
            try
            {
                //checks if the Y position - 1 (to the ABOVE current yPos) is empty (white) 
                // If the space is empty it sets it to occupied (black) and subtracts 1 from the
                // yPos position variable and sets the new square, black and the original square white.

                if (gamespace[xPos, yPos - 1].BackColor == Color.White)
                {
                    gamespace[xPos, yPos - 1].BackColor = Color.Black;
                    gamespace[xPos, yPos].BackColor = Color.White;

                    yPos--;
                }
            }
            catch
            {

            }
        }
    }
}
