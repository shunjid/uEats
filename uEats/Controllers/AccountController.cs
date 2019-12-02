using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using uEats.Models;

namespace uEats.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;

        public AccountController(ApplicationDbContext context, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        /*
         * HttpGet : When request comes to UserAccount/Register
         * this page's View will be shown
         */
        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        /*
         * HttpGet : When request comes to UserAccount/Login
         * this page's View will be shown
         */
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        
        
    }
}