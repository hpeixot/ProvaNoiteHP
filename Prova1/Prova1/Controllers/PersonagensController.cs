using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prova1.Models;
using Web.Models.Contexto;

namespace Prova1.Controllers
{
    public class PersonagensController : Controller
    {
        private MeuContexto db = new MeuContexto();

        // GET: Personagens
        public ActionResult Index()
        {
            return View(db.Personagens.ToList());
        }

        // GET: Personagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagens personagens = db.Personagens.Find(id);
            if (personagens == null)
            {
                return HttpNotFound();
            }
            return View(personagens);
        }

        // GET: Personagens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personagens/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonagensID,PersonagensTipo,PersonagensEspecialidade")] Personagens personagens)
        {
            if (ModelState.IsValid)
            {
                db.Personagens.Add(personagens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personagens);
        }

        // GET: Personagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagens personagens = db.Personagens.Find(id);
            if (personagens == null)
            {
                return HttpNotFound();
            }
            return View(personagens);
        }

        // POST: Personagens/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonagensID,PersonagensTipo,PersonagensEspecialidade")] Personagens personagens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personagens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personagens);
        }

        // GET: Personagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagens personagens = db.Personagens.Find(id);
            if (personagens == null)
            {
                return HttpNotFound();
            }
            return View(personagens);
        }

        // POST: Personagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personagens personagens = db.Personagens.Find(id);
            db.Personagens.Remove(personagens);
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
