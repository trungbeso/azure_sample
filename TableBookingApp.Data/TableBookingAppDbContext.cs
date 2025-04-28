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
        public DbSet<DiningTable> DiningTables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RestaurantBranch> RestaurantBranches { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<User> Users { get; set; }
    }
}