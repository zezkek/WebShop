using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Base;
using WebShop.Models;

namespace WebShop.Data.Services
{
    public class PowerService : EntityBaseRepository<PowerSupply>, IPowerService
    {
        private readonly AppDbContext _context;
        public PowerService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<PowerSupply> GetPowerByIdAsync(int id)
        {
            var powerDetail = await _context.PowerSupply.FirstOrDefaultAsync(n => n.Id == id);
            return powerDetail;
        }
        public async Task<List<PowerSupply>> GetAllPowerAsync()
        {
            var allpower = await _context.PowerSupply.ToListAsync();
            return allpower;
        }
    }
}
