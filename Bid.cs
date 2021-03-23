using System;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    public class Bid
    {
        System.Random random = new System.Random();
        private int bidID;
        private int auctionID;
        private int buyerID;
        private double amount;
        private DateTime when;

        public Bid(double Amount)
        {

        }

        public void setBidID()
        {
            bidID = random.Next();
        }
        public int getBidID()
        {
            return bidID;
        }

        public void setAuctionID(int idNum)
        {
            auctionID = idNum;
        }
        public int getBidID()
        {
            return bidID;
        }
        public void setAmount(int bidAmount)
        {
            amount = bidAmount;
        }
    }
    // private int BidID = rnd.Next(1, 5000);
}
