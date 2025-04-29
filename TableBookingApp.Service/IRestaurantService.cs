
using TableBookingApp.Core.ViewModels;

namespace TableBookingApp.Service
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<RestaurantModel>> GetRestaurantsAsync();
        public Task<IEnumerable<RestaurantBranchModel>> GetRestaurantBranchsByRestaurantIdAsync(int restaurantId);

        public Task<IEnumerable<DiningTableWithTimeSlotModel>> GetDiningTablesByBranchAsync(int branchId, DateTime date);

        public Task<IEnumerable<DiningTableWithTimeSlotModel>> GetDiningTablesByBranchAsync(int branchId);
    }
}
