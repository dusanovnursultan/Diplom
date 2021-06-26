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
    public class LakesController : Controller
    {
        public static Context _db;
        // GET: Fishes
        public ActionResult ShowLakes()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetLakes(int? Page)
        {
            _db = new Context();
            int pageSize = 10;
            int pageNumber = (Page ?? 1);
            var model = _db.Lakes.ToList();

            var LakesList = new List<ViewModel>();
            var LakesModel = new PostViewModel();

            foreach (Post item in model)
            {
                var Images = _db.Images.Where(x => x.Post.PostId == item.PostId).ToList();
                ViewModel Lake = new ViewModel();
                Lake.Post = item;
                Lake.Post.Images = null;
                Lake.Images = Images;
                LakesList.Add(Lake);

            }
            LakesModel.Posts = LakesList.ToPagedList(pageNumber, pageSize);
            LakesModel.TotalDishesCount = LakesList.Count();

            return new JsonResult() { Data = LakesModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }


        [HttpGet]
        public ActionResult GetLakeById(int Id)
        {
            _db = new Context();
            var LakeModel = new ViewModel();
            var Images = _db.Images.Where(x => x.Post.PostId == Id).ToList();
            var Lake = _db.Posts.Where(x => x.PostId == Id).FirstOrDefault();
            LakeModel.Images = Images;
            LakeModel.Post = Lake;
            LakeModel.Post.Images = null;

            return new JsonResult() { Data = LakeModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }


        public ActionResult ShowMoreInfoAboutLake(int Id)
        {
            ViewBag.IdLake = Id;

            return View();
        }
    }
}