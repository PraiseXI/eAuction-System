using System;
using System.Collections.Generic;
using System.Text;

namespace eAuction_System
{
    class item
    {
        private string description;

        public item (string desc)
        {
            this.description = desc;
        }
        public void setDescription(string itemDesc)
        {
            this.description = itemDesc;
        }

        public string getDescription()
        {
            return description;
        }


    }
}
