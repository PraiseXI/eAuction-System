using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace eAuction_System
{
    public class Menus
    {
        //headers just for visual purposes
        public void mainHeader()
        {
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|     Welcome to the eAuction     |");
            Console.WriteLine("+---------------------------------+");
        }
        public void sellerHeader()
        {
            Console.WriteLine();
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|           Seller Menu           |");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine();
        }
        public void buyerHeader()
        {
            Console.WriteLine();
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|            Buyer Menu           |");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine();
        }
        public int mainMenu()
        {
            Console.WriteLine("\n-- Main Menu --");
            Console.WriteLine("\n-- Please Make A Selection --\n");
            Console.WriteLine("(1) Log In");
            Console.WriteLine("(2) Create an Account");
            Console.WriteLine("(3) Browse Auctions");
            Console.WriteLine("(0) Exit \n");
            Console.Write("Enter your choice: ");

            string input = Console.ReadLine();

            int output = inputChecker(input);
            return output;
        }
        public int buyerMenu()
        {
            this.buyerHeader();
            Console.WriteLine("\n-- Please Make A Selection --\n");
            Console.WriteLine("(1) Browse All Active Auctions");
            Console.WriteLine("(2) Bid on Item");
            Console.WriteLine("(3) View All Auctions You've Won");
            Console.WriteLine("(4) Log Out");
            Console.WriteLine("(0) Exit");
            Console.Write("Enter your choice: \n");

            string input = Console.ReadLine();

            int output = inputChecker(input);
            return output;

        }
        public int sellerMenu()
        {
            this.sellerHeader();
            Console.WriteLine("-- Please Make A Selection --\n");
            Console.WriteLine("(1) Sell an Item (Create Auction)");
            Console.WriteLine("(2) View Auction Bids");
            Console.WriteLine("(3) Verify Pending Auction");
            Console.WriteLine("(4) Log Out");
            Console.WriteLine("(0) Exit:");
            Console.Write("Enter your choice: \n");

            string input = Console.ReadLine();
            int output = inputChecker(input);
            return output;
        }

        //saves time down the road as makes sure input is in the correct format
        public int inputChecker(string numToCheck)
        {
            //error catch to make sure input is an integer.
            bool valid = false;
            int output;
            do
            {
                if (int.TryParse(numToCheck, out output))
                {
                    valid = true;
                }
                else
                {
                    Console.Write("Please enter a number input: ");
                    numToCheck = Console.ReadLine();
                }
            } while (valid == false);
            return output;
        }

    }
}
