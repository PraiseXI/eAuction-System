using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;


namespace eAuction_System
{
    public class AuctionSystem
    {
        //TODO: press a button at any time to go back to main menu
        //TODO: add option to delete account if logged in
        //TODO: implement a way for seller to view bid history
        private List<User> allUsers = new List<User>();
        List<Auction> activeAuctions = new List<Auction>();
        string usrnme = null;
        string psswrd = null;
        User activeUser = null;
        string activeMenu = "main";
        Seller currentSeller;
        Buyer currentBuyer;
        DateTime currDate = DateTime.Now;

        public void systemSetup()
        {
            populateAuctions();
            //will put all serialisation and adding users

        }
        public void startMenu()
        {
            int response;
            Menus menu = new Menus();

            menu.mainHeader();
            do
            {
                response = menu.mainMenu();

                int caseSwitch = response;

                switch (caseSwitch)
                {
                    case 0:
                        Console.WriteLine("Now Exiting....Goodbye");
                        Thread.Sleep(2000); //delays execution, just for effect :)
                        Environment.Exit(0);
                        break;
                    case 1:
                        login();
                        break;
                    case 2:
                        createAccount();
                        break;
                    case 3:
                        browseAuctions();
                        break;
                    default:
                        Console.WriteLine("Your option must be a number (0-3) try again.");
                        break;
                }
            } while (response > 3 || response != 0);
        }
        public void buyerMenu()
        {
            int response;
            Menus menu = new Menus();
            do
            {
                response = menu.buyerMenu();

                int caseSwitch = response;

                switch (caseSwitch)
                {
                    case 0:
                        Console.WriteLine("Now Exiting....Goodbye");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                    case 1:
                        browseAuctions();
                        break;
                    case 2:
                        //bidonitem
                        bidOnItem();
                        break;
                    case 3:
                        //view all won auctions
                        browseAuctions();
                        break;
                    case 4:
                        //log out
                        Console.WriteLine("Logging out...");
                        Thread.Sleep(2000);
                        startMenu();
                        break;
                    default:
                        Console.WriteLine("Your option must be a number (0-4) try again.");
                        break;
                }
            } while (response > 4 || response != 0);
        }
        //checkbid amount method
        //check state of auction -  if(getState().Equals(States.ACTIVE))
        private void login()
        {
            Console.WriteLine("\n-- Log in --\n");
            //validations for non empty input
            while (String.IsNullOrEmpty(usrnme))
            {
                Console.Write("Please enter your username: ");
                usrnme = Console.ReadLine();
            }
            User user = findUsername(usrnme);
            try
            {
                if (user == null) //checks if user exists
                {
                    //TODO: redirect them to create an account if doesn't exist
                    Console.WriteLine("\n ** This User does not exist **");
                }
                else
                {
                    while (String.IsNullOrEmpty(psswrd))
                    {
                        Console.Write("Please enter your password: ");
                        psswrd = Console.ReadLine();
                    }
                    if (findUsername(usrnme).passCheck(psswrd)) //checks password alongside username
                    {
                        activeUser = user;
                        //checks to see if seller or buyer to change menu and to cast it to the current, so you know who is logged in
                        if (activeUser is Seller)
                        {
                            activeMenu = "Seller";
                            currentSeller = (Seller)activeUser;
                        }
                        else if (activeUser is Buyer)
                        {
                            activeMenu = "Buyer";
                            currentBuyer = (Buyer)activeUser;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }

        }
        private void createAccount()
        {
            string newUsrnme = null;
            string newPass = null;
            string acctype = null;
            bool proceed = false;

            Console.WriteLine("\n-- Create Account --\n");
            do
            {
                Console.Write("Which account would you like to create (Seller/Buyer): ");
                acctype = Console.ReadLine().ToLower();

            } while (string.IsNullOrEmpty(acctype) || isAlphabet(acctype) == false || acctype != "seller" && acctype != "buyer"); //makes sure appropriate input.
            Console.WriteLine("\n --These entries are *case sensitive*-- \n");

            while (String.IsNullOrEmpty(newUsrnme))
            {
                //TODO: make sure that it is not taken
                Console.Write("Please enter your username: ");
                newUsrnme = Console.ReadLine();
                if (findUsername(newUsrnme) != null)
                {
                    Console.Write("This username is already taken try again: ");
                    newUsrnme = null;
                }

            }
            Console.WriteLine("Username set");

            do
            {
                //TODO: mask  password for security measures
                Console.Write("Please enter your password: ");
                newPass = Console.ReadLine();
                /*
                while (true)
                {
                    var key = System.Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    newPass += key.KeyChar;
                }
                */
            } while (String.IsNullOrEmpty(newPass));
            Console.WriteLine("Password set");

            if (acctype == "buyer")
            {
                allUsers.Add(new Buyer(newUsrnme, newPass));
            }
            if (acctype == "seller")
            {
                allUsers.Add(new Seller(newUsrnme, newPass));
            }
            Console.WriteLine("\n Your account has been successfully created");
            Thread.Sleep(2000);
            login();
        }
        //saves time instead of doing a foreach through every user
        private void browseAuctions()
        {
            Console.WriteLine("\n -- All ACTIVE AUCTIONS -- \n");
            if (activeAuctions.Count == 0)
            {
                Console.WriteLine("-- There is no active auctions currently, please try again at another time --");
            }
            foreach (Auction auction in activeAuctions)
            {
                Console.WriteLine(auction.displayAuction());
            }
            Thread.Sleep(3000);
            //TODO: redirect to whether they want to bid on auction
        }
        private void bidOnItem()
        {
            bool exists = false;
            int aucID = 0;
            double amount = 0;
            string response = "";
            //included the option to preview auctions first
            do
            {
                Console.WriteLine("Would you like to browse all active auctions first? (y/n)");
                response = Console.ReadLine().ToLower();
            } while (String.IsNullOrEmpty(response) && !isAlphabet(response));
            if (response == "y")
            {
                browseAuctions();
            }
            else if (response == "n")
            {
                int value = 0;
                Console.WriteLine("-- Please enter the details of the auction you would like to bid on -- ");

                do
                {
                    Console.Write("ID number of auction: ");
                    while (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine("That is not a valid response please try again.");
                        Console.Write("Please enter the ID number of the auction: ");
                    }
                    aucID = value;


                    foreach (Auction auc in activeAuctions)
                    {
                        if (auc.getAuctionID() == aucID)
                        {
                            exists = true;
                            break;
                        }
                    }
                    if (exists == false)
                    {
                        Console.WriteLine("An auction with that ID number doesn't exist please try again");
                    }
                } while (exists == false);


                Console.Write("Amount you want to bid for: £");
                while (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("That is not a valid response please try again.");
                    Console.Write("Please enter the amount you would like to bid: £");
                }
                amount = value;

                foreach (Auction auc in activeAuctions)
                {
                    if (amount >= auc.getStartPrice())
                    {
                        auc.placeBid(aucID, currentBuyer.getUserID(), amount, currDate.Date);
                        Console.WriteLine("--Your bid has been successfully placed");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid response please try again");
                //just recalled the method to avoid another loop
                bidOnItem();
                Thread.Sleep(1000);
            }
        }
        //will get specific Bid details from amount and buyerID
        private Bid findBid(double amt)
        {
            foreach (Auction auc in activeAuctions)
            {
                foreach (Bid bid in auc.getAllBids())
                {
                    if (bid.getAmount() == amt)
                    {
                        return bid;
                    }

                }
            }
        }
        private void populateAuctions()
        {
            foreach (Auction auc in activeAuctions)
            {
                if (auc.getState().Equals(States.ACTIVE))
                {
                    activeAuctions.Add(auc);
                }
            }
        }
        private User findUsername(string username)
        {
            foreach (User user in allUsers)
            {
                if (user.getUsername().Equals(username))
                {
                    return user;
                }
            }
            return null;
            /*
             * an alternative way of checking if user
            if (user is Seller)
            {

            }
            */
        }
        //return a Seller with specified username
        private Seller getSellerByName(String username)
        {
            foreach (User user in allUsers)
            {
                if (user.getUsername().Equals(username))
                {
                    try
                    {
                        return (Seller)user;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error: " + e);
                    }
                }
            }
            return null;
        }
        //return a Buyer with specified username
        private Buyer getBuyerByName(String username)
        {
            foreach (User user in allUsers)
            {
                if (user.getUsername().Equals(username))
                {
                    try
                    {
                        return (Buyer)user;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error: " + e);
                    }
                }
            }
            return null;

        }
        private bool emptyCheck(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool isAlphabet(string inputString)
        {
            Regex r = new Regex("^[a-zA-Z ]+$");
            if (r.IsMatch(inputString))
                return true;
            else
                return false;
        }
        //TODO: implementing this just because there will repetition in the menu control for the different menus
        private void menuControl()
        {

        }
    }
}
