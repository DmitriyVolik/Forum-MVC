using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;

namespace Forum_MVC.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(12)]
        public string Title { get; set;}

        [Required]
        public string Description { get; set;}

        [Required]
        public string Text { get; set;}

        [Required]
        public Topic Topic { get; set;}
        
        [Required]
        public User User { get; set; }
    }
}