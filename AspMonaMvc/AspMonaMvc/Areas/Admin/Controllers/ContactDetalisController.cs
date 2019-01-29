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
    public class ContactDetalisController : Controller
    {
        private ConnectDataModel db = new ConnectDataModel();

        // GET: Admin/ContactDetalis
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactDetalis.ToListAsync());
        }

        // GET: Admin/ContactDetalis/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetalis contactDetalis = await db.ContactDetalis.FindAsync(id);
            if (contactDetalis == null)
            {
                return HttpNotFound();
            }
            return View(contactDetalis);
        }

        // GET: Admin/ContactDetalis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ContactDetalis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ContactDetaliss,Reception,Booking,President")] ContactDetalis contactDetalis)
        {
            if (ModelState.IsValid)
            {
                db.ContactDetalis.Add(contactDetalis);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactDetalis);
        }

        // GET: Admin/ContactDetalis/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetalis contactDetalis = await db.ContactDetalis.FindAsync(id);
            if (contactDetalis == null)
            {
                return HttpNotFound();
            }
            return View(contactDetalis);
        }

        // POST: Admin/ContactDetalis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ContactDetaliss,Reception,Booking,President")] ContactDetalis contactDetalis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactDetalis).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactDetalis);
        }

        // GET: Admin/ContactDetalis/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDetalis contactDetalis = await db.ContactDetalis.FindAsync(id);
            if (contactDetalis == null)
            {
                return HttpNotFound();
            }
            return View(contactDetalis);
        }

        // POST: Admin/ContactDetalis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactDetalis contactDetalis = await db.ContactDetalis.FindAsync(id);
            db.ContactDetalis.Remove(contactDetalis);
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
