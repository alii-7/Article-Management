using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloggingSystem.Models;

namespace BloggingSystem.Controllers
{

    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
                
            var articles = db.Articles.Include(a => a.Category).OrderBy(a => a.Title);
            return View("Index", articles.ToList());
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {

            var articles = db.Articles.Include(a => a.Category).OrderBy(a => a.Category.CategoryName);
            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.Category.CategoryName.Contains(searchString)).OrderBy(a => a.Title);
            }

            return View("Index", articles.ToList());
        }
    }
}
