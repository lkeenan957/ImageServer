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

    }
}