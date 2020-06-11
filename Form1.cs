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

        public Form1()
        {
            InitializeComponent();
            whiteKing = pictureBox61;
            blackKing = pictureBox37; //Debug - normal 05
        }
        private void ValidMove(string piece)
        //I still need to find a way to simplify this method
        {
            square1.Tag = "empty";
            square.Tag = piece;

            if (piece == "white_pawn")
            {
                if (DoesMoveResultInCheck("white") == false) //Move is valid
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

                    if (DoesMoveResultInCheck("black") == true)
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
                if (DoesMoveResultInCheck("black") == false) //Move is valid
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

                    if (DoesMoveResultInCheck("white") == true)
                    {
                        checkStatusLabel.Text = "White is in Check.";
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
                if (DoesMoveResultInCheck("white") == false) //Move is valid
                {
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

                    if (DoesMoveResultInCheck("black") == true)
                    {
                        checkStatusLabel.Text = "Black is in Check.";
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
                if (DoesMoveResultInCheck("black") == false) //Move is valid
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

                    if (DoesMoveResultInCheck("white") == true)
                    {
                        checkStatusLabel.Text = "White is in Check.";
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
                if (DoesMoveResultInCheck("white") == false) //Move is valid
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

                    if (DoesMoveResultInCheck("black") == true)
                    {
                        checkStatusLabel.Text = "Black is in Check.";
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
                if (DoesMoveResultInCheck("black") == false) //Move is valid
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

                    if (DoesMoveResultInCheck("white") == true)
                    {
                        checkStatusLabel.Text = "White is in Check.";
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
                if (DoesMoveResultInCheck("white") == false) //Move is valid
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

                    if (DoesMoveResultInCheck("black") == true)
                    {
                        checkStatusLabel.Text = "Black is in Check.";
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
                if (DoesMoveResultInCheck("black") == false) //Move is valid
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

                    if (DoesMoveResultInCheck("white") == true)
                    {
                        checkStatusLabel.Text = "White is in Check.";
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
                if (DoesMoveResultInCheck("white") == false) //Move is valid
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

                    if (DoesMoveResultInCheck("black") == true)
                    {
                        checkStatusLabel.Text = "Black is in Check.";
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
                if (DoesMoveResultInCheck("black") == false) //Move is valid
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

                    if (DoesMoveResultInCheck("white") == true)
                    {
                        checkStatusLabel.Text = "White is in Check.";
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
                if (DoesMoveResultInCheck("white") == false) //Move is valid
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

                    if (DoesMoveResultInCheck("black") == true)
                    {
                        checkStatusLabel.Text = "Black is in Check.";
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
                if (DoesMoveResultInCheck("black") == false) //Move is valid
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

                    if (DoesMoveResultInCheck("white") == true)
                    {
                        checkStatusLabel.Text = "White is in Check.";
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
            if (piece == "white")
            {
                //Get position of white king
                int KingRow = tableLayoutPanel1.GetRow(whiteKing);
                int KingCol = tableLayoutPanel1.GetColumn(whiteKing);

                /////////////////////////////////////
                //CHECK IF A PAWN CAN KILL WHITE KING

                Control blackPawnCheck1 = new Control();
                Control blackPawnCheck2 = new Control();

                //Check if the king is in an outside or outside-adjecent row or column, and set 
                //appropriate squares to be ignored (because they are outside the board)
                if (KingCol > 1 & KingCol < 6 & KingRow > 1 & KingRow < 6) //Do not ignore any squares
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 0 & KingRow > 1 & KingRow < 6) //ignore col - 1 and col - 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 0) //ignore col - 1 and col - 2 and row - 1 and row -2
                {
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 1) //ignore col - 1 and col - 2 and row - 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 6) //ignore col - 1 and col - 2 and row + 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 7) //ignore col - 1 and col - 2 and row + 1 and row + 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 1 & KingRow > 1 && KingRow < 6) //ignore col - 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 1 & KingRow == 0) //ignore col - 2 and row - 1 and row -2
                {
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 1 & KingRow == 1) //ignore col - 2 and row - 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 1 & KingRow == 6) //ignore col - 2 and row + 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 1 & KingRow == 7) //ignore col - 2 and row + 1 and row + 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 6 & KingRow > 1 && KingRow < 6) //ignore col + 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 6 & KingRow == 0) //ignore col + 2 and row - 1 and row -2
                {
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 6 & KingRow == 1) //ignore col + 2 and row - 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 6 & KingRow == 6) //ignore col + 2 and row + 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 6 & KingRow == 7) //ignore col + 2 and row + 1 and row + 2
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 7 & KingRow > 1 && KingRow < 6) //ignore col + 1 and col + 2
                {
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 7 & KingRow == 0) //ignore col + 1 and col + 2 and row - 1 and row -2
                {
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = null;
                }
                else if (KingCol == 7 & KingRow == 1) //ignore col + 1 and col + 2 and row - 2
                {
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 7 & KingRow == 6) //ignore col + 1 and col + 2 and row + 2
                {
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else if (KingCol == 7 & KingRow == 7) //ignore col + 1 and col + 2 and row + 1 and row + 2
                {
                    blackPawnCheck1 = null;
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }
                else //Do not ignore any squares
                {
                    blackPawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackPawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                }

                //Determine if white king is in check by black pawn
                if (blackPawnCheck1 != null & blackPawnCheck2 == null)
                {
                    if (blackPawnCheck1.Tag.ToString() == "black_pawn")
                    {
                        blackPawnCheck1.BackColor = Color.Red;
                        return true;
                    }
                }
                else if (blackPawnCheck1 == null & blackPawnCheck2 != null)
                {
                    if (blackPawnCheck2.Tag.ToString() == "black_pawn")
                    {
                        blackPawnCheck2.BackColor = Color.Red;
                        return true;
                    }
                }
                else if (blackPawnCheck1 != null & blackPawnCheck2 != null)
                {
                    if (blackPawnCheck1.Tag.ToString() == "black_pawn")
                    {
                        blackPawnCheck1.BackColor = Color.Red;
                        return true;
                    }
                    if (blackPawnCheck2.Tag.ToString() == "black_pawn")
                    {
                        blackPawnCheck2.BackColor = Color.Red;
                        return true;
                    }
                }

                //////////////////////////////////////////////
                //CHECK IF A ROOK OR QUEEN CAN KILL WHITE KING

                Control blackHorizontalCheck1 = new Control();
                Control blackHorizontalCheck2 = new Control();
                Control blackHorizontalCheck3 = new Control();
                Control blackHorizontalCheck4 = new Control();

                //Check if the king is in an outside or outside-adjecent row or column, and set 
                //appropriate squares to be ignored (because they are outside the board)
                if (KingCol > 1 & KingCol < 6 & KingRow > 1 & KingRow < 6) //Do not ignore any squares
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow > 1 & KingRow < 6) //Ignore  col - 1 and col - 2
                {
                    blackHorizontalCheck1 = null;
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow == 0) //Ignore  col - 1 and col - 2 and row - 1 and row -2
                {
                    blackHorizontalCheck1 = null;
                    blackHorizontalCheck2 = null;
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow == 1) //Ignore  col - 1 and col - 2 and row - 2
                {
                    blackHorizontalCheck1 = null;
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow == 6) //Ignore  col - 1 and col - 2 and row + 2
                {
                    blackHorizontalCheck1 = null;
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow == 7) //Ignore  col - 1 and col - 2 and row + 1 and row + 2
                {
                    blackHorizontalCheck1 = null;
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = null;
                }
                else if (KingCol == 1 & KingRow > 1 && KingRow < 6) //Ignore  col - 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 0) //Ignore  col - 2 and row - 1 and row -2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = null;
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 1) //Ignore  col - 2 and row - 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 6) //Ignore  col - 2 and row + 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 7) //Ignore  col - 2 and row + 1 and row + 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = null;
                }
                else if (KingCol == 6 & KingRow > 1 && KingRow < 6) //Ignore  col + 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 0) //Ignore  col + 2 and row - 1 and row -2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = null;
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 1) //Ignore  col + 2 and row - 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 6) //Ignore  col + 2 and row + 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 7) //Ignore  col + 2 and row + 1 and row + 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = null;
                }
                else if (KingCol == 7 & KingRow > 1 && KingRow < 6) //Ignore  col + 1 and col + 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = null;
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 0) //Ignore  col + 1 and col + 2 and row - 1 and row -2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = null;
                    blackHorizontalCheck3 = null;
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 1) //Ignore  col + 1 and col + 2 and row - 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = null;
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 6) //Ignore  col + 1 and col + 2 and row + 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = null;
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 7) //Ignore  col + 1 and col + 2 and row + 1 and row + 2
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = null;
                    blackHorizontalCheck4 = null;
                }
                else //Do not ignore any squares
                {
                    blackHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    blackHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }

                //Determine if white king is in check - horizontal left (black rook or queen)
                if (blackHorizontalCheck1 != null)
                {
                    int y = tableLayoutPanel1.GetRow(blackHorizontalCheck1);
                    for (int x = tableLayoutPanel1.GetColumn(blackHorizontalCheck1); x >= 0; x--)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_rook" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_queen")
                        //Square is piece that is not black rook or black queen
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_rook" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_queen")
                        //Square is black rook or black queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            continue;
                        }
                    }
                }

                //Determine if white king is in check - horizontal right (black rook or queen)
                if (blackHorizontalCheck3 != null)
                {
                    int y = tableLayoutPanel1.GetRow(blackHorizontalCheck3);
                    for (int x = tableLayoutPanel1.GetColumn(blackHorizontalCheck3); x <= 7; x++)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_rook" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_queen")
                        //Square is piece that is not black rook or black queen
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_rook" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_queen")
                        //Square is black rook or black queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            continue;
                        }
                    }
                }

                //Determine if white king is in check - vertical up (black rook or queen)
                if (blackHorizontalCheck2 != null)
                {
                    int y = tableLayoutPanel1.GetColumn(blackHorizontalCheck2);
                    for (int x = tableLayoutPanel1.GetRow(blackHorizontalCheck2); x >= 0; x--)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "black_rook" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "black_queen")
                        //Square is piece that is not black rook or black queen
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "black_rook" | tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "black_queen")
                        //Square is black rook or black queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            continue;
                        }
                    }
                }

                //Determine if white king is in check - vertical down (black rook or queen)
                if (blackHorizontalCheck4 != null)
                {
                    int y = tableLayoutPanel1.GetColumn(blackHorizontalCheck4);
                    for (int x = tableLayoutPanel1.GetRow(blackHorizontalCheck4); x <= 7; x++)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "black_rook" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "black_queen")
                        //Square is piece that is not black rook or black queen
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "black_rook" | tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "black_queen")
                        //Square is black rook or black queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            continue;
                        }
                    }
                }

                ///////////////////////////////////////
                //CHECK IF A KNIGHT CAN KILL WHITE KING

                Control blackKnightCheck1 = new Control();
                Control blackKnightCheck2 = new Control();
                Control blackKnightCheck3 = new Control();
                Control blackKnightCheck4 = new Control();
                Control blackKnightCheck5 = new Control();
                Control blackKnightCheck6 = new Control();
                Control blackKnightCheck7 = new Control();
                Control blackKnightCheck8 = new Control();

                Control[] blackKnightChecks = { blackKnightCheck1, blackKnightCheck2, blackKnightCheck3, blackKnightCheck4, blackKnightCheck5, blackKnightCheck6, blackKnightCheck7, blackKnightCheck8 };

                //Check if the king is in an outside or outside-adjecent row or column, and set 
                //appropriate squares to be ignored (because they are outside the board)
                if (KingCol > 1 && KingCol < 6 && KingRow > 1 && KingRow < 6) //Do not ignore any squares
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
                    if (KingRow > 1 && KingRow < 6) //Ignore col - 1 and col - 2
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
                    else if (KingRow == 0) //Ignore col - 1 and col - 2 and row - 1 and row -2
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
                    else if (KingRow == 1) //Ignore col - 1 and col - 2 and row - 2
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
                    else if (KingRow == 6) //Ignore col - 1 and col - 2 and row + 2
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
                    else if (KingRow == 7) //Ignore col - 1 and col - 2 and row + 1 and row + 2
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
                    if (KingRow > 1 && KingRow < 6) //Ignore col - 2
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
                    else if (KingRow == 0) //Ignore col - 2 and row - 1 and row -2
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
                    else if (KingRow == 1) //Ignore col - 2 and row - 2
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
                    else if (KingRow == 6) //Ignore col - 2 and row + 2
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
                    else if (KingRow == 7) //Ignore col - 2 and row + 1 and row + 2
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
                    if (KingRow > 1 && KingRow < 6) //Ignore col + 2
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
                    else if (KingRow == 0) //Ignore col + 2 and row - 1 and row -2
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
                    else if (KingRow == 1) //Ignore col + 2 and row - 2
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
                    else if (KingRow == 6) //Ignore col + 2 and row + 2
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
                    else if (KingRow == 7) //Ignore col + 2 and row + 1 and row + 2
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
                    if (KingRow > 1 && KingRow < 6) //Ignore col + 1 and col + 2
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
                    else if (KingRow == 0) //Ignore col + 1 and col + 2 and row - 1 and row -2
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
                    else if (KingRow == 1) //Ignore col + 1 and col + 2 and row - 2
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
                    else if (KingRow == 6) //Ignore col + 1 and col + 2 and row + 2
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
                    else if (KingRow == 7) //Ignore col + 1 and col + 2 and row + 1 and row + 2
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
                else if (KingCol > 1 & KingCol < 6)
                {
                    if (KingRow == 0) //Ignore col - 1 and col - 2
                    {
                        blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        blackKnightChecks[1] = null;
                        blackKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        blackKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        blackKnightChecks[5] = null;
                        blackKnightChecks[6] = null;
                        blackKnightChecks[7] = null;
                    }
                    else if (KingRow == 1) //Ignore col - 2
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
                    else if (KingRow == 6) //Ignore col + 2
                    {
                        blackKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                        blackKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                    }
                    else if (KingRow == 7) //Ignore col + 1 and col + 2
                    {
                        blackKnightChecks[0] = null;
                        blackKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        blackKnightChecks[2] = null;
                        blackKnightChecks[3] = null;
                        blackKnightChecks[4] = null;
                        blackKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        blackKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        blackKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                    }
                }
                //Determine if white king is in check by a black knight
                foreach (Control x in blackKnightChecks)
                {
                    if (x != null) //if square is on the board
                    {
                        if (x.Tag.ToString() == "black_knight")
                        {
                            x.BackColor = Color.Red;
                            return true;
                        }
                    }
                }

                ////////////////////////////////////////////////
                //CHECK IF A BISHOP OR QUEEN CAN KILL WHITE KING

                Control blackDiagonalCheck1 = new Control();
                Control blackDiagonalCheck2 = new Control();
                Control blackDiagonalCheck3 = new Control();
                Control blackDiagonalCheck4 = new Control();

                //Check if the king is in an outside or outside-adjecent row or column, and set 
                //appropriate squares to be ignored (because they are outside the board)
                if (KingCol > 1 & KingCol < 6 & KingRow > 1 & KingRow < 6) //Do not ignore any squares
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow > 1 & KingRow < 6) //Ignore col - 1 and col - 2
                {
                    blackDiagonalCheck1 = null;
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = null;
                }
                else if (KingCol == 0 & KingRow == 0) //Ignore col - 1 and col - 2 and row - 1 and row -2
                {
                    blackDiagonalCheck1 = null;
                    blackDiagonalCheck2 = null;
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = null;
                }
                else if (KingCol == 0 & KingRow == 1) //Ignore col - 1 and col - 2 and row - 2
                {
                    blackDiagonalCheck1 = null;
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = null;
                }
                else if (KingCol == 0 & KingRow == 6) //Ignore col - 1 and col - 2 and row + 2
                {
                    blackDiagonalCheck1 = null;
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = null;
                }
                else if (KingCol == 0 & KingRow == 7) //Ignore col - 1 and col - 2 and row + 1 and row + 2
                {
                    blackDiagonalCheck1 = null;
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = null;
                }
                else if (KingCol == 1 & KingRow > 1 && KingRow < 6) //Ignore col - 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 0) //Ignore col - 2 and row - 1 and row -2
                {
                    blackDiagonalCheck1 = null;
                    blackDiagonalCheck2 = null;
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 1) //Ignore col - 2 and row - 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 6) //Ignore col - 2 and row + 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 7) //Ignore col - 2 and row + 1 and row + 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = null;
                    blackDiagonalCheck4 = null;
                }
                else if (KingCol == 6 & KingRow > 1 && KingRow < 6) //Ignore col + 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 0) //Ignore col + 2 and row - 1 and row -2
                {
                    blackDiagonalCheck1 = null;
                    blackDiagonalCheck2 = null;
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 1) //Ignore col + 2 and row - 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 6) //Ignore col + 2 and row + 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 7) //Ignore col + 2 and row + 1 and row + 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = null;
                    blackDiagonalCheck4 = null;
                }
                else if (KingCol == 7 & KingRow > 1 && KingRow < 6) //Ignore col + 1 and col + 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = null;
                    blackDiagonalCheck4 = null;
                }
                else if (KingCol == 7 & KingRow == 0) //Ignore col + 1 and col + 2 and row - 1 and row -2
                {
                    blackDiagonalCheck1 = null;
                    blackDiagonalCheck2 = null;
                    blackDiagonalCheck3 = null;
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 1) //Ignore col + 1 and col + 2 and row - 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = null;
                    blackDiagonalCheck3 = null;
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 6) //Ignore col + 1 and col + 2 and row + 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = null;
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 7) //Ignore col + 1 and col + 2 and row + 1 and row + 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = null;
                    blackDiagonalCheck4 = null;
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 0) //Ignore row - 1 and row - 2
                {
                    blackDiagonalCheck1 = null;
                    blackDiagonalCheck2 = null;
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 1) //Ignore row - 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 6) //Ignore row + 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 7) //Ignore row + 1 and row + 2
                {
                    blackDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackDiagonalCheck3 = null;
                    blackDiagonalCheck4 = null;
                }
                //Determine if white king is in check - diagonal up/left (black bishop or queen)
                if (blackDiagonalCheck1 != null)
                {
                    int y = tableLayoutPanel1.GetRow(blackDiagonalCheck1);
                    for (int x = tableLayoutPanel1.GetColumn(blackDiagonalCheck1); x >= 0; x--, y--)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                        //Square is outside board
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_bishop" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_queen")
                        //Square is piece that is not black bishop or black queen
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_bishop" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_queen")
                        //Square is black bishop or black queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }

                //Determine if white king is in check - diagonal up/right (black bishop or queen)
                if (blackDiagonalCheck2 != null)
                {
                    int y = tableLayoutPanel1.GetRow(blackDiagonalCheck2);
                    for (int x = tableLayoutPanel1.GetColumn(blackDiagonalCheck2); x <= 7; x++, y--)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                        //Square is outside board
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_bishop" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_queen")
                        //Square is piece that is not black bishop or black queen
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_bishop" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_queen")
                        //Square is black bishop or black queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }

                //Determine if white king is in check - diagonal down/right (black bishop or queen)
                if (blackDiagonalCheck3 != null)
                {
                    int y = tableLayoutPanel1.GetRow(blackDiagonalCheck3);
                    for (int x = tableLayoutPanel1.GetColumn(blackDiagonalCheck3); x <= 7; x++, y++)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                        //Square is outside board
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_bishop" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_queen")
                        //Square is piece that is not black bishop or black queen
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_bishop" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_queen")
                        //Square is black bishop or black queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }

                //Determine if white king is in check - diagonal down/left (black bishop or queen)
                if (blackDiagonalCheck4 != null)
                {
                    int y = tableLayoutPanel1.GetRow(blackDiagonalCheck4);
                    for (int x = tableLayoutPanel1.GetColumn(blackDiagonalCheck4); x >= 0; x--, y++)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                        //Square is outside board
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_bishop" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "black_queen")
                        //Square is piece that is not black bishop or black queen
                        {
                           //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_bishop" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "black_queen")
                        //Square is black bishop or black queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }

                /////////////////////////////////////////
                //CHECK IF BLACK KING CAN KILL WHITE KING

                Control blackKingCheck1 = new Control();
                Control blackKingCheck2 = new Control();
                Control blackKingCheck3 = new Control();
                Control blackKingCheck4 = new Control();
                Control blackKingCheck5 = new Control();
                Control blackKingCheck6 = new Control();
                Control blackKingCheck7 = new Control();
                Control blackKingCheck8 = new Control();

                //Check if the king is in an outside or outside-adjecent row or column, and set 
                //appropriate squares to be ignored (because they are outside the board)
                if (KingCol > 1 & KingCol < 6 & KingRow > 1 & KingRow < 6) //Do not ignore any squares
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 0 & KingRow > 1 & KingRow < 6) //Ignore col - 1 and col - 2
                {
                    blackKingCheck1 = null;
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = null;
                    blackKingCheck8 = null;
                }
                else if (KingCol == 0 & KingRow == 0) //Ignore col - 1 and col - 2 and row - 1 and row -2
                {
                    blackKingCheck1 = null;
                    blackKingCheck2 = null;
                    blackKingCheck3 = null;
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = null;
                    blackKingCheck8 = null;
                }
                else if (KingCol == 0 & KingRow == 1) //Ignore col - 1 and col - 2 and row - 2
                {
                    blackKingCheck1 = null;
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = null;
                    blackKingCheck8 = null;
                }
                else if (KingCol == 0 & KingRow == 6) //Ignore col - 1 and col - 2 and row + 2
                {
                    blackKingCheck1 = null;
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = null;
                    blackKingCheck8 = null;
                }
                else if (KingCol == 0 & KingRow == 7) //Ignore col - 1 and col - 2 and row + 1 and row + 2
                {
                    blackKingCheck1 = null;
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = null;
                    blackKingCheck6 = null;
                    blackKingCheck7 = null;
                    blackKingCheck8 = null;
                }
                else if (KingCol == 1 & KingRow > 1 && KingRow < 6) //Ignore col - 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 1 & KingRow == 0) //Ignore col - 2 and row - 1 and row -2
                {
                    blackKingCheck1 = null;
                    blackKingCheck2 = null;
                    blackKingCheck3 = null;
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 1 & KingRow == 1) //Ignore col - 2 and row - 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 1 & KingRow == 6) //Ignore col - 2 and row + 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 1 & KingRow == 7) //Ignore col - 2 and row + 1 and row + 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = null;
                    blackKingCheck6 = null;
                    blackKingCheck7 = null;
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 6 & KingRow > 1 && KingRow < 6) //Ignore col + 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 6 & KingRow == 0) //Ignore col + 2 and row - 1 and row -2
                {
                    blackKingCheck1 = null;
                    blackKingCheck2 = null;
                    blackKingCheck3 = null;
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 6 & KingRow == 1) //Ignore col + 2 and row - 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 6 & KingRow == 6) //Ignore col + 2 and row + 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 6 & KingRow == 7) //Ignore col + 2 and row + 1 and row + 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = null;
                    blackKingCheck6 = null;
                    blackKingCheck7 = null;
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 7 & KingRow > 1 && KingRow < 6) //Ignore col + 1 and col + 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = null;
                    blackKingCheck4 = null;
                    blackKingCheck5 = null;
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 7 & KingRow == 0) //Ignore col + 1 and col + 2 and row - 1 and row -2
                {
                    blackKingCheck1 = null;
                    blackKingCheck2 = null;
                    blackKingCheck3 = null;
                    blackKingCheck4 = null;
                    blackKingCheck5 = null;
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 7 & KingRow == 1) //Ignore col + 1 and col + 2 and row - 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = null;
                    blackKingCheck4 = null;
                    blackKingCheck5 = null;
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 7 & KingRow == 6) //Ignore col + 1 and col + 2 and row + 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = null;
                    blackKingCheck4 = null;
                    blackKingCheck5 = null;
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 7 & KingRow == 7) //Ignore col + 1 and col + 2 and row + 1 and row + 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = null;
                    blackKingCheck4 = null;
                    blackKingCheck5 = null;
                    blackKingCheck6 = null;
                    blackKingCheck7 = null;
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 0) //Ignore row - 1 and row - 2
                {
                    blackKingCheck1 = null;
                    blackKingCheck2 = null;
                    blackKingCheck3 = null;
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 1) //Ignore row - 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 6) //Ignore row + 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    blackKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    blackKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 7) //Ignore row + 1 and row + 2
                {
                    blackKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    blackKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    blackKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    blackKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    blackKingCheck5 = null;
                    blackKingCheck6 = null;
                    blackKingCheck7 = null;
                    blackKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }

                //Determine if white king is in check by black king
                if (blackKingCheck1 != null)
                {
                    if (blackKingCheck1.Tag.ToString() == "black_king")
                    {
                        blackKingCheck1.BackColor = Color.Red;
                        return true;
                    }
                }
                if (blackKingCheck2 != null)
                {
                    if (blackKingCheck2.Tag.ToString() == "black_king")
                    {
                        blackKingCheck2.BackColor = Color.Red;
                        return true;
                    }
                }
                if (blackKingCheck3 != null)
                {
                    if (blackKingCheck3.Tag.ToString() == "black_king")
                    {
                        blackKingCheck3.BackColor = Color.Red;
                        return true;
                    }
                }
                if (blackKingCheck4!= null)
                {
                    if (blackKingCheck4.Tag.ToString() == "black_king")
                    {
                        blackKingCheck4.BackColor = Color.Red;
                        return true;
                    }
                }
                if (blackKingCheck5 != null)
                {
                    if (blackKingCheck5.Tag.ToString() == "black_king")
                    {
                        blackKingCheck5.BackColor = Color.Red;
                        return true;
                    }
                }
                if (blackKingCheck6 != null)
                {
                    if (blackKingCheck6.Tag.ToString() == "black_king")
                    {
                        blackKingCheck6.BackColor = Color.Red;
                        return true;
                    }
                }
                if (blackKingCheck7 != null)
                {
                    if (blackKingCheck7.Tag.ToString() == "black_king")
                    {
                        blackKingCheck7.BackColor = Color.Red;
                        return true;
                    }
                }
                if (blackKingCheck8 != null)
                {
                    if (blackKingCheck8.Tag.ToString() == "black_king")
                    {
                        blackKingCheck8.BackColor = Color.Red;
                        return true;
                    }
                }

                //If white king is not in check
                return false;

            }

            else if (piece == "black")
            {
                //Get position of black king
                int KingRow = tableLayoutPanel1.GetRow(blackKing);
                int KingCol = tableLayoutPanel1.GetColumn(blackKing);

                /////////////////////////////////////
                //CHECK IF A PAWN CAN KILL black KING

                Control whitePawnCheck1 = new Control();
                Control whitePawnCheck2 = new Control();

                //Check if the king is in an outside or outside-adjecent row or column, and set 
                //appropriate squares to be ignored (because they are outside the board)
                if (KingCol > 1 & KingCol < 6 & KingRow > 1 & KingRow < 6) //Do not ignore any squares
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow > 1 & KingRow < 6) //ignore col - 1 and col - 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 0) //ignore col - 1 and col - 2 and row - 1 and row -2
                {
                    whitePawnCheck1 = null;
                    whitePawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 1) //ignore col - 1 and col - 2 and row - 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 6) //ignore col - 1 and col - 2 and row + 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = null;
                }
                else if (KingCol == 0 & KingRow == 7) //ignore col - 1 and col - 2 and row + 1 and row + 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = null;
                }
                else if (KingCol == 1 & KingRow > 1 && KingRow < 6) //ignore col - 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 0) //ignore col - 2 and row - 1 and row -2
                {
                    whitePawnCheck1 = null;
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 1) //ignore col - 2 and row - 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 6) //ignore col - 2 and row + 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 7) //ignore col - 2 and row + 1 and row + 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow > 1 && KingRow < 6) //ignore col + 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 0) //ignore col + 2 and row - 1 and row -2
                {
                    whitePawnCheck1 = null;
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 1) //ignore col + 2 and row - 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 6) //ignore col + 2 and row + 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 7) //ignore col + 2 and row + 1 and row + 2
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow > 1 && KingRow < 6) //ignore col + 1 and col + 2
                {
                    whitePawnCheck1 = null;
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 0) //ignore col + 1 and col + 2 and row - 1 and row -2
                {
                    whitePawnCheck1 = null;
                    whitePawnCheck2 = null;
                }
                else if (KingCol == 7 & KingRow == 1) //ignore col + 1 and col + 2 and row - 2
                {
                    whitePawnCheck1 = null;
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 6) //ignore col + 1 and col + 2 and row + 2
                {
                    whitePawnCheck1 = null;
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 7) //ignore col + 1 and col + 2 and row + 1 and row + 2
                {
                    whitePawnCheck1 = null;
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else //Do not ignore any squares
                {
                    whitePawnCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whitePawnCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }

                //Determine if black king is in check by white pawn
                if (whitePawnCheck1 != null & whitePawnCheck2 == null)
                {
                    if (whitePawnCheck1.Tag.ToString() == "white_pawn")
                    {
                        whitePawnCheck1.BackColor = Color.Red;
                        return true;
                    }
                }
                else if (whitePawnCheck1 == null & whitePawnCheck2 != null)
                {
                    if (whitePawnCheck2.Tag.ToString() == "white_pawn")
                    {
                        whitePawnCheck2.BackColor = Color.Red;
                        return true;
                    }
                }
                else if (whitePawnCheck1 != null & whitePawnCheck2 != null)
                {
                    if (whitePawnCheck1.Tag.ToString() == "white_pawn")
                    {
                        whitePawnCheck1.BackColor = Color.Red;
                        return true;
                    }
                    if (whitePawnCheck2.Tag.ToString() == "white_pawn")
                    {
                        whitePawnCheck2.BackColor = Color.Red;
                        return true;
                    }
                }

                //////////////////////////////////////////////
                //CHECK IF A ROOK OR QUEEN CAN KILL black KING

                Control whiteHorizontalCheck1 = new Control();
                Control whiteHorizontalCheck2 = new Control();
                Control whiteHorizontalCheck3 = new Control();
                Control whiteHorizontalCheck4 = new Control();

                //Check if the king is in an outside or outside-adjecent row or column, and set 
                //appropriate squares to be ignored (because they are outside the board)
                if (KingCol > 1 & KingCol < 6 & KingRow > 1 & KingRow < 6) //Do not ignore any squares
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow > 1 & KingRow < 6) //Ignore  col - 1 and col - 2
                {
                    whiteHorizontalCheck1 = null;
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow == 0) //Ignore  col - 1 and col - 2 and row - 1 and row -2
                {
                    whiteHorizontalCheck1 = null;
                    whiteHorizontalCheck2 = null;
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow == 1) //Ignore  col - 1 and col - 2 and row - 2
                {
                    whiteHorizontalCheck1 = null;
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow == 6) //Ignore  col - 1 and col - 2 and row + 2
                {
                    whiteHorizontalCheck1 = null;
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow == 7) //Ignore  col - 1 and col - 2 and row + 1 and row + 2
                {
                    whiteHorizontalCheck1 = null;
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = null;
                }
                else if (KingCol == 1 & KingRow > 1 && KingRow < 6) //Ignore  col - 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 0) //Ignore  col - 2 and row - 1 and row -2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = null;
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 1) //Ignore  col - 2 and row - 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 6) //Ignore  col - 2 and row + 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 7) //Ignore  col - 2 and row + 1 and row + 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = null;
                }
                else if (KingCol == 6 & KingRow > 1 && KingRow < 6) //Ignore  col + 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 0) //Ignore  col + 2 and row - 1 and row -2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = null;
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 1) //Ignore  col + 2 and row - 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 6) //Ignore  col + 2 and row + 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 7) //Ignore  col + 2 and row + 1 and row + 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = null;
                }
                else if (KingCol == 7 & KingRow > 1 && KingRow < 6) //Ignore  col + 1 and col + 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = null;
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 0) //Ignore  col + 1 and col + 2 and row - 1 and row -2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = null;
                    whiteHorizontalCheck3 = null;
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 1) //Ignore  col + 1 and col + 2 and row - 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = null;
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 6) //Ignore  col + 1 and col + 2 and row + 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = null;
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 7) //Ignore  col + 1 and col + 2 and row + 1 and row + 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = null;
                    whiteHorizontalCheck4 = null;
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 0) //Ignore row - 1 and row - 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = null;
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 1) //Ignore row - 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 6) //Ignore row + 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 7) //Ignore row + 1 and row + 2
                {
                    whiteHorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                    whiteHorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteHorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteHorizontalCheck4 = null;
                }

                //Determine if black king is in check - horizontal left (white rook or queen)
                if (whiteHorizontalCheck1 != null)
                {
                    int y = tableLayoutPanel1.GetRow(whiteHorizontalCheck1);
                    for (int x = tableLayoutPanel1.GetColumn(whiteHorizontalCheck1); x >= 0; x--)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_rook" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_queen")
                        //Square is piece that is not white rook or white queen
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_rook" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_queen")
                        //Square is white rook or white queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            continue;
                        }
                    }
                }

                //Determine if black king is in check - horizontal right (white rook or queen)
                if (whiteHorizontalCheck3 != null)
                {
                    int y = tableLayoutPanel1.GetRow(whiteHorizontalCheck3);
                    for (int x = tableLayoutPanel1.GetColumn(whiteHorizontalCheck3); x <= 7; x++)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_rook" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_queen")
                        //Square is piece that is not white rook or white queen
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_rook" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_queen")
                        //Square is white rook or white queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            continue;
                        }
                    }
                }

                //Determine if black king is in check - vertical up (white rook or queen)
                if (whiteHorizontalCheck2 != null)
                {
                    int y = tableLayoutPanel1.GetColumn(whiteHorizontalCheck2);
                    for (int x = tableLayoutPanel1.GetRow(whiteHorizontalCheck2); x >= 0; x--)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "white_rook" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "white_queen")
                        //Square is piece that is not white rook or white queen
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "white_rook" | tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "white_queen")
                        //Square is white rook or white queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            continue;
                        }
                    }
                }

                //Determine if black king is in check - vertical down (white rook or queen)
                if (whiteHorizontalCheck4 != null)
                {
                    int y = tableLayoutPanel1.GetColumn(whiteHorizontalCheck4);
                    for (int x = tableLayoutPanel1.GetRow(whiteHorizontalCheck4); x <= 7; x++)
                    {
                        if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "white_rook" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "white_queen")
                        //Square is piece that is not white rook or white queen
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "white_rook" | tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "white_queen")
                        //Square is white rook or white queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            continue;
                        }
                    }
                }

                ///////////////////////////////////////
                //CHECK IF A KNIGHT CAN KILL black KING

                Control whiteKnightCheck1 = new Control();
                Control whiteKnightCheck2 = new Control();
                Control whiteKnightCheck3 = new Control();
                Control whiteKnightCheck4 = new Control();
                Control whiteKnightCheck5 = new Control();
                Control whiteKnightCheck6 = new Control();
                Control whiteKnightCheck7 = new Control();
                Control whiteKnightCheck8 = new Control();

                Control[] whiteKnightChecks = { whiteKnightCheck1, whiteKnightCheck2, whiteKnightCheck3, whiteKnightCheck4, whiteKnightCheck5, whiteKnightCheck6, whiteKnightCheck7, whiteKnightCheck8 };

                //Check if the king is in an outside or outside-adjecent row or column, and set 
                //appropriate squares to be ignored (because they are outside the board)
                if (KingCol > 1 && KingCol < 6 && KingRow > 1 && KingRow < 6) //Do not ignore any squares
                {
                    whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                    whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                    whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                    whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                    whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                    whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                    whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                    whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                }
                else if (KingCol == 0)
                {
                    if (KingRow > 1 && KingRow < 6) //Ignore col - 1 and col - 2
                    {
                        whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[5] = null;
                        whiteKnightChecks[6] = null;
                        whiteKnightChecks[7] = null;
                    }
                    else if (KingRow == 0) //Ignore col - 1 and col - 2 and row - 1 and row -2
                    {
                        whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[5] = null;
                        whiteKnightChecks[6] = null;
                        whiteKnightChecks[7] = null;
                    }
                    else if (KingRow == 1) //Ignore col - 1 and col - 2 and row - 2
                    {
                        whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[5] = null;
                        whiteKnightChecks[6] = null;
                        whiteKnightChecks[7] = null;
                    }
                    else if (KingRow == 6) //Ignore col - 1 and col - 2 and row + 2
                    {
                        whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[4] = null;
                        whiteKnightChecks[5] = null;
                        whiteKnightChecks[6] = null;
                        whiteKnightChecks[7] = null;
                    }
                    else if (KingRow == 7) //Ignore col - 1 and col - 2 and row + 1 and row + 2
                    {
                        whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[3] = null;
                        whiteKnightChecks[4] = null;
                        whiteKnightChecks[5] = null;
                        whiteKnightChecks[6] = null;
                        whiteKnightChecks[7] = null;
                    }
                }
                else if (KingCol == 1)
                {
                    if (KingRow > 1 && KingRow < 6) //Ignore col - 2
                    {
                        whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        whiteKnightChecks[6] = null;
                        whiteKnightChecks[7] = null;
                    }
                    else if (KingRow == 0) //Ignore col - 2 and row - 1 and row -2
                    {
                        whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[6] = null;
                        whiteKnightChecks[7] = null;
                    }
                    else if (KingRow == 1) //Ignore col - 2 and row - 2
                    {
                        whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[6] = null;
                        whiteKnightChecks[7] = null;
                    }
                    else if (KingRow == 6) //Ignore col - 2 and row + 2
                    {
                        whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        whiteKnightChecks[4] = null;
                        whiteKnightChecks[5] = null;
                        whiteKnightChecks[6] = null;
                        whiteKnightChecks[7] = null;
                    }
                    else if (KingRow == 7) //Ignore col - 2 and row + 1 and row + 2
                    {
                        whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        whiteKnightChecks[3] = null;
                        whiteKnightChecks[4] = null;
                        whiteKnightChecks[5] = null;
                        whiteKnightChecks[6] = null;
                        whiteKnightChecks[7] = null;
                    }
                }
                else if (KingCol == 6)
                {
                    if (KingRow > 1 && KingRow < 6) //Ignore col + 2
                    {
                        whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[3] = null;
                    }
                    else if (KingRow == 0) //Ignore col + 2 and row - 1 and row -2
                    {
                        whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[3] = null;
                    }
                    else if (KingRow == 1) //Ignore col + 2 and row - 2
                    {
                        whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[3] = null;
                    }
                    else if (KingRow == 6) //Ignore col + 2 and row + 2
                    {
                        whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[3] = null;
                        whiteKnightChecks[4] = null;
                        whiteKnightChecks[5] = null;
                    }
                    else if (KingRow == 7) //Ignore col + 2 and row + 1 and row + 2
                    {
                        whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[3] = null;
                        whiteKnightChecks[4] = null;
                        whiteKnightChecks[5] = null;
                        whiteKnightChecks[7] = null;
                    }
                }
                else if (KingCol == 7)
                {
                    if (KingRow > 1 && KingRow < 6) //Ignore col + 1 and col + 2
                    {
                        whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[3] = null;
                        whiteKnightChecks[4] = null;
                    }
                    else if (KingRow == 0) //Ignore col + 1 and col + 2 and row - 1 and row -2
                    {
                        whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[3] = null;
                        whiteKnightChecks[4] = null;
                    }
                    else if (KingRow == 1) //Ignore col + 1 and col + 2 and row - 2
                    {
                        whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[3] = null;
                        whiteKnightChecks[4] = null;
                    }
                    else if (KingRow == 6) //Ignore col + 1 and col + 2 and row + 2
                    {
                        whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[3] = null;
                        whiteKnightChecks[4] = null;
                        whiteKnightChecks[5] = null;
                    }
                    else if (KingRow == 7) //Ignore col + 1 and col + 2 and row + 1 and row + 2
                    {
                        whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[3] = null;
                        whiteKnightChecks[4] = null;
                        whiteKnightChecks[7] = null;
                    }
                }
                else if (KingCol > 1 & KingCol < 6)
                {
                    if (KingRow == 0) //Ignore row - 1 and row - 2
                    {
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[2] = null;
                        whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        whiteKnightChecks[6] = null;
                        whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                    }
                    else if (KingRow == 1) //Ignore row - 2
                    {
                        whiteKnightChecks[0] = null;
                        whiteKnightChecks[1] = null;
                        whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        whiteKnightChecks[4] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 2);
                        whiteKnightChecks[5] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 2);
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                    }
                    else if (KingRow == 6) //Ignore row + 2
                    {
                        whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        whiteKnightChecks[3] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow + 1);
                        whiteKnightChecks[4] = null;
                        whiteKnightChecks[5] = null;
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[7] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow + 1);
                    }
                    else if (KingRow == 7) //Ignore row + 1 and row + 2
                    {
                        whiteKnightChecks[0] = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 2);
                        whiteKnightChecks[1] = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 2);
                        whiteKnightChecks[2] = tableLayoutPanel1.GetControlFromPosition(KingCol + 2, KingRow - 1);
                        whiteKnightChecks[3] = null;
                        whiteKnightChecks[4] = null;
                        whiteKnightChecks[5] = null;
                        whiteKnightChecks[6] = tableLayoutPanel1.GetControlFromPosition(KingCol - 2, KingRow - 1);
                        whiteKnightChecks[7] = null;
                    }
                }
                //Determine if black king is in check by a white knight
                foreach (Control x in whiteKnightChecks)
                {
                    if (x != null) //if square is on the board
                    {
                        if (x.Tag.ToString() == "white_knight")
                        {
                            x.BackColor = Color.Red;
                            return true;
                        }
                    }
                }

                ////////////////////////////////////////////////
                //CHECK IF A BISHOP OR QUEEN CAN KILL black KING

                Control whiteDiagonalCheck1 = new Control();
                Control whiteDiagonalCheck2 = new Control();
                Control whiteDiagonalCheck3 = new Control();
                Control whiteDiagonalCheck4 = new Control();

                //Check if the king is in an outside or outside-adjecent row or column, and set 
                //appropriate squares to be ignored (because they are outside the board)
                if (KingCol > 1 & KingCol < 6 & KingRow > 1 & KingRow < 6) //Do not ignore any squares
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 0 & KingRow > 1 & KingRow < 6) //Ignore col - 1 and col - 2
                {
                    whiteDiagonalCheck1 = null;
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = null;
                }
                else if (KingCol == 0 & KingRow == 0) //Ignore col - 1 and col - 2 and row - 1 and row -2
                {
                    whiteDiagonalCheck1 = null;
                    whiteDiagonalCheck2 = null;
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = null;
                }
                else if (KingCol == 0 & KingRow == 1) //Ignore col - 1 and col - 2 and row - 2
                {
                    whiteDiagonalCheck1 = null;
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = null;
                }
                else if (KingCol == 0 & KingRow == 6) //Ignore col - 1 and col - 2 and row + 2
                {
                    whiteDiagonalCheck1 = null;
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = null;
                }
                else if (KingCol == 0 & KingRow == 7) //Ignore col - 1 and col - 2 and row + 1 and row + 2
                {
                    whiteDiagonalCheck1 = null;
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = null;
                }
                else if (KingCol == 1 & KingRow > 1 && KingRow < 6) //Ignore col - 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 0) //Ignore col - 2 and row - 1 and row -2
                {
                    whiteDiagonalCheck1 = null;
                    whiteDiagonalCheck2 = null;
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 1) //Ignore col - 2 and row - 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 6) //Ignore col - 2 and row + 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 1 & KingRow == 7) //Ignore col - 2 and row + 1 and row + 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = null;
                    whiteDiagonalCheck4 = null;
                }
                else if (KingCol == 6 & KingRow > 1 && KingRow < 6) //Ignore col + 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 0) //Ignore col + 2 and row - 1 and row -2
                {
                    whiteDiagonalCheck1 = null;
                    whiteDiagonalCheck2 = null;
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 1) //Ignore col + 2 and row - 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 6) //Ignore col + 2 and row + 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 6 & KingRow == 7) //Ignore col + 2 and row + 1 and row + 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = null;
                    whiteDiagonalCheck4 = null;
                }
                else if (KingCol == 7 & KingRow > 1 && KingRow < 6) //Ignore col + 1 and col + 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = null;
                    whiteDiagonalCheck3 = null;
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 0) //Ignore col + 1 and col + 2 and row - 1 and row -2
                {
                    whiteDiagonalCheck1 = null;
                    whiteDiagonalCheck2 = null;
                    whiteDiagonalCheck3 = null;
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 1) //Ignore col + 1 and col + 2 and row - 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = null;
                    whiteDiagonalCheck3 = null;
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 6) //Ignore col + 1 and col + 2 and row + 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = null;
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol == 7 & KingRow == 7) //Ignore col + 1 and col + 2 and row + 1 and row + 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = null;
                    whiteDiagonalCheck4 = null;
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 0) //Ignore row - 1 and row - 2
                {
                    whiteDiagonalCheck1 = null;
                    whiteDiagonalCheck2 = null;
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 1) //Ignore row - 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 6) //Ignore row + 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteDiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 7) //Ignore row + 1 and row + 2
                {
                    whiteDiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteDiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteDiagonalCheck3 = null;
                    whiteDiagonalCheck4 = null;
                }

                //Determine if black king is in check - diagonal up/left (black bishop or queen)
                if (whiteDiagonalCheck1 != null)
                {
                    int y = tableLayoutPanel1.GetRow(whiteDiagonalCheck1);
                    for (int x = tableLayoutPanel1.GetColumn(whiteDiagonalCheck1); x >= 0; x--, y--)
                    {
                        if (x < 0 | y < 0)
                        //Square is outside board (top or left)
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                        //Square is outside board (bottom or right)
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_bishop" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_queen")
                        //Square is piece that is not white bishop or white queen
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_bishop" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_queen")
                        //Square is white bishop or white queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }

                //Determine if black king is in check - diagonal up/right (black bishop or queen)
                if (whiteDiagonalCheck2 != null)
                {
                    int y = tableLayoutPanel1.GetRow(whiteDiagonalCheck2);
                    for (int x = tableLayoutPanel1.GetColumn(whiteDiagonalCheck2); x <= 7; x++, y--)
                    {
                        if (x < 0 | y < 0)
                        //Square is outside board (top or left)
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                        //Square is outside board
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_bishop" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_queen")
                        //Square is piece that is not black bishop or black queen
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_bishop" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_queen")
                        //Square is black bishop or black queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }

                //Determine if black king is in check - diagonal down/right (black bishop or queen)
                if (whiteDiagonalCheck3 != null)
                {
                    int y = tableLayoutPanel1.GetRow(whiteDiagonalCheck3);
                    for (int x = tableLayoutPanel1.GetColumn(whiteDiagonalCheck3); x <= 7; x++, y++)
                    {
                        if (x < 0 | y < 0)
                        //Square is outside board (top or left)
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                        //Square is outside board
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_bishop" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_queen")
                        //Square is piece that is not black bishop or black queen
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_bishop" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_queen")
                        //Square is black bishop or black queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }

                //Determine if black king is in check - diagonal down/left (black bishop or queen)
                if (whiteDiagonalCheck4 != null)
                {
                    int y = tableLayoutPanel1.GetRow(whiteDiagonalCheck4);
                    for (int x = tableLayoutPanel1.GetColumn(whiteDiagonalCheck4); x >= 0; x--, y++)
                    {
                        if (x < 0 | y < 0)
                        //Square is outside board (top or left)
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y) == null)
                        //Square is outside board
                        {
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_bishop" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "white_queen")
                        //Square is piece that is not black bishop or black queen
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow; //DEBUG
                            break;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_bishop" | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "white_queen")
                        //Square is black bishop or black queen
                        {
                            tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                            return true;
                        }
                        else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                        //Square is empty
                        {
                            //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                            continue;
                        }
                    }
                }

                /////////////////////////////////////////
                //CHECK IF white KING CAN KILL black KING

                Control whiteKingCheck1 = new Control();
                Control whiteKingCheck2 = new Control();
                Control whiteKingCheck3 = new Control();
                Control whiteKingCheck4 = new Control();
                Control whiteKingCheck5 = new Control();
                Control whiteKingCheck6 = new Control();
                Control whiteKingCheck7 = new Control();
                Control whiteKingCheck8 = new Control();

                //Check if the king is in an outside or outside-adjecent row or column, and set 
                //appropriate squares to be ignored (because they are outside the board)
                if (KingCol > 1 & KingCol < 6 & KingRow > 1 & KingRow < 6) //Do not ignore any squares
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 0 & KingRow > 1 & KingRow < 6) //Ignore col - 1 and col - 2
                {
                    whiteKingCheck1 = null;
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = null;
                    whiteKingCheck8 = null;
                }
                else if (KingCol == 0 & KingRow == 0) //Ignore col - 1 and col - 2 and row - 1 and row -2
                {
                    whiteKingCheck1 = null;
                    whiteKingCheck2 = null;
                    whiteKingCheck3 = null;
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = null;
                    whiteKingCheck8 = null;
                }
                else if (KingCol == 0 & KingRow == 1) //Ignore col - 1 and col - 2 and row - 2
                {
                    whiteKingCheck1 = null;
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = null;
                    whiteKingCheck8 = null;
                }
                else if (KingCol == 0 & KingRow == 6) //Ignore col - 1 and col - 2 and row + 2
                {
                    whiteKingCheck1 = null;
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = null;
                    whiteKingCheck8 = null;
                }
                else if (KingCol == 0 & KingRow == 7) //Ignore col - 1 and col - 2 and row + 1 and row + 2
                {
                    whiteKingCheck1 = null;
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = null;
                    whiteKingCheck6 = null;
                    whiteKingCheck7 = null;
                    whiteKingCheck8 = null;
                }
                else if (KingCol == 1 & KingRow > 1 && KingRow < 6) //Ignore col - 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 1 & KingRow == 0) //Ignore col - 2 and row - 1 and row -2
                {
                    whiteKingCheck1 = null;
                    whiteKingCheck2 = null;
                    whiteKingCheck3 = null;
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 1 & KingRow == 1) //Ignore col - 2 and row - 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 1 & KingRow == 6) //Ignore col - 2 and row + 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 1 & KingRow == 7) //Ignore col - 2 and row + 1 and row + 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = null;
                    whiteKingCheck6 = null;
                    whiteKingCheck7 = null;
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 6 & KingRow > 1 && KingRow < 6) //Ignore col + 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 6 & KingRow == 0) //Ignore col + 2 and row - 1 and row -2
                {
                    whiteKingCheck1 = null;
                    whiteKingCheck2 = null;
                    whiteKingCheck3 = null;
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 6 & KingRow == 1) //Ignore col + 2 and row - 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 6 & KingRow == 6) //Ignore col + 2 and row + 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 6 & KingRow == 7) //Ignore col + 2 and row + 1 and row + 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = null;
                    whiteKingCheck6 = null;
                    whiteKingCheck7 = null;
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 7 & KingRow > 1 && KingRow < 6) //Ignore col + 1 and col + 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = null;
                    whiteKingCheck4 = null;
                    whiteKingCheck5 = null;
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 7 & KingRow == 0) //Ignore col + 1 and col + 2 and row - 1 and row -2
                {
                    whiteKingCheck1 = null;
                    whiteKingCheck2 = null;
                    whiteKingCheck3 = null;
                    whiteKingCheck4 = null;
                    whiteKingCheck5 = null;
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 7 & KingRow == 1) //Ignore col + 1 and col + 2 and row - 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = null;
                    whiteKingCheck4 = null;
                    whiteKingCheck5 = null;
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 7 & KingRow == 6) //Ignore col + 1 and col + 2 and row + 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = null;
                    whiteKingCheck4 = null;
                    whiteKingCheck5 = null;
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol == 7 & KingRow == 7) //Ignore col + 1 and col + 2 and row + 1 and row + 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = null;
                    whiteKingCheck4 = null;
                    whiteKingCheck5 = null;
                    whiteKingCheck6 = null;
                    whiteKingCheck7 = null;
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 0) //Ignore row - 1 and row - 2
                {
                    whiteKingCheck1 = null;
                    whiteKingCheck2 = null;
                    whiteKingCheck3 = null;
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 1) //Ignore row - 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 6) //Ignore row + 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
                    whiteKingCheck6 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);
                    whiteKingCheck7 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }
                else if (KingCol > 1 & KingCol < 6 & KingRow == 7) //Ignore row + 1 and row + 2
                {
                    whiteKingCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
                    whiteKingCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
                    whiteKingCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
                    whiteKingCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
                    whiteKingCheck5 = null;
                    whiteKingCheck6 = null;
                    whiteKingCheck7 = null;
                    whiteKingCheck8 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
                }

                //Determine if black king is in check by white king
                if (whiteKingCheck1 != null)
                {
                    if (whiteKingCheck1.Tag.ToString() == "white_king")
                    {
                        whiteKingCheck1.BackColor = Color.Red;
                        return true;
                    }
                }
                if (whiteKingCheck2 != null)
                {
                    if (whiteKingCheck2.Tag.ToString() == "white_king")
                    {
                        whiteKingCheck2.BackColor = Color.Red;
                        return true;
                    }
                }
                if (whiteKingCheck3 != null)
                {
                    if (whiteKingCheck3.Tag.ToString() == "white_king")
                    {
                        whiteKingCheck3.BackColor = Color.Red;
                        return true;
                    }
                }
                if (whiteKingCheck4 != null)
                {
                    if (whiteKingCheck4.Tag.ToString() == "white_king")
                    {
                        whiteKingCheck4.BackColor = Color.Red;
                        return true;
                    }
                }
                if (whiteKingCheck5 != null)
                {
                    if (whiteKingCheck5.Tag.ToString() == "white_king")
                    {
                        whiteKingCheck5.BackColor = Color.Red;
                        return true;
                    }
                }
                if (whiteKingCheck6 != null)
                {
                    if (whiteKingCheck6.Tag.ToString() == "white_king")
                    {
                        whiteKingCheck6.BackColor = Color.Red;
                        return true;
                    }
                }
                if (whiteKingCheck7 != null)
                {
                    if (whiteKingCheck7.Tag.ToString() == "white_king")
                    {
                        whiteKingCheck7.BackColor = Color.Red;
                        return true;
                    }
                }
                if (whiteKingCheck8 != null)
                {
                    if (whiteKingCheck8.Tag.ToString() == "white_king")
                    {
                        whiteKingCheck8.BackColor = Color.Red;
                        return true;
                    }
                }

                //If black king is not in check
                return false;

            }

            else //This should be unreachable
            {
                return false;
            }
        }

        private bool DoesMoveResultInCheckmate(string piece)
        //This method will be triggered after (white) moves
        //Input will be the position of (black) king and the (white) piece that was moved
        {
            if (piece.Contains("black"))
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

                Control[] KingPos = {KingPos0, KingPos1, KingPos2, KingPos3, KingPos4, KingPos5, KingPos6, KingPos7};

                //If needed, set appropriate squares to null
                //Check if the king is in an outside or outside-adjecent row or column, and set 
                //appropriate squares to be ignored (because they are outside the board)
                if (KingColTemp > 1 & KingColTemp < 6 & KingRowTemp > 1 & KingRowTemp < 6) //Do not ignore any squares
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 0 & KingRowTemp > 1 & KingRowTemp < 6) //ignore col - 1 and col - 2
                {
                    KingPos[0] = null;
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = null;
                    KingPos[7] = null;
                }
                else if (KingColTemp == 0 & KingRowTemp == 0) //ignore col - 1 and col - 2 and row - 1 and row -2
                {
                    KingPos[0] = null;
                    KingPos[1] = null;
                    KingPos[2] = null;
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = null;
                    KingPos[7] = null;
                }
                else if (KingColTemp == 0 & KingRowTemp == 1) //ignore col - 1 and col - 2 and row - 2
                {
                    KingPos[0] = null;
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = null;
                    KingPos[7] = null;
                }
                else if (KingColTemp == 0 & KingRowTemp == 6) //ignore col - 1 and col - 2 and row + 2
                {
                    KingPos[0] = null;
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = null;
                    KingPos[7] = null;
                }
                else if (KingColTemp == 0 & KingRowTemp == 7) //ignore col - 1 and col - 2 and row + 1 and row + 2
                {
                    KingPos[0] = null;
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = null;
                    KingPos[5] = null;
                    KingPos[6] = null;
                    KingPos[7] = null;
                }
                else if (KingColTemp == 1 & KingRowTemp > 1 && KingRowTemp < 6) //ignore col - 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 1 & KingRowTemp == 0) //ignore col - 2 and row - 1 and row -2
                {
                    KingPos[0] = null;
                    KingPos[1] = null;
                    KingPos[2] = null;
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 1 & KingRowTemp == 1) //ignore col - 2 and row - 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 1 & KingRowTemp == 6) //ignore col - 2 and row + 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 1 & KingRowTemp == 7) //ignore col - 2 and row + 1 and row + 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = null;
                    KingPos[5] = null;
                    KingPos[6] = null;
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 6 & KingRowTemp > 1 && KingRowTemp < 6) //ignore col + 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 6 & KingRowTemp == 0) //ignore col + 2 and row - 1 and row -2
                {
                    KingPos[0] = null;
                    KingPos[1] = null;
                    KingPos[2] = null;
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 6 & KingRowTemp == 1) //ignore col + 2 and row - 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 6 & KingRowTemp == 6) //ignore col + 2 and row + 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 6 & KingRowTemp == 7) //ignore col + 2 and row + 1 and row + 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = null;
                    KingPos[5] = null;
                    KingPos[6] = null;
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 7 & KingRowTemp > 1 && KingRowTemp < 6) //ignore col + 1 and col + 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = null;
                    KingPos[3] = null;
                    KingPos[4] = null;
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 7 & KingRowTemp == 0) //ignore col + 1 and col + 2 and row - 1 and row -2
                {
                    KingPos[0] = null;
                    KingPos[1] = null;
                    KingPos[2] = null;
                    KingPos[3] = null;
                    KingPos[4] = null;
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 7 & KingRowTemp == 1) //ignore col + 1 and col + 2 and row - 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = null;
                    KingPos[3] = null;
                    KingPos[4] = null;
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 7 & KingRowTemp == 6) //ignore col + 1 and col + 2 and row + 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = null;
                    KingPos[3] = null;
                    KingPos[4] = null;
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp == 7 & KingRowTemp == 7) //ignore col + 1 and col + 2 and row + 1 and row + 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = null;
                    KingPos[3] = null;
                    KingPos[4] = null;
                    KingPos[5] = null;
                    KingPos[6] = null;
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp > 1 & KingColTemp < 6 & KingRowTemp == 0) //Ignore row - 1 and row - 2
                {
                    KingPos[0] = null;
                    KingPos[1] = null;
                    KingPos[2] = null;
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp > 1 & KingColTemp < 6 & KingRowTemp == 1) //Ignore row - 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp > 1 & KingColTemp < 6 & KingRowTemp == 6) //Ignore row + 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else if (KingColTemp > 1 & KingColTemp < 6 & KingRowTemp == 7) //Ignore row + 1 and row + 2
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = null;
                    KingPos[5] = null;
                    KingPos[6] = null;
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }
                else //Do not ignore any squares
                {
                    KingPos[0] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp - 1);
                    KingPos[1] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp - 1);
                    KingPos[2] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp - 1);
                    KingPos[3] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp);
                    KingPos[4] = tableLayoutPanel1.GetControlFromPosition(KingColTemp + 1, KingRowTemp + 1);
                    KingPos[5] = tableLayoutPanel1.GetControlFromPosition(KingColTemp, KingRowTemp + 1);
                    KingPos[6] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp + 1);
                    KingPos[7] = tableLayoutPanel1.GetControlFromPosition(KingColTemp - 1, KingRowTemp);
                }

                //First, determine whether black king can move into a position that does not result in check
                int piecesThatCanKillBlackKing = 0;
                foreach (PictureBox x in KingPos)
                {
                    blackKing2 = blackKing;
                    blackKing = x;

                    if (x != null) //if square is on the board
                    {
                        //x.BackColor = Color.Green; //DEBUG                        
                        if (DoesMoveResultInCheck("black") == false)
                        {
                            blackKing = blackKing2;
                            return false;
                        }
                        
                    }
                }

                //If not, determine how many pieces are currently in a position to kill black king
                blackKing = blackKing2
                
                MessageBox.Show(piecesThatCanKillBlackKing.ToString());





                //If only one, determine if that piece can be killed

                return true; //Checkmate - White wins
            }
            else if (piece.Contains("black"))
            {
                return false;
            }
            else //This should be unreachable
            {
                return false;
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