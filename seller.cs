﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    public class seller : user
    {
        //list is used as the storage size will constantly change
        private LinkedList<item> itemslist = new LinkedList<item>();
        public seller (int num, string usrname, string passwrd) : base(num, convertToLower(usrname), convertToLower(passwrd))
        {

        }
        private static string convertToLower(string text)
        {
            return text.ToLower();
        }
        public LinkedList<item> getAllItems()
        {
            return itemslist;
        }

        /*
         * wanted to implement a way to delete an item however it is not required, will go back if I have time
        public item deleteItem(int idNum)
        {
            foreach (item thing in itemslist)
            {
                if (thing.getID().Equals(idNum))
                {
                    context.DeleteObject
                }
            }
            return null;
        }
        */
    }
}
