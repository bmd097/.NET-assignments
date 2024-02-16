using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleDb.Models {
    public class Article {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PublishedDate { get; set; }
        public string LastModifiedDate { get; set; }
        public string AuthorId;
        public string CategoryId;

        public override string ToString() {
            return $"ArticleId: {ArticleId}, Title: {Title}, Content: {Content}, PublishedDate: {PublishedDate}, LastModifiedDate: {LastModifiedDate}, AuthorId: {AuthorId}, CategoryId: {CategoryId}";
        }
    }
}
