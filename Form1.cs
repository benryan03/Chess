using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        bool square1Clicked = false;
        bool square2Clicked = false;
        PictureBox square1 = new PictureBox();
        PictureBox square2 = new PictureBox();

        public Form1()
        {
            InitializeComponent();
        }

        private void ResetColorOfSquare(PictureBox square)
        {
            string squareName = square.Name.ToString();
            string x = squareName.Substring(10, 2);
            int y = int.Parse(x);
            if (1 <= y && y <= 8)
            {
                if (y % 2 != 0)//If square is odd
                {
                    square.BackColor = Color.Beige;
                }
                else //square is even
                {
                    square.BackColor = Color.Goldenrod;
                }
            }
            else if (9 <= y && y <= 16)
            {
                if (y % 2 == 0)
                {
                    square.BackColor = Color.Beige;
                }
                else
                {
                    square.BackColor = Color.Goldenrod;
                }
            }
            else if (17 <= y && y <= 24)
            {
                if (y % 2 != 0)
                {
                    square.BackColor = Color.Beige;
                }
                else
                {
                    square.BackColor = Color.Goldenrod;
                }
            }
            else if (25 <= y && y <= 32)
            {
                if (y % 2 == 0)
                {
                    square.BackColor = Color.Beige;
                }
                else
                {
                    square.BackColor = Color.Goldenrod;
                }
            }
            else if (33 <= y && y <= 40)
            {
                if (y % 2 != 0)
                {
                    square.BackColor = Color.Beige;
                }
                else
                {
                    square.BackColor = Color.Goldenrod;
                }
            }
            else if (41 <= y && y <= 48)
            {
                if (y % 2 == 0)
                {
                    square.BackColor = Color.Beige;
                }
                else
                {
                    square.BackColor = Color.Goldenrod;
                }
            }
            else if (49 <= y && y <= 56)
            {
                if (y % 2 != 0)
                {
                    square.BackColor = Color.Beige;
                }
                else
                {
                    square.BackColor = Color.Goldenrod;
                }
            }
            else if (57 <= y && y <= 64)
            {
                if (y % 2 == 0)
                {
                    square.BackColor = Color.Beige;
                }
                else
                {
                    square.BackColor = Color.Goldenrod;
                }
            }
        }

        private void mouseEnterSquare(object sender, EventArgs e)
        {

            //PictureBox square = ((PictureBox)sender);
            //color = square.BackColor;
            //square.BackColor = Color.White;
        }

        private void mouseLeaveSquare(object sender, EventArgs e)
        {
            //PictureBox square = ((PictureBox)sender);
            //if (square.Tag == null)
            //{
            //}
        }

        private void squareClick(object sender, EventArgs e)
        {
            PictureBox square = ((PictureBox)sender);
            //First click of move
            if (square.Image != null & square1Clicked == false & square2Clicked == false)
            {
                square.BackColor = Color.DarkGray;
                square1Clicked = true;
                square1 = square;
            }

            //Second click of move
            else if (square1Clicked == true & square2Clicked == false)
            {
                //NEED TO CHECK IF MOVE IS VALID
                
                ResetColorOfSquare(square1);
                square1 = null;
                square1Clicked = false;
            }

        }
    }
}
