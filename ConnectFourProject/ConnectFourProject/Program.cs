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
    public class CheckForWin
    {

    }
    public class PlayerVsPlayer : CheckForWin
    {

    }
    public class PlayerVsComputer : CheckForWin
    {

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
                    Console.WriteLine("num 1");
                }
                else if (MenuInput == 2)
                {
                    Console.WriteLine("num 2");
                }
                else
                {
                    Console.WriteLine("Invalid Input...Please enter 1 or 2");
                }

                Console.WriteLine("Would you like to Play again? (y/n)");
                PlayAgain = Console.ReadLine();
                PlayAgain = PlayAgain.ToUpper();

            } while (PlayAgain == "Y" || PlayAgain == "YES");



            Console.Read();
        }
    }
}