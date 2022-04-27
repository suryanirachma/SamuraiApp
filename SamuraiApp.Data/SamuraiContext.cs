using Microsoft.EntityFrameworkCore;
using SamuraiAppDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public SamuraiContext()
        {
        }

        public SamuraiContext(DbContextOptions<SamuraiContext> options) : base(options)
        {

        }
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Pedang> Pedangs { get; set; }
        public DbSet<Elemen> Elemens { get; set; }
       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Samurai1Db")
            .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name,
                DbLoggerCategory.Database.Transaction.Name},
                Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedang>().HasMany(e => e.Elemens)
                .WithMany(p => p.Pedangs)
                .UsingEntity<ElemenPedang>(pe => pe.HasOne<Elemen>().WithMany(),
                pe => pe.HasOne<Pedang>().WithMany());
        }
    }
}
