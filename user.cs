using System;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    public class user
    {
        Random random = new Random();
        private int userID;
        private string username;
        private string password;
        public void setuserID()
        {
            //TODO: Make sure that the random numbers are unique
            userID = random.Next(1, 5000);
        }
        public int getBidID()
        {
            return userID;
        }

        public void setUsername(string usrnme)
        {
            username = usrnme;
        }
        public string getUsername()
        {
            return username;
        }

        public void setPassword(string psswrd)
        {
            password = psswrd;
        }
        public string getPassword()
        {
            return password;
        }
    }
}
