using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace eAuction_System
{
    class Auction
    {
        Random random = new Random();
        List<Bid> bidList = new List<Bid>();
        // maybe implement a stack for the bidID of the bids, instead of storing whole bid
        // it would check to see if the bid amount is high enough, then it would get the bidID and add it to the stack
        //so that at the end you would just need to take the top value and then get the bid info based on that bidID4
        private int auctionID;
        private double startingPrice;
        private double reservePrice;
        private DateTime closingDate;
        private Item auctionItem;
        private Seller auctionSeller;
        private States state;

        public Auction(double startPrice, double reservePrice, DateTime closingDate, Item auctionitem, Seller auctionSeller, States state)
        {
            this.auctionID = random.Next(1, 5000);
            this.startingPrice = startPrice;
            this.reservePrice = reservePrice;
            this.closingDate = closingDate;
            this.auctionItem = auctionitem;
            this.auctionSeller = auctionSeller;
            this.state = state;
        }
        public void setAuctionID()
        {
            //TODO: Make sure that the random numbers are unique
            this.auctionID = random.Next(1, 5000);
        }      public int getAuctionID()
        {
            return auctionID;
        }
        public void setStartPrice(double price)
        {
            this.startingPrice = price;
        }
        public double getStartPrice()
        {
            return startingPrice;
        }
        public void setReservePrice(double price)
        {
            this.reservePrice = price;
        }
        public double getReservePrice()
        {
            return reservePrice;
        }
        public void setCloseDate(DateTime date)
        {
            bool valid = false;
            do
            {
                if ((date - DateTime.Now).TotalDays >= 3)
                {
                    valid = true;
                    this.closingDate = date;
                }
                else
                {
                    Console.WriteLine("You are allowed to have a closing date 7 or less days that the current date");
                }
                //TODO: format date before its been set
            }
            while (valid == false);
        }
        public DateTime getClosingDate()
        {
            return closingDate;
        }
        public Seller getSeller()
        {
            return this.auctionSeller;
        }
        public void placeBid(int auctionID, int buyerID, double howMuch, DateTime when)
        {
            new Bid(auctionID, buyerID, howMuch, when);
        }
        public States verifying()
        {
            return state = States.PENDING;
        }
        //list should already be arranged as you cannot add a bid unless it is greater than previous, so i just need to select the last element
        public int getHighestBid()
        {
            //TODO: add error check for if there is no bids.
            var highest = bidList.Last().getBidID();
            return highest;
        }
        /*
        public string displayAuction()
        {

        }
        */
    }
}
