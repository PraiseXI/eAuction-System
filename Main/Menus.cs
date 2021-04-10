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
            Console.WriteLine();
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|     Welcome to the eAuction     |");
            Console.WriteLine("+---------------------------------+");
        }
        public void sellerheader()
        {
            Console.WriteLine();
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|           Seller Menu           |");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine();
        }
        public void buyerheader()
        {
            Console.WriteLine();
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|            Buyer Menu           |");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine();
        }
        public int mainMenu()
        {
            Console.WriteLine("-- Please Make A Selection --\n");
            Console.WriteLine("(1) Log In");
            Console.WriteLine("(2) Set Up an Account");
            Console.WriteLine("(3) Browse Auctions");
            Console.WriteLine("(0) Exit");
            Console.Write("Enter your choice: \n");

            //Ensures number is an int to save time later down the road
            while (!int.TryParse(Console.ReadLine(), out int x))
            {
                Console.Write("Your option must be a number (0-3) try again: ");
            }

            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            switch (caseSwitch)
            {
                case 0:
                    return 0;
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
        public int buyerMenu()
        {
            this.buyerheader();
            Console.WriteLine("-- Please Make A Selection --\n");
            Console.WriteLine("(1) Browse All Active Auctions");
            Console.WriteLine("(2) Bid on Item");
            Console.WriteLine("(3) View All Auctions You've Won");
            Console.WriteLine("(4) Log Out");
            Console.WriteLine("(0) Exit");
            Console.Write("Enter your choice: \n");

            //Ensures number is an int to save time later down the road
            while (!int.TryParse(Console.ReadLine(), out int x))
            {
                Console.Write("Your option must be a number (0-4) try again: ");
            }

            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            switch (caseSwitch)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 4;
                default:
                    return caseSwitch;
            }
        }
        public int sellerMenu()
        {
            this.sellerheader();
            Console.WriteLine("-- Please Make A Selection --\n");
            Console.WriteLine("(1) Sell an Item (Create Auction)");
            Console.WriteLine("(2) View Auction Bids");
            Console.WriteLine("(3) Verify Pending Auction");
            Console.WriteLine("(4) Log Out");
            Console.WriteLine("(0) Exit:");
            Console.Write("Enter your choice: \n");

            //Ensures number is an int to save time later down the road
            while (!int.TryParse(Console.ReadLine(), out int x))
            {
                Console.Write("Your option must be a number (0-4) try again: ");
            }

            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            switch (caseSwitch)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 4;
                default:
                    return caseSwitch;
            }
        }
        /*
         * I was going to put it in a separate method however this just complicates it.
        public void inputChecker()
        {

        }
        */
    }
}
