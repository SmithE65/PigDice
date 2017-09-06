using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDice
{
    class Program
    {
        static Random rnd = new Random();
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

        // Prints a number in ordinal form
        void PrintOrdinal(int i)
        {
            Console.Write(i.ToString());
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
            int DieRoll = 2;
            int RollNumber = 0;
            int Score = 0;

            while (true)
            {
                DieRoll = RollDie();
                if (DieRoll == 1)
                {
                    PrintLine("Oops! Rolled a 1.\nGAME OVER.");
                    break;
                }
                RollNumber++;

                PrintOrdinal(RollNumber);
                Print(" roll: ");
                Print(DieRoll.ToString());
                Print(" Current Score: ");
                Score += DieRoll;
                PrintLine(Score.ToString());
            }

            return Score;
        }

        // Application logic
        void Run()
        {
            int GameNumber = 1;
            int Score = 0;
            int TopScore = 0;
            ConsoleKeyInfo PressedKey = new ConsoleKeyInfo();

            PrintLine("Welcome to Pig Dice!\nPress any key to continue.");
            Console.ReadKey();

            while (true)
            {
                Console.Clear();
                Print("Game number ");
                PrintLine(GameNumber++.ToString());
                Score = PigDice();

                if (Score > TopScore)
                    TopScore = Score;
                Print("Current Top Score: ");
                PrintLine(TopScore.ToString());
                PrintLine("Press any key to continue or \'q\' to quit.");
                PressedKey = Console.ReadKey(true);
                if (PressedKey.KeyChar == 'q')
                    break;
            }
        }
    }
}
