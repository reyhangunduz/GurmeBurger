using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using DAL.Configurations;
using System.Reflection.Emit;

namespace DAL.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Condiment> Condiments { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
		{


            //builder
            //         .ApplyConfiguration(new BeverageConfiguration())
            //         .ApplyConfiguration(new BurgerConfiguration())
            //         .ApplyConfiguration(new CondimentConfiguration());
            base.OnModelCreating(builder);
        }


    }
}