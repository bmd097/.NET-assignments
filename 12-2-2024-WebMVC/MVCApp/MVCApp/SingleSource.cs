using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp {
    public sealed class SingleSource {

        private SingleSource() {
            models = new List<ArticleModel>();
            ArticleModel model = new ArticleModel();
            model.Title = "Hello!";
            model.AuthorId = 1;
            model.ArticleId = 1;
            model.CategoryId = 1;
            model.Content = "Hi, guys how are you!";
            models.Add(model);
            model = new ArticleModel();
            model.Title = "Task!";
            model.AuthorId = 1;
            model.ArticleId = 2;
            model.CategoryId = 1;
            model.Content = "Complete Them Today!";
            models.Add(model);
        }
        private static SingleSource instance;
        private static object lockObj = new object();
        private static object singleAccessLock = new object();

        public List<ArticleModel> models;
        public int i = 3;

        public static SingleSource GetInstance() {
            if(instance == null) {
                lock (lockObj) {
                    if(instance == null) {
                        instance = new SingleSource();
                    }
                }
            } 
            return instance; 
        }

        public List<ArticleModel> GetAll() {
            lock (singleAccessLock) {
                return this.models;
            }
        }

        public void Add(ArticleModel model) {
            lock(singleAccessLock) {
                model.ArticleId = i++;
                this.models.Add(model);
            }
        }

        public ArticleModel Remove(int id) {
            lock (singleAccessLock) {
                var model = this.models.FirstOrDefault(m => m.ArticleId == id);
                if (model != null) {
                    this.models.Remove(model);
                }
                return model;
            }
        }

        public ArticleModel GetArticle(int id) {
            lock (singleAccessLock) {
                var model = this.models.FirstOrDefault(m => m.ArticleId.Equals(id));
                return model;
            }
        }

        public void Update(ArticleModel model) {
            lock (singleAccessLock) {
                var existingModel = this.models.FirstOrDefault(m => m.ArticleId == model.ArticleId);
                if (existingModel != null) {
                    existingModel.Title = model.Title;
                    existingModel.Content = model.Content;
                    existingModel.PublishedDate = model.PublishedDate;
                    existingModel.LastModifiedDate = model.LastModifiedDate;
                    existingModel.AuthorId = model.AuthorId;
                    existingModel.CategoryId = model.CategoryId;
                }
            }
        }

    }
}