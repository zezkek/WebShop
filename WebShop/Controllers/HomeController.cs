using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            Random rnd = new Random();
            CPU rndcpu = _context.CPU.ToList()[rnd.Next(_context.CPU.ToList().Count)];
            GPU rndgpu = _context.GPU.ToList()[rnd.Next(_context.GPU.ToList().Count)];
            Motherboard rndmoth = _context.Motherboard.ToList()[rnd.Next(_context.Motherboard.ToList().Count)];
            NumberFormatInfo nfi = new CultureInfo("ru-RU", false).NumberFormat;
            nfi.CurrencyDecimalDigits = 0;
            string[] rnditems =
            {
                "cpus/"+rndcpu.Id.ToString()+".jpg",
                rndcpu.Name,
                rndcpu.Price.ToString("c", nfi),
                "gpus/"+rndgpu.Id.ToString()+".jpg",
                rndgpu.Name,
                rndgpu.Price.ToString("c", nfi),
                "mothers/"+rndmoth.Id.ToString()+".jpg",
                rndmoth.Name,
                rndmoth.Price.ToString("c", nfi),
            };
            return View(rnditems);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
