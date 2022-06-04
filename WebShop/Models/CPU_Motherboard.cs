using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class CPU_Motherboard
    {
        public int CPU_Id { get; set; }
        public CPU CPU { get; set; }
        public int Motherboard_Id { get; set; }
        public Motherboard Motherboard { get; set; }

    }
}
