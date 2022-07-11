using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Base;
using WebShop.Models;

namespace WebShop.Data.Services
{
    public class GPUService: EntityBaseRepository<GPU>, IGPUService
    {
        private readonly AppDbContext _context;
        public GPUService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GPU> GetGPUByIdAsync(int id)
        {
            var gpuDetail = await _context.GPU.FirstOrDefaultAsync(n => n.Id == id);
            return gpuDetail;
        }
        public async Task<List<GPU>> GetAllGPUAsync()
        {
            var allgpu = await _context.GPU.ToListAsync();
            return allgpu;
        }
    }
}
