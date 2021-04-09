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
        private string when;

        public Bid(int auction, int buyer, double amount, DateTime date)
        {
            this.bidID = bidID = random.Next(1, 5000);
            this.auctionID = auction;
            this.buyerID = buyer;
            this.amount = amount;
            string formatdate = date.ToShortDateString();
            this.when = formatdate;
        }
        public string display()
        {
            string text = "Your bid is #" + bidID + " for auction #" + auctionID + ", for £" + amount + " on " + DateTime.Now.ToString("dddd, dd MMMM yyyy") + ".";
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
        //-- this is just here for me to visually separate it as I find it hard to look at all at once
        public void setAuctionID(int idNum)
        {
            auctionID = idNum;
        }
        public int getAuctionID(string desc)
        {
            return auctionID;
        }
        //--
        public void setBuyerID(int buyer)
        {
            this.buyerID = buyer;
        }
        public int getBuyerID()
        {
            return buyerID;
        }
        //--
        public void setAmount(double bidAmount)
        {
            String.Format("{0:0.00}", bidAmount);
            amount = bidAmount;
        }
        public double getAmount()
        {
            return amount;
        }
        //--
        public void setWhen(string when)
        {
            String.Format("{0:0.00}", when);
            this.when = when;
        }
        //--
        public string getWhen()
        {
            return when;
        }
    }
}
