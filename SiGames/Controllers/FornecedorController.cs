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
    public class FornecedorController : Controller
    {
        private sigamesEntities db = new sigamesEntities();

        //
        // GET: /Fornecedor/

        public ActionResult Index()
        {
            var fornecedor = db.fornecedor.Include(f => f.pessoa);
            return View(fornecedor.ToList());
        }

        //
        // GET: /Fornecedor/Details/5

        public ActionResult Details(int id )
        {
            fornecedor fornecedor = db.fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        //
        // GET: /Fornecedor/Create

        public ActionResult Create()
        {
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome");
            return View();
        }

        //
        // POST: /Fornecedor/Create

        [HttpPost]
        public ActionResult Create(fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.fornecedor.Add(fornecedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", fornecedor.IdPessoa);
            return View(fornecedor);
        }

        //
        // GET: /Fornecedor/Edit/5

        public ActionResult Edit(int id )
        {
            fornecedor fornecedor = db.fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", fornecedor.IdPessoa);
            return View(fornecedor);
        }

        //
        // POST: /Fornecedor/Edit/5

        [HttpPost]
        public ActionResult Edit(fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", fornecedor.IdPessoa);
            return View(fornecedor);
        }

        //
        // GET: /Fornecedor/Delete/5

        public ActionResult Delete(int id )
        {
            fornecedor fornecedor = db.fornecedor.Find(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        //
        // POST: /Fornecedor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            fornecedor fornecedor = db.fornecedor.Find(id);
            db.fornecedor.Remove(fornecedor);
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