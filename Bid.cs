using System;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    public class Bid
    {
        Random rnd = new Random();

        private int bidID = rnd;
        private int auctionID;
        private int buyerID;
        private double amount;
        private DateTime when;

        public Bid(double Amount)
        {

        }
    }
    // private int BidID = rnd.Next(1, 5000);
}
