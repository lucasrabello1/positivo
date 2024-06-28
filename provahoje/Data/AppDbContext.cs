using Microsoft.EntityFrameworkCore;
using prova.Models;

namespace prova.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contrato> Contratos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
