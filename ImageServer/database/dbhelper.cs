using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ImageServer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

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
                    if(startdate == null && enddate == null)
                    {
                        var temp = from dl in dbctx.DownloadLogs where dl.UserId == userid group dl by dl.ImageId into c select new { id = c.Key, count = c.Count() };

                        dll = Createdownloadcountcollection(temp, dbctx);

                        
                    }
                    else if(startdate != null && enddate != null)
                    {
                        var temp = from dl in dbctx.DownloadLogs where dl.UserId == userid && dl.DownloadDate >= startdate && dl.DownloadDate <= enddate group dl by dl.ImageId into c select new { id = c.Key, count = c.Count() };

                        dll = Createdownloadcountcollection(temp, dbctx);
                    }

                    return dll;
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

        #region Moderator Role

        public List<ImageUpload> GetUnmoderatedImages()
        {
            List<ImageUpload> iu = new List<ImageUpload>();

            using (dbctx = new Entities())
            {
                try
                {
                    var temp = from m in dbctx.ImageUploads where m.ismoderated == false select m; 
                    return temp.ToList<ImageUpload>();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<ImageUpload> UpdateModeratedImage(int imageid, string action, string tags)
        {
            List<ImageUpload> iu = new List<ImageUpload>();

            using (dbctx = new Entities())
            {
                try
                {

                    ImageUpload temp = dbctx.ImageUploads.Find(imageid);

                    temp.ismoderated = true;
                    temp.isapproved = (action == "Approve");
                    temp.ImageTags = tags;

                    dbctx.SaveChanges();

                    var imagetemp = from m in dbctx.ImageUploads where m.ismoderated == false select m;
                    return imagetemp.ToList<ImageUpload>();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        #endregion

        #region Administrator Role
        public List<ImageUpload> GetImages()
        {
            List<ImageUpload> iu = new List<ImageUpload>();

            using (dbctx = new Entities())
            {
                try
                {
                    var temp = from m in dbctx.ImageUploads select m;
                    return temp.ToList<ImageUpload>();
                }
                catch
                {
                    throw;
                }
            }
        }

        public List<ImageUpload> UpdateImages(int imageid, string isapproved, string ismoderated, string tags)
        {
            List<ImageUpload> ui = new List<ImageUpload>();

            using (dbctx = new Entities())
            {
                try
                {
                    ImageUpload temp = dbctx.ImageUploads.Find(imageid);

                    temp.ismoderated = (ismoderated == "Yes");
                    temp.isapproved = (isapproved == "Yes");
                    temp.ImageTags = tags;

                    dbctx.SaveChanges();

                    var imagetemp = from m in dbctx.ImageUploads select m;
                    return imagetemp.ToList<ImageUpload>();

                }
                catch(Exception)
                {
                    throw;
                }
            }
        }

        public bool DeleteImages(int imageid)
        {
            bool success = false;
            using (dbctx = new Entities())
            {
                try
                {
                    ImageUpload iu = dbctx.ImageUploads.Find(imageid);

                    dbctx.ImageUploads.Remove(iu);

                    dbctx.SaveChanges();

                    success = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return success;
        }

        public List<AspNetUser> GetAllUsers()
        {
            List<AspNetUser> allUsers = new List<AspNetUser>();
            using (dbctx = new Entities())
            {
                try
                {
                    var au = from u in dbctx.AspNetUsers select u;

                    allUsers = au.ToList<AspNetUser>();

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return allUsers;
        }

        //public List<AspNetUser> AddUser(string submit, string firstname, string lastname, string email, int phonenumber, string username, string password, int userid)
        //{
            
        //    using (dbctx = new Entities())
        //    {
        //        try
        //        {

        //            ApplicationUser user = new ApplicationUser() { UserName = username, Email = username };
        //            IdentityResult i = Use


        //            dbctx.SaveChanges();
        //            var usertemp = from m in dbctx.AspNetUsers select m;
        //            return usertemp.ToList<AspNetUser>();
                    
        //        }
        //        catch(Exception)
        //        {
        //            throw;
        //        }
        //    }

            
        //}
        public bool DeleteUser(string userid)
        {
            bool success = false;
            using (dbctx = new Entities())
            {
                try
                {
                    AspNetUser user = dbctx.AspNetUsers.Find(userid);

                    dbctx.AspNetUsers.Remove(user);

                    dbctx.SaveChanges();

                    success = true;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return success;
        }

        #endregion

        #region Consumer Role
        
        public List<ImageUpload> GetImageUploadByTags(string tags)
        {
            List<ImageUpload> iu = new List<ImageUpload>();

            var searchtags = tags.Split(' ');

            using (dbctx = new Entities())
            {
                HashSet<ImageUpload> iuh = new HashSet<ImageUpload>();
                try
                {
                    foreach(string s in searchtags)
                    {
                        iuh.UnionWith(((from u in dbctx.ImageUploads.AsEnumerable() where u.isapproved == true && u.ImageTags.Contains(s) select u)));
                    }

                    iu = iuh.ToList<ImageUpload>();

                    return iu;
                }
                catch
                {
                    throw;
                }
            }
        }
        
        #endregion
    }
}