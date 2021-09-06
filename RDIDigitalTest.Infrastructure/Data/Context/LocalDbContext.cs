using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RDIDigitalTest.Domain.Entities.CostumerCard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RDIDigitalTest.Infrastructure.Data.Context
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions options) : base(options) { }

        public LocalDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            optionsBuilder.UseSqlite($"Data Source={dir}..\\..\\..\\..\\RDIDigitalTest.Database\\Database\\RDIDigitalTest.db"); //Dummy way to fill in the connection string
        }

        public DbSet<CostumerCard> CostumerCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CostumerCard>().ToTable("CostumerCard");
        }
    }
}
