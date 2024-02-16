using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise.Models {
    public class ArticleDTO {

        public int ArticleId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime LastModifiedDate { get; set;}
        public String Author { get; set; }
        public String Category { get; set; }
    }
    
}