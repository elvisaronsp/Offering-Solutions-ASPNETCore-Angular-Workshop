using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodAPICore.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodAPICore.DatabaseContext
{
    public class FoodDbContext : DbContext
    {
        public FoodDbContext(DbContextOptions<FoodDbContext> options)
            : base(options)
        { }

        public DbSet<FoodItem> FoodItems { get; set; }
    }
}
