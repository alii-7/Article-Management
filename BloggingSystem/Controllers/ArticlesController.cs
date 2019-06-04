using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloggingSystem.Models;
using Microsoft.AspNet.Identity;

namespace BloggingSystem.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Articles
        public ActionResult Index()
        {
            var articles = db.Articles.Include(a => a.Category);
            if(User.IsInRole("CanManageArticles"))
            {
                return View("IndexAdmin", articles.ToList());
            }
            return View("Index", articles.ToList());
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var articles = db.Articles.Include(a => a.Category).OrderBy(a => a.Title);
            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.Title.Contains(searchString)).OrderBy(a => a.Title);
            }
            
            if (User.IsInRole("CanManageArticles"))
            {
                return View("IndexAdmin", articles.ToList());
            }
            return View("Index", articles.ToList());
        }

        [HttpPost]
        public ActionResult Save(Article article)
        {
            try
             {
                Comment comment = new Comment
                {
                    CommentText = article.comment,
                    UserID = User.Identity.GetUserId(),
                    ArticleID = article.ID,
                };
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View("Articles/Details/"+article.ID);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            List<Comment> comments = db.Comments.Where(x => x.ArticleID == id).ToList();
   
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Article article = db.Articles.Find(id);
            article.Comments = comments;
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }


        // GET: Articles/Create
        [Authorize(Roles = "CanManageArticles")]
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageArticles")]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", article.CategoryID);
            return View(article);
        }

        // GET: Articles/Edit/5
        [Authorize(Roles = "CanManageArticles")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", article.CategoryID);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageArticles")]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", article.CategoryID);
            return View(article);
        }

        // GET: Articles/Delete/5
        [Authorize(Roles = "CanManageArticles")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "CanManageArticles")]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
