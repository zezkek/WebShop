using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RAM_Motherboard>().HasKey(rm => new
            {
                rm.RAM_Id,
                rm.Motherboard_Id
            });
            modelBuilder.Entity<RAM_Motherboard>().HasOne(r => r.RAM).WithMany(rm => rm.RAM_Motherboards).HasForeignKey(r => r.RAM_Id);
            modelBuilder.Entity<RAM_Motherboard>().HasOne(m => m.Motherboard).WithMany(rm => rm.RAM_Motherboards).HasForeignKey(m => m.Motherboard_Id);

            modelBuilder.Entity<CPU_Motherboard>().HasKey(cm => new
            {
                cm.CPU_Id,
                cm.Motherboard_Id
            });
            modelBuilder.Entity<CPU_Motherboard>().HasOne(c => c.CPU).WithMany(cm => cm.CPU_Motherboards).HasForeignKey(c => c.CPU_Id);
            modelBuilder.Entity<CPU_Motherboard>().HasOne(m => m.Motherboard).WithMany(rm => rm.CPU_Motherboards).HasForeignKey(m => m.Motherboard_Id);

            modelBuilder.Entity<CPU_RAM>().HasKey(cr => new
            {
                cr.CPU_Id,
                cr.RAM_Id
            });
            modelBuilder.Entity<CPU_RAM>().HasOne(c => c.CPU).WithMany(cr => cr.CPU_RAMs).HasForeignKey(c => c.CPU_Id);
            modelBuilder.Entity<CPU_RAM>().HasOne(r => r.RAM).WithMany(cr => cr.CPU_RAMs).HasForeignKey(m => m.RAM_Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CPU> CPU { get; set; }
        public DbSet<GPU> GPU { get; set; }
        public DbSet<Motherboard> Motherboard { get; set; }
        public DbSet<PowerSupply> PowerSupply { get; set; }
        public DbSet<RAM> RAM { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<RAM_Motherboard> RAM_Motherboard { get; set; }
        public DbSet<CPU_Motherboard> CPU_Motherboard { get; set; }
        public DbSet<CPU_RAM> CPU_RAM { get; set; }

        //order
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
