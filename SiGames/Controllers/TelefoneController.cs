using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiGames.Models;

namespace SiGames.Controllers
{
    public class TelefoneController : Controller
    {
        private sigamesEntities db = new sigamesEntities();

        //
        // GET: /Telefone/

        public ActionResult Index()
        {
            var telefone = db.telefone.Include(t => t.pessoa).Include(t => t.tipo_telefone);
            return View(telefone.ToList());
        }

        //
        // GET: /Telefone/Details/5

        public ActionResult Details(int id )
        {
            telefone telefone = db.telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        //
        // GET: /Telefone/Create

        public ActionResult Create()
        {
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome");
            ViewBag.IdTipoTelefone = new SelectList(db.tipo_telefone, "IdTipoTelefone", "Descricao");
            return View();
        }

        //
        // POST: /Telefone/Create

        [HttpPost]
        public ActionResult Create(telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.telefone.Add(telefone);
                db.SaveChanges();
                return RedirectToAction("../Endereco/create");
            }

            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", telefone.IdPessoa);
            ViewBag.IdTipoTelefone = new SelectList(db.tipo_telefone, "IdTipoTelefone", "Descricao", telefone.IdTipoTelefone);
            return View(telefone);
        }

        //
        // GET: /Telefone/Edit/5

        public ActionResult Edit(int id )
        {
            telefone telefone = new telefone();
            if (telefone == null)
            {
                return HttpNotFound();
            }
            telefone = (telefone)db.telefone.Where(c => c.IdPessoa == id).First();
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", telefone.IdPessoa);
            ViewBag.IdTipoTelefone = new SelectList(db.tipo_telefone, "IdTipoTelefone", "Descricao", telefone.IdTipoTelefone);
            return View(telefone);
        }

        //
        // POST: /Telefone/Edit/5

        [HttpPost]
        public ActionResult Edit(telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../endereco/edit", new { id = telefone.IdPessoa });
            }
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", telefone.IdPessoa);
            ViewBag.IdTipoTelefone = new SelectList(db.tipo_telefone, "IdTipoTelefone", "Descricao", telefone.IdTipoTelefone);
            return View(telefone);
        }

        //
        // GET: /Telefone/Delete/5

        public ActionResult Delete(int id )
        {
            telefone telefone = db.telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        //
        // POST: /Telefone/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            telefone telefone = db.telefone.Find(id);
            db.telefone.Remove(telefone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}