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
            List<ModerateImages> mi = db.Getuserdownloadedimage(User.Identity.GetUserId());
            return View(mi);
        }

            // GET: Moderate
            public ActionResult Index()
        {
            return View();
        }

        // GET: Moderate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Moderate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moderate/Create
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

        // GET: Moderate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Moderate/Edit/5
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

        // GET: Moderate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Moderate/Delete/5
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
