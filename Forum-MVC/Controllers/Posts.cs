using System;
using System.Linq;
using Forum_MVC.Models;
using Forum_MVC.Models.ViewModels;
using Forum_MVC.Views.Posts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
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
        
        
        public IActionResult OpenPost(int id)
        {
            return View(_db.Posts.Include(x=>x.Topic)
                .Include(x=>x.User)
                .FirstOrDefault(x=>x.Id==id));
        }
        
        
        
        [Authorize]
        [HttpPost] 
        public IActionResult EditPost(PostEditViewModel postEditViewModel)
        {
            var post = _db.Posts.Include(x=>x.User)
                .FirstOrDefault(x => x.Id == postEditViewModel.PostId);

            if (post!=null && User.Identity.Name==post.User.Login)
            {
                post.Topic = _db.Topics.FirstOrDefault(x => x.Id == postEditViewModel.TopicId);

                post.Title = postEditViewModel.Title;

                post.Description = postEditViewModel.Description;

                post.Text = postEditViewModel.Description;

                _db.SaveChanges();
            }

            return Redirect("/");

        }
        
        [Authorize]
        public IActionResult EditPost(int id)
        {
            var post = _db.Posts.Include(x=>x.User)
                .Include(x=>x.Topic).FirstOrDefault(x => x.Id == id);
            if (User.Identity.Name!=post.User.Login)
            {
                return Redirect("/");
            }

            return View(new PostEditViewModel()
            {
                PostId = id,
                Title = post.Title,
                Description = post.Description,
                Text = post.Text,
                AllTopics = _db.Topics.ToList(),
                TopicId = post.Topic.Id
            });
        }


        [Authorize]
        public IActionResult CreatePost()
        {
            return View( new PostEditViewModel(){AllTopics = _db.Topics.ToList()});
        }
        
        [HttpPost("CreateTopic")]
        public IActionResult CreateTopic(string name)
        {
            if (_db.Topics.FirstOrDefault(x=>x.Name==name)!=null)
            {
                TempData["Error"] += "Error: This topic is already exists\n";
                return View("CreatePost", new PostEditViewModel(){AllTopics = _db.Topics.ToList()});
            }
            if (name!=null)
            {
                _db.Topics.Add(new Topic() { Name = name });
                _db.SaveChanges();
            }
            return View("CreatePost", new PostEditViewModel(){AllTopics = _db.Topics.ToList()});
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult CreatePost(PostEditViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                var topic = _db.Topics.FirstOrDefault(x => x.Id == postViewModel.TopicId);
                var user = _db.Users.FirstOrDefault(x=>x.Login==User.Identity.Name);
           
                _db.Posts.Add(new Post(){Title = postViewModel.Title, Description = postViewModel.Description,
                    Text = postViewModel.Text, Topic = topic, User =user });
                _db.SaveChanges();
                return Redirect("/");
            }
            return View( new PostEditViewModel(){AllTopics = _db.Topics.ToList()});
        }
        
    }
}