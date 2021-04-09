using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    public class Buyer : User
    {
        // Will be added to this based on Auction ID
        private List<Auction> wonAuctions = new List<Auction>();
        //Linked list will contain all bids that buyer has made
        private List<Bid> buyerBids = new List<Bid>();
        public Buyer(string usrname, string passwrd) : base(convertToLower(usrname), convertToLower(passwrd))
        {

        }
        public List<Bid> getBids()
        {
            return buyerBids;
        }
        private static string convertToLower(string text)
        {
            return text.ToLower();
        }
    }
}
