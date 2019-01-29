using AspMonaMvc.AddDataConnect;
using AspMonaMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AspMonaMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ConnectDataModel db;

        public HomeController()
        {
            db = new ConnectDataModel();
        }
        // GET: Home
        public ActionResult Index(int catId = 0)
        {


            HomePageViewModel model = new HomePageViewModel
            {
                ModellsChanges = db.ModellsChanges
                                        .Include(m => m.ImageContents).Where(x => catId == 0 || x.ModelCategoryId == catId)

                                            .ToList(),
                Socials = db.Socials.Include(mbox=>mbox.ModellsChange)
                                         .ToList(),
                ClientsFedbackModels = db.ClientsFedbackModels
                                            .ToList(),
                ModelCategories = db.ModelCategories.ToList(),
                HomePageChanges = db.HomePageChanges.ToList()
            };

            return View(model);
        }

        public ActionResult About()
        {
            return View();

        }
        public ActionResult Contact()
        {
            return View();

        }
    }
}