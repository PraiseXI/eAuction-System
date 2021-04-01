using System;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    public class seller : user
    {
        private string firstName { get; set; }
        private string lastName { get; set; }

        private int sellerID;

        public seller (int num, string usrname, string passwrd) : base(num, usrname, passwrd)
        {
            sellerID = base.getUserID();
        }

    }
}
