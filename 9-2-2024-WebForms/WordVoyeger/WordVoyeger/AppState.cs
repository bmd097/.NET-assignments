using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordVoyegerBackend;

namespace WordVoyeger {
    public class AppState {

        private static AppState instance;
        private static object lockObj = new object ();
        private WordVoyegerAPI api;
        public List<Category> categories;
        public Dictionary<int, List<RenderArticle>> dictionary;

        private AppState() {
            api = WordVoyegerAPI.GetInstance();
            categories = api.FetchCategories();
            dictionary = new Dictionary<int, List<RenderArticle>> ();
        }

        public static AppState GetInstance() {
            if(instance == null) {
                lock(lockObj) {
                    if(instance == null) {
                        instance = new AppState();
                    }
                }
            } 
            return instance; 
        }

        public static List<RenderArticle> ConvertTo(List<WordVoyegerBackend.Article> articleBackendList) {
            var list = new List<RenderArticle>();
            foreach (var articleBackend in articleBackendList) {
                var renderArticle = new RenderArticle();
                renderArticle.Id = articleBackend.Id;
                renderArticle.Title = articleBackend.Title;
                renderArticle.content = articleBackend.content;
                renderArticle.publishedDate = articleBackend.publishedDate;
                renderArticle.categoryId = articleBackend.categoryId;
                renderArticle.lastUpdatedDate = articleBackend.lastUpdatedDate;
                renderArticle.authorName = articleBackend.authorName;
                renderArticle.authorEmail = articleBackend.authorEmail;
                renderArticle.tags = articleBackend.tags;
                list.Add(renderArticle);
            }
            return list;
        }

        public void Init() {
            var articleBackendList = WordVoyegerAPI.GetInstance().FetchArticlesByCategoryId(3);
            dictionary[3]=ConvertTo(articleBackendList);
        }
    }
}