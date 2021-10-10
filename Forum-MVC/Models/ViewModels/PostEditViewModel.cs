using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum_MVC.Models.ViewModels
{
    public class PostEditViewModel
    {
        public int PostId;
        
        [Required]
        [MaxLength(20,ErrorMessage = "Maximum lenght is 12" )]
        public string Title { get; set; }
        
        public List<Topic> AllTopics { get; set; }

        [Required]
        public int TopicId  { get; set; }

        [Required]
        [MaxLength(230,ErrorMessage = "Maximum lenght is 200")]
        [MinLength(10, ErrorMessage = "Minimum lenght is 10" )]
        public string Description { get; set; }
        
        [Required]
        public string Text { get; set; }
    }
}