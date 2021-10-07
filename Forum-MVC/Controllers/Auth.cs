using Microsoft.AspNetCore.Mvc;

namespace Forum_MVC.Controllers
{
    public class Auth : Controller
    {
        // GET
        public IActionResult SignUp()
        {
            return View();
        }
        
        public IActionResult SignIn()
        {
            return View();
        }
    }
}