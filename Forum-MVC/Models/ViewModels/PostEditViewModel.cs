using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum_MVC.Models.ViewModels
{
    public class PostEditViewModel
    {
        [Required]
        public string Title { get; set; }
        
        public List<Topic> AllTopics { get; set; }

        [Required]
        public int TopicId  { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Text { get; set; }
    }
}