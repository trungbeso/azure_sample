using Microsoft.EntityFrameworkCore;
using TableBookingApp.Core;

namespace TableBookingApp.Data
{
    public class TableBookingAppDbContext : DbContext
    {
        public TableBookingAppDbContext(DbContextOptions<TableBookingAppDbContext> options) : base(options)
        {
           
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}