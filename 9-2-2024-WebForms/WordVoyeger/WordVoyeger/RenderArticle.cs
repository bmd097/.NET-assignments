using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordVoyeger {
    public class RenderArticle {
            public int Id { get; set; }
            public string Title { get; set; }
            public string content { get; set; }
            public DateTime publishedDate { get; set; }
            public DateTime lastUpdatedDate { get; set; }
            public string authorName { get; set; }
            public string authorEmail { get; set; }
            public int categoryId { get; set; }
            public List<string> tags { get; set; }
   
    }
}