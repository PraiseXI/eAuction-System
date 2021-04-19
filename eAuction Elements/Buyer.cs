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
    public class Buyer : User, ISerializable
    {
        // Will be added to this based on Auction ID
        private List<Auction> wonAuctions = new List<Auction>();
        //Linked list will contain all bids that buyer has made - *might not need*
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
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("User ID Number", userID);
            info.AddValue("Username", username);
            info.AddValue("Password", password);
        }
        //To deserialize data
        public Buyer(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            userID = info.GetString("User ID Number");
            username = info.GetString("Username");
            password = info.GetString("Password");

        }
    }
}
