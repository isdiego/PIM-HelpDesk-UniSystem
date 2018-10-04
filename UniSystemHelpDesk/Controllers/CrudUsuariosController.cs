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
    public class CrudUsuariosController : Controller
    {
        private UniSystemBD db = new UniSystemBD();

        // GET: CrudUsuarios
        public ActionResult Index()
        {
            var uS_USUARIOS = db.US_USUARIOS.Include(u => u.US_SETORES).Include(u => u.US_TIPO_USUARIO);
            return View(uS_USUARIOS.ToList());
        }

        // GET: CrudUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_USUARIOS uS_USUARIOS = db.US_USUARIOS.Find(id);
            if (uS_USUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(uS_USUARIOS);
        }

        // GET: CrudUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.ID_SETOR = new SelectList(db.US_SETORES, "ID_SETOR", "SETOR");
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.US_TIPO_USUARIO, "ID_TIPO_USUARIO", "TIPO_USUARIO");
            return View();
        }

        // POST: CrudUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_USUARIOS,NOME_USUARIO,EMAIL_USUARIO,SENHA_USUARIO,ID_TIPO_USUARIO,ID_SETOR")] US_USUARIOS uS_USUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.US_USUARIOS.Add(uS_USUARIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SETOR = new SelectList(db.US_SETORES, "ID_SETOR", "SETOR", uS_USUARIOS.ID_SETOR);
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.US_TIPO_USUARIO, "ID_TIPO_USUARIO", "TIPO_USUARIO", uS_USUARIOS.ID_TIPO_USUARIO);
            return View(uS_USUARIOS);
        }

        // GET: CrudUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_USUARIOS uS_USUARIOS = db.US_USUARIOS.Find(id);
            if (uS_USUARIOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SETOR = new SelectList(db.US_SETORES, "ID_SETOR", "SETOR", uS_USUARIOS.ID_SETOR);
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.US_TIPO_USUARIO, "ID_TIPO_USUARIO", "TIPO_USUARIO", uS_USUARIOS.ID_TIPO_USUARIO);
            return View(uS_USUARIOS);
        }

        // POST: CrudUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_USUARIOS,NOME_USUARIO,EMAIL_USUARIO,SENHA_USUARIO,ID_TIPO_USUARIO,ID_SETOR")] US_USUARIOS uS_USUARIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uS_USUARIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SETOR = new SelectList(db.US_SETORES, "ID_SETOR", "SETOR", uS_USUARIOS.ID_SETOR);
            ViewBag.ID_TIPO_USUARIO = new SelectList(db.US_TIPO_USUARIO, "ID_TIPO_USUARIO", "TIPO_USUARIO", uS_USUARIOS.ID_TIPO_USUARIO);
            return View(uS_USUARIOS);
        }

        // GET: CrudUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_USUARIOS uS_USUARIOS = db.US_USUARIOS.Find(id);
            if (uS_USUARIOS == null)
            {
                return HttpNotFound();
            }
            return View(uS_USUARIOS);
        }

        // POST: CrudUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            US_USUARIOS uS_USUARIOS = db.US_USUARIOS.Find(id);
            db.US_USUARIOS.Remove(uS_USUARIOS);
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
