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
    public class ModelCategoriesController : Controller
    {
        private ConnectDataModel db = new ConnectDataModel();

        // GET: Admin/ModelCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.ModelCategories.ToListAsync());
        }

        // GET: Admin/ModelCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelCategory modelCategory = await db.ModelCategories.FindAsync(id);
            if (modelCategory == null)
            {
                return HttpNotFound();
            }
            return View(modelCategory);
        }

        // GET: Admin/ModelCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ModelCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CategoryName")] ModelCategory modelCategory)
        {
            if (ModelState.IsValid)
            {
                db.ModelCategories.Add(modelCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(modelCategory);
        }

        // GET: Admin/ModelCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelCategory modelCategory = await db.ModelCategories.FindAsync(id);
            if (modelCategory == null)
            {
                return HttpNotFound();
            }
            return View(modelCategory);
        }

        // POST: Admin/ModelCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CategoryName")] ModelCategory modelCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modelCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(modelCategory);
        }

        // GET: Admin/ModelCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModelCategory modelCategory = await db.ModelCategories.FindAsync(id);
            if (modelCategory == null)
            {
                return HttpNotFound();
            }
            return View(modelCategory);
        }

        // POST: Admin/ModelCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ModelCategory modelCategory = await db.ModelCategories.FindAsync(id);
            db.ModelCategories.Remove(modelCategory);
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
