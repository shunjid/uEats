﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using uEats.Models;

namespace uEats.Controllers
{
    public class ConsumerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;
        
        public ConsumerController(ApplicationDbContext context, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(string connId)
        {
            return View();
        }
    }
    
}