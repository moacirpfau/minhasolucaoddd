using Microsoft.EntityFrameworkCore;
using MinhaSolucaoDDD.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MinhaSolucaoDDD.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
