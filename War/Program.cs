using System;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("\tWAR!");
            Console.WriteLine("========================");
            Console.Write("\nPress ENTER to continue...");
            Console.ReadLine();

            Console.Write("\nEnter a name for Player 1: ");
            string playerOne = Console.ReadLine();
            while(string.IsNullOrEmpty(playerOne))
            {
                Console.Write("Empty or invalid string. Re-enter:  ");
                playerOne = Console.ReadLine();
            }

            Console.Write("\nEnter a name for Player 2: ");
            string playerTwo = Console.ReadLine();
            while (string.IsNullOrEmpty(playerTwo))
            {
                Console.Write("Empty or invalid string. Re-enter:  ");
                playerTwo = Console.ReadLine();
            }

            Console.WriteLine("\nWe have " + playerOne + " and " + playerTwo + ".\n");
            Console.WriteLine("Press ENTER to continue...");
            Console.ReadLine();

            WarApp war = new WarApp(playerOne, playerTwo);


        }
    }
}
