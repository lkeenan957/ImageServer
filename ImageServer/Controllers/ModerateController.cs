using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageServer.Controllers
{
    [Authorize(Roles = "Moderator")]
    public class ModerateController : BaseController
    {

        // GET: Moderate
        public ActionResult Index()
        {
            List<ImageUpload> mi = db.GetUnmoderatedImages();
            return View(mi);
        }

        // GET: Moderate
        [HttpPost]
        public ActionResult Index(string submit, int? imageid, string tags)
        {
           return View(db.UpdateModeratedImage(imageid.Value, submit, tags));
        }


    }
}
