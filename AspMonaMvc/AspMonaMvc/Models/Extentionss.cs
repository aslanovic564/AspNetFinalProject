using AspMonaMvc.AddDataConnect;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AspMonaMvc.Models
{
    public class Extentionss
    {

        public bool CheckImageType(HttpPostedFileBase Image)
        {
            return Image.ContentType == "image/jpg" || Image.ContentType == "image/jpeg" || Image.ContentType == "image/png" || Image.ContentType == "image/gif";
        }

        public bool CheckeImageSize(HttpPostedFileBase Image, int mb)
        {
            return Image.ContentLength / 1024 / 1024 < mb;
        }
        public string SaveImage(string folder,HttpPostedFileBase Image)
        {
            string filename = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + Path.GetFileName(Image.FileName);
            string path = Path.Combine(folder, filename);
            Image.SaveAs(path);
            return filename;
        }
        public bool DeleteImage(string folder,string filename)
        {
            string pathToImage = Path.Combine(folder, filename);
            if (File.Exists(pathToImage))
            {
                File.Delete(pathToImage);
                return true;
            }
            return false;
        }

        //public static  Split( string[] str)
        //{
        //    using (ConnectDataModel db= new ConnectDataModel())
        //    {
        //        string description = db.ClientsFedbackModels.FirstOrDefault().Descriptions;
        //        string[] descriptonsaray = description.Split(new char[] { ' ', ',' });
        //    return c
        //    }
           
        //}
    }
}

