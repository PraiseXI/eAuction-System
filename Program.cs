using System;

namespace eAuction_System
{
    class Program
    {
        public static void stringCheck(string word)
        {
            do
            {
                if (String.IsNullOrEmpty(word) == true)
                {
                    Console.WriteLine("Entry can't be empty, please try again: ");
                    Console.ReadLine();
                }
            }
            while (String.IsNullOrEmpty(word) == true);
        }
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }
}
