namespace Forum_MVC.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set;}

        public string Description { get; set;}

        public string Text { get; set;}

        public Topic Topic { get; set;}

        public User User { get; set; }
    }
}