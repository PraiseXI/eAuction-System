using System;

namespace eAuction_System
{
    class EntryProgram
    {
        static void Main(string[] args)
        {
            while(true)
            {
                AuctionSystem a = new AuctionSystem();
                a.buyerMenu();
            }

        }
    }
}
