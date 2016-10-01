using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ImageServer.Models;

namespace ImageServer.database
{
    
    public class dbhelper
    {
        ImageServer.Entities dbctx = null;

        #region provider role
        public int saveuserimage(ImageUpload ui)
        {
            using (dbctx = new Entities())
            {
                try
                {
                    dbctx.ImageUploads.Add(ui);
                    return dbctx.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        #endregion


        public List<DownLoadcount> Getuserdownloadedimage(string userid, DateTime? startdate = null, DateTime? enddate = null)
        {
            using (dbctx = new Entities())
            {
                List<DownLoadcount> dll = new List<DownLoadcount>();
                try
                {
                    //if(startdate == null && enddate == null)
                    {
                        var temp = from dl in dbctx.DownloadLogs where dl.UserId == userid group dl by dl.ImageId into c select new { id = c.Key, count = c.Count() };

                        dll = Createdownloadcountcollection(temp, dbctx);

                        return dll;
                    }
                   
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private List<DownLoadcount> Createdownloadcountcollection(dynamic a, Entities dbctx)
        {
            List<DownLoadcount> count = new List<DownLoadcount>();


            foreach (var i in a)
            {
                ImageUpload iu = dbctx.ImageUploads.Find(i.id);

                count.Add(new DownLoadcount() { imageid = i.id, downloadcount = i.count, imagename = iu.ImageName, imagepath = iu.ImagePath });
            }

            return count;
        }

        private List<DownLoadcount> 
    }
}