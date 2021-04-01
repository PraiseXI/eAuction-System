using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace eAuction_System
{
    class item
    {
        Random random = new Random();
        private int itemID;
        private string title;
        private string description;

        public item (string title, string desc)
        {
            this.itemID = random.Next(1, 1000);
            setTitle(title);
            setDescription(desc);
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
    }
}
