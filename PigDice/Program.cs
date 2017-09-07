using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDice
{
    class Program
    {
        static Random rnd = new Random();       // Random object for our dice rolls

        // Entry point into the program
        static void Main(string[] args)
        {
            new Program().Run();
        }

        // Output a string to the console
        void Print(string s)
        {
            Console.Write(s);
        }

        // Output a line of text
        void PrintLine(string s)
        {
            Console.WriteLine(s);
        }

        // Prints a number in ordinal form (WIP)
        void PrintOrdinal(int i)
        {
            Console.Write(i.ToString());

            if (i > 13)         // If we're out of the teens, we just need the last digit
                i = i % 10;

            switch (i)
            {
                case 1:
                    Print("st");
                    break;
                case 2:
                    Print("nd");
                    break;
                case 3:
                    Print("rd");
                    break;
                default:
                    Print("th");
                    break;
            }
        }

        // Returns a random integer between 1 and 6
        int RollDie()
        {
            return rnd.Next(6) + 1;
        }

        // Plays a round of Pig Dice and returns the score
        int PigDice()
        {
            int DieRoll = 2;    // Stores our current roll
            int RollNumber = 0; // How many rolls in this game
            int Score = 0;      // Total score for this game

            while (true)        // Go forever, 1 roll per loop
            {
                DieRoll = RollDie();    // Roll the die
                if (DieRoll == 1)       // If we roll a 1 it's game over
                {   // Game over, inform the user and break from the loop
                    PrintLine("Oops! Rolled a 1.\nGAME OVER.");
                    break;
                }
                RollNumber++;           // +1 successful roll
                Score += DieRoll;       // Add the roll to our score

                // Print ordinal of our roll number and our current score
                PrintOrdinal(RollNumber);
                Print(" roll: ");
                Print(DieRoll.ToString());
                Print(" Current Score: ");
                PrintLine(Score.ToString());
            }

            // Game is over, return our score
            return Score;
        }

        // Application logic
        void Run()
        {
            int GameNumber = 1;     // Number of games played
            int Score = 0;          // Score of the last game played
            int TopScore = 0;       // Top score for this instance of the program
            ConsoleKeyInfo PressedKey = new ConsoleKeyInfo();   // Place to store a single 

            // Send a greeting and wait until a key is pressed
            PrintLine("Welcome to Pig Dice!\nPress any key to continue.");
            Console.ReadKey(true);

            while (true)                            // Go until I say, stop
            {
                Console.Clear();                    // Clear the screen
                Print("Game number ");              // Announce current game number
                PrintLine(GameNumber++.ToString());
                Score = PigDice();                  // Play a full game of Pig Dice

                if (Score > TopScore)               // Do we have a new top score?
                    TopScore = Score;               // Yes, save it
                Print("Current Top Score: ");       // And then print it
                PrintLine(TopScore.ToString());

                // Wait for user input
                PrintLine("Press any key to continue or \'q\' to quit.");
                PressedKey = Console.ReadKey(true);
                if (PressedKey.KeyChar == 'q')      // If we get a q, quit, otherwise play again
                    break;
            }
        }
    }
}
