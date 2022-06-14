﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data.Services
{
    public interface IRAMService
    {
        Task<RAM> GetCPUByIdAsync(int id);
    }
}
