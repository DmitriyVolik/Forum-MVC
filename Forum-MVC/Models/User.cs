using System.ComponentModel.DataAnnotations;

namespace Forum_MVC.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Email { get; set;}
        
        [Required]
        [MinLength(4)]
        [MaxLength(12)]
        public string Login { get; set;}
        
        [Required]
        public string Password { get; set;}
    }
}