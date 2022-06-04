using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class RAM_Motherboard
    {
        public int RAM_Id { get; set; }
        public RAM RAM { get; set; }
        public int Motherboard_Id { get; set; }
        public Motherboard Motherboard { get; set; }
    }
}
