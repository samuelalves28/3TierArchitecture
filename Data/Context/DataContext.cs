using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var entityTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.IsPublic &&
                    t.Namespace == "Data.Models");

            foreach (var type in entityTypes)
            {
                modelBuilder.Entity(type);
            }
        }
    }
}