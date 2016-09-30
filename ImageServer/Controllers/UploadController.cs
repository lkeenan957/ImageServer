﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ImageServer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

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
            if (file != null && file.ContentLength > 0)
            {
             
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));

                    ImageUpload iu = new ImageUpload();
                    iu.ImageName = ImageName;
                    iu.UserId = User.Identity.GetUserId();
                    iu.ImagePath = Request.Url.Scheme + "://" + Request.Url.Authority + "/Images/" + Path.GetFileName(file.FileName);
                    iu.ImageTags = ImageTag;
                    iu.isapproved = false;
                    iu.ismoderated = false;
                    iu.CreateDate = DateTime.Now;
                    iu.UpdateDate = DateTime.Now;

                    file.SaveAs(path);

                    // Put in code to store image metadata in DB.
                    db.saveuserimage(iu);

                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {

                    ViewBag.Message = "Error: " + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file";
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
