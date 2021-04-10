using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace eAuction_System.Main
{
    public class Menus
    {
        //headers just for visual purposes
        public void mainheader()
        {
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|     Welcome to the eAuction     |");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine();
        }
        public void sellerheader()
        {
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|           Seller Menu           |");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine();
        }
        public void buyerheader()
        {
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|            Buyer Menu           |");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine();
        }
        public int mainMenu()
        {

            Console.WriteLine("Please Make A Selection: \n");
            Console.WriteLine("1) Log In:");
            Console.WriteLine("2) Set Up an Account:");
            Console.WriteLine("3) Browse Auctions:");
            Console.WriteLine("0) Exit:");
            Console.WriteLine("Enter your choice: \n");

            //Ensures number is an int to save time later down the road
            while (!int.TryParse(Console.ReadLine(), out int x))
            {
                Console.Write("Your option must be a number (1-4) try again: ");
            }

            int caseSwitch = Convert.ToInt32(Console.ReadLine());

            switch (caseSwitch)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                default:
                    return caseSwitch;
            }
        }

    }
}
