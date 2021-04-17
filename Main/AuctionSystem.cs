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
                        Console.WriteLine("1");
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
            Console.Write("Please enter your username: ");
            string usrnme = Console.ReadLine();
            Console.Write("Please enter your password: ");
            string psswrd = Console.ReadLine();

            User user = findUsername(usrnme);

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
        }
    }
}
