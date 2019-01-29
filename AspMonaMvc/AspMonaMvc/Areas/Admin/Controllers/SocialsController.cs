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
    public class SocialsController : Controller
    {
        private ConnectDataModel db = new ConnectDataModel();

        // GET: Admin/Socials
        public async Task<ActionResult> Index()
        {
            var socials = db.Socials.Include(s => s.ModellsChange);
            return View(await socials.ToListAsync());
        }

        // GET: Admin/Socials/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social social = await db.Socials.FindAsync(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // GET: Admin/Socials/Create
        public ActionResult Create()
        {
            ViewBag.ModellsChangeId = new SelectList(db.ModellsChanges, "Id", "ModelFullName");
            return View();
        }

        // POST: Admin/Socials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Facebook,Tviter,Pinterest,Instagram,Youtube,ModellsChangeId")] Social social)
        {
            if (ModelState.IsValid)
            {
                db.Socials.Add(social);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ModellsChangeId = new SelectList(db.ModellsChanges, "Id", "ModelFullName", social.ModellsChangeId);
            return View(social);
        }

        // GET: Admin/Socials/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social social = await db.Socials.FindAsync(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModellsChangeId = new SelectList(db.ModellsChanges, "Id", "ModelFullName", social.ModellsChangeId);
            return View(social);
        }

        // POST: Admin/Socials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Facebook,Tviter,Pinterest,Instagram,Youtube,ModellsChangeId")] Social social)
        {
            if (ModelState.IsValid)
            {
                db.Entry(social).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ModellsChangeId = new SelectList(db.ModellsChanges, "Id", "ModelFullName", social.ModellsChangeId);
            return View(social);
        }

        // GET: Admin/Socials/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Social social = await db.Socials.FindAsync(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            return View(social);
        }

        // POST: Admin/Socials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Social social = await db.Socials.FindAsync(id);
            db.Socials.Remove(social);
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
