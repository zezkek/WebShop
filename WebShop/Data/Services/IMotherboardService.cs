using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data.Services
{
    public interface IMotherboardService
    {
        Task<Motherboard> GetMotherboardByIdAsync(int id);
        Task <List<Motherboard>> GetAllMotherboardAsync();
    }
}
