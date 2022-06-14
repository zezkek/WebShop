using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Data.Cart;
using WebShop.Data.Services;
using WebShop.Data.ViewModels;
using WebShop.Models;

namespace WebShop.Controllers
{
    
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        private readonly ICPUService _cpuService;
        private readonly IGPUService _gpuService;
        private readonly IMotherboardService _motherboardService;
        private readonly IPowerService _powerService;
        private readonly IRAMService _ramservice;

        public OrdersController(AppDbContext context, ShoppingCart shoppingCart,
            IOrdersService ordersService, ICPUService cpuservice, IGPUService gpuservice,
            IMotherboardService motherboardService, IPowerService powerService, IRAMService ramService)
        {
            _cpuService = cpuservice;
            _gpuService = gpuservice;
            _motherboardService = motherboardService;
            _powerService = powerService;
            _ramservice = ramService;
            _context = context;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }
        public async Task<IActionResult> AddItemToShoppingCart(int id, int type, string name)
        {
            switch (type)
            {
                case 0:
                    {
                        CPU item = await _cpuService.GetCPUByIdAsync(id);
                        if (item != null)
                        {
                            _shoppingCart.AddItemToCart(item.Id, type, item.Name, item.Price);
                        }
                    }
                    break;
                case 1:
                    {
                        GPU item = await _gpuService.GetGPUByIdAsync(id);
                        if (item != null)
                        {
                            _shoppingCart.AddItemToCart(item.Id, type, item.Name, item.Price);
                        }
                    }
                    break;
                case 2:
                    {
                        var item = await _motherboardService.GetMotherboardByIdAsync(id);
                        if (item != null)
                        {
                            _shoppingCart.AddItemToCart(item.Id, type, item.Name, item.Price);
                        }
                    }
                    break;
                case 3:
                    {
                        var item = await _powerService.GetPowerByIdAsync(id);
                        if (item != null)
                        {
                            _shoppingCart.AddItemToCart(item.Id, type, item.Name, item.Price);
                        }
                    }
                    break;
                case 4:
                    {
                        var item = await _ramservice.GetRAMByIdAsync(id);
                        if (item != null)
                        {
                            _shoppingCart.AddItemToCart(item.Id, type, item.Name, item.Price);
                        }
                    }
                    break;
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id, int type)
        {
            switch (type)
            {
                case 0:
                    {
                        CPU item = await _cpuService.GetCPUByIdAsync(id);
                        if (item != null)
                        {
                            _shoppingCart.RemoveItemFromCart(item.Id, type);
                        }
                    }
                    break;
                case 1:
                    {
                        GPU item = await _gpuService.GetGPUByIdAsync(id);
                        if (item != null)
                        {
                            _shoppingCart.RemoveItemFromCart(item.Id, type);
                        }
                    }
                    break;
                case 2:
                    {
                        var item = await _motherboardService.GetMotherboardByIdAsync(id);
                        if (item != null)
                        {
                            _shoppingCart.RemoveItemFromCart(item.Id, type);
                        }
                    }
                    break;
                case 3:
                    {
                        var item = await _powerService.GetPowerByIdAsync(id);
                        if (item != null)
                        {
                            _shoppingCart.RemoveItemFromCart(item.Id, type);
                        }
                    }
                    break;
                case 4:
                    {
                        var item = await _ramservice.GetRAMByIdAsync(id);
                        if (item != null)
                        {
                            _shoppingCart.RemoveItemFromCart(item.Id, type);
                        }
                    }
                    break;
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
