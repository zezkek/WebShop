using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data.Services
{
    public interface IGPUService
    {
        Task<GPU> GetGPUByIdAsync(int id);
        Task<List<GPU>> GetAllGPUAsync();
    }
}
