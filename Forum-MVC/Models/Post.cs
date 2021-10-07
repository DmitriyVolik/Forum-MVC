namespace Forum_MVC.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Name { get; set;}

        public string Description { get; set;}

        public string Text { get; set;}

        public Theme Theme { get; set;}
    }
}