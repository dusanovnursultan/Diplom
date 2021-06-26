using Microsoft.AspNet.Identity;
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
    public class ForumController : Controller
    {
        public Context _db = new Context();
        // GET: Blog
        public ActionResult Index()
        {
            return View("");
        }
        public ActionResult ShowDiscussions(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        [HttpGet]
        public ActionResult GetThemes(int? Page)
        {
            _db = new Context();
            var ListTheme = new List<ThemeDiscussionViewModel>();
            var Themes = _db.Thems.ToList();
            int pageSize = 10;
            int pageNumber = (Page ?? 1);
            foreach (var item in Themes)
            {
                var model = new ThemeDiscussionViewModel();
                item.Discussions.Clear();
                model.Theme = item;
                int count = _db.Discussions.Count(d => d.Theme.ThemeDiscussionId == item.ThemeDiscussionId);
                model.Count = count;
                ListTheme.Add(model);
            }
            var ThemeModel = new PaginationModelTheme();
            ThemeModel.Themes = ListTheme.ToPagedList(pageNumber, pageSize);
            ThemeModel.TotalDishesCount = Themes.Count();
            return new JsonResult() { Data = ThemeModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }
        public ActionResult AddThemeDiscussion()
        {
            var model = new ThemeDiscussion();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddThemeDiscussion(ThemeDiscussion model)
        {
            using (_db = new Context())
            {
                if (ModelState.IsValid)
                {
                    _db.Thems.Add(model);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
        // GET: Forum by id
        public ActionResult GetDiscussionsById(int Id,int? Page)
        {
            int pageSize = 10;
            int pageNumber = (Page ?? 1);
            _db = new Context();
            var DiscussionModel = new PaginationModelDiscussion();
            var _dbUser = new ApplicationDbContext();
            var ListDiscussions = new List<DiscussionViewModel>();
            var Discussions = _db.Discussions.Where(id => id.Theme.ThemeDiscussionId == Id).ToList();
            var model = new DiscussionViewModel();
            foreach (var item in Discussions)
            {
                model = new DiscussionViewModel();
                if (item.UserId != null)
                {
                    var userName = _dbUser.Users.Find(item.UserId).UserName;
                    model.UserName = userName;
                }
                model.Discussion = item;
                int count = _db.ForumComments.Count(d => d.Discussion == item.DiscussionId);
                model.CountThread = count;
                ListDiscussions.Add(model);
            }
            DiscussionModel.Discussions = ListDiscussions.ToPagedList(pageNumber, pageSize);
            DiscussionModel.TotalDishesCount = ListDiscussions.Count();
            return new JsonResult() { Data = DiscussionModel, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }
        public ActionResult AddDiscussion(int Id)
        {
            var model = new Discussion();

            var ThemeDiscussion = _db.Thems.Where(x => x.ThemeDiscussionId == Id).FirstOrDefault();
            ViewBag.Theme = ThemeDiscussion.Name;
            return View(model);
        }
        public ActionResult Thread(int id)
        {
            ViewBag.Id = id;
            return View("");
        }
        [HttpGet]
        public ActionResult GetThread(int Id)
        {
            _db = new Context();
            var _dbUser = new ApplicationDbContext();
            _db.Discussions.Find(Id).CountView++;
            var model = new DiscussionViewModel();
            var discussion = _db.Discussions.Where(x => x.DiscussionId == Id).FirstOrDefault();
            var userName = _dbUser.Users.Find(discussion.UserId).UserName;
            model.Discussion = discussion;
            model.Image = _dbUser.Users.Find(discussion.UserId).Image;
            model.UserName = userName;
            _db.SaveChanges();
            return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDiscussion(Discussion model, int Id,HttpPostedFileBase files)
        {
            using (_db = new Context())
            {
                if (ModelState.IsValid)
                {
                    if (files != null) //проверяем не пустое ли значение
                    {
                        string pathToSave = Server.MapPath("~/Images/ForViews/Forum"); // берем путь куда будем сохранять
                        string ext = System.IO.Path.GetExtension(files.FileName); // берем расширение для файла
                        var id = Guid.NewGuid();
                        string uniqueName = $"{"ImageDiscussion"}{id}{files.FileName}{ext}"; // создаем уникальное имя для файла
                        string fileName = System
                            .IO
                            .Path
                            .Combine(pathToSave, uniqueName); // соединяем все вместе
                        files.SaveAs(fileName); // сохраняем
                        model.Image = uniqueName;
                    }
                    var ActiveUserId = User.Identity.GetUserId();
                    var Date = DateTime.Now.ToShortDateString();
                    model.Date = Date;
                    model.Theme = _db.Thems.Where(t => t.ThemeDiscussionId == Id).FirstOrDefault();
                    model.UserId = ActiveUserId;
                    _db.Discussions.Add(model);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        //Добавление форума
        public ActionResult AddForumComment(ForumComment model)
        {
            using (_db = new Context())
            {
                if (ModelState.IsValid)
                {
                    if (model.Text == null)
                    {
                        return new JsonResult() { Data = "Пустой текст", JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
                    }
                    var ActiveUserId = User.Identity.GetUserId();
                    var Date = DateTime.Now.ToShortDateString();
                    model.Date = Date;
                    model.UserId = ActiveUserId;
                    _db.ForumComments.Add(model);
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetComments(int Id,int? Page)
        {
            _db = new Context();
            int pageSize = 10;
            int pageNumber = (Page ?? 1);
            var commentModels = new CommentViewPagination();
            var _dbUser = new ApplicationDbContext();
            var listComment = new List<ForumCommentsViewModel>();
            var model = _db.ForumComments.Where(x => x.Discussion == Id).ToList();
            foreach (var item in model)
            {
                var comment = new ForumCommentsViewModel();
                comment.Comment = item;
                comment.UserName = _dbUser.Users.Where(u => u.Id == item.UserId).FirstOrDefault().UserName;
                comment.Image = _dbUser.Users.Where(u => u.Id == item.UserId).FirstOrDefault().Image;
                listComment.Add(comment);
            }
            commentModels.Comments = listComment.ToPagedList(pageNumber,pageSize);
            commentModels.TotalCommentCount = listComment.Count();
            commentModels.Page = pageNumber;
            return new JsonResult() { Data = commentModels, JsonRequestBehavior = JsonRequestBehavior.AllowGet, MaxJsonLength = Int32.MaxValue };
        }

        [HttpPost]
        //Добавление форума
        public ActionResult UpdateForumComment(Discussion model)
        {
            using (_db = new Context())
            {
                if (ModelState.IsValid)
                {
                    var Discussion = _db.Discussions.Find(model.DiscussionId);
                    Discussion.Closed = model.Closed;
                    _db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}