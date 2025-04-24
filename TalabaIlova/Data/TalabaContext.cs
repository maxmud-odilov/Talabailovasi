using Microsoft.EntityFrameworkCore;
using TalabaIlova.Models;

namespace TalabaIlova.Data
{
    public class TalabaContext : DbContext
    {
        public TalabaContext(DbContextOptions<TalabaContext> options) : base(options)
        {
        }

        public DbSet<Talaba> Talabalar { get; set; }
    }
}
