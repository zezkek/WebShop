using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IPowerService _powerService;
        private readonly IRAMService _ramService;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context,
            ICPUService cpuservice, IGPUService gpuservice, IMotherboardService motherboardService,
            IPowerService powerService, IRAMService ramService)
        {
            _logger = logger;
            _cpuService = cpuservice;
            _gpuService = gpuservice;
            _motherboardService = motherboardService;
            _context = context;
            _powerService = powerService;
            _ramService = ramService;
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
            return View(_motherboardService.GetAllMotherboardAsync().Result.ToList());
        }
        public async Task<IActionResult> ConstructorOne(int selectedmotherboardId)
        {
            Motherboard selectedmotherboard = await _motherboardService.GetMotherboardByIdAsync(selectedmotherboardId);
            List<ItemToSell> ItemsToSend = new List<ItemToSell>();
            foreach(CPU cpu in _cpuService.GetAllCPUAsync().Result.Where(c=>c.CPU_Type==selectedmotherboard.CPU_Type))
            {
                ItemsToSend.Add(new ItemToSell
                {
                    ItemDescrip = cpu.Description,
                    ItemId = cpu.Id,
                    ItemName = cpu.Name,
                    ItemPrice = cpu.Price,
                    ItemType = 0
                });
            }
            ItemsToSend.Add(new ItemToSell
            {
                ItemDescrip=selectedmotherboard.Description,
                ItemId=selectedmotherboard.Id,
                ItemName=selectedmotherboard.Name,
                ItemPrice=selectedmotherboard.Price,
                ItemType=2
            });
            return View(ItemsToSend);
        }
        public async Task<IActionResult> ConstructorTwo(int selectedmotherboardId, int selectedcpuId)
        {
            Motherboard selectedmotherboard = await _motherboardService.GetMotherboardByIdAsync(selectedmotherboardId);
            CPU selectedcpu = await _cpuService.GetCPUByIdAsync(selectedcpuId);
            List<ItemToSell> ItemsToSend = new List<ItemToSell>();
            foreach (RAM ram in _ramService.GetAllRAMAsync().Result.Where(c => c.RAM_Type == selectedmotherboard.RAM_Type))
            {
                ItemsToSend.Add(new ItemToSell
                {
                    ItemDescrip = ram.Description,
                    ItemId = ram.Id,
                    ItemName = ram.Name,
                    ItemPrice = ram.Price,
                    ItemType = 4
                });
            }
            ItemsToSend.Add(new ItemToSell
            {
                ItemDescrip = selectedmotherboard.Description,
                ItemId = selectedmotherboard.Id,
                ItemName = selectedmotherboard.Name,
                ItemPrice = selectedmotherboard.Price,
                ItemType = 2
            });
            ItemsToSend.Add(new ItemToSell
            {
                ItemDescrip = selectedcpu.Description,
                ItemId = selectedcpu.Id,
                ItemName = selectedcpu.Name,
                ItemPrice = selectedcpu.Price,
                ItemType = 0
            });
            return View(ItemsToSend);
        }
        public async Task<IActionResult> ConstructorThree(int selectedmotherboardId, int selectedcpuId, int selectedramId)
        {
            Motherboard selectedmotherboard = await _motherboardService.GetMotherboardByIdAsync(selectedmotherboardId);
            CPU selectedcpu = await _cpuService.GetCPUByIdAsync(selectedcpuId);
            RAM selectedram = await _ramService.GetRAMByIdAsync(selectedramId);
            List<ItemToSell> ItemsToSend = new List<ItemToSell>();
            foreach (GPU gpu in _gpuService.GetAllGPUAsync().Result)
            {
                ItemsToSend.Add(new ItemToSell
                {
                    ItemDescrip = gpu.Description,
                    ItemId = gpu.Id,
                    ItemName = gpu.Name,
                    ItemPrice = gpu.Price,
                    ItemType = 1
                });
            }
            ItemsToSend.Add(new ItemToSell
            {
                ItemDescrip = selectedmotherboard.Description,
                ItemId = selectedmotherboard.Id,
                ItemName = selectedmotherboard.Name,
                ItemPrice = selectedmotherboard.Price,
                ItemType = 2
            });
            ItemsToSend.Add(new ItemToSell
            {
                ItemDescrip = selectedcpu.Description,
                ItemId = selectedcpu.Id,
                ItemName = selectedcpu.Name,
                ItemPrice = selectedcpu.Price,
                ItemType = 0
            });
            ItemsToSend.Add(new ItemToSell
            {
                ItemDescrip = selectedram.Description,
                ItemId = selectedram.Id,
                ItemName = selectedram.Name,
                ItemPrice = selectedram.Price,
                ItemType = 4
            });
            return View(ItemsToSend);
        }
        public async Task<IActionResult> ConstructorFour(int selectedmotherboardId, int selectedcpuId, int selectedramId, int selectedgpuId)
        {
            Motherboard selectedmotherboard = await _motherboardService.GetMotherboardByIdAsync(selectedmotherboardId);
            CPU selectedcpu = await _cpuService.GetCPUByIdAsync(selectedcpuId);
            RAM selectedram = await _ramService.GetRAMByIdAsync(selectedramId);
            GPU selectedgpu = await _gpuService.GetGPUByIdAsync(selectedgpuId);
            List<ItemToSell> ItemsToSend = new List<ItemToSell>();
            foreach (PowerSupply power in _powerService.GetAllPowerAsync().Result.Where(p => p.Power_output >= selectedcpu.Power_usage + selectedgpu.Power_usage))
            {
                ItemsToSend.Add(new ItemToSell
                {
                    ItemDescrip = power.Description,
                    ItemId = power.Id,
                    ItemName = power.Name,
                    ItemPrice = power.Price,
                    ItemType = 3
                });
            }
            ItemsToSend.Add(new ItemToSell
            {
                ItemDescrip = selectedmotherboard.Description,
                ItemId = selectedmotherboard.Id,
                ItemName = selectedmotherboard.Name,
                ItemPrice = selectedmotherboard.Price,
                ItemType = 2
            });
            ItemsToSend.Add(new ItemToSell
            {
                ItemDescrip = selectedcpu.Description,
                ItemId = selectedcpu.Id,
                ItemName = selectedcpu.Name,
                ItemPrice = selectedcpu.Price,
                ItemType = 0
            });
            ItemsToSend.Add(new ItemToSell
            {
                ItemDescrip = selectedram.Description,
                ItemId = selectedram.Id,
                ItemName = selectedram.Name,
                ItemPrice = selectedram.Price,
                ItemType = 4
            });
            ItemsToSend.Add(new ItemToSell
            {
                ItemDescrip = selectedgpu.Description,
                ItemId = selectedgpu.Id,
                ItemName = selectedgpu.Name,
                ItemPrice = selectedgpu.Price,
                ItemType = 1
            });
            return View(ItemsToSend);
        }
    }
}
