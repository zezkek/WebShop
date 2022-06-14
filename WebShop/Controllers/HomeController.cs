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

        public HomeController(ILogger<HomeController> logger,
            ICPUService cpuservice, IGPUService gpuservice, IMotherboardService motherboardService)
        {
            _logger = logger;
            _cpuService = cpuservice;
            _gpuService = gpuservice;
            _motherboardService = motherboardService;
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
    }
}
