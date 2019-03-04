using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using ConnectLib2.Models;

namespace ConnectLib2.Context
{
    public class Repository
    {
        public BlogDbContext context;
        public Repository()
        {
            context = new BlogDbContext("connStr");
        }
        public IEnumerable<Article> GetArticles()
        {
            return context.Articles;
        }
        public string GetArticle(int index)
        {
            var con = context.Articles;
            con.ToList();
            Article art = con.Find(index + 1);
            return art.Content;
        }

        public void AddComment(Comment cm)
        {
            if (cm.AuthorName != String.Empty && cm.Content != String.Empty)
            {
                context.Comments.Add(cm);
            }
        }
        public IEnumerable<Comment> GetComment()
        {
            return context.Comments;
        }
        public string GetTagsOfArticle(int numberOfArticle)
        {
            context.Configuration.LazyLoadingEnabled = false;
            string res = "";
            var query = from art in context.Articles.Include(art => art.Tags)
                        select art.Tags;
            var queryList = query.ToList();
            // concatenate all tags into one string
            foreach (var t in queryList[numberOfArticle])
                res += t.Text + ", ";
            // delete last comma
            int index = res.Length - 2;
            res = res.Remove(index);
            return res;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
    
}
