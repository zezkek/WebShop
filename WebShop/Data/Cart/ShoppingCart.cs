﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        public void AddItemToCart(int ItemId, int ItemType)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.ItemId == ItemId && n.ShoppingCartId == ShoppingCartId && n.ItemType == ItemType);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    ItemId = ItemId,
                    ItemType = ItemType,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }
        public void RemoveItemFromCart(int ItemId, int ItemType)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.ItemId == ItemId && n.ShoppingCartId == ShoppingCartId && n.ItemType == ItemType);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        }
        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
        public double GetShoppingCartTotal()
        {
            double sum = 0;
            foreach(var cart in _context.ShoppingCartItems)
                switch (cart.ItemType)
                {
                    case 0:
                        sum += _context.CPU.ToList()[cart.ItemId].Price * cart.Amount;
                        break;
                    case 1:
                        sum += _context.GPU.ToList()[cart.ItemId].Price * cart.Amount;
                        break;
                    case 2:
                        sum += _context.Motherboard.ToList()[cart.ItemId].Price * cart.Amount;
                        break;
                    case 3:
                        sum += _context.PowerSupply.ToList()[cart.ItemId].Price * cart.Amount;
                        break;
                    case 4:
                        sum += _context.RAM.ToList()[cart.ItemId].Price * cart.Amount;
                        break;
                }
            return sum;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.ItemId).Include(n => n.ItemType).ToList());
        }
    }
}
