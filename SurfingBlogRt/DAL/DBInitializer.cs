using SurfingBlogRt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurfingBlogRt.DAL
{
    public class DBInitializer
    {
        public static void Initialize(DataContext context)
        {
            if (!context.Users.Any())
            {
                var user = new User();
                user.Email = "System";
                user.Nickname = "System";
                user.Password = "54kk32";
                context.Users.Add(user);
                context.SaveChanges();
            }
            if (!context.News.Any())
            {               
                context.News.AddRange(new List<News>(){
                    new News()
                {
                    AuthorId = 1,
                    Text = "Мой первый пост",
                    CreateDate = DateTime.Now.AddMonths(-13)
                },
                    new News()
                {
                    AuthorId = 1,
                    Text = "Всех с новым годом!",
                    CreateDate = new DateTime(2020, 12, 31, 11, 58, 00)
                },
                    new News()
                {
                    AuthorId = 1,
                    Text = "Вернулсяhgfd",
                    CreateDate = DateTime.Now
                }
                });
                context.SaveChanges();
                
               
            }
        }
    }
}
