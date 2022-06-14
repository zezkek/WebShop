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

namespace WebShop.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> AddItemToShoppingCart(int id, int type)
        {
            switch (type)
            {
                case 0:
                    var item = await _cpuService.GetCPUByIdAsync(id);
                    break;
                case 1:
                    var item = await _cpuService.GetCPUByIdAsync(id);
                    break;
                case 2:
                    var item = await _cpuService.GetCPUByIdAsync(id);
                    break;
                case 3:
                    var item = await _cpuService.GetCPUByIdAsync(id);
                    break;
                case 4:
                    var item = await _cpuService.GetCPUByIdAsync(id);
                    break;
            }

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
