using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ImageServer.Models;

namespace ImageServer.Controllers
{
    [Authorize(Roles = "Provider")]

    public class DownloadReportController : BaseController
    {
        // GET: DownloadReport
        public ActionResult Index()
        {
            List<DownLoadcount> dlc = db.Getuserdownloadedimage(User.Identity.GetUserId());
            return View(dlc);
        }
        
        [HttpPost]
       public ActionResult Index(string startdate, string enddate)
        {
            List<DownLoadcount> dlc = db.Getuserdownloadedimage(User.Identity.GetUserId(),Convert.ToDateTime(startdate), Convert.ToDateTime(enddate));
            return View(dlc);
        }
    }
}
