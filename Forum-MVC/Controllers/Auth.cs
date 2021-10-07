using System.Diagnostics;
using Forum_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using СookieAuth.Models;

namespace Forum_MVC.Controllers
{
    public class Auth : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private Context _db;

        public Auth(ILogger<HomeController> logger, Context db )
        {
            _logger = logger;
            _db = db;
        }
        
        
        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount(string email, string login, string password)
        {
            
            
            return null;
        }
        
        public IActionResult SignUp()
        {
            return View();
        }
        
        public IActionResult SignIn()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}