using MeitalOfmanMVC.ContentDataModels;
using System.IO;
using System.Web.Mvc;

namespace MeitalOfmanMVC.Controllers
{
    public class ImageController : Controller
    {
        ContentDataModel db = new ContentDataModel();

        public ActionResult Show(int id)
        {
            var postImage = db.PostImages.Find(id);
            var actualImage = System.IO.File.ReadAllBytes(postImage.ImagePath);
            return File(actualImage, "image/jpg");
        }
    }
}