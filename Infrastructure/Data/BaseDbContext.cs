using ApplicationCore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BaseDbContext : DbContext
    {
        public DbSet<AppConfiguration> Configs { get; set; }

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
