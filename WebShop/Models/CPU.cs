using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Data.Base;

namespace WebShop.Models
{
    public class CPU : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Power_usage { get; set; }
        public string Description { get; set; }
        public RAM_Type RAM_Type { get; set; }
        public CPU_Type CPU_Type { get; set; }
        public List<CPU_Motherboard> CPU_Motherboards { get; set; }
        public List<CPU_RAM> CPU_RAMs { get; set; }
    }
}
