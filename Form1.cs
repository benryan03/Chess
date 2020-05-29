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
        string selectedPiece = null;

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

        private void MouseEnterSquare(object sender, EventArgs e)
        {
            PictureBox square = ((PictureBox)sender);
            if (square1 != square && square2 != square)
            {
                square.BackColor = Color.White;
            }
        }

        private void mouseLeaveSquare(object sender, EventArgs e)
        {
            PictureBox square = ((PictureBox)sender);
            if (square1 != square && square2 != square)
            {
                ResetColorOfSquare(square);
            }
        }

        private void SquareClick(object sender, EventArgs e)
        {
            PictureBox square = ((PictureBox)sender);
            //First click of move
            if (square.Image != null & square1Clicked == false & square2Clicked == false)
            {
                square.BackColor = Color.DarkGray;
                square1Clicked = true;
                square1 = square;

                //Detect which piece was clicked
                if (square.Tag.ToString() == "white_pawn")
                {
                    selectedPiece = "white_pawn";
                }
                else if (square.Tag.ToString() == "black_pawn")
                {
                    selectedPiece = "black_pawn";
                }
                else if (square.Tag.ToString() == "white_rook")
                {
                    selectedPiece = "white_rook";
                }
                else if (square.Tag.ToString() == "black_rook")
                {
                    selectedPiece = "black_rook";
                }
                else if (square.Tag.ToString() == "white_knight")
                {
                    selectedPiece = "white_knight";
                }
                else if (square.Tag.ToString() == "black_knight")
                {
                    selectedPiece = "black_knight";
                }
                else if (square.Tag.ToString() == "white_bishop")
                {
                    selectedPiece = "white_bishop";
                }
                else if (square.Tag.ToString() == "black_bishop")
                {
                    selectedPiece = "black_bishop";
                }
                else if (square.Tag.ToString() == "white_queen")
                {
                    selectedPiece = "white_queen";
                }
                else if (square.Tag.ToString() == "black_queen")
                {
                    selectedPiece = "black_queen";
                }
                else if (square.Tag.ToString() == "white_king")
                {
                    selectedPiece = "white_king";
                }
                else if (square.Tag.ToString() == "black_king")
                {
                    selectedPiece = "black_king";
                }
            }

            //Second click of move
            else if (square1Clicked == true & square2Clicked == false)
            {

                //NEED TO CHECK IF MOVE IS VALID
                if (selectedPiece == "white_pawn")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("WHITE PAWN"); //DEBUG
                    selectedPiece = null;
                }
                else if (selectedPiece == "black_pawn")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("BLACK PAWN"); //DEBUG
                    selectedPiece = null;
                }
                if (selectedPiece == "white_rook")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("WHITE ROOK"); //DEBUG
                    selectedPiece = null;
                }
                else if (selectedPiece == "black_rook")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("BLACK ROOK"); //DEBUG
                    selectedPiece = null;
                }
                if (selectedPiece == "white_knight")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("WHITE KNIGHT"); //DEBUG
                    selectedPiece = null;
                }
                else if (selectedPiece == "black_knight")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("BLACK KNIGHT"); //DEBUG
                    selectedPiece = null;
                }
                if (selectedPiece == "white_bishop")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("WHITE BISHOP"); //DEBUG
                    selectedPiece = null;
                }
                else if (selectedPiece == "black_bishop")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("BLACK BISHOP"); //DEBUG
                    selectedPiece = null;
                }
                if (selectedPiece == "white_queen")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("WHITE QUEEN"); //DEBUG
                    selectedPiece = null;
                }
                else if (selectedPiece == "black_queen")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("BLACK QUEEN"); //DEBUG
                    selectedPiece = null;
                }
                if (selectedPiece == "white_king")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("WHITE KING"); //DEBUG
                    selectedPiece = null;
                }
                else if (selectedPiece == "black_king")
                {
                    ResetColorOfSquare(square1);
                    square1 = null;
                    square1Clicked = false;
                    MessageBox.Show("BLACK KING"); //DEBUG
                    selectedPiece = null;
                }
            }
        }
    }
}
