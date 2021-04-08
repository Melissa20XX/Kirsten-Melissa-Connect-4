/*

    ####################################
    #                                  #
    # SODV1201 Connect 4 Final Project #
    #                                  #
    #  Created by: Kirsten Kristensen  #
    #          and Melissa Wiebe       #
    #                                  #
    ####################################


Notes:
    
    The easiest way to check for a victory would probably be to check for a vertical,
    horizontal or diagonal victory for each piece the moment its placed.

    
    Here's an example:
    
    We're playing as X, this is the board so far.

    |   |   |   |   |   |   |   |
    |   |   |   |   |   |   |   |
    |   |   |   |   |   | X |   |
    |   | 0 |   | X |   | 0 |   |
    |   | 0 | 0 | X | X | 0 | 0 |
    | X | 0 | X | 0 | 0 | X | X |
    -----------------------------
    0 went first, and has taken 9 turns.


    Now it's our 9th turn.
    We're about to win, so we drop in an X

                      X
                      .
    |   |   |   |   | . |   |   |
    |   |   |   |   | . |   |   |
    |   |   |   |   | . | X |   |
    |   |   |   | X | . | 0 |   |
    |   | 0 | 0 | X | X | 0 | 0 |
    | X | 0 | X | 0 | 0 | X | X |
    -----------------------------    

        
    First, we check vertically. If the cell below also contains an 'X', we add 1 to a tally var and repeat
    If we come across an empty or non-matching square, we stop counting in that direction, reset the tally to 0, and begin counting in a different direction.

    |   |   |   |   | . |   |   |
    |   |   |   |   | . |   |   |
    |   |   |   |   | . |   |   |
    |   |   |   |   | X |   |   |
    |   |   |   |   | 1 |   |   |
    |   |   |   |   | # |   |   |
    -----------------------------
    There is not a vertical victory, the tally is 1
    
    Next, we need to check for a left-diagonal, horizontal, and right-diagonal victory.
    For the sake of consistency, we'll check the left side before the right side for all 3

    '#' is a cell we check that doesn't increment the tally

    |   |   |   |   | . |   |   |
    |   |   |   |   | . |   |   |
    |   |   |   | # | . |   |   |   
    |   |   |   |   | X |   |   |
    |   |   |   |   |   | # |   |
    |   |   |   |   |   |   |   |
    -----------------------------
    There is not a left diagonal victory, the tally is 0


    |   |   |   |   | . |   |   |
    |   |   |   |   | . |   |   |
    |   |   |   |   | . |   |   |
    |   |   | # | 1 | X | # |   |
    |   |   |   |   |   |   |   |
    |   |   |   |   |   |   |   |
    -----------------------------
    There is not a horizontal victory, the tally is 0

    

    |   |   |   |   | . |   |   |
    |   |   |   |   | . |   |   |
    |   |   |   |   | . | 1 |   |
    |   |   |   |   | X |   |   |
    |   |   |   | 1 |   |   |   |
    |   |   | 2 |   |   |   |   |
    -----------------------------
    Since the total tally in this direction is 3,
    our victory is confirmed 

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public static class Controller
    {
        public static string[,] GameArray = { { "| # |", "| # |", "| # |", "| # |", "| # |", "| # |", "| # |" },
                                              { "| # |", "| # |", "| # |", "| # |", "| # |", "| # |", "| # |" },
                                              { "| # |", "| # |", "| # |", "| # |", "| # |", "| # |", "| # |" },
                                              { "| # |", "| # |", "| # |", "| # |", "| # |", "| # |", "| # |" },
                                              { "| # |", "| # |", "| # |", "| # |", "| # |", "| # |", "| # |" },
                                              { "| # |", "| # |", "| # |", "| # |", "| # |", "| # |", "| # |" },
                                              { "  1  ", "  2  ", "  3  ", "  4  ", "  5  ", "  6  ", "  7  " } };
        
        public static bool CheckWin()
        {
            //static so it can be called within the other classes and without creating an object
            //return true for win and false for not a win

            int counter = 0;

            //horizontal checking
            for (int i = 0; i < 6; i++) //one less than max so when one is added to the index it wont break
            {
                counter = 0;
                for (int j = 0; j < 6; j++)
                {
                    if (GameArray[i,j] != "| # |")
                    {
                        if(GameArray[i,j] == GameArray[i,j + 1])
                        {
                            counter++;
                            if (counter == 3)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            counter = 0;
                        }
                    }
                }
            }
            //vertical checking
            for (int j = 0; j < 7; j++)
            {
                counter = 0;
                for (int i = 0; i < 5; i++) //one less than max so when one is added to the index it wont break
                {
                    if (GameArray[i, j] != "| # |")
                    {
                        if (GameArray[i, j] == GameArray[i + 1, j])
                        {
                            counter++;
                            if (counter == 3)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            counter = 0;
                        }
                    }
                }
            }

            //diagonal left to right checking
            counter = 0;
            for (int i = 0; i<6; i++) //one less than max so when one is added to the index it wont break
            {
                for (int j = i; j<5; j++) //one less than max so when one is added to the index it wont break
                {
                    if (GameArray[i, j] != "| # |")
                    {
                        if (GameArray[i, j] == GameArray[i + 1, j + 1])
                        {
                            counter++;
                            if (counter == 3)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            counter = 0;
                        }
                    }
                }
            }

            //diagonal right to left checking                              still have to do this diagonal
            //counter = 0;
            //for (int i = 6; i > 0; i--)
            //{
            //    for (int j = 7; j > 0; j--)
            //    {
            //        if (GameArray[i, j] != "| # |")
            //        {
            //            if (GameArray[i, j] == GameArray[i - 1, j - 1])
            //            {
            //                counter++;
            //                if (counter == 3)
            //                {
            //                    return true;
            //                }
            //            }
            //            else
            //            {
            //                counter = 0;
            //            }
            //        }
            //    }
            //}




            return false;
        }
        public static void PrintGameBoard() //static method so that the changes apply to all objects
        {
            //7 collumns by 6 rows
            Console.WriteLine();

            for (int i=0; i<7; i++)
            {
                for(int j=0; j<7; j++)
                {
                    Console.Write(GameArray[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static bool CheckTurn(char piece, int turn)
        {
            for (int i = 5; i >= 0; i--)
            {
                if (GameArray[i , turn - 1] == "| # |")
                {
                    GameArray[i , turn - 1] = "| " + piece + " |";
                    return true;
                }
            }

            return false; //returning true if the game piece is able to be placed and false if the collumn is full
        }
    }
    public abstract class Player
    {
        public char GamePiece { get; set; }

        public Player(char piece)
        {
            GamePiece = piece;
        }

        public abstract void TakeATurn();

    }
    public class Human : Player
    {
        public string Name { get; set; }
        public Human(char piece, string name) :base(piece)
        {
            Name = name;
        }
        public override void TakeATurn()
        {
            bool TurnCompleted;
            do //let player take a turn untill the pick a collumn that is not full
            {
                Console.WriteLine(Name + " please enter the number of the collumn you wish to place your game piece in: ");
                int turn = Int32.Parse(Console.ReadLine());
                if (turn <= 7 && turn >= 1) //checking for proper collumn number
                {
                    if (Controller.CheckTurn(GamePiece, turn)) // pass the collumn number and the game piece to the print game board to check if it is full
                    {
                        TurnCompleted = true;
                        Console.Clear();
                        Controller.PrintGameBoard();
                    }
                    else
                    {
                        Console.WriteLine("Collumn is full, please place your game piece somewhere else!");
                        TurnCompleted = false; // if the collumn was full, the player's turn is not over and they should pick another collumn number
                    }
                }
                else
                {
                    TurnCompleted = false;
                }

            } while (TurnCompleted == false); 
        }

}
    public class Computer : Player
    {
        public Computer(char piece) : base(piece)
        {

        }
        public override void TakeATurn()
        {
            bool TurnCompleted;
            do 
            {
                Random r = new Random();
                int turn = r.Next(1, 7);

                if (Controller.CheckTurn(GamePiece, turn)) // pass the collumn number and the game piece to the print game board to check if it is full
                {
                    TurnCompleted = true;
                    Console.Clear();
                    Controller.PrintGameBoard();
                }
                else
                {
                    Console.WriteLine("Collumn is full, please place your game piece somewhere else!");
                    TurnCompleted = false; // if the collumn was full, the computer's turn is not over and needs to pick another collumn number
                }

            } while (TurnCompleted == false);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string PlayAgain;

            do
            {

                Console.WriteLine("Input 1 or 2 to Play: \n1: Player VS. Player \n2: Player VS. Computer");
                int MenuInput = Int32.Parse(Console.ReadLine());

                if (MenuInput == 1)
                {
                    Console.WriteLine("Please enter player one's name: ");
                    string PlayerOne = Console.ReadLine();
                    Console.WriteLine(PlayerOne + " You will be playing as 'X' \n\nPlease enter player two's name: ");
                    string PlayerTwo = Console.ReadLine();
                    Console.WriteLine("\n" + PlayerTwo + " You will be playing as 'O'");
                    Human NumOne = new Human('X', PlayerOne);
                    Human NumTwo = new Human('O', PlayerTwo);
                    
                    Controller.PrintGameBoard();

                    for (int i = 1; i <= 42; i++) // total number of spaces on the game board...if no one wims in 42 turns the game is a tie
                    {
                        NumOne.TakeATurn();
                        if (Controller.CheckWin())
                        {
                            Console.WriteLine("Congratulations " + NumOne.Name + "! You Win!");
                            break;
                        }
                        NumTwo.TakeATurn();
                        if (Controller.CheckWin())
                        {
                            Console.WriteLine("Congratulations " + NumTwo.Name + "! You Win!");
                            break;
                        }
                        if (i == 42)
                        {
                            Console.WriteLine("This game is a tie!");
                        }
                    }

                }
                else if (MenuInput == 2)
                {
                    Console.WriteLine("Please enter your name: ");
                    string PlayerName = Console.ReadLine();
                    Console.WriteLine(PlayerName + "You will be playing as 'X'");
                    Human Player = new Human('X' , PlayerName);
                    Computer Comp = new Computer('O');

                    Controller.PrintGameBoard();

                    for (int i = 1; i <= 42; i++) // total number of spaces on the game board...if no one wims in 42 turns the game is a tie
                    {
                        Player.TakeATurn();
                        if (Controller.CheckWin())
                        {
                            Console.WriteLine("Congratulations " + Player.Name + "! You Win!");
                            break;
                        }
                        Comp.TakeATurn();
                        if (Controller.CheckWin())
                        {
                            Console.WriteLine("The Computer is the winner!");
                            break;
                        }
                        if (i == 42)
                        {
                            Console.WriteLine("This game is a tie!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input...Please enter 1 or 2");
                }

                Console.WriteLine("Would you like to play again? (y/n)");
                PlayAgain = Console.ReadLine();
                PlayAgain = PlayAgain.ToUpper();

            } while (PlayAgain == "Y" || PlayAgain == "YES");



            Console.Read();
        }
    }
}