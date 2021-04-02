using System;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    public class buyer : user
    {
        public buyer(int num, string usrname, string passwrd) : base(num, convertToLower(usrname), convertToLower(passwrd))
        {

        }
        private static string convertToLower(string text)
        {
            return text.ToLower();
        }
    }
}
