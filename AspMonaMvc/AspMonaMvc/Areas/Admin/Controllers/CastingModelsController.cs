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
    public class CastingModelsController : Controller
    {
        private ConnectDataModel db = new ConnectDataModel();

        // GET: Admin/CastingModels
        public async Task<ActionResult> Index()
        {
            var castingModels = db.CastingModels.Include(c => c.ImageContent);
            return View(await castingModels.ToListAsync());
        }

        // GET: Admin/CastingModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastingModel castingModel = await db.CastingModels.FindAsync(id);
            if (castingModel == null)
            {
                return HttpNotFound();
            }
            return View(castingModel);
        }

        // GET: Admin/CastingModels/Create
        public ActionResult Create()
        {
            ViewBag.ImageContentId = new SelectList(db.ImageContents, "Id", "ImageUrlName");
            return View();
        }

        // POST: Admin/CastingModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CastHeader,CastResumeHeader,ImageContentId")] CastingModel castingModel)
        {
            if (ModelState.IsValid)
            {
                db.CastingModels.Add(castingModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ImageContentId = new SelectList(db.ImageContents, "Id", "ImageUrlName", castingModel.ImageContentId);
            return View(castingModel);
        }

        // GET: Admin/CastingModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastingModel castingModel = await db.CastingModels.FindAsync(id);
            if (castingModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ImageContentId = new SelectList(db.ImageContents, "Id", "ImageUrlName", castingModel.ImageContentId);
            return View(castingModel);
        }

        // POST: Admin/CastingModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CastHeader,CastResumeHeader,ImageContentId")] CastingModel castingModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(castingModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ImageContentId = new SelectList(db.ImageContents, "Id", "ImageUrlName", castingModel.ImageContentId);
            return View(castingModel);
        }

        // GET: Admin/CastingModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CastingModel castingModel = await db.CastingModels.FindAsync(id);
            if (castingModel == null)
            {
                return HttpNotFound();
            }
            return View(castingModel);
        }

        // POST: Admin/CastingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CastingModel castingModel = await db.CastingModels.FindAsync(id);
            db.CastingModels.Remove(castingModel);
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
