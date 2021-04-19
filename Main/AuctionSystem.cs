using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace eAuction_System
{
    public class AuctionSystem
    {
        //TODO: press a button at any time to go back to main menu
        //TODO: add option to delete account if logged in
        //TODO: implement a way for seller to view bid history
        //TODO: implement 'cancel' so that it takes them to previous menu/main menu
        public List<User> allUsers = new List<User>();
        List<Auction> allAuctions = new List<Auction>();
        List<Auction> activeAuctions = new List<Auction>();
        public List<Item> allItems = new List<Item>();
        string usrnme = null;
        string psswrd = null;
        User activeUser = null; //way to see if logged in or not
        string activeMenu = "main";
        Seller currentSeller;
        Buyer currentBuyer;
        DateTime currDate = DateTime.Now;

        public void systemSetup()
        {
            populateActiveAuctions();
            //deseralising from file

            using (Stream fileStream = File.OpenRead("UserData.txt"))
            {
                BinaryFormatter deserializer = new BinaryFormatter();
                allUsers = (List<User>)deserializer.Deserialize(fileStream);
            }
        }
        public void startMenu()
        {
            int response;

            mainHeader();
            do
            {
                response = mainMenu();

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
        public void buyerMenuChoices()
        {
            int response;
            do
            {
                response = buyerMenu();

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
                        viewWonAuctions();
                        break;
                    case 4:
                        //log out
                        Console.WriteLine("Logging out...");
                        Thread.Sleep(1000);
                        startMenu();
                        break;
                    default:
                        Console.WriteLine("Your option must be a number (0-4) try again.");
                        break;
                }
            } while (response > 4 || response != 0);
        }
        public void sellerMenuChoices()
        {
            int response;
            do
            {
                response = sellerMenu();

                int caseSwitch = response;

                switch (caseSwitch)
                {
                    case 0:
                        Console.WriteLine("Now Exiting....Goodbye");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                    case 1:
                        //Sell an Item (Create Auction)
                        createAuction();
                        break;
                    case 2:
                        //View Auction Bids
                        bidOnItem();
                        break;
                    case 3:
                        //Verify Pending Auction
                        viewWonAuctions();
                        break;
                    case 4:
                        //Log Out
                        Console.WriteLine("Logging out...");
                        Thread.Sleep(1000);
                        startMenu();
                        break;
                    default:
                        Console.WriteLine("Your option must be a number (0-4) try again.");
                        break;
                }
            } while (response > 4 || response != 0);
        }
        //check state of auction -  if(getState().Equals(States.ACTIVE))
        private void login()
        {
            usrnme = null;
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
                    startMenu();
                    // ask them if they want to createAccount();
                }
                else
                {
                    do
                    {
                        psswrd = null;
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
                                Console.WriteLine("\n -- Welcome {0}! -- \n", currentSeller.getUsername());
                                Thread.Sleep(1000);
                                sellerMenuChoices();
                            }
                            else if (activeUser is Buyer)
                            {
                                activeMenu = "Buyer";
                                currentBuyer = (Buyer)activeUser;
                                Console.WriteLine("\n -- Welcome {0}! -- \n", currentBuyer.getUsername());
                                Thread.Sleep(1000);
                                buyerMenuChoices();
                            }
                        }
                        else if (!findUsername(usrnme).passCheck(psswrd))
                        {
                            Console.WriteLine("Incorrect password.");
                        }
                    } while (!findUsername(usrnme).passCheck(psswrd));
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
                lock(allUsers) //makes sure no multi threading
                {
                    allUsers.Add(new Buyer(newUsrnme, newPass));
                }

                //writes to binary file
                using (Stream fileStream = File.Open("UserData.txt", FileMode.Create))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(fileStream, allUsers);
                }

                /*
                Stream stream = File.Open("UserData.txt", FileMode.Create);
                IFormatter formatter = new BinaryFormatter();

                // Send the object data to the file
                formatter.Serialize(stream, allUsers);
                stream.Close();


                //@".data\\UserData.xml **relative path**
                using (Stream fs = new FileStream(@"C:\Users\prais\Documents\Programming\Uni\Semester 2 - Object Oriented\eAuction System\data\\UserData.xml",
                    FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                    serializer.Serialize(fs, allUsers);
                }
                */

                Console.WriteLine("Your account has been successfully created");
                login();
            }
            else if (acctype == "seller")
            {
                lock (allUsers)
                {
                    allUsers.Add(new Seller(newUsrnme, newPass));
                }
                Console.WriteLine("Your account has been successfully created, please enter");
                login();
            }
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
            bool redo = true;
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

                    if (findAuctionByID(aucID) == null)
                    {
                        Console.WriteLine("An auction with that ID number doesn't exist please try again");
                    }
                    else
                    {
                        Console.WriteLine(findAuctionByID(aucID).displayAuction());
                    }
                } while (findAuctionByID(aucID) == null);

                do
                {
                    Console.Write("Amount you want to bid for: £");
                    while (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine("That is not a valid response please try again.");
                        Console.Write("Please enter the amount you would like to bid: £");
                    }
                    amount = value;

                    foreach (Auction auc in activeAuctions)
                    {
                        if (auc.getAuctionID() == aucID)
                        {
                            if (auc.checkBidAmount(amount))
                            {
                                auc.placeBid(aucID, currentBuyer.getUserID(), amount, currDate.Date);
                                Console.WriteLine("--Your bid has been successfully placed");
                                Console.WriteLine("Your ID number for your bid is: {0} please note this down and remember it for future reference", findBid(aucID, amount).getBidID());
                                redo = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("There is a upper and lower bidding increment of 20% and 10% of the starting price, your bid does not meet that.");
                            }
                        }
                    }
                } while (redo == true);
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
        private void viewWonAuctions()
        {
            string input = null;
            List<Auction> wonAucs = new List<Auction>();
            while (activeUser == null)
            {
                Console.WriteLine("You are currently not logged in, please log in now");
                login();
            }
            if (allAuctions.Count != 0) //sees if theres any auctions
            {
                foreach (Auction auc in allAuctions)
                {
                    if (auc.getWinnerID() == activeUser.getUserID()) //checks if user is winner
                    {
                        wonAucs.Add(auc);
                    }
                }
                if (wonAucs.Count == 0)
                {
                    Console.WriteLine("\n -- Sorry, you have not won any auctions:(-- \n");
                    Thread.Sleep(1000);
                    buyerMenu();
                }
                else
                {
                    Console.WriteLine("Here are the auctions you have won: ");
                    foreach (Auction aucs in wonAucs)
                    {
                        Console.WriteLine("ID: " + aucs.getItem().getItemID() + ", " + aucs.getItem().getDescription() + ". Seller: " + aucs.getSeller());
                    }
                    do
                    {
                        do
                        {
                            Console.Write("Finished? [Y/N]: ");
                            input = Console.ReadLine().ToUpper();
                        } while (String.IsNullOrEmpty(input));

                        if (input == "Y")
                        {
                            buyerMenu();
                        }
                        else if (input == "N")
                        {
                            Thread.Sleep(9000);
                        }
                        else
                        {
                            Console.WriteLine("That was an incorrect input try again");
                        }
                    } while (input != "Y" && input != "N");
                }
            }
            else
            {
                Console.WriteLine("\n -- There are no auctions in the system!-- \n");
                Thread.Sleep(1000);
                buyerMenu();
            }
        }
        private void createAuction()
        {
            bool repeat = true;
            string response = null;
            string title = null;
            string desc = null;
            double start;
            double reserve;
            DateTime closing;
            Item itemToSell;
            Seller aucSeller;
            Auction currAuc;

            Console.WriteLine("\n -- You first need to create an item to list -- \n");
            Console.WriteLine("\n -- Create your item -- \n");
            //TODO: check if it already exists
            do
            {
                Console.WriteLine("Please enter the name of the item: ");
                title = Console.ReadLine();
                if (findItem(title) == null)
                {
                    repeat = false;
                    do
                    {
                        Console.WriteLine("Please enter the description of the item: ");
                    } while (!String.IsNullOrEmpty(desc));
                    desc = Console.ReadLine();
                    allItems.Add(new Item(title, desc));
                    Console.WriteLine("\n -- Your item has been created -- \n");

                    Console.WriteLine("\n -- Create an auction -- \n");

                    //TODO: Validation for input types
                    Console.Write("Please enter the starting price: £");
                    start = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Please enter the reserve price: £");
                    reserve = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Please enter the date you would like the auction to close (dd/mm/yyyy 00:00): ");
                    closing = Convert.ToDateTime(Console.ReadLine());
                    //checkclosedate
                    itemToSell = findItem(title);
                    aucSeller = (Seller)activeUser;

                    allAuctions.Add(new Auction(start, reserve, closing, itemToSell, aucSeller));

                    currAuc = findAuctionByItem(findItem(title)); //sets state to pending

                    do
                    {
                        do
                        {
                            Console.WriteLine("Verify auction? [Y/N]");
                            response = Console.ReadLine().ToUpper();
                        } while (String.IsNullOrEmpty(response));

                        if (response == "Y")
                        {
                            currAuc.startAuction();
                            Console.WriteLine("\n -- Auction Started -- \n");
                        }
                        else if (response == "N")
                        {
                            currAuc.verifying();
                            Console.WriteLine("Auction created but not started, you can verify the auction though the seller menu");
                        }
                        else
                        {
                            Console.WriteLine("That was an incorrect input try again");
                        }
                    } while (response != "Y" && response != "N");
                    populateActiveAuctions();
                    sellerMenu();
                }
                else
                {
                    Console.WriteLine("An item with this title already exists, please re-enter.");
                }
            } while (String.IsNullOrEmpty(title) || repeat == true);

        }
        private Bid findBid(int aucID, double amt)
        {
            foreach (Auction auc in activeAuctions)
            {
                if (auc.getAuctionID() == aucID)
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
            return null;
        }
        //put into a method to help re
        private Auction findAuctionByItem(Item item)
        {
            foreach (Auction auc in allAuctions)
            {
                if (auc.getItem() == item)
                {
                    return auc;
                }
                break;
            }
            return null;
        }
        private Auction findAuctionByID(int idNum)
        {
            foreach (Auction auc in activeAuctions)
            {
                if (auc.getAuctionID() == idNum)
                {
                    return auc;
                }
                break;
            }
            return null;
        }
        private void populateActiveAuctions()
        {
            foreach (Auction auc in allAuctions)
            {
                if (auc.getState().Equals(States.ACTIVE))
                {
                    activeAuctions.Add(auc);
                }
            }
        }
        private User findUsername(string username)
        {
            lock (allUsers)
            {
                foreach (User user in allUsers)
                {
                    if (user.getUsername().Equals(username))
                    {
                        return user;
                    }
                }
                return null;
            }
        }
        private Item findItem(string title)
        {
            Item toReturn = null;
            foreach (Item thing in allItems)
            {
                if (thing.getTitle() == title)
                {
                    toReturn = thing;
                }
                else
                {
                    Console.WriteLine(thing.getTitle());
                }
            }
            return toReturn;
        }
        //return a Seller with specified username
        private Seller getSellerByName(String username)
        {
            foreach (User user in allUsers)
            {
                if (user.getUsername().Equals(username))
                {
                    if (user is Seller)
                    {
                        return (Seller)user;
                    }

                }
            }
            return null;
        }
        //return a Buyer with specified username
        private Buyer getBuyerByName(String username)
        {
            lock (allUsers)
            {
                foreach (User user in allUsers)
                {
                    if (user.getUsername().Equals(username))
                    {
                        if (user is Buyer)
                        {
                            return (Buyer)user;
                        }
                    }
                }
                return null;
            }

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
        public bool checkCloseDate(DateTime dateToCheck)
        {
            if ((dateToCheck - DateTime.Now).TotalDays <= 7)
            {
                return true;
            }
            else
            {
                return false;
            }
            //TODO: format date before its been set
        }
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
        /*
         * I want to find a way to put it in a method
        private void SerializeObjects()
        {

        }
        */

        //Menus & Headers//
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
        public void buyerHeader()
        {
            Console.WriteLine();
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine("|            Buyer Menu           |");
            Console.WriteLine("+---------------------------------+");
            Console.WriteLine();
        }
        public int buyerMenu()
        {
            buyerHeader();
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
            sellerHeader();
            Console.WriteLine("-- Please Make A Selection --\n");
            Console.WriteLine("(1) Sell an Item (Create Auction)"); //add each auction to list in system
            Console.WriteLine("(2) View Auction Bids");
            Console.WriteLine("(3) Verify Pending Auction");
            Console.WriteLine("(4) Log Out");
            Console.WriteLine("(0) Exit:");
            Console.Write("Enter your choice: \n");

            string input = Console.ReadLine();
            int output = inputChecker(input);
            return output;
        }
    }
}
