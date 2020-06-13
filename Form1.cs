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
                if (DoesMoveResultInCheck("white", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("black", false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        /*//Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }*/
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
                if (DoesMoveResultInCheck("black", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("white", false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";

                        /*
                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }
                        */
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
                if (DoesMoveResultInCheck("white", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("black", false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        /*//Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }*/
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
                if (DoesMoveResultInCheck("black", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("white", false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";

                        /*
                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }
                        */
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
                if (DoesMoveResultInCheck("white", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("black", false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        /*//Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }*/
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
                if (DoesMoveResultInCheck("black", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("white", false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";

                        /*
                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }
                        */
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
                if (DoesMoveResultInCheck("white", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("black", false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        /*//Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }*/
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
                if (DoesMoveResultInCheck("black", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("white", false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";

                        /*
                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }
                        */
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
                if (DoesMoveResultInCheck("white", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("black", false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        /*//Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }*/
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
                if (DoesMoveResultInCheck("black", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("white", false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";

                        /*
                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }
                        */
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
                if (DoesMoveResultInCheck("white", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("black", false) > 0)
                    {
                        checkStatusLabel.Text = "Black is in Check.";

                        /*//Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("black") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! White wins!";
                        }*/
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
                if (DoesMoveResultInCheck("black", false) == 0) //Move is valid
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

                    if (DoesMoveResultInCheck("white", false) > 0)
                    {
                        checkStatusLabel.Text = "White is in Check.";

                        /*
                        //Does move result in Checkmate?
                        if (DoesMoveResultInCheckmate("white") == true)
                        {
                            checkStatusLabel.Text = "Checkmate! Black wins!";
                        }
                        */
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

        private int DoesMoveResultInCheck(string piece, bool test)
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

                tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow).BackColor = Color.Green; //DEBUG

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
                //Get position of white king
                KingRow = tableLayoutPanel1.GetRow(whiteKing);
                KingCol = tableLayoutPanel1.GetColumn(whiteKing);

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

            if (PawnCheck1.Tag.ToString() == enemy_pawn)
            {
                PawnCheck1.BackColor = Color.Red;
                piecesThatCanKillKing++;
            }

            if (PawnCheck2.Tag.ToString() == enemy_pawn)
            {
                PawnCheck2.BackColor = Color.Red;
                piecesThatCanKillKing++;
            }

            if (PawnCheck1.Tag.ToString() == enemy_pawn)
            {
                PawnCheck1.BackColor = Color.Red;
                piecesThatCanKillKing++;

            }
            if (PawnCheck2.Tag.ToString() == enemy_pawn)
            {
                PawnCheck2.BackColor = Color.Red;
                piecesThatCanKillKing++;
            }
            
            /*
            //////////////////////////////////////////////
            //CHECK IF A ROOK OR QUEEN CAN KILL KING

            Control HorizontalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow);
            Control HorizontalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow - 1);
            Control HorizontalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow);
            Control HorizontalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol, KingRow + 1);

            //Determine if king is in check - horizontal left (black rook or queen)
            int y = tableLayoutPanel1.GetRow(HorizontalCheck1);
            for (int x = tableLayoutPanel1.GetColumn(HorizontalCheck1); x >= 2; x--)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not black rook or black queen
                {
                    MessageBox.Show("break");
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is black rook or black queen
                {
                    tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                    piecesThatCanKillKing++;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow;
                    tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Orange;
                    continue;
                }
            }

            //Determine if white king is in check - horizontal right (enemy rook or queen)
            y = tableLayoutPanel1.GetRow(HorizontalCheck3);
            for (int x = tableLayoutPanel1.GetColumn(HorizontalCheck3); x <= 9; x++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() != enemy_queen)
                //Square is piece that is not enemy rook or enemy queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == enemy_queen)
                //Square is enemy rook or enemy queen
                {

                    tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Yellow;
                    piecesThatCanKillKing++;
                    //return true;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Orange;
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
                    tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Yellow;
                    piecesThatCanKillKing++;
                    //return true;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                //Square is empty
                {
                    tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Orange;
                    continue;
                }
            }


            //Determine if white king is in check - vertical down (enemy rook or queen)
            y = tableLayoutPanel1.GetColumn(HorizontalCheck4);
            for (int x = tableLayoutPanel1.GetRow(HorizontalCheck4); x <= 9; x++)
            {
                if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != "empty" & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_rook & tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() != enemy_queen)
                //Square is piece that is not enemy rook or enemy queen
                {
                    break;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_rook | tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == enemy_queen)
                //Square is enemy rook or enemy queen
                {
                    tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Yellow;
                    piecesThatCanKillKing++;
                    //return true;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(y, x).Tag.ToString() == "empty")
                //Square is empty
                {
                    tableLayoutPanel1.GetControlFromPosition(y, x).BackColor = Color.Orange;
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
                        x.BackColor = Color.Red;
                    piecesThatCanKillKing++;
                    //return true;
                }
            }

            ////////////////////////////////////////////////
            //CHECK IF A BISHOP OR QUEEN CAN KILL KING

            Control DiagonalCheck1 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow - 1);
            Control DiagonalCheck2 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow - 1);
            Control DiagonalCheck3 = tableLayoutPanel1.GetControlFromPosition(KingCol + 1, KingRow + 1);
            Control DiagonalCheck4 = tableLayoutPanel1.GetControlFromPosition(KingCol - 1, KingRow + 1);

            y = tableLayoutPanel1.GetRow(DiagonalCheck1);
            for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck1); x >= 2; x--, y--)
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
                    tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                    piecesThatCanKillKing++;
                    //return true;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                    continue;
                }
            }

            //Determine if  king is in check - diagonal up/right ( bishop or queen)
            y = tableLayoutPanel1.GetRow(DiagonalCheck2);
            for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck2); x <= 9; x++, y--)
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
                    tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                    piecesThatCanKillKing++;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                    continue;
                }
            }
            
            //Determine if  king is in check - diagonal down/right ( bishop or queen)
            y = tableLayoutPanel1.GetRow(DiagonalCheck3);
            for (int x = tableLayoutPanel1.GetColumn(DiagonalCheck3); x <= 9; x++, y++)
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
                    tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                    piecesThatCanKillKing++;
                }
                else if (tableLayoutPanel1.GetControlFromPosition(x, y).Tag.ToString() == "empty")
                //Square is empty
                {
                    //tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Green; //DEBUG
                    continue;
                }
            }
            
            //Determine if  king is in check - diagonal down/left ( bishop or queen)
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
                    tableLayoutPanel1.GetControlFromPosition(x, y).BackColor = Color.Red;
                    piecesThatCanKillKing++;
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
                KingCheck1.BackColor = Color.Red;
                piecesThatCanKillKing++;
            }

            if (KingCheck2.Tag.ToString() == enemy_king)
            {
                KingCheck2.BackColor = Color.Red;
                piecesThatCanKillKing++;
            }

            if (KingCheck3.Tag.ToString() == enemy_king)
            {
                KingCheck3.BackColor = Color.Red;
                piecesThatCanKillKing++;
            }

            if (KingCheck4.Tag.ToString() == enemy_king)
            {
                KingCheck4.BackColor = Color.Red;
                piecesThatCanKillKing++;
            }

            if (KingCheck5.Tag.ToString() == enemy_king)
            {
                KingCheck5.BackColor = Color.Red;
                piecesThatCanKillKing++;
            }

            if (KingCheck6.Tag.ToString() == enemy_king)
            {
                KingCheck6.BackColor = Color.Red;
                piecesThatCanKillKing++;
            }

            if (KingCheck7.Tag.ToString() == enemy_king)
            {
                KingCheck7.BackColor = Color.Red;
                piecesThatCanKillKing++;
            }

            if (KingCheck8.Tag.ToString() == enemy_king)
            {
                KingCheck8.BackColor = Color.Red;
                piecesThatCanKillKing++;
            }
            */

            return piecesThatCanKillKing;
        }
 
        /*
        private bool DoesMoveResultInCheckmate(string piece)
        //This method will be triggered after (white) moves
        //Input will be the position of (black) king
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
                MessageBox.Show("Checking whether king can move out of check..."); //DEBUG
                foreach (PictureBox x in KingPos)
                {
                    System.Threading.Thread.Sleep(500); //DEBUG
                    Application.DoEvents(); //DEBUG

                    if (x != null) //if square is on the board - not sure why the !=kingpos[7] needs to be there
                    {
                        blackKing2 = blackKing;
                        blackKing = x;
                        x.BackColor = Color.Green; //DEBUG            

                        if (DoesMoveResultInCheck("black", true) == 0) //Black king does have a possible move
                        {
                            MessageBox.Show("Black king can move"); //DEBUG
                            blackKing = blackKing2;
                            return false;
                        }
                        blackKing = blackKing2;
                    }
                }
                





                //MessageBox.Show("King has no possible moves"); //DEBUG
                //return false; //DEBUG 

                

                //If not, determine how many pieces are currently in a position to kill black king
                int CheckPieceQuantity = DoesMoveResultInCheck("black", false);
                MessageBox.Show(CheckPieceQuantity.ToString() + " piece can kill king"); //DEBUG

                //If only 1, determine if that piece can be killed
                if (CheckPieceQuantity == 1)
                {
                    MessageBox.Show("Checking whether that piece can be killed"); //DEBUG

                    //Get position of piece causing Check
                    whiteKing2 = whiteKing;
                    GetPositionOfPieceThatIsCausingCheck("black");
                    whiteKing = blackKing;

                    if (DoesMoveResultInCheck("white", false) > 0)
                    {
                        //Yes, that piece can be killed 
                        MessageBox.Show("That piece can be killed"); //DEBUG
                        whiteKing = whiteKing2;
                        return false;
                    }
                    else
                    {
                        whiteKing = whiteKing2;
                        return true;
                    }
                    
                }
                 else if (CheckPieceQuantity > 1) //Checkmate - White wins
                {
                    return true;
                }
                
                else //This should be unreachable
                {
                    return false;
                }
                

            }
            else if (piece.Contains("black"))
            {
                return false;
            }
            else //This should be unreachable
            {
                return false;
            }
        }*/

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