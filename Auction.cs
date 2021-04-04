using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    class Auction
    {
        ArrayList bidList = new ArrayList();
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

        }

    }
}
