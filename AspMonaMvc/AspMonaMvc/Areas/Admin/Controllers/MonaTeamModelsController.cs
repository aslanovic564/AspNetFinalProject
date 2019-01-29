using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspMonaMvc.AddDataConnect;
using AspMonaMvc.Models;

namespace AspMonaMvc.Areas.Admin.Controllers
{
    public class MonaTeamModelsController : Controller
    {
        private ConnectDataModel db = new ConnectDataModel();

        // GET: Admin/MonaTeamModels
        public async Task<ActionResult> Index()
        {
            return View(await db.MonaTeamModels.ToListAsync());
        }

        // GET: Admin/MonaTeamModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonaTeamModel monaTeamModel = await db.MonaTeamModels.FindAsync(id);
            if (monaTeamModel == null)
            {
                return HttpNotFound();
            }
            return View(monaTeamModel);
        }

        // GET: Admin/MonaTeamModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MonaTeamModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TeamImagesDescription,NameTeam,statusTeam")] MonaTeamModel monaTeamModel)
        {
            if (ModelState.IsValid)
            {
                db.MonaTeamModels.Add(monaTeamModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(monaTeamModel);
        }

        // GET: Admin/MonaTeamModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonaTeamModel monaTeamModel = await db.MonaTeamModels.FindAsync(id);
            if (monaTeamModel == null)
            {
                return HttpNotFound();
            }
            return View(monaTeamModel);
        }

        // POST: Admin/MonaTeamModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TeamImagesDescription,NameTeam,statusTeam")] MonaTeamModel monaTeamModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monaTeamModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(monaTeamModel);
        }

        // GET: Admin/MonaTeamModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonaTeamModel monaTeamModel = await db.MonaTeamModels.FindAsync(id);
            if (monaTeamModel == null)
            {
                return HttpNotFound();
            }
            return View(monaTeamModel);
        }

        // POST: Admin/MonaTeamModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MonaTeamModel monaTeamModel = await db.MonaTeamModels.FindAsync(id);
            db.MonaTeamModels.Remove(monaTeamModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
