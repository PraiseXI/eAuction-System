using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace eAuction_System
{
    class Auction
    {
        List<Bid> bidList = new List<Bid>();
        // maybe implement a stack for the bidID of the bids, instead of storing whole bid
        // it would check to see if the bid amount is high enough, then it would get the bidID and add it to the stack
        //so that at the end you would just need to take the top value and then get the bid info based on that bidID
        private int auctionID;
        private double startingPrice;
        private double reservePrice;
        private DateTime closingDate;
        private Item auctionItem;
        private Seller auctionSeller;
        private States state;

        public Auction(double startPrice, double reservePrice, DateTime closingDate, Item auctionitem, Seller auctionSeller, States state)
        {
            this.startingPrice = startPrice;
            this.reservePrice = reservePrice;
            this.closingDate = closingDate;
            this.auctionItem = auctionitem;
            this.auctionSeller = auctionSeller;
            this.state = state;
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
        private int getHighestBid()
        {
            //TODO: add error check for if there is no bids.
            var highest = bidList.Last().getBidID();
            return highest;
        }

    }
}
