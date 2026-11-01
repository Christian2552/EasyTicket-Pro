using Microsoft.EntityFrameworkCore;
using EasyTicket_Pro.Models;

namespace EasyTicket_Pro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}