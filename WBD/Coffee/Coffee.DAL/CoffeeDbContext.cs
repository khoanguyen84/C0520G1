using Coffee.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffee.DAL
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext()
        {

        }
        public CoffeeDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Table> Tables { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=admin\sqlexpress;Database=CoffeeDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
