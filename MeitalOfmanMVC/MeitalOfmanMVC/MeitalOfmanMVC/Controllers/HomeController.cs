using MeitalOfmanMVC.Models;
using System.Web.Mvc;
using MeitalOfmanMVC.ContentDataModels;
using System.Linq;

namespace MeitalOfmanMVC.Controllers
{
    public class HomeController : Controller
    {
        ContentDataModel db = new ContentDataModel();
        public ActionResult Index()
        {
            var model = db.Posts.OrderByDescending(x=>x.Id).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}