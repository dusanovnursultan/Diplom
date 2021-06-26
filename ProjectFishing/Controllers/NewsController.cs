using ProjectFishing.Infrastructure;
using ProjectFishing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace ProjectFishing.Controllers
{
    public class NewsController : Controller
    {
        public static Context _db = new Context();
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetNews(int? Page)
        {
            _db = new Context();
            int pageSize = 10;
            int pageNumber = (Page ?? 1);
            var model = _db.News.ToList();
            var NewsModel = new NewsViewModel();
            NewsModel.News = model.ToPagedList(pageNumber, pageSize);
            NewsModel.TotalDishesCount = model.Count();
            return new JsonResult() { Data = NewsModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult AddNews()
        {

            return View();
        }
    }
}