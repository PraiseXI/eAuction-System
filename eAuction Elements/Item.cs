using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Linq;

namespace eAuction_System
{
    public class Item
    {
        Random random = new Random();
        private int itemID;
        private string title;
        private string description;

        public Item (string title, string desc)
        {
            this.itemID = random.Next(1, 1000);
            setTitle(title);
            setDescription(desc);
        }
        public void setItemID()
        {
            //TODO: Make sure that the random numbers are unique
            this.itemID = random.Next(1, 5000);
        }
        public int getItemID()
        {
            return itemID;
        }
        public void setDescription(string itemDesc)
        {
            this.description = itemDesc;
        }
        public string getDescription()
        {
            return description;
        }
        public void setTitle(string title)
        {
            this.title = title;
        }
        public string getTitle()
        {
            return title;
        }
        public int getID()
        {
            return itemID;
        }
    }
}
