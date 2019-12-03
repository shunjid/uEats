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
                            .Include(res => res.Location)
                            .SingleOrDefaultAsync(res => res.RestaurantId == resId);

            var locations = await _context.Locations.FromSqlRaw("Execute get_sp_AllAvailableLocations").ToListAsync();
            restaurant.Locations = new List<SelectListItem>();
            foreach (var eachLocation in locations)
            {
                restaurant.Locations.Add(new SelectListItem
                {
                    Text = eachLocation.LocationName + " , " + eachLocation.LocationCity,
                    Value = eachLocation.LocationId.ToString()
                });
            }

            ViewBag.restaurantIdViewBag = restaurant.RestaurantId;
            return View(restaurant);
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(Restaurant restaurant)
        {
            if (!ModelState.IsValid) return NotFound();
            try
            {
                var res = await _context
                    .Restaurants
                    .FromSqlInterpolated($"sp__UpgradeRestaurantInformation {restaurant.RestaurantId}, {restaurant.RestaurantName}, {restaurant.Location.LocationId}").ToListAsync();
                var resResponse = res.SingleOrDefault();
                    
                if (resResponse != null)
                    return RedirectToAction("Index", "Restaurant", new
                    {
                        resId = resResponse.RestaurantId
                    });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(restaurant.RestaurantId))
                {
                    return NotFound();
                }
                throw;
            }

            return NotFound();
        }

        public IActionResult Breads(string resId)
        {
            ViewBag.restaurantIdViewBag = resId;
            return View();
        }

        public IActionResult Configurations(string resId)
        {
            ViewBag.restaurantIdViewBag = resId;
            return View();
        }
        
        private bool RestaurantExists(string id)
        {
            return _context.Restaurants.Any(e => e.RestaurantId == id);
        }
    }
}