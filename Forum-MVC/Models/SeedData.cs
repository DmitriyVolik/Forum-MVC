using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using СookieAuth.Models;

namespace Forum_MVC.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            Context context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<Context>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //Users password: Passw0rd%
            if (!context.Users.Any())
            {
                Collection<User> users = new Collection<User>()
                {
                    new User()
                    {
                        Email = "email1@gmail.com",
                        Login = "User1",
                        Password = "1000:x8vwVFbf8/WGD3Yvwix6HHChUcafvyDH:/gyXxTYtPxnBzsy7LbON3xHFkjtim09/"
                    },
                    new User()
                    {
                        Email = "email2@gmail.com",
                        Login = "User2",
                        Password = "1000:x8vwVFbf8/WGD3Yvwix6HHChUcafvyDH:/gyXxTYtPxnBzsy7LbON3xHFkjtim09/"
                    },
                    new User()
                    {
                        Email = "email3@gmail.com",
                        Login = "User3",
                        Password = "1000:x8vwVFbf8/WGD3Yvwix6HHChUcafvyDH:/gyXxTYtPxnBzsy7LbON3xHFkjtim09/"
                    }
                };
                context.Users.AddRange(users);

                Collection<Topic> topics = new Collection<Topic>()
                {
                    new Topic() { Name = "Topic 1" },
                    new Topic() { Name = "Topic 2" },
                    new Topic() { Name = "Topic 3" }
                };

                context.Topics.AddRange(topics);
                context.Posts.AddRange(
                    new Post()
                    {
                        Title = "Post 1",
                        Description = "Post description Aenean vitae quam id massa gravida accumsan sit amet ac mauris. Fusce porttitor et sem vel sagittis. Maecenas laoreet est in nunc vestibulum sagittis.",
                        Topic = topics[0],
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id laoreet ex. Nunc eget augue tempus, placerat dolor non, vehicula libero. Maecenas viverra erat ultrices, sodales turpis a, dictum augue. Quisque tempor fringilla justo at efficitur. Vivamus ultrices sollicitudin lectus, vel aliquet tellus egestas tempor. Integer tempus mauris vitae nulla pretium, nec pharetra dui vulputate. Donec a odio mattis massa pharetra gravida. Aliquam vitae lectus dignissim, pellentesque nibh ut, blandit purus. Aenean interdum sit amet nulla ac pellentesque.",
                        User = users[0]
                    },
                    new Post()
                    {
                        Title = "Post 2",
                        Description = "Post description Aenean vitae quam id massa gravida accumsan sit amet ac mauris. Fusce porttitor et sem vel sagittis. Maecenas laoreet est in nunc vestibulum sagittis.",
                        Topic = topics[1],
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id laoreet ex. Nunc eget augue tempus, placerat dolor non, vehicula libero. Maecenas viverra erat ultrices, sodales turpis a, dictum augue. Quisque tempor fringilla justo at efficitur. Vivamus ultrices sollicitudin lectus, vel aliquet tellus egestas tempor. Integer tempus mauris vitae nulla pretium, nec pharetra dui vulputate. Donec a odio mattis massa pharetra gravida. Aliquam vitae lectus dignissim, pellentesque nibh ut, blandit purus. Aenean interdum sit amet nulla ac pellentesque.",
                        User = users[0]
                    },
                    new Post()
                    {
                        Title = "Post 3",
                        Description = "Post description Aenean vitae quam id massa gravida accumsan sit amet ac mauris. Fusce porttitor et sem vel sagittis. Maecenas laoreet est in nunc vestibulum sagittis.",
                        Topic = topics[2],
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id laoreet ex. Nunc eget augue tempus, placerat dolor non, vehicula libero. Maecenas viverra erat ultrices, sodales turpis a, dictum augue. Quisque tempor fringilla justo at efficitur. Vivamus ultrices sollicitudin lectus, vel aliquet tellus egestas tempor. Integer tempus mauris vitae nulla pretium, nec pharetra dui vulputate. Donec a odio mattis massa pharetra gravida. Aliquam vitae lectus dignissim, pellentesque nibh ut, blandit purus. Aenean interdum sit amet nulla ac pellentesque.",
                        User = users[0]
                    },
                    new Post()
                    {
                        Title = "Post 4",
                        Description = "Post description Aenean vitae quam id massa gravida accumsan sit amet ac mauris. Fusce porttitor et sem vel sagittis. Maecenas laoreet est in nunc vestibulum sagittis.",
                        Topic = topics[0],
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id laoreet ex. Nunc eget augue tempus, placerat dolor non, vehicula libero. Maecenas viverra erat ultrices, sodales turpis a, dictum augue. Quisque tempor fringilla justo at efficitur. Vivamus ultrices sollicitudin lectus, vel aliquet tellus egestas tempor. Integer tempus mauris vitae nulla pretium, nec pharetra dui vulputate. Donec a odio mattis massa pharetra gravida. Aliquam vitae lectus dignissim, pellentesque nibh ut, blandit purus. Aenean interdum sit amet nulla ac pellentesque.",
                        User = users[1]
                    },
                    new Post()
                    {
                        Title = "Post 5",
                        Description = "Post description Aenean vitae quam id massa gravida accumsan sit amet ac mauris. Fusce porttitor et sem vel sagittis. Maecenas laoreet est in nunc vestibulum sagittis.",
                        Topic = topics[1],
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id laoreet ex. Nunc eget augue tempus, placerat dolor non, vehicula libero. Maecenas viverra erat ultrices, sodales turpis a, dictum augue. Quisque tempor fringilla justo at efficitur. Vivamus ultrices sollicitudin lectus, vel aliquet tellus egestas tempor. Integer tempus mauris vitae nulla pretium, nec pharetra dui vulputate. Donec a odio mattis massa pharetra gravida. Aliquam vitae lectus dignissim, pellentesque nibh ut, blandit purus. Aenean interdum sit amet nulla ac pellentesque.",
                        User = users[1]
                    },
                    new Post()
                    {
                        Title = "Post 6",
                        Description = "Post description Aenean vitae quam id massa gravida accumsan sit amet ac mauris. Fusce porttitor et sem vel sagittis. Maecenas laoreet est in nunc vestibulum sagittis.",
                        Topic = topics[2],
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id laoreet ex. Nunc eget augue tempus, placerat dolor non, vehicula libero. Maecenas viverra erat ultrices, sodales turpis a, dictum augue. Quisque tempor fringilla justo at efficitur. Vivamus ultrices sollicitudin lectus, vel aliquet tellus egestas tempor. Integer tempus mauris vitae nulla pretium, nec pharetra dui vulputate. Donec a odio mattis massa pharetra gravida. Aliquam vitae lectus dignissim, pellentesque nibh ut, blandit purus. Aenean interdum sit amet nulla ac pellentesque.",
                        User = users[1]
                    },
                    new Post()
                    {
                        Title = "Post 7",
                        Description = "Post description Aenean vitae quam id massa gravida accumsan sit amet ac mauris. Fusce porttitor et sem vel sagittis. Maecenas laoreet est in nunc vestibulum sagittis.",
                        Topic = topics[0],
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id laoreet ex. Nunc eget augue tempus, placerat dolor non, vehicula libero. Maecenas viverra erat ultrices, sodales turpis a, dictum augue. Quisque tempor fringilla justo at efficitur. Vivamus ultrices sollicitudin lectus, vel aliquet tellus egestas tempor. Integer tempus mauris vitae nulla pretium, nec pharetra dui vulputate. Donec a odio mattis massa pharetra gravida. Aliquam vitae lectus dignissim, pellentesque nibh ut, blandit purus. Aenean interdum sit amet nulla ac pellentesque.",
                        User = users[2]
                    },
                    new Post()
                    {
                        Title = "Post 8",
                        Description = "Post description Aenean vitae quam id massa gravida accumsan sit amet ac mauris. Fusce porttitor et sem vel sagittis. Maecenas laoreet est in nunc vestibulum sagittis.",
                        Topic = topics[1],
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id laoreet ex. Nunc eget augue tempus, placerat dolor non, vehicula libero. Maecenas viverra erat ultrices, sodales turpis a, dictum augue. Quisque tempor fringilla justo at efficitur. Vivamus ultrices sollicitudin lectus, vel aliquet tellus egestas tempor. Integer tempus mauris vitae nulla pretium, nec pharetra dui vulputate. Donec a odio mattis massa pharetra gravida. Aliquam vitae lectus dignissim, pellentesque nibh ut, blandit purus. Aenean interdum sit amet nulla ac pellentesque.",
                        User = users[2]
                    },
                    new Post()
                    {
                        Title = "Post 9",
                        Description = "Post description Aenean vitae quam id massa gravida accumsan sit amet ac mauris. Fusce porttitor et sem vel sagittis. Maecenas laoreet est in nunc vestibulum sagittis.",
                        Topic = topics[2],
                        Text =
                            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin id laoreet ex. Nunc eget augue tempus, placerat dolor non, vehicula libero. Maecenas viverra erat ultrices, sodales turpis a, dictum augue. Quisque tempor fringilla justo at efficitur. Vivamus ultrices sollicitudin lectus, vel aliquet tellus egestas tempor. Integer tempus mauris vitae nulla pretium, nec pharetra dui vulputate. Donec a odio mattis massa pharetra gravida. Aliquam vitae lectus dignissim, pellentesque nibh ut, blandit purus. Aenean interdum sit amet nulla ac pellentesque.",
                        User = users[2]
                    });
                context.SaveChanges();
            }
        }
    }
}