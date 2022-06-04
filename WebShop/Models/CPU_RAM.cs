using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class CPU_RAM
    {
        public int CPU_Id { get; set; }
        public CPU CPU { get; set; }
        public int RAM_Id { get; set; }
        public RAM RAM { get; set; }
    }
}
