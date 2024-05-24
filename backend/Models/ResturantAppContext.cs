using ResturantApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ResturantApp.Models
{
  public class ResturantAppContext : IdentityDbContext<IdentityUser>
  {
    public ResturantAppContext(DbContextOptions<ResturantAppContext> options) : base(options)
    {

    }
    public DbSet <Customer> Customers {get;set;}
    
    public DbSet<MenuItem> MenuItems {get;set;}
    public DbSet <Staff> Staffs{get;set;}
    public DbSet <Order> Orders {get;set;}
      public DbSet<Address> Address { get; set; }

        public DbSet<Review> Reviews { get;set;}
  }
}