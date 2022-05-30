using DiplomaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaApp.Data.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option)
             : base(option)
        {
        }

        public DbSet<Apartament> Apartaments { get; set; }
        public DbSet<Refugee> Refugees { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartament>().ToTable("Apartament");
            modelBuilder.Entity<Refugee>().ToTable("Refugee");
            modelBuilder.Entity<Volunteer>().ToTable("Volunteer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Category>().ToTable("Category");
        }
    }
}
