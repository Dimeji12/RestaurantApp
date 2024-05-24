using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResturantApp.Models;

    public class ResturantContext : DbContext
    {
        public ResturantContext (DbContextOptions<ResturantContext> options)
            : base(options)
        {
        }

        public DbSet<ResturantApp.Models.Review> Review { get; set; } = default!;
    }
