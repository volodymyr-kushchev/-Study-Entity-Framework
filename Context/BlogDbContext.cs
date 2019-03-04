using System;
using System.Configuration;
using System.Data.Entity;
using ConnectLib2.Models;
using System.IO;
using System.Collections.Generic;

namespace ConnectLib2.Context
{
    public class BlogDbContext:DbContext
    {
        static BlogDbContext()
        {
            Database.SetInitializer<BlogDbContext>(new ContextInitialisator());
        }
        public BlogDbContext() : base() { }
        public BlogDbContext(string connString)
            : base(connString) { }
        
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
    //DropCreateDatabaseAlways//
    class ContextInitialisator : DropCreateDatabaseIfModelChanges<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
            #region initialize tags
            Tag t1 = new Tag
            {
                Text = "антикафе"
            };
            Tag t2 = new Tag
            {
                Text = "место для отдыха"
            };
            Tag t3 = new Tag
            {
                Text = "бизнес"
            };
            Tag t4 = new Tag
            {
                Text = "работа"
            };
            Tag t5 = new Tag
            {
                Text = "мероприятие"
            };
            Tag t6 = new Tag
            {
                Text = "отель"
            };
            Tag t7 = new Tag
            {
                Text = "комната"
            };
            Tag t8 = new Tag
            {
                Text = "рабочее пространство"
            };
            Tag t9 = new Tag
            {
                Text = "ночевка"
            };
            context.Tags.Add(t1);
            context.Tags.Add(t2);
            context.Tags.Add(t3);
            context.Tags.Add(t4);
            context.Tags.Add(t5);
            context.Tags.Add(t6);
            context.Tags.Add(t7);
            context.Tags.Add(t8);
            context.Tags.Add(t9);
            #endregion
            Article a1 = new Article
            {
                DateOfPublish = new DateTime(2018, 1, 1),
                Title = "Антикафе",
                Content = String.Join(String.Empty,File.ReadAllLines(@"D:\V_S\Visual Studio 2017\Projects\TestViewEpam\TestViewEpam\Resources\Article1.txt")),
                linkToFullArticle = "https://www.openbusiness.ru/biz/business/biznes-plan-antikafe/",
                NameImg = "anticafe",
                UrlImg = "/Resources/anticafe.jpg",
                Tags = new List<Tag>(){ t1, t2, t3, t5, t8 }
            };
            Article a2 = new Article
            {
                DateOfPublish = new DateTime(2018, 2, 2),
                Title = "Коворкинг",
                Content = String.Join(String.Empty, File.ReadAllLines(@"D:\V_S\Visual Studio 2017\Projects\TestViewEpam\TestViewEpam\Resources\Article2.txt")),
                linkToFullArticle = "https://www.openbusiness.ru/biz/business/svoy-biznes-biznes-plan-kovorking-tsentra/",
                NameImg = "coworking",
                UrlImg = "/Resources/coworking.jpg",
                Tags = new List<Tag>() { t3, t4, t5, t8 }
            };
            List<Tag> tags = new List<Tag>();
            tags.Add(t2);
            tags.Add(t3);
            tags.Add(t6);
            tags.Add(t7);
            tags.Add(t9);
            Article a3 = new Article
            {
                DateOfPublish = new DateTime(2018, 3, 3),
                Title = "Хостел",
                Content = String.Join(String.Empty, File.ReadAllLines(@"D:\V_S\Visual Studio 2017\Projects\TestViewEpam\TestViewEpam\Resources\Article1.txt")),
                linkToFullArticle = "https://www.openbusiness.ru/biz/business/svoy-biznes-khostely/",
                NameImg = "hostel",
                UrlImg = "/Resources/hostel.jpg",
                Tags = new List<Tag>(tags)
            };

            context.Articles.Add(a1);
            context.Articles.Add(a2);
            context.Articles.Add(a3);
            context.SaveChanges();
        }
    }

}
