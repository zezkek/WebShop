using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Base;
using WebShop.Models;

namespace WebShop.Data.Services
{
    public class CPUService : EntityBaseRepository<CPU>, ICPUService
    {
        private readonly AppDbContext _context;
        public CPUService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<CPU> GetCPUByIdAsync(int id)
        {
            var cpuDetail = await _context.CPU.FirstOrDefaultAsync(n => n.Id == id);
            return cpuDetail;
        }
        public async Task<List<CPU>> GetAllCPUAsync()
        {
            var allcpu = await _context.CPU.ToListAsync();
            return allcpu;
        }

    }
}
