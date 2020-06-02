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
        string selectedPiece = null;

        public Form1()
        {
            InitializeComponent();
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
            PictureBox square = (PictureBox)sender;

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
                                        //Valid move
                                        //MessageBox.Show("valid move1"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.white_pawn;
                                        square.Tag = "white_pawn";
                                    }
                                    else
                                    {
                                        //Invalid move
                                        ResetColorOfSquare(square1);
                                        square1 = null;
                                        square1Clicked = false;
                                        //MessageBox.Show("invalid move1"); //DEBUG
                                        selectedPiece = null;
                                    }
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move2"); //DEBUG
                                    selectedPiece = null;
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
                                            //Valid move
                                            //MessageBox.Show("valid move2"); //DEBUG
                                            ResetColorOfSquare(square1);
                                            square1.Image = null;
                                            square1.Tag = "empty";
                                            square1 = null;
                                            square1Clicked = false;
                                            selectedPiece = null;
                                            square.Image = global::Chess.Properties.Resources.white_pawn;
                                            square.Tag = "white_pawn";
                                        }
                                        else
                                        {
                                            //Invalid move
                                            ResetColorOfSquare(square1);
                                            square1 = null;
                                            square1Clicked = false;
                                            //MessageBox.Show("invalid move3"); //DEBUG
                                            selectedPiece = null;
                                        }
                                    }
                                    else
                                    {
                                        //Invalid move
                                        ResetColorOfSquare(square1);
                                        square1 = null;
                                        square1Clicked = false;
                                        //MessageBox.Show("invalid move4"); //DEBUG
                                        selectedPiece = null;
                                    }
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move5"); //DEBUG
                                    selectedPiece = null;
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
                                        //Valid move
                                        //MessageBox.Show("valid move3"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.white_pawn;
                                        square.Tag = "white_pawn";
                                    }
                                    else
                                    {
                                        //Invalid move
                                        ResetColorOfSquare(square1);
                                        square1 = null;
                                        square1Clicked = false;
                                        //MessageBox.Show("invalid move6"); //DEBUG
                                        selectedPiece = null;
                                    }
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move7"); //DEBUG
                                    selectedPiece = null;
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
                                            //Valid move
                                            //MessageBox.Show("valid move4"); //DEBUG
                                            ResetColorOfSquare(square1);
                                            square1.Image = null;
                                            square1.Tag = "empty";
                                            square1 = null;
                                            square1Clicked = false;
                                            selectedPiece = null;
                                            square.Image = global::Chess.Properties.Resources.white_pawn;
                                            square.Tag = "white_pawn";
                                        }
                                        else
                                        {
                                            //Invalid move
                                            ResetColorOfSquare(square1);
                                            square1 = null;
                                            square1Clicked = false;
                                            //MessageBox.Show("invalid move8"); //DEBUG
                                            selectedPiece = null;
                                        }
                                    }
                                    else
                                    {
                                        //Invalid move
                                        ResetColorOfSquare(square1);
                                        square1 = null;
                                        square1Clicked = false;
                                        //MessageBox.Show("invalid move9"); //DEBUG
                                        selectedPiece = null;
                                    }
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move10"); //DEBUG
                                    selectedPiece = null;
                                }
                            }
                        }
                    }
                    else
                    {
                        //Invalid move
                        ResetColorOfSquare(square1);
                        square1 = null;
                        square1Clicked = false;
                        //MessageBox.Show("invalid move1"); //DEBUG
                        selectedPiece = null;
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
                                        //Valid move
                                        //MessageBox.Show("valid move1"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.black_pawn;
                                        square.Tag = "black_pawn";
                                    }
                                    else
                                    {
                                        //Invalid move
                                        ResetColorOfSquare(square1);
                                        square1 = null;
                                        square1Clicked = false;
                                        //MessageBox.Show("invalid move1"); //DEBUG
                                        selectedPiece = null;
                                    }
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move2"); //DEBUG
                                    selectedPiece = null;
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
                                            //Valid move
                                            //MessageBox.Show("valid move2"); //DEBUG
                                            ResetColorOfSquare(square1);
                                            square1.Image = null;
                                            square1.Tag = "empty";
                                            square1 = null;
                                            square1Clicked = false;
                                            selectedPiece = null;
                                            square.Image = global::Chess.Properties.Resources.black_pawn;
                                            square.Tag = "black_pawn";
                                        }
                                        else
                                        {
                                            //Invalid move
                                            ResetColorOfSquare(square1);
                                            square1 = null;
                                            square1Clicked = false;
                                            //MessageBox.Show("invalid move3"); //DEBUG
                                            selectedPiece = null;
                                        }
                                    }
                                    else
                                    {
                                        //Invalid move
                                        ResetColorOfSquare(square1);
                                        square1 = null;
                                        square1Clicked = false;
                                        //MessageBox.Show("invalid move4"); //DEBUG
                                        selectedPiece = null;
                                    }
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move5"); //DEBUG
                                    selectedPiece = null;
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
                                        //Valid move
                                        //MessageBox.Show("valid move3"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.black_pawn;
                                        square.Tag = "black_pawn";
                                    }
                                    else
                                    {
                                        //Invalid move
                                        ResetColorOfSquare(square1);
                                        square1 = null;
                                        square1Clicked = false;
                                        //MessageBox.Show("invalid move6"); //DEBUG
                                        selectedPiece = null;
                                    }
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move7"); //DEBUG
                                    selectedPiece = null;
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
                                            //Valid move
                                            //MessageBox.Show("valid move4"); //DEBUG
                                            ResetColorOfSquare(square1);
                                            square1.Image = null;
                                            square1.Tag = "empty";
                                            square1 = null;
                                            square1Clicked = false;
                                            selectedPiece = null;
                                            square.Image = global::Chess.Properties.Resources.black_pawn;
                                            square.Tag = "black_pawn";
                                        }
                                        else
                                        {
                                            //Invalid move
                                            ResetColorOfSquare(square1);
                                            square1 = null;
                                            square1Clicked = false;
                                            //MessageBox.Show("invalid move8"); //DEBUG
                                            selectedPiece = null;
                                        }
                                    }
                                    else
                                    {
                                        //Invalid move
                                        ResetColorOfSquare(square1);
                                        square1 = null;
                                        square1Clicked = false;
                                        //MessageBox.Show("invalid move9"); //DEBUG
                                        selectedPiece = null;
                                    }
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move10"); //DEBUG
                                    selectedPiece = null;
                                }
                            }
                        }
                    }
                    else
                    {
                        //Invalid move
                        ResetColorOfSquare(square1);
                        square1 = null;
                        square1Clicked = false;
                        //MessageBox.Show("invalid move1"); //DEBUG
                        selectedPiece = null;
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
                                    //Valid move
                                    //MessageBox.Show("valid move1"); //DEBUG
                                    ResetColorOfSquare(square1);
                                    square1.Image = null;
                                    square1.Tag = "empty";
                                    square1 = null;
                                    square1Clicked = false;
                                    selectedPiece = null;
                                    square.Image = global::Chess.Properties.Resources.white_rook;
                                    square.Tag = "white_rook";
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move1"); //DEBUG
                                    selectedPiece = null;
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
                                    //Valid move
                                    //MessageBox.Show("valid move1"); //DEBUG
                                    ResetColorOfSquare(square1);
                                    square1.Image = null;
                                    square1.Tag = "empty";
                                    square1 = null;
                                    square1Clicked = false;
                                    selectedPiece = null;
                                    square.Image = global::Chess.Properties.Resources.white_rook;
                                    square.Tag = "white_rook";
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move1"); //DEBUG
                                    selectedPiece = null;
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
                                    //Valid move
                                    //MessageBox.Show("valid move1"); //DEBUG
                                    ResetColorOfSquare(square1);
                                    square1.Image = null;
                                    square1.Tag = "empty";
                                    square1 = null;
                                    square1Clicked = false;
                                    selectedPiece = null;
                                    square.Image = global::Chess.Properties.Resources.white_rook;
                                    square.Tag = "white_rook";
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move1"); //DEBUG
                                    selectedPiece = null;
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
                                    //Valid move
                                    //MessageBox.Show("valid move2"); //DEBUG
                                    ResetColorOfSquare(square1);
                                    square1.Image = null;
                                    square1.Tag = "empty";
                                    square1 = null;
                                    square1Clicked = false;
                                    selectedPiece = null;
                                    square.Image = global::Chess.Properties.Resources.white_rook;
                                    square.Tag = "white_rook";
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move2"); //DEBUG
                                    selectedPiece = null;
                                }
                            }
                        }
                        else
                        {
                            //Invalid move
                            ResetColorOfSquare(square1);
                            square1 = null;
                            square1Clicked = false;
                            //MessageBox.Show("invalid move3"); //DEBUG
                            selectedPiece = null;
                        }
                    }
                    else
                    {
                        //Invalid move
                        ResetColorOfSquare(square1);
                        square1 = null;
                        square1Clicked = false;
                        //MessageBox.Show("invalid move4"); //DEBUG
                        selectedPiece = null;
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
                                    //Valid move
                                    //MessageBox.Show("valid move1"); //DEBUG
                                    ResetColorOfSquare(square1);
                                    square1.Image = null;
                                    square1.Tag = "empty";
                                    square1 = null;
                                    square1Clicked = false;
                                    selectedPiece = null;
                                    square.Image = global::Chess.Properties.Resources.black_rook;
                                    square.Tag = "black_rook";
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move1"); //DEBUG
                                    selectedPiece = null;
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
                                    //Valid move
                                    //MessageBox.Show("valid move1"); //DEBUG
                                    ResetColorOfSquare(square1);
                                    square1.Image = null;
                                    square1.Tag = "empty";
                                    square1 = null;
                                    square1Clicked = false;
                                    selectedPiece = null;
                                    square.Image = global::Chess.Properties.Resources.black_rook;
                                    square.Tag = "black_rook";
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move1"); //DEBUG
                                    selectedPiece = null;
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
                                    //Valid move
                                    //MessageBox.Show("valid move1"); //DEBUG
                                    ResetColorOfSquare(square1);
                                    square1.Image = null;
                                    square1.Tag = "empty";
                                    square1 = null;
                                    square1Clicked = false;
                                    selectedPiece = null;
                                    square.Image = global::Chess.Properties.Resources.black_rook;
                                    square.Tag = "black_rook";
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move1"); //DEBUG
                                    selectedPiece = null;
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
                                    //Valid move
                                    //MessageBox.Show("valid move2"); //DEBUG
                                    ResetColorOfSquare(square1);
                                    square1.Image = null;
                                    square1.Tag = "empty";
                                    square1 = null;
                                    square1Clicked = false;
                                    selectedPiece = null;
                                    square.Image = global::Chess.Properties.Resources.black_rook;
                                    square.Tag = "black_rook";
                                }
                                else
                                {
                                    //Invalid move
                                    ResetColorOfSquare(square1);
                                    square1 = null;
                                    square1Clicked = false;
                                    //MessageBox.Show("invalid move2"); //DEBUG
                                    selectedPiece = null;
                                }
                            }
                        }
                        else
                        {
                            //Invalid move
                            ResetColorOfSquare(square1);
                            square1 = null;
                            square1Clicked = false;
                            //MessageBox.Show("invalid move3"); //DEBUG
                            selectedPiece = null;
                        }
                    }
                    else
                    {
                        //Invalid move
                        ResetColorOfSquare(square1);
                        square1 = null;
                        square1Clicked = false;
                        //MessageBox.Show("invalid move4"); //DEBUG
                        selectedPiece = null;
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
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.white_knight;
                                square.Tag = "white_knight";
                            }
                            else if (endRow == startRow - 1) //Vertical move up/left
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.white_knight;
                                square.Tag = "white_knight";
                            }
                            else
                            {
                                //Invalid move
                                ResetColorOfSquare(square1);
                                square1 = null;
                                square1Clicked = false;
                                //MessageBox.Show("invalid move1"); //DEBUG
                                selectedPiece = null;
                            }
                        }
                        else if (endColumn == startColumn + 2) //Vertical move down
                        {
                            if (endRow == startRow + 1) //Vertical move down/right
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.white_knight;
                                square.Tag = "white_knight";
                            }
                            else if (endRow == startRow - 1) //Vertical move down/left
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.white_knight;
                                square.Tag = "white_knight";
                            }
                            else
                            {
                                //Invalid move
                                ResetColorOfSquare(square1);
                                square1 = null;
                                square1Clicked = false;
                                //MessageBox.Show("invalid move2"); //DEBUG
                                selectedPiece = null;
                            }
                        }
                        else if (endRow == startRow - 2) //Horizontal move left
                        {
                            if (endColumn == startColumn - 1) //Horizontal move left/up
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.white_knight;
                                square.Tag = "white_knight";
                            }
                            else if (endColumn == startColumn + 1) //Horizontal move left/down
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.white_knight;
                                square.Tag = "white_knight";
                            }
                            else
                            {
                                //Invalid move
                                ResetColorOfSquare(square1);
                                square1 = null;
                                square1Clicked = false;
                                //MessageBox.Show("invalid move3"); //DEBUG
                                selectedPiece = null;
                            }
                        }
                        else if (endRow == startRow + 2) //Horizontal move right
                        {
                            if (endColumn == startColumn - 1) //Horizontal move right/up
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.white_knight;
                                square.Tag = "white_knight";
                            }
                            else if (endColumn == startColumn + 1) //Horizontal move right/down
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.white_knight;
                                square.Tag = "white_knight";
                            }
                            else
                            {
                                //Invalid move
                                ResetColorOfSquare(square1);
                                square1 = null;
                                square1Clicked = false;
                                //MessageBox.Show("invalid move4"); //DEBUG
                                selectedPiece = null;
                            }
                        }
                        else
                        {
                            //Invalid move
                            ResetColorOfSquare(square1);
                            square1 = null;
                            square1Clicked = false;
                            //MessageBox.Show("invalid move5"); //DEBUG
                            selectedPiece = null;
                        }
                    }
                    else //Target is own piece
                    {
                        //Invalid move
                        ResetColorOfSquare(square1);
                        square1 = null;
                        square1Clicked = false;
                        //MessageBox.Show("invalid move6"); //DEBUG
                        selectedPiece = null;
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
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.black_knight;
                                square.Tag = "black_knight";
                            }
                            else if (endRow == startRow - 1) //Vertical move up/left
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.black_knight;
                                square.Tag = "black_knight";
                            }
                            else
                            {
                                //Invalid move
                                ResetColorOfSquare(square1);
                                square1 = null;
                                square1Clicked = false;
                                //MessageBox.Show("invalid move1"); //DEBUG
                                selectedPiece = null;
                            }
                        }
                        else if (endColumn == startColumn + 2) //Vertical move down
                        {
                            if (endRow == startRow + 1) //Vertical move down/right
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.black_knight;
                                square.Tag = "black_knight";
                            }
                            else if (endRow == startRow - 1) //Vertical move down/left
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.black_knight;
                                square.Tag = "black_knight";
                            }
                            else
                            {
                                //Invalid move
                                ResetColorOfSquare(square1);
                                square1 = null;
                                square1Clicked = false;
                                //MessageBox.Show("invalid move2"); //DEBUG
                                selectedPiece = null;
                            }
                        }
                        else if (endRow == startRow - 2) //Horizontal move left
                        {
                            if (endColumn == startColumn - 1) //Horizontal move left/up
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.black_knight;
                                square.Tag = "black_knight";
                            }
                            else if (endColumn == startColumn + 1) //Horizontal move left/down
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.black_knight;
                                square.Tag = "black_knight";
                            }
                            else
                            {
                                //Invalid move
                                ResetColorOfSquare(square1);
                                square1 = null;
                                square1Clicked = false;
                                //MessageBox.Show("invalid move3"); //DEBUG
                                selectedPiece = null;
                            }
                        }
                        else if (endRow == startRow + 2) //Horizontal move right
                        {
                            if (endColumn == startColumn - 1) //Horizontal move right/up
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.black_knight;
                                square.Tag = "black_knight";
                            }
                            else if (endColumn == startColumn + 1) //Horizontal move right/down
                            {
                                //Valid move
                                //MessageBox.Show("valid move1"); //DEBUG
                                ResetColorOfSquare(square1);
                                square1.Image = null;
                                square1.Tag = "empty";
                                square1 = null;
                                square1Clicked = false;
                                selectedPiece = null;
                                square.Image = global::Chess.Properties.Resources.black_knight;
                                square.Tag = "black_knight";
                            }
                            else
                            {
                                //Invalid move
                                ResetColorOfSquare(square1);
                                square1 = null;
                                square1Clicked = false;
                                //MessageBox.Show("invalid move4"); //DEBUG
                                selectedPiece = null;
                            }
                        }
                        else
                        {
                            //Invalid move
                            ResetColorOfSquare(square1);
                            square1 = null;
                            square1Clicked = false;
                            //MessageBox.Show("invalid move5"); //DEBUG
                            selectedPiece = null;
                        }
                    }
                    else //Target is own piece
                    {
                        //Invalid move
                        ResetColorOfSquare(square1);
                        square1 = null;
                        square1Clicked = false;
                        //MessageBox.Show("invalid move6"); //DEBUG
                        selectedPiece = null;
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
                                        //Valid move
                                        //MessageBox.Show("valid move1"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.white_bishop;
                                        square.Tag = "white_bishop";
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
                                        //Valid move
                                       // MessageBox.Show("valid move2"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.white_bishop;
                                        square.Tag = "white_bishop";
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
                                        //Valid move
                                        //MessageBox.Show("valid move3"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.white_bishop;
                                        square.Tag = "white_bishop";
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
                                        //Valid move
                                       // MessageBox.Show("valid move4"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.white_bishop;
                                        square.Tag = "white_bishop";
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
                        else
                        {
                            InvalidMove(); //horizontal move by bishop
                            //MessageBox.Show("horizontal move by bishop"); //DEBUG
                        }
                    }
                    else
                    {
                        InvalidMove();
                        //MessageBox.Show("target is own piece"); //DEBUG
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
                                        //Valid move
                                        //MessageBox.Show("valid move1"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.black_bishop;
                                        square.Tag = "black_bishop";
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
                                        //Valid move
                                        // MessageBox.Show("valid move2"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.black_bishop;
                                        square.Tag = "black_bishop";
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
                                        //Valid move
                                        //MessageBox.Show("valid move3"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.black_bishop;
                                        square.Tag = "black_bishop";
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
                                            //MessageBox.Show(y.Tag.ToString()); //DEBUG
                                        }
                                    }
                                    if (squareInWay == false)
                                    {
                                        //Valid move
                                        // MessageBox.Show("valid move4"); //DEBUG
                                        ResetColorOfSquare(square1);
                                        square1.Image = null;
                                        square1.Tag = "empty";
                                        square1 = null;
                                        square1Clicked = false;
                                        selectedPiece = null;
                                        square.Image = global::Chess.Properties.Resources.black_bishop;
                                        square.Tag = "black_bishop";
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
                        else
                        {
                            InvalidMove(); //horizontal move by bishop
                            //MessageBox.Show("horizontal move by bishop"); //DEBUG
                        }
                    }
                    else
                    {
                        InvalidMove();
                        //MessageBox.Show("target is own piece"); //DEBUG
                    }
                }

                else if (selectedPiece == "white_queen")
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
                else if (selectedPiece == "white_king")
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