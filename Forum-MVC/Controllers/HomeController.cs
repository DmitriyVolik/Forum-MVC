using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Forum_MVC.Models;
using Forum_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using СookieAuth.Models;

namespace Forum_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Context _db;
        public HomeController(ILogger<HomeController> logger, Context db)
        {
            _logger = logger;
            _db = db;
        }
        
        public IActionResult Index(int topic)
        {
            IEnumerable<Post> posts;
            if (topic==0)
            {
                posts=_db.Posts.Include(x => x.User)
                    .Include(x => x.Topic);
            }
            else if (topic==-1)
            {
                posts=_db.Posts.Include(x => x.User)
                    .Include(x => x.Topic).Where(x=>x.User.Login==User.Identity.Name);
            }
            else
            {
                posts=_db.Posts.Include(x => x.User)
                    .Include(x => x.Topic).Where(x=>x.Topic.Id==topic);
            }
            return View(new PostsViewModel()
            {
                Posts = posts,
                Topics = _db.Topics,
                ActiveTopicId = topic
            });
            
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}