namespace Forum_MVC.Models.ViewModels
{
    public class PostViewModel
    {
        public string Name { get; set; }
        
        public Topic Topic  { get; set; }

        public string Description { get; set; }
        
        public string Text { get; set; }
    }
}