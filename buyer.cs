using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    public class Buyer : User
    {
        // Will be added to this based on Auction ID
        private ArrayList wonAuctions = new ArrayList();
        //Linked list will contain all bids that buyer has made
        private ArrayList buyerBids = new ArrayList();
        public Buyer(int num, string usrname, string passwrd) : base(num, convertToLower(usrname), convertToLower(passwrd))
        {

        }
        public ArrayList getBids()
        {
            return buyerBids;
        }
        private static string convertToLower(string text)
        {
            return text.ToLower();
        }
        /*
            foreach (Bid x in buyerBids)
            {
                if  (x.getBuyerID == )
            }
        */
    }
}
