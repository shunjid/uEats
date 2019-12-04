using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using uEats.Data;
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
        
        private string _getCurrentlyLoggedInUserRole(string username)
        {
            return _userManager.FindByNameAsync(username).Result.Role;
        }
        
        private string _getCurrentlyLoggedInUserId(string username)
        {
            return _userManager.FindByNameAsync(username).Result.Id;
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(Account account)
        {
            account.AccountId = Guid.NewGuid().ToString().Replace("-", "");
            
            if (ModelState.IsValid)
            {
                var mailAddress = new MailAddress(account.AccountEmail);
                account.AccountUserName = mailAddress.User;
                
                var userObject = new CustomUser
                {
                    Id = account.AccountId,
                    Email = account.AccountEmail,
                    UserName = account.AccountUserName,
                    Role = account.AccountRole,
                    PhoneNumber = account.AccountPhoneNumber,
                    LockoutEnabled = false
                };

                var userCreationResult = await _userManager.CreateAsync(userObject, account.UserPassword);

                if (userCreationResult.Succeeded)
                {
                    if (account.AccountRole == "Consumer")
                    {
                        var consumer = new Consumer
                        {
                            ConsumerId = account.AccountId,
                            Account = account,
                            CustomerStatus = "Silver"
                        };
                        _context.Add(consumer);
                        _context.Add(account);
                        await _context.SaveChangesAsync();
                        await _signInManager.SignInAsync(userObject, isPersistent: true);
                        
                        return RedirectToAction("Index", "Consumer", new
                        {
                            connId = account.AccountId
                        });
                    } 
                    if (account.AccountRole == "Restaurant")
                    {
                        var restaurant = new Restaurant
                        {
                            RestaurantId = account.AccountId,
                            Account = account,
                            RestaurantStatus = "Silver",
                            RestaurantAverageRating = 0.0f
                        };
                        _context.Add(restaurant);
                        _context.Add(account);
                        await _context.SaveChangesAsync();
                        await _signInManager.SignInAsync(userObject, isPersistent: true);
                        
                        return RedirectToAction("Index", "Restaurant", new
                        {
                            resId = account.AccountId
                        }); 
                    }

                    var carrier = new Carrier
                    {
                        CarrierId = account.AccountId,
                        Account = account,
                        CarrierStatus = "Silver",
                        CarrierAverageRating = 0.0f
                    };
                    _context.Add(carrier);
                    _context.Add(account);
                    await _context.SaveChangesAsync();
                    await _signInManager.SignInAsync(userObject, isPersistent: true);
                        
                    return RedirectToAction("Index", "Carrier", new
                    {
                        carrIId = account.AccountId
                    });
                }

                foreach (var error in userCreationResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(account);
        }
        
        [HttpPost]
        public async Task<IActionResult> LogIn(AuthUser authUser, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var userName = new MailAddress(authUser.UserEmail).User;
                var userSignInResult = await _signInManager.PasswordSignInAsync(userName, authUser.UserPassword, true, false);

                if (userSignInResult.Succeeded)
                {
                    var userRole = _getCurrentlyLoggedInUserRole(userName);
                    if (userRole == "Consumer")
                    {
                        return RedirectToAction("Index", "Consumer", new
                        {
                            connId = _getCurrentlyLoggedInUserId(userName)
                        });
                    }
                    if (userRole == "Restaurant")
                    {
                        return RedirectToAction("Index", "Restaurant", new
                        {
                            resId = _getCurrentlyLoggedInUserId(userName)
                        });
                    }

                    return RedirectToAction("Index", "Carrier", new
                    {
                        carrIId = _getCurrentlyLoggedInUserId(userName)
                    });
                }
                ModelState.AddModelError("", "Invalid SignIn Attempt");
            }
            return View(authUser);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}