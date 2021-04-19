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
    public class Item : ISerializable
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

        //SerializationInfo info holds key value pairs
        //To serialize data
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Item ID", itemID);
            info.AddValue("Title", title);
            info.AddValue("Item Description", description);
        }
        //To deserialize data
        public Item(SerializationInfo info, StreamingContext context)
        {
            itemID = (int)info.GetValue("Item ID", typeof(int));
            title = (string)info.GetValue("Title", typeof(string));
            description = (string)info.GetValue("Item Description", typeof(string));


        }
    }
}
