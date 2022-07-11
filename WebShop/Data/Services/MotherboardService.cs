using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Base;
using WebShop.Models;

namespace WebShop.Data.Services
{
    public class MotherboardService : EntityBaseRepository<Motherboard>, IMotherboardService
    {
        private readonly AppDbContext _context;
        public MotherboardService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Motherboard> GetMotherboardByIdAsync(int id)
        {
            var motherboardDetail = await _context.Motherboard.FirstOrDefaultAsync(n => n.Id == id);
            return motherboardDetail;
        }
        public async Task<List<Motherboard>> GetAllMotherboardAsync()
        {
            var allmotherboard = await _context.Motherboard.ToListAsync();
            return allmotherboard;
        }
    }
}
