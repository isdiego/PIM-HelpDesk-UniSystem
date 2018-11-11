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
    public class AddTecnicoController : Controller
    {
        private BDUniSystemHelpDesk db = new BDUniSystemHelpDesk();

        // GET: AddTecnico
        public ActionResult Index()
        {
            return View(db.US_TECNICO.ToList());
        }

        // GET: AddTecnico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_TECNICO uS_TECNICO = db.US_TECNICO.Find(id);
            if (uS_TECNICO == null)
            {
                return HttpNotFound();
            }
            return View(uS_TECNICO);
        }

        // GET: AddTecnico/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddTecnico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TECNICO,TECNICO")] US_TECNICO uS_TECNICO)
        {
            if (ModelState.IsValid)
            {
                db.US_TECNICO.Add(uS_TECNICO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uS_TECNICO);
        }

        // GET: AddTecnico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_TECNICO uS_TECNICO = db.US_TECNICO.Find(id);
            if (uS_TECNICO == null)
            {
                return HttpNotFound();
            }
            return View(uS_TECNICO);
        }

        // POST: AddTecnico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TECNICO,TECNICO")] US_TECNICO uS_TECNICO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uS_TECNICO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uS_TECNICO);
        }

        // GET: AddTecnico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_TECNICO uS_TECNICO = db.US_TECNICO.Find(id);
            if (uS_TECNICO == null)
            {
                return HttpNotFound();
            }
            return View(uS_TECNICO);
        }

        // POST: AddTecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            US_TECNICO uS_TECNICO = db.US_TECNICO.Find(id);
            db.US_TECNICO.Remove(uS_TECNICO);
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
