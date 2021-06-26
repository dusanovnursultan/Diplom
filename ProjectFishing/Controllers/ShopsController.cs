using PagedList;
using ProjectFishing.Infrastructure;
using ProjectFishing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectFishing.Controllers
{
    public class ShopsController : Controller
    {
        public static Context _db = new Context();
        public ActionResult ShowShops()
        {
            return View();
        }
        public ActionResult GetShops(int? Page)
        {
            _db = new Context();
            int pageSize = 10;
            int pageNumber = (Page ?? 1);
            var model = _db.Shops.ToList();
            var ShopsList = new List<ViewModel>();
            var ShopsModel = new PostViewModel();
            foreach (Post item in model)
            {
                var Images = _db.Images.Where(x => x.Post.PostId == item.PostId).ToList();
                ViewModel Shop = new ViewModel();
                Shop.Post = item;
                Shop.Post.Images = null;
                Shop.Images = Images;
                ShopsList.Add(Shop);
            }
            ShopsModel.Posts = ShopsList.ToPagedList(pageNumber, pageSize);
            ShopsModel.TotalDishesCount = ShopsList.Count();
            return new JsonResult() { Data = ShopsModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult ShowMoreInfoAboutShop(int Id)
        {
            ViewBag.IdShop = Id;

            return View();
        }
        [HttpGet]
        public ActionResult GetShopById(int Id)
        {
            _db = new Context();
            var ShopModel = new ViewModel();
            var Images = _db.Images.Where(x => x.Post.PostId == Id).ToList();
            var Shop = _db.Posts.Where(x => x.PostId == Id).FirstOrDefault();
            ShopModel.Images = Images;
            ShopModel.Post = Shop;
            ShopModel.Post.Images = null;

            return new JsonResult() { Data = ShopModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}