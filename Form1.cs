using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        PictureBox square = new PictureBox();

        PictureBox whiteKing = new PictureBox();
        PictureBox blackKing = new PictureBox();



        string selectedPiece = null;
        int turn = 0;

        public Form1()
        {
            InitializeComponent();
            whiteKing = pictureBox35; //debug - normal 61
            blackKing = pictureBox05;
        }
        private void ValidMove(string piece)
        {
            //I still need to find a way to simplify this
            if (piece == "white_pawn")
            {
                square.Image = Properties.Resources.white_pawn;
                status.Text = "Black's move";

                ResetColorOfSquare(square1);
                square1.Image = null;
                square1.Tag = "empty";
                square1 = null;
                square1Clicked = false;
                selectedPiece = null;
                square.Tag = piece;
                turn++;
            }
            else if (piece == "black_pawn")
            {
                square.Image = Properties.Resources.black_pawn;
                status.Text = "White's move";

                ResetColorOfSquare(square1);
                square1.Image = null;
                square1.Tag = "empty";
                square1 = null;
                square1Clicked = false;
                selectedPiece = null;
                square.Tag = piece;
                turn++;
            }
            else if (piece == "white_rook")
            {
                square.Image = Properties.Resources.white_rook;
                status.Text = "Black's move";

                ResetColorOfSquare(square1);
                square1.Image = null;
                square1.Tag = "empty";
                square1 = null;
                square1Clicked = false;
                selectedPiece = null;
                square.Tag = piece;
                turn++;
            }
            else if (piece == "black_rook")
            {
                square.Image = Properties.Resources.black_rook;
                status.Text = "White's move";

                ResetColorOfSquare(square1);
                square1.Image = null;
                square1.Tag = "empty";
                square1 = null;
                square1Clicked = false;
                selectedPiece = null;
                square.Tag = piece;
                turn++;
            }
            else if (piece == "white_knight")
            {
                square.Image = Properties.Resources.white_knight;
                status.Text = "Black's move";

                ResetColorOfSquare(square1);
                square1.Image = null;
                square1.Tag = "empty";
                square1 = null;
                square1Clicked = false;
                selectedPiece = null;
                square.Tag = piece;
                turn++;
            }
            else if (piece == "black_knight")
            {
                square.Image = Properties.Resources.black_knight;
                status.Text = "White's move";

                ResetColorOfSquare(square1);
                square1.Image = null;
                square1.Tag = "empty";
                square1 = null;
                square1Clicked = false;
                selectedPiece = null;
                square.Tag = piece;
                turn++;
            }
            else if (piece == "white_bishop")
            {
                square.Image = Properties.Resources.white_bishop;
                status.Text = "Black's move";

                ResetColorOfSquare(square1);
                square1.Image = null;
                square1.Tag = "empty";
                square1 = null;
                square1Clicked = false;
                selectedPiece = null;
                square.Tag = piece;
                turn++;
            }
            else if (piece == "black_bishop")
            {
                square.Image = Properties.Resources.black_bishop;
                status.Text = "White's move";

                ResetColorOfSquare(square1);
                square1.Image = null;
                square1.Tag = "empty";
                square1 = null;
                square1Clicked = false;
                selectedPiece = null;
                square.Tag = piece;
                turn++;
            }
            else if (piece == "white_queen")
            {
                square.Image = Properties.Resources.white_queen;
                status.Text = "Black's move";

                ResetColorOfSquare(square1);
                square1.Image = null;
                square1.Tag = "empty";
                square1 = null;
                square1Clicked = false;
                selectedPiece = null;
                square.Tag = piece;
                turn++;
            }
            else if (piece == "black_queen")
            {
                square.Image = Properties.Resources.black_queen;
                status.Text = "White's move";

                ResetColorOfSquare(square1);
                square1.Image = null;
                square1.Tag = "empty";
                square1 = null;
                square1Clicked = false;
                selectedPiece = null;
                square.Tag = piece;
                turn++;
            }






            else if (piece == "white_king")
            {
                whiteKing = square;
                square.Tag = piece;
                square1.Tag = "empty";

                bool CheckStatus = DoesMoveResultInCheck("white_king");

                if (CheckStatus == false)
                {
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    //square1.Tag = "empty";
                    square1Clicked = false;
                    selectedPiece = null;
                    //square.Tag = piece;
                    turn++;
                    square1 = null;


                    square.Image = Properties.Resources.white_king;
                    status.Text = "Black's move";
                }
                else
                {
                    whiteKing = square1;
                    square.Tag = "empty";
                    square1.Tag = piece;
                    status.Text = "White cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1 = null;

                }





            }
            else if (piece == "black_king")
            {
                square.Image = Properties.Resources.black_king;
                status.Text = "White's move";
                blackKing = square;

                ResetColorOfSquare(square1);
                square1.Image = null;
                square1.Tag = "empty";
                square1 = null;
                square1Clicked = false;
                selectedPiece = null;
                square.Tag = piece;
                turn++;
            }


















        }

        private void InvalidMove()
        {
            ResetColorOfSquare(square1);
            square1 = null;
            square1Clicked = false;
            selectedPiece = null;
        }

        private bool DoesMoveResultInCheck(string piece)
        //This method is a bit messy and it makes me sad
        //If I had to do this project over, I might make 2 invisible rows and columns on each side of the board,
        //so no squares could be null here
        {
            if (piece.Contains("white"))
            {
                //Get position of white king
                int KingRow = tableLayoutPanel1.GetRow(whiteKing);
                int KingCol = tableLayoutPanel1.GetColumn(whiteKing);

                //Check if the king is in an outside or outside-adjecent row or column
                if (KingCol > 1 & KingCol < 6 & KingRow > 1 & KingRow < 6) //everything is fine
                {

                }
                else if (KingCol == 0 & KingRow > 1 & KingRow < 6) //do not check col - 1 or col - 2
                {

                }
                else if (KingCol == 0 & KingRow == 0) //do not check col - 1 or col - 2 or row - 1 or row -2
                {

                }
                else if (KingCol == 0 & KingRow == 1) //do not check col - 1 or col - 2 or row - 2
                {

                }
                else if (KingCol == 0 & KingRow == 6) //do not check col - 1 or col - 2 or row + 2
                {

                }
                else if (KingCol == 0 & KingRow == 7) //do not check col - 1 or col - 2 or row + 1 or row + 2
                {

                }
                else if (KingCol == 1 & KingRow > 1 && KingRow < 6) //do not check col - 2
                {

                }
                else if (KingCol == 1 & KingRow == 0) //do not check col - 2 or row - 1 or row -2
                {

                }
                else if (KingCol == 1 & KingRow == 1) //do not check col - 2 or row - 2
                {

                }
                else if (KingCol == 1 & KingRow == 6) //do not check col - 2 or row + 2
                {

                }
                else if (KingCol == 1 & KingRow == 7) //do not check col - 2 or row + 1 or row + 2
                {

                }
                else if (KingCol == 6 & KingRow > 1 && KingRow < 6) //do not check col + 2
                {

                }
                else if (KingCol == 6 & KingRow == 0) //do not check col + 2 or row - 1 or row -2
                {

                }
                else if (KingCol == 6 & KingRow == 1) //do not check col + 2 or row - 2
                {

                }
                else if (KingCol == 6 & KingRow == 6) //do not check col + 2 or row + 2
                {

                }
                else if (KingCol == 6 & KingRow == 7) //do not check col + 2 or row + 1 or row + 2
                {

                }
                else if (KingCol == 7 & KingRow > 1 && KingRow < 6) //do not check col + 1 or col + 2
                {

                }
                else if (KingCol == 7 & KingRow == 0) //do not check col + 1 or col + 2 or row - 1 or row -2
                {

                }
                else if (KingCol == 7 & KingRow == 1) //do not check col + 1 or col + 2 or row - 2
                {

                }
                else if (KingCol == 7 & KingRow == 6) //do not check col + 1 or col + 2 or row + 2
                {

                }
                else if (KingCol == 7 & KingRow == 7) //do not check col + 1 or col + 2 or row + 1 or row + 2
                {

                }

                /////////////////////////////////////
                //Check if a pawn can kill white king
                Control blackPawnCheck1 = new Control();
                Control blackPawnCheck2 = new Control();

                //Determine if any squares need to be excluded (because they are outside the board)
                if (KingCol > 1 & KingCol < 6 & KingRow > 1 & KingRow < 6) //everything is fine
                {
                    //MessageBox.Show("1");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 0 & KingRow > 1 & KingRow < 6) //do not check col - 1 or col - 2
                {
                    //MessageBox.Show("2");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 0) //do not check col - 1 or col - 2 or row - 1 or row -2
                {
                    //MessageBox.Show("3");
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 1) //do not check col - 1 or col - 2 or row - 2
                {
                    //MessageBox.Show("4");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 6) //do not check col - 1 or col - 2 or row + 2
                {
                    //MessageBox.Show("5");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 7) //do not check col - 1 or col - 2 or row + 1 or row + 2
                {
                    //MessageBox.Show("6");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 1 & KingRow > 1 && KingRow < 6) //do not check col - 2
                {
                    //MessageBox.Show("7");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 1 & KingRow == 0) //do not check col - 2 or row - 1 or row -2
                {
                    //MessageBox.Show("8");
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 1 & KingRow == 1) //do not check col - 2 or row - 2
                {
                    //MessageBox.Show("9");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 1 & KingRow == 6) //do not check col - 2 or row + 2
                {
                    //MessageBox.Show("10");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 1 & KingRow == 7) //do not check col - 2 or row + 1 or row + 2
                {
                    //MessageBox.Show("11");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 6 & KingRow > 1 && KingRow < 6) //do not check col + 2
                {
                    //MessageBox.Show("12");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 6 & KingRow == 0) //do not check col + 2 or row - 1 or row -2
                {
                    //MessageBox.Show("13");
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 6 & KingRow == 1) //do not check col + 2 or row - 2
                {
                    //MessageBox.Show("14");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 6 & KingRow == 6) //do not check col + 2 or row + 2
                {
                    //MessageBox.Show("15");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 6 & KingRow == 7) //do not check col + 2 or row + 1 or row + 2
                {
                    //MessageBox.Show("16");
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 7 & KingRow > 1 && KingRow < 6) //do not check col + 1 or col + 2
                {
                    //MessageBox.Show("17");
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 7 & KingRow == 0) //do not check col + 1 or col + 2 or row - 1 or row -2
                {
                    //MessageBox.Show("18");
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 7 & KingRow == 1) //do not check col + 1 or col + 2 or row - 2
                {
                    //MessageBox.Show("19");
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 7 & KingRow == 6) //do not check col + 1 or col + 2 or row + 2
                {
                    //MessageBox.Show("20");
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 7 & KingRow == 7) //do not check col + 1 or col + 2 or row + 1 or row + 2
                {
                    //MessageBox.Show("21");
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }

                //Check if check
                if (blackPawnCheck1 != null & blackPawnCheck2 == null)
                {
                    //MessageBox.Show("22");
                    //blackPawnCheck1.BackColor = Color.Yellow; //DEBUG
                    if (blackPawnCheck1.Tag.ToString() == "black_pawn")
                    {
                        blackPawnCheck1.BackColor = Color.Red;
                        //MessageBox.Show("Moved into check (black pawn"); //DEBUG
                        return true;
                    }
                }
                else if (blackPawnCheck1 == null & blackPawnCheck2 != null)
                {
                    //MessageBox.Show("23");
                    //blackPawnCheck2.BackColor = Color.Yellow; //DEBUG
                    if (blackPawnCheck2.Tag.ToString() == "black_pawn")
                    {
                        blackPawnCheck2.BackColor = Color.Red;
                        //MessageBox.Show("Moved into check (black pawn"); //DEBUG
                        return true;
                    }
                }
                else if (blackPawnCheck1 != null & blackPawnCheck2 != null)
                {
                    //MessageBox.Show("24");
                    //blackPawnCheck1.BackColor = Color.Yellow; //DEBUG
                    //blackPawnCheck2.BackColor = Color.Yellow; //DEBUG

                    if (blackPawnCheck1.Tag.ToString() == "black_pawn")
                    {
                        blackPawnCheck1.BackColor = Color.Red;
                        //MessageBox.Show("Moved into check (black pawn"); //DEBUG
                        return true;
                    }
                    if (blackPawnCheck2.Tag.ToString() == "black_pawn")
                    {
                        blackPawnCheck2.BackColor = Color.Red;
                        //MessageBox.Show("Moved into check (black pawn"); //DEBUG
                        return true;
                    }
                }

                /////////////////////////////////////
                //Check if a rook can kill white king

                Control blackRookCheck1 = new Control();
                Control blackRookCheck2 = new Control();
                Control blackRookCheck3 = new Control();
                Control blackRookCheck4 = new Control();

                //Check if the king is in an outside or outside-adjecent row or column
                if (KingCol > 1 & KingCol < 6 & KingRow > 1 & KingRow < 6) //everything is fine
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow > 1 & KingRow < 6) //do not check col - 1 or col - 2
                {
                    blackRookCheck1 = null;
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow == 0) //do not check col - 1 or col - 2 or row - 1 or row -2
                {
                    blackRookCheck1 = null;
                    blackRookCheck2 = null;
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow == 1) //do not check col - 1 or col - 2 or row - 2
                {
                    blackRookCheck1 = null;
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1); 
                }
                else if (KingCol == 0 & KingRow == 6) //do not check col - 1 or col - 2 or row + 2
                {
                    blackRookCheck1 = null;
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow == 7) //do not check col - 1 or col - 2 or row + 1 or row + 2
                {
                    blackRookCheck1 = null;
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = null;
                }
                else if (KingCol == 1 & KingRow > 1 && KingRow < 6) //do not check col - 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 0) //do not check col - 2 or row - 1 or row -2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = null;
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 1) //do not check col - 2 or row - 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 6) //do not check col - 2 or row + 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 7) //do not check col - 2 or row + 1 or row + 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = null;
                }
                else if (KingCol == 6 & KingRow > 1 && KingRow < 6) //do not check col + 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 0) //do not check col + 2 or row - 1 or row -2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = null;
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 1) //do not check col + 2 or row - 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 6) //do not check col + 2 or row + 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 7) //do not check col + 2 or row + 1 or row + 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackRookCheck4 = null;
                }
                else if (KingCol == 7 & KingRow > 1 && KingRow < 6) //do not check col + 1 or col + 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = null;
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 0) //do not check col + 1 or col + 2 or row - 1 or row -2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = null;
                    blackRookCheck3 = null;
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 1) //do not check col + 1 or col + 2 or row - 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = null;
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 6) //do not check col + 1 or col + 2 or row + 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = null;
                    blackRookCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 7) //do not check col + 1 or col + 2 or row + 1 or row + 2
                {
                    blackRookCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackRookCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackRookCheck3 = null;
                    blackRookCheck4 = null;
                }

                //Check if check - rook left
                if (blackRookCheck1 != null)
                {
                    int y = tableLayoutPanel1.GetRow(blackRookCheck1);
                    for (int x = tableLayoutPanel1.GetColumn(blackRookCheck1); x >= 0; x--)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_rook")
                        //Square is piece that is not black rook
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_rook")
                        //Square is black rook
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }


                //Check if check - rook right
                if (blackRookCheck3 != null)
                {
                    int y = tableLayoutPanel1.GetRow(blackRookCheck3);
                    for (int x = tableLayoutPanel1.GetColumn(blackRookCheck3); x <= 7; x++)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_rook")
                        //Square is piece that is not black rook
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_rook")
                        //Square is black rook
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }

                //Check if check - rook up
                if (blackRookCheck2 != null)
                {
                    int y = tableLayoutPanel1.GetColumn(blackRookCheck2);
                    for (int x = tableLayoutPanel1.GetRow(blackRookCheck2); x >= 0; x--)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "black_rook")
                        //Square is piece that is not black rook
                        {
                            tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "black_rook")
                        //Square is black rook
                        {
                            tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }

                //Check if check - rook down
                if (blackRookCheck4 != null)
                {
                    int y = tableLayoutPanel1.GetColumn(blackRookCheck4);
                    for (int x = tableLayoutPanel1.GetRow(blackRookCheck4); x <= 7; x++)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "black_rook")
                        //Square is piece that is not black rook
                        {
                            tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "black_rook")
                        //Square is black rook
                        {
                            tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }

                ///////////////////////////////////////
                //Check if a knight can kill white king
                Control blackKnightCheck1 = new Control();
                Control blackKnightCheck2 = new Control();
                Control blackKnightCheck3 = new Control();
                Control blackKnightCheck4 = new Control();
                Control blackKnightCheck5 = new Control();
                Control blackKnightCheck6 = new Control();
                Control blackKnightCheck7 = new Control();
                Control blackKnightCheck8 = new Control();

                Control[] blackKnightChecks = {blackKnightCheck1, blackKnightCheck2, blackKnightCheck3, blackKnightCheck4, blackKnightCheck5, blackKnightCheck6, blackKnightCheck7, blackKnightCheck8};

                if (KingCol > 1 && KingCol < 6 && KingRow > 1 && KingRow < 6) //everything is fine
                {
                    blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                    blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                    blackKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                    blackKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                    blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                    blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                    blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                    blackKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                }
                else if (KingCol == 0)
                {
                    if (KingRow > 1 && KingRow < 6) //do not check col - 1 or col - 2
                    {
                        blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        blackKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        blackKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        blackKnightChecks[1] = null;
                        blackKnightChecks[5] = null;
                        blackKnightChecks[6] = null;
                        blackKnightChecks[7] = null;
                    }
                    else if (KingRow == 0) //do not check col - 1 or col - 2 or row - 1 or row -2
                    {
                        blackKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        blackKnightChecks[0] = null;
                        blackKnightChecks[1] = null;
                        blackKnightChecks[2] = null;
                        blackKnightChecks[5] = null;
                        blackKnightChecks[6] = null;
                        blackKnightChecks[7] = null;
                    }
                    else if (KingRow == 1) //do not check col - 1 or col - 2 or row - 2
                    {
                        blackKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        blackKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        blackKnightChecks[0] = null;
                        blackKnightChecks[1] = null;
                        blackKnightChecks[5] = null;
                        blackKnightChecks[6] = null;
                        blackKnightChecks[7] = null;
                    }
                    else if (KingRow == 6) //do not check col - 1 or col - 2 or row + 2
                    {
                        blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        blackKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        blackKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        blackKnightChecks[1] = null;
                        blackKnightChecks[4] = null;
                        blackKnightChecks[5] = null;
                        blackKnightChecks[6] = null;
                        blackKnightChecks[7] = null;
                    }
                    else if (KingRow == 7) //do not check col - 1 or col - 2 or row + 1 or row + 2
                    {
                        blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        blackKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        blackKnightChecks[1] = null;
                        blackKnightChecks[3] = null;
                        blackKnightChecks[4] = null;
                        blackKnightChecks[5] = null;
                        blackKnightChecks[6] = null;
                        blackKnightChecks[7] = null;
                    }
                }
                else if (KingCol == 1)
                {
                    if (KingRow > 1 && KingRow < 6) //do not check col - 2
                    {
                        blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        blackKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        blackKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        blackKnightChecks[6] = null;
                        blackKnightChecks[7] = null;
                    }
                    else if (KingRow == 0) //do not check col - 2 or row - 1 or row -2
                    {
                        blackKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        blackKnightChecks[0] = null;
                        blackKnightChecks[1] = null;
                        blackKnightChecks[2] = null;
                        blackKnightChecks[6] = null;
                        blackKnightChecks[7] = null;
                    }
                    else if (KingRow == 1) //do not check col - 2 or row - 2
                    {
                        blackKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        blackKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        blackKnightChecks[0] = null;
                        blackKnightChecks[1] = null;
                        blackKnightChecks[6] = null;
                        blackKnightChecks[7] = null;
                    }
                    else if (KingRow == 6) //do not check col - 2 or row + 2
                    {
                        blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        blackKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        blackKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        blackKnightChecks[4] = null;
                        blackKnightChecks[5] = null;
                        blackKnightChecks[6] = null;
                        blackKnightChecks[7] = null;
                    }
                    else if (KingRow == 7) //do not check col - 2 or row + 1 or row + 2
                    {
                        blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        blackKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        blackKnightChecks[3] = null;
                        blackKnightChecks[4] = null;
                        blackKnightChecks[5] = null;
                        blackKnightChecks[6] = null;
                        blackKnightChecks[7] = null;
                    }
                }
                else if (KingCol == 6)
                {
                    if (KingRow > 1 && KingRow < 6) //do not check col + 2
                    {
                        blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                    }
                    else if (KingRow == 0) //do not check col + 2 or row - 1 or row -2
                    {
                        blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        blackKnightChecks[0] = null;
                        blackKnightChecks[1] = null;
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                    }
                    else if (KingRow == 1) //do not check col + 2 or row - 2
                    {
                        blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        blackKnightChecks[0] = null;
                        blackKnightChecks[1] = null;
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                    }
                    else if (KingRow == 6) //do not check col + 2 or row + 2
                    {
                        blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                        blackKnightChecks[4] = null;
                        blackKnightChecks[5] = null;
                    }
                    else if (KingRow == 7) //do not check col + 2 or row + 1 or row + 2
                    {
                        blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                        blackKnightChecks[4] = null;
                        blackKnightChecks[5] = null;
                        blackKnightChecks[7] = null;
                    }
                }
                else if (KingCol == 7)
                {
                    if (KingRow > 1 && KingRow < 6) //do not check col + 1 or col + 2
                    {
                        blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        blackKnightChecks[0] = null;
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                        blackKnightChecks[4] = null;
                    }
                    else if (KingRow == 0) //do not check col + 1 or col + 2 or row - 1 or row -2
                    {
                        blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        blackKnightChecks[0] = null;
                        blackKnightChecks[1] = null;
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                        blackKnightChecks[4] = null;
                    }
                    else if (KingRow == 1) //do not check col + 1 or col + 2 or row - 2
                    {
                        blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        blackKnightChecks[0] = null;
                        blackKnightChecks[1] = null;
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                        blackKnightChecks[4] = null;
                    }
                    else if (KingRow == 6) //do not check col + 1 or col + 2 or row + 2
                    {
                        blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        blackKnightChecks[0] = null;
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                        blackKnightChecks[4] = null;
                        blackKnightChecks[5] = null;
                    }
                    else if (KingRow == 7) //do not check col + 1 or col + 2 or row + 1 or row + 2
                    {
                        blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[0] = null;
                        blackKnightChecks[1] = null;
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                        blackKnightChecks[4] = null;
                        blackKnightChecks[7] = null;
                    }
                }

                //Check if check
                foreach (Control x in blackKnightChecks)
                {
                    if (x != null) //if square is on the board
                    {
                        //x.BackColor = Color.Red; //DEBUG
                        if (x.Tag.ToString() == "black_knight")
                        {
                            //MessageBox.Show("moved into check (black knight)"); //DEBUG
                            x.BackColor = Color.Red;
                            return true;
                        }
                    }
                }
                
                //If no pieces are in cleck
                return false;
            }
            else
            {
                return false;
            }


            /*

            if (blackKnightCheck1.Tag.ToString() == ("black_knight" | null) |
                blackKnightCheck2.Tag.ToString() == "black_knight" |
                blackKnightCheck3.Tag.ToString() == "black_knight" |
                blackKnightCheck4.Tag.ToString() == "black_knight" |
                blackKnightCheck5.Tag.ToString() == "black_knight" |
                blackKnightCheck6.Tag.ToString() == "black_knight" |
                blackKnightCheck7.Tag.ToString() == "black_knight" |
                blackKnightCheck8.Tag.ToString() == "black_knight")
            {
                return true;
            }

            */

            //Check if a bishop can kill white king

            //Check if queen can kill white king

            //Check if king can kill white king

            //else if (piece.Contains("black"))
            //{
            //    //Get position of black king
            //    int KingRow = tableLayoutPanel1.GetRow(blackKing);
            //    int KingCol = tableLayoutPanel1.GetColumn(blackKing);
            //    return false; //DEGUG
            //}

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
            square = (PictureBox)sender;

            //First click of move
            if (square.Image != null & square1Clicked == false & square2Clicked == false)
            {
                //Detect which piece was clicked
                if (square.Tag.ToString() == "white_pawn" & turn % 2 == 0)
                {
                    selectedPiece = "white_pawn";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
                else if (square.Tag.ToString() == "black_pawn" & turn % 2 != 0)
                {
                    selectedPiece = "black_pawn";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
                else if (square.Tag.ToString() == "white_rook" & turn % 2 == 0)
                {
                    selectedPiece = "white_rook";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
                else if (square.Tag.ToString() == "black_rook" & turn % 2 != 0)
                {
                    selectedPiece = "black_rook";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
                else if (square.Tag.ToString() == "white_knight" & turn % 2 == 0)
                {
                    selectedPiece = "white_knight";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
                else if (square.Tag.ToString() == "black_knight" & turn % 2 != 0)
                {
                    selectedPiece = "black_knight";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
                else if (square.Tag.ToString() == "white_bishop" & turn % 2 == 0)
                {
                    selectedPiece = "white_bishop";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
                else if (square.Tag.ToString() == "black_bishop" & turn % 2 != 0)
                {
                    selectedPiece = "black_bishop";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
                else if (square.Tag.ToString() == "white_queen" & turn % 2 == 0)
                {
                    selectedPiece = "white_queen";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
                else if (square.Tag.ToString() == "black_queen" & turn % 2 != 0)
                {
                    selectedPiece = "black_queen";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
                else if (square.Tag.ToString() == "white_king" & turn % 2 == 0)
                {
                    selectedPiece = "white_king";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
                else if (square.Tag.ToString() == "black_king" & turn % 2 != 0)
                {
                    selectedPiece = "black_king";
                    square.BackColor = Color.DarkGray;
                    square1Clicked = true;
                    square1 = square;
                }
            }

            //Second click of move
            else if (square1Clicked == true & square2Clicked == false)
            {
                if (selectedPiece == "white_pawn")
                {
                    if (square.Tag.ToString().Contains("white") == false || square.Tag.ToString().Contains("empty") == true)
                    {

                        if (this.tableLayoutPanel1.GetRow(square1) == 6) //Original row
                        {
                            if (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square)) //Original row and same column
                            {
                                if (((this.tableLayoutPanel1.GetRow(square1) - 1) == this.tableLayoutPanel1.GetRow(square)) || ((this.tableLayoutPanel1.GetRow(square1) - 2) == this.tableLayoutPanel1.GetRow(square))) //Original row and same column and "1 up" or "2 up"
                                {
                                    if (square.Tag.ToString() == "empty") //If square is empty
                                    {
                                        ValidMove("white_pawn");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else //Original row, and not same column
                            {
                                if ((this.tableLayoutPanel1.GetRow(square1) - 1) == this.tableLayoutPanel1.GetRow(square))  //Original row, and not same column, and "1 up"
                                {
                                    if ((this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square) + 1) || (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square) - 1)) //Original row, and column is 1 over
                                    {
                                        if (square.Tag.ToString() != "empty") //If square is full
                                        {
                                            ValidMove("white_pawn");
                                        }
                                        else
                                        {
                                            InvalidMove();
                                        }
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                        else //Not original row
                        {
                            if (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square)) //Not original row, and same column
                            {
                                if ((this.tableLayoutPanel1.GetRow(square1) - 1) == this.tableLayoutPanel1.GetRow(square))  //Not original row, and same column, and "1 up"
                                {
                                    if (square.Tag.ToString() == "empty")
                                    {
                                        ValidMove("white_pawn");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else //Not original row, and different column
                            {
                                if ((this.tableLayoutPanel1.GetRow(square1) - 1) == this.tableLayoutPanel1.GetRow(square))  //Not original row, and not same column, and "1 up"
                                {
                                    if ((this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square) + 1) || (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square) - 1)) //Not original row, and not same column, and column is 1 over
                                    {
                                        if (square.Tag.ToString() != "empty") //If square is full
                                        {
                                            ValidMove("white_pawn");
                                        }
                                        else
                                        {
                                            InvalidMove();
                                        }
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                    }
                    else
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "black_pawn")
                {
                    if (square.Tag.ToString().Contains("black") == false || square.Tag.ToString().Contains("empty") == true)
                    {

                        if (this.tableLayoutPanel1.GetRow(square1) == 1) //Original row
                        {
                            if (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square)) //Original row and same column
                            {
                                if (((this.tableLayoutPanel1.GetRow(square1) + 1) == this.tableLayoutPanel1.GetRow(square)) || ((this.tableLayoutPanel1.GetRow(square1) + 2) == this.tableLayoutPanel1.GetRow(square))) //Original row and same column and "1 down" or "2 down"
                                {
                                    if (square.Tag.ToString() == "empty") //If square is empty
                                    {
                                        ValidMove("black_pawn");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else //Original row, and not same column
                            {
                                if ((this.tableLayoutPanel1.GetRow(square1) + 1) == this.tableLayoutPanel1.GetRow(square))  //Original row, and not same column, and "1 up"
                                {
                                    if ((this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square) - 1) || (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square) + 1)) //Original row, and column is 1 over
                                    {
                                        if (square.Tag.ToString() != "empty") //If square is full
                                        {
                                            ValidMove("black_pawn");
                                        }
                                        else
                                        {
                                            InvalidMove();
                                        }
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                        else //Not original row
                        {
                            if (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square)) //Not original row, and same column
                            {
                                if ((this.tableLayoutPanel1.GetRow(square1) + 1) == this.tableLayoutPanel1.GetRow(square))  //Not original row, and same column, and "1 down"
                                {
                                    if (square.Tag.ToString() == "empty")
                                    {
                                        ValidMove("black_pawn");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else //Not original row, and different column
                            {
                                if ((this.tableLayoutPanel1.GetRow(square1) + 1) == this.tableLayoutPanel1.GetRow(square))  //Not original row, and not same column, and "1 up"
                                {
                                    if ((this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square) + 1) || (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square) - 1)) //Not original row, and not same column, and column is 1 over
                                    {
                                        if (square.Tag.ToString() != "empty") //If square is full
                                        {
                                            ValidMove("black_pawn");
                                        }
                                        else
                                        {
                                            InvalidMove();
                                        }
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                    }
                    else
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "white_rook")
                {
                    if (square.Tag.ToString().Contains("white") == false || square.Tag.ToString().Contains("empty") == true)
                    {
                        int column = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endRow = this.tableLayoutPanel1.GetRow(square);
                        bool squareInWay = false;

                        if (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square)) //Vertical move
                        {
                            if (endRow < startRow) // Vertical move "up"
                            {
                                for (int x = startRow - 1; x > endRow; x--) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(column, x);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("white_rook");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else //Vertical move "down"
                            {
                                for (int x = startRow + 1; x < endRow; x++) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(column, x);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("white_rook");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                        else if (this.tableLayoutPanel1.GetRow(square1) == this.tableLayoutPanel1.GetRow(square)) //Horizontal move
                        {
                            int row = this.tableLayoutPanel1.GetRow(square1);
                            int startCol = this.tableLayoutPanel1.GetColumn(square1);
                            int endCol = this.tableLayoutPanel1.GetColumn(square);
                            bool squareInWay2 = false;

                            if (startCol > endCol) // Horizontal move "left"
                            {
                                for (int x = startCol - 1; x > endCol; x--) //For each square in the way, check if occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(x, row);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay2 = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay2 == false)
                                {
                                    ValidMove("white_rook");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else //Horizontal move right
                            {
                                for (int x = startCol + 1; x < endCol; x++) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(x, row);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay2 = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay2 == false)
                                {
                                    ValidMove("white_rook");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                        else
                        {
                            InvalidMove();
                        }
                    }
                    else
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "black_rook")
                {
                    if (square.Tag.ToString().Contains("black") == false || square.Tag.ToString().Contains("empty") == true)
                    {
                        int column = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endRow = this.tableLayoutPanel1.GetRow(square);
                        bool squareInWay = false;

                        if (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square)) //Vertical move
                        {
                            if (endRow < startRow) // Vertical move "up"
                            {
                                for (int x = startRow - 1; x > endRow; x--) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(column, x);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("black_rook");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else //Vertical move "down"
                            {
                                for (int x = startRow + 1; x < endRow; x++) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(column, x);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("black_rook");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                        else if (this.tableLayoutPanel1.GetRow(square1) == this.tableLayoutPanel1.GetRow(square)) //Horizontal move
                        {
                            int row = this.tableLayoutPanel1.GetRow(square1);
                            int startCol = this.tableLayoutPanel1.GetColumn(square1);
                            int endCol = this.tableLayoutPanel1.GetColumn(square);
                            bool squareInWay2 = false;

                            if (startCol > endCol) // Horizontal move "left"
                            {
                                for (int x = startCol - 1; x > endCol; x--) //For each square in the way, check if occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(x, row);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay2 = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay2 == false)
                                {
                                    ValidMove("black_rook");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else //Horizontal move right
                            {
                                for (int x = startCol + 1; x < endCol; x++) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(x, row);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay2 = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay2 == false)
                                {
                                    ValidMove("black_rook");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                        else
                        {
                            InvalidMove();
                        }
                    }
                    else
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "white_knight")
                {
                    if (square.Tag.ToString().Contains("white") == false || square.Tag.ToString().Contains("empty") == true) //Makes sure target square is not occupied by own piece
                    {
                        int startColumn = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endColumn = this.tableLayoutPanel1.GetColumn(square);
                        int endRow = this.tableLayoutPanel1.GetRow(square);

                        if (endColumn == startColumn - 2) //Vertical move up
                        {
                            if (endRow == startRow + 1) //Vertical move up/right
                            {
                                ValidMove("white_knight");
                            }
                            else if (endRow == startRow - 1) //Vertical move up/left
                            {
                                ValidMove("white_knight");
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else if (endColumn == startColumn + 2) //Vertical move down
                        {
                            if (endRow == startRow + 1) //Vertical move down/right
                            {
                                ValidMove("white_knight");
                            }
                            else if (endRow == startRow - 1) //Vertical move down/left
                            {
                                ValidMove("white_knight");
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else if (endRow == startRow - 2) //Horizontal move left
                        {
                            if (endColumn == startColumn - 1) //Horizontal move left/up
                            {
                                ValidMove("white_knight");
                            }
                            else if (endColumn == startColumn + 1) //Horizontal move left/down
                            {
                                ValidMove("white_knight");
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else if (endRow == startRow + 2) //Horizontal move right
                        {
                            if (endColumn == startColumn - 1) //Horizontal move right/up
                            {
                                ValidMove("white_knight");
                            }
                            else if (endColumn == startColumn + 1) //Horizontal move right/down
                            {
                                ValidMove("white_knight");
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else
                        {
                            InvalidMove();
                        }
                    }
                    else //Target is own piece
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "black_knight")
                {
                    if (square.Tag.ToString().Contains("black") == false || square.Tag.ToString().Contains("empty") == true) //Makes sure target square is not occupied by own piece
                    {
                        int startColumn = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endColumn = this.tableLayoutPanel1.GetColumn(square);
                        int endRow = this.tableLayoutPanel1.GetRow(square);

                        if (endColumn == startColumn - 2) //Vertical move up
                        {
                            if (endRow == startRow + 1) //Vertical move up/right
                            {
                                ValidMove("black_knight");
                            }
                            else if (endRow == startRow - 1) //Vertical move up/left
                            {
                                ValidMove("black_knight");
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else if (endColumn == startColumn + 2) //Vertical move down
                        {
                            if (endRow == startRow + 1) //Vertical move down/right
                            {
                                ValidMove("black_knight");
                            }
                            else if (endRow == startRow - 1) //Vertical move down/left
                            {
                                ValidMove("black_knight");
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else if (endRow == startRow - 2) //Horizontal move left
                        {
                            if (endColumn == startColumn - 1) //Horizontal move left/up
                            {
                                ValidMove("black_knight");
                            }
                            else if (endColumn == startColumn + 1) //Horizontal move left/down
                            {
                                ValidMove("black_knight");
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else if (endRow == startRow + 2) //Horizontal move right
                        {
                            if (endColumn == startColumn - 1) //Horizontal move right/up
                            {
                                ValidMove("black_knight");
                            }
                            else if (endColumn == startColumn + 1) //Horizontal move right/down
                            {
                                ValidMove("black_knight");
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else
                        {
                            InvalidMove();
                        }
                    }
                    else //Target is own piece
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "white_bishop")
                {
                    if (square.Tag.ToString().Contains("white") == false || square.Tag.ToString().Contains("empty") == true) //Makes sure target square is not occupied by own piece
                    {
                        int startColumn = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endColumn = this.tableLayoutPanel1.GetColumn(square);
                        int endRow = this.tableLayoutPanel1.GetRow(square);

                        int rowDifference = endRow - startRow;
                        int columnDifference = endColumn - startColumn;

                        bool squareInWay = false;

                        if (endColumn < startColumn) //LEFT
                        {
                            if (endRow > startRow) //Target square is down and to the left 
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn - x, startRow + x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                            //MessageBox.Show("test"); //debug
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("white_bishop");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else if (endRow < startRow) //Target square is up and to the left
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn - x, startRow - x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("white_bishop");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else if (endColumn > startColumn) //RIGHT
                        {
                            if (endRow > startRow) //Target square is down and to the right
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference))
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn + x, startRow + x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("white_bishop");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else if (endRow < startRow) //Target square is up and to the right
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn + x, startRow - x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false && squareInWay == false)
                                        {
                                            squareInWay = true;
                                            MessageBox.Show(y.Tag.ToString());
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("white_bishop");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                        else
                        {
                            InvalidMove(); //horizontal move by bishop
                        }
                    }
                    else
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "black_bishop")
                {
                    if (square.Tag.ToString().Contains("black") == false || square.Tag.ToString().Contains("empty") == true) //Makes sure target square is not occupied by own piece
                    {
                        int startColumn = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endColumn = this.tableLayoutPanel1.GetColumn(square);
                        int endRow = this.tableLayoutPanel1.GetRow(square);

                        int rowDifference = endRow - startRow;
                        int columnDifference = endColumn - startColumn;

                        bool squareInWay = false;

                        if (endColumn < startColumn) //LEFT
                        {
                            if (endRow > startRow) //Target square is down and to the left 
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn - x, startRow + x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                            //MessageBox.Show("test"); //debug
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("black_bishop");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else if (endRow < startRow) //Target square is up and to the left
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn - x, startRow - x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("black_bishop");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else
                            {
                                InvalidMove();
                                //MessageBox.Show("horizontal move by bishop"); //DEBUG
                            }
                        }
                        else if (endColumn > startColumn) //RIGHT
                        {
                            if (endRow > startRow) //Target square is down and to the right
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference))
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn + x, startRow + x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("black_bishop");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else if (endRow < startRow) //Target square is up and to the right
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn + x, startRow - x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false && squareInWay == false)
                                        {
                                            squareInWay = true;
                                            //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("black_bishop");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                        else
                        {
                            InvalidMove(); //horizontal move by bishop
                        }
                    }
                    else
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "white_queen")
                {
                    if (square.Tag.ToString().Contains("white") == false || square.Tag.ToString().Contains("empty") == true) //Makes sure target square is not occupied by own piece
                    {
                        int startColumn = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endColumn = this.tableLayoutPanel1.GetColumn(square);
                        int endRow = this.tableLayoutPanel1.GetRow(square);

                        int rowDifference = endRow - startRow;
                        int columnDifference = endColumn - startColumn;

                        bool squareInWay = false;

                        if (endColumn < startColumn) //LEFT
                        {
                            if (startRow == endRow) // Horizontal move left
                            {
                                for (int x = startColumn - 1; x > endColumn; x--) //For each square in the way, check if occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(x, endRow);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("white_queen");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else if (endRow > startRow) //Target square is down and to the left 
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn - x, startRow + x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                            //MessageBox.Show("test"); //debug
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("white_queen");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                    //MessageBox.Show("not diagonal"); //DEBUG
                                }
                            }
                            else if (endRow < startRow) //Target square is up and to the left
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn - x, startRow - x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("white_queen");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else if (endColumn == startColumn) //VERTICAL MOVE
                        {
                            if (endRow < startRow) // Vertical move "up"
                            {
                                for (int x = startRow - 1; x > endRow; x--) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(endColumn, x);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("white_queen");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else //Vertical move "down"
                            {
                                for (int x = startRow + 1; x < endRow; x++) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(endColumn, x);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("white_queen");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                        else if (endColumn > startColumn) //RIGHT
                        {
                            if (startRow == endRow) //Horizontal move right
                            {
                                for (int x = startColumn + 1; x < endColumn; x++) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(x, endRow);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("white_queen");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else if (endRow > startRow) //Target square is down and to the right
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn + x, startRow + x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("white_queen");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else if (endRow < startRow) //Target square is up and to the right
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn + x, startRow - x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false && squareInWay == false)
                                        {
                                            squareInWay = true;
                                            MessageBox.Show(y.Tag.ToString());
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("white_queen");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                        else //if (endColumn == startColumn) //Horizontal move
                        {
                            InvalidMove();
                        }
                    }
                    else
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "black_queen")
                {
                    if (square.Tag.ToString().Contains("black") == false || square.Tag.ToString().Contains("empty") == true) //Makes sure target square is not occupied by own piece
                    {
                        int startColumn = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endColumn = this.tableLayoutPanel1.GetColumn(square);
                        int endRow = this.tableLayoutPanel1.GetRow(square);

                        int rowDifference = endRow - startRow;
                        int columnDifference = endColumn - startColumn;

                        bool squareInWay = false;

                        if (endColumn < startColumn) //LEFT
                        {
                            if (startRow == endRow) // Horizontal move left
                            {
                                for (int x = startColumn - 1; x > endColumn; x--) //For each square in the way, check if occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(x, endRow);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("black_queen");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else if (endRow > startRow) //Target square is down and to the left 
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn - x, startRow + x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                            //MessageBox.Show("test"); //debug
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("black_queen");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                        // MessageBox.Show("invalid move1"); //DEBUG
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                    //MessageBox.Show("not diagonal"); //DEBUG
                                }
                            }
                            else if (endRow < startRow) //Target square is up and to the left
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn - x, startRow - x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("black_queen");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                        //MessageBox.Show("invalid move3"); //DEBUG
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                    //MessageBox.Show("not diagonal"); //DEBUG
                                }
                            }
                            else
                            {
                                InvalidMove();
                                //MessageBox.Show("horizontal move by bishop"); //DEBUG
                            }
                        }
                        else if (endColumn == startColumn) //VERTICAL MOVE
                        {
                            if (endRow < startRow) // Vertical move "up"
                            {
                                for (int x = startRow - 1; x > endRow; x--) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(endColumn, x);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("black_queen");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else //Vertical move "down"
                            {
                                for (int x = startRow + 1; x < endRow; x++) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(endColumn, x);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("black_queen");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                        }
                        else if (endColumn > startColumn) //RIGHT
                        {
                            if (startRow == endRow) //Horizontal move right
                            {
                                for (int x = startColumn + 1; x < endColumn; x++) //For each square in the way, check occupied
                                {
                                    Control y = this.tableLayoutPanel1.GetControlFromPosition(x, endRow);
                                    if (y.Tag.ToString().Contains("empty") == false)
                                    {
                                        squareInWay = true;
                                        //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                    }
                                }
                                if (squareInWay == false)
                                {
                                    ValidMove("black_queen");
                                }
                                else
                                {
                                    InvalidMove();
                                }
                            }
                            else if (endRow > startRow) //Target square is down and to the right
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn + x, startRow + x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false)
                                        {
                                            squareInWay = true;
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("black_queen");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                        //MessageBox.Show("invalid move6"); //DEBUG
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                    //MessageBox.Show("not diagonal"); //DEBUG
                                }
                            }
                            else if (endRow < startRow) //Target square is up and to the right
                            {
                                if (Math.Abs(rowDifference) == Math.Abs(columnDifference)) //Target square is diagonal
                                {
                                    for (int x = 1; x < Math.Abs(rowDifference); x++) //For each square in the way, check occupied
                                    {
                                        Control y = this.tableLayoutPanel1.GetControlFromPosition(startColumn + x, startRow - x);
                                        //MessageBox.Show("Checking square"); //DEBUG
                                        if (y.Tag.ToString().Contains("empty") == false && squareInWay == false)
                                        {
                                            squareInWay = true;
                                            MessageBox.Show(y.Tag.ToString());
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        ValidMove("black_queen");
                                    }
                                    else
                                    {
                                        InvalidMove();
                                        //MessageBox.Show("invalid move8"); //DEBUG
                                    }
                                }
                                else
                                {
                                    InvalidMove();
                                    //MessageBox.Show("not diagonal"); //DEBUG
                                }
                            }
                        }
                        else //if (endColumn == startColumn) //Horizontal move
                        {
                            InvalidMove();
                        }
                    }
                    else
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "white_king")
                {
                    if (square.Tag.ToString().Contains("white") == false || square.Tag.ToString().Contains("empty") == true) //Makes sure target square is not occupied by own piece
                    {
                        int startColumn = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endColumn = this.tableLayoutPanel1.GetColumn(square);
                        int endRow = this.tableLayoutPanel1.GetRow(square);

                        int rowDifference = endRow - startRow;
                        int columnDifference = endColumn - startColumn;
                        
                        if (Math.Abs(rowDifference) == 1 || Math.Abs(columnDifference) == 1)
                        {
                            ValidMove("white_king");
                        }
                        else
                        {
                            InvalidMove();
                        }
                    }
                    else
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "black_king")
                {
                    if (square.Tag.ToString().Contains("black") == false || square.Tag.ToString().Contains("empty") == true) //Makes sure target square is not occupied by own piece
                    {
                        int startColumn = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endColumn = this.tableLayoutPanel1.GetColumn(square);
                        int endRow = this.tableLayoutPanel1.GetRow(square);

                        int rowDifference = endRow - startRow;
                        int columnDifference = endColumn - startColumn;

                        if (Math.Abs(rowDifference) == 1 || Math.Abs(columnDifference) == 1)
                        {
                            ValidMove("black_king");
                        }
                        else
                        {
                            InvalidMove();
                        }
                    }
                    else
                    {
                        InvalidMove();
                    }
                }
            }
        }
    }
}