using System;

namespace eAuction_System
{
    class Program
    {
        static void Main(string[] args)
        {
            user Praise = new user();
            Praise.setUsername("praise11");
            string username = Praise.getUsername();
            Console.WriteLine(username);
            Console.ReadLine();

        }
    }
}
