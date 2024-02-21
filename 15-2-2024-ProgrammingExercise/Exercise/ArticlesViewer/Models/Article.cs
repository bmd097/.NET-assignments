using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticlesViewer.Models {
    public class Article {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PublishedDate { get; set; }
        public string LastModifiedDate { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}