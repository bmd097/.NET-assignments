using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleDb {
    internal sealed class Program {
        static void Main(string[] args) {

            var db = WordVoyagerDb.GetInstance();

            var articles = db.GetArticles(1,3);
            foreach (var article in articles) 
                Console.WriteLine(article.ToString());

            var users = db.GetUsers();
            foreach (var user in users)
                Console.WriteLine(user.ToString());

            var categories = db.GetCategories();
            foreach (var category in categories)
                Console.WriteLine(category.ToString());

            articles = db.GetArticles("C#");
            foreach (var article in articles)
                Console.WriteLine(article.ToString());

            Console.ReadLine();

        }
    }
}
