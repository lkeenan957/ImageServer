using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ImageServer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ImageServer.database;

namespace ImageServer.Utilities
{
    public class UploadHelper
    {

        public bool UploadImage(HttpPostedFileBase file, string ImageName, string ImageTag, string filePath, string scheme, string authority, string userId)
        {
            
            if (file != null && file.ContentLength > 0)
            {
                dbhelper db = new dbhelper();

                try
                {
                    string path = filePath;

                    ImageUpload iu = new ImageUpload();
                    iu.ImageName = ImageName;
                    iu.UserId = userId;
                    iu.ImagePath = scheme + "://" + authority + "/Images/" + Path.GetFileName(file.FileName);
                    iu.ImageTags = ImageTag;
                    iu.isapproved = false;
                    iu.ismoderated = false;
                    iu.CreateDate = DateTime.Now;
                    iu.UpdateDate = DateTime.Now;

                    file.SaveAs(path);

                    // Put in code to store image metadata in DB.
                    db.saveuserimage(iu);

                    return true;
                    
                }
                catch (Exception)
                {
                    throw;
                    
                }
            }
            else
            {
                return false;
            }

        }
    }
}