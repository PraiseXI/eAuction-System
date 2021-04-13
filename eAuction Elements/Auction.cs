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
        public DateTime getClosingDate()
        {
            return closingDate;
        }
        public Item getItem()
        {
            return this.auctionItem;
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
        public States getState()
        {
            return state;
        }
        public void placeBid(int auctionID, int buyerID, double howMuch, DateTime when)
        {
            bidList.Add(new Bid(auctionID, buyerID, howMuch, when));
        }
        public void verifying()
        {
            state = States.PENDING;
        }
        public void startAuctionState()
        {
            this.state = States.ACTIVE;
        }
        public void endAuctionState()
        {
            this.state = States.CLOSED;
        }
        //will keep the bid ID of the highest bidder after each bid is placed
        public void setCurrentHighestBid()
        {
        }
        public Bid getHighestBid()
        {
            //put all bids into descending order so the bid with the highest amount highest will be first in the list
            List<Bid> sortedBids = bidList.OrderByDescending(o => o.getAmount()).ToList();

            Bid highest = sortedBids.First();
            return highest;
        }
        /*
        public Buyer getWinner(int highestBidID)
        {
            //based on highest bidID, get details of winner
        }
        */
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
         // TODO: put in system class
        public bool checkBidAmount(double amount)
        {
            bool valid;
            double lower = startingPrice + (startingPrice / 10);
            double upper = startingPrice + (startingPrice / 20);

            if (amount >= lower && amount <= upper)
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;
        }





    }
}
