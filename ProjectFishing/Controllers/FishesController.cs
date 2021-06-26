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
    public class FishesController : Controller
    {
        public static Context _db;
        // GET: Fishes
        public ActionResult ShowFishes()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetFishies(int? Page)
        {
            _db = new Context();
            int pageSize = 10;
            int pageNumber = (Page ?? 1);
            var model = _db.Fishies.ToList();
            var FishesList = new List<ViewModel>();
            var FishesModel = new PostViewModel();
            foreach (Post item in model)
            {
                var Images = _db.Images.Where(x => x.Post.PostId == item.PostId).ToList();
                ViewModel Fish = new ViewModel();
                Fish.Post = item;
                Fish.Post.Images = null;
                Fish.Images = Images;
                FishesList.Add(Fish);
            }
            FishesModel.Posts = FishesList.ToPagedList(pageNumber, pageSize);
            FishesModel.TotalDishesCount = FishesList.Count();

            return new JsonResult() { Data = FishesModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }


        [HttpGet]
        public ActionResult GetFishById(int Id)
        {
            _db = new Context();
            var FishModel = new ViewModel();
            var Images = _db.Images.Where(x => x.Post.PostId == Id).ToList();
            var Fish = _db.Posts.Where(x => x.PostId == Id).FirstOrDefault();
            FishModel.Images = Images;
            FishModel.Post = Fish;
            FishModel.Post.Images = null;
            


            return new JsonResult() { Data = FishModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }


        public ActionResult ShowMoreInfoAboutFish(int Id)
        {
            ViewBag.IdFish = Id;

            return View();
        }
    }
}