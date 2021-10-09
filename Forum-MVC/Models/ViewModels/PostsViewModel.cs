using System.Collections.Generic;

namespace Forum_MVC.Models.ViewModels
{
    public class PostsViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        
        public IEnumerable<Topic> Topics { get; set; }

        public int ActiveTopicId { get; set; }
    }
}