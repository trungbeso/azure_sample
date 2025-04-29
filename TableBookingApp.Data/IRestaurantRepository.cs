using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableBookingApp.Core.ViewModels;

namespace TableBookingApp.Data
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<RestaurantModel>> GetAllRestaurantAsync();

        Task<IEnumerable<RestaurantBranchModel>> GetRestaurantBranchsByRestaurantIdAsync(int restaurantId);

        Task<IEnumerable<DiningTableWithTimeSlotModel>> GetDiningTablesByBranchAsync(int branchId, DateTime date);

        Task<IEnumerable<DiningTableWithTimeSlotModel>> GetDiningTablesByBranchAsync(int branchId);
    }
}
