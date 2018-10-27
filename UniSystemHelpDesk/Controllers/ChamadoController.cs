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
    [Authorize(Roles = "Usuário")]
    public class ChamadoController : Controller
    {
        private BDUniSystemHelpDesk db = new BDUniSystemHelpDesk();

        // GET: Chamado
        public ActionResult Index()
        {
            var uS_CHAMADOS = db.US_CHAMADOS.Include(u => u.US_EQUIPAMENTO).Include(u => u.US_STATUS).Include(u => u.US_USUARIOS);
            return View(uS_CHAMADOS.ToList());
        }

        // GET: Chamado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_CHAMADOS uS_CHAMADOS = db.US_CHAMADOS.Find(id);
            if (uS_CHAMADOS == null)
            {
                return HttpNotFound();
            }
            return View(uS_CHAMADOS);
        }

        // GET: Chamado/Create
        public ActionResult Create()
        {
            ViewBag.ID_EQUIPAMENTO = new SelectList(db.US_EQUIPAMENTO, "ID_EQUIPAMENTO", "EQUIPAMENTO");
            ViewBag.ID_STATUS_CHAMADO = new SelectList(db.US_STATUS.Where(a => a.STATUS_CHAMADO == "Aberto"), "ID_STATUS_CHAMADO", "STATUS_CHAMADO");
            ViewBag.ID_USUARIOS_RESP = new SelectList(db.US_USUARIOS.Where(a => a.EMAIL_USUARIO == User.Identity.Name), "ID_USUARIOS", "NOME_USUARIO");
            return View();
        }

        // POST: Chamado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CHAMADO,CHAMADO,DATA_CRIACAO_CHAMADO,DATA_INICIO_SUPORTE,DATA_FINALIZACAO_CHAMADO,SOLUCAO,COMENTARIOS,ID_USUARIOS_RESP,ID_EQUIPAMENTO,ID_STATUS_CHAMADO")] US_CHAMADOS uS_CHAMADOS)
        {
            if (ModelState.IsValid)
            {
                db.US_CHAMADOS.Add(uS_CHAMADOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_EQUIPAMENTO = new SelectList(db.US_EQUIPAMENTO, "ID_EQUIPAMENTO", "EQUIPAMENTO", uS_CHAMADOS.ID_EQUIPAMENTO);
            ViewBag.ID_STATUS_CHAMADO = new SelectList(db.US_STATUS, "ID_STATUS_CHAMADO", "STATUS_CHAMADO", uS_CHAMADOS.ID_STATUS_CHAMADO);
            ViewBag.ID_USUARIOS_RESP = new SelectList(db.US_USUARIOS, "ID_USUARIOS", "NOME_USUARIO", uS_CHAMADOS.ID_USUARIOS_RESP);
            return View(uS_CHAMADOS);
        }

        // GET: Chamado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_CHAMADOS uS_CHAMADOS = db.US_CHAMADOS.Find(id);
            if (uS_CHAMADOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_EQUIPAMENTO = new SelectList(db.US_EQUIPAMENTO, "ID_EQUIPAMENTO", "EQUIPAMENTO", uS_CHAMADOS.ID_EQUIPAMENTO);
            ViewBag.ID_STATUS_CHAMADO = new SelectList(db.US_STATUS, "ID_STATUS_CHAMADO", "STATUS_CHAMADO", uS_CHAMADOS.ID_STATUS_CHAMADO);
            ViewBag.ID_USUARIOS_RESP = new SelectList(db.US_USUARIOS, "ID_USUARIOS", "NOME_USUARIO", uS_CHAMADOS.ID_USUARIOS_RESP);
            return View(uS_CHAMADOS);
        }

        // POST: Chamado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CHAMADO,CHAMADO,DATA_CRIACAO_CHAMADO,DATA_INICIO_SUPORTE,DATA_FINALIZACAO_CHAMADO,SOLUCAO,COMENTARIOS,ID_USUARIOS_RESP,ID_EQUIPAMENTO,ID_STATUS_CHAMADO")] US_CHAMADOS uS_CHAMADOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uS_CHAMADOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_EQUIPAMENTO = new SelectList(db.US_EQUIPAMENTO, "ID_EQUIPAMENTO", "EQUIPAMENTO", uS_CHAMADOS.ID_EQUIPAMENTO);
            ViewBag.ID_STATUS_CHAMADO = new SelectList(db.US_STATUS, "ID_STATUS_CHAMADO", "STATUS_CHAMADO", uS_CHAMADOS.ID_STATUS_CHAMADO);
            ViewBag.ID_USUARIOS_RESP = new SelectList(db.US_USUARIOS, "ID_USUARIOS", "NOME_USUARIO", uS_CHAMADOS.ID_USUARIOS_RESP);
            return View(uS_CHAMADOS);
        }

        // GET: Chamado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            US_CHAMADOS uS_CHAMADOS = db.US_CHAMADOS.Find(id);
            if (uS_CHAMADOS == null)
            {
                return HttpNotFound();
            }
            return View(uS_CHAMADOS);
        }

        // POST: Chamado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            US_CHAMADOS uS_CHAMADOS = db.US_CHAMADOS.Find(id);
            db.US_CHAMADOS.Remove(uS_CHAMADOS);
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
