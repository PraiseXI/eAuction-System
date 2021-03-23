using System;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    public class Bid
    {
        Random random = new Random();
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
            //TODO: Make sure that the random numbers are unique
            bidID = random.Next(1,5000);
        }
        public int getBidID()
        {
            return bidID;
        }

        public void setAuctionID(int idNum)
        {
            auctionID = idNum;
        }
        public int getAuctionID(string desc)
        {
            return auctionID;
        }
        public void setAmount(int bidAmount)
        {
            amount = bidAmount;
        }
    }
}
