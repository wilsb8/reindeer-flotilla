using System;
namespace War
{


    public class Validation
    {

        // Integer
        public static int Integer(string message)
        {
            int number;
            while (!(int.TryParse(message, out number)) || (number < 0))
            {
                Console.Write("Please enter a non-negative numeric value: ");
                message = Console.ReadLine();
            }

            return number;
        }

        // String

        public static string MyString(string mystring)
        {
            if (string.IsNullOrEmpty(mystring))
            {
                Console.Write("Empty or invalid string. Re-enter:  ");
                mystring = Console.ReadLine();
            }

            return mystring;
        }


    }
}


