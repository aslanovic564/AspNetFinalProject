using AspMonaMvc.AddDataConnect;
using AspMonaMvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMonaMvc.Controllers
{
    public class CastingController : Controller
    {
        // GET: Casting
        ConnectDataModel model = new ConnectDataModel();
        public ActionResult Casting()
        {

            ViewModelsConnection con = new ViewModelsConnection()
            {
                MonaTeamModel = model.MonaTeamModels.FirstOrDefault(),
                ContactUserModel = model.ContactUserModels.FirstOrDefault(),
                CastingModel = model.CastingModels.FirstOrDefault(),
                //ModellsChange = model.ModellsChanges.ToList(),
                //ModelCategory = model.ModelCategories.ToList(),
                ImageContents = model.ImageContents.ToList()
            };
            return View(con);
        }
    }
}