using System;
using System.Linq;
using Forum_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using СookieAuth.Models;

namespace Forum_MVC.Controllers
{
    public class Posts : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Context _db;
        
        public Posts(ILogger<HomeController> logger, Context db)
        {
            _logger = logger;
            _db = db;
        }
        
        public IActionResult CreatePost()
        {
            return View(_db.Topics.ToList());
        }

        [HttpPost("CreateTopic")]
        public IActionResult CreateTopic(string name)
        {
            _db.Topics.Add(new Topic() { Name = name });
            _db.SaveChanges();
            return View("CreatePost", _db.Topics.ToList());
        }
        
    }
}