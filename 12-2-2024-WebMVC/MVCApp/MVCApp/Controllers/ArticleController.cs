using MVCApp.contexts;
using MVCApp.Entities;
using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class ArticleController : Controller
    {

        MyDBContext db = new MyDBContext();

        // GET: Article
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
            //return View(SingleSource.GetInstance().models);
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            ArticleModel model = db.Articles.Find(id);
            if (model == null) {
                return HttpNotFound();
            }
            return View(model);
            /*
            ArticleModel model = SingleSource.GetInstance().GetArticle(id);
            if (model == null) {
                return HttpNotFound();
            }
            return View(model);
            */
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleModel articleModel)
        {
            db.Articles.Add(articleModel);
            db.SaveChanges();
            return RedirectToAction("Index");
            /*
            SingleSource.GetInstance().Add(articleModel);
            return RedirectToAction("Index");
            */
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            ArticleModel model = db.Articles.Find(id);
            if (model == null)
                return HttpNotFound();
            return View(model);
            /*
            ArticleModel model = SingleSource.GetInstance().GetArticle(id);
            if(model  == null)
                return HttpNotFound();
            return View(model);
            */
        }

        // POST: Article/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ArticleModel article)
        {
            db.Entry(article).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            /*
            article.ArticleId = id;
            SingleSource.GetInstance().Update(article);
            return View(article);
            */
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            ArticleModel model = db.Articles.Find(id);
            if (model == null)
                return HttpNotFound();
            return View(model);
            /*
            ArticleModel model = SingleSource.GetInstance().GetArticle(id);
            if (model == null)
                return HttpNotFound();
            return View(model);
            */
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ArticleModel model)
        {
            ArticleModel model2 = db.Articles.Find(id);
            db.Articles.Remove(model2);
            db.SaveChanges();
            return RedirectToAction("Index");
            /*
            model.ArticleId = id;
            ArticleModel model2 = SingleSource.GetInstance().Remove(id);
            if(model2 == null) return HttpNotFound();
            return RedirectToAction("Index");
            */

        }
    }
}
