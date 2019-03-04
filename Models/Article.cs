using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ConnectLib2.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfPublish { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Url)]
        public string linkToFullArticle { get; set; }
        public string NameImg { get; set; }
        [DataType(DataType.ImageUrl)]
        public string UrlImg { get; set; }

        public List<Tag> Tags { get; set; }
        public Article()
        {
            Tags = new List<Tag>();
        }
    }
}