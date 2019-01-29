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
    public class ContactUserModelsController : Controller
    {
        private ConnectDataModel db = new ConnectDataModel();

        // GET: Admin/ContactUserModels
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactUserModels.ToListAsync());
        }

        // GET: Admin/ContactUserModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUserModel contactUserModel = await db.ContactUserModels.FindAsync(id);
            if (contactUserModel == null)
            {
                return HttpNotFound();
            }
            return View(contactUserModel);
        }

        // GET: Admin/ContactUserModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ContactUserModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserName,UserEmail,UserResume")] ContactUserModel contactUserModel)
        {
            if (ModelState.IsValid)
            {
                db.ContactUserModels.Add(contactUserModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactUserModel);
        }

        // GET: Admin/ContactUserModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUserModel contactUserModel = await db.ContactUserModels.FindAsync(id);
            if (contactUserModel == null)
            {
                return HttpNotFound();
            }
            return View(contactUserModel);
        }

        // POST: Admin/ContactUserModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserName,UserEmail,UserResume")] ContactUserModel contactUserModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactUserModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactUserModel);
        }

        // GET: Admin/ContactUserModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUserModel contactUserModel = await db.ContactUserModels.FindAsync(id);
            if (contactUserModel == null)
            {
                return HttpNotFound();
            }
            return View(contactUserModel);
        }

        // POST: Admin/ContactUserModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactUserModel contactUserModel = await db.ContactUserModels.FindAsync(id);
            db.ContactUserModels.Remove(contactUserModel);
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
