using Recipes.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recipes.Controllers;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Recipes.Models;
using Microsoft.EntityFrameworkCore;
using RecipeBook.Models.Data;
using RecipeBook.Models;
using Microsoft.AspNetCore.Builder;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Policy;

namespace Recipes.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<RecipeBookUser> _userManager;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,UserManager<RecipeBookUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            this._userManager = userManager;
            this._context = context;
        }

     
        public IActionResult Index()
        {
            ViewData["UserID"]=_userManager.GetUserId(this.User);
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}