using System;

namespace eAuction_System
{
    class EntryProgram
    {
        static void Main(string[] args)
        {
            AuctionSystem a = new AuctionSystem();
            a.systemSetup();
            while (true)
            {
                a.buyerMenu();
            }

        }
    }
}
