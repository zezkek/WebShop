using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;
        private readonly ICPUService _cpuService;
        private readonly IGPUService _gpuService;
        private readonly IMotherboardService _motherboardService;
        private readonly IPowerService _powerService;
        private readonly IRAMService _ramService;
        public OrdersService(AppDbContext context, ICPUService cpuservice, IGPUService gpuservice,
            IMotherboardService motherboardService, IPowerService powerService, IRAMService ramService)
        {
            _cpuService = cpuservice;
            _gpuService = gpuservice;
            _motherboardService = motherboardService;
            _powerService = powerService;
            _ramService = ramService;
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }
        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                double price = 0;
                string name = string.Empty;
                switch (item.ItemType)
                {
                    case 0:
                        price = _cpuService.GetCPUByIdAsync(item.ItemId).Result.Price;
                        name = _cpuService.GetCPUByIdAsync(item.ItemId).Result.Name;
                        break;
                    case 1:
                        price = _gpuService.GetGPUByIdAsync(item.ItemId).Result.Price;
                        name = _gpuService.GetGPUByIdAsync(item.ItemId).Result.Name;
                        break;
                    case 2:
                        price = _motherboardService.GetMotherboardByIdAsync(item.ItemId).Result.Price;
                        name = _motherboardService.GetMotherboardByIdAsync(item.ItemId).Result.Name;
                        break;
                    case 3:
                        price = _powerService.GetPowerByIdAsync(item.ItemId).Result.Price;
                        name = _powerService.GetPowerByIdAsync(item.ItemId).Result.Name;
                        break;
                    case 4:
                        price = _ramService.GetRAMByIdAsync(item.ItemId).Result.Price;
                        name = _ramService.GetRAMByIdAsync(item.ItemId).Result.Name;
                        break;
                }
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ItemId = item.ItemId,
                    OrderId = order.Id,
                    Price = price,
                    Name=name
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
