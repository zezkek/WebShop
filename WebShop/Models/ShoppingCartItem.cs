using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ItemType { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
