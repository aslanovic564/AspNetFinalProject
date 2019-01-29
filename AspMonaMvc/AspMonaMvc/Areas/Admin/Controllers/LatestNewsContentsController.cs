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
    public class LatestNewsContentsController : Controller
    {
        private ConnectDataModel db = new ConnectDataModel();

        // GET: Admin/LatestNewsContents
        public async Task<ActionResult> Index()
        {
            return View(await db.LatestNewsContents.ToListAsync());
        }

        // GET: Admin/LatestNewsContents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatestNewsContent latestNewsContent = await db.LatestNewsContents.FindAsync(id);
            if (latestNewsContent == null)
            {
                return HttpNotFound();
            }
            return View(latestNewsContent);
        }

        // GET: Admin/LatestNewsContents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LatestNewsContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NewsImageUrl,ImageDescription,Date")] LatestNewsContent latestNewsContent)
        {
            if (ModelState.IsValid)
            {
                db.LatestNewsContents.Add(latestNewsContent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(latestNewsContent);
        }

        // GET: Admin/LatestNewsContents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatestNewsContent latestNewsContent = await db.LatestNewsContents.FindAsync(id);
            if (latestNewsContent == null)
            {
                return HttpNotFound();
            }
            return View(latestNewsContent);
        }

        // POST: Admin/LatestNewsContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NewsImageUrl,ImageDescription,Date")] LatestNewsContent latestNewsContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(latestNewsContent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(latestNewsContent);
        }

        // GET: Admin/LatestNewsContents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatestNewsContent latestNewsContent = await db.LatestNewsContents.FindAsync(id);
            if (latestNewsContent == null)
            {
                return HttpNotFound();
            }
            return View(latestNewsContent);
        }

        // POST: Admin/LatestNewsContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LatestNewsContent latestNewsContent = await db.LatestNewsContents.FindAsync(id);
            db.LatestNewsContents.Remove(latestNewsContent);
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
