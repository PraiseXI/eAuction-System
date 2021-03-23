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

        public Bid(int auction, int buyer, double Amount, DateTime date)
        {
            this.bidID = getBidID();
            this.auctionID = auction;
            this.buyerID = buyer;
            this.amount = Amount;
            this.when = date;
        }

        public string displayBid()
        {
            string text = "Your bid is #" + bidID + " for auction #" + auctionID + ", for £" + amount + " on " + when + ".";
            return text;
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
