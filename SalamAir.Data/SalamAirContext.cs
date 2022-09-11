using Microsoft.EntityFrameworkCore;
using SalamAir.Domain.Contracts;
using SalamAir.Domain.Entities;
using System.Reflection;

namespace SalamAir.Data
{
    public class SalamAirContext : DbContext, IUnitOfWork
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Item> Items { get; set; }

        public SalamAirContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(GetType()));
        }

        void IUnitOfWork.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}