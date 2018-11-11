using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniSystemHelpDesk.Models;

namespace UniSystemHelpDesk.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AddSetorController : Controller
    {
        private BDUniSystemHelpDesk db = new BDUniSystemHelpDesk();

        // GET: AddSetor
        public ActionResult Index()
        {
            return View(db.US_SETORES.ToList());
        }

        // GET: AddSetor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_SETORES uS_SETORES = db.US_SETORES.Find(id);
            if (uS_SETORES == null)
            {
                return HttpNotFound();
            }
            return View(uS_SETORES);
        }

        // GET: AddSetor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddSetor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SETOR,SETOR")] US_SETORES uS_SETORES)
        {
            if (ModelState.IsValid)
            {
                db.US_SETORES.Add(uS_SETORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uS_SETORES);
        }

        // GET: AddSetor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_SETORES uS_SETORES = db.US_SETORES.Find(id);
            if (uS_SETORES == null)
            {
                return HttpNotFound();
            }
            return View(uS_SETORES);
        }

        // POST: AddSetor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SETOR,SETOR")] US_SETORES uS_SETORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uS_SETORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uS_SETORES);
        }

        // GET: AddSetor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_SETORES uS_SETORES = db.US_SETORES.Find(id);
            if (uS_SETORES == null)
            {
                return HttpNotFound();
            }
            return View(uS_SETORES);
        }

        // POST: AddSetor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            US_SETORES uS_SETORES = db.US_SETORES.Find(id);
            db.US_SETORES.Remove(uS_SETORES);
            db.SaveChanges();
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
