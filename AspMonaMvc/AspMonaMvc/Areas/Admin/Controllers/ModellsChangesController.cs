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
    public class ModellsChangesController : Controller
    {
        private ConnectDataModel db = new ConnectDataModel();

        // GET: Admin/ModellsChanges
        public async Task<ActionResult> Index()
        {
            var modellsChanges = db.ModellsChanges.Include(m => m.ModelCategory);
            return View(await modellsChanges.ToListAsync());
        }

        // GET: Admin/ModellsChanges/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModellsChange modellsChange = await db.ModellsChanges.FindAsync(id);
            if (modellsChange == null)
            {
                return HttpNotFound();
            }
            return View(modellsChange);
        }

        // GET: Admin/ModellsChanges/Create
        public ActionResult Create()
        {
            ViewBag.ModelCategoryId = new SelectList(db.ModelCategories, "Id", "CategoryName");
            return View();
        }

        // POST: Admin/ModellsChanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ModelFullName,FigurStatus,ModelCategoryId")] ModellsChange modellsChange)
        {
            if (ModelState.IsValid)
            {
                db.ModellsChanges.Add(modellsChange);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ModelCategoryId = new SelectList(db.ModelCategories, "Id", "CategoryName", modellsChange.ModelCategoryId);
            return View(modellsChange);
        }

        // GET: Admin/ModellsChanges/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModellsChange modellsChange = await db.ModellsChanges.FindAsync(id);
            if (modellsChange == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModelCategoryId = new SelectList(db.ModelCategories, "Id", "CategoryName", modellsChange.ModelCategoryId);
            return View(modellsChange);
        }

        // POST: Admin/ModellsChanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ModelFullName,FigurStatus,ModelCategoryId")] ModellsChange modellsChange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modellsChange).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ModelCategoryId = new SelectList(db.ModelCategories, "Id", "CategoryName", modellsChange.ModelCategoryId);
            return View(modellsChange);
        }

        // GET: Admin/ModellsChanges/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModellsChange modellsChange = await db.ModellsChanges.FindAsync(id);
            if (modellsChange == null)
            {
                return HttpNotFound();
            }
            return View(modellsChange);
        }

        // POST: Admin/ModellsChanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ModellsChange modellsChange = await db.ModellsChanges.FindAsync(id);
            db.ModellsChanges.Remove(modellsChange);
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
