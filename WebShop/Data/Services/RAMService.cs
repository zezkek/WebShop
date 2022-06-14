using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data.Base;
using WebShop.Models;

namespace WebShop.Data.Services
{
    public class RAMService : EntityBaseRepository<RAM>, IRAMService
    {
        private readonly AppDbContext _context;
        public RAMService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RAM> GetCPUByIdAsync(int id)
        {
            var ramDetail = await _context.RAM.FirstOrDefaultAsync(n => n.Id == id);
            return ramDetail;
        }
    }
}
