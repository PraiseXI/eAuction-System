using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace eAuction_System
{
    public class user
    {
        Random random = new Random();
        private int userID;
        private string username;
        private string password;

        public user(int ID, string name, string psswrd)
        {
            this.setUserID();
            this.setUsername(name);

            if (emptyCheck(psswrd) == true)
            {
                Console.WriteLine("Please enter a valid password");
            }
            else
            {
                this.setPassword(psswrd);
            }
        }

        //function loop to check
        /*
        public bool isAlphabets(string inputString)
        {
            Regex r = new Regex("^[a-zA-Z ]+$");
            if (r.IsMatch(inputString))
                return true;
            else
                return false;
        }
        */

        public void setUserID()
        {
            //TODO: Make sure that the random numbers are unique
            userID = random.Next(1, 5000);
        }
        public int getUserID()
        {
            return userID;
        }

        public void setUsername(string usrnme)
        {
            //TODO: make sure that it is not taken
            if (emptyCheck(usrnme) == true)
            {
                Console.WriteLine("This isn't a correct username");
                Console.ReadLine();
            }
            else
            {
                username = usrnme;
                Console.WriteLine("Username set! Hi {0}", username);
                Console.ReadLine();
            }
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
        public bool emptyCheck(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool passCheck(string inputPass)
        {
            return this.password.Equals(inputPass);
        }
    }
}
