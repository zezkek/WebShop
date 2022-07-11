using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data.Services
{
    public interface ICPUService
    {
        Task<CPU> GetCPUByIdAsync(int id);
        Task<List<CPU>> GetAllCPUAsync();
    }
}
