using AspMonaMvc.AddDataConnect;
using AspMonaMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using AspMonaMvc.ViewModels;


namespace AspMonaMvc.Controllers
{
    public class ModellsController : Controller
    {
        ConnectDataModel db = new ConnectDataModel();

        // GET: Modells
        public ActionResult Modells()
        {
            HomePageViewModel model = new HomePageViewModel
            {
                Images = db.ImageContents.Include(m=>m.ModellsChange).ToList(),   
                ModellsChanges = db.ModellsChanges.Include(m => m.ImageContents).ToList(),
                ModelCategories = db.ModelCategories
                                            .ToList(),
            };

            return View(model);

        }
     
    }
}