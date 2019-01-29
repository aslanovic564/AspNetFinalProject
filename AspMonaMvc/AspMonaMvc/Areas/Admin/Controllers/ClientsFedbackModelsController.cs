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
    public class ClientsFedbackModelsController : Controller
    {
        private ConnectDataModel db = new ConnectDataModel();

        // GET: Admin/ClientsFedbackModels
        public async Task<ActionResult> Index()
        {
            return View(await db.ClientsFedbackModels.ToListAsync());
        }

        // GET: Admin/ClientsFedbackModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientsFedbackModel clientsFedbackModel = await db.ClientsFedbackModels.FindAsync(id);
            if (clientsFedbackModel == null)
            {
                return HttpNotFound();
            }
            return View(clientsFedbackModel);
        }

        // GET: Admin/ClientsFedbackModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ClientsFedbackModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ClientName,ClientStatus,Descriptions")] ClientsFedbackModel clientsFedbackModel)
        {
            if (ModelState.IsValid)
            {
                db.ClientsFedbackModels.Add(clientsFedbackModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clientsFedbackModel);
        }

        // GET: Admin/ClientsFedbackModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientsFedbackModel clientsFedbackModel = await db.ClientsFedbackModels.FindAsync(id);
            if (clientsFedbackModel == null)
            {
                return HttpNotFound();
            }
            return View(clientsFedbackModel);
        }

        // POST: Admin/ClientsFedbackModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ClientName,ClientStatus,Descriptions")] ClientsFedbackModel clientsFedbackModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientsFedbackModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clientsFedbackModel);
        }

        // GET: Admin/ClientsFedbackModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientsFedbackModel clientsFedbackModel = await db.ClientsFedbackModels.FindAsync(id);
            if (clientsFedbackModel == null)
            {
                return HttpNotFound();
            }
            return View(clientsFedbackModel);
        }

        // POST: Admin/ClientsFedbackModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClientsFedbackModel clientsFedbackModel = await db.ClientsFedbackModels.FindAsync(id);
            db.ClientsFedbackModels.Remove(clientsFedbackModel);
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
