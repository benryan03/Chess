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
        string selectedPiece = null;
        int turn = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void ValidMove(string piece)
        {
            ResetColorOfSquare(square1);
            square1.Image = null;
            square1.Tag = "empty";
            square1 = null;
            square1Clicked = false;
            selectedPiece = null;
            square.Tag = piece;
            turn++;

            //I still need to find a way to simplify this
            if (piece == "white_pawn")
            {
                square.Image = Properties.Resources.white_pawn;
                status.Text = "Black's move";
            }
            else if (piece == "black_pawn")
            {
                square.Image = Properties.Resources.black_pawn;
                status.Text = "White's move";
            }
            else if (piece == "white_rook")
            {
                square.Image = Properties.Resources.white_rook;
                status.Text = "Black's move";
            }
            else if (piece == "black_rook")
            {
                square.Image = Properties.Resources.black_rook;
                status.Text = "White's move";
            }
            else if (piece == "white_knight")
            {
                square.Image = Properties.Resources.white_knight;
                status.Text = "Black's move";
            }
            else if (piece == "black_knight")
            {
                square.Image = Properties.Resources.black_knight;
                status.Text = "White's move";
            }
            else if (piece == "white_bishop")
            {
                square.Image = Properties.Resources.white_bishop;
                status.Text = "Black's move";
            }
            else if (piece == "black_bishop")
            {
                square.Image = Properties.Resources.black_bishop;
                status.Text = "White's move";
            }
            else if (piece == "white_queen")
            {
                square.Image = Properties.Resources.white_queen;
                status.Text = "Black's move";
            }
            else if (piece == "black_queen")
            {
                square.Image = Properties.Resources.black_queen;
                status.Text = "White's move";
            }
            else if (piece == "white_king")
            {
                square.Image = Properties.Resources.white_king;
                status.Text = "Black's move";
            }
            else if (piece == "black_king")
            {
                square.Image = Properties.Resources.black_king;
                status.Text = "White's move";
            }
        }

        private void InvalidMove()
        {
            ResetColorOfSquare(square1);
            square1 = null;
            square1Clicked = false;
            selectedPiece = null;
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
                                if ((this.tableLayoutPanel1.GetRow(square1) - 1) == this.tableLayoutPanel1.GetRow(square))  //Original row, and not same column, and "1 up"
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