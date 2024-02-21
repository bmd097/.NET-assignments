using ArticleDb;
using ArticleDb.Models;
using ArticlesViewer.Filters;
using ArticlesViewer.Models;
using ArticlesViewer.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;


namespace ArticlesViewer.Controllers
{
    [JwtAuthorizationFilter]
    [LogActionFilterAttribute]
    public class WordVoyagerController : Controller {

        public WordVoyagerController() {
            JwtUtils.secretKey = ConfigurationManager.AppSettings["SecretKey"];
        }

        // GET: WordVoyager
        public ActionResult Index(int page = 0, int limit = 3,string searchTitle = null) {
            if (page < 0)
                page = 0;
            if (limit < 3)
                limit = 3;
            var articlesFromDb = (searchTitle != null) ? 
                WordVoyagerDb.GetInstance().GetArticles(searchTitle) :
                WordVoyagerDb.GetInstance().GetArticles(page, limit);
            var usersDictionary = new Dictionary<string, string>();
            var categoriesDictionary = new Dictionary<string, string>();
            foreach (var category in WordVoyagerDb.GetInstance().GetCategories())
                categoriesDictionary[category.CategoryId + ""] = category.Name;
            foreach (var user in WordVoyagerDb.GetInstance().GetUsers())
                usersDictionary[user.UserId + ""] = user.Username;
            List<ArticlesViewer.Models.Article> articles = new List<ArticlesViewer.Models.Article>();
            foreach (var articleDb in articlesFromDb) {
                var article = new ArticlesViewer.Models.Article();
                article.ArticleId = articleDb.ArticleId;
                article.Title = articleDb.Title;
                article.Content = articleDb.Content;
                article.PublishedDate = articleDb.PublishedDate;
                article.LastModifiedDate = articleDb.LastModifiedDate;
                article.Author = usersDictionary[articleDb.AuthorId];
                article.Category = categoriesDictionary[articleDb.CategoryId];
                articles.Add(article);
            }
            return View(articles);
        }

        // POST: WordVoyager
        public ActionResult Create([FromBody] ArticlesViewer.Models.Article article) {
            try {
                if (article.Title != null) {
                    var articleDb = new ArticleDb.Models.Article();
                    articleDb.Title = article.Title;
                    articleDb.Content = article.Content;
                    articleDb.PublishedDate = article.PublishedDate;
                    articleDb.LastModifiedDate = article.LastModifiedDate;

                    articleDb.AuthorId = article.AuthorId+"";
                    articleDb.CategoryId = article.CategoryId+"";

                    if (articleDb.AuthorId != null && articleDb.CategoryId != null) {
                        if (WordVoyagerDb.GetInstance().AddArticle(articleDb))
                            return RedirectToAction("Index");
                    } else {

                    }
                }
                

            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            var categoriesDictionary1 = new Dictionary<string, string>();
            foreach (var category in WordVoyagerDb.GetInstance().GetCategories())
                categoriesDictionary1[category.Name] = category.CategoryId + "";
            ViewBag.Categories = categoriesDictionary1;
            var usersDictionary = new Dictionary<string, string>();
            foreach (var user in WordVoyagerDb.GetInstance().GetUsers())
                usersDictionary[user.Username] = user.UserId + "";
            ViewBag.Users = usersDictionary;
            return View();
        }

        public ActionResult Delete(int articleId, bool deleteFlag = false) {
            if (deleteFlag) {
                if (WordVoyagerDb.GetInstance().DeleteArticleById(articleId))
                    return RedirectToAction("Index");
            }
            ArticleDb.Models.Article articleDb = WordVoyagerDb.GetInstance().GetArticleById(articleId);
            var usersDictionary = new Dictionary<string, string>();
            var categoriesDictionary = new Dictionary<string, string>();
            foreach (var category in WordVoyagerDb.GetInstance().GetCategories())
                categoriesDictionary[category.CategoryId + ""] = category.Name;
            foreach (var user in WordVoyagerDb.GetInstance().GetUsers())
                usersDictionary[user.UserId + ""] = user.Username;
            var article = new ArticlesViewer.Models.Article();
            article.ArticleId = articleDb.ArticleId;
            article.Title = articleDb.Title;
            article.Content = articleDb.Content;
            article.PublishedDate = articleDb.PublishedDate;
            article.LastModifiedDate = articleDb.LastModifiedDate;
            article.Author = usersDictionary[articleDb.AuthorId];
            article.Category = categoriesDictionary[articleDb.CategoryId];
            return View(article);
        }

        public ActionResult Edit(int articleId, [FromBody] ArticlesViewer.Models.Article articleToSave) {
            ArticleDb.Models.Article articleDb = WordVoyagerDb.GetInstance().GetArticleById(articleId);
            if (!string.IsNullOrEmpty(articleToSave.Title)) {
                articleDb.Title = articleToSave.Title;
                articleDb.Content = articleToSave.Content;
                articleDb.LastModifiedDate = articleToSave.LastModifiedDate;

                var usersDictionaryEdit = new Dictionary<string, string>();
                var categoriesDictionaryEdit = new Dictionary<string, string>();
                foreach (var category in WordVoyagerDb.GetInstance().GetCategories())
                    categoriesDictionaryEdit[category.Name] = category.CategoryId + "";
                foreach (var user in WordVoyagerDb.GetInstance().GetUsers())
                    usersDictionaryEdit[user.Username] = user.UserId + "";

                articleDb.AuthorId = usersDictionaryEdit[articleToSave.Author];
                articleDb.CategoryId = categoriesDictionaryEdit[articleToSave.Category];

                if(WordVoyagerDb.GetInstance().EditArticle(articleDb))
                    return RedirectToAction("Index");
            }
            var usersDictionary = new Dictionary<string, string>();
            var categoriesDictionary = new Dictionary<string, string>();
            foreach (var category in WordVoyagerDb.GetInstance().GetCategories())
                categoriesDictionary[category.CategoryId + ""] = category.Name;
            foreach (var user in WordVoyagerDb.GetInstance().GetUsers())
                usersDictionary[user.UserId + ""] = user.Username;
            var article = new ArticlesViewer.Models.Article();
            article.ArticleId = articleDb.ArticleId;
            article.Title = articleDb.Title;
            article.Content = articleDb.Content;
            article.PublishedDate = articleDb.PublishedDate;
            article.LastModifiedDate = articleDb.LastModifiedDate;
            article.Author = usersDictionary[articleDb.AuthorId];
            article.Category = categoriesDictionary[articleDb.CategoryId];
            return View(article);
        }

        public ActionResult Logout() {
            var cookie = new HttpCookie("jwtToken") {
                Expires = DateTime.Now.AddDays(-1)
            };
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index","Auth");
        }
    }
}
