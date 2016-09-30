using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ImageServer.Controllers
{
    [Authorize(Roles = "Provider")]

    public class DownloadReportController : BaseController
    {
        // GET: DownloadReport
        public ActionResult Index()
        {
            return View();
        }

        /*code for handle download report
        [HttpGet]
        public ActionResult Index()
        {
           
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
        };
        */

        // GET: DownloadReport/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DownloadReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DownloadReport/Create
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

        // GET: DownloadReport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DownloadReport/Edit/5
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

        // GET: DownloadReport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DownloadReport/Delete/5
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
