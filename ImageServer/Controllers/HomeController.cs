using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageServer.Controllers
{
    public class HomeController : BaseController
    {

        //Get Images for consumers
        public ActionResult Index()
       {
           List<ImageUpload> mi = db.GetAllApprovedImages();
            return View(mi);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}