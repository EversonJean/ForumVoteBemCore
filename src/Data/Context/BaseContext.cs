using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data.Context
{
    public class BaseContext : DbContext
    {
        public DbSet<Elector> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Party> Parties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ElectorMapping());

            modelBuilder.Entity<Address>()
                .HasOne(x => x.Elector)
                .WithOne(x => x.Address)
                .HasForeignKey<Address>(x => x.ElectorId);

            modelBuilder.Entity<Address>()
              .ToTable("Addresses");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
