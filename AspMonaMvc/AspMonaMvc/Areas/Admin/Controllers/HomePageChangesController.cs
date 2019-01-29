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
    public class HomePageChangesController : Controller
    {
        private ConnectDataModel db = new ConnectDataModel();

        // GET: Admin/HomePageChanges
        public async Task<ActionResult> Index()
        {
            return View(await db.HomePageChanges.ToListAsync());
        }

        // GET: Admin/HomePageChanges/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomePageChange homePageChange = await db.HomePageChanges.FindAsync(id);
            if (homePageChange == null)
            {
                return HttpNotFound();
            }
            return View(homePageChange);
        }

        // GET: Admin/HomePageChanges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HomePageChanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Facebook,Tviter,Pinterest,Instagram,Youtube")] HomePageChange homePageChange)
        {
            if (ModelState.IsValid)
            {
                db.HomePageChanges.Add(homePageChange);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(homePageChange);
        }

        // GET: Admin/HomePageChanges/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomePageChange homePageChange = await db.HomePageChanges.FindAsync(id);
            if (homePageChange == null)
            {
                return HttpNotFound();
            }
            return View(homePageChange);
        }

        // POST: Admin/HomePageChanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Facebook,Tviter,Pinterest,Instagram,Youtube")] HomePageChange homePageChange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homePageChange).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(homePageChange);
        }

        // GET: Admin/HomePageChanges/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomePageChange homePageChange = await db.HomePageChanges.FindAsync(id);
            if (homePageChange == null)
            {
                return HttpNotFound();
            }
            return View(homePageChange);
        }

        // POST: Admin/HomePageChanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HomePageChange homePageChange = await db.HomePageChanges.FindAsync(id);
            db.HomePageChanges.Remove(homePageChange);
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
