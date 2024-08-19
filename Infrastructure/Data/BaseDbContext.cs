using ApplicationCore.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BaseDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AppConfiguration> Configs { get; set; }
    }
}
