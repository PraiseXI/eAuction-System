using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace eAuction_System
{
    [Serializable()]
    public class Bid : ISerializable
    {
        Random random = new Random();
        private int bidID;
        private int auctionID;
        private int buyerID;
        private double amount;
        private DateTime when;

        public Bid(int auction, int buyer, double amount, DateTime date)
        {
            this.bidID = bidID = random.Next(1, 5000);
            this.auctionID = auction;
            this.buyerID = buyer;
            this.amount = amount;
            string formatdate = date.ToShortDateString();
            this.when = date;
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
        public void setWhen(DateTime when)
        {
            this.when = when;
        }
        //--
        public DateTime getWhen()
        {
            return when;
        }
        //To serialize data
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bid ID Number", bidID);
            info.AddValue("Auction ID Number", auctionID);
            info.AddValue("Buyer ID Number", buyerID);
            info.AddValue("Bid Amount", amount);
            info.AddValue("Bid Date", when);
        }
        //To deserialize data
        public Bid(SerializationInfo info, StreamingContext context)
        {
            bidID = (int)info.GetValue("Bid ID Number", typeof(int));
            auctionID = (int)info.GetValue("Auction ID Number", typeof(int));
            buyerID = (int)info.GetValue("Buyer ID Number", typeof(int));
            amount = (double)info.GetValue("Bid Amount", typeof(double));
            when = (DateTime)info.GetValue("Bid Date", typeof(DateTime));

        }

    }
}
