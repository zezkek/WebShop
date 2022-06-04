using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;

namespace WebShop.Models
{
    public class RAM
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public RAM_Type RAM_Type { get; set; }
        public List<RAM_Motherboard> RAM_Motherboards { get; set; }
        public List<CPU_RAM> CPU_RAMs { get; set; }
    }
}
    