using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ItemToSell
    {
        public int ItemId { get; set; }
        public int ItemType { get; set; }
        public double ItemPrice { get; set; }
        public string ItemDescrip { get; set; }
        public string ItemName { get; set; }
    }
}
