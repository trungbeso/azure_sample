using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TableBookingApp.Core;
using TableBookingApp.Core.ViewModels;
using TableBookingApp.Service;

namespace TableBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _service;

        public RestaurantController(IRestaurantService service)
        {
            _service = service;
        }

        [HttpGet("/restaurants")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RestaurantModel>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllRestaurantAsync()
        {
            var restaurant = await _service.GetRestaurantsAsync();
            if (!ModelState.IsValid) {
                return BadRequest();
            }
            return Ok(restaurant);
        }

        [HttpGet("/dining-table/{branchId}/date/{date}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RestaurantBranchModel>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetDiningTableListByBranch(int branchId, DateTime date)
        {
            var diningTable = await _service.GetDiningTablesByBranchAsync(branchId, date);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(diningTable);
        }
    }
}
