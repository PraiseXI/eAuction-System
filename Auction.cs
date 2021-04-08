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
        private Buyer winner;
        private Bid highestBid;

        public Auction(double startPrice, double reservePrice, DateTime closingDate, Item auctionitem, Seller auctionSeller)
        {
            this.auctionID = random.Next(1, 5000);
            this.startingPrice = startPrice;
            this.reservePrice = reservePrice;
            do
            {
                if (checkCloseDate(closingDate))
                {
                    this.closingDate = closingDate;
                }
                else
                {
                    Console.WriteLine("You are allowed to have a closing date 7 or less days that the current date");
                }
                //TODO: format date before its been set
            }
            while (checkCloseDate(closingDate) == false);
            this.auctionItem = auctionitem;
            this.auctionSeller = auctionSeller;
            this.state = States.PENDING;
        }
        public void setAuctionID()
        {
            //TODO: Make sure that the random numbers are unique
            this.auctionID = random.Next(1, 5000);
        }
        public int getAuctionID()
        {
            return auctionID;
        }
        public double getStartPrice()
        {
            return startingPrice;
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
                if ((date - DateTime.Now).TotalDays <= 7)
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
        public List<Bid> getAllBids()
        {
            return this.bidList;
        }
        public void setState(States status)
        {
            this.state = status;
        }
        public void placeBid(int auctionID, int buyerID, double howMuch, DateTime when)
        {
            //TODO: checks for amount and datetime
            new Bid(auctionID, buyerID, howMuch, when);
        }
        public States verifying()
        {
            return state = States.PENDING;
        }
        //list should already be arranged as you cannot add a bid unless it is greater than previous, so i just need to select the last element
        public int getHighestBid()
        {
            Bid winner = Enumerable.Max(getAllBids(), Comparer.C
            //TODO: add error check for if there is no bids.
            //last element should be the highest as it adds higher bids.
            int highest = bidList.Last().getBuyerID();
            return highest;
        }
        public bool checkCloseDate(DateTime dateToCheck)
        {
            if ((dateToCheck - DateTime.Now).TotalDays <= 7)
            {
                return true;
            }
            else
            {
                return false;
            }
                //TODO: format date before its been set
        }
        public string displayAuction()
        {
            return String.Format("This auction is #{0} by {1} for {2}, with a starting price of £{3}, with a reserve price of: £{4}, which closes on: {5}", this.auctionItem.getID(), this.auctionSeller, this.auctionItem.getDescription(), this.startingPrice, this.reservePrice, this.closingDate);
        }
        /*
        public bool checkBidAmount(double amount)
        {
            //20% upper, 10% lower
            double lower = startingPrice + (startingPrice / 10);
            double upper = startingPrice + (startingPrice / 20);
            // IEnumerable<double> range = Enumerable.Range(lower, upper).Contains();
            foreach (Bid b in bidList)
            {
            if (IEnumerable<double> range = Enumerable.Range(lower, upper).Contains( ))
                {

                }
            }


        }
        */



    }
}
