using MeitalOfmanMVC.ContentDataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeitalOfmanMVC.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        ContentDataModel db = new ContentDataModel();

        // GET: Post
        public ActionResult Index()
        {
            var model = db.Posts.ToList();
            return View(model);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(Post post, IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                var postCreated = db.Posts.Add(post);
                db.SaveChanges();
                var uploadPostFolderPath = Path.Combine(Server.MapPath("~/App_Data/uploads"), postCreated.Id.ToString());
                Directory.CreateDirectory(uploadPostFolderPath);
                foreach (var file in files)
                {
                    if (!file.ContentType.Contains("image") || file.ContentLength <= 0) return View();
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(uploadPostFolderPath, fileName);
                    file.SaveAs(path);
                    db.PostImages.Add(new PostImage
                    {
                        ImageName = fileName,
                        ImagePath = path,
                        PostId = postCreated.Id
                    });
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            var postToDelete = db.Posts.Single(x => x.Id == id);
            var postImagesToDelete = db.PostImages.Where(x => x.PostId == id).ToList();
            db.PostImages.RemoveRange(postImagesToDelete);
            db.Posts.Remove(postToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                db.Posts.Remove(db.Posts.Single(x=> x.Id == id));
                return RedirectToAction("Index");
            }
            catch
            {
                //failed
                return RedirectToAction("Index");
            }
        }

        public ActionResult Search(string searchTerm = null)
        {
            var model = db.Posts.Where(x => searchTerm == null || x.Headline.Contains(searchTerm)).ToList();

            if (Request.IsAjaxRequest()) {
                return PartialView("PostsTable", model);
            }

            return View(model) ;
        }
    }
}
