using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;

namespace WebShop.Models
{
    public class CPU
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Power_usage { get; set; }
        public string Description { get; set; }
        public CPU_Type CPU_Type { get; set; }
    }
}
