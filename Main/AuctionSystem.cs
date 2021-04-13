using System;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    public class AuctionSystem
    {
        public void start()
        {
            int response;
            Menus menu = new Menus();
            menu.mainHeader();
            do
            {
                menu.mainMenu();
                response = menu.mainMenu();

            } while (response > 3);
            Console.WriteLine("done");
            Console.ReadLine();
            //Ensures number is an int to save time later down the road
        }

        //menu loop
        /*
         * for the menu option
         * TODO: make sure there is a do while loop for the menu inputs
        if (caseSwitch == 0)
        {
            Console.WriteLine("Now Exiting....");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
        */
        //checkbid amount method
        //check state of auction -  if(getState().Equals(States.ACTIVE))
    }
}
