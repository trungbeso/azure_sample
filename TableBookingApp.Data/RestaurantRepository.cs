using Microsoft.EntityFrameworkCore;
using TableBookingApp.Core.ViewModels;

namespace TableBookingApp.Data
{
    public class RestaurantRepository : IRestaurantRepository
    {

        private readonly TableBookingAppDbContext _dbContext;

        public RestaurantRepository(TableBookingAppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<RestaurantModel>> GetAllRestaurantAsync()
        {
            return await _dbContext.Restaurants
                .OrderBy(x => x.Name)
                .Select(r => new RestaurantModel()
            {
                Id = r.Id,
                Name = r.Name,
                Address = r.Address,
                Phone = r.Phone,
                Email = r.Email,
                ImageUrl = r.ImageUrl
            }).ToListAsync();
        }

        public async Task<IEnumerable<DiningTableWithTimeSlotModel>> GetDiningTablesByBranchAsync(int branchId, DateTime date)
        {
            var diningTables = await _dbContext.DiningTables
                .Where(dt => dt.RestaurantBranchid == branchId)
                .SelectMany(dt => dt.TimeSlots, (dt, ts) => new {
                    dt.RestaurantBranchid,
                    dt.Tablename,
                    dt.Capacity,
                    ts.ReservationDay,
                    ts.MealType,
                    ts.TableStatus,
                    ts.Id
                })
                .Where(ts => ts.ReservationDay.Date == date.Date)
                .OrderBy(ts => ts.Id)
                .ThenBy(ts => ts.MealType)
                .ToListAsync();
            return diningTables.Select(dt => new DiningTableWithTimeSlotModel
            {
                BranchId = dt.RestaurantBranchid,
                TableName = dt.Tablename,
                Capacity = dt.Capacity,
                RevervationDay = dt.ReservationDay,
                MealType = dt.MealType,
                TableStatus = dt.TableStatus,
                TimeSlotId = dt.Id
            });
        }

        public async Task<IEnumerable<DiningTableWithTimeSlotModel>> GetDiningTablesByBranchAsync(int branchId)
        {
            return await _dbContext.DiningTables
                .Where(dt => dt.RestaurantBranchid == branchId)
                .SelectMany(dt => dt.TimeSlots, (dt, ts) => new DiningTableWithTimeSlotModel
                {
                    BranchId = branchId,
                    TableName = dt.Tablename,
                    Capacity = dt.Capacity,
                    RevervationDay = ts.ReservationDay,
                    MealType = ts.MealType,
                    TableStatus = ts.TableStatus,
                    TimeSlotId= ts.Id
                })
                .Where(ts => ts.RevervationDay >= DateTime.Now.Date)
                .OrderBy(ts => ts.TimeSlotId)
                .ThenBy(ts => ts.MealType)
                .ToListAsync();
        }

        public async Task<IEnumerable<RestaurantBranchModel>> GetRestaurantBranchsByRestaurantIdAsync(int restaurantId)
        {
            return await _dbContext.RestaurantBranches
                .Where(rb => rb.RestaurantId == restaurantId)
                .OrderBy(rb => rb.Name)
                .Select(rb => new RestaurantBranchModel
                {
                    Id = rb.Id,
                    Name = rb.Name,
                    Address = rb.Address,
                    Phone = rb.Phone,
                    Email = rb.Email,
                    ImageUrl = rb.ImageUrl
                }).ToListAsync();
        }
    }
}
