using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace eAuction_System
{
    public class AuctionSystem
    {
        private List<User> allUsers = new List<User>();
        string usrnme = null;
        string psswrd = null;
        User activeUser = null;
        string activeMenu = "main";
        public void start()
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
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                        break;
                    case 1:
                        login();
                        break;
                    case 2:
                        Console.WriteLine("2");
                        break;
                    case 3:
                        Console.WriteLine("3");
                        break;
                    default:
                        Console.WriteLine("Your option must be a number (0-3) try again.");
                        break;
                }
            } while (response > 3 || response != 0);

            Console.WriteLine("It's going to start again");
            Console.WriteLine();

        }

        //checkbid amount method
        //check state of auction -  if(getState().Equals(States.ACTIVE))

        private void login()
        {
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
                        //checks to see if seller or buyer to change menu
                        if (activeUser is Seller)
                        {
                            activeMenu = "Seller";
                        }
                        else if (activeUser is Buyer)
                        {
                            activeMenu = "Buyer";
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
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
             * an alternative way of checking if suser
            if (user is Seller)
            {

            }
            */
        }

        //return a Seller with specified username if there is one, otherwise returns null
        public Seller getSellerByName(String username)
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

        //return a Buyer with specified username if there is one, otherwise returns null
        public Buyer getBuyerByName(String username)
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
        public bool emptyCheck(string input)
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

    }
}
