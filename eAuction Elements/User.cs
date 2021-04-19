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
    public class User : ISerializable
    {
        Random random = new Random();
        public int userID;
        public string username;
        public string password;

        public User(string name, string psswrd)
        {
            //TODO: make sure random number doesn't already exist: loop
            this.userID = random.Next(1, 9000);
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
        public int getUserID()
        {
            return userID;
        }
        public void setUsername(string usrnme)
        {
                username = usrnme;
                Console.WriteLine("Username set! Hi {0}", username);
                Console.ReadLine();
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
        //To serialize data
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("User ID Number", userID);
            info.AddValue("Username", username);
            info.AddValue("Password", password);
        }
        //To deserialize data
        public User(SerializationInfo info, StreamingContext context)
        {
            userID = (int)info.GetValue("User ID Number", typeof(int));
            username = (string)info.GetValue("Username", typeof(string));
            password = (string)info.GetValue("Password", typeof(string));

        }

    }
}
