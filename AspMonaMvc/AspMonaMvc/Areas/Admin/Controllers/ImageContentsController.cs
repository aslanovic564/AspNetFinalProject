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
    public class ImageContentsController : Controller
    {
        private ConnectDataModel db = new ConnectDataModel();

        // GET: Admin/ImageContents
        public async Task<ActionResult> Index()
        {
            var imageContents = db.ImageContents.Include(i => i.ClientsFedbackModels).Include(i => i.HomePageChange).Include(i => i.LatestNewsContent).Include(i => i.ModellsChange).Include(i => i.MonaTeamModel);
            return View(await imageContents.ToListAsync());
        }

        // GET: Admin/ImageContents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageContent imageContent = await db.ImageContents.FindAsync(id);
            if (imageContent == null)
            {
                return HttpNotFound();
            }
            return View(imageContent);
        }

        // GET: Admin/ImageContents/Create
        public ActionResult Create()
        {
            ViewBag.ClientsFedbackModelsId = new SelectList(db.ClientsFedbackModels, "Id", "ClientName");
            ViewBag.HomePageChangeId = new SelectList(db.HomePageChanges, "Id", "Facebook");
            ViewBag.LatestNewsContentId = new SelectList(db.LatestNewsContents, "Id", "NewsImageUrl");
            ViewBag.ModellsChangeId = new SelectList(db.ModellsChanges, "Id", "ModelFullName");
            ViewBag.MonaTeamModelId = new SelectList(db.MonaTeamModels, "Id", "TeamImagesDescription");
            return View();
        }

        // POST: Admin/ImageContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ImageUrlName,MonaTeamModelId,LatestNewsContentId,ClientsFedbackModelsId,ModellsChangeId,HomePageChangeId")] ImageContent imageContent,HttpPostedFileBase Img)
        {
            
            if (ModelState.IsValid)
            {
                Extentionss extentionss = new Extentionss();
                if (extentionss.CheckImageType(Img) && extentionss.CheckeImageSize(Img, 30))
                {
                    db.ImageContents.Add(imageContent);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.ClientsFedbackModelsId = new SelectList(db.ClientsFedbackModels, "Id", "ClientName", imageContent.ClientsFedbackModelsId);
                ViewBag.HomePageChangeId = new SelectList(db.HomePageChanges, "Id", "Facebook", imageContent.HomePageChangeId);
                ViewBag.LatestNewsContentId = new SelectList(db.LatestNewsContents, "Id", "NewsImageUrl", imageContent.LatestNewsContentId);
                ViewBag.ModellsChangeId = new SelectList(db.ModellsChanges, "Id", "ModelFullName", imageContent.ModellsChangeId);
                ViewBag.MonaTeamModelId = new SelectList(db.MonaTeamModels, "Id", "TeamImagesDescription", imageContent.MonaTeamModelId);
           
            }
            return View(imageContent);

        }

        // GET: Admin/ImageContents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageContent imageContent = await db.ImageContents.FindAsync(id);
            if (imageContent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientsFedbackModelsId = new SelectList(db.ClientsFedbackModels, "Id", "ClientName", imageContent.ClientsFedbackModelsId);
            ViewBag.HomePageChangeId = new SelectList(db.HomePageChanges, "Id", "Facebook", imageContent.HomePageChangeId);
            ViewBag.LatestNewsContentId = new SelectList(db.LatestNewsContents, "Id", "NewsImageUrl", imageContent.LatestNewsContentId);
            ViewBag.ModellsChangeId = new SelectList(db.ModellsChanges, "Id", "ModelFullName", imageContent.ModellsChangeId);
            ViewBag.MonaTeamModelId = new SelectList(db.MonaTeamModels, "Id", "TeamImagesDescription", imageContent.MonaTeamModelId);
            return View(imageContent);
        }

        // POST: Admin/ImageContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ImageUrlName,MonaTeamModelId,LatestNewsContentId,ClientsFedbackModelsId,ModellsChangeId,HomePageChangeId")] ImageContent imageContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageContent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClientsFedbackModelsId = new SelectList(db.ClientsFedbackModels, "Id", "ClientName", imageContent.ClientsFedbackModelsId);
            ViewBag.HomePageChangeId = new SelectList(db.HomePageChanges, "Id", "Facebook", imageContent.HomePageChangeId);
            ViewBag.LatestNewsContentId = new SelectList(db.LatestNewsContents, "Id", "NewsImageUrl", imageContent.LatestNewsContentId);
            ViewBag.ModellsChangeId = new SelectList(db.ModellsChanges, "Id", "ModelFullName", imageContent.ModellsChangeId);
            ViewBag.MonaTeamModelId = new SelectList(db.MonaTeamModels, "Id", "TeamImagesDescription", imageContent.MonaTeamModelId);
            return View(imageContent);
        }

        // GET: Admin/ImageContents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageContent imageContent = await db.ImageContents.FindAsync(id);
            if (imageContent == null)
            {
                return HttpNotFound();
            }
            return View(imageContent);
        }

        // POST: Admin/ImageContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ImageContent imageContent = await db.ImageContents.FindAsync(id);
            db.ImageContents.Remove(imageContent);
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
