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

        PictureBox whiteKing2 = new PictureBox();
        PictureBox blackKing2 = new PictureBox();

        string selectedPiece = null;
        int turn = 0;

        bool IsCastle1Possible = true;
        bool IsCastle2Possible = true;
        bool IsCastle3Possible = true;
        bool IsCastle4Possible = true;

        Image[] CapturedWhitePieces = {null, null, null, null, null, null, null, null, null, null, null, null, null, null, null};
        Image[] CapturedBlackPieces = {null, null, null, null, null, null, null, null, null, null, null, null, null, null, null};

        string[] CapturedWhitePiecesTags = { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        string[] CapturedBlackPiecesTags = { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };

        int CapturedWhitePiecesQuantity = 0;
        int CapturedBlackPiecesQuantity = 0;

        bool RevivePieceStatus = false;

        public Form1()
        {
            InitializeComponent();
            whiteKing = pictureBox61;
            blackKing = pictureBox05;
        }

        private void MouseEnterSquare(object sender, EventArgs e)
        //Change background to white
        {
            PictureBox square = ((PictureBox)sender);
            if (square1 != square && square2 != square)
            {
                square.BackColor = Color.White;
            }
        }

        private void MouseLeaveSquare(object sender, EventArgs e)
        //Remove white background
        {
            PictureBox square = ((PictureBox)sender);
            if (square1 != square && square2 != square)
            {
                ResetColorOfSquare(square);
            }
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
                    if (square.Tag.ToString().Contains("white") == false)
                    {
                        if (this.tableLayoutPanel1.GetRow(square1) == 9) //Original row
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

                        else if (this.tableLayoutPanel1.GetRow(square) == 3) //Pawn reached end
                        {
                            if (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square)) //Not original row, and same column
                            {
                                if ((this.tableLayoutPanel1.GetRow(square1) - 1) == this.tableLayoutPanel1.GetRow(square))  //Not original row, and same column, and "1 up"
                                {
                                    if (square.Tag.ToString() == "empty")
                                    {
                                        //Revive captured piece
                                        RevivePieceStatus = true;
                                        ValidMove("white_pawn");
                                        status.Text = "White - choose a piece to bring back";
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
                                            //Revive captured piece
                                            RevivePieceStatus = true;
                                            ValidMove("white_pawn");
                                            status.Text = "White - choose a piece to bring back";

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
                    if (square.Tag.ToString().Contains("black") == false)
                    {

                        if (this.tableLayoutPanel1.GetRow(square1) == 4) //Original row
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




                        else if (this.tableLayoutPanel1.GetRow(square) == 10) //Pawn reached end
                        {
                            if (this.tableLayoutPanel1.GetColumn(square1) == this.tableLayoutPanel1.GetColumn(square)) //Not original row, and same column
                            {
                                if ((this.tableLayoutPanel1.GetRow(square1) + 1) == this.tableLayoutPanel1.GetRow(square))  //Not original row, and same column, and "1 up"
                                {
                                    if (square.Tag.ToString() == "empty")
                                    {
                                        //Revive captured piece
                                        RevivePieceStatus = true;
                                        ValidMove("black_pawn");
                                        status.Text = "Black - choose a piece to bring back";
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
                                            //Revive captured piece
                                            RevivePieceStatus = true;
                                            ValidMove("black_pawn");
                                            status.Text = "Black - choose a piece to bring back";

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
                    if (square.Tag.ToString().Contains("white") == false)
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
                    if (square.Tag.ToString().Contains("black") == false)
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
                    if (square.Tag.ToString().Contains("white") == false) //Makes sure target square is not occupied by own piece
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
                    if (square.Tag.ToString().Contains("black") == false) //Makes sure target square is not occupied by own piece
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
                    if (square.Tag.ToString().Contains("white") == false) //Makes sure target square is not occupied by own piece
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
                    if (square.Tag.ToString().Contains("black") == false) //Makes sure target square is not occupied by own piece
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
                                //MessageBox.Show("horizontal move by bishop); //DEBUG
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
                    if (square.Tag.ToString().Contains("white") == false) //Makes sure target square is not occupied by own piece
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
                    if (square.Tag.ToString().Contains("black") == false) //Makes sure target square is not occupied by own piece
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
                                //MessageBox.Show("horizontal move by bishop); //DEBUG
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
                    if (square.Tag.ToString().Contains("white") == false) //Makes sure target square is not occupied by own piece
                    {
                        int startColumn = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endColumn = this.tableLayoutPanel1.GetColumn(square);
                        int endRow = this.tableLayoutPanel1.GetRow(square);

                        int rowDifference = endRow - startRow;
                        int columnDifference = endColumn - startColumn;

                        if ((Math.Abs(rowDifference) == 0 | Math.Abs(rowDifference) == 1) & (Math.Abs(columnDifference) == 0 | Math.Abs(columnDifference) == 1))
                        {
                            ValidMove("white_king");
                        }
                        else if (rowDifference == 0 & columnDifference == 2) //Castle right
                        {
                            if (IsCastlePossible("4") == true)
                            {
                                IsCastle4Possible = false;
                                IsCastle3Possible = false;
                                pictureBox62.Tag = "white_rook";
                                pictureBox62.Image = Properties.Resources.white_rook;
                                pictureBox64.Tag = "empty";
                                pictureBox64.Image = null;
                                ValidMove("white_king");
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else if (rowDifference == 0 & columnDifference == -2) //Castle left
                        {
                            if (IsCastlePossible("3") == true)
                            {
                                IsCastle4Possible = false;
                                IsCastle3Possible = false;
                                pictureBox60.Tag = "white_rook";
                                pictureBox60.Image = Properties.Resources.white_rook;
                                pictureBox57.Tag = "empty";
                                pictureBox57.Image = null;
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
                    else
                    {
                        InvalidMove();
                    }
                }

                else if (selectedPiece == "black_king")
                {
                    if (square.Tag.ToString().Contains("black") == false) //Makes sure target square is not occupied by own piece
                    {
                        int startColumn = this.tableLayoutPanel1.GetColumn(square1);
                        int startRow = this.tableLayoutPanel1.GetRow(square1);
                        int endColumn = this.tableLayoutPanel1.GetColumn(square);
                        int endRow = this.tableLayoutPanel1.GetRow(square);

                        int rowDifference = endRow - startRow;
                        int columnDifference = endColumn - startColumn;

                        if ((Math.Abs(rowDifference) == 0 | Math.Abs(rowDifference) == 1) & (Math.Abs(columnDifference) == 0 | Math.Abs(columnDifference) == 1))
                        {
                            ValidMove("black_king");
                        }
                        else if (rowDifference == 0 & columnDifference == 2) //Castle right
                        {
                            if (IsCastlePossible("2") == true)
                            {
                                IsCastle1Possible = false;
                                IsCastle2Possible = false;
                                pictureBox06.Tag = "black_rook";
                                pictureBox06.Image = Properties.Resources.black_rook;
                                pictureBox08.Tag = "empty";
                                pictureBox08.Image = null;
                                ValidMove("black_king");
                            }
                            else
                            {
                                InvalidMove();
                            }
                        }
                        else if (rowDifference == 0 & columnDifference == -2) //Castle left
                        {
                            if (IsCastlePossible("1") == true)
                            {
                                IsCastle1Possible = false;
                                IsCastle2Possible = false;
                                pictureBox04.Tag = "black_rook";
                                pictureBox04.Image = Properties.Resources.black_rook;
                                pictureBox01.Tag = "empty";
                                pictureBox01.Image = null;
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
                    else
                    {
                        InvalidMove();
                    }
                }
            }
        }

        private void ValidMove(string piece)
        //Move is valid - does it result in Check or Checkmate?
        //I still need to find a way to simplify this method
        {
            square1.Tag = "empty";

            //These are saved in case they need to be added to captured pieces
            string targetSquareTag = square.Tag.ToString();
            Image targetSquareImage = square.Image;


            if (piece == "white_pawn")
            {
                if (DoesMoveResultInCheck("white", true, false) == 0) //Move does not put self in check
                {
                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.white_pawn;
                    square.Tag = piece;
                    status.Text = "Black's move";

                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("black", true, false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }
                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    square1.Tag = piece;
                    square.Tag = "empty";
                    status.Text = "White cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1 = null;
                }
            }
            else if (piece == "black_pawn")
            {
                if (DoesMoveResultInCheck("black", true, false) == 0) //Move does not put self in check
                {


                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.black_pawn;
                    square.Tag = piece;
                    status.Text = "White's move";

                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("white", true, false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";


                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }

                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    square.Tag = "empty";
                    status.Text = "Black cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1.Tag = piece;
                    square1 = null;
                }
            }
            else if (piece == "white_rook")
            {
                if (DoesMoveResultInCheck("white", true, false) == 0) //Move does not put self in check
                {
                    if (square1 == pictureBox57)
                    {
                        IsCastle3Possible = false;
                    }
                    else if (square1 == pictureBox64)
                    {
                        IsCastle4Possible = false;
                    }



                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.white_rook;
                    square.Tag = piece;
                    status.Text = "Black's move";

                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("black", true, false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }
                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    square.Tag = "empty";
                    status.Text = "White cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1.Tag = piece;
                    square1 = null;
                }
            }
            else if (piece == "black_rook")
            {
                if (square1 == pictureBox01)
                {
                    IsCastle3Possible = false;
                }
                else if (square1 == pictureBox08)
                {
                    IsCastle4Possible = false;
                }

                if (DoesMoveResultInCheck("black", true, false) == 0) //Move does not put self in check
                {
                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.black_rook;
                    square.Tag = piece;
                    status.Text = "White's move";

                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("white", true, false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";


                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }

                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    square.Tag = "empty";
                    status.Text = "Black cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1.Tag = piece;
                    square1 = null;
                }
            }
            else if (piece == "white_knight")
            {
                if (DoesMoveResultInCheck("white", true, false) == 0) //Move does not put self in check
                {
                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.white_knight;
                    square.Tag = piece;
                    status.Text = "Black's move";

                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("black", true, false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }
                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    square.Tag = "empty";
                    status.Text = "White cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1.Tag = piece;
                    square1 = null;
                }
            }
            else if (piece == "black_knight")
            {
                if (DoesMoveResultInCheck("black", true, false) == 0) //Move does not put self in check
                {
                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.black_knight;
                    square.Tag = piece;
                    status.Text = "White's move";

                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("white", true, false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";


                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }

                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    square.Tag = "empty";
                    status.Text = "Black cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1.Tag = piece;
                    square1 = null;
                }
            }
            else if (piece == "white_bishop")
            {
                if (DoesMoveResultInCheck("white", true, false) == 0) //Move does not put self in check
                {
                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.white_bishop;
                    square.Tag = piece;
                    status.Text = "Black's move";

                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("black", true, false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }
                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    square.Tag = "empty";
                    status.Text = "White cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1.Tag = piece;
                    square1 = null;
                }
            }
            else if (piece == "black_bishop")
            {
                if (DoesMoveResultInCheck("black", true, false) == 0) //Move does not put self in check
                {
                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.black_bishop;
                    square.Tag = piece;
                    status.Text = "White's move";

                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("white", true, false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";


                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }

                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    square.Tag = "empty";
                    status.Text = "Black cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1.Tag = piece;
                    square1 = null;
                }
            }
            else if (piece == "white_queen")
            {
                if (DoesMoveResultInCheck("white", true, false) == 0) //Move does not put self in check
                {
                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.white_queen;
                    square.Tag = piece;
                    status.Text = "Black's move";

                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("black", true, false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }
                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    square.Tag = "empty";
                    status.Text = "White cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1.Tag = piece;
                    square1 = null;
                }
            }
            else if (piece == "black_queen")
            {
                if (DoesMoveResultInCheck("black", true, false) == 0) //Move is valid
                {
                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.black_queen;
                    square.Tag = piece;
                    status.Text = "White's move";

                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("white", true, false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";


                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }

                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    square.Tag = "empty";
                    status.Text = "Black cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1.Tag = piece;
                    square1 = null;
                }
            }
            else if (piece == "white_king")
            {
                whiteKing2 = whiteKing;
                whiteKing = square;
                if (DoesMoveResultInCheck("white", true, false) == 0) //Move does not put self in check
                {
                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.white_king;
                    square.Tag = piece;
                    status.Text = "Black's move";



                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("black", true, false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }
                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    whiteKing = whiteKing2;
                    square.Tag = "empty";
                    status.Text = "White cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1.Tag = piece;
                    square1 = null;
                }
            }
            else if (piece == "black_king")
            {
                blackKing2 = blackKing;
                blackKing = square;
                if (DoesMoveResultInCheck("black", true, false) == 0) //Move does not put self in check
                {
                    //Reset properties of square1
                    ResetColorOfSquare(square1);
                    square1.Image = null;
                    square1Clicked = false;
                    square1 = null;

                    //Prepare for next move
                    selectedPiece = null;
                    turn++;
                    square.Image = Properties.Resources.black_king;
                    square.Tag = piece;
                    status.Text = "White's move";

                    //Does move put opponent in Check?
                    if (DoesMoveResultInCheck("white", true, false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";


                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }

                    }
                    else
                    {
                        checkStatusLabel.Text = "";
                    }

                }
                else //Move is invalid
                {
                    //Reset and prepare for next move
                    blackKing = blackKing2;
                    square.Tag = "empty";
                    status.Text = "Black cannot move into Check.";
                    square1Clicked = false;
                    ResetColorOfSquare(square1);
                    square1.Tag = piece;
                    square1 = null;
                }
            }

            if (targetSquareTag != "empty")
            {
                if (targetSquareTag.Contains("white"))
                {
                    //Add to list of captured pieces
                    CapturedWhitePieces[CapturedWhitePiecesQuantity] = targetSquareImage;
                    CapturedWhitePiecesTags[CapturedWhitePiecesQuantity] = targetSquareTag;
                    CapturedWhitePiecesQuantity++;

                    //Refresh captured pieces display
                    CapturedWhitePiece0.BackgroundImage = CapturedWhitePieces[0];
                    CapturedWhitePiece1.BackgroundImage = CapturedWhitePieces[1];
                    CapturedWhitePiece2.BackgroundImage = CapturedWhitePieces[2];
                    CapturedWhitePiece3.BackgroundImage = CapturedWhitePieces[3];
                    CapturedWhitePiece4.BackgroundImage = CapturedWhitePieces[4];
                    CapturedWhitePiece5.BackgroundImage = CapturedWhitePieces[5];
                    CapturedWhitePiece6.BackgroundImage = CapturedWhitePieces[6];
                    CapturedWhitePiece7.BackgroundImage = CapturedWhitePieces[7];
                    CapturedWhitePiece8.BackgroundImage = CapturedWhitePieces[8];
                    CapturedWhitePiece9.BackgroundImage = CapturedWhitePieces[9];
                    CapturedWhitePiece10.BackgroundImage = CapturedWhitePieces[10];
                    CapturedWhitePiece11.BackgroundImage = CapturedWhitePieces[11];
                    CapturedWhitePiece12.BackgroundImage = CapturedWhitePieces[12];
                    CapturedWhitePiece13.BackgroundImage = CapturedWhitePieces[13];
                    CapturedWhitePiece14.BackgroundImage = CapturedWhitePieces[14];

                    CapturedWhitePiece0.Tag = CapturedWhitePiecesTags[0];
                    CapturedWhitePiece1.Tag = CapturedWhitePiecesTags[1];
                    CapturedWhitePiece2.Tag = CapturedWhitePiecesTags[2];
                    CapturedWhitePiece3.Tag = CapturedWhitePiecesTags[3];
                    CapturedWhitePiece4.Tag = CapturedWhitePiecesTags[4];
                    CapturedWhitePiece5.Tag = CapturedWhitePiecesTags[5];
                    CapturedWhitePiece6.Tag = CapturedWhitePiecesTags[6];
                    CapturedWhitePiece7.Tag = CapturedWhitePiecesTags[7];
                    CapturedWhitePiece8.Tag = CapturedWhitePiecesTags[8];
                    CapturedWhitePiece9.Tag = CapturedWhitePiecesTags[9];
                    CapturedWhitePiece10.Tag = CapturedWhitePiecesTags[10];
                    CapturedWhitePiece11.Tag = CapturedWhitePiecesTags[11];
                    CapturedWhitePiece12.Tag = CapturedWhitePiecesTags[12];
                    CapturedWhitePiece13.Tag = CapturedWhitePiecesTags[13];
                    CapturedWhitePiece14.Tag = CapturedWhitePiecesTags[14];
                }
                else if (targetSquareTag.Contains("black"))
                {
                    //Add to list of captured pieces
                    CapturedBlackPieces[CapturedBlackPiecesQuantity] = targetSquareImage;
                    CapturedBlackPiecesTags[CapturedBlackPiecesQuantity] = targetSquareTag;
                    CapturedBlackPiecesQuantity++;

                    //Refresh captured pieces display
                    CapturedBlackPiece0.BackgroundImage = CapturedBlackPieces[0];
                    CapturedBlackPiece1.BackgroundImage = CapturedBlackPieces[1];
                    CapturedBlackPiece2.BackgroundImage = CapturedBlackPieces[2];
                    CapturedBlackPiece3.BackgroundImage = CapturedBlackPieces[3];
                    CapturedBlackPiece4.BackgroundImage = CapturedBlackPieces[4];
                    CapturedBlackPiece5.BackgroundImage = CapturedBlackPieces[5];
                    CapturedBlackPiece6.BackgroundImage = CapturedBlackPieces[6];
                    CapturedBlackPiece7.BackgroundImage = CapturedBlackPieces[7];
                    CapturedBlackPiece8.BackgroundImage = CapturedBlackPieces[8];
                    CapturedBlackPiece9.BackgroundImage = CapturedBlackPieces[9];
                    CapturedBlackPiece10.BackgroundImage = CapturedBlackPieces[10];
                    CapturedBlackPiece11.BackgroundImage = CapturedBlackPieces[11];
                    CapturedBlackPiece12.BackgroundImage = CapturedBlackPieces[12];
                    CapturedBlackPiece13.BackgroundImage = CapturedBlackPieces[13];
                    CapturedBlackPiece14.BackgroundImage = CapturedBlackPieces[14];


                    CapturedBlackPiece0.Tag = CapturedBlackPiecesTags[0];
                    CapturedBlackPiece1.Tag = CapturedBlackPiecesTags[1];
                    CapturedBlackPiece2.Tag = CapturedBlackPiecesTags[2];
                    CapturedBlackPiece3.Tag = CapturedBlackPiecesTags[3];
                    CapturedBlackPiece4.Tag = CapturedBlackPiecesTags[4];
                    CapturedBlackPiece5.Tag = CapturedBlackPiecesTags[5];
                    CapturedBlackPiece6.Tag = CapturedBlackPiecesTags[6];
                    CapturedBlackPiece7.Tag = CapturedBlackPiecesTags[7];
                    CapturedBlackPiece8.Tag = CapturedBlackPiecesTags[8];
                    CapturedBlackPiece9.Tag = CapturedBlackPiecesTags[9];
                    CapturedBlackPiece10.Tag = CapturedBlackPiecesTags[10];
                    CapturedBlackPiece11.Tag = CapturedBlackPiecesTags[11];
                    CapturedBlackPiece12.Tag = CapturedBlackPiecesTags[12];
                    CapturedBlackPiece13.Tag = CapturedBlackPiecesTags[13];
                    CapturedBlackPiece14.Tag = CapturedBlackPiecesTags[14];
                }
            }





            square.Tag = piece;

        }

        private void InvalidMove()
        {
            ResetColorOfSquare(square1);
            square1 = null;
            square1Clicked = false;
            selectedPiece = null;
        }

        private int DoesMoveResultInCheck(string piece, bool ShowRedSquares, bool DetermineIfCheckmate)
        {
            int piecesThatCanKillKing = 0;

            int KingRow = 0;
            int KingCol = 0;

            string enemy_pawn = "";
            string enemy_rook = "";
            string enemy_knight = "";
            string enemy_bishop = "";
            string enemy_queen = "";
            string enemy_king = "";


            Control PawnCheck1 = new Control();
            Control PawnCheck2 = new Control();

            if (piece == "white")
            {
                //Get position of white king
                KingRow = tableLayoutPanel1.GetRow(whiteKing);
                KingCol = tableLayoutPanel1.GetColumn(whiteKing);

                PawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                PawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);

                enemy_pawn = "black_pawn";
                enemy_rook = "black_rook";
                enemy_knight = "black_knight";
                enemy_bishop = "black_bishop";
                enemy_queen = "black_queen";
                enemy_king = "black_king";
            }

            else if (piece == "black")
            {
                //Get position of black king
                KingRow = tableLayoutPanel1.GetRow(blackKing);
                KingCol = tableLayoutPanel1.GetColumn(blackKing);

                PawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                PawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);

                enemy_pawn = "white_pawn";
                enemy_rook = "white_rook";
                enemy_knight = "white_knight";
                enemy_bishop = "white_bishop";
                enemy_queen = "white_queen";
                enemy_king = "white_king";
            }

            /////////////////////////////////////
            //CHECK IF A PAWN CAN KILL KING

            if (PawnCheck1.Tag.ToString() == enemy_pawn & PawnCheck2.Tag.ToString() != enemy_pawn)
            {
                piecesThatCanKillKing++;
                if (ShowRedSquares == true)
                {
                    PawnCheck1.BackColor = Color.Red;
                }
            }
            else if (PawnCheck1.Tag.ToString() != enemy_pawn & PawnCheck2.Tag.ToString() == enemy_pawn)
            {
                piecesThatCanKillKing++;
                if (ShowRedSquares == true)
                {
                    PawnCheck2.BackColor = Color.Red;
                }
            }
            if (PawnCheck1.Tag.ToString() == enemy_pawn & PawnCheck2.Tag.ToString() == enemy_pawn)
            {
                piecesThatCanKillKing++;
                piecesThatCanKillKing++;
                if (ShowRedSquares == true)
                {
                    PawnCheck1.BackColor = Color.Red;
                    PawnCheck2.BackColor = Color.Red;
                }
            }

            //////////////////////////////////////////////
            //CHECK IF A ROOK OR QUEEN CAN KILL KING

            Control HorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
            Control HorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
            Control HorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
            Control HorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);

            //Determine if king is in check - horizontal left (enemy rook or queen)
            int y = tableLayoutPanel1.GetRow(HorizontalCheck1);
            for (int x = tableLayoutPanel1.GetColumn(HorizontalCheck1); x >= 1; x--)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not enemy rook or enemy queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is enemy rook or enemy queen
                {

                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                    }
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    continue;
                }
            }

            //Determine if king is in check - horizontal right (enemy rook or queen)
            y = tableLayoutPanel1.GetRow(HorizontalCheck3);
            for (int x = tableLayoutPanel1.GetColumn(HorizontalCheck3); x <= 10; x++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not enemy rook or enemy queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is enemy rook or enemy queen
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                    }
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    continue;
                }
            }

            //Determine if white king is in check - vertical up (enemy rook or queen)
            y = tableLayoutPanel1.GetColumn(HorizontalCheck2);
            for (int x = tableLayoutPanel1.GetRow(HorizontalCheck2); x >= 2; x--)
            {
                if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_queen)
                //Square is piece that is not enemy rook or enemy queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_queen)
                //Square is enemy rook or enemy queen
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Red;
                    }
                }
                else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                //Square is empty
                {
                    continue;
                }
            }

            //Determine if king is in check - vertical down (enemy rook or queen)
            y = tableLayoutPanel1.GetColumn(HorizontalCheck4);
            for (int x = tableLayoutPanel1.GetRow(HorizontalCheck4); x <= 10; x++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_queen)
                //Square is piece that is not enemy rook or enemy queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_queen)
                //Square is enemy rook or enemy queen
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Red;
                    }
                }
                else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                //Square is empty
                {
                    continue;
                }
            }

            ///////////////////////////////////////
            //CHECK IF A KNIGHT CAN KILL KING

            Control KnightCheck1 = new Control();
            Control KnightCheck2 = new Control();
            Control KnightCheck3 = new Control();
            Control KnightCheck4 = new Control();
            Control KnightCheck5 = new Control();
            Control KnightCheck6 = new Control();
            Control KnightCheck7 = new Control();
            Control KnightCheck8 = new Control();

            Control[] KnightChecks = { KnightCheck1, KnightCheck2, KnightCheck3, KnightCheck4, KnightCheck5, KnightCheck6, KnightCheck7, KnightCheck8 };

            KnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
            KnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
            KnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
            KnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
            KnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
            KnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
            KnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
            KnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);

            foreach (Control x in KnightChecks)
            {
                if (x.Tag.ToString() == enemy_knight)
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        x.BackColor = Color.Red;
                    }
                }
            }

            ////////////////////////////////////////////////
            //CHECK IF A BISHOP OR QUEEN CAN KILL KING

            Control DiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
            Control DiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
            Control DiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
            Control DiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);

            //Determine if  king is in check - diagonal up/left (bishop or queen)
            y = tableLayoutPanel1.GetRow(DiagonalCheck1);
            for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck1); x > 1 & y > 1; x--, y--)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                //Square is outside board
                {
                    tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Orange; //DEBUG
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not  bishop or  queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is  bishop or  queen
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                    }
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    continue;
                }
            }

            //Determine if  king is in check - diagonal up/right (bishop or queen)
            y = tableLayoutPanel1.GetRow(DiagonalCheck2);
            for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck2); x < 11 & y > 1; x++, y--)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                //Square is outside board
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not  bishop or  queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is  bishop or  queen
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                    }
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    continue;
                }
            }

            //Determine if  king is in check - diagonal down/right (bishop or queen)
            y = tableLayoutPanel1.GetRow(DiagonalCheck3);
            for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck3); x < 11 & y < 11; x++, y++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                //Square is outside board
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not  bishop or  queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is  bishop or  queen
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                    }
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    continue;
                }
            }

            //Determine if  king is in check - diagonal down/left (bishop or queen)
            y = tableLayoutPanel1.GetRow(DiagonalCheck4);
            for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck4); x > 1 & y < 11; x--, y++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                //Square is outside board
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not  bishop or  queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is  bishop or  queen
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                    }
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    continue;
                }
            }

            if (DetermineIfCheckmate == false)
            {
                /////////////////////////////////////////
                //CHECK IF KING CAN KILL KING

                Control KingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                Control KingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                Control KingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                Control KingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                Control KingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                Control KingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                Control KingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                Control KingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);

                //Determine if king is in check by king

                if (KingCheck1.Tag.ToString() == enemy_king)
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        KingCheck1.BackColor = Color.Red;
                    }
                }

                if (KingCheck2.Tag.ToString() == enemy_king)
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        KingCheck2.BackColor = Color.Red;
                    }
                }

                if (KingCheck3.Tag.ToString() == enemy_king)
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        KingCheck3.BackColor = Color.Red;
                    }
                }

                if (KingCheck4.Tag.ToString() == enemy_king)
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        KingCheck4.BackColor = Color.Red;
                    }
                }

                if (KingCheck5.Tag.ToString() == enemy_king)
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        KingCheck5.BackColor = Color.Red;
                    }
                }

                if (KingCheck6.Tag.ToString() == enemy_king)
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        KingCheck6.BackColor = Color.Red;
                    }
                }

                if (KingCheck7.Tag.ToString() == enemy_king)
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        KingCheck7.BackColor = Color.Red;
                    }
                }

                if (KingCheck8.Tag.ToString() == enemy_king)
                {
                    piecesThatCanKillKing++;
                    if (ShowRedSquares == true)
                    {
                        KingCheck8.BackColor = Color.Red;
                    }
                }
            }

            return piecesThatCanKillKing;
        }

        private bool DoesMoveResultInCheckmate(string piece)
        {
            if (piece.Contains("black")) //Is Black in Checkmate?
            {
                //Get position of black king
                int KingRowTemp = tableLayoutPanel1.GetRow(blackKing);
                int KingColTemp = tableLayoutPanel1.GetColumn(blackKing);

                Control KingPos0 = new Control();
                Control KingPos1 = new Control();
                Control KingPos2 = new Control();
                Control KingPos3 = new Control();
                Control KingPos4 = new Control();
                Control KingPos5 = new Control();
                Control KingPos6 = new Control();
                Control KingPos7 = new Control();

                Control[] KingPos = { KingPos0, KingPos1, KingPos2, KingPos3, KingPos4, KingPos5, KingPos6, KingPos7 };

                KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);

                //First, determine whether black king can move into a position that does not result in check
                blackKing.Tag = "empty";
                blackKing2 = blackKing; //Keep track of original position of black king
                foreach (PictureBox x in KingPos)
                {
                    if (x.Tag.ToString() == "empty")
                    {
                        blackKing = x;
                        if (DoesMoveResultInCheck("black", true, true) == 0 & tableLayoutPanel1.GetRow(blackKing) >= 3 & tableLayoutPanel1.GetRow(blackKing) <= 10 & tableLayoutPanel1.GetColumn(blackKing) >= 3 & tableLayoutPanel1.GetColumn(blackKing) <= 10) //Black king does have a possible move
                        {
                            //Black king can move out of Check
                            blackKing = blackKing2;
                            blackKing.Tag = "black_king";
                            return false;
                        }
                    }
                }
                blackKing = blackKing2;
                blackKing.Tag = "black_king";

                //If king cannot move, determine how many pieces are currently in a position to kill black king
                int CheckPieceQuantity = DoesMoveResultInCheck("black", true, false);

                //If only 1, determine if that piece can be killed by a piece other than the king
                if (CheckPieceQuantity == 1)
                {

                    //Get position of piece causing Check
                    string position = GetPositionOfPieceThatIsCausingCheck("black");

                    int pieceColumn = Int32.Parse(position.Substring(0, 2));
                    int pieceRow = Int32.Parse(position.Substring(2, 2));

                    whiteKing2 = whiteKing; //Save position of white king, which will be borrowed here
                    whiteKing = tableLayoutPanel1.GetControlFromPosition(pieceColumn, pieceRow) as PictureBox;

                    if (DoesMoveResultInCheck("black", true, true) > 0)
                    {
                        //Yes, that piece can be killed 
                        whiteKing = whiteKing2;
                        return false;
                    }
                    else //Checkmate - White wins
                    {
                        return true;
                    }
                }

                /*
                //Check if there are any empty pieces between black king and attacker
                if (pieceColumn == KingColTemp & pieceRow < KingRowTemp - 1)
                {
                    //Vertical up
                    whiteKing = whiteKing2; return false; //DEBUG
                }
                else if (pieceColumn == KingColTemp & pieceRow > KingRowTemp + 1)
                {
                    //Vertical down

                    MessageBox.Show("test"); //DEBUG

                    for (int x = KingRowTemp + 1; x < pieceRow; x++)
                    {
                        Control y = this.tableLayoutPanel1.GetControlFromPosition(KingColTemp, x) as PictureBox;
                        if (IsBlankSquareVulnerable("black", y) == true)
                        {
                            //Not checkmate
                            return false;
                        }
                    }

                    whiteKing = whiteKing2; return false; //DEBUG
                }
                else if (pieceRow == KingRowTemp & pieceColumn < KingColTemp - 1)
                {
                    //Horizontal left
                    whiteKing = whiteKing2; return false; //DEBUG
                }
                else if (pieceRow == KingRowTemp & pieceColumn > KingColTemp + 1)
                {
                    //Horizontal right
                    whiteKing = whiteKing2; return false; //DEBUG
                }
                else if (pieceColumn != KingColTemp & pieceRow != KingRowTemp)
                {
                    if (pieceRow < KingRowTemp - 1 & pieceColumn < KingColTemp - 1)
                    {
                        //Diagnonal up/left
                        whiteKing = whiteKing2; return false; //DEBUG
                    }
                    else if (pieceRow < KingRowTemp - 1 & pieceColumn > KingColTemp + 1)
                    {
                        //Diagnonal up/right
                        whiteKing = whiteKing2; return false; //DEBUG
                    }
                    else if (pieceRow > KingRowTemp + 1 & pieceColumn < KingColTemp - 1)
                    {
                        //Diagnonal down/left
                        whiteKing = whiteKing2; return false; //DEBUG
                    }
                    else if (pieceRow > KingRowTemp + 1 & pieceColumn > KingColTemp + 1)
                    {
                        //Diagnonal down/right
                        whiteKing = whiteKing2; return false; //DEBUG
                    }
                    return false; //Unreachable
                }

                */




                /*
                else
                {
                    return true;
                }
                */
            
                else if (CheckPieceQuantity > 1) //Checkmate - White wins
                {
                    return true;
                }
                else //This should be unreachable
                {
                    return false;
                }
            }
            else if (piece.Contains("white"))
            {
                //Get position of black king
                int KingRowTemp = tableLayoutPanel1.GetRow(whiteKing);
                int KingColTemp = tableLayoutPanel1.GetColumn(whiteKing);

                Control KingPos0 = new Control();
                Control KingPos1 = new Control();
                Control KingPos2 = new Control();
                Control KingPos3 = new Control();
                Control KingPos4 = new Control();
                Control KingPos5 = new Control();
                Control KingPos6 = new Control();
                Control KingPos7 = new Control();

                Control[] KingPos = { KingPos0, KingPos1, KingPos2, KingPos3, KingPos4, KingPos5, KingPos6, KingPos7 };

                KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);

                //First, determine whether black king can move into a position that does not result in check
                whiteKing.Tag = "empty";
                whiteKing2 = whiteKing; //Keep track of original position of black king
                foreach (PictureBox x in KingPos)
                {
                    if (x.Tag.ToString() == "empty")
                    {
                        whiteKing = x;
                        if (DoesMoveResultInCheck("white", true, true) == 0 & tableLayoutPanel1.GetRow(whiteKing) >= 3 & tableLayoutPanel1.GetRow(whiteKing) <= 10 & tableLayoutPanel1.GetColumn(whiteKing) >= 3 & tableLayoutPanel1.GetColumn(whiteKing) <= 10) //White king does have a possible move
                        {
                            //White king can move out of check
                            whiteKing = whiteKing2;
                            whiteKing.Tag = "white_king";
                            return false;
                        }
                    }
                }

                whiteKing = whiteKing2;
                whiteKing.Tag = "white_king";

                //If king cannot move, determine how many pieces are currently in a position to kill black king
                int CheckPieceQuantity = DoesMoveResultInCheck("white", true, false);
                MessageBox.Show(CheckPieceQuantity.ToString() + " piece(s) can kill king"); //DEBUG

                //If only 1, determine if that piece can be killed by a piece other than the king
                if (CheckPieceQuantity == 1)
                {

                    //Get position of piece causing Check
                    string position = GetPositionOfPieceThatIsCausingCheck("white");

                    int pieceColumn = Int32.Parse(position.Substring(0, 2));
                    int pieceRow = Int32.Parse(position.Substring(2, 2));

                    blackKing2 = blackKing; //Save position of white king, which will be borrowed here
                    blackKing= tableLayoutPanel1.GetControlFromPosition(pieceColumn, pieceRow) as PictureBox;

                    if (DoesMoveResultInCheck("white", true, true) > 0)
                    {
                        //Yes, that piece can be killed 
                        blackKing = blackKing2;
                        return false;
                    }
                    else //Checkmate - Black wins
                    {
                        return true;
                    }
                }
                else if (CheckPieceQuantity > 1) //Checkmate - Black wins
                {
                    return true;
                }
                else //This should be unreachable
                {
                    return false;
                }
            }
            else //This should be unreachable
            {
                return false;
            }
        }

        private string GetPositionOfPieceThatIsCausingCheck(string piece)
        //Similar to DoesMoveResultInCheck()
        //but returns position of first piece causing check
        //instead if the total number of pieces causing check
        {
            int KingRow = 0;
            int KingCol = 0;

            string enemy_pawn = "";
            string enemy_rook = "";
            string enemy_knight = "";
            string enemy_bishop = "";
            string enemy_queen = "";
            string enemy_king = "";

            string returnColumn = "";
            string returnRow = "";
            //string returnString = "";


            Control PawnCheck1 = new Control();
            Control PawnCheck2 = new Control();

            if (piece == "white")
            {
                //Get position of white king
                KingRow = tableLayoutPanel1.GetRow(whiteKing);
                KingCol = tableLayoutPanel1.GetColumn(whiteKing);

                //tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow).BackColor = Color.Green; //DEBUG

                PawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                PawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);

                enemy_pawn = "black_pawn";
                enemy_rook = "black_rook";
                enemy_knight = "black_knight";
                enemy_bishop = "black_bishop";
                enemy_queen = "black_queen";
                enemy_king = "black_king";
            }

            else if (piece == "black")
            {
                //Get position of black king
                KingRow = tableLayoutPanel1.GetRow(blackKing);
                KingCol = tableLayoutPanel1.GetColumn(blackKing);

                //tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow).BackColor = Color.Green; //DEBUG

                PawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                PawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);

                enemy_pawn = "white_pawn";
                enemy_rook = "white_rook";
                enemy_knight = "white_knight";
                enemy_bishop = "white_bishop";
                enemy_queen = "white_queen";
                enemy_king = "white_king";
            }

            /////////////////////////////////////
            //CHECK IF A PAWN CAN KILL KING

            if (PawnCheck1.Tag.ToString() == enemy_pawn & PawnCheck2.Tag.ToString() != enemy_pawn)
            {
                returnColumn = tableLayoutPanel1.GetColumn(PawnCheck1).ToString();
                returnRow = tableLayoutPanel1.GetRow(PawnCheck1).ToString();
                if (returnColumn.Length == 1)
                {
                    returnColumn = 0 + returnColumn;
                }
                if (returnRow.Length == 1)
                {
                    returnRow = 0 + returnRow;
                }
                return returnColumn + returnRow;
            }
            else if (PawnCheck1.Tag.ToString() != enemy_pawn & PawnCheck2.Tag.ToString() == enemy_pawn)
            {
                returnColumn = tableLayoutPanel1.GetColumn(PawnCheck2).ToString();
                returnRow = tableLayoutPanel1.GetRow(PawnCheck2).ToString();
                return returnColumn + returnRow;
            }

            //////////////////////////////////////////////
            //CHECK IF A ROOK OR QUEEN CAN KILL KING

            Control HorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
            Control HorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
            Control HorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
            Control HorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);


            //Determine if king is in check - horizontal left (enemy rook or queen)
            int y = tableLayoutPanel1.GetRow(HorizontalCheck1);
            for (int x = tableLayoutPanel1.GetColumn(HorizontalCheck1); x >= 1; x--)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not enemy rook or enemy queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is enemy rook or enemy queen
                {
                    returnColumn = x.ToString();
                    if (returnColumn.Length == 1)
                    {
                        returnColumn = 0 + returnColumn;
                    }
                    returnRow = y.ToString();
                    if (returnRow.Length == 1)
                    {
                        returnRow = 0 + returnRow;
                    }
                    return returnColumn + returnRow;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Orange;
                    continue;
                }
            }

            //Determine if king is in check - horizontal right (enemy rook or queen)
            y = tableLayoutPanel1.GetRow(HorizontalCheck3);
            for (int x = tableLayoutPanel1.GetColumn(HorizontalCheck3); x <= 10; x++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not enemy rook or enemy queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is enemy rook or enemy queen
                {
                    returnColumn = x.ToString();
                    returnRow = y.ToString();
                    if (returnColumn.Length == 1)
                    {
                        returnColumn = 0 + returnColumn;
                    }
                    if (returnRow.Length == 1)
                    {
                        returnRow = 0 + returnRow;
                    }
                    return returnColumn + returnRow;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    continue;
                }
            }

            //Determine if white king is in check - vertical up (enemy rook or queen)
            y = tableLayoutPanel1.GetColumn(HorizontalCheck2);
            for (int x = tableLayoutPanel1.GetRow(HorizontalCheck2); x >= 2; x--)
            {
                if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_queen)
                //Square is piece that is not enemy rook or enemy queen
                {
                    //tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Green;
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_queen)
                //Square is enemy rook or enemy queen
                {
                    returnColumn = y.ToString();
                    returnRow = x.ToString();
                    if (returnColumn.Length == 1)
                    {
                        returnColumn = 0 + returnColumn;
                    }
                    if (returnRow.Length == 1)
                    {
                        returnRow = 0 + returnRow;
                    }
                    return returnColumn + returnRow;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                //Square is empty
                {
                    //tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Orange;
                    continue;
                }
            }


            //Determine if king is in check - vertical down (enemy rook or queen)
            y = tableLayoutPanel1.GetColumn(HorizontalCheck4);
            for (int x = tableLayoutPanel1.GetRow(HorizontalCheck4); x <= 10; x++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_queen)
                //Square is piece that is not enemy rook or enemy queen
                {
                    //tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Green;
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_queen)
                //Square is enemy rook or enemy queen
                {
                    returnColumn = y.ToString();
                    returnRow = x.ToString();
                    if (returnColumn.Length == 1)
                    {
                        returnColumn = 0 + returnColumn;
                    }
                    if (returnRow.Length == 1)
                    {
                        returnRow = 0 + returnRow;
                    }
                    return returnColumn + returnRow;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                //Square is empty
                {
                    //tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Orange;
                    continue;
                }
            }

            ///////////////////////////////////////
            //CHECK IF A KNIGHT CAN KILL KING

            Control KnightCheck1 = new Control();
            Control KnightCheck2 = new Control();
            Control KnightCheck3 = new Control();
            Control KnightCheck4 = new Control();
            Control KnightCheck5 = new Control();
            Control KnightCheck6 = new Control();
            Control KnightCheck7 = new Control();
            Control KnightCheck8 = new Control();

            Control[] KnightChecks = { KnightCheck1, KnightCheck2, KnightCheck3, KnightCheck4, KnightCheck5, KnightCheck6, KnightCheck7, KnightCheck8 };

            KnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
            KnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
            KnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
            KnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
            KnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
            KnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
            KnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
            KnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);

            foreach (Control x in KnightChecks)
            {
                if (x.Tag.ToString() == enemy_knight)
                {
                    returnColumn = tableLayoutPanel1.GetColumn(x).ToString();
                    returnRow = tableLayoutPanel1.GetRow(x).ToString();
                    if (returnColumn.Length == 1)
                    {
                        returnColumn = 0 + returnColumn;
                    }
                    if (returnRow.Length == 1)
                    {
                        returnRow = 0 + returnRow;
                    }
                    return returnColumn + returnRow;
                }
            }

            ////////////////////////////////////////////////
            //CHECK IF A BISHOP OR QUEEN CAN KILL KING

            Control DiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
            Control DiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
            Control DiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
            Control DiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);

            y = tableLayoutPanel1.GetRow(DiagonalCheck1);
            for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck1); x >= 0 & y >= 0; x--, y--)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                //Square is outside board
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not  bishop or  queen
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is  bishop or  queen
                {
                    returnColumn = x.ToString();
                    returnRow = y.ToString();
                    if (returnColumn.Length == 1)
                    {
                        returnColumn = 0 + returnColumn;
                    }
                    if (returnRow.Length == 1)
                    {
                        returnRow = 0 + returnRow;
                    }
                    return returnColumn + returnRow;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                    continue;
                }
            }

            //Determine if  king is in check - diagonal up/right (bishop or queen)
            y = tableLayoutPanel1.GetRow(DiagonalCheck2);
            for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck2); x <= 10; x++, y--)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                //Square is outside board
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not  bishop or  queen
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is  bishop or  queen
                {
                    returnColumn = x.ToString();
                    returnRow = y.ToString();
                    if (returnColumn.Length == 1)
                    {
                        returnColumn = 0 + returnColumn;
                    }
                    if (returnRow.Length == 1)
                    {
                        returnRow = 0 + returnRow;
                    }
                    return returnColumn + returnRow;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                    continue;
                }
            }

            //Determine if  king is in check - diagonal down/right (bishop or queen)
            y = tableLayoutPanel1.GetRow(DiagonalCheck3);
            for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck3); x <= 12; x++, y++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                //Square is outside board
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not  bishop or  queen
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is  bishop or  queen
                {
                    returnColumn = x.ToString();
                    returnRow = y.ToString();
                    if (returnColumn.Length == 1)
                    {
                        returnColumn = 0 + returnColumn;
                    }
                    if (returnRow.Length == 1)
                    {
                        returnRow = 0 + returnRow;
                    }
                    return returnColumn + returnRow;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                    continue;
                }
            }

            //Determine if  king is in check - diagonal down/left (bishop or queen)
            y = tableLayoutPanel1.GetRow(DiagonalCheck4);
            for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck4); x >= 2; x--, y++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                //Square is outside board
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not  bishop or  queen
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is  bishop or  queen
                {
                    returnColumn = x.ToString();
                    returnRow = y.ToString();
                    if (returnColumn.Length == 1)
                    {
                        returnColumn = 0 + returnColumn;
                    }
                    if (returnRow.Length == 1)
                    {
                        returnRow = 0 + returnRow;
                    }
                    return returnColumn + returnRow;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                    continue;
                }
            }

            /////////////////////////////////////////
            //CHECK IF KING CAN KILL KING

            Control KingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
            Control KingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
            Control KingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
            Control KingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
            Control KingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
            Control KingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
            Control KingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
            Control KingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);

            //Determine if  king is in check by  king

            if (KingCheck1.Tag.ToString() == enemy_king)
            {
                returnColumn = KingCheck1.ToString();
                returnRow = KingCheck1.ToString();
                if (returnColumn.Length == 1)
                {
                    returnColumn = 0 + returnColumn;
                }
                if (returnRow.Length == 1)
                {
                    returnRow = 0 + returnRow;
                }
                return returnColumn + returnRow;
            }

            if (KingCheck2.Tag.ToString() == enemy_king)
            {
                returnColumn = KingCheck2.ToString();
                returnRow = KingCheck2.ToString();
                if (returnColumn.Length == 1)
                {
                    returnColumn = 0 + returnColumn;
                }
                if (returnRow.Length == 1)
                {
                    returnRow = 0 + returnRow;
                }
                return returnColumn + returnRow;
            }

            if (KingCheck3.Tag.ToString() == enemy_king)
            {
                returnColumn = KingCheck3.ToString();
                returnRow = KingCheck3.ToString();
                if (returnColumn.Length == 1)
                {
                    returnColumn = 0 + returnColumn;
                }
                if (returnRow.Length == 1)
                {
                    returnRow = 0 + returnRow;
                }
                return returnColumn + returnRow;
            }

            if (KingCheck4.Tag.ToString() == enemy_king)
            {
                returnColumn = KingCheck4.ToString();
                returnRow = KingCheck4.ToString();
                if (returnColumn.Length == 1)
                {
                    returnColumn = 0 + returnColumn;
                }
                if (returnRow.Length == 1)
                {
                    returnRow = 0 + returnRow;
                }
                return returnColumn + returnRow;
            }

            if (KingCheck5.Tag.ToString() == enemy_king)
            {
                returnColumn = KingCheck5.ToString();
                returnRow = KingCheck5.ToString();
                if (returnColumn.Length == 1)
                {
                    returnColumn = 0 + returnColumn;
                }
                if (returnRow.Length == 1)
                {
                    returnRow = 0 + returnRow;
                }
                return returnColumn + returnRow;
            }

            if (KingCheck6.Tag.ToString() == enemy_king)
            {
                returnColumn = KingCheck6.ToString();
                returnRow = KingCheck6.ToString();
                if (returnColumn.Length == 1)
                {
                    returnColumn = 0 + returnColumn;
                }
                if (returnRow.Length == 1)
                {
                    returnRow = 0 + returnRow;
                }
                return returnColumn + returnRow;
            }

            if (KingCheck7.Tag.ToString() == enemy_king)
            {
                returnColumn = KingCheck7.ToString();
                returnRow = KingCheck6.ToString();
                if (returnColumn.Length == 1)
                {
                    returnColumn = 0 + returnColumn;
                }
                if (returnRow.Length == 1)
                {
                    returnRow = 0 + returnRow;
                }
                return returnColumn + returnRow;
            }

            if (KingCheck8.Tag.ToString() == enemy_king)
            {
                returnColumn = KingCheck8.ToString();
                returnRow = KingCheck8.ToString();
                if (returnColumn.Length == 1)
                {
                    returnColumn = 0 + returnColumn;
                }
                if (returnRow.Length == 1)
                {
                    returnRow = 0 + returnRow;
                }
                return returnColumn + returnRow;
            }

            return null;
        }

        private bool IsCastlePossible(string position)
        {
            if (position == "1") //Black castle left
            {
                if (IsCastle1Possible == true)
                {
                    return true; //DEBUG
                }
                else
                {
                    return false;
                }
            }
            else if (position == "2") //Black castle right
            {
                if (IsCastle2Possible == true)
                {
                    return true; //DEBUG
                }
                else
                {
                    return false;
                }
            }
            else if (position == "3") //White castle left
            {
                if (IsCastle3Possible == true)
                {
                    //Check whether king is in check in current position
                    if (DoesMoveResultInCheck("white", false, false) > 0)
                    {
                        return false;
                    }
                    //Check whether path is clear
                    if (pictureBox60.Tag.ToString() != "empty")
                    {
                        return false;
                    }
                    if (pictureBox59.Tag.ToString() != "empty")
                    {
                        return false;
                    }
                    //Check whether any square in path would result in check, including target square
                    whiteKing2 = whiteKing;
                    whiteKing = pictureBox60;
                    if (DoesMoveResultInCheck("white", false, false) > 0)
                    {
                        whiteKing = whiteKing2;
                        return false;
                    }
                    whiteKing = pictureBox59;
                    if (DoesMoveResultInCheck("white", false, false) > 0)
                    {
                        whiteKing = whiteKing2;
                        return false;
                    }
                    whiteKing = whiteKing2;
                    return true; //Castle is possible
                }
                else
                {
                    return false;
                }
            }
            else if (position == "4") //White castle right
            {
                if (IsCastle4Possible == true)
                {
                    //Check whether king is in check in current position
                    if (DoesMoveResultInCheck("white", false, false) > 0)
                    {
                        return false;
                    }
                    //Check whether path is clear
                    if (pictureBox62.Tag.ToString() != "empty")
                    {
                        return false;
                    }
                    if (pictureBox63.Tag.ToString() != "empty")
                    {
                        return false;
                    }
                    //Check whether any square in path would result in check, including target square
                    whiteKing2 = whiteKing;
                    whiteKing = pictureBox62;
                    if (DoesMoveResultInCheck("white", false, false) > 0)
                    {
                        whiteKing = whiteKing2;
                        return false;
                    }
                    whiteKing = pictureBox63;
                    if (DoesMoveResultInCheck("white", false, false) > 0)
                    {
                        whiteKing = whiteKing2;
                        return false;
                    }
                    whiteKing = whiteKing2;
                    return true; //Castle is possible
                }
                else
                {
                    return false;
                }
            }
            else //Should be unreachable
            {
                return false;
            }
        }

        private void ReviveWhitePiece(object sender, EventArgs e)
        {
            PictureBox RevivedPiece = (PictureBox)sender;
            if (RevivePieceStatus == true & RevivedPiece.Tag != null)
            {
                square.Tag = RevivedPiece.Tag.ToString();
                square.Image = RevivedPiece.BackgroundImage;
                status.Text = "Black's move";
                RevivePieceStatus = false;
            }
        }

        private void ReviveBlackPiece(object sender, EventArgs e)
        {
            PictureBox RevivedPiece = (PictureBox)sender;
            if (RevivePieceStatus == true & RevivedPiece.Tag != null)
            {
                square.Tag = RevivedPiece.Tag.ToString();
                square.Image = RevivedPiece.BackgroundImage;
                status.Text = "White's move";
                RevivePieceStatus = false;
            }
        }

        /*
        private bool IsBlankSquareVulnerable(string piece, Control SquareToCheck)
        {
            {
                string enemy_pawn = "";
                string enemy_rook = "";
                string enemy_knight = "";
                string enemy_bishop = "";
                string enemy_queen = "";

                Control PawnCheck = new Control();

                int KingRow = tableLayoutPanel1.GetRow(SquareToCheck);
                int KingCol = tableLayoutPanel1.GetColumn(SquareToCheck);

                if (piece == "white")
                {
                    PawnCheck = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);

                    enemy_pawn = "black_pawn";
                    enemy_rook = "black_rook";
                    enemy_knight = "black_knight";
                    enemy_bishop = "black_bishop";
                    enemy_queen = "black_queen";
                }

                else if (piece == "black")
                {
                    PawnCheck = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);

                    enemy_pawn = "white_pawn";
                    enemy_rook = "white_rook";
                    enemy_knight = "white_knight";
                    enemy_bishop = "white_bishop";
                    enemy_queen = "white_queen";
                }

                /////////////////////////////////////
                //CHECK IF A PAWN CAN KILL KING

                if (PawnCheck.Tag.ToString() == enemy_pawn)
                {
                    return true;
                }

                //////////////////////////////////////////////
                //CHECK IF A ROOK OR QUEEN CAN KILL KING

                Control HorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                Control HorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                Control HorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                Control HorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);


                //Determine if king is in check - horizontal left (enemy rook or queen)
                int y = tableLayoutPanel1.GetRow(HorizontalCheck1);
                for (int x = tableLayoutPanel1.GetColumn(HorizontalCheck1); x >= 1; x--)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                    //Square is piece that is not enemy rook or enemy queen
                    {
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                    //Square is enemy rook or enemy queen
                    {
                        return true;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                    //Square is empty
                    {
                        //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Orange;
                        continue;
                    }
                }

                //Determine if king is in check - horizontal right (enemy rook or queen)
                y = tableLayoutPanel1.GetRow(HorizontalCheck3);
                for (int x = tableLayoutPanel1.GetColumn(HorizontalCheck3); x <= 10; x++)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                    //Square is piece that is not enemy rook or enemy queen
                    {
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                    //Square is enemy rook or enemy queen
                    {
                        return true;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                    //Square is empty
                    {
                        continue;
                    }
                }

                //Determine if white king is in check - vertical up (enemy rook or queen)
                y = tableLayoutPanel1.GetColumn(HorizontalCheck2);
                for (int x = tableLayoutPanel1.GetRow(HorizontalCheck2); x >= 2; x--)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_queen)
                    //Square is piece that is not enemy rook or enemy queen
                    {
                        //tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Green;
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_queen)
                    //Square is enemy rook or enemy queen
                    {
                        return true;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                    //Square is empty
                    {
                        //tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Orange;
                        continue;
                    }
                }


                //Determine if king is in check - vertical down (enemy rook or queen)
                y = tableLayoutPanel1.GetColumn(HorizontalCheck4);
                for (int x = tableLayoutPanel1.GetRow(HorizontalCheck4); x <= 10; x++)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_queen)
                    //Square is piece that is not enemy rook or enemy queen
                    {
                        //tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Green;
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_queen)
                    //Square is enemy rook or enemy queen
                    {
                        return true;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                    //Square is empty
                    {
                        //tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Orange;
                        continue;
                    }
                }

                ///////////////////////////////////////
                //CHECK IF A KNIGHT CAN KILL KING

                Control KnightCheck1 = new Control();
                Control KnightCheck2 = new Control();
                Control KnightCheck3 = new Control();
                Control KnightCheck4 = new Control();
                Control KnightCheck5 = new Control();
                Control KnightCheck6 = new Control();
                Control KnightCheck7 = new Control();
                Control KnightCheck8 = new Control();

                Control[] KnightChecks = { KnightCheck1, KnightCheck2, KnightCheck3, KnightCheck4, KnightCheck5, KnightCheck6, KnightCheck7, KnightCheck8 };

                KnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                KnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                KnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                KnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                KnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                KnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                KnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                KnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);

                foreach (Control x in KnightChecks)
                {
                    if (x.Tag.ToString() == enemy_knight)
                    {
                        return true;
                    }
                }

                ////////////////////////////////////////////////
                //CHECK IF A BISHOP OR QUEEN CAN KILL KING

                Control DiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                Control DiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                Control DiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                Control DiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);

                y = tableLayoutPanel1.GetRow(DiagonalCheck1);
                for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck1); x >= 0 & y >= 0; x--, y--)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                    //Square is outside board
                    {
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                    //Square is piece that is not  bishop or  queen
                    {
                        //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                    //Square is  bishop or  queen
                    {
                        return true;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                    //Square is empty
                    {
                        //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                        continue;
                    }
                }

                //Determine if  king is in check - diagonal up/right (bishop or queen)
                y = tableLayoutPanel1.GetRow(DiagonalCheck2);
                for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck2); x <= 10; x++, y--)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                    //Square is outside board
                    {
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                    //Square is piece that is not  bishop or  queen
                    {
                        //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                    //Square is  bishop or  queen
                    {
                        return true;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                    //Square is empty
                    {
                        //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                        continue;
                    }
                }

                //Determine if  king is in check - diagonal down/right (bishop or queen)
                y = tableLayoutPanel1.GetRow(DiagonalCheck3);
                for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck3); x <= 12; x++, y++)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                    //Square is outside board
                    {
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                    //Square is piece that is not  bishop or  queen
                    {
                        //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                    //Square is  bishop or  queen
                    {
                        return true;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                    //Square is empty
                    {
                        //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                        continue;
                    }
                }

                //Determine if  king is in check - diagonal down/left (bishop or queen)
                y = tableLayoutPanel1.GetRow(DiagonalCheck4);
                for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck4); x >= 2; x--, y++)
                {
                    if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                    //Square is outside board
                    {
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_bishop & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                    //Square is piece that is not  bishop or  queen
                    {
                        //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                        break;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_bishop | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                    //Square is  bishop or  queen
                    {
                        return true;
                    }
                    else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                    //Square is empty
                    {
                        //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                        continue;
                    }
                }


                return true; //unreachable
            }
        }
        */
    }
}
 