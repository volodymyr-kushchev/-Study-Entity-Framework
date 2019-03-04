using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectLib2.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Text { get; set; }

        public List<Article> Articles { get; set; }
        public Tag()
        {
            Articles = new List<Article>();
        }
    }
}
