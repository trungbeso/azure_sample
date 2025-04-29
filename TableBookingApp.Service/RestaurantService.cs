using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableBookingApp.Core.ViewModels;
using TableBookingApp.Data;

namespace TableBookingApp.Service
{
    public class RestaurantService : IRestaurantService
    {

        private readonly IRestaurantRepository _repository;

        public RestaurantService(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<DiningTableWithTimeSlotModel>> GetDiningTablesByBranchAsync(int branchId, DateTime date)
        {
            return _repository.GetDiningTablesByBranchAsync(branchId, date);
        }

        public Task<IEnumerable<DiningTableWithTimeSlotModel>> GetDiningTablesByBranchAsync(int branchId)
        {
            return _repository.GetDiningTablesByBranchAsync(branchId);
        }

        public Task<IEnumerable<RestaurantBranchModel>> GetRestaurantBranchsByRestaurantIdAsync(int restaurantId)
        {
            return _repository.GetRestaurantBranchsByRestaurantIdAsync(restaurantId);
        }

        public Task<IEnumerable<RestaurantModel>> GetRestaurantsAsync()
        {
            return _repository.GetAllRestaurantAsync();
        }
    }
}
