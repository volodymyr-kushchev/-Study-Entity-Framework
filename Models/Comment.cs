using System;
using System.ComponentModel.DataAnnotations;

namespace ConnectLib2.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfNotice { get; set; }
    }
}