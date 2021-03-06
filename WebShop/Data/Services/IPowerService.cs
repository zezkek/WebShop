using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data.Services
{
    public interface IPowerService
    {
        Task<PowerSupply> GetPowerByIdAsync(int id);
        Task<List<PowerSupply>> GetAllPowerAsync();
    }
}
