using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Data.Services;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICPUService _cpuService;
        private readonly IGPUService _gpuService;
        private readonly IMotherboardService _motherboardService;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context,
            ICPUService cpuservice, IGPUService gpuservice, IMotherboardService motherboardService)
        {
            _logger = logger;
            _cpuService = cpuservice;
            _gpuService = gpuservice;
            _motherboardService = motherboardService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            Random rnd = new Random();
            CPU rndcpu = await _cpuService.GetCPUByIdAsync(rnd.Next(1, 10));
            GPU rndgpu = await _gpuService.GetGPUByIdAsync(rnd.Next(1, 5));
            Motherboard rndmoth = await _motherboardService.GetMotherboardByIdAsync(rnd.Next(1, 5));
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
        public IActionResult Catalog()
        {
            List<ItemToSell> items = new List<ItemToSell>();
            foreach(CPU cpus in _context.CPU)
                items.Add(new ItemToSell
                {
                    ItemId=cpus.Id,
                    ItemType=0,
                    ItemDescrip=cpus.Description,
                    ItemPrice=cpus.Price,
                    ItemName=cpus.Name
                });
            foreach (GPU gpus in _context.GPU)
                items.Add(new ItemToSell
                {
                    ItemId = gpus.Id,
                    ItemType = 1,
                    ItemDescrip = gpus.Description,
                    ItemPrice = gpus.Price,
                    ItemName=gpus.Name
                });
            foreach (Motherboard mothers in _context.Motherboard)
                items.Add(new ItemToSell
                {
                    ItemId = mothers.Id,
                    ItemType = 2,
                    ItemDescrip = mothers.Description,
                    ItemPrice = mothers.Price,
                    ItemName=mothers.Name
                });
            foreach (PowerSupply powers in _context.PowerSupply)
                items.Add(new ItemToSell
                {
                    ItemId = powers.Id,
                    ItemType = 3,
                    ItemDescrip = powers.Description,
                    ItemPrice = powers.Price,
                    ItemName=powers.Name
                });
            foreach (RAM rams in _context.RAM)
                items.Add(new ItemToSell
                {
                    ItemId = rams.Id,
                    ItemType = 4,
                    ItemDescrip = rams.Description,
                    ItemPrice = rams.Price,
                    ItemName=rams.Name
                });
            return View(items);
        }
        public IActionResult Constructor()
        {
            return View(_context);
        }

    }
}
