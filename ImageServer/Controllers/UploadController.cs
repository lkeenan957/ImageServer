using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ImageServer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ImageServer.Utilities;

namespace ImageServer.Controllers
{
    [Authorize(Roles = "Provider")]
 
    public class UploadController : BaseController
    {
     

        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        // code to handle uploading files
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string ImageName, string ImageTag)
        {
            UploadHelper helper = new UploadHelper();

            string filePath = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));
            string userId = User.Identity.GetUserId();
            string scheme = Request.Url.Scheme;
            string authority = Request.Url.Authority;

            if (helper.UploadImage(file, ImageName, ImageTag, filePath, scheme, authority, userId))
            {
                ViewBag.Message = "File uploaded successfully";
            }
            else
            {
                ViewBag.Message = "Error: There was an issue with file upload.";
            }
            return View();
        }

        // GET: Upload/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Upload/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Upload/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Upload/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Upload/Edit/5
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

        // GET: Upload/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Upload/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
