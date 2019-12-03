using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using uEats.Models;

namespace uEats.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        
        public RestaurantController(ApplicationDbContext context, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(string resId)
        {
            var restaurant = await _context
                            .Restaurants
                            .SingleOrDefaultAsync(res => res.RestaurantId == resId);

            var locations = await _context.Locations.FromSqlRaw("Execute GetAllAvailableLocations").ToListAsync();
            restaurant.Locations = new List<SelectListItem>();
            foreach (var eachLocation in locations)
            {
                restaurant.Locations.Add(new SelectListItem
                {
                    Text = eachLocation.LocationName + " , " + eachLocation.LocationCity,
                    Value = eachLocation.LocationId.ToString()
                });
            }
            return View(restaurant);
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SqlParameter param1 = new SqlParameter("@p0",restaurant.RestaurantId);
                    SqlParameter param2 = new SqlParameter("@p1", restaurant.RestaurantName);
                    SqlParameter param3 = new SqlParameter("@p2", restaurant.Location.LocationId);
                    
                    var res = _context.Restaurants
                        .FromSqlRaw("UpdateRestaurantInformation @p0,@p1,@p2", param1, param2, param3)
                        .ToList();
                    
                    //var res = await _context.Restaurants.FromSqlInterpolated($"EXECUTE UpdateRestaurantInformation ({});")
                    return Ok(res);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.RestaurantId))
                    {
                        return NotFound();
                    }
                    throw;
                }
            }

            return NotFound();
        }
        
        private bool RestaurantExists(string id)
        {
            return _context.Restaurants.Any(e => e.RestaurantId == id);
        }
    }
}